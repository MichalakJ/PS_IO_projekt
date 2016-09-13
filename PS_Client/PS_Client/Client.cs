using PS_Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PS_Client
{
    class Client
    {
        private UdpClient client;
        private IPEndPoint ServerEp = new IPEndPoint(IPAddress.Any, 0);
        private int port;
        private IPEndPoint broadcastEp;
        private Form1 form;
        private TcpClient tcpClient;
        private Thread tcpListenThread;
        public Client(int port, Form1 form)
        {
            this.form = form;
            client = new UdpClient();

            this.port = port;
            broadcastEp = new IPEndPoint(IPAddress.Broadcast, port);
        }
        public void doWork()
        {
            form.SetClientText("inside doWork");

            byte[] msgToSend = Encoding.ASCII.GetBytes("DISCOVER");
            form.SetClientText("sending discover msg...");
            client.Send(msgToSend, msgToSend.Length, broadcastEp);
            form.SetClientText("msg sent...waiting for answer");
            byte[] msgReceived = client.Receive(ref ServerEp);
            String msgStr = Encoding.ASCII.GetString(msgReceived);
            processMsg(msgStr);
            form.SetClientText(msgStr);

        }
        public void connectTcp()
        {
            string[] tcpServerEp = form.getSelectedServer().Split(':');
            form.SetClientText(tcpServerEp[0]);
            form.SetClientText(tcpServerEp[1]);
            
            tcpClient = new TcpClient();
            tcpClient.Connect(tcpServerEp[0], Convert.ToInt32(tcpServerEp[1]));
            tcpListenThread = new Thread(new ThreadStart(listenTCP));
            tcpListenThread.Start();
        }
        public void sendMsg()
        {
            NetworkStream netStream = tcpClient.GetStream();
            Byte[] sendBytes = Encoding.UTF8.GetBytes(form.getUserName());
            netStream.Write(sendBytes, 0, sendBytes.Length);
        }
        public void closeConnection()
        {
            tcpClient.Close();
        }

        private void listenTCP()
        {
            while (true)
            {
                NetworkStream clientStream = tcpClient.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();

                int size = 1024;
                byte[] msg = new byte[size];
                int bytesRead;
                bytesRead = 0;
                try
                {
                    bytesRead = clientStream.Read(msg, 0, size);
                }
                catch (Exception ex)
                {
                    form.SetClientText("connection problem occoured ");
                }
                if (bytesRead == 0)
                {
                    form.SetClientText("server disconnected");
                    break;
                }
                String stringMsg = encoder.GetString(msg);
                form.SetClientText("recived msg from " + tcpClient.Client.RemoteEndPoint + ": " + stringMsg + " ");
                form.SetClientText("\n");
            }
        }

        public void valueCommand(string text)
        {
            int interval = Convert.ToInt32(text);
            Thread thread = new Thread(new ParameterizedThreadStart(sendNumbers));
            thread.Start(interval);
        }
        private void sendNumbers(object param)
        {
            int interval = (Int32)param;
            while (true)
            {
                try
                {
                    Random rnd = new Random();
                    String msgToSend = rnd.Next(100).ToString();
                    NetworkStream netStream = tcpClient.GetStream();
                    Byte[] sendBytes = Encoding.UTF8.GetBytes(msgToSend);
                    netStream.Write(sendBytes, 0, sendBytes.Length);
                    Thread.Sleep(interval);
                }catch(Exception ex)
                {
                    form.SetClientText("disconnected");
                    break;
                }
            }
        }
        
        private void processMsg(string msg)
        {
            string[] split = msg.Split(':');

            if (split.Length == 3 && split[0].Equals("OFFER")){
                form.addServer(split[1] + ":" + split[2]);
            }

        }

    }
}
