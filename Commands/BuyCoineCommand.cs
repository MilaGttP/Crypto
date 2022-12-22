using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto.Commands
{
    public class BuyCoineCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public MainViewModel ViewModel;
        public BuyCoineCommand(MainViewModel viewModel)
        {
            ViewModel = viewModel;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if ((ViewModel.Set[0].price * ViewModel.AmountCoine)> ViewModel.Wallet.Sum)
            {
                ViewModel.ErrorBuy = "Insufficient funds!";
                ViewModel.AmountCoine= 0;
            }
            else
            {
                SaveLoadfromDB.UpdateWallet(ViewModel.Wallet.Id, (ViewModel.Set[0].price * ViewModel.AmountCoine));
                ViewModel.Wallet= SaveLoadfromDB.GetAccountWallet(ViewModel.Account.Id); 
            }
        }
    }
}
