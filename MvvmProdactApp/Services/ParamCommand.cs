using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MvvmProdactApp.Services
{
    class ParamCommand : ICommand
    {
        private readonly Action<object> _action;

        public ParamCommand(Action<object> action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged { add { } remove { } }
#pragma warning restore 67
    }
}

