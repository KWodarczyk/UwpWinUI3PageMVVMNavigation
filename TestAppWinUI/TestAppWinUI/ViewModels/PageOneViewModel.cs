using System;
using System.Windows.Input;

namespace TestAppWinUI.ViewModels
{
    public class PageOneViewModel
    {
        public string VmText { get; private set; }

        public ICommand GoToSubPageOneOneCommand => new RelayCommand(GotoSubPageOneOne);

        private Action<object> _switch;
        public PageOneViewModel(Action<object> switchAction)
        {
            _switch = switchAction;
            VmText = "This is Page One";
        }

        private async void GotoSubPageOneOne()
        {
            _switch.Invoke(new SubPageOneOneViewModel(_switch));
        }
    }
}
