using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Tethys.Sample.Views.Basic
{
    public sealed partial class ColorBrushPage : Page, INavTitle, IDetailPage
    {
        public ColorBrushPage()
        {
            InitializeComponent();
            GlyphFontFamily = new FontFamily("Segoe MDL2 Assets");
        }

        public string NavTitile => "ColorBrushs";

        public string TitleName => "ColorBrushs";

        public string Description => "ColorBrushs like Bootstrap";

        public string Glyph => "\ue790";

        public FontFamily GlyphFontFamily { get; }
    }
}
