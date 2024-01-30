using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client_interface
{
    /// <summary>
    /// /// MENU 3
    /// Texte "Save Name : "
    /// Texte "Status : "
    /// Texte "Source : "
    /// Texte "Destination : "
    /// Progress Bar
    /// Bouton "Retour"
    /// Bouton "Accueil"
    /// </summary>
    public partial class Progress_Screen : Window
    {

        private void ProgressBarHandling(int number_Of_Files_Done, int total_Number_Of_Files)
        {
            double Progress = (((double)number_Of_Files_Done / (double)total_Number_Of_Files) * 100);
            Application.Current.Dispatcher.Invoke(() =>
            {
                Window parentWindow = this;
                var yourInstanceOfWindow = (Progress_Screen)parentWindow;
                yourInstanceOfWindow.Save_Progress_Bar.Value = Progress;
                yourInstanceOfWindow.Progress_Percent_Label.Content = String.Format("{0:0.##}", Progress) + "%";
            });
            
        }

        public static int todo = 0;
        public static int done = 0;

        public Progress_Screen(String save_name)
        {
            InitializeComponent();
            Save_Name_Value_Label.Content = save_name;

            Source_Path_Label.Content = VueMain.GetSRC(save_name);
            Target_Path_Label.Content = VueMain.GetTRG(save_name);
            Progress_Percent_Label.Content = "0%";

            Thread t = new Thread(new ThreadStart(
                () => {
                    while (true)
                    {
                        String cmd = Client.ServerReceive(VueMain.client);
                        String[] cmdData = cmd.Split("#");
                        if(cmdData[0] == "To_Do")
                        {
                            Trace.WriteLine("To do client : " + cmdData[1]);
                            try
                            {
                                todo = int.Parse(cmdData[1]);
                            }
                            catch(System.FormatException e)
                            {

                            }
                        }
                        if(cmdData[0] == "Done")
                        {
                            try
                            {
                                done = int.Parse(cmdData[1]);
                                ProgressBarHandling(done, todo);
                            }
                            catch (System.FormatException e)
                            {

                            }
                            
                        }
                        else
                        {

                        }

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Window parentWindow = this;
                            var yourInstanceOfWindow = (Progress_Screen)parentWindow;
                            yourInstanceOfWindow.Progress_As_Number_Of_Files_Label.Content = done + "/" + todo;
                        });



                        
                    }
                }));
            t.Start();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            VueMain.Start_save(Save_Name_Value_Label.Content.ToString());
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            VueMain.Stop_save(Save_Name_Value_Label.Content.ToString());
        }
    }
}
