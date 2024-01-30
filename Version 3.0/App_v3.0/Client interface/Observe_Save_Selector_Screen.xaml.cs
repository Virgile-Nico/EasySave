using System;
using System.Collections.Generic;
using System.Text;
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
    /// MENU 2
    /// A METTRE
    /// Texte "Save ID :"
    /// Drop Down, pas besoin de trop se préoccuper du contenu (Virgile fera)
    /// Bouton "Valider"
    /// Bouton "Retour" (ferme la fenêtre)
    /// </summary>

    public partial class Observe_Save_Selector_Screen : Window
    {

        String[] files = new string[0];
        String save_To_Observe = "";

        public Observe_Save_Selector_Screen(int nbr_saves)
        {
            InitializeComponent();

            Array.Resize(ref files, nbr_saves);
            for (int i = 0; i < nbr_saves; i++)
            {
                files[i] = "Save#" + i;
            }

            saveID_ComboBox.ItemsSource = files;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        { //Validate Button
            Progress_Screen progress_win = new Progress_Screen(save_To_Observe);
            progress_win.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //Back Button

            this.Close();
        }

        private void saveID_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            save_To_Observe = saveID_ComboBox.SelectedItem.ToString();
        }
    }
}
