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

namespace PS_Server
{
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(string text);
        delegate void SetaddUserCallback(string userName);
        delegate Boolean SetUserNameTakenCallback(string userName);
        Server server;
        TcpServer tcpServer;
        public Form1()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tcpPort = Int32.Parse(textBoxTcpPort.Text);
            server = new Server (this, tcpPort);
            Thread workerThread = new Thread(server.listen);
            workerThread.Start();
            tcpServer = new TcpServer(this, tcpPort);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            server.stop();
           
        }


        public void SetServerText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.serverTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetServerText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.serverTextBox.Text += text+"\n";
            }
        }


        public void addUserToList(String userName)
        {
            if (this.users.InvokeRequired)
            {
                SetaddUserCallback d = new SetaddUserCallback(addUserToList);
                this.Invoke(d, new object[] { userName });
            }
            else
            {
                this.users.Items.Add(userName);
            }

        }

        public Boolean userNameTaken(String userName)
        {
            if (this.users.InvokeRequired)
            {
                SetUserNameTakenCallback d = new SetUserNameTakenCallback(userNameTaken);
                return (Boolean) this.Invoke(d, new object[] { userName });
            }
            else
            {
                if  (this.users.FindItemWithText(userName) == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


    }
}
