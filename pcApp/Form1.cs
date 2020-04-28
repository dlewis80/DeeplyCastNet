using System;
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
        public bool messageRecieved;
        public bool sendingSettings;
        public List<int> values;

        public AcousticModemForm()
        {
            InitializeComponent();
            RxMessage = new StringBuilder();

            BaudSelect.DataSource = new int[] {110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200};
            BaudSelect.SelectedIndex = 4;

            TotalTextBox.Text = "3";

            messageRecieved = false;
            sendingSettings = false;
            values = new List<int>();

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
            serialPort1.WriteLine("1"+messageTextBox.Text);
            logTextBox.AppendText("Tx: " + messageTextBox.Text + "\n");
            messageTextBox.Clear();
        }

        private void sendSerialButton_Click(object sender, EventArgs e)
        {
            sendSerial();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string existing = serialPort1.ReadExisting();

            if (sendingSettings && existing[0] == '0')
            {
                messageRecieved = true;              
                return;
            }
            else
            {

                foreach (char c in existing) 
                {
                    int what = Int16.Parse(c.ToString());
                    System.Diagnostics.Debug.WriteLine("received " + what);
                    values.Add(what);

                    if (values.Count() > 20)
                    {
                        values.RemoveAt(0);
                    }
                }


                System.Diagnostics.Debug.Write("list: ");
                foreach (int i in values)
                {
                    System.Diagnostics.Debug.Write(i + ", ");
                }
                System.Diagnostics.Debug.WriteLine("");

                System.Diagnostics.Debug.WriteLine("average: " + (values.Sum()/20.0));

                if (values.Sum() / 20.0 >= .9)
                {
                    logTextBox.AppendText("1\n");
                } else if (values.Sum() / 20.0 <= .1)
                {
                    logTextBox.AppendText("0\n");
                }
                logTextBox.ScrollToCaret();


                


                /*
                RxMessage.Append(existing);

                String received = RxMessage.ToString();
                RxMessage.Clear();
                RxMessage.Append(received); //This isn't how you are supposed to use StringBuilders lol

                System.Diagnostics.Debug.WriteLine("received: " + received + " from source");


                if (received.EndsWith("\n"))
                {
                    logTextBox.AppendText("Rx: " + received);
                    RxMessage.Clear();
                }
                */
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

        private void messageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Catch the enter key
            if (e.KeyChar == '\r')
            {
                sendSerial();
            }
        }

        private void SendSettingsButton_Click(object sender, EventArgs e)
        {

            sendingSettings = true;

            bool success = true;
            success &= SendSetting('0', TotalTextBox.Text);

            success &= SendSetting('1', IdComboBox.Text);
            success &= SendSetting('2', Target1Combo.Text);
            success &= SendSetting('3', Target2Combo.Text);
            success &= SendSetting('4', BinCombo.Text);
            success &= SendSetting('5', EnergyCombo.Text);
            success &= SendSetting('6', GainCombo.Text);
            success &= SendSetting('7', A1TextBox.Text);
            success &= SendSetting('8', A2TextBox.Text);
            success &= SendSetting('9', A3TextBox.Text);
            sendingSettings = false;

            if (!success)
            {
                //display an error somehow
            }
        }

        private bool SendSetting(char code, string data)
        {

            if (data == "")
            {
                System.Diagnostics.Debug.WriteLine("No Data for " + code);
                return false;
            }

            StringBuilder TxMessage = new StringBuilder();
            TxMessage.Append("1");
            TxMessage.Append(code);
            TxMessage.Append(data);
            //string toSend = TxMessage.ToString();
            string toSend = "1" + code + data;

            System.Diagnostics.Debug.WriteLine("Transmitting: ", toSend, "\r\n");

            messageRecieved = false;
            int timeout = 10;
            while (!messageRecieved)
            {
                serialPort1.WriteLine(toSend);

                timeout--;
                if (timeout <= 0)
                {
                    // Failed to recieve response
                    return false;
                }
            }

            return true;
        }

        private void IdComboBox_DropDown(object sender, EventArgs e)
        {
            IdComboBox.Items.Clear();
            for (int i = 0; i < (Int16.Parse(TotalTextBox.Text)); i++)
            {
                IdComboBox.Items.Add(i);
            }
        }
    }
}
