using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Tethys.Sample.Views.Basic
{
    public sealed partial class ButtonPage : Page, INavTitle, IDetailPage
    {
        public ButtonPage()
        {
            InitializeComponent();
            GlyphFontFamily = new FontFamily("Segoe MDL2 Assets");
        }

        public string NavTitile => "Buttons";

        public string TitleName => "Buttons";

        public string Description => "Buttons like Bootstrap";

        public string Glyph => "\uf271";

        public FontFamily GlyphFontFamily { get; }
    }
}
