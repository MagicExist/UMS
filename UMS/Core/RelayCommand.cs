using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UMS.Core
{
    internal class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Predicate<object>? _canExecute;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<object> execute,Predicate<object>? canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
            _canExecute = null;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
