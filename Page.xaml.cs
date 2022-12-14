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
using static Crypto.MainWindow;
using static Crypto.Page;

namespace Crypto
{
    /// <summary>
    /// Логика взаимодействия для Page.xaml
    /// </summary>
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();

            History hist = new History();

            hist.histData = "";
            hist.histName = "";
            hist.histType = "";
            hist.histPrice = "";
            hist.histAmount = "";
            hist.histProfit = "";

            GridHistory.Items.Add(hist);

            History hist1 = new History();

            hist1.histData = "";
            hist1.histName = "";
            hist1.histType = "";
            hist1.histPrice = "";
            hist1.histAmount = "";
            hist1.histProfit = "";

            GridHistory.Items.Add(hist1);
        }

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            
        }

        public class History
        {
            public string histData { get; set; }
            public string histName { get; set; }
            public string histType { get; set; }
            public string histPrice { get; set; }
            public string histAmount { get; set; }
            public string histProfit { get; set; }
        }
    }
}
