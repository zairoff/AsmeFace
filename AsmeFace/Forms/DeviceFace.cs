using AsmeFace.Properties;
using System;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class DeviceFace : Form
    {
        public DeviceFace(string ip)
        {
            InitializeComponent();
            basic_combo_auth.SelectedIndex = 0;
            alarm_combo_mode.SelectedIndex = 0;
            alarm_combo_type.SelectedIndex = 0;
            temp_combo_compensation.SelectedIndex = 0;
            temp_combo_trigger.SelectedIndex = 0;
            temp_combo_action.SelectedIndex = 0;
            _asmeDevice = new AsmeDevice();
            _ip = ip;
        }

        private static bool _isCollapsedBasic;
        private static bool _isCollapsedAlarm;
        private static bool _isCollapsedTemp;
        private static bool _isCollapsedAdvanced;
        private readonly AsmeDevice _asmeDevice;
        private readonly string _ip;

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

        private void timer_temp_Tick(object sender, EventArgs e)
        {
            if (_isCollapsedTemp)
            {
                temperature_btn.Image = Resources.arrow_down;
                temp_panel.Height -= 10;
                if (temp_panel.Height == temp_panel.MinimumSize.Height)
                {
                    timer_temp.Stop();
                    _isCollapsedTemp = false;
                }
            }
            else
            {
                temperature_btn.Image = Resources.arrow_up;
                temp_panel.Height += 10;
                if (temp_panel.Height == temp_panel.MaximumSize.Height)
                {
                    timer_temp.Stop();
                    _isCollapsedTemp = true;
                }
            }
        }

        private void timer_adv_Tick(object sender, EventArgs e)
        {
            if (_isCollapsedAdvanced)
            {
                adv_btn.Image = Resources.arrow_down;
                advanced_panel.Height -= 10;
                if (advanced_panel.Height == advanced_panel.MinimumSize.Height)
                {
                    timer_adv.Stop();
                    _isCollapsedAdvanced = false;
                }
            }
            else
            {
                adv_btn.Image = Resources.arrow_up;
                advanced_panel.Height += 10;
                if (advanced_panel.Height == advanced_panel.MaximumSize.Height)
                {
                    timer_adv.Stop();
                    _isCollapsedAdvanced = true;
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

        private void temperature_btn_Click(object sender, EventArgs e)
        {
            timer_temp.Start();
        }

        private void adv_btn_Click(object sender, EventArgs e)
        {
            timer_adv.Start();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(_asmeDevice.OpenDevice(_ip) < 0)
            {
                CustomMessageBox.Error(Properties.Resources.DEVICE_FAILED_OPEN);
                return;
            }

            var auth_mode = basic_combo_auth.SelectedIndex + 11;
            if (_asmeDevice.CommunicationTest() < 0)
            {
                CustomMessageBox.Error(Resources.DEVICE_FAILED_INFO);
                return;
            }

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

            CustomMessageBox.Info(Properties.Resources.OPERATION_SUCCESS);
        }
    }
}
