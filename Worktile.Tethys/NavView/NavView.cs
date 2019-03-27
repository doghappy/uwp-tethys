using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Worktile.Tethys
{
    public sealed class NavView : ContentControl
    {
        public NavView()
        {
            DefaultStyleKey = typeof(NavView);
        }

        public object MenuItemsSource
        {
            get { return (object)GetValue(MenuItemsSourceProperty); }
            set { SetValue(MenuItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty MenuItemsSourceProperty =
            DependencyProperty.Register("MenuItemsSource", typeof(object), typeof(NavView), new PropertyMetadata(null));

        public DataTemplate MenuItemTemplate
        {
            get { return (DataTemplate)GetValue(MenuItemTemplateProperty); }
            set { SetValue(MenuItemTemplateProperty, value); }
        }

        public static readonly DependencyProperty MenuItemTemplateProperty =
            DependencyProperty.Register("MenuItemTemplate", typeof(DataTemplate), typeof(NavView), new PropertyMetadata(null));

        public double NavHeaderWidth
        {
            get { return (double)GetValue(NavHeaderWidthProperty); }
            set { SetValue(NavHeaderWidthProperty, value); }
        }

        public static readonly DependencyProperty NavHeaderWidthProperty =
            DependencyProperty.Register("NavHeaderWidth", typeof(double), typeof(NavView), new PropertyMetadata(70));

        

    }
}
