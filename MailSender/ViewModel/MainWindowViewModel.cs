using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.Infastractures.Services.Interfaces;
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
        private readonly IAdressersStore _AdressersStore;
        private readonly IMailsStore _MailsStore;
        private readonly IServerStore _ServerStore;
        private readonly IAdresserEditor _AdresserEditor;


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
        private ObservableCollection<Adresser> _Adressers; //определяем коллекцию
        public ObservableCollection<Adresser> Adressers //для возможности обновления
        {
            get => _Adressers;
            private set => Set(ref _Adressers, value);

        }
        private ObservableCollection<Server> _Servers; //определяем коллекцию
        public ObservableCollection<Server> Servers //для возможности обновления
        {
            get => _Servers;
            private set => Set(ref _Servers, value);

        }
        private ObservableCollection<Mail> _Mails; //определяем коллекцию
        public ObservableCollection<Mail> Mails //для возможности обновления
        {
            get => _Mails;
            private set => Set(ref _Mails, value);

        }

        private Adressee _SelectedAdressee;
        public Adressee SelectedAdressee
        {
            get => _SelectedAdressee;
            set => Set(ref _SelectedAdressee, value);
        }
        private Adresser _SelectedAdresser;
        public Adresser SelectedAdresser
        {
            get => _SelectedAdresser;
            set => Set(ref _SelectedAdresser, value);
        }
        private Mail _SelectedMail;
        public Mail SelectedMail
        {
            get => _SelectedMail;
            set => Set(ref _SelectedMail, value); 
        }

        private Server _SelectedServer;
        public Server SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }
        #region Команды
        public ICommand LoadAdresseesDataCommand { get; }
        public ICommand SaveAdresseesChangesCommand { get; }

        public ICommand AdresserEditCommand { get; }

        #endregion
        public MainWindowViewModel(IAdresseeManager AdresseeManager, 
            IAdressersStore AdressersStore,
            IMailsStore MailsStore, 
            IServerStore ServerStore,
            IAdresserEditor AdresserEditor)
        {
            LoadAdresseesDataCommand = new RelayCommand(OnLoadAdresseesDataCommandExecuted, CanLoadAdresseesDataCommandExecute) ;
            SaveAdresseesChangesCommand = new RelayCommand<Adressee>(OnSaveAdresseeChangesCommandExecute, CanSaveAdresseeChangesCommandExecute);
            AdresserEditCommand = new RelayCommand<Adresser>(OnAdresserEditCommandExecuted, CanAdresserEditCommandExecute);
            _AdresseeManager = AdresseeManager;
           // _Adressees = new ObservableCollection<Adressee>(_AdresseeManager.GetAll());

            _AdressersStore = AdressersStore;
            _ServerStore = ServerStore;
            _MailsStore = MailsStore;
            _AdresserEditor = AdresserEditor;
        }
        private bool CanAdresserEditCommandExecute(Adresser adresser) => adresser != null;
        private void OnAdresserEditCommandExecuted(Adresser adresser)
        {
            _AdresserEditor.Edit(adresser);
        }

        private bool CanLoadAdresseesDataCommandExecute() => true;
        private void OnLoadAdresseesDataCommandExecuted()
        {
            Adressees = new ObservableCollection<Adressee>(_AdresseeManager.GetAll());
            Adressers = new ObservableCollection<Adresser>(_AdressersStore.GetAll());
            Servers = new ObservableCollection<Server>(_ServerStore.GetAll());
            Mails = new ObservableCollection<Mail>(_MailsStore.GetAll());
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