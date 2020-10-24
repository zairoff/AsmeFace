namespace AsmeFace.Forms
{
    partial class DeviceFace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceFace));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.basic_panel = new System.Windows.Forms.Panel();
            this.basic_combo_auth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.temp_panel = new System.Windows.Forms.Panel();
            this.temp_combo_action = new System.Windows.Forms.ComboBox();
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
            this.adv_combo_snap = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.adv_btn = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
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
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.basic_panel);
            this.flowLayoutPanel1.Controls.Add(this.alarm_panel);
            this.flowLayoutPanel1.Controls.Add(this.temp_panel);
            this.flowLayoutPanel1.Controls.Add(this.advanced_panel);
            this.flowLayoutPanel1.Controls.Add(this.btn_save);
            this.flowLayoutPanel1.Controls.Add(this.btn_close);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // basic_panel
            // 
            resources.ApplyResources(this.basic_panel, "basic_panel");
            this.basic_panel.Controls.Add(this.basic_combo_auth);
            this.basic_panel.Controls.Add(this.label5);
            this.basic_panel.Controls.Add(this.label2);
            this.basic_panel.Controls.Add(this.basic_txt_open_time);
            this.basic_panel.Controls.Add(this.basic_btn);
            this.basic_panel.Name = "basic_panel";
            // 
            // basic_combo_auth
            // 
            resources.ApplyResources(this.basic_combo_auth, "basic_combo_auth");
            this.basic_combo_auth.FormattingEnabled = true;
            this.basic_combo_auth.Items.AddRange(new object[] {
            resources.GetString("basic_combo_auth.Items"),
            resources.GetString("basic_combo_auth.Items1"),
            resources.GetString("basic_combo_auth.Items2")});
            this.basic_combo_auth.Name = "basic_combo_auth";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // basic_txt_open_time
            // 
            resources.ApplyResources(this.basic_txt_open_time, "basic_txt_open_time");
            this.basic_txt_open_time.Name = "basic_txt_open_time";
            // 
            // basic_btn
            // 
            resources.ApplyResources(this.basic_btn, "basic_btn");
            this.basic_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.basic_btn.ForeColor = System.Drawing.Color.White;
            this.basic_btn.Image = global::AsmeFace.Properties.Resources.arrow_down;
            this.basic_btn.Name = "basic_btn";
            this.basic_btn.UseVisualStyleBackColor = false;
            this.basic_btn.Click += new System.EventHandler(this.basic_btn_Click);
            // 
            // alarm_panel
            // 
            resources.ApplyResources(this.alarm_panel, "alarm_panel");
            this.alarm_panel.Controls.Add(this.alarm_combo_mode);
            this.alarm_panel.Controls.Add(this.label11);
            this.alarm_panel.Controls.Add(this.alarm_txt_delay);
            this.alarm_panel.Controls.Add(this.label15);
            this.alarm_panel.Controls.Add(this.alarm_combo_type);
            this.alarm_panel.Controls.Add(this.label16);
            this.alarm_panel.Controls.Add(this.alarm_btn);
            this.alarm_panel.Name = "alarm_panel";
            // 
            // alarm_combo_mode
            // 
            resources.ApplyResources(this.alarm_combo_mode, "alarm_combo_mode");
            this.alarm_combo_mode.FormattingEnabled = true;
            this.alarm_combo_mode.Items.AddRange(new object[] {
            resources.GetString("alarm_combo_mode.Items")});
            this.alarm_combo_mode.Name = "alarm_combo_mode";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // alarm_txt_delay
            // 
            resources.ApplyResources(this.alarm_txt_delay, "alarm_txt_delay");
            this.alarm_txt_delay.Name = "alarm_txt_delay";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // alarm_combo_type
            // 
            resources.ApplyResources(this.alarm_combo_type, "alarm_combo_type");
            this.alarm_combo_type.FormattingEnabled = true;
            this.alarm_combo_type.Items.AddRange(new object[] {
            resources.GetString("alarm_combo_type.Items"),
            resources.GetString("alarm_combo_type.Items1")});
            this.alarm_combo_type.Name = "alarm_combo_type";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // alarm_btn
            // 
            resources.ApplyResources(this.alarm_btn, "alarm_btn");
            this.alarm_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.alarm_btn.ForeColor = System.Drawing.Color.White;
            this.alarm_btn.Image = global::AsmeFace.Properties.Resources.arrow_down;
            this.alarm_btn.Name = "alarm_btn";
            this.alarm_btn.UseVisualStyleBackColor = false;
            this.alarm_btn.Click += new System.EventHandler(this.alarm_btn_Click);
            // 
            // temp_panel
            // 
            resources.ApplyResources(this.temp_panel, "temp_panel");
            this.temp_panel.Controls.Add(this.temp_combo_action);
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
            this.temp_panel.Name = "temp_panel";
            // 
            // temp_combo_action
            // 
            resources.ApplyResources(this.temp_combo_action, "temp_combo_action");
            this.temp_combo_action.FormattingEnabled = true;
            this.temp_combo_action.Items.AddRange(new object[] {
            resources.GetString("temp_combo_action.Items"),
            resources.GetString("temp_combo_action.Items1")});
            this.temp_combo_action.Name = "temp_combo_action";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // temp_combo_compensation
            // 
            resources.ApplyResources(this.temp_combo_compensation, "temp_combo_compensation");
            this.temp_combo_compensation.FormattingEnabled = true;
            this.temp_combo_compensation.Items.AddRange(new object[] {
            resources.GetString("temp_combo_compensation.Items"),
            resources.GetString("temp_combo_compensation.Items1"),
            resources.GetString("temp_combo_compensation.Items2"),
            resources.GetString("temp_combo_compensation.Items3"),
            resources.GetString("temp_combo_compensation.Items4"),
            resources.GetString("temp_combo_compensation.Items5"),
            resources.GetString("temp_combo_compensation.Items6"),
            resources.GetString("temp_combo_compensation.Items7"),
            resources.GetString("temp_combo_compensation.Items8"),
            resources.GetString("temp_combo_compensation.Items9"),
            resources.GetString("temp_combo_compensation.Items10"),
            resources.GetString("temp_combo_compensation.Items11"),
            resources.GetString("temp_combo_compensation.Items12"),
            resources.GetString("temp_combo_compensation.Items13"),
            resources.GetString("temp_combo_compensation.Items14")});
            this.temp_combo_compensation.Name = "temp_combo_compensation";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // temp_high
            // 
            resources.ApplyResources(this.temp_high, "temp_high");
            this.temp_high.Name = "temp_high";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // temp_combo_trigger
            // 
            resources.ApplyResources(this.temp_combo_trigger, "temp_combo_trigger");
            this.temp_combo_trigger.FormattingEnabled = true;
            this.temp_combo_trigger.Items.AddRange(new object[] {
            resources.GetString("temp_combo_trigger.Items"),
            resources.GetString("temp_combo_trigger.Items1")});
            this.temp_combo_trigger.Name = "temp_combo_trigger";
            // 
            // temp_low
            // 
            resources.ApplyResources(this.temp_low, "temp_low");
            this.temp_low.Name = "temp_low";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // temperature_btn
            // 
            resources.ApplyResources(this.temperature_btn, "temperature_btn");
            this.temperature_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.temperature_btn.ForeColor = System.Drawing.Color.White;
            this.temperature_btn.Image = global::AsmeFace.Properties.Resources.arrow_down;
            this.temperature_btn.Name = "temperature_btn";
            this.temperature_btn.UseVisualStyleBackColor = false;
            this.temperature_btn.Click += new System.EventHandler(this.temperature_btn_Click);
            // 
            // advanced_panel
            // 
            resources.ApplyResources(this.advanced_panel, "advanced_panel");
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
            this.advanced_panel.Controls.Add(this.adv_combo_snap);
            this.advanced_panel.Controls.Add(this.label21);
            this.advanced_panel.Controls.Add(this.adv_btn);
            this.advanced_panel.Name = "advanced_panel";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // adv_txt_sleep_time
            // 
            resources.ApplyResources(this.adv_txt_sleep_time, "adv_txt_sleep_time");
            this.adv_txt_sleep_time.Name = "adv_txt_sleep_time";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // adv_txt_volume
            // 
            resources.ApplyResources(this.adv_txt_volume, "adv_txt_volume");
            this.adv_txt_volume.Name = "adv_txt_volume";
            // 
            // adv_combo_sleep_mode
            // 
            resources.ApplyResources(this.adv_combo_sleep_mode, "adv_combo_sleep_mode");
            this.adv_combo_sleep_mode.FormattingEnabled = true;
            this.adv_combo_sleep_mode.Name = "adv_combo_sleep_mode";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // adv_combo_live
            // 
            resources.ApplyResources(this.adv_combo_live, "adv_combo_live");
            this.adv_combo_live.FormattingEnabled = true;
            this.adv_combo_live.Name = "adv_combo_live";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // adv_combo_light
            // 
            resources.ApplyResources(this.adv_combo_light, "adv_combo_light");
            this.adv_combo_light.FormattingEnabled = true;
            this.adv_combo_light.Name = "adv_combo_light";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // adv_txt_threshold
            // 
            resources.ApplyResources(this.adv_txt_threshold, "adv_txt_threshold");
            this.adv_txt_threshold.Name = "adv_txt_threshold";
            // 
            // adv_combo_snap
            // 
            resources.ApplyResources(this.adv_combo_snap, "adv_combo_snap");
            this.adv_combo_snap.FormattingEnabled = true;
            this.adv_combo_snap.Name = "adv_combo_snap";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // adv_btn
            // 
            resources.ApplyResources(this.adv_btn, "adv_btn");
            this.adv_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.adv_btn.ForeColor = System.Drawing.Color.White;
            this.adv_btn.Image = global::AsmeFace.Properties.Resources.arrow_down;
            this.adv_btn.Name = "adv_btn";
            this.adv_btn.UseVisualStyleBackColor = false;
            this.adv_btn.Click += new System.EventHandler(this.adv_btn_Click);
            // 
            // btn_save
            // 
            resources.ApplyResources(this.btn_save, "btn_save");
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Name = "btn_save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_close
            // 
            resources.ApplyResources(this.btn_close, "btn_close");
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(103)))), ((int)(((byte)(92)))));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Name = "btn_close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // timer_basic
            // 
            this.timer_basic.Interval = 15;
            this.timer_basic.Tick += new System.EventHandler(this.timer_basic_Tick);
            // 
            // timer_alarm
            // 
            this.timer_alarm.Interval = 15;
            this.timer_alarm.Tick += new System.EventHandler(this.timer_alarm_Tick);
            // 
            // timer_temp
            // 
            this.timer_temp.Interval = 15;
            this.timer_temp.Tick += new System.EventHandler(this.timer_temp_Tick);
            // 
            // timer_adv
            // 
            this.timer_adv.Interval = 15;
            this.timer_adv.Tick += new System.EventHandler(this.timer_adv_Tick);
            // 
            // DeviceFace
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeviceFace";
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
        private System.Windows.Forms.ComboBox basic_combo_auth;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.Panel temp_panel;
        private System.Windows.Forms.ComboBox temp_combo_action;
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
        private System.Windows.Forms.ComboBox adv_combo_snap;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button adv_btn;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Timer timer_basic;
        private System.Windows.Forms.Timer timer_alarm;
        private System.Windows.Forms.Timer timer_temp;
        private System.Windows.Forms.Timer timer_adv;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.ComboBox alarm_combo_mode;
    }
}