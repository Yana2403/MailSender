using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для SenderEditor.xaml
    /// </summary>
    public partial class AdresserEditor
    { 
        private MainWindow _MainWindow;

    public string NameValue { get => NameEditor.Text; set => NameEditor.Text = value; }
    public string AdressValue { get => AdressEditor.Text; set => AdressEditor.Text = value; }
    
        public AdresserEditor(Adresser Adresser, MainWindow MainWindow)
        {
            InitializeComponent();
            NameValue = Adresser.Name;
            AdressValue = Adresser.Address;
            _MainWindow = MainWindow;
        }


        private void OnOkButtonClick(object Adresser, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void OnCancelButtonClick(object Adresser, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void OnCloseMainWindowClick(object Adresser, RoutedEventArgs e)
         {
            // _MainWindow.Title += "Hello World!";
         }
    }
}
