using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace App_Easy_Save
{
    public class Server
    {
        private static IPEndPoint clientEndPoint;

        private static Socket SeConnecter()
        {

            Socket socket = null;
            int port = 9050;
            String adress = "127.0.0.1";

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse(adress), port);

            try
            {
                Socket TrySock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                TrySock.Bind(localEndPoint);
                TrySock.Listen(10);

                socket = TrySock;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }

            Trace.WriteLine("Server available at listenning...");
            return socket;
        }

        private static Socket AccepterConnexion(Socket socket)
        {
            Socket client = socket.Accept();
            

            clientEndPoint = (IPEndPoint)client.RemoteEndPoint;

            Trace.WriteLine("Client connecté avec l'adresse "+ clientEndPoint.Address + ", et le port " + clientEndPoint.Port);

            return (client);
        }

        private static void Deconnecter(Socket socket)
        {
            Console.WriteLine("Déconnecté de {0}", clientEndPoint.Address);

            socket.Close();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }


        private static void ReseauNewConnexion(Socket client)
        {
            String input;
            int recData;

            String welcome = "Welcome on Easy save";

            byte[] data = new byte[1024];

            data = Encoding.UTF8.GetBytes(welcome);

            client.Send(data, data.Length, SocketFlags.None);

        }

        public static void ReseauSend(Socket client, String data)
        {
            try
            {
                client.Send(Encoding.UTF8.GetBytes(data));
            }
            catch(NullReferenceException e)
            {

            }
            
        }

        public static String ReseauListen(Socket client)
        {
            byte[] data = new byte[1024];

            int recData;

            recData = client.Receive(data);

            return Encoding.UTF8.GetString(data, 0, recData);

        }

        public static Socket server;
        public static Socket client;
        public static void Init()
        {
            server = SeConnecter();

            Thread t = new Thread(new ThreadStart(
                () => { 
                    client = AccepterConnexion(server);
                    int number = Prepare.Save_Number();
                    ReseauSend(client, number.ToString());
                    String save_nbr = ReseauListen(client);
                    Prepare.ClientSave_infos(save_nbr);

                    byte[] data = new byte[1024];

                    while (true)
                    {
                        int recData = client.Receive(data);
                        String recStr = Encoding.UTF8.GetString(data, 0, recData);

                        String[] cmd = recStr.Split('_');
                        if(cmd[0] == "Start")
                        {
                            VueMain.Save_single(cmd[1], false);
                        }
                        if(cmd[0] == "Stop")
                        {
                            VueMain.Stop_btn_click();
                        }
                        else
                        {

                        }
                    }
                }));
            t.Start();


        }
    }
}
