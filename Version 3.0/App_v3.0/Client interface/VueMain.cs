using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client_interface
{
    class VueMain
    {
        public static void Initialization()
        {
        }

        public static Boolean whiler = true;
        public static Socket client;
        public static int Saves_nbr;
        public static void Clientconnect(String address)
        {
            client = Client.SeConnecter(address);
            Saves_nbr = int.Parse(Client.ServerReceive(client));
        }

        public static String GetSRC(String saveName)
        {
            Client.ServerSend(client, saveName);
            String recData = Client.ServerReceive(client);
            String[] vs = recData.Split("#");

            if(vs[0] == "src")
            {
                return vs[1];
            }
            else
            {
                return "";
            }
        }
        public static String GetTRG(String saveName)
        {
            Client.ServerSend(client, saveName);
            String recData = Client.ServerReceive(client);
            String[] vs = recData.Split("#");

            if (vs[0] == "trg")
            {
                return vs[1];
            }
            else
            {
                return "";
            }
        }

        public static void Start_save(String saveName)
        {
            Client.ServerSend(client, "Start_" + saveName);
        }

        public static void Stop_save(String saveName)
        {
            Client.ServerSend(client, "Stop_" + saveName);
        }
    }
}
