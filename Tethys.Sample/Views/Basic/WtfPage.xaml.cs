using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


namespace Tethys.Sample.Views.Basic
{
    public sealed partial class WtfPage : Page, INavTitle, IDetailPage, INotifyPropertyChanged
    {
        public WtfPage()
        {
            InitializeComponent();
            GlyphFontFamily = new FontFamily("Segoe MDL2 Assets");
            WtfItems = new ObservableCollection<WtfItem>();
            IsActive = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string NavTitile => "Worktile Icon Font";
        public string TitleName => NavTitile;
        public string Description => "Worktile Icon Font";
        public string Glyph => "\ue164";
        public FontFamily GlyphFontFamily { get; }
        public ObservableCollection<WtfItem> WtfItems { get; }

        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsActive)));
            }
        }


        private async Task AddWtfItemsAsync()
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                int begin = Convert.ToInt32("e600", 16);
                int end = Convert.ToInt32("e73C", 16);
                for (int i = begin; i <= end; i++)
                {
                    if (i < 59155 || i > 59158)
                    {
                        WtfItems.Add(new WtfItem
                        {
                            Glyph = (char)i,
                            Unicode = "u+" + i.ToString("x")
                        });
                    }
                }
            });
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await AddWtfItemsAsync();
            IsActive = false;
        }
    }

    public class WtfItem
    {
        public char Glyph { get; set; }
        public string Unicode { get; set; }
    }
}
