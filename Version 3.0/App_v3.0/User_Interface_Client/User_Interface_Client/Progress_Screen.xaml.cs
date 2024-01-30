using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace User_Interface_Client
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
            int percentage = (number_Of_Files_Done/total_Number_Of_Files)*100;
            Save_Progress_Bar.Value = percentage;
            Progress_Percent_Label.Content = percentage + "%";
        }
        
        
        public Progress_Screen()
        {
            InitializeComponent();
        }

        private void Main_Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //Parent.Close(); //Doesn't work, couldn't find alternative
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Progress_Bar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
