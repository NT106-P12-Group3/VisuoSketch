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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
            PictureBox pictureBoxBackground = new PictureBox();
            pictureBoxBackground.Dock = DockStyle.Fill;
            pictureBoxBackground.Image = Image.FromFile(@"D:\WindowsFormsSign\Source\BackGround.gif");
            pictureBoxBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pictureBoxBackground);
            pictureBoxBackground.SendToBack();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            QuenMatKhau quenMatKhau = new QuenMatKhau();
            quenMatKhau.ShowDialog();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormDangKy formDangKy = new FormDangKy();
            formDangKy.ShowDialog();
            this.Close();
        }

        Modify modify = new Modify();

        private void button1_Click(object sender, EventArgs e)
        {
            string tentk = textBox1.Text;
            string matkhau = textBox2.Text;
            if (tentk.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!");
                return;
            }
            else if (matkhau.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }
            else
            {
                string query = "Select * from TaiKhoan where TenTaiKhoan = '"+tentk+ "' and MatKhau = '"+matkhau+"'";
                if (modify.TaiKhoans(query).Count!=0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Hide();
                    Phong phong = new Phong();
                    phong.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBatDau formBatDau = new FormBatDau();
            formBatDau.ShowDialog();
            this.Close();
        }
    }
}
