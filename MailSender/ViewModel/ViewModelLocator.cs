using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.Infastractures.Services;
using MailSender.Infastractures.Services.Interfaces;
using MailSender.lib.Data.EF;
using MailSender.lib.Services;
using MailSender.lib.Services.EF;
using MailSender.lib.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MailSender.ViewModel
{
    public class ViewModelLocator
    {
        public  ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var services = SimpleIoc.Default;
            services.Register<MainWindowViewModel>();//регистрация класса
            services.Register<IAdresseeManager, AdresseeManager>();
            // services.Register<IAdresseesStore,AdresseeStoreinMemory>();
            services.Register<IAdresseesStore, AdresseeStoreEF>();
            services.Register<IAdressersStore, AdressersStoreinMemory>();
            services.Register<IServerStore, ServersStoreinMemory>();
            services.Register<IMailsStore, MailsStoreinMemory>();
            services.Register<MailSenderDB>();

            services.Register(() => new DbContextOptionsBuilder<MailSenderDB>()
               .UseSqlServer(App.Configuration.GetConnectionString("DefaultConnection")).Options);

            services.Register<IAdresserEditor, WindowAdresserEditor>();
            
        }

        public MainWindowViewModel MainWindowModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}