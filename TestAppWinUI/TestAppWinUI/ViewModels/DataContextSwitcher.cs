namespace TestAppWinUI.ViewModels
{
    public class DataContextSwitcher : NotifyPropertyChanged
    {
        private object _context;

        public object VmContext
        {
            get => _context;
            set
            {
                if (_context != value)
                {
                    _context = value;
                    OnPropertyChanged();
                }
            }
        }

        public void SwitchVmContext(object newContext)
        {
            VmContext = newContext;
        }
    }
}
