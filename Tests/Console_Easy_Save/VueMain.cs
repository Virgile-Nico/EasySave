using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Easy_Save
{
    class VueMain
    {
        public static void Initialization()
        {
            //Initalisation for multiple component of the software
            Paths.Initialize(); //file component (taking care of Logs files + software files)
            Work_Logger.Initialize();
            Save_preparer.Initialize();
        }

        public static int Prepare_save(String source, String target, String type)
        {
            int Nbr = Save_preparer.Save_Prearer(source, target, type);
            return Nbr;
        }

        //function to do a full save
        public static String Full_Save(String Source, String Target)
        {
            return "not done yet";
        }

        //function to do a differential save
        public static String Differential_Save()
        {
            return "not done yet";
        }
    }
}
