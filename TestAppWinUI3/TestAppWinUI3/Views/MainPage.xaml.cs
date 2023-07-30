// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TestAppWinUI3.Views
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
