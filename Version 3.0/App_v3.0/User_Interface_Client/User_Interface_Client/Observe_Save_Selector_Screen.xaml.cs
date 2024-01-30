using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
    /// MENU 2
    /// A METTRE
    /// Texte "Save ID :"
    /// Drop Down, pas besoin de trop se préoccuper du contenu (Virgile fera)
    /// Bouton "Valider"
    /// Bouton "Retour" (ferme la fenêtre)
    /// </summary>

    public partial class Observe_Save_Selector_Screen : Window
    {

        string save_To_Observe = "";
        
        public Observe_Save_Selector_Screen()
        {
            InitializeComponent();
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        { //Validate Button
            Progress_Screen progress_win = new Progress_Screen();
            progress_win.Owner = this;
            progress_win.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //Back Button
            this.Close();
        }

        private void saveID_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            save_To_Observe = saveID_ComboBox.SelectedValuePath;
        }
    }
}
