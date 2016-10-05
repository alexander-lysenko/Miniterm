﻿using System;
using System.Windows.Forms;

namespace UI_DataPicker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            PickerTimer.Start();
        }

        public int DeviceNumber
        {
            set { DeviceNumberLabel.Text = "№ " + value; }
        }

        public string DeviceName
        {
            set { DeviceNameLabel.Text = value; }
        }

        public string Date
        {
            set { DateStatusLabel.Text = value; }
        }

        public void SetData(string CurrentTemperature, string Temperature2, 
            string TaskTemperature, string txc, string OutputY, string Mode, string Time)
        {
            CurrentTemperatureLabel.Text = CurrentTemperature;
            TaskTemperatureLabel.Text = TaskTemperature;
            Temperature2Label.Text = Temperature2;
            TXCLabel.Text = txc;
            YOutputLabel.Text = OutputY;
            ModeLabel.Text = Mode;
            TimeStatusLabel.Text = Time;
        }

        private void SettingsTSMI_Click(object sender, System.EventArgs e)
        {
            SettingsForm.ShowForm();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogoutForm.ShowForm();
            e.Cancel = true;
        }

        private void PickerTimer_Tick(object sender, System.EventArgs e)
        {
            CurrentTemperatureLabel.Text = (new Random().Next()%100).ToString(); 
            DateStatusLabel.Text = DateTime.Now.ToShortDateString();
            TimeStatusLabel.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
