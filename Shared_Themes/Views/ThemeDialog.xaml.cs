using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Extensions;
using Shared_Themes.Common;
using Shared_Themes.ViewModels;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Glob = Shared_Themes.Common.GlobThemes;

namespace Shared_Themes.Views
{
    public sealed partial class ThemeDialog : UserControl
    {
        private ObservableCollection<ThemeColor> AllThemesList = new ObservableCollection<ThemeColor>();
        public event EventHandler ColorChanged;
        private bool _isLoading;
        private int savedLstThemeColorsLastIndex;
        private int savedLstBackImagesLastIndex;
        private double SavedSliderImageOpacityValue;
        

        public ThemeDialog()
        {
            this.InitializeComponent();
            Loaded += ThemeDialog_Loaded;
        }

        private void ThemeDialog_Loaded(object sender, RoutedEventArgs e)
        {
            _isLoading = true;
            savedLstThemeColorsLastIndex = (int)Reg.GetSetting(ThemeRegKeys.LstThemeColorsLastIndex, 0);
            savedLstBackImagesLastIndex = (int)Reg.GetSetting(ThemeRegKeys.LstBackImagesLastIndex, 0);
            SavedSliderImageOpacityValue = (double)Reg.GetSetting(ThemeRegKeys.SliderImageOpacityValue, 0.5);

            CreateColorArray();
            LstThemeColors.ItemsSource = AllThemesList;
            LoadBackImages();
            RetrieveSaved();
            LstThemeColors.Visibility = Visibility.Visible;
            LstBackImages.Visibility = Visibility.Collapsed;
            _isLoading = false;
            SetFocusToLst();
        }

        private async void SetFocusToLst()
        {
            await Task.Delay(500);
            LstThemeColors.Focus(FocusState.Programmatic); 
        }

        //private async void GetOldPreview()
        //{
        //    GetOldPreview();
        //    ImgOldPreview.Source =  ThemeController.BitmapImage;
        //}


        private void RetrieveSaved()
        {
            LstThemeColors.SelectedIndex = savedLstThemeColorsLastIndex;
            LstBackImages.SelectedIndex = savedLstBackImagesLastIndex;
            SliderImageOpacity.Value = SavedSliderImageOpacityValue;
            selectedSliderImageOpacityValue = SavedSliderImageOpacityValue;
        }

