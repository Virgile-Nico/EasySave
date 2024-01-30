using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Management;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace App_Easy_Save
{
    public delegate void SoftwareStartDelegate(SoftwareStartAnalyzer Software);
    public delegate void PauseDelegate(PauseBtnClick pause);
    public delegate void StopDelegate(StopBtnClick stop);
    public delegate void NetwDelegate(NetworkAnalyser network);
    

    public class Save
    {
        public static int Files_max_simul = 0;
        public static Semaphore sema;
        public static Thread[] threadsID = new Thread[0];


        public static int files = 0;
        public static int Done = 0;


        /// <summary>
        /// Function to do saves
        /// </summary>
        /// <param name="source">Source path</param>
        /// <param name="Target">Target path</param>
        /// <param name="Type">Save type, to know wich save we have to do</param>
        /// <param name="SaveName">Save name, to log the save</param>
        public static void save(String source, String Target, String Type, String SaveName, Boolean encrypt)
        {

            String Work_Process_Name = ConfigurationManager.AppSettings["Work_Process"];
            Files_max_simul = int.Parse(ConfigurationManager.AppSettings["Files_same_time"]);
            sema = new Semaphore(initialCount: Files_max_simul, maximumCount: Files_max_simul);
            VueMain.To_Do = File.Exists(source) ? 1 : Directory.GetFiles(source, "*.*", SearchOption.AllDirectories).Length;
            //Check the type
            if (Type == "Full")
            {
                //write the log for the save
                Log_Save.Log_Write(SaveName, source, Target);

                //Call the save funciton to do the save of files
                Full_Save(source, Target, SaveName, encrypt);

                //Edit the log for the save, because it has ended
                Log_Save.Log_End(SaveName, source, Target);
            }
            if (Type == "Diff")
            {
                //write the log for the save
                Log_Save.Log_Write(SaveName, source, Target);

                //Call the save funciton to do the save of files
                Diff_Save(source, Target, SaveName, encrypt);

                //Edit the log for the save, because it has ended
                Log_Save.Log_End(SaveName, source, Target);
            }

        }

        /// <summary>
        /// Function to do a full save
        /// </summary>
        /// <param name="source">Source path</param>
        /// <param name="target">target path</param>
        /// <param name="SaveName">Save name, t log the informations</param>
        public static void Full_Save(String source, String target, String SaveName, Boolean encrypt)
        {
            //Lists to get all the files, and all the folders to save
            String[] Files = Directory.GetFiles(source);
            String[] Folders = Directory.GetDirectories(source);

            files = Files.Length;

            //For each files in the list, save it
            foreach (String file in Files)
            {
                //Create the file target path
                String file_Target = file.Replace(source, target);
                String Prio_file = ConfigurationManager.AppSettings["Prio_Files"];
                //Call save function
                Thread t = new Thread(new ThreadStart(() => { save_files(source, target, SaveName, file, encrypt); }));
                if (Path.GetExtension(source) == Prio_file)
                {
                    t.Priority = ThreadPriority.Highest;
                }
                Array.Resize(ref threadsID, (threadsID.Length + 1));
                threadsID[threadsID.Length - 1] = t;
                t.Name = SaveName;
                t.Start();

                Done++;
            }

            //For each folder in the list, create it in the target folder, and recall the full save funciton to save teh subfolders and subfiles
            foreach (String folder in Folders)
            {
                //Create the folder new path
                String target_folder = folder.Replace(source, target);

                save_folders(target_folder);

                Full_Save(folder, target_folder, SaveName, encrypt);
            }
        }

        public static void Diff_Save(String source, String target, String SaveName, Boolean encrypt)
        {
            //Lists to get all the files, and all the folders to save
            String[] Files = Directory.GetFiles(source);
            String[] Folders = Directory.GetDirectories(source);


            //For each files in the list, save it
            foreach (String file in Files)
            {
                //Create the file target path
                String file_Target = file.Replace(source, target);
                String Prio_file = ConfigurationManager.AppSettings["Prio_Files"];
                //Call save function
                Thread t = new Thread(new ThreadStart(() => { save_files(source, target, SaveName, file, encrypt); }));
                if(Path.GetExtension(source) == Prio_file)
                {
                    t.Priority = ThreadPriority.Highest;
                }
                t.Start();
            }

            //For each folder in the list, create it in the target folder, and recall the Differential save funciton to save teh subfolders and subfiles
            foreach (String folder in Folders)
            {
                //Create the folder new path
                String Folder_Path = folder.Replace(source, target);

                //Check if the folder exist
                save_folders(Folder_Path);

                Diff_Save(folder, Folder_Path, SaveName, encrypt);
            }
        }

        private static void save_folders(String Folder_path)
        {
            if (Directory.Exists(Folder_path) == false)
            {
                //if, no
                //Create te folder
                //Recall the differential save funciton to save subfolders and subfiles
                Directory.CreateDirectory(Folder_path);


            }
        }


        public static SoftwareStartAnalyzer software = new SoftwareStartAnalyzer(ConfigurationManager.AppSettings["Work_Process"]);
        public static PauseBtnClick Pause = new PauseBtnClick("Pause");
        public static StopBtnClick Stop = new StopBtnClick("Stop");

        public static NetworkAnalyser Netw = new NetworkAnalyser(ConfigurationManager.AppSettings["Network_max_use"]);

        public static SoftwareListener listener = new SoftwareListener(software);
        public static PauseListener pauseListener = new PauseListener(Pause);
        public static StopListener stopListener = new StopListener(Stop);

        public static NetworkListener NetwListener = new NetworkListener(Netw);

        public static Boolean pause_status = false;
        public static int current_size = 0;

        public static void save_files(String source, String target, String SaveName, String file_source, Boolean encrypt)
        {
            //Log the file informations to copy
            String dst = file_source.Replace(source, target);

            try
            {
                software.Analyze();
                Stop.StopClick();
                Pause.ListenClick();
                Netw.Analyse();
                sema.WaitOne();

                while(pause_status == true)
                {
                    Thread.Sleep(1);
                }

                FileInfo fi = new FileInfo(file_source);

                while(current_size >= int.Parse(ConfigurationManager.AppSettings["Files_max_size"]) * 1000)
                {
                    if(int.Parse(ConfigurationManager.AppSettings["Files_max_size"]) == 0)
                    {
                        break;
                    }
                    else
                    {
                        Thread.Sleep(10);
                    }
                }

                current_size = current_size + (int)fi.Length;
                Trace.WriteLine("Fichier de " + (int)fi.Length + " bytes en cours");
                if (encrypt == true)
                {
                    String[] args = new string[] { source, dst };
                    String extension = Path.GetExtension(source);
                    if (extension == ".txt")
                    {
                        double Process_Time = ConsoleApp1.Program.Main(args);
                        if (Process_Time == -1)
                        {
                            Log_Daily.Log_Write(SaveName, file_source, dst, "-1");
                        }
                        else
                        {
                            Log_Daily.Log_Write(SaveName, file_source, dst, Process_Time.ToString());
                        }
                    }
                    else
                    {
                        double transferTime = 0;

                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();

                        //Copy the file (true option to overwrite the file)
                        File.Copy(file_source, dst, true);

                        stopWatch.Stop();

                        transferTime = stopWatch.Elapsed.TotalMilliseconds;
                        Log_Daily.Log_Write(SaveName, file_source, dst, stopWatch.Elapsed.TotalMilliseconds.ToString());
                    }
                }

                if (encrypt == false)
                {
                    double transferTime = 0;

                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();

                    //Copy the file (true option to overwrite the file)
                    File.Copy(file_source, dst, true);

                    stopWatch.Stop();

                    transferTime = stopWatch.Elapsed.TotalMilliseconds;
                    Log_Daily.Log_Write(SaveName, file_source, dst, stopWatch.Elapsed.TotalMilliseconds.ToString());
                }
                //call the log save update function to update the number of files left to do
                Log_Save.Log_update(SaveName, source, target);
                sema.Release();

                Trace.WriteLine("Copy finished");
                VueMain.ProgressConverter(files);
                current_size = current_size - (int)fi.Length;
            }
            catch (System.Threading.ThreadInterruptedException e)
            {
                
            }

        }        
    }

    class file_to_save
    {
        private static string Source { get; set; }
        private static string Target { get; set; }
        private static string SaveName { get; set; }
        private static string file_source { get; set; }
        private static Boolean encrypt { get; set; }

    }

    public class SoftwareStartAnalyzer
    {
        public string SoftwareName;
        public event SoftwareStartDelegate SoftwareStartEvent;

        public SoftwareStartAnalyzer(String name)
        {
            SoftwareName = name;
        }
        public void Analyze()
        {
            SoftwareStartEvent?.Invoke(this);
        }
    }

    public class SoftwareListener
    {
        public SoftwareStartAnalyzer software;
        public SoftwareListener(SoftwareStartAnalyzer softwareStart)
        {
            software = softwareStart;
            software.SoftwareStartEvent += SoftwareListen;
        }

        public void SoftwareListen(SoftwareStartAnalyzer software)
        {
            String Work_Process_Name = ConfigurationManager.AppSettings["Work_Process"];
            Process[] pname = Process.GetProcessesByName(Work_Process_Name);
            if(pname.Length > 0)
            {
                Thread.CurrentThread.Interrupt();
            }
        }
    }


    public class PauseBtnClick
    {
        public string BtnName;
        public Boolean state;
        public event PauseDelegate PauseEvent;

        public PauseBtnClick(String name)
        {
            BtnName = name;
            state = false;
        }
        public void ListenClick()
        {
            PauseEvent?.Invoke(this);
        }
    }
    public class PauseListener
    {
        public PauseBtnClick pauseBtn;

        public PauseListener(PauseBtnClick PauseBtn)
        {
            pauseBtn = PauseBtn;
            pauseBtn.PauseEvent += PauseListen;
        }
        public void PauseListen(PauseBtnClick PauseBtn)
        {
            if(PauseBtn.state == true)
            {
                foreach (Thread t in Save.threadsID)
                {
                    Save.pause_status = true;
                }
            }
            else
            {
                foreach (Thread t in Save.threadsID)
                {
                    Save.pause_status = false;
                }
            }
        }
    }
    public class StopBtnClick
    {
        public string BtnName;
        public Boolean state;
        public event StopDelegate StopEvent;

        public StopBtnClick(String name)
        {
            BtnName = name;
            state = false;
        }
        public void StopClick()
        {
            StopEvent?.Invoke(this);
        }
    }
    public class StopListener
    {
        public StopBtnClick stopBtn;

        public StopListener(StopBtnClick StopBtn)
        {
            stopBtn = StopBtn;
            stopBtn.StopEvent += StopListen;
        }
        public void StopListen(StopBtnClick StopBtn)
        {
            if(StopBtn.state == true)
            {
                try
                {
                    foreach (Thread t in Save.threadsID)
                    {
                        t.Interrupt();
                    }
                    Thread.CurrentThread.Interrupt();

                    StopBtn.state = false;
                }
                catch(ThreadInterruptedException e)
                {
                    Trace.WriteLine(e);
                }
                
            }
        }
    }

    public class NetworkAnalyser
    {
        public string Netw;
        public event NetwDelegate NetwEvent;

        public NetworkAnalyser(String max)
        {
            Netw = max;
        }
        public void Analyse()
        {
            NetwEvent.Invoke(this);
        }
    }
    public class NetworkListener
    {
        public NetworkAnalyser network;

        public NetworkListener(NetworkAnalyser netChange)
        {
            network = netChange;
            network.NetwEvent += NetwListen;
        }
        public void NetwListen(NetworkAnalyser networkAnalyser)
        {
            if(ConfigurationManager.AppSettings["Network_max_use"] == "0")
            {

            }
            else
            {
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    return;
                }

                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

                long send = 0;
                long receive = 0;

                foreach (NetworkInterface ni in interfaces)
                {
                    send = send + ni.GetIPv4Statistics().BytesSent;
                    receive = receive + ni.GetIPv4Statistics().BytesReceived;
                }
                send = send / 1000000;

                if ((int)send > int.Parse(ConfigurationManager.AppSettings["Network_max_use"]))
                {
                    try
                    {
                        foreach (Thread t in Save.threadsID)
                        {
                            t.Interrupt();
                        }
                        Thread.CurrentThread.Interrupt();
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Trace.WriteLine("Network max use !");
                        Trace.WriteLine(e);
                    }
                }
            }
        }
    }
}
