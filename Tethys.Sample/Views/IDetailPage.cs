using Windows.UI.Xaml.Media;

namespace Tethys.Sample.Views
{
    public interface IDetailPage 
    {
        string TitleName { get; }
        string Description { get; }
        string Glyph { get; }
        FontFamily GlyphFontFamily { get; }
    }
}
