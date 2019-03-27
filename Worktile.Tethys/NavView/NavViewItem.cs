using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls.Primitives;

namespace Worktile.Tethys
{
    public sealed class NavViewItem : ListViewItem
    {
        public NavViewItem()
        {
            DefaultStyleKey = typeof(NavViewItem);
        }

        public object PointerOverContent
        {
            get { return GetValue(PointerOverContentProperty); }
            set { SetValue(PointerOverContentProperty, value); }
        }

        public static readonly DependencyProperty PointerOverContentProperty =
            DependencyProperty.Register("PointerOverContent", typeof(object), typeof(NavViewItem), new PropertyMetadata(null));



        //public IconElement Icon
        //{
        //    get { return (IconElement)GetValue(IconProperty); }
        //    set { SetValue(IconProperty, value); }
        //}

        //public static readonly DependencyProperty IconProperty =
        //    DependencyProperty.Register("Icon", typeof(IconElement), typeof(NavViewItem), new PropertyMetadata(null));


        //public IconElement SelectedIcon
        //{
        //    get { return (IconElement)GetValue(SelectedIconProperty); }
        //    set { SetValue(SelectedIconProperty, value); }
        //}

        //public static readonly DependencyProperty SelectedIconProperty =
        //    DependencyProperty.Register("SelectedIcon", typeof(IconElement), typeof(NavViewItem), new PropertyMetadata(null));

        //public string Label
        //{
        //    get { return (string)GetValue(LabelProperty); }
        //    set { SetValue(LabelProperty, value); }
        //}

        //public static readonly DependencyProperty LabelProperty =
        //    DependencyProperty.Register("Label", typeof(string), typeof(NavViewItem), new PropertyMetadata(null));
    }
}
