namespace TestAppWinUI.ViewModels
{
    public class MainViewModel
    {
        public DataContextSwitcher Switcher { get; set; }

        public PageOneViewModel PageOneVM { get; set; }

        public PageTwoViewModel PageTwoVM { get; set; }



        public MainViewModel()
        {
            Switcher = new DataContextSwitcher();
            PageOneVM = new PageOneViewModel(Switcher.SwitchVmContext);
            PageTwoVM  = new PageTwoViewModel();
        }
    }
}
