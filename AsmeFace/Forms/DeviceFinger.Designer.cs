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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceFinger));
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
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.basic_panel);
            this.flowLayoutPanel1.Controls.Add(this.alarm_panel);
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
            resources.GetString("basic_combo_auth.Items2"),
            resources.GetString("basic_combo_auth.Items3"),
            resources.GetString("basic_combo_auth.Items4"),
            resources.GetString("basic_combo_auth.Items5")});
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
            resources.GetString("alarm_combo_mode.Items"),
            resources.GetString("alarm_combo_mode.Items1")});
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
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeviceFinger";
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