using GalaSoft.MvvmLight;
using MailSender.lib.Entities;
using MailSender.lib.Services;
using System.Collections.ObjectModel;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly AdresseeManager _AdresseeManager;
        private string _Title = "���������� �����";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        private ObservableCollection<Adressee> _Adressees; //���������� ���������
        public ObservableCollection<Adressee> Adressees //��� ����������� ����������
        {
            get => _Adressees;
            private set => Set(ref _Adressees, value);

        }

        public MainWindowViewModel(AdresseeManager AdresseeManager)
        {
            _AdresseeManager = AdresseeManager;
            _Adressees = new ObservableCollection<Adressee>(_AdresseeManager.GetAll());
        }
    }
}