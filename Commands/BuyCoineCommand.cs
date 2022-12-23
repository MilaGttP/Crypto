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
            if (ViewModel.AmountCoine != 0)
            {
                decimal? Sum = ViewModel.Set[0].price * ViewModel.AmountCoine;
                if (Sum > ViewModel.Wallet.Sum)
                {
                    ViewModel.ErrorBuy = "Insufficient funds!";
                    ViewModel.AmountCoine = 0;
                }
                else
                {
                    ViewModel.MainItem.OperationWithNotecase.MakePurchaseCoine(Sum, ViewModel.Wallet, ViewModel.Set[0].name);
                    ViewModel.Wallet = SaveLoadfromDB.GetAccountWallet(ViewModel.Account.Id);
                    ViewModel.Set.Clear();
                    ViewModel.Set=null ;
                }
            }
        }
    }
}
