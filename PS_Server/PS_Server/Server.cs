using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS_Server
{
    class Server
    {
        private Form1 form;
        private int udpPort = 7;
        private int tcpPort;
        private UdpClient server;
        private Boolean isListening;
        private IPEndPoint receiveEp = new IPEndPoint(IPAddress.Any, 0);
        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        private IPEndPoint broadcastEp;
       

        public Server (Form1 form, int tcpPort)
        {
            server = new UdpClient(udpPort);
            this.tcpPort = tcpPort;
            this.form = form;
            broadcastEp = new IPEndPoint(IPAddress.Broadcast, udpPort);
            form.SetServerText("set tcp server on " + localAddr.ToString() + " " + tcpPort);
        }
        public void listen()
        {
            isListening = true;
            form.SetServerText("Listen");
            while (isListening)
            {
                form.SetServerText("inside listen");
                byte[] receivedMsg = server.Receive(ref receiveEp);
                String convertedMsg = Encoding.ASCII.GetString(receivedMsg);
                form.SetServerText(convertedMsg);
                if (convertedMsg.Equals("DISCOVER"))
                {
                    form.SetServerText("detected discover - sending offer");
                    String offerMsg = "OFFER:" + localAddr.ToString() + ":" + tcpPort.ToString();
                    byte[] serverInfo = Encoding.ASCII.GetBytes(offerMsg);
                    server.Send(serverInfo, serverInfo.Length, receiveEp);
                }
                

            }
        }


        public void stop()
        {
            isListening = false;
        }
    }
}
