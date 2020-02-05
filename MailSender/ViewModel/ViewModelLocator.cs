using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
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
            services.Register<AdresseeManager>();
            services.Register<AdresseeStoreinMemory>();
            services.Register<MainWindowViewModel>();//регистрация класса
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