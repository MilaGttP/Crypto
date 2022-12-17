using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        private MainItems mainItems { get; set; }
        private SetCurrencyAndIcon setIconsCurrency { get; set; }
        private ExchangeCurrentrate exchangeCurrentrate { get; set; }

        public ExchangeCurrentrate Exchange
        {
            get
            {
                exchangeCurrentrate = AdapterDataAPi.Get_all_exchangerate(setIconsCurrency.name.ToString());
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
        public ICommand UpDateViewCommand { get; set; }
        public MainViewModel()
        {
            mainItems = new MainItems();
            UpDateViewCommand = new UpDateViewCommand(this);
            
        }
    }
}
