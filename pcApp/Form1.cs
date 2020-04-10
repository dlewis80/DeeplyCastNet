﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;

namespace AcousticModem
{
    public partial class AcousticModemForm : Form
    {

        public StringBuilder RxMessage;
        public AcousticModemForm()
        {
            InitializeComponent();
            RxMessage = new StringBuilder();

            BaudSelect.DataSource = new int[] {110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200};
            BaudSelect.SelectedIndex = 6;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void connectButton_Click(object sender, EventArgs e)
        {

            if (!serialPort1.IsOpen) {
                try
                {
                    serialPort1.PortName = (string) COMSelect.SelectedItem;
                    serialPort1.BaudRate = (int) BaudSelect.SelectedItem;
                    serialPort1.Open();

                    StatusDisplay.Text = "Connected";
                    StatusDisplay.BackColor = Color.FromName("Green");

                    connectButton.Enabled = false;
                }

                catch
                {
                    StatusDisplay.Text = "Not Connected";
                    StatusDisplay.BackColor = Color.FromName("Red");

                    connectButton.Enabled = true;
                }
            }
        }

        private void sendSerial() {
            // Need to add error checking for connection
            // Also need to check that message is in the right format
            serialPort1.WriteLine(messageTextBox.Text);
            logTextBox.AppendText("Tx: " + messageTextBox.Text + "\n");
            messageTextBox.Clear();
        }

        private void sendSerialButton_Click(object sender, EventArgs e)
        {
            sendSerial();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            RxMessage.Append(serialPort1.ReadExisting());

            String received = RxMessage.ToString();
            RxMessage.Clear();
            RxMessage.Append(received); //This isn't how you are supposed to use StringBuilders lol

            System.Diagnostics.Debug.WriteLine("received: " + received + " from source");

            if (received.EndsWith("\n"))
            {
                logTextBox.AppendText("Rx: " + received);
                RxMessage.Clear();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
             if (serialPort1.IsOpen) serialPort1.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            string[] COMPorts = SerialPort.GetPortNames();
            foreach (string COMPort in COMPorts)
            {
                COMSelect.Items.Add(COMPort);
            }
        }

        private void logTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TotalTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TargetLabel_Click(object sender, EventArgs e)
        {

        }

        private void A3TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void A3Label_Click(object sender, EventArgs e)
        {

        }

        private void messageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Catch the enter key
            if (e.KeyChar == '\r')
            {
                sendSerial();
            }
        }
    }
}
