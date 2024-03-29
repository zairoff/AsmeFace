﻿using AsmeFace.Properties;
using System;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class DeviceFinger : Form
    {
        public DeviceFinger(string ip)
        {
            InitializeComponent();
            basic_combo_auth.SelectedIndex = 0;
            alarm_combo_mode.SelectedIndex = 0;
            alarm_combo_type.SelectedIndex = 0;
            this.ip = ip;
            _asmeDevice = new AsmeDevice();
        }

        private bool _isCollapsedBasic;
        private bool _isCollapsedAlarm;
        private readonly string ip;
        private readonly AsmeDevice _asmeDevice;

        private void timer_basic_Tick(object sender, EventArgs e)
        {
            if (_isCollapsedBasic)
            {
                basic_btn.Image = Resources.arrow_down;
                basic_panel.Height -= 10;
                if (basic_panel.Height == basic_panel.MinimumSize.Height)
                {
                    timer_basic.Stop();
                    _isCollapsedBasic = false;
                }
            }
            else
            {
                basic_btn.Image = Resources.arrow_up;
                basic_panel.Height += 10;
                if (basic_panel.Height == basic_panel.MaximumSize.Height)
                {
                    timer_basic.Stop();
                    _isCollapsedBasic = true;

                }
            }
        }

        private void timer_alarm_Tick(object sender, EventArgs e)
        {
            if (_isCollapsedAlarm)
            {
                alarm_btn.Image = Resources.arrow_down;
                alarm_panel.Height -= 10;
                if (alarm_panel.Height == alarm_panel.MinimumSize.Height)
                {
                    timer_alarm.Stop();
                    _isCollapsedAlarm = false;
                }
            }
            else
            {
                alarm_btn.Image = Resources.arrow_up;
                alarm_panel.Height += 10;
                if (alarm_panel.Height == alarm_panel.MaximumSize.Height)
                {
                    timer_alarm.Stop();
                    _isCollapsedAlarm = true;

                }
            }
        }        

        private void basic_btn_Click(object sender, EventArgs e)
        {
            timer_basic.Start();
        }

        private void alarm_btn_Click(object sender, EventArgs e)
        {
            timer_alarm.Start();
        }        

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (_asmeDevice.OpenDevice(ip) < 0)
            {
                CustomMessageBox.Error(Resources.DEVICE_FAILED_OPEN);
                return;
            }
            
            if (_asmeDevice.CommunicationTest() < 0)
            {
                CustomMessageBox.Error(Resources.DEVICE_FAILED_INFO);
                return;
            }

            var auth_mode = basic_combo_auth.SelectedIndex + 5;
            if (_asmeDevice.SetReader(Convert.ToInt32(basic_txt_open_time.Text), auth_mode) < 0)
            {
                CustomMessageBox.Error(Resources.DEVICE_FAILED_INFO);
                return;
            }

            if (_asmeDevice.SetGroup(0, _asmeDevice.GetDefaultWeek()) < 0)
            {
                CustomMessageBox.Error(Resources.DEVICE_FAILED_INFO);
                return;
            }

            _asmeDevice.CloseDevice();

            CustomMessageBox.Info(Resources.OPERATION_SUCCESS);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
