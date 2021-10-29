using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestAppUWP.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestAppUWP.Views
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
