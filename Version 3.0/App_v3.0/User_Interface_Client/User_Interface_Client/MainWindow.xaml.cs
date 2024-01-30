using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace User_Interface_Client
{
    /// <summary>
    /// MENU 1
    /// A METTRE :
    /// Un texte "IP Server : "
    /// Une boîte d'input (ComboBox) où l'utilisateur va taper l'IP
    /// Bouton "Valider"
    /// <summary>
    public partial class MainWindow : Window
    {
        string UserIPEntry = "";
        public MainWindow()
        {
            InitializeComponent();
            
        }

        

        public void Button_Click(object sender, RoutedEventArgs e)
        { //Validate Button
            Observe_Save_Selector_Screen observe_select_win = new Observe_Save_Selector_Screen();
            observe_select_win.Owner = this;
            observe_select_win.Show();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserIPEntry = IPTextBox.Text;

        }
    }
}
