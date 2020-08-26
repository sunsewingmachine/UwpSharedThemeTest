using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Media.SpeechSynthesis;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Shared_Themes.Common;
using Shared_Themes.Views;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Shared_Themes.ViewModels
{
    public class ThemeController
    {
        //internal static ImageSource BitmapImage;

        //public static async Task SetOldImage(UIElement OldUiElement)
        //{
        //    //var OldUiElement = ThemeController.OldUiElement;
        //    if (OldUiElement == null) return;

        //    var kk = new GetImage();
        //    await kk.CaptureWindow4(OldUiElement);
        //    var saveFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("old.png", CreationCollisionOption.OpenIfExists);
        //    if (saveFile == null) return;

        //    var bitmapImage = new BitmapImage();
        //    var uri = new Uri(saveFile.Path);
        //    bitmapImage.UriSource = uri;
        //    BitmapImage = bitmapImage;
        //}
        
        public static void RefreshTheme(ThemeColor themeViewModel)
        {
            var jsonString = JsonSerializer.Serialize(new ThemeColor());
            jsonString = Reg.GetSetting(ThemeRegKeys.SavedTheme, jsonString);
            var savedTheme = JsonSerializer.Deserialize<ThemeColor>(jsonString);

            themeViewModel.Color1 = savedTheme.Color1;
            themeViewModel.Color2 = savedTheme.Color2;
            themeViewModel.RequestedTheme = savedTheme.RequestedThemeString == "Light" ? ElementTheme.Light : ElementTheme.Dark;

            if (savedTheme.ImageOpacity < 0 || savedTheme.ImageOpacity > 1) savedTheme.ImageOpacity = 0.5;
            themeViewModel.ImageOpacity = savedTheme.ImageOpacity;

            var AvatarPath = @"ms-appx:///Shared_Themes/Images/Backs/";
            var imageName = savedTheme.BackImage; //"1.png";
            var imagePath = AvatarPath + imageName;
            themeViewModel.BackImage = imagePath;
        }

        private static ThemeColor MyTheme { get; set; }

        public static void ShowThemeDialog(ThemeColor themeViewModel, MyThemeChangedEvent themeChangedEvent = null)
        {
            var rootFrame = Window.Current.Content as Frame;
            var page = rootFrame?.Content as Page;
            var root = page?.Content as Grid;
            if (root == null) return;

            var themeDialog = new ThemeDialog();
            root?.Children.Add(themeDialog);
            themeDialog.StartAnimationFloating(1.01, 1.01);
            MyTheme = themeViewModel;

            //themeDialog.ColorChanged += ThemeDialog_ColorChanged;
            themeDialog.ColorChanged += delegate { RefreshThemes(themeChangedEvent); };
        }

        private static void RefreshThemes(MyThemeChangedEvent themeChangedEvent)
        {
            ThemeController.RefreshTheme(MyTheme);
            themeChangedEvent?.InvokeThemeChanged();
        }

        private static void ThemeDialog_ColorChanged(object sender, EventArgs e)
        {
            ThemeController.RefreshTheme(MyTheme);
        }

        public class MyThemeChangedEvent
        {
            public event EventHandler ThemeChanged;

            public void InvokeThemeChanged()
            {
                ThemeChanged?.Invoke(null, null);
            }
        }




    }
}
