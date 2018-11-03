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
    public sealed partial class HomePage : Page, INavTitle, INavItem
    {
        public HomePage()
        {
            InitializeComponent();
            Pages = new List<IDetailPage>
            {
                new WtfPage(),
                new ThemePage(),
                new ColorBrushPage()
            };
        }

        public string NavTitile => "Basic";

        public List<IDetailPage> Pages { get; }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var gridView = sender as GridView;
            Frame.Navigate(gridView.SelectedItem.GetType());
        }
    }
}
