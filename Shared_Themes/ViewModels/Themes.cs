using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Shared_Themes.ViewModels
{    public class Themes : ViewModelBase
    {
        private Color _primaryColor;
        private Color _secondaryColor;
        private SolidColorBrush _primarySolidBrush;
        private SolidColorBrush _secondarySolidBrush;
        private SolidColorBrush _accentSolidBrush;
        private double _fontSizeDialog;
        
        public Color PrimaryColor
        {
            get => _primaryColor;
            set
            {
                _primaryColor = value;
                OnPropertyChanged();
            }
        }

        public Color SecondaryColor
        {
            get => _secondaryColor;
            set
            {
                _secondaryColor = value;
                OnPropertyChanged();
            }
        }


        public SolidColorBrush PrimarySolidBrush
        {
            get => _primarySolidBrush;
            set
            {
                _primarySolidBrush = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush SecondarySolidBrush
        {
            get => _secondarySolidBrush;
            set
            {
                _secondarySolidBrush = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush AccentSolidBrush
        {
            get => _accentSolidBrush;
            set
            {
                _accentSolidBrush = value;
                OnPropertyChanged();
            }
        }


        public double FontSizeDialog
        {
            get => _fontSizeDialog;
            set
            {
                _fontSizeDialog = value;
                OnPropertyChanged();
            }
        }
        

        public Themes()
        {
            PrimaryColor = Colors.DarkRed;
            PrimarySolidBrush = new SolidColorBrush(Colors.DarkRed);
            AccentSolidBrush = new SolidColorBrush(Colors.AntiqueWhite);
            FontSizeDialog = 22;
        }
        


    }
}
