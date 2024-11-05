﻿using System;
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
    public partial class FormBatDau : Form
    {
        public FormBatDau()
        {
            InitializeComponent();
            PictureBox pictureBoxBackground = new PictureBox();
            pictureBoxBackground.Dock = DockStyle.Fill;
            pictureBoxBackground.Image = Image.FromFile(@"D:\Download\FormBatDau.gif");
            pictureBoxBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pictureBoxBackground);
            pictureBoxBackground.SendToBack();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDangKy formDangKy = new FormDangKy();
            formDangKy.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            this.Hide();
        }
    }
}
