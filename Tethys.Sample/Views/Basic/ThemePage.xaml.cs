using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tethys.Themes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Tethys.Sample.Views.Basic
{
    public sealed partial class ThemePage : Page, INavTitle, IDetailPage, INotifyPropertyChanged
    {
        public ThemePage()
        {
            InitializeComponent();
            GlyphFontFamily = new FontFamily("Segoe MDL2 Assets");
            LoadThemes();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string NavTitile => "Temes";

        public string TitleName => "Themes";

        public string Description => "8 beautiful themes";

        public string Glyph => "\ue790";

        public FontFamily GlyphFontFamily { get; }

        public ObservableCollection<ThemeItem> Themes { get; private set; }

        private ThemeItem _themeItem;
        public ThemeItem ThemeItem
        {
            get => _themeItem;
            set
            {
                if (_themeItem != value)
                {
                    _themeItem = value;
                    ThemeSelector.ChangeTheme(value.Theme);
                    ThemeSelector.ReloadPage<MainPage>();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ThemeItem)));
                }
            }
        }


        private void LoadThemes()
        {
            Themes = new ObservableCollection<ThemeItem>();
            var values = Enum.GetValues(typeof(TethysTheme));
            foreach (var item in values)
            {
                var theme = (TethysTheme)item;
                var rd = ThemeSelector.GetResourceDictionary(theme);
                Themes.Add(new ThemeItem
                {
                    ChineseName = rd["Theme"].ToString(),
                    Theme = theme,
                    PrimaryColor = (SolidColorBrush)rd["Primary"]
                });
            }
        }
    }

    public class ThemeItem
    {
        public string ChineseName { get; set; }
        public TethysTheme Theme { get; set; }
        public SolidColorBrush PrimaryColor { get; set; }
    }
}
