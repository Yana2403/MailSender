﻿using System;
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

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        static void SendMessage(string Adressee, string messageText, string Adresser, SecureString Password)
        {
            try
            {
                using (var  message = new MailMessage(Adresser, Adressee))
                {   ///message.Subject= тема 
                    message.Body = messageText; // текст сообщения
                    const string server_address = "smtp.yandex.ru";
                    const int server_port = 25;
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
            string Adressee = TextBox_Adresee.Text; //Адресат
            string messageText = TextBox_Message.Text; //Текст сообщения
            string Adresser = TextBox_Adresser.Text; //Адресант
            SecureString Password = PasswordEdit.SecurePassword;
            SendMessage(Adressee, messageText, Adresser, Password);
        }
    }
}
