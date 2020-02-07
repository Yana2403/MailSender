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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
using System.Security;
using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Service;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
            //Addresser_ComboBox.ItemsSource = TestData.Adressers;
        }

        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
           //var addressee = AddresseeList.SelectedItem as Adressee;
           //var adresser = Addresser_ComboBox.SelectedItem as Adresser;
           //var server = ServersList_ComboBox.SelectedItem as Server;
           //
           //if (addressee is null || server is null || sender is null) return;
           //
           //var mail_sender = new lib.Services.DebugMailSender(server.Adress, server.Port, server.UseSSL, server.Login, server.Password.Decode(3));
           //
           //mail_sender.Send(MailHeader.Text, MailBody.Text, adresser.Address, addressee.Address);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void OnSenderEditClick(object Adresser, RoutedEventArgs E)
        {
            var adresser = Addresser_ComboBox.SelectedItem as Adresser;
            if (adresser is null) return;

            var dialog = new AdresserEditor(adresser, this);

            if (dialog.ShowDialog() != true) return;

            adresser.Name = dialog.NameValue;
            adresser.Address = dialog.AdressValue;
        }

        /*static void SendMessage(string Adressee, string messageHeader, string messageText, string Adresser, SecureString Password)
        {
            try
            {
                using (var  message = new MailMessage(Adresser, Adressee))
                {   message.Subject= messageHeader; 
                    message.Body = messageText; // текст сообщения
                    const string server_address = "smtp.yandex.ru";
                    const int server_port = 587;
                    using (SmtpClient client = new SmtpClient(server_address, server_port))
                    {
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential(Adresser, Password);
                        client.Send(message);//отправка сообщения пользователю
                        MessageBox.Show("Почта отправлена!", "Ура!!!",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
            } 
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendEndWindow sew = new SendEndWindow();
            sew.Owner = this;
            sew.ShowDialog();
              /*string Adressee = Addresser_ComboBox.Text; //Адресат
            string messageHeader = MailHeader.Text; //Тема письма
            string messageText = MailBody.Text; //Текст сообщения
            string Adresser = TextBox_Adresser.Text; //Адресант
              SecureString Password = PasswordEdit.SecurePassword;
              SendMessage(Adressee,messageHeader, messageText, Adresser, Password);
        }

        
        private void Contacts_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Улендеева Я.А.\nДля связи: ulendeeva.yana2013@yandex.ru");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Раздел в разработке.");
        }*/

    }
}
