using System;
using System.Windows.Input;

namespace TestAppWinUI.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute ?? (o => true);
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
            : this(o => execute(), o => canExecute?.Invoke() ?? true)
        {
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
     
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
