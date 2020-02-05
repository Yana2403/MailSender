using GalaSoft.MvvmLight;
using MailSender.lib.Services;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly AdresseeManager _AdresseeManager;
        private string _Title = "Рассыльщик почты";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        public MainWindowViewModel(AdresseeManager AdresseeManager)
        {
            _AdresseeManager = AdresseeManager;
        }
    }
}