using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace Console_Vue
{
    class Save
    {
        /// <summary>
        /// Function to do saves
        /// </summary>
        /// <param name="source">Source path</param>
        /// <param name="Target">Target path</param>
        /// <param name="Type">Save type, to know wich save we have to do</param>
        /// <param name="SaveName">Save name, to log the save</param>
        public static void save(String source, String Target, String Type, String SaveName)
        {
            //Check the type
            if(Type == "Full")
            {
                //write the log for the save
                Log_Save.Log_Write(SaveName, source, Target);

                //Call the save funciton to do the save of files
                Full_Save(source, Target, SaveName);

                //Edit the log for the save, because it has ended
                Log_Save.Log_End(SaveName, source, Target);
            }
            if(Type == "Diff")
            {
                //write the log for the save
                Log_Save.Log_Write(SaveName, source, Target);

                //Call the save funciton to do the save of files
                Diff_Save(source, Target, SaveName);

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
        public static void Full_Save(String source, String target, String SaveName)
        {
            //Lists to get all the files, and all the folders to save
            String[] Files = Directory.GetFiles(source);
            String[] Folders = Directory.GetDirectories(source);

            //For each files in the list, save it
            foreach (String file in Files)
            {
                //Create the file target path
                String file_Target = file.Replace(source, target);

                //Call save function
                save_files(source, target, SaveName, file);
            }

            //For each folder in the list, create it in the target folder, and recall the full save funciton to save teh subfolders and subfiles
            foreach(String folder in Folders)
            {
                //Create the folder new path
                String target_folder = folder.Replace(source, target);

                save_folders(target_folder);

                Full_Save(folder, target_folder, SaveName);
            }
        }

        public static void Diff_Save(String source, String target, String SaveName)
        {
            //Lists to get all the files, and all the folders to save
            String[] Files = Directory.GetFiles(source);
            String[] Folders = Directory.GetDirectories(source);

            //For each files in the list, save it
            foreach (String file in Files)
            {
                //Create the file target path
                String file_Target = file.Replace(source, target);

                //Check the last edit time, and if the target file is older than the source one, sve it
                if(File.GetLastWriteTime(file_Target) < File.GetLastWriteTime(file))
                {
                    save_files(source, target, SaveName, file);
                }
            }

            //For each folder in the list, create it in the target folder, and recall the Differential save funciton to save teh subfolders and subfiles
            foreach (String folder in Folders)
            {
                //Create the folder new path
                String Folder_Path = folder.Replace(source, target);

                //Check if the folder exist
                save_folders(Folder_Path);

                Diff_Save(folder, Folder_Path, SaveName);
            }
        }

        private static void save_files(String source, String target, String SaveName, String file_source)
        {
            //Log the file informations to copy
            String dst = file_source.Replace(source, target);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Copy the file (true option to overwrite the file)
            File.Copy(file_source, dst, true);
            stopWatch.Stop();

            //Call the log daily update function to update the log file
            Log_Daily.Log_Write(SaveName, file_source, dst, stopWatch.Elapsed.TotalMilliseconds.ToString());

            //call the log save update function to update the number of files left to do
            Log_Save.Log_update(SaveName, source, target);

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
    }
}
