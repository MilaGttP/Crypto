using System;
using System.Windows.Input;

namespace Crypto.Commands
{
    public class GetHistoryWalletCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public MainViewModel viewModel { get; set; }
        public GetHistoryWalletCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public void Execute(object? parameter)
        {
            if (Authentification.accounts.Id != null) {
                viewModel.HistoryAccounts = SaveLoadfromDB.GetAccountHistory(Authentification.accounts.Id);
            }
        }
    }
}
