using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace App_Easy_Save
{
    class Paths
    {
        //Variables to store th differents files
        public static String App_Path = ""; //Default emplacement 
        public static String Log_Daily_Path = "Log";
        public static String Log_Save_path = "Work_Log";
        public static String Default_save_path = "Saves";

        //Variables for all the logs types we want
        public static String[] Logs_Types = { "json", "XML" };


        //Variables to store Files paths
        public static String Source_Path = "";
        public static String Target_Path = "";

        public static void Initialize()
        {
            App_Path = ConfigurationManager.AppSettings["Default_path"];

            //Check if the app main directory exists
            if (Directory.Exists(App_Path) == false)
            {
                //If they doesn't exist, create all of them
                Directory.CreateDirectory(App_Path + "Easy_Save"); //Main directory
                Directory.CreateDirectory(App_Path + @"Easy_Save\" + Log_Daily_Path); //Log directory
                Directory.CreateDirectory(App_Path + @"Easy_Save\" + Log_Save_path); //Work_Log directory
                Directory.CreateDirectory(App_Path + @"Easy_Save\" + Default_save_path); //Default save directory, if a save path is not specified
            }
            else
            {
                //If the main directory exists, check if all directories exists, if they don't create them
                //Oterwise, do nothing
                if (Directory.Exists(App_Path + @"\Easy_Save\" + Log_Daily_Path) == false)
                {
                    Directory.CreateDirectory(App_Path + @"\Easy_Save\" + Log_Daily_Path);
                }
                if (Directory.Exists(App_Path + @"\Easy_Save\" + Log_Save_path) == false)
                {
                    Directory.CreateDirectory(App_Path + @"\Easy_Save\" + Log_Save_path);
                }
                if (Directory.Exists(App_Path + @"\Easy_Save\" + Default_save_path) == false)
                {
                    Directory.CreateDirectory(App_Path + @"\Easy_Save\" + Default_save_path);
                }
                else
                {

                }
            }
        }
    }
}
