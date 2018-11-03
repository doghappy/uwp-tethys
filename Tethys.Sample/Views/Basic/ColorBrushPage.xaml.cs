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

namespace Tethys.Sample.Views.Basic
{
    public sealed partial class ColorBrushPage : Page,INavTitle, IDetailPage
    {
        public ColorBrushPage()
        {
            InitializeComponent();
            GlyphFontFamily = new FontFamily("Segoe MDL2 Assets");
        }

        public string NavTitile => "ColorBrush";

        public string TitleName => "ColorBrush";

        public string Description => "ColorBrush like Bootstrap";

        public string Glyph => "\ue790";

        public FontFamily GlyphFontFamily { get; }
    }
}
