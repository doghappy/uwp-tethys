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
    public sealed partial class WtfPage : Page, INavTitle, IDetailPage
    {
        public WtfPage()
        {
            InitializeComponent();
            GlyphFontFamily = new FontFamily("Segoe MDL2 Assets");
        }

        public string NavTitile => "Worktile Icon Font";
        public string TitleName => NavTitile;
        public string Description => "Worktile Icon Font";
        public string Glyph => "\ue164";
        public FontFamily GlyphFontFamily { get; }
    }
}
