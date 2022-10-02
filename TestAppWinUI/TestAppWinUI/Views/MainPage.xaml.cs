using Microsoft.UI.Xaml.Controls;
using TestAppWinUI.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestAppWinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainViewModel _mainViewModel;

        public DataContextSwitcher Switcher => _mainViewModel.Switcher;
  
        public MainPage()
        {
            _mainViewModel = new MainViewModel();
            Switcher.SwitchVmContext(_mainViewModel.PageOneVM);
            this.InitializeComponent();
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem navigationViewItem = (NavigationViewItem)args.InvokedItemContainer;

            if (navigationViewItem == PageOneItem)
            {
                Switcher.SwitchVmContext(_mainViewModel.PageOneVM);
            }
            else if (navigationViewItem == PageTwoItem)
            {
                Switcher.SwitchVmContext(_mainViewModel.PageTwoVM);
            }
           
        }
    }
}
