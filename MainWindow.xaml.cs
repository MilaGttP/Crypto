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
        public MainWindow()
        {
            InitializeComponent();

            Coins coin = new Coins();

            coin.coinId = "";
            coin.coinIcon = "";
            coin.coinNameC = "";
            coin.coinPriceC = "";

            GridCoins.Items.Add(coin);

            Coins coin1 = new Coins();

            coin1.coinId = "";
            coin1.coinIcon = "";
            coin1.coinNameC = "";
            coin1.coinPriceC = "";

            GridCoins.Items.Add(coin1);

            TradeHistory trHis = new TradeHistory();

            trHis.trHisName = "";
            trHis.trHisType = "";
            trHis.trHisPrice = "";
            trHis.trHisAmount = "";
            trHis.trHisDoll = "";

            //GridTradeHistory.Items.Add(trHis);

            //TradeHistory trHis1 = new TradeHistory();

            //trHis1.trHisName = "";
            //trHis1.trHisType = "";
            //trHis1.trHisPrice = "";
            //trHis1.trHisAmount = "";
            //trHis1.trHisDoll = "";

            //GridTradeHistory.Items.Add(trHis1);
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

        public class Coins
        {
            public string coinId { get; set; }
            public string coinIcon { get; set; }
            public string coinNameC { get; set; }
            public string coinPriceC { get; set; }
        }

        public class TradeHistory
        {
            public string trHisName { get; set; }
            public string trHisType { get; set; }
            public string trHisPrice { get; set; }
            public string trHisAmount { get; set; }
            public string trHisDoll { get; set; }
        }
    }
}
