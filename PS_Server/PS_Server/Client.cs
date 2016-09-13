/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PS_Server
{
    class Client
    {
        private UdpClient client;
        private IPEndPoint ServerEp = new IPEndPoint(IPAddress.Any, 0);
        private int port;
        private IPEndPoint broadcastEp;
        private Form1 form;
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
            form.SetClientText(Encoding.ASCII.GetString(msgReceived));

        }
        public void connectTcp()
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1", 20);
            NetworkStream netStream = tcpClient.GetStream();
            Byte[] sendBytes = Encoding.UTF8.GetBytes("Is anybody there?");
            netStream.Write(sendBytes, 0, sendBytes.Length);

        }
        
    }
}
*/