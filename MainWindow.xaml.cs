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

namespace Crypto
{
    public partial class MainWindow : Window
    {
        public MainViewModel mainViewModel;
        public MainWindow()
        {
            InitializeComponent();
            
            mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            GridCoins.ItemsSource = mainViewModel.MainItem.setCurrencyAndIcons;
            mainViewModel.Exchange = AdapterDataAPi.Get_all_exchangerate("BTC");
            dgBord1.ItemsSource = mainViewModel.Exchange.rates;
            mainViewModel.Url = AdapterDataAPi.Get_icon_list(32).Find(i => i.asset_id == "BTC").url;
            Switcher.pageSwitcher = this;
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
    }
}
