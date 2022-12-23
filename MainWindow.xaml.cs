using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Crypto.Page;

namespace Crypto
{
    public partial class MainWindow : Window
    {
        private MainViewModel? mainViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            CoinsDG.ItemsSource = mainViewModel.MainItem.setCurrencyAndIcons;
            mainViewModel.Exchange = AdapterDataAPi.Get_all_exchangerate("BTC");
            mainViewModel.Currency_Selected = mainViewModel.MainItem.currencies.Find(s => s.asset_id == "BTC");
            RatesDG.ItemsSource = mainViewModel.Exchange.rates;
            WalletDG.ItemsSource = mainViewModel.Set;
            mainViewModel.Url = AdapterDataAPi.Get_icon_list(32).Find(i => i.asset_id == "BTC").url;
            Switcher.pageSwitcher = this;
        }
        public MainWindow(Accounts account)
        {
            InitializeComponent();

            mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            CoinsDG.ItemsSource = mainViewModel.MainItem.setCurrencyAndIcons;
            mainViewModel.Exchange = AdapterDataAPi.Get_all_exchangerate("BTC");
            mainViewModel.Currency_Selected = mainViewModel.MainItem.currencies.Find(s => s.asset_id == "BTC");
            RatesDG.ItemsSource = mainViewModel.Exchange.rates;
            //WalletDG.ItemsSource = mainViewModel.Set;
            mainViewModel.Url = AdapterDataAPi.Get_icon_list(32).Find(i => i.asset_id == "BTC").url;
            mainViewModel.Wallet = Authentification.notecase;
            Switcher.pageSwitcher = this;

            HelloTB.Text = "Hello, Dear";
            BalanceL.Visibility = Visibility.Visible;
            AmountL.Visibility = Visibility.Visible;
            AmountCoineTB.Visibility = Visibility.Visible;
            ClearBtn.Visibility = Visibility.Visible;
            AddBtn.Visibility = Visibility.Visible;
            BuyBtn.Visibility = Visibility.Visible;
            HistoryBtn.Visibility = Visibility.Visible;
            ForBuyL.Visibility = Visibility.Hidden;
            AmountL.Visibility = Visibility.Visible;
            WalletL.Visibility = Visibility.Visible;
            BalanceL.Visibility = Visibility.Visible;
            HistoryL.Visibility = Visibility.Visible;
            ErrTB.Visibility = Visibility.Visible;   

            mainViewModel.Account = Authentification.accounts;
        }

        public void Navigate(UserControl nextPage) => this.Content = nextPage;
        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;
            if (s != null) s.UtilizeState(state);
            else throw new ArgumentException("NextPage is not ISwitchable! " + nextPage.Name.ToString());
        }

        private void SignBtn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Sign());
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Registration());
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filtered = mainViewModel.MainItem.setCurrencyAndIcon.
                FilterCurrencyList(mainViewModel.MainItem.currencies, mainViewModel.MainItem.icons, SearchTB.Text);
            CoinsDG.ItemsSource = filtered;
        }
    }
}