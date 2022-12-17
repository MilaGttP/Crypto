using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto
{
    public class ClickIconMaineCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private MainViewModel viewModel;
        public ClickIconMaineCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            
        }
    }
}
