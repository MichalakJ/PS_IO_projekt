using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PS_Server
{
    class TcpServer
    {
        int port;
        private TcpListener tcpServer;
        private Thread tcpListenThread;
        bool isListening = false;
        Form1 form;
        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        public TcpServer(Form1 form, int tcpPort)
        {
            this.form = form;
            port = tcpPort;
            tcpServer = new TcpListener(localAddr, tcpPort);
            tcpListenThread = new Thread(new ThreadStart(tcpListenForClient));
            tcpListenThread.Start();
        }

        public void tcpListenForClient()
        {
            isListening = true;
            tcpServer.Start();
            while (isListening)
            {
                TcpClient client = tcpServer.AcceptTcpClient();
                form.SetServerText("connected client on " + client.Client.RemoteEndPoint + " ");
                Thread clientThread = new Thread(new ParameterizedThreadStart(handleClient));
                clientThread.Start(client);
            }
        }

        private void handleClient(object Client)
        {
            TcpClient tcpClient = (TcpClient)Client;
            String userName = null;
            try
            {
                String response;
                do
                {
                    sendMsg("Connected, provide user name", tcpClient);
                    String stringMsg = waitForMsg(tcpClient);
                    if (form.userNameTaken(stringMsg))
                    {
                        response = "user name already taken, try other name";
                    }
                    else
                    {
                        form.addUserToList(stringMsg);
                        response = "user added";
                        userName = stringMsg;
                    }
                    sendMsg(response, tcpClient);
                } while (userName == null);

                while (true)
                {
                    waitForMsg(tcpClient);
                }
            }
            catch (Exception ex)
            {
                form.SetServerText(ex.ToString());
            }

            form.SetServerText("closed client " + tcpClient.Client.RemoteEndPoint + " ");

            tcpClient.Close();
        }

        private String waitForMsg(TcpClient client)
        {
            NetworkStream clientStream = client.GetStream();
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
                form.SetServerText("client exception occoured \n");
                throw ex;
            }
            if (bytesRead == 0)
            {
                return null;
            }
            String stringMsg = encoder.GetString(msg);
            form.SetServerText("recivedd msg from " + client.Client.RemoteEndPoint + ": " + stringMsg);
            form.SetServerText("\n");
            
            return stringMsg;
        }

        private void sendMsg(String msg, TcpClient tcpClient)
        {
            NetworkStream netStream = tcpClient.GetStream();
            Byte[] sendBytes = Encoding.UTF8.GetBytes(msg);
            netStream.Write(sendBytes, 0, sendBytes.Length);
        }
    }
}
