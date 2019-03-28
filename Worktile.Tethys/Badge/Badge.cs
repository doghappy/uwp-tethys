using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Worktile.Tethys
{
    public sealed class Badge : Control
    {
        public Badge()
        {
            DefaultStyleKey = typeof(Badge);
        }

        public string Content
        {
            get { return (string)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(string), typeof(Badge), new PropertyMetadata(null, OnContentChanged));

        private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var badge = d as Badge;
            badge.Visibility = Visibility.Visible;
        }


        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(int), typeof(Badge), new PropertyMetadata(0, OnNumberChanged));

        private static void OnNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var badge = d as Badge;
            int newValue = (int)e.NewValue;
            if (newValue == 0)
            {
                badge.Visibility = Visibility.Collapsed;
            }
            else
            {
                badge.Visibility = Visibility.Visible;
                if (newValue > 99)
                {
                    badge.Content = "99+";
                }
                else
                {
                    badge.Content = newValue.ToString();
                }
            }
        }
    }
}
