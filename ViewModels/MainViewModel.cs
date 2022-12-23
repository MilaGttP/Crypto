using Crypto.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Crypto
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel { get; set; }
        private MainItems mainItems { get; set; }
        private SetCurrencyAndIcon setIconsCurrency { get; set; }
        private ExchangeCurrentrate exchangeCurrentrate { get; set; }
        private Accounts accounts { get; set; }
        private Notecase notecase { get; set; }
        private List<SetCurrencyAndIcon> set { get; set; }
        private int amountCoine { get; set; }
        private string errorBuy { get; set; }
        private Currency currency_selected { get; set; }
        private List<HistoryAccount> historyAccounts { get; set; }
        public List<HistoryAccount> HistoryAccounts
        {
            get
            {
                return historyAccounts;
            }
            set
            {
                historyAccounts = value;
                OnPropertyChanged(nameof(HistoryAccounts));
            }
        }

        public Currency Currency_Selected
        {
            get
            {
                return currency_selected;
            }
            set
            {
                currency_selected = value;
                OnPropertyChanged(nameof(Currency_Selected));
            }
        }
        public string ErrorBuy { 
            get { return errorBuy; }
            set
            {
                errorBuy = value;
                OnPropertyChanged(nameof(ErrorBuy));
            }
        }

        public int AmountCoine { 
            get { 
                return amountCoine;
                }
            set
            {
                this.amountCoine = value;
                OnPropertyChanged(nameof(AmountCoine));
            }
            }
        public List<SetCurrencyAndIcon> Set { get
            {
                return set;
            }
            set
            {
                set= value;
                OnPropertyChanged(nameof (Set));
            }
            }
        public Notecase Wallet { 
            get { return notecase; }
            set
            {
                notecase = value;
                OnPropertyChanged(nameof(Wallet));
            }
        }
        public Accounts Account
        {
            get { return accounts; }
            set
            {
                accounts = value;
                OnPropertyChanged(nameof(Account));
            }
        }
        private string url { get; set; }
        public string Url
        {
            get { return url; }
            set
            {
                url = value;
                OnPropertyChanged(nameof(Url));
            }
        }
        public ExchangeCurrentrate Exchange
        {
            get
            {
               return exchangeCurrentrate;
            }
            set
            {
                exchangeCurrentrate = value;
                OnPropertyChanged(nameof(Exchange));
            }
        }
        public SetCurrencyAndIcon SetIconsCurrencies
        {
            get
            {
                return setIconsCurrency;
            }
            set
            {
                setIconsCurrency = value;
                OnPropertyChanged(nameof(SetIconsCurrencies));
            }
        }
        public MainItems MainItem
        {
            get { return mainItems; }
            set { mainItems = value;
                OnPropertyChanged(nameof(MainItem));
            }
        }
        public ICommand CloseCommand { get; set; }
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public ICommand SelectedCurrencyCommand { get; set; }
        public ICommand AddCoine { get; set; }
        public ICommand BuyCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand GetHistroryCommand { get; set; }
        public MainViewModel()
        {
            set = new List<SetCurrencyAndIcon>();
            mainItems = new MainItems();
            SelectedCurrencyCommand = new ClickIconMainCommand(this);
            AddCoine = new AddCoinCommand(this);
            BuyCommand= new BuyCoineCommand(this);
            ClearCommand= new ClearCoineCommand(this);
            GetHistroryCommand = new GetHistoryWalletCommand(this);
        }
    }
}
