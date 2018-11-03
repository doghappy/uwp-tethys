using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Tethys.Extensions;

namespace Tethys.Themes
{
    public static class ThemeSelector
    {
        public static void ChangeTheme(TethysTheme theme)
        {
            var style = Application.Current.Resources.MergedDictionaries
                 .FirstOrDefault(r => r.Source.OriginalString == "ms-appx:///Tethys/Styles/Style.xaml");
            if (style == null)
            {
                throw new InvalidOperationException("Tethys's reference was not found in App.xaml. please make sure '<ResourceDictionary Source=\"ms-appx:///Tethys/Styles/Style.xaml\"/>' is in the node \"<ResourceDictionary.MergedDictionaries>\"");
            }
            var oldTheme = style.MergedDictionaries
                .FirstOrDefault(r => r.Source.OriginalString.StartsWith("ms-resource:///Themes/"));
            style.MergedDictionaries.Remove(oldTheme);
            style.MergedDictionaries.Add(GetResourceDictionary(theme));
        }

        public static bool ReloadPage<T>() where T : Page
        {
            var fe = Window.Current.Content as FrameworkElement;
            var page = fe.GetChildren<T>().FirstOrDefault();
            if (page == null)
            {
                throw new InvalidOperationException("Failed to reload, can't found " + typeof(T).Name);
            }
            Type type = page.Frame.CurrentSourcePageType;
            object parameter = null;
            if (page.Frame.BackStack.Any())
            {
                var lastPage = page.Frame.BackStack.Last();
                type = lastPage.SourcePageType;
                parameter = lastPage.Parameter;
            }
            try
            {
                return page.Frame.Navigate(type, parameter);
            }
            finally
            {
                page.Frame.BackStack.Remove(page.Frame.BackStack.Last());
            }
        }

        public static ResourceDictionary GetResourceDictionary(TethysTheme theme)
        {
            return new ResourceDictionary
            {
                Source = new Uri($"ms-appx:///Tethys/Themes/{theme.ToString()}.xaml", UriKind.Absolute)
            };
        }
    }
}
