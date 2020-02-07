using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Entities;
using MailSender.lib.Services;
using MailSender.lib.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IAdresseeManager _AdresseeManager;
        private string _Title = "Рассыльщик почты";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        private ObservableCollection<Adressee> _Adressees; //определяем коллекцию
        public ObservableCollection<Adressee> Adressees //для возможности обновления
        {
            get => _Adressees;
            private set => Set(ref _Adressees, value);

        }
        private Adressee _SelectedAdressee;
        public Adressee SelectedAdressee
        {
            get => _SelectedAdressee;
            set => Set(ref _SelectedAdressee, value);
        }
        #region Команды
        public ICommand LoadAdresseesDataCommand { get; }
        public ICommand SaveAdresseesChangesCommand { get; }
        #endregion
        public MainWindowViewModel(IAdresseeManager AdresseeManager)
        {
            LoadAdresseesDataCommand = new RelayCommand(OnLoadAdresseesDataCommandExecuted, CanLoadAdresseesDataCommandExecute) ;
            SaveAdresseesChangesCommand = new RelayCommand<Adressee>(OnSaveAdresseeChangesCommandExecute, CanSaveAdresseeChangesCommandExecute);
            _AdresseeManager = AdresseeManager;
            _Adressees = new ObservableCollection<Adressee>(_AdresseeManager.GetAll());
        }
        private bool CanLoadAdresseesDataCommandExecute() => true;
        private void OnLoadAdresseesDataCommandExecuted()
        {
            Adressees = new ObservableCollection<Adressee>(_AdresseeManager.GetAll());
        }
        private bool CanSaveAdresseeChangesCommandExecute(Adressee adressee)
        {
            System.Diagnostics.Debug.WriteLine("Проверка состояния команды" + adressee?.Name);
            return adressee != null;
        }
        private void OnSaveAdresseeChangesCommandExecute(Adressee adressee)
        {
            _AdresseeManager.Edit(adressee);
            _AdresseeManager.SaveChanges();
        }
    }
}