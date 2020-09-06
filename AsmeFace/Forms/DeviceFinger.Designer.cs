namespace AsmeFace.Forms
{
    partial class DeviceFinger
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.basic_panel = new System.Windows.Forms.Panel();
            this.basic_combo_open_type = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.basic_txt_close_time = new System.Windows.Forms.TextBox();
            this.basic_combo_auth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.basic_combo_wiegend = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.basic_combo_sensor_type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.basic_txt_open_time = new System.Windows.Forms.TextBox();
            this.basic_btn = new System.Windows.Forms.Button();
            this.alarm_panel = new System.Windows.Forms.Panel();
            this.alarm_combo_mode = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.alarm_txt_delay = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.alarm_combo_type = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.alarm_btn = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.timer_basic = new System.Windows.Forms.Timer(this.components);
            this.timer_alarm = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.basic_panel.SuspendLayout();
            this.alarm_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.basic_panel);
            this.flowLayoutPanel1.Controls.Add(this.alarm_panel);
            this.flowLayoutPanel1.Controls.Add(this.btn_save);
            this.flowLayoutPanel1.Controls.Add(this.btn_close);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(913, 520);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // basic_panel
            // 
            this.basic_panel.Controls.Add(this.basic_combo_open_type);
            this.basic_panel.Controls.Add(this.label7);
            this.basic_panel.Controls.Add(this.label6);
            this.basic_panel.Controls.Add(this.basic_txt_close_time);
            this.basic_panel.Controls.Add(this.basic_combo_auth);
            this.basic_panel.Controls.Add(this.label5);
            this.basic_panel.Controls.Add(this.basic_combo_wiegend);
            this.basic_panel.Controls.Add(this.label4);
            this.basic_panel.Controls.Add(this.basic_combo_sensor_type);
            this.basic_panel.Controls.Add(this.label3);
            this.basic_panel.Controls.Add(this.label2);
            this.basic_panel.Controls.Add(this.basic_txt_open_time);
            this.basic_panel.Controls.Add(this.basic_btn);
            this.basic_panel.Location = new System.Drawing.Point(3, 3);
            this.basic_panel.MaximumSize = new System.Drawing.Size(910, 154);
            this.basic_panel.MinimumSize = new System.Drawing.Size(910, 28);
            this.basic_panel.Name = "basic_panel";
            this.basic_panel.Size = new System.Drawing.Size(910, 28);
            this.basic_panel.TabIndex = 2;
            // 
            // basic_combo_open_type
            // 
            this.basic_combo_open_type.FormattingEnabled = true;
            this.basic_combo_open_type.Items.AddRange(new object[] {
            "Normal Mode",
            "Latch Mode",
            "Keep Opening After Valid Access",
            "Normal Open Automatically"});
            this.basic_combo_open_type.Location = new System.Drawing.Point(691, 115);
            this.basic_combo_open_type.Name = "basic_combo_open_type";
            this.basic_combo_open_type.Size = new System.Drawing.Size(189, 21);
            this.basic_combo_open_type.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(553, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Режим открытия двери:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(587, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Время закрытия:";
            // 
            // basic_txt_close_time
            // 
            this.basic_txt_close_time.Location = new System.Drawing.Point(691, 79);
            this.basic_txt_close_time.Name = "basic_txt_close_time";
            this.basic_txt_close_time.Size = new System.Drawing.Size(189, 20);
            this.basic_txt_close_time.TabIndex = 11;
            // 
            // basic_combo_auth
            // 
            this.basic_combo_auth.FormattingEnabled = true;
            this.basic_combo_auth.Items.AddRange(new object[] {
            "Open by Fingerprint or card"});
            this.basic_combo_auth.Location = new System.Drawing.Point(691, 43);
            this.basic_combo_auth.Name = "basic_combo_auth";
            this.basic_combo_auth.Size = new System.Drawing.Size(189, 21);
            this.basic_combo_auth.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(551, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Режим аутентификации:";
            // 
            // basic_combo_wiegend
            // 
            this.basic_combo_wiegend.FormattingEnabled = true;
            this.basic_combo_wiegend.Items.AddRange(new object[] {
            "Wiegand 26",
            "Wiegand 34"});
            this.basic_combo_wiegend.Location = new System.Drawing.Point(112, 120);
            this.basic_combo_wiegend.Name = "basic_combo_wiegend";
            this.basic_combo_wiegend.Size = new System.Drawing.Size(189, 21);
            this.basic_combo_wiegend.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Wiegand:";
            // 
            // basic_combo_sensor_type
            // 
            this.basic_combo_sensor_type.FormattingEnabled = true;
            this.basic_combo_sensor_type.Items.AddRange(new object[] {
            "Normal-open",
            "Normal-close"});
            this.basic_combo_sensor_type.Location = new System.Drawing.Point(112, 82);
            this.basic_combo_sensor_type.Name = "basic_combo_sensor_type";
            this.basic_combo_sensor_type.Size = new System.Drawing.Size(189, 21);
            this.basic_combo_sensor_type.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Сенсор тип:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Время открытия:";
            // 
            // basic_txt_open_time
            // 
            this.basic_txt_open_time.Location = new System.Drawing.Point(112, 46);
            this.basic_txt_open_time.Name = "basic_txt_open_time";
            this.basic_txt_open_time.Size = new System.Drawing.Size(189, 20);
            this.basic_txt_open_time.TabIndex = 2;
            // 
            // basic_btn
            // 
            this.basic_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.basic_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.basic_btn.ForeColor = System.Drawing.Color.White;
            this.basic_btn.Image = global::AsmeFace.Properties.Resources.arrow_down;
            this.basic_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.basic_btn.Location = new System.Drawing.Point(0, 0);
            this.basic_btn.Name = "basic_btn";
            this.basic_btn.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.basic_btn.Size = new System.Drawing.Size(910, 30);
            this.basic_btn.TabIndex = 0;
            this.basic_btn.Text = "Основная информация";
            this.basic_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.basic_btn.UseVisualStyleBackColor = false;
            this.basic_btn.Click += new System.EventHandler(this.basic_btn_Click);
            // 
            // alarm_panel
            // 
            this.alarm_panel.Controls.Add(this.alarm_combo_mode);
            this.alarm_panel.Controls.Add(this.label11);
            this.alarm_panel.Controls.Add(this.alarm_txt_delay);
            this.alarm_panel.Controls.Add(this.label15);
            this.alarm_panel.Controls.Add(this.alarm_combo_type);
            this.alarm_panel.Controls.Add(this.label16);
            this.alarm_panel.Controls.Add(this.alarm_btn);
            this.alarm_panel.Location = new System.Drawing.Point(3, 37);
            this.alarm_panel.MaximumSize = new System.Drawing.Size(910, 113);
            this.alarm_panel.MinimumSize = new System.Drawing.Size(910, 25);
            this.alarm_panel.Name = "alarm_panel";
            this.alarm_panel.Size = new System.Drawing.Size(910, 25);
            this.alarm_panel.TabIndex = 3;
            // 
            // alarm_combo_mode
            // 
            this.alarm_combo_mode.FormattingEnabled = true;
            this.alarm_combo_mode.Items.AddRange(new object[] {
            "Syncronize with alarm input",
            "Alarm delay"});
            this.alarm_combo_mode.Location = new System.Drawing.Point(112, 72);
            this.alarm_combo_mode.Name = "alarm_combo_mode";
            this.alarm_combo_mode.Size = new System.Drawing.Size(189, 21);
            this.alarm_combo_mode.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(624, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Задержка:";
            // 
            // alarm_txt_delay
            // 
            this.alarm_txt_delay.Location = new System.Drawing.Point(691, 79);
            this.alarm_txt_delay.Name = "alarm_txt_delay";
            this.alarm_txt_delay.Size = new System.Drawing.Size(189, 20);
            this.alarm_txt_delay.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Режим связи:";
            // 
            // alarm_combo_type
            // 
            this.alarm_combo_type.FormattingEnabled = true;
            this.alarm_combo_type.Items.AddRange(new object[] {
            "Normal-open",
            "Normal-close"});
            this.alarm_combo_type.Location = new System.Drawing.Point(112, 36);
            this.alarm_combo_type.Name = "alarm_combo_type";
            this.alarm_combo_type.Size = new System.Drawing.Size(189, 21);
            this.alarm_combo_type.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(31, 39);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Тип тревоги:";
            // 
            // alarm_btn
            // 
            this.alarm_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.alarm_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.alarm_btn.ForeColor = System.Drawing.Color.White;
            this.alarm_btn.Image = global::AsmeFace.Properties.Resources.arrow_down;
            this.alarm_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.alarm_btn.Location = new System.Drawing.Point(0, 0);
            this.alarm_btn.Name = "alarm_btn";
            this.alarm_btn.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.alarm_btn.Size = new System.Drawing.Size(910, 30);
            this.alarm_btn.TabIndex = 0;
            this.alarm_btn.Text = "Настройки сигнализация";
            this.alarm_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.alarm_btn.UseVisualStyleBackColor = false;
            this.alarm_btn.Click += new System.EventHandler(this.alarm_btn_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(6, 68);
            this.btn_save.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(123, 41);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(138, 68);
            this.btn_close.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(123, 41);
            this.btn_close.TabIndex = 7;
            this.btn_close.Text = "Закрыть";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // timer_basic
            // 
            this.timer_basic.Interval = 10;
            this.timer_basic.Tick += new System.EventHandler(this.timer_basic_Tick);
            // 
            // timer_alarm
            // 
            this.timer_alarm.Interval = 10;
            this.timer_alarm.Tick += new System.EventHandler(this.timer_alarm_Tick);
            // 
            // DeviceFinger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(913, 520);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeviceFinger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeviceSettings";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.basic_panel.ResumeLayout(false);
            this.basic_panel.PerformLayout();
            this.alarm_panel.ResumeLayout(false);
            this.alarm_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel basic_panel;
        private System.Windows.Forms.ComboBox basic_combo_open_type;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox basic_txt_close_time;
        private System.Windows.Forms.ComboBox basic_combo_wiegend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox basic_combo_sensor_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox basic_txt_open_time;
        private System.Windows.Forms.Button basic_btn;
        private System.Windows.Forms.Panel alarm_panel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox alarm_txt_delay;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox alarm_combo_type;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button alarm_btn;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Timer timer_basic;
        private System.Windows.Forms.Timer timer_alarm;
        private System.Windows.Forms.ComboBox basic_combo_auth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.ComboBox alarm_combo_mode;
    }
}