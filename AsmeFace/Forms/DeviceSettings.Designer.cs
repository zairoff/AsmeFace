namespace AsmeFace.Forms
{
    partial class DeviceSettings
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
            this.basic_combo_display_name = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
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
            this.basic_combo_btn_type = new System.Windows.Forms.ComboBox();
            this.basic_txt_open_time = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.basic_btn = new System.Windows.Forms.Button();
            this.alarm_panel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.alarm_txt_delay = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.alarm_combo_type = new System.Windows.Forms.ComboBox();
            this.alarm_txt_mode = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.alarm_btn = new System.Windows.Forms.Button();
            this.temp_panel = new System.Windows.Forms.Panel();
            this.temp_action = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.temp_combo_compensation = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.temp_high = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.temp_combo_trigger = new System.Windows.Forms.ComboBox();
            this.temp_low = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.temperature_btn = new System.Windows.Forms.Button();
            this.advanced_panel = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.adv_txt_sleep_time = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.adv_txt_volume = new System.Windows.Forms.TextBox();
            this.adv_combo_sleep_mode = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.adv_combo_live = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.adv_combo_light = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.adv_txt_threshold = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.adv_combo_snap = new System.Windows.Forms.ComboBox();
            this.adv_txt_bright = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.adv_btn = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.timer_basic = new System.Windows.Forms.Timer(this.components);
            this.timer_alarm = new System.Windows.Forms.Timer(this.components);
            this.timer_temp = new System.Windows.Forms.Timer(this.components);
            this.timer_adv = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.basic_panel.SuspendLayout();
            this.alarm_panel.SuspendLayout();
            this.temp_panel.SuspendLayout();
            this.advanced_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.basic_panel);
            this.flowLayoutPanel1.Controls.Add(this.alarm_panel);
            this.flowLayoutPanel1.Controls.Add(this.temp_panel);
            this.flowLayoutPanel1.Controls.Add(this.advanced_panel);
            this.flowLayoutPanel1.Controls.Add(this.btn_save);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(913, 700);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // basic_panel
            // 
            this.basic_panel.Controls.Add(this.basic_combo_display_name);
            this.basic_panel.Controls.Add(this.label8);
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
            this.basic_panel.Controls.Add(this.basic_combo_btn_type);
            this.basic_panel.Controls.Add(this.basic_txt_open_time);
            this.basic_panel.Controls.Add(this.label1);
            this.basic_panel.Controls.Add(this.basic_btn);
            this.basic_panel.Location = new System.Drawing.Point(3, 3);
            this.basic_panel.MaximumSize = new System.Drawing.Size(910, 186);
            this.basic_panel.MinimumSize = new System.Drawing.Size(910, 28);
            this.basic_panel.Name = "basic_panel";
            this.basic_panel.Size = new System.Drawing.Size(910, 186);
            this.basic_panel.TabIndex = 2;
            // 
            // basic_combo_display_name
            // 
            this.basic_combo_display_name.FormattingEnabled = true;
            this.basic_combo_display_name.Location = new System.Drawing.Point(691, 153);
            this.basic_combo_display_name.Name = "basic_combo_display_name";
            this.basic_combo_display_name.Size = new System.Drawing.Size(189, 21);
            this.basic_combo_display_name.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(530, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Отображать имя персонала:";
            // 
            // basic_combo_open_type
            // 
            this.basic_combo_open_type.FormattingEnabled = true;
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
            this.basic_combo_wiegend.Location = new System.Drawing.Point(115, 153);
            this.basic_combo_wiegend.Name = "basic_combo_wiegend";
            this.basic_combo_wiegend.Size = new System.Drawing.Size(189, 21);
            this.basic_combo_wiegend.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Wiegend:";
            // 
            // basic_combo_sensor_type
            // 
            this.basic_combo_sensor_type.FormattingEnabled = true;
            this.basic_combo_sensor_type.Location = new System.Drawing.Point(115, 115);
            this.basic_combo_sensor_type.Name = "basic_combo_sensor_type";
            this.basic_combo_sensor_type.Size = new System.Drawing.Size(189, 21);
            this.basic_combo_sensor_type.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Сенсор тип:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Время открытия:";
            // 
            // basic_combo_btn_type
            // 
            this.basic_combo_btn_type.FormattingEnabled = true;
            this.basic_combo_btn_type.Location = new System.Drawing.Point(115, 43);
            this.basic_combo_btn_type.Name = "basic_combo_btn_type";
            this.basic_combo_btn_type.Size = new System.Drawing.Size(189, 21);
            this.basic_combo_btn_type.TabIndex = 3;
            // 
            // basic_txt_open_time
            // 
            this.basic_txt_open_time.Location = new System.Drawing.Point(115, 79);
            this.basic_txt_open_time.Name = "basic_txt_open_time";
            this.basic_txt_open_time.Size = new System.Drawing.Size(189, 20);
            this.basic_txt_open_time.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Кнопка выхода:";
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
            this.alarm_panel.Controls.Add(this.label11);
            this.alarm_panel.Controls.Add(this.alarm_txt_delay);
            this.alarm_panel.Controls.Add(this.label15);
            this.alarm_panel.Controls.Add(this.alarm_combo_type);
            this.alarm_panel.Controls.Add(this.alarm_txt_mode);
            this.alarm_panel.Controls.Add(this.label16);
            this.alarm_panel.Controls.Add(this.alarm_btn);
            this.alarm_panel.Location = new System.Drawing.Point(3, 195);
            this.alarm_panel.MaximumSize = new System.Drawing.Size(910, 113);
            this.alarm_panel.MinimumSize = new System.Drawing.Size(910, 25);
            this.alarm_panel.Name = "alarm_panel";
            this.alarm_panel.Size = new System.Drawing.Size(910, 113);
            this.alarm_panel.TabIndex = 3;
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
            this.label15.Location = new System.Drawing.Point(63, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Режим связи:";
            // 
            // alarm_combo_type
            // 
            this.alarm_combo_type.FormattingEnabled = true;
            this.alarm_combo_type.Location = new System.Drawing.Point(150, 41);
            this.alarm_combo_type.Name = "alarm_combo_type";
            this.alarm_combo_type.Size = new System.Drawing.Size(189, 21);
            this.alarm_combo_type.TabIndex = 3;
            // 
            // alarm_txt_mode
            // 
            this.alarm_txt_mode.Location = new System.Drawing.Point(150, 77);
            this.alarm_txt_mode.Name = "alarm_txt_mode";
            this.alarm_txt_mode.Size = new System.Drawing.Size(189, 20);
            this.alarm_txt_mode.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(69, 44);
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
            // temp_panel
            // 
            this.temp_panel.Controls.Add(this.temp_action);
            this.temp_panel.Controls.Add(this.label14);
            this.temp_panel.Controls.Add(this.temp_combo_compensation);
            this.temp_panel.Controls.Add(this.label13);
            this.temp_panel.Controls.Add(this.label9);
            this.temp_panel.Controls.Add(this.temp_high);
            this.temp_panel.Controls.Add(this.label10);
            this.temp_panel.Controls.Add(this.temp_combo_trigger);
            this.temp_panel.Controls.Add(this.temp_low);
            this.temp_panel.Controls.Add(this.label12);
            this.temp_panel.Controls.Add(this.temperature_btn);
            this.temp_panel.Location = new System.Drawing.Point(3, 314);
            this.temp_panel.MaximumSize = new System.Drawing.Size(910, 152);
            this.temp_panel.MinimumSize = new System.Drawing.Size(910, 28);
            this.temp_panel.Name = "temp_panel";
            this.temp_panel.Size = new System.Drawing.Size(910, 152);
            this.temp_panel.TabIndex = 4;
            // 
            // temp_action
            // 
            this.temp_action.FormattingEnabled = true;
            this.temp_action.Location = new System.Drawing.Point(691, 82);
            this.temp_action.Name = "temp_action";
            this.temp_action.Size = new System.Drawing.Size(189, 21);
            this.temp_action.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(625, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Действия:";
            // 
            // temp_combo_compensation
            // 
            this.temp_combo_compensation.FormattingEnabled = true;
            this.temp_combo_compensation.Location = new System.Drawing.Point(150, 118);
            this.temp_combo_compensation.Name = "temp_combo_compensation";
            this.temp_combo_compensation.Size = new System.Drawing.Size(189, 21);
            this.temp_combo_compensation.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(62, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Компенсация:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(562, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Высокая температура:";
            // 
            // temp_high
            // 
            this.temp_high.Location = new System.Drawing.Point(691, 47);
            this.temp_high.Name = "temp_high";
            this.temp_high.Size = new System.Drawing.Size(189, 20);
            this.temp_high.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Низкая температура:";
            // 
            // temp_combo_trigger
            // 
            this.temp_combo_trigger.FormattingEnabled = true;
            this.temp_combo_trigger.Location = new System.Drawing.Point(150, 82);
            this.temp_combo_trigger.Name = "temp_combo_trigger";
            this.temp_combo_trigger.Size = new System.Drawing.Size(189, 21);
            this.temp_combo_trigger.TabIndex = 3;
            // 
            // temp_low
            // 
            this.temp_low.Location = new System.Drawing.Point(150, 47);
            this.temp_low.Name = "temp_low";
            this.temp_low.Size = new System.Drawing.Size(189, 20);
            this.temp_low.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(84, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Действия:";
            // 
            // temperature_btn
            // 
            this.temperature_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.temperature_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.temperature_btn.ForeColor = System.Drawing.Color.White;
            this.temperature_btn.Image = global::AsmeFace.Properties.Resources.arrow_down;
            this.temperature_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.temperature_btn.Location = new System.Drawing.Point(0, 0);
            this.temperature_btn.Name = "temperature_btn";
            this.temperature_btn.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.temperature_btn.Size = new System.Drawing.Size(910, 30);
            this.temperature_btn.TabIndex = 0;
            this.temperature_btn.Text = "Настройки температуры";
            this.temperature_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.temperature_btn.UseVisualStyleBackColor = false;
            this.temperature_btn.Click += new System.EventHandler(this.temperature_btn_Click);
            // 
            // advanced_panel
            // 
            this.advanced_panel.Controls.Add(this.label24);
            this.advanced_panel.Controls.Add(this.adv_txt_sleep_time);
            this.advanced_panel.Controls.Add(this.label22);
            this.advanced_panel.Controls.Add(this.adv_txt_volume);
            this.advanced_panel.Controls.Add(this.adv_combo_sleep_mode);
            this.advanced_panel.Controls.Add(this.label23);
            this.advanced_panel.Controls.Add(this.adv_combo_live);
            this.advanced_panel.Controls.Add(this.label17);
            this.advanced_panel.Controls.Add(this.adv_combo_light);
            this.advanced_panel.Controls.Add(this.label18);
            this.advanced_panel.Controls.Add(this.label19);
            this.advanced_panel.Controls.Add(this.adv_txt_threshold);
            this.advanced_panel.Controls.Add(this.label20);
            this.advanced_panel.Controls.Add(this.adv_combo_snap);
            this.advanced_panel.Controls.Add(this.adv_txt_bright);
            this.advanced_panel.Controls.Add(this.label21);
            this.advanced_panel.Controls.Add(this.adv_btn);
            this.advanced_panel.Location = new System.Drawing.Point(3, 472);
            this.advanced_panel.MaximumSize = new System.Drawing.Size(910, 192);
            this.advanced_panel.MinimumSize = new System.Drawing.Size(910, 28);
            this.advanced_panel.Name = "advanced_panel";
            this.advanced_panel.Size = new System.Drawing.Size(910, 192);
            this.advanced_panel.TabIndex = 5;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(594, 157);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 13);
            this.label24.TabIndex = 22;
            this.label24.Text = "Время сна:";
            // 
            // adv_txt_sleep_time
            // 
            this.adv_txt_sleep_time.Location = new System.Drawing.Point(669, 154);
            this.adv_txt_sleep_time.Name = "adv_txt_sleep_time";
            this.adv_txt_sleep_time.Size = new System.Drawing.Size(189, 20);
            this.adv_txt_sleep_time.TabIndex = 21;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(46, 157);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(125, 13);
            this.label22.TabIndex = 18;
            this.label22.Text = "Громкость устройства:";
            // 
            // adv_txt_volume
            // 
            this.adv_txt_volume.Location = new System.Drawing.Point(180, 154);
            this.adv_txt_volume.Name = "adv_txt_volume";
            this.adv_txt_volume.Size = new System.Drawing.Size(189, 20);
            this.adv_txt_volume.TabIndex = 17;
            // 
            // adv_combo_sleep_mode
            // 
            this.adv_combo_sleep_mode.FormattingEnabled = true;
            this.adv_combo_sleep_mode.Location = new System.Drawing.Point(669, 118);
            this.adv_combo_sleep_mode.Name = "adv_combo_sleep_mode";
            this.adv_combo_sleep_mode.Size = new System.Drawing.Size(189, 21);
            this.adv_combo_sleep_mode.TabIndex = 20;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(571, 121);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(87, 13);
            this.label23.TabIndex = 19;
            this.label23.Text = "Спящий режим:";
            // 
            // adv_combo_live
            // 
            this.adv_combo_live.FormattingEnabled = true;
            this.adv_combo_live.Location = new System.Drawing.Point(669, 48);
            this.adv_combo_live.Name = "adv_combo_live";
            this.adv_combo_live.Size = new System.Drawing.Size(189, 21);
            this.adv_combo_live.TabIndex = 16;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(543, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(115, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Живое обнаружение:";
            // 
            // adv_combo_light
            // 
            this.adv_combo_light.FormattingEnabled = true;
            this.adv_combo_light.Location = new System.Drawing.Point(180, 83);
            this.adv_combo_light.Name = "adv_combo_light";
            this.adv_combo_light.Size = new System.Drawing.Size(189, 21);
            this.adv_combo_light.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(76, 86);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Световой режим:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(572, 88);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 13);
            this.label19.TabIndex = 12;
            this.label19.Text = "Threshold value:";
            // 
            // adv_txt_threshold
            // 
            this.adv_txt_threshold.Location = new System.Drawing.Point(669, 85);
            this.adv_txt_threshold.Name = "adv_txt_threshold";
            this.adv_txt_threshold.Size = new System.Drawing.Size(189, 20);
            this.adv_txt_threshold.TabIndex = 11;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(76, 121);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(95, 13);
            this.label20.TabIndex = 4;
            this.label20.Text = "Световой режим:";
            // 
            // adv_combo_snap
            // 
            this.adv_combo_snap.FormattingEnabled = true;
            this.adv_combo_snap.Location = new System.Drawing.Point(180, 48);
            this.adv_combo_snap.Name = "adv_combo_snap";
            this.adv_combo_snap.Size = new System.Drawing.Size(189, 21);
            this.adv_combo_snap.TabIndex = 3;
            // 
            // adv_txt_bright
            // 
            this.adv_txt_bright.Location = new System.Drawing.Point(180, 118);
            this.adv_txt_bright.Name = "adv_txt_bright";
            this.adv_txt_bright.Size = new System.Drawing.Size(189, 20);
            this.adv_txt_bright.TabIndex = 2;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(95, 51);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "Снимок лица:";
            // 
            // adv_btn
            // 
            this.adv_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.adv_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.adv_btn.ForeColor = System.Drawing.Color.White;
            this.adv_btn.Image = global::AsmeFace.Properties.Resources.arrow_down;
            this.adv_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.adv_btn.Location = new System.Drawing.Point(0, 0);
            this.adv_btn.Name = "adv_btn";
            this.adv_btn.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.adv_btn.Size = new System.Drawing.Size(910, 30);
            this.adv_btn.TabIndex = 0;
            this.adv_btn.Text = "Расширенные настройки";
            this.adv_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.adv_btn.UseVisualStyleBackColor = false;
            this.adv_btn.Click += new System.EventHandler(this.adv_btn_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(6, 674);
            this.btn_save.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(123, 41);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = false;
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
            // timer_temp
            // 
            this.timer_temp.Interval = 10;
            this.timer_temp.Tick += new System.EventHandler(this.timer_temp_Tick);
            // 
            // timer_adv
            // 
            this.timer_adv.Interval = 10;
            this.timer_adv.Tick += new System.EventHandler(this.timer_adv_Tick);
            // 
            // DeviceSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(913, 700);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeviceSettings";
            this.Text = "DeviceSettings";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.basic_panel.ResumeLayout(false);
            this.basic_panel.PerformLayout();
            this.alarm_panel.ResumeLayout(false);
            this.alarm_panel.PerformLayout();
            this.temp_panel.ResumeLayout(false);
            this.temp_panel.PerformLayout();
            this.advanced_panel.ResumeLayout(false);
            this.advanced_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel basic_panel;
        private System.Windows.Forms.ComboBox basic_combo_display_name;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox basic_combo_open_type;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox basic_txt_close_time;
        private System.Windows.Forms.ComboBox basic_combo_auth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox basic_combo_wiegend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox basic_combo_sensor_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox basic_combo_btn_type;
        private System.Windows.Forms.TextBox basic_txt_open_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button basic_btn;
        private System.Windows.Forms.Panel alarm_panel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox alarm_txt_delay;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox alarm_combo_type;
        private System.Windows.Forms.TextBox alarm_txt_mode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button alarm_btn;
        private System.Windows.Forms.Panel temp_panel;
        private System.Windows.Forms.ComboBox temp_action;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox temp_combo_compensation;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox temp_high;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox temp_combo_trigger;
        private System.Windows.Forms.TextBox temp_low;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button temperature_btn;
        private System.Windows.Forms.Panel advanced_panel;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox adv_txt_sleep_time;
        private System.Windows.Forms.ComboBox adv_combo_sleep_mode;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox adv_txt_volume;
        private System.Windows.Forms.ComboBox adv_combo_live;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox adv_combo_light;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox adv_txt_threshold;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox adv_combo_snap;
        private System.Windows.Forms.TextBox adv_txt_bright;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button adv_btn;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Timer timer_basic;
        private System.Windows.Forms.Timer timer_alarm;
        private System.Windows.Forms.Timer timer_temp;
        private System.Windows.Forms.Timer timer_adv;
    }
}