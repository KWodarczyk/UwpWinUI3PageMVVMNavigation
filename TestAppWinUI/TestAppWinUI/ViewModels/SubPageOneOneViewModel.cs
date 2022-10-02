using System;
using System.Windows.Input;

namespace TestAppWinUI.ViewModels
{
    public class SubPageOneOneViewModel
    {
        public string VmText { get; private set; }
        public ICommand BackCommand => new RelayCommand(Back);

        private Action<object> _switch;
        public SubPageOneOneViewModel(Action<object> switchAction)
        {
            _switch = switchAction;
            VmText = "This is SubPage One One";
        }
        private async void Back()
        {
            _switch.Invoke(new PageOneViewModel(_switch));
        }
    }
}
