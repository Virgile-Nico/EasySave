using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Encrypt(string data)
        {
            string key = File.ReadAllText(@".\key.txt");
            int datalength = data.Length;
            String filedata = File.ReadAllText(data);
            int keylength = key.Length;
            char[] result = new char[datalength];
            for (int i = 0; i < datalength; i++)
            {
                result[i] = (char)(data[i] ^ key[i % keylength]);
            }
            string resultString = "";
            File.WriteAllText(resultString, data);
        }

        public static int Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int exectime = -1;
            
            if (args.Length != 1)
            {
                watch.Stop();
                return exectime;
            }
            else
            {
                try
                {

                    Encrypt(args[0]);
                    watch.Stop();

                    int timeExe = (int)(watch.Elapsed.TotalSeconds * 1000);
                    Console.WriteLine(timeExe);
                    return timeExe;
                }
                catch
                {
                    return exectime;
                }

            }
        }
    }
}
