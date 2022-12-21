﻿using System;
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
        public Accounts Accounts
        {
            get { return accounts; }
            set
            {
                accounts = value;
                OnPropertyChanged(nameof(Url));
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
        public ICommand UpDateViewCommand { get; set; }
        public ICommand SelectedCurrencyCommand { get; set; }
        public MainViewModel()
        {
            mainItems = new MainItems();
            UpDateViewCommand = new UpDateViewCommand(this);
            SelectedCurrencyCommand = new ClickIconMainCommand(this);
        }
    }
}
