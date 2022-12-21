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
using static Azure.Core.HttpHeader;

namespace Crypto
{
    public partial class Sign : UserControl
    {
        public Sign()
        {
            InitializeComponent();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Window main = new MainWindow();
            Window.GetWindow(this).Close();
            main.ShowDialog();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            EmailTB.Text = string.Empty;
            PassTB.Password = string.Empty;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!OperationWithAccount.EmailRegex(EmailTB.Text))
            {
                EmailTB.Text = "Incorrect email!";
                return;
            }
            else if (!OperationWithAccount.PasswordRegex(PassTB.Password))
            {
                PassTB.Password = "Incorrect password!";
                return;
            }
            else
            {
                Notecase notecase = new Notecase();
                Accounts account = new Accounts();
                account = OperationWithAccount.SignIn(EmailTB.Text, ref notecase);
                Window main = new MainWindow(account);
                Window.GetWindow(this).Close();
                main.ShowDialog();
            }
        }
    }
}
