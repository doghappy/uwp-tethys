using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Worktile.Tethys
{
    public sealed class Alert : Control
    {
        public Alert()
        {
            DefaultStyleKey = typeof(Alert);
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(Alert), new PropertyMetadata(null));

        public IconElement Icon
        {
            get { return (IconElement)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(IconElement), typeof(Alert), new PropertyMetadata(null));

        public AlertMode Mode
        {
            get { return (AlertMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(AlertMode), typeof(Alert), new PropertyMetadata(AlertMode.Accent, OnModeChanged));

        private static void OnModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                AlertMode mode = (AlertMode)e.NewValue;
                SolidColorBrush brush = null;
                switch (mode)
                {
                    case AlertMode.Accent:
                        brush = Application.Current.Resources["SystemAccentColor"] as SolidColorBrush;
                        break;
                    case AlertMode.Success:
                        brush = Application.Current.Resources["PrimaryBrush"] as SolidColorBrush;
                        break;
                    case AlertMode.Warning:
                        brush = Application.Current.Resources["WarningBrush"] as SolidColorBrush;
                        break;
                    case AlertMode.Danger:
                        brush = Application.Current.Resources["DangerBrush"] as SolidColorBrush;
                        break;
                }
                var control = d as Alert;
                control.BorderBrush = brush;
                var backgroundBrush = new SolidColorBrush(brush.Color)
                {
                    Opacity = .1
                };
                control.Background = backgroundBrush;
            }
        }
    }
}
