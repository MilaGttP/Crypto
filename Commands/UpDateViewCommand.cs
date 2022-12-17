using Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Crypto
{
    public class UpDateViewCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private MainViewModel viewModel ;
        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public UpDateViewCommand(MainViewModel viewModel) { 
        
            this.viewModel = viewModel;
        }

        public void Execute(object? parameter)
        {
            if (parameter.ToString() == "SignIn")
            {
                
            }
            else if (parameter.ToString() == "Registration")
            {
                
            }
            else if (parameter.ToString() == "Account")
            {
                
            }
        }
    }
}
