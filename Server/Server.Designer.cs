namespace Server
{
    partial class Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
            this.button_start_server = new System.Windows.Forms.Button();
            this.button_stop_server = new System.Windows.Forms.Button();
            this.button_get_server_IP = new System.Windows.Forms.Button();
            this.textBox_server_local_IP = new System.Windows.Forms.TextBox();
            this.textBox_room_count = new System.Windows.Forms.TextBox();
            this.textBox_user_count = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listView_log = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // button_start_server
            // 
            this.button_start_server.BackColor = System.Drawing.Color.Transparent;
            this.button_start_server.Location = new System.Drawing.Point(25, 26);
            this.button_start_server.Name = "button_start_server";
            this.button_start_server.Size = new System.Drawing.Size(187, 75);
            this.button_start_server.TabIndex = 0;
            this.button_start_server.Text = "Bắt đầu";
            this.button_start_server.UseVisualStyleBackColor = false;
            this.button_start_server.Click += new System.EventHandler(this.button_start_server_Click);
            // 
            // button_stop_server
            // 
            this.button_stop_server.Location = new System.Drawing.Point(25, 107);
            this.button_stop_server.Name = "button_stop_server";
            this.button_stop_server.Size = new System.Drawing.Size(187, 75);
            this.button_stop_server.TabIndex = 1;
            this.button_stop_server.Text = "Kết thúc";
            this.button_stop_server.UseVisualStyleBackColor = true;
            this.button_stop_server.Click += new System.EventHandler(this.button_stop_server_Click);
            // 
            // button_get_server_IP
            // 
            this.button_get_server_IP.Location = new System.Drawing.Point(25, 323);
            this.button_get_server_IP.Name = "button_get_server_IP";
            this.button_get_server_IP.Size = new System.Drawing.Size(187, 75);
            this.button_get_server_IP.TabIndex = 2;
            this.button_get_server_IP.Text = "Lấy IP Server";
            this.button_get_server_IP.UseVisualStyleBackColor = true;
            this.button_get_server_IP.Click += new System.EventHandler(this.button_get_server_IP_Click);
            // 
            // textBox_server_local_IP
            // 
            this.textBox_server_local_IP.Location = new System.Drawing.Point(25, 404);
            this.textBox_server_local_IP.Name = "textBox_server_local_IP";
            this.textBox_server_local_IP.Size = new System.Drawing.Size(187, 20);
            this.textBox_server_local_IP.TabIndex = 3;
            // 
            // textBox_room_count
            // 
            this.textBox_room_count.Location = new System.Drawing.Point(294, 455);
            this.textBox_room_count.Name = "textBox_room_count";
            this.textBox_room_count.Size = new System.Drawing.Size(100, 20);
            this.textBox_room_count.TabIndex = 4;
            // 
            // textBox_user_count
            // 
            this.textBox_user_count.Location = new System.Drawing.Point(709, 455);
            this.textBox_user_count.Name = "textBox_user_count";
            this.textBox_user_count.Size = new System.Drawing.Size(100, 20);
            this.textBox_user_count.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 458);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Số phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(611, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Số người tham gia";
            // 
            // listView_log
            // 
            this.listView_log.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_log.HideSelection = false;
            this.listView_log.Location = new System.Drawing.Point(238, 26);
            this.listView_log.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView_log.Name = "listView_log";
            this.listView_log.Size = new System.Drawing.Size(571, 398);
            this.listView_log.TabIndex = 8;
            this.listView_log.UseCompatibleStateImageBehavior = false;
            this.listView_log.View = System.Windows.Forms.View.List;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(838, 495);
            this.Controls.Add(this.listView_log);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_user_count);
            this.Controls.Add(this.textBox_room_count);
            this.Controls.Add(this.textBox_server_local_IP);
            this.Controls.Add(this.button_get_server_IP);
            this.Controls.Add(this.button_stop_server);
            this.Controls.Add(this.button_start_server);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_start_server;
        private System.Windows.Forms.Button button_stop_server;
        private System.Windows.Forms.Button button_get_server_IP;
        private System.Windows.Forms.TextBox textBox_server_local_IP;
        private System.Windows.Forms.TextBox textBox_room_count;
        private System.Windows.Forms.TextBox textBox_user_count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView_log;
    }
}

