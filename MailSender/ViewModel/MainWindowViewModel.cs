using GalaSoft.MvvmLight;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _Title = "Рассыльщик почты";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        public MainWindowViewModel()
        {
          
        }
    }
}