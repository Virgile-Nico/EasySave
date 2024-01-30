using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using EasySave_Core;
using EasySave_Core.Resources;
using EasySave_Core.ViewModel;
using EasySave_Core.Service;

namespace EasySave_Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logger.initLog();
            BuildHeader();
            ViewSave viewSave = new ViewSave();
            string language = String.Empty;
            Text.Culture = new CultureInfo(CultureInfo.CurrentCulture.Name.Split('-')[0]);
            while (!(language == "FR" || language == "EN"))
            {
                Console.WriteLine(Text.ChooseLanguage);
                language = Console.ReadLine();
            }
            
            Text.Culture = new CultureInfo(language.ToLower());
            Console.WriteLine(Text.Title);
            if(viewSave.saves.Count > 0)
            {
                Console.WriteLine(Text.List);
                DisplaySaves(viewSave.getNames());
            }
            string actionId = "0";
            while(actionId != "5")
            {
                Console.WriteLine(Text.MenuCompleteSave);
                Console.WriteLine(Text.MenuDiffSave);
                Console.WriteLine(Text.MenuStartSpecificSave);
                Console.WriteLine(Text.MenuStartAllSaves);
                Console.WriteLine(Text.MenuQuitApplication);
                actionId = Console.ReadLine();
                
                switch (actionId)
                {
                    case "1" :
                    case "2" :
                        Console.WriteLine(Text.SaveStartSave);
                        Console.WriteLine(Text.SaveEnterName);
                        string name = Console.ReadLine();
                        Console.WriteLine(Text.SaveSourcePath);
                        string source = Console.ReadLine();
                        Console.WriteLine(Text.SaveDestPath);
                        string destination = Console.ReadLine();
                        viewSave.CreateSave(name, PathAuditor.CheckPath(source), PathAuditor.CheckPath(destination), actionId);
                        break;
                    case "3":
                        Console.WriteLine(Text.List);
                        List<string> listNames = viewSave.getNames();
                        DisplaySaves(listNames);
                        Console.WriteLine(Text.SaveLoadSpecific);
                        string nameSelectedSave = Console.ReadLine();
                        if (listNames.Contains(nameSelectedSave))
                        {
                            Console.WriteLine(Text.SaveStartingSpecificSave);
                            viewSave.StartSave(nameSelectedSave);
                            Console.WriteLine(Text.SaveFinishedSpecificSave);
                        }
                        else
                        {
                            Console.WriteLine(Text.SaveNameNotValid);
                        }
                        break;
                    case "4" :
                        Console.WriteLine(Text.SaveStartingAllSaves);
                        viewSave.StartAllSaves();
                        Console.WriteLine(Text.SaveStartingAllSaves);
                        break;
                    case "5" :
                        Console.WriteLine(Text.SaveClosingApp);
                        Environment.Exit(0);
                        break;
                    default :
                        Console.WriteLine(Text.SaveWrongCharacter);
                        break;
                }
                
            }
           

        }

        public static void BuildHeader()
        {
            Console.WriteLine(@"
  ______                 _____                 
 |  ____|               / ____|                
 | |__   __ _ ___ _   _| (___   __ ___   _____ 
 |  __| / _` / __| | | |\___ \ / _` \ \ / / _ \
 | |___| (_| \__ \ |_| |____) | (_| |\ V /  __/
 |______\__,_|___/\__, |_____/ \__,_| \_/ \___|
                   __/ |                       
                  |___/                        
");
        }

        public static void DisplaySaves(List<string> listNames)
        {
            int i = 0;
            foreach (string nameSave in listNames)
            {
                Console.WriteLine("{0} -> " + nameSave, i++);
            }
        }
        

        public static string ProgressBar(int progress)
        {
            // Convertit le progress en texte, et on fixe la longueur à 3 caractères avec un petit PadLeft 
            string textual = progress.ToString().PadLeft(3, ' ');
            // Réutilisation de la même string pour afficher un texte représentant le progrès
            textual = "Progress " + textual + "% ";
            // Calcul de la taille disponible pour la progressbar
            // Console.WindowWidth retourne le nombre de colonnes de la console.
            // Il faut retrancher 1 car sinon le texte fait exactement la largeur de la console, 
            // ce qui entraînerait de facto un retour à la ligne (et ce serait moche, et l'effet 
            // progressbar disparaîtrait...)
            int barsize = Console.WindowWidth - 2 - textual.Length;
            // Initialisation d'un string builder d'une capacité égale à la taille de la progressbar
            StringBuilder p = new StringBuilder(barsize);
            // Une petit règle de trois pour caler le progrès sur la taille de la progressbar
            progress = progress * barsize / 100;

            // Et la fonction retourne une string avec des padding sur la gauche pour afficher le progress
            // et un padding sur la droite pour donner une arrière plan à la progressbar
            return textual + "[" + p.ToString().PadLeft(progress, (char)37).PadRight(barsize, (char)126) + "]";
        }
    }
}