        private void CreateColorArray()
        {
            ThemeColor theme;
            
            theme = new ThemeColor();
            theme.Color1 = Colors.Maroon;
            theme.Color2 = Color.FromArgb(255, 198, 61, 61);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);
            
            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 0, 93, 51);
            theme.Color2 = Color.FromArgb(255, 69, 143, 69);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);

                theme = new ThemeColor();
                theme.Color1 = Colors.Maroon;
                theme.Color2 = Color.FromArgb(255, 1, 114, 64);
                AllThemesList.Add(theme);
                AddInvertedTheme(theme, false);


            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 137, 46, 188);
            theme.Color2 = Color.FromArgb(255, 76, 153, 76);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);

            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 48, 63, 159);
            theme.Color2 = Color.FromArgb(255, 239, 56, 118);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);

                theme = new ThemeColor();
                theme.Color1 = Color.FromArgb(255, 137, 46, 188);
                theme.Color2 = Color.FromArgb(255, 239, 56, 118);
                AllThemesList.Add(theme);
                AddInvertedTheme(theme, false);


            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 47, 134, 51);
            theme.Color2 = Color.FromArgb(255, 48, 63, 159);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);

            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 6, 37, 160);
            theme.Color2 = Color.FromArgb(255, 239, 56, 118);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);

                theme = new ThemeColor();
                theme.Color1 = Color.FromArgb(255, 56, 142, 60);
                theme.Color2 = Color.FromArgb(255, 239, 56, 118);
                AllThemesList.Add(theme);
                AddInvertedTheme(theme, false);



            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 0, 145, 142);
            theme.Color2 = Color.FromArgb(255, 0, 111, 148);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);

            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 0, 145, 142);
            theme.Color2 = Color.FromArgb(255, 6, 37, 160);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme, false);


                theme = new ThemeColor();
                theme.Color1 = Color.FromArgb(255, 0, 145, 142);
                theme.Color2 = Color.FromArgb(255, 6, 37, 160);
                AllThemesList.Add(theme);
                AddInvertedTheme(theme, false);


            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 5, 0, 121);
            theme.Color2 = Color.FromArgb(255, 147, 2, 2);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);


            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 239, 56, 118);
            theme.Color2 = Color.FromArgb(255, 183, 102, 102);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);

            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 0, 120, 23);
            theme.Color2 = Color.FromArgb(255, 65, 148, 199);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);



            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 127, 0, 123);
            theme.Color2 = Color.FromArgb(255, 165, 78, 163);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);

            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 14, 56, 227);
            theme.Color2 = Color.FromArgb(255, 97, 126, 241);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);

            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 0, 146, 92);
            theme.Color2 = Color.FromArgb(255, 0, 162, 102);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);

            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 114, 96, 96);
            theme.Color2 = Color.FromArgb(255, 151, 8, 162);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);

            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 0, 51, 114);
            theme.Color2 = Color.FromArgb(255, 23, 79, 149);
            AllThemesList.Add(theme);
            AddInvertedTheme(theme);

            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 81, 107, 4);
            theme.Color2 = Color.FromArgb(255, 124, 146, 57);
            AllThemesList.Add(theme);

            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 111, 0, 157);
            theme.Color2 = Color.FromArgb(255, 147, 76, 176);
            AllThemesList.Add(theme);

            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 202, 202, 202);
            theme.Color2 = Color.FromArgb(255, 222, 230, 181);
            theme.RequestedTheme = ElementTheme.Light;
            AllThemesList.Add(theme);

            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 240, 191, 191);
            theme.Color2 = Color.FromArgb(255, 199, 217, 103);
            theme.RequestedTheme = ElementTheme.Light;
            AllThemesList.Add(theme);

            theme = new ThemeColor();
            theme.Color1 = Color.FromArgb(255, 224, 224, 224);
            theme.Color2 = Color.FromArgb(255, 177, 177, 177);
            theme.RequestedTheme = ElementTheme.Light;
            AllThemesList.Add(theme);
        }

        private readonly Color VeryNearBlack = Color.FromArgb(255, 25, 25, 25);
        private void AddInvertedTheme(ThemeColor theme, bool skipBlackInversions = false)
        {
            var themeInverted = new ThemeColor();
            var color2 = theme.Color2;
            themeInverted.Color2 = theme.Color1;
            themeInverted.Color1 = color2;
            AllThemesList.Add(themeInverted);

            if (skipBlackInversions) return;

            var themeWithBlack2 = new ThemeColor();
            themeWithBlack2.Color1 = theme.Color1;
            themeWithBlack2.Color2 = VeryNearBlack;
            AllThemesList.Add(themeWithBlack2);

            var themeWithBlack2Inverted = new ThemeColor();
            themeWithBlack2Inverted.Color2 = theme.Color1;
            themeWithBlack2Inverted.Color1 = VeryNearBlack;
            AllThemesList.Add(themeWithBlack2Inverted);
            
            var themeWithBlack1 = new ThemeColor();
            themeWithBlack1.Color1 = VeryNearBlack;
            themeWithBlack1.Color2 = theme.Color2;
            AllThemesList.Add(themeWithBlack1);

            var themeWithBlack1Inverted = new ThemeColor();
            themeWithBlack1Inverted.Color1 = VeryNearBlack;
            themeWithBlack1Inverted.Color2 = theme.Color2;
            AllThemesList.Add(themeWithBlack1Inverted);

        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void LstThemeColors_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SaveAndRefresh();
        }

        private void SaveAndRefresh()
        {
            if (_isLoading) return;
            if (!(LstThemeColors.SelectedItem is ThemeColor themeColor)) return;

            themeColor.ImageOpacity = selectedSliderImageOpacityValue;
            themeColor.BackImage = selectedBackImageFileName;

            var jsonString = JsonSerializer.Serialize(themeColor);
            Debug.WriteLine(jsonString);
            Reg.SaveSetting(ThemeRegKeys.SavedTheme, jsonString);
            ColorChanged?.Invoke(this, null);

            Reg.SaveSetting(ThemeRegKeys.SliderImageOpacityValue, selectedSliderImageOpacityValue);
            Reg.SaveSetting(ThemeRegKeys.LstThemeColorsLastIndex, LstThemeColors.SelectedIndex);
            Reg.SaveSetting(ThemeRegKeys.LstBackImagesLastIndex, LstBackImages.SelectedIndex);
            Debug.WriteLine(Reg.GetSetting(ThemeRegKeys.SliderImageOpacityValue, 0.5));
        }



        private async void LoadBackImages()
        {
            var appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            // Launcher.LaunchFolderAsync(appInstalledFolder);

            var path = GlobThemes.BackgroundImagePath.Replace(@"ms-appx:///", "");
            path = path.Replace("/", @"\");

            var AssetFolder = await appInstalledFolder.GetFolderAsync(path);

            var files = await AssetFolder.GetFilesAsync();

            //Avatars = new ObservableCollection<Avatar>();
            var backImages = new List<BackImage>();

            foreach (var file in files)
            {
                Debug.WriteLine(file.Path);
                var ImageUri = new Uri(file.Path, UriKind.RelativeOrAbsolute);
                var bi = new BackImage();
                bi.FileName = file.Name;
                bi.ImageUri = ImageUri;
                backImages.Add(bi);
            }

            LstBackImages.ItemsSource = backImages;
            //LstBackImages.SelectedIndex = -1;
        }

        private void BtnBgColor_OnClick(object sender, RoutedEventArgs e)
        {
            LstBackImages.Visibility = Visibility.Collapsed;
            LstThemeColors.Visibility = Visibility.Visible;
        }

        private void BtnBgImage_OnClick(object sender, RoutedEventArgs e)
        {
            LstBackImages.Visibility = Visibility.Visible;
            LstThemeColors.Visibility = Visibility.Collapsed;
        }

        private string selectedBackImageFileName = string.Empty;
        private double selectedSliderImageOpacityValue;
        private void LstBackImages_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstBackImages.SelectedIndex == -1) return;
            var backImage = LstBackImages.SelectedItem as BackImage;
            selectedBackImageFileName = backImage?.FileName;
            SaveAndRefresh();
        }

        private void UserControl_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Escape)
            {
                e.Handled = true;
                CloseMe();
            }
            else if (e.Key == Windows.System.VirtualKey.Enter)
            {
                e.Handled = true;
                BtnClose_OnClick(null, null);
            }
        }

        private void CloseMe()
        {
            RetrieveSaved();
            SaveAndRefresh();
            this.Visibility = Visibility.Collapsed;
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            CloseMe();
        }


        private void SliderImageOpacity_OnValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            selectedSliderImageOpacityValue = SliderImageOpacity.Value;
            SaveAndRefresh();
        }
    }


    public class BackImage
    {
        public Uri ImageUri { get; set; }

        public string FileName { get; set; }
    }



}
