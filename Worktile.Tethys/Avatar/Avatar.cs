using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Worktile.Tethys
{
    public sealed class Avatar : Control
    {
        public Avatar()
        {
            DefaultStyleKey = typeof(Avatar);
            SizeChanged += Avatar_SizeChanged;
            Loaded += Avatar_Loaded;
        }

        private void Avatar_Loaded(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Icon))
            {
                VisualStateManager.GoToState(this, "Icon", false);
            }
            else if (Source is BitmapImage bitmap)
            {
                if (Path.GetExtension(bitmap.UriSource.AbsolutePath.ToLower()) == ".png")
                {
                    Background = Foreground;
                }
            }
        }

        private void Avatar_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            bool widthChanged = e.NewSize.Width != e.PreviousSize.Width;
            bool heightChanged = e.NewSize.Height != e.PreviousSize.Height;
            double newSize;
            if (widthChanged && heightChanged)
            {
                newSize = e.NewSize.Width < e.NewSize.Height ? e.NewSize.Width : e.NewSize.Height;
            }
            else if (widthChanged)
            {
                newSize = e.NewSize.Width;
            }
            else if (heightChanged)
            {
                newSize = e.NewSize.Height;
            }
            else
            {
                return;
            }
            Height = newSize;
            Width = newSize;
            CornerRadius = new CornerRadius(newSize);
            FontSize = Width * .42;
        }

        public string DisplayName
        {
            get => (string)GetValue(DisplayNameProperty);
            set => SetValue(DisplayNameProperty, value);
        }

        public static readonly DependencyProperty DisplayNameProperty =
            DependencyProperty.Register("DisplayName", typeof(string), typeof(Avatar), new PropertyMetadata(null, OnDisplayNameChanged));

        private static void OnDisplayNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue && e.NewValue != null)
            {
                var avatar = d as Avatar;

                string value = e.NewValue.ToString();
                if (Regex.IsMatch(value, @"^[\u4e00-\u9fa5]+$") && value.Length > 2)
                {
                    avatar.Initials = value.Substring(value.Length - 2, 2);
                }
                else if (Regex.IsMatch(value, @"^[a-zA-Z\/\s]+$") && value.IndexOf(' ') > 0)
                {
                    var arr = value.Split(' ');
                    avatar.Initials = (arr[0].First().ToString() + arr[1].First()).ToUpper();
                }
                else if (value.Length > 2)
                {
                    avatar.Initials = value.Substring(0, 2).ToUpper();
                }
                else
                {
                    avatar.Initials = value.ToUpper();
                }
            }
        }

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(Avatar), new PropertyMetadata(null));

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(Avatar), new PropertyMetadata(null));

        private string Initials
        {
            get { return (string)GetValue(InitialsProperty); }
            set { SetValue(InitialsProperty, value); }
        }

        private static readonly DependencyProperty InitialsProperty =
            DependencyProperty.Register("Initials", typeof(string), typeof(Avatar), new PropertyMetadata(null));
    }
}
