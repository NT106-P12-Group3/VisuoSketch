using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using WindowsFormsSign;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace WindowsFormsSign
{
    public partial class Form_Client : Form
    {
        private Bitmap bitmap;
        private Graphics graphics;
        private Boolean cursorMoving = false;
        private Pen cursorPen;
        private int cursorX = -1;
        private int cursorY = -1;
        private Point p = new Point();
        private Color stateColor;
        private int shapeTag = 10;

        private ColorDialog cd = new ColorDialog();

        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private Packet this_client_info;
        private IPEndPoint serverIP;
        private Manager Manager;
        private bool isOffline;
        private bool isNew;

        private SynchronizationContext context = SynchronizationContext.Current ?? new SynchronizationContext();
        private const string PexelsApiKey = "fekai6VjdPTPzbL0e4kYM0l8HmTI0f3XSTw3W6NGKT8c65w28DcCvV4v";

        private Bitmap overlayImage;
        private bool isOverlayVisible = true; 


        public Form_Client(bool mode, string _serverIP, int code, string username, string roomID)
        {
            InitializeComponent();

            bitmap = new Bitmap(Canvas.Width, Canvas.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Canvas.Image = bitmap;
            stateColor = Color.Black;
            cursorPen = new Pen(stateColor, 2);
            PenOptimizer(cursorPen);
            this.ActiveControl = null;

            this_client_info = new Packet()
            {
                Code = code,
                Username = username,
                RoomID = roomID,
            };

            isNew = true;
            isOffline = mode;
            if (!isOffline)
            {
                textBox_room_code.Visible = true;
                serverIP = new IPEndPoint(IPAddress.Parse(_serverIP), 9999);
            }

            Manager = new Manager(listView_room_users, textBox_room_code);

            Canvas.Paint += Canvas_Paint;
        }

        private void Form_Client_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            if (!isOffline)
            {
                try
                {
                    client = new TcpClient();
                    client.Connect(serverIP);
                }
                catch
                {
                    Manager.ShowError("Can not connect to the server!");
                    this.Close();
                    return;
                }
                NetworkStream stream = client.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                sendToServer(this_client_info);
                Manager.UpdateRoomID(this_client_info.RoomID);
                Manager.AddToUserListView(this_client_info.Username + " (you)");

                Thread listen = new Thread(Receive);
                listen.IsBackground = true;
                listen.Start();
            }
        }

        private void Receive()
        {
            try
            {
                string responseInJson = string.Empty;
                while (true)
                {
                    responseInJson = reader.ReadLine();

                    Packet response = JsonConvert.DeserializeObject<Packet>(responseInJson);

                    switch (response.Code)
                    {
                        case 0:
                            generate_room_status(response);
                            break;
                        case 1:
                            join_room_status(response);
                            break;
                        case 2:
                            sync_bitmap_status(response);
                            break;
                        case 3:
                            draw_bitmap_handler(response);
                            break;
                        case 4:
                            draw_graphics_handler(response);
                            break;
                    }
                }
            }
            catch
            {
                client.Close();
            }
        }

        void generate_room_status(Packet response)
        {
            this_client_info.RoomID = response.RoomID;
            Manager.UpdateRoomID(this_client_info.RoomID);
            isNew = false;
        }

        void join_room_status(Packet response)
        {
            if (isNew)
            {
                sendToServer(new Packet
                {
                    Code = 2,
                    RoomID = response.RoomID,
                });
                isNew = false;
            }

            if (response.Username == "err:thisroomdoesnotexist")
            {
                Manager.ShowError("The room you requested does not exist");
                client.Close();
                this.Close();
                return;
            }

            if (response.Username.Contains('!'))
            {
                Manager.RemoveFromUserListView(response.Username.Substring(1));
            }
            else
            {
                List<string> list = response.Username.Split(',').ToList();
                foreach (string username in list)
                {
                    if (username == this_client_info.Username)
                    {
                        list.Remove(username);
                        break;
                    }
                }
                Manager.ClearUserListView();
                foreach (string username in list)
                {
                    Manager.AddToUserListView(username);
                }
            }
        }

        private void sync_bitmap_status(Packet respone)
        {
            Packet message = new Packet
            {
                Code = 3,
                RoomID = respone.RoomID,
                BitmapString = Manager.BitmapToString(bitmap),
            };
            sendToServer(message);
        }

        private void draw_bitmap_handler(Packet response)
        {
            Bitmap _bitmap = Manager.StringToBitmap(response.BitmapString);
            bitmap = _bitmap;
            graphics = Graphics.FromImage(bitmap);
            Canvas.Image = bitmap;
            context.Send(s =>
            {
                Canvas.Refresh();
            }, null);
        }

        void draw_graphics_handler(Packet response)
        {
            Pen p = new Pen(Color.FromName(response.PenColor), response.PenWidth);
            PenOptimizer(p);
            int cursorX = 0, cursorY = 0;
            float w = 0, h = 0;

            if (response.ShapeTag == 10)
            {
                int length = response.Points_1.ToArray().Length;

                for (int i = 0; i < length; i++)
                {
                    context.Send(s =>
                    {
                        graphics.DrawLine(p, response.Points_1[i], response.Points_2[i]);
                    }, null);
                }
            }
            else
            {
                cursorX = (int)response.Position[0];
                cursorY = (int)response.Position[1];
                w = response.Position[2];
                h = response.Position[3];
            }
            if (response.ShapeTag == 11)
            {
                context.Send(s =>
                {
                    graphics.DrawLine(p, cursorX, cursorY, w + cursorX, h + cursorY);
                }, null);
            }
            if (response.ShapeTag == 12)
            {
                context.Send(s =>
                {
                    graphics.DrawRectangle(p, cursorX, cursorY, w, h);
                }, null);
            }
            if (response.ShapeTag == 13)
            {
                context.Send(s =>
                {
                    graphics.DrawEllipse(p, cursorX, cursorY, w, h);
                }, null);
            }
            context.Send(s =>
            {
                Canvas.Refresh();
            }, null);
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            cursorMoving = true;
            cursorX = e.X;
            cursorY = e.Y;
        }

        static List<Point> points_1 = new List<Point>();
        static List<Point> points_2 = new List<Point>();

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (cursorX != -1 && cursorY != -1 && cursorMoving && (shapeTag == 10))
            {
                p = e.Location;

                points_1.Add(new Point(cursorX, cursorY));
                points_2.Add(p);

                // Vẽ đường thẳng
                graphics.DrawLine(cursorPen, new Point(cursorX, cursorY), p);

                cursorX = e.X;
                cursorY = e.Y;

                Canvas.Invalidate();
                Canvas.Update();
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            float w = e.Location.X - cursorX;
            float h = e.Location.Y - cursorY;

            if (shapeTag == 11)
            {
                graphics.DrawLine(cursorPen, cursorX, cursorY, w + cursorX, h + cursorY);
            }
            if (shapeTag == 12)
            {
                graphics.DrawRectangle(cursorPen, cursorX, cursorY, w, h);
            }
            if (shapeTag == 13)
            {
                graphics.DrawEllipse(cursorPen, cursorX, cursorY, w, h);
            }
            context.Send(s =>
            {
                Canvas.Refresh();
            }, null);

            float[] pos = new float[] { cursorX, cursorY, w, h };

            Packet messsage = new Packet
            {
                Code = 4,
                Username = this_client_info.Username,
                RoomID = this_client_info.RoomID,
                PenColor = cursorPen.Color.Name,
                PenWidth = cursorPen.Width,
                ShapeTag = shapeTag,
                Points_1 = points_1,
                Points_2 = points_2,
                Position = pos
            };

            if (!isOffline)
            {
                sendToServer(messsage);
            }

            cursorMoving = false;
            cursorX = -1;
            cursorY = -1;
            points_1.Clear();
            points_2.Clear();
        }

        private void sendToServer(Packet message)
        {
            string messageInJson = JsonConvert.SerializeObject(message);
            try
            {
                writer.WriteLine(messageInJson);
                writer.Flush();
            }
            catch
            {
                Manager.ShowError("Failed to send data to server!");
            }
        }

        private void pictureBox_black_Click(object sender, EventArgs e)
        {
            PictureBox color = (PictureBox)sender;
            cursorPen.Color = color.BackColor;
            if (color.BackColor != Color.White)
            {
                stateColor = color.BackColor;
            }
            else
            {
                shapeTag = 10;
            }
            pictureBox_picking_color.BackColor = stateColor;
        }

        private void button_pen_width_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            cursorPen.Width = Convert.ToInt32(button.Tag);
        }

        private void button_shapes_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            shapeTag = Convert.ToInt32(button.Tag);
            cursorPen.Color = stateColor;
        }

        private void PenOptimizer(Pen pen)
        {
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Image (*.png) |*.png| (*.*) |*.*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Bitmap btm = bitmap.Clone(new Rectangle(0, 0, Canvas.Width, Canvas.Height), bitmap.PixelFormat);
                btm.Save(saveFile.FileName, ImageFormat.Png);
            }
        }

        int _temp = 0;
        private void textBox_room_code_Click(object sender, EventArgs e)
        {
            _temp++;
            if (_temp % 2 == 0)
            {
                listView_room_users.Visible = false;
            }
            else
            {
                listView_room_users.Visible = true;
            }
        }

        private void Form_Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isOffline)
            {
                client.Close();
            }
            Application.OpenForms["MainForm"].Close();
        }

        private void button_sign_out_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                FormDangNhap formDangNhap = new FormDangNhap();
                formDangNhap.ShowDialog();
            }
        }

        private void button_color_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();
            stateColor = cd.Color;
            pictureBox_picking_color.BackColor = cd.Color;
            cursorPen.Color = cd.Color;
        }

        private void pictureBox_custom_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = set_point(pictureBox_custom, e.Location);
            pictureBox_picking_color.BackColor = ((Bitmap)pictureBox_custom.Image).GetPixel(point.X, point.Y);
            stateColor = pictureBox_picking_color.BackColor;
            cursorPen.Color = pictureBox_picking_color.BackColor;
        }

        public void Fill(Bitmap bitmap, int x, int y, Color new_clr)
        {
            Color old_color = bitmap.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bitmap.SetPixel(x, y, new_clr);
            if (old_color == new_clr) return;

            while (pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();
                if (pt.X > 0 && pt.Y > 0 && pt.X < bitmap.Width - 1 && pt.Y < bitmap.Height - 1)
                {
                    validate(bitmap, pixel, pt.X - 1, pt.Y, old_color, new_clr);
                    validate(bitmap, pixel, pt.X, pt.Y - 1, old_color, new_clr);
                    validate(bitmap, pixel, pt.X + 1, pt.Y, old_color, new_clr);
                    validate(bitmap, pixel, pt.X, pt.Y + 1, old_color, new_clr);
                }
            }
        }

        static Point set_point(PictureBox pictureBox, Point pt)
        {
            float pX = 1f * pictureBox.Image.Width / pictureBox.Width;
            float pY = 1f * pictureBox.Image.Height / pictureBox.Height;
            return new Point((int)(pt.X * pX), (int)(pt.Y * pY));
        }

        private void validate(Bitmap bitmap, Stack<Point> sp, int x, int y, Color old_color, Color new_color)
        {
            Color cx = bitmap.GetPixel(x, y);
            if (cx == old_color)
            {
                sp.Push(new Point(x, y));
                bitmap.SetPixel(x, y, new_color);
            }
        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (shapeTag == 15)
            {
                Point point = set_point(Canvas, e.Location);
                Fill(bitmap, point.X, point.Y, stateColor);
            }
        }

        private void button_fill_Click(object sender, EventArgs e)
        {
            shapeTag = 15;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            Canvas.Image = bitmap;
            shapeTag = 0;
        }

        private void button_chat_Click(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible;
        }
        private async void button_get_Click(object sender, EventArgs e)
        {
            try
            {
                await GetImageAsync(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async Task GetImageAsync(string query)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", PexelsApiKey);
                    var encodedQuery = Uri.EscapeDataString(query);
                    var response = await client.GetAsync($"https://api.pexels.com/v1/search?query={encodedQuery}&per_page=1");
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var pexelsResponse = JsonConvert.DeserializeObject<PexelsResponse>(json);
                        var imageUrl = pexelsResponse?.Photos?[0]?.Src?.Original;
                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            var imageStream = await client.GetStreamAsync(imageUrl);
                            overlayImage = new Bitmap(imageStream); 
                            overlayImage = new Bitmap(overlayImage, Canvas.Size); 
                            Canvas.Invalidate(); 
                        }
                        else
                        {
                            MessageBox.Show("Image URL not found in the response.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Image not found.");
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"Request error: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public class PexelsResponse
        {
            public Photo[] Photos { get; set; }
        }

        public class Photo
        {
            public Src Src { get; set; }
        }

        public class Src
        {
            public string Original { get; set; }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0, Canvas.Width, Canvas.Height);

            if (isOverlayVisible && overlayImage != null)
            {
                ColorMatrix colorMatrix = new ColorMatrix
                {
                    Matrix33 = trackBar1.Value / 100f 
                };

                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    e.Graphics.DrawImage(overlayImage, new Rectangle(0, 0, Canvas.Width, Canvas.Height), 0, 0, overlayImage.Width, overlayImage.Height, GraphicsUnit.Pixel, attributes);
                }
            }
        }

        private void UpdateOverlayTransparency(float transparency)
        {
            Canvas.Invalidate(); 
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            float transparency = trackBar1.Value / 100f;
            UpdateOverlayTransparency(transparency);
        }
    }
}