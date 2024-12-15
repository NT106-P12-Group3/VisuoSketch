using WindowsFormsSign;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsSign
{
    public partial class Phong : Form
    {
        public Phong()
        {
            InitializeComponent();
            PictureBox pictureBoxBackground = new PictureBox();
            pictureBoxBackground.Dock = DockStyle.Fill;
            pictureBoxBackground.Image = Image.FromFile(@"D:\WindowsFormsSign\Source\BackGround.gif");
            pictureBoxBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pictureBoxBackground);
            pictureBoxBackground.SendToBack();
        }

        private bool isOffline;

        private void go_to_canvas(string serverIP, int code, string username, string roomID = "")
        {
            Form_Client canvas = new Form_Client(isOffline, serverIP, code, username, roomID);
            canvas.Show();
        }

        public bool IPv4IsValid(string ipv4)
        {
            if (String.IsNullOrWhiteSpace(ipv4)) return false;

            string[] splitValues = ipv4.Split('.');
            if (splitValues.Length != 4) return false;

            byte posNum;
            return splitValues.All(i => byte.TryParse(i, out posNum));
        }

        private void Phong_Load(object sender, EventArgs e)
        {
            this.button_mode_offline.Visible = true;
            this.button_mode_online.Visible = true;
            this.button_create_room.Visible = false;
            this.button_join_room.Visible = false;
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = false;
            this.textBox_name.Visible = false;
            this.textBox_server_IP.Visible = false;
            this.textBox_code_room.Visible = false;
            this.button_go_create_room.Visible = false;
            this.button_go_join_room.Visible = false;
            this.button_go_create_canvas.Visible = false;
        }

        private void button_mode_offline_Click(object sender, EventArgs e)
        {
            this.isOffline = true;
            this.button_go_create_canvas.Visible = true;
            this.button_create_room.Visible = false;
            this.button_join_room.Visible = false;
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = false;
            this.textBox_name.Visible = false;
            this.textBox_server_IP.Visible = false;
            this.textBox_code_room.Visible = false;
            this.button_go_create_room.Visible = false;
            this.button_go_join_room.Visible = false;
        }

        private void button_mode_online_Click(object sender, EventArgs e)
        {
            this.isOffline = false;
            this.button_go_create_canvas.Visible = false;
            this.button_create_room.Visible = true;
            this.button_join_room.Visible = true;
        }

        private void button_create_room_Click(object sender, EventArgs e)
        {
            this.label1.Visible = true;
            this.label2.Visible = true;
            this.label3.Visible = false;
            this.textBox_name.Visible = true;
            this.textBox_server_IP.Visible = true;
            this.textBox_code_room.Visible = false;
            this.button_go_create_room.Visible = true;
            this.button_go_join_room.Visible = false;
        }

        private void button_join_room_Click(object sender, EventArgs e)
        {
            this.label1.Visible = true;
            this.label2.Visible = true;
            this.label3.Visible = true;
            this.textBox_name.Visible = true;
            this.textBox_server_IP.Visible = true;
            this.textBox_code_room.Visible = true;
            this.button_go_create_room.Visible = false;
            this.button_go_join_room.Visible = true;
        }

        private void button_go_create_canvas_Click(object sender, EventArgs e)
        {
            Form_Client canvas = new Form_Client(isOffline, "", 0, "", "");
            canvas.Show();
        }

        private void button_go_create_room_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text == "")
            {
                MessageBox.Show("Please enter nickname");
                return;
            }
            if (textBox_name.Text.Contains("!"))
            {
                MessageBox.Show("Nicknames cannot contain exclamation marks (!)");
                return;
            }
            if (!IPv4IsValid(textBox_server_IP.Text))
            {
                MessageBox.Show("Please enter a valid IPv4 address");
                return;
            }

            this.Hide();

            string username = textBox_name.Text;
            string serverIP = textBox_server_IP.Text;
            go_to_canvas(serverIP, 0, username);
        }

        private void button_go_join_room_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text == "" || textBox_code_room.Text == "")
            {
                MessageBox.Show("Please enter nickname and room code");
                return;
            }
            if (!IPv4IsValid(textBox_server_IP.Text))
            {
                MessageBox.Show("Please enter a valid IPv4 address");
                return;
            }
            if (textBox_name.Text.Contains("!"))
            {
                MessageBox.Show("Nicknames cannot contain exclamation marks (!)");
                return;
            }
            string check_roomID = textBox_code_room.Text;
            if (check_roomID.Length != 4 || check_roomID.Any(char.IsLetter))
            {
                MessageBox.Show("Room code not valid");
                return;
            }

            this.Hide();

            string username = textBox_name.Text;
            string roomID = textBox_code_room.Text;
            string serverIP = textBox_server_IP.Text;
            go_to_canvas(serverIP, 1, username, roomID);
        }

        private void linkLabel_back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.ShowDialog();
            this.Close();
        }
    }
}
