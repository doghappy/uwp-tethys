using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
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
            _brushes = new SolidColorBrush[]
            {
                new SolidColorBrush(Color.FromArgb(255, 44, 204, 218)),
                new SolidColorBrush(Color.FromArgb(255, 45, 188, 255)),
                new SolidColorBrush(Color.FromArgb(255, 78, 138, 249)),
                new SolidColorBrush(Color.FromArgb(255, 112, 118, 250)),
                new SolidColorBrush(Color.FromArgb(255, 148, 115, 253)),
                new SolidColorBrush(Color.FromArgb(255, 239, 126, 222)),
                new SolidColorBrush(Color.FromArgb(255, 153, 215, 90)),
                new SolidColorBrush(Color.FromArgb(255, 102, 192, 96)),
                new SolidColorBrush(Color.FromArgb(255, 57, 186, 93))
            };
        }

        readonly SolidColorBrush[] _brushes;

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

        private SolidColorBrush GetBrush(string displayName)
        {
            int code = displayName.Sum(n => n);
            return _brushes[code % _brushes.Length];
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
                    avatar.DisplayName = value.Substring(value.Length - 2, 2);
                }
                else if (Regex.IsMatch(value, @"^[a-zA-Z\/\s]+$") && value.IndexOf(' ') > 0)
                {
                    var arr = value.Split(' ');
                    avatar.DisplayName = (arr[0].First().ToString() + arr[1].First()).ToUpper();
                }
                else if (value.Length > 2)
                {
                    avatar.DisplayName = value.Substring(0, 2).ToUpper();
                }
                else
                {
                    avatar.DisplayName = value.ToUpper();
                }

                avatar.Background = avatar.GetBrush(value);
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
    }
}
