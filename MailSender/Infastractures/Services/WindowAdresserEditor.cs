using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MailSender.Infastractures.Services.Interfaces;
using MailSender.lib.Entities;

namespace MailSender.Infastractures.Services
{
    class WindowAdresserEditor : IAdresserEditor
    {
        public void Edit (Adresser adresser)
        {
            var current_main_window = (MainWindow)Application.Current.MainWindow; //создаем окно внутри сервеса
            var editor = new AdresserEditor(adresser, current_main_window);
            editor.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            editor.Owner = current_main_window;

            if (editor.ShowDialog() != true) return; //если пользователь выбрал не кнопку ок то выходим, в противном случае возвращаем данные обратно
            adresser.Name = editor.Name;
            adresser.Address = editor.AdressValue;
        }
    }
}
