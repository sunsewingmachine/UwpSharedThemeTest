using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Shared_Themes.Common;

namespace Shared_Themes.ViewModels
{

    public class ThemeColor : ViewModelBase
    {
        private double _imageOpacity;

        private Color _color1;
        private Color _color2;
        private Color _color1Text;
        private Color _color2Text;

        private SolidColorBrush _brush1;
        private SolidColorBrush _brush2;
        private SolidColorBrush _brush1Text;
        private SolidColorBrush _brush2Text;

        public const int BlackOpacity = 40;


        private ElementTheme _requestedTheme;
        private string _backImage;

        [JsonIgnore]
        public ElementTheme RequestedTheme 
        {
            get => _requestedTheme;
            set
            {
                _requestedTheme = value;
                SetTextColors(value);
                OnPropertyChanged();
            }
        }

        private void SetTextColors(ElementTheme value)
        {
            if(value == ElementTheme.Dark)
            {
                Color1Text = Colors.Gainsboro;
                Color2Text = Colors.Gold;
                RequestedThemeString = "Dark";
            }
            else
            {
                Color1Text = Colors.Black;
                Color2Text = Colors.Black;
                RequestedThemeString = "Light";
            }
        }

        public string RequestedThemeString { get; set; }

        public Color ColorBlack { get; set; } = Colors.Black;

        public Color ColorNearBlack { get; set; } = Color.FromArgb(255, BlackOpacity, BlackOpacity, BlackOpacity);
        

        public double ImageOpacity
        {
            get => _imageOpacity;
            set
            {
                _imageOpacity = value;
                OnPropertyChanged();
            }
        }

        public Color Color1
        {
            get => _color1;
            set
            {
                _color1 = value;
                Brush1 = new SolidColorBrush(value);
                OnPropertyChanged();
            }
        }

        public Color Color2
        {
            get => _color2;
            set
            {
                _color2 = value;
                Brush2 = new SolidColorBrush(value);
                OnPropertyChanged();
            }
        }

        public Color Color1Text
        {
            get => _color1Text;
            set
            {
                _color1Text = value;
                Brush1Text = new SolidColorBrush(value);
                OnPropertyChanged();
            }
        }

        public Color Color2Text
        {
            get => _color2Text;
            set
            {
                _color2Text = value;
                Brush2Text = new SolidColorBrush(value);
                OnPropertyChanged();
            }
        }


        [JsonIgnore]
        public SolidColorBrush Brush1
        {
            get => _brush1;
            set
            {
                _brush1 = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public SolidColorBrush Brush2
        {
            get => _brush2;
            set { 
                _brush2 = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public SolidColorBrush Brush1Text
        {
            get => _brush1Text;
            set
            {
                _brush1Text = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public SolidColorBrush Brush2Text
        {
            get => _brush2Text;
            set
            {
                _brush2Text = value;
                OnPropertyChanged();
            }
        }



        [JsonIgnore] 
        public SolidColorBrush BrushBlack { get; set; } = new SolidColorBrush(Colors.Black);
        
        [JsonIgnore]
        public SolidColorBrush BrushNearBlack { get; set; } = new SolidColorBrush(Color.FromArgb(255, BlackOpacity, BlackOpacity, BlackOpacity));

        public string BackImage
        {
            get => _backImage;
            set
            {
                _backImage = value;
                OnPropertyChanged();
            }
        }


        public ThemeColor()
        {
            ImageOpacity = 0.5;
            Color1 = Colors.Teal;
            Color1Text = Colors.Gainsboro;
            Color2 = Colors.Crimson;
            Color2Text = Colors.Gold;
            RequestedTheme = ElementTheme.Dark;


            // public Color ColorBlack { get; set; } = Colors.Black;
            // public Color ColorNearBlack { get; set; } = Color.FromArgb(255, 70, 70, 70);


            var AvatarPath = @"ms-appx:///Shared_Themes/Images/Backs/";
            var imageName = "1.png";
            var imagePath = AvatarPath + imageName;

            //BackImage = new Uri(imagePath);
            BackImage = imagePath;
        }

        

    }
}
