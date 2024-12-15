namespace WindowsFormsSign
{
    partial class Phong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Phong));
            this.button_mode_offline = new System.Windows.Forms.Button();
            this.button_mode_online = new System.Windows.Forms.Button();
            this.textBox_server_IP = new System.Windows.Forms.TextBox();
            this.button_create_room = new System.Windows.Forms.Button();
            this.button_join_room = new System.Windows.Forms.Button();
            this.button_go_create_room = new System.Windows.Forms.Button();
            this.textBox_code_room = new System.Windows.Forms.TextBox();
            this.button_go_join_room = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel_back = new System.Windows.Forms.LinkLabel();
            this.button_go_create_canvas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_mode_offline
            // 
            this.button_mode_offline.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_mode_offline.Location = new System.Drawing.Point(24, 133);
            this.button_mode_offline.Name = "button_mode_offline";
            this.button_mode_offline.Size = new System.Drawing.Size(124, 38);
            this.button_mode_offline.TabIndex = 0;
            this.button_mode_offline.Text = "Offline";
            this.button_mode_offline.UseVisualStyleBackColor = true;
            this.button_mode_offline.Click += new System.EventHandler(this.button_mode_offline_Click);
            // 
            // button_mode_online
            // 
            this.button_mode_online.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_mode_online.Location = new System.Drawing.Point(24, 181);
            this.button_mode_online.Name = "button_mode_online";
            this.button_mode_online.Size = new System.Drawing.Size(124, 38);
            this.button_mode_online.TabIndex = 1;
            this.button_mode_online.Text = "Online";
            this.button_mode_online.UseVisualStyleBackColor = true;
            this.button_mode_online.Click += new System.EventHandler(this.button_mode_online_Click);
            // 
            // textBox_server_IP
            // 
            this.textBox_server_IP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_server_IP.Location = new System.Drawing.Point(285, 72);
            this.textBox_server_IP.Name = "textBox_server_IP";
            this.textBox_server_IP.Size = new System.Drawing.Size(170, 26);
            this.textBox_server_IP.TabIndex = 2;
            // 
            // button_create_room
            // 
            this.button_create_room.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_create_room.Location = new System.Drawing.Point(172, 20);
            this.button_create_room.Name = "button_create_room";
            this.button_create_room.Size = new System.Drawing.Size(125, 33);
            this.button_create_room.TabIndex = 3;
            this.button_create_room.Text = "Tạo phòng";
            this.button_create_room.UseVisualStyleBackColor = true;
            this.button_create_room.Click += new System.EventHandler(this.button_create_room_Click);
            // 
            // button_join_room
            // 
            this.button_join_room.AutoSize = true;
            this.button_join_room.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_join_room.Location = new System.Drawing.Point(330, 20);
            this.button_join_room.Name = "button_join_room";
            this.button_join_room.Size = new System.Drawing.Size(125, 33);
            this.button_join_room.TabIndex = 4;
            this.button_join_room.Text = "Tham gia phòng";
            this.button_join_room.UseVisualStyleBackColor = true;
            this.button_join_room.Click += new System.EventHandler(this.button_join_room_Click);
            // 
            // button_go_create_room
            // 
            this.button_go_create_room.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_go_create_room.Location = new System.Drawing.Point(254, 179);
            this.button_go_create_room.Name = "button_go_create_room";
            this.button_go_create_room.Size = new System.Drawing.Size(122, 40);
            this.button_go_create_room.TabIndex = 6;
            this.button_go_create_room.Text = "Tạo";
            this.button_go_create_room.UseVisualStyleBackColor = true;
            this.button_go_create_room.Click += new System.EventHandler(this.button_go_create_room_Click);
            // 
            // textBox_code_room
            // 
            this.textBox_code_room.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_code_room.Location = new System.Drawing.Point(285, 136);
            this.textBox_code_room.Name = "textBox_code_room";
            this.textBox_code_room.Size = new System.Drawing.Size(170, 26);
            this.textBox_code_room.TabIndex = 7;
            // 
            // button_go_join_room
            // 
            this.button_go_join_room.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_go_join_room.Location = new System.Drawing.Point(254, 179);
            this.button_go_join_room.Name = "button_go_join_room";
            this.button_go_join_room.Size = new System.Drawing.Size(122, 40);
            this.button_go_join_room.TabIndex = 8;
            this.button_go_join_room.Text = "Tham gia";
            this.button_go_join_room.UseVisualStyleBackColor = true;
            this.button_go_join_room.Click += new System.EventHandler(this.button_go_join_room_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(168, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nhập ID phòng";
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.Location = new System.Drawing.Point(285, 104);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(170, 26);
            this.textBox_name.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nhập IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(168, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nhập tên";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(34, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(481, 251);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-5, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(171, 103);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.linkLabel_back);
            this.panel1.Controls.Add(this.button_go_create_canvas);
            this.panel1.Controls.Add(this.button_mode_offline);
            this.panel1.Controls.Add(this.button_mode_online);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button_go_join_room);
            this.panel1.Controls.Add(this.button_go_create_room);
            this.panel1.Controls.Add(this.textBox_name);
            this.panel1.Controls.Add(this.button_join_room);
            this.panel1.Controls.Add(this.textBox_server_IP);
            this.panel1.Controls.Add(this.button_create_room);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_code_room);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(34, 293);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(481, 241);
            this.panel1.TabIndex = 7;
            // 
            // linkLabel_back
            // 
            this.linkLabel_back.AutoSize = true;
            this.linkLabel_back.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_back.Location = new System.Drawing.Point(402, 204);
            this.linkLabel_back.Name = "linkLabel_back";
            this.linkLabel_back.Size = new System.Drawing.Size(53, 15);
            this.linkLabel_back.TabIndex = 12;
            this.linkLabel_back.TabStop = true;
            this.linkLabel_back.Text = "Quay lại";
            this.linkLabel_back.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_back_LinkClicked);
            // 
            // button_go_create_canvas
            // 
            this.button_go_create_canvas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_go_create_canvas.Location = new System.Drawing.Point(238, 84);
            this.button_go_create_canvas.Name = "button_go_create_canvas";
            this.button_go_create_canvas.Size = new System.Drawing.Size(159, 52);
            this.button_go_create_canvas.TabIndex = 11;
            this.button_go_create_canvas.Text = "Bắt đầu";
            this.button_go_create_canvas.UseVisualStyleBackColor = true;
            this.button_go_create_canvas.Click += new System.EventHandler(this.button_go_create_canvas_Click);
            // 
            // Phong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 569);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Phong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phong";
            this.Load += new System.EventHandler(this.Phong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_mode_offline;
        private System.Windows.Forms.Button button_mode_online;
        private System.Windows.Forms.TextBox textBox_server_IP;
        private System.Windows.Forms.Button button_create_room;
        private System.Windows.Forms.Button button_join_room;
        private System.Windows.Forms.Button button_go_create_room;
        private System.Windows.Forms.TextBox textBox_code_room;
        private System.Windows.Forms.Button button_go_join_room;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_go_create_canvas;
        private System.Windows.Forms.LinkLabel linkLabel_back;
    }
}