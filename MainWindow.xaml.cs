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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainItems mainItems { get; set; }
        public Currency currency { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            currency = new Currency();
            mainItems = new MainItems();
            ConContol.Content = currency;
            GridCoins.ItemsSource = mainItems.currencies;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ClickDetals(object sender, MouseButtonEventArgs e)
        {
            NavigationWindow win = new NavigationWindow();
            win.Content = new Page();
            win.Show();
            this.Close();
        }
    }
}
