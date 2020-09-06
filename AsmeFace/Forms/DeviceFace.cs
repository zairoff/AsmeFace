using AsmeFace.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsmeFace.Forms
{
    public partial class DeviceFace : Form
    {
        public DeviceFace()
        {
            InitializeComponent();
        }

        private static bool _isCollapsedBasic;
        private static bool _isCollapsedAlarm;
        private static bool _isCollapsedTemp;
        private static bool _isCollapsedAdvanced;        

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
    }
}
