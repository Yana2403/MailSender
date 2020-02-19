using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.Infastractures.Services;
using MailSender.Infastractures.Services.Interfaces;
using MailSender.lib.Services;
using MailSender.lib.Services.Interfaces;

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
            services.Register<IAdresseesStore,AdresseeStoreinMemory>();
            services.Register<IAdressersStore, AdressersStoreinMemory>();
            services.Register<IServerStore, ServersStoreinMemory>();
            services.Register<IMailsStore, MailsStoreinMemory>();

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