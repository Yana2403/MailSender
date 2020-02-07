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
    /// Логика взаимодействия для SendEndWindow.xaml
    /// </summary>
    public partial class SendEndWindow : Window
    {
        public SendEndWindow()
        {
            InitializeComponent();
        }
         
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*string Adressee = TextBox_Adresee.Text; //Адресат
            string messageText = TextBox_Message.Text; //Текст сообщения
            string Adresser = TextBox_Adresser.Text; //Адресант
            SecureString Password = PasswordEdit.SecurePassword;
            SendMessage(Adressee, messageText, Adresser, Password);*/
        }
    }
}
