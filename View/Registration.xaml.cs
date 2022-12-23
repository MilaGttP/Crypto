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
    public partial class Registration : UserControl
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Window.GetWindow(this).Close();
            main.ShowDialog();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            NameTB.Text = string.Empty;
            SurnameTB.Text = string.Empty;
            EmailTB.Text = string.Empty;
            PassTB.Password = string.Empty;
            RepassTB.Password = string.Empty;
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
                PassTB.BorderBrush = Brushes.Red;
                RepassTB.Clear();
                return;
            }
            else if (!OperationWithAccount.PassRePass(PassTB.Password, RepassTB.Password))
            {
                RepassTB.BorderBrush = Brushes.Red;
                PassTB.BorderBrush = Brushes.Red;
                RepassTB.Clear();
                PassTB.Clear();
                return;
            }
            else
            {
                OperationWithAccount.Registration(NameTB.Text, SurnameTB.Text, EmailTB.Text, PassTB.Password);
                Notecase notecase = new Notecase();
                Authentification.accounts = OperationWithAccount.SignIn(EmailTB.Text, ref notecase);
                Authentification.notecase = notecase;
                Window main = new MainWindow(Authentification.accounts);
                Window.GetWindow(this).Close();
                main.ShowDialog();
            }   
        }
    }
}
