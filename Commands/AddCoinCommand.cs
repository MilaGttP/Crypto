using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto.Commands
{
    public class AddCoinCommand : ICommand
    {
        public MainViewModel viewModel { get; set; }
        public AddCoinCommand(MainViewModel mainItems)
        {
            this.viewModel = mainItems;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            List<SetCurrencyAndIcon> setCurrencyAndIconList = new List<SetCurrencyAndIcon>();
            setCurrencyAndIconList.Add(viewModel.SetIconsCurrencies);
            viewModel.Set = setCurrencyAndIconList;
        }
    }
}
