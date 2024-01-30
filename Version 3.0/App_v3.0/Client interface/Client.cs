using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client_interface
{
    public class Client
    {
        public static Socket SeConnecter(String address)
        {
            Socket server = null;
            int port = 9050;

            IPEndPoint clientEndpoint = new IPEndPoint(IPAddress.Parse(address), port);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(clientEndpoint);

            }
            catch (SocketException e)
            {
                Trace.WriteLine("unable to connect to server");

                Trace.WriteLine(e.ToString());
            }

            return server;
        }

        public static String ServerReceive(Socket server)
        {
            byte[] data = new byte[1024];

            int recData;

            recData = server.Receive(data);

            String recstr = Encoding.UTF8.GetString(data, 0, recData);

            Trace.WriteLine(recstr);

            return recstr;
        }

        public static void ServerSend(Socket server, String info)
        {
            server.Send(Encoding.UTF8.GetBytes(info));
        }
    }
}
