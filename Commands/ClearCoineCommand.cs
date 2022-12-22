using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto.Commands
{
    public class ClearCoineCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public MainViewModel ViewModel { get; set; }
        public ClearCoineCommand(MainViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ViewModel.Set = null; ;
        }
    }
}
