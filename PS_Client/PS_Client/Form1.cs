using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS_Client
{
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(string text);
        delegate void SetaddServerCallback(string serverInfo);
        Client client;
        public Form1()
        {
            InitializeComponent();
        }

        public void SetClientText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.clientTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetClientText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.clientTextBox.Text += text + "\n";
            }
        }

        public void addServer(string serverInfo)
        {
            if (this.serverList.InvokeRequired)
            {
                SetaddServerCallback d = new SetaddServerCallback(addServer);
                this.Invoke(d, new object[] { serverInfo });
            }else
            {
                if(this.serverList.FindItemWithText(serverInfo) ==null)
                {
                    this.serverList.Items.Add(serverInfo);
                }
                else
                {
                    
                }
                
            }
        }

        public string getSelectedServer()
        {
            return serverList.SelectedItems[0].Text;
        }

        public string getUserName()
        {
            return userNameTextBox.Text;
        }

        private void discoverBtn_Click(object sender, EventArgs e)
        {
            client = new Client(7, this);
            Thread workerThread = new Thread(client.doWork);
            workerThread.Start();
        }

        private void tcpBtn_Click(object sender, EventArgs e)
        {
            client.connectTcp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.sendMsg();
        }

        private void closeTCP_Click(object sender, EventArgs e)
        {
            client.closeConnection();
        }

        private void valueBtn_Click(object sender, EventArgs e)
        {
            client.valueCommand(value.Text);
        }
    }


}
