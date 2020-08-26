using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Shared_Themes.ViewModels;

namespace UwpSharedThemeTest
{
    public sealed partial class MainPage : Page
    {
        public ThemeColor MyTheme { get; set; } = new ThemeColor();

        public MainPage()
        {
            ThemeController.RefreshTheme(MyTheme);
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            // ;
        }

        private void ShowThemeDialog_OnClick(object sender, RoutedEventArgs e)
        {
            ThemeController.ShowThemeDialog(MyTheme);
        }
    }
}
