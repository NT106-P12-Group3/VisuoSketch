using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsSign
{
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
            PictureBox pictureBoxBackground = new PictureBox();
            pictureBoxBackground.Dock = DockStyle.Fill;
            pictureBoxBackground.Image = Image.FromFile(@"D:\WindowsFormsSign\Source\BackGround.gif");
            pictureBoxBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pictureBoxBackground);
            pictureBoxBackground.SendToBack();
        }
        public bool CheckAccount(string account)
        {
            return Regex.IsMatch(account, "^[a-zA-Z0-9]{6,24}$");
        }
        public bool CheckEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");
        }
        Modify modify = new Modify();
        private void button1_Click(object sender, EventArgs e)
        {
            string tentk = textBox1.Text;
            string matkhau = textBox3.Text;
            string xnmatkhau = textBox4.Text;
            string email = textBox2.Text;
            if (!CheckAccount(tentk))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản từ 6 đến 24 ký tự, chỉ gồm chữ cái và số.");
                return;
            }

            if (!CheckAccount(matkhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu từ 6 đến 24 ký tự, chỉ gồm chữ cái và số.");
                return;
            }

            if (xnmatkhau != matkhau)
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu chính xác.");
                return;
            }

            if (!CheckEmail(email))
            {
                MessageBox.Show("Vui lòng nhập email đúng định dạng, sử dụng đuôi @gmail.com hoặc @gmail.com.vn.");
                return;
            }

            if (modify.TaiKhoans("Select * from TaiKhoan where Email = '"+email+"'").Count!=0)
            {
                MessageBox.Show("Email da duoc dang ky");
                return;
            }

            try
            {
                string query = "Insert into TaiKhoan values ('" + tentk + "','" + matkhau + "','" + email + "')";
                modify.Command(query);
                if (MessageBox.Show("Đăng ký thành công! Bạn có muốn đăng nhập?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                    using (FormDangNhap formDangNhap = new FormDangNhap())
                    {
                        formDangNhap.ShowDialog();
                    }
                    this.Show();
                }
            }

            catch 
            {
                MessageBox.Show("Ten tai khoan da duoc dang ky");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.ShowDialog();
            this.Close();
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
