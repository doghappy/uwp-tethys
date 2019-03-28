using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Worktile.Tethys
{
    public sealed class Card : ContentControl
    {
        public Card()
        {
            DefaultStyleKey = typeof(Card);
        }



        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(Card), new PropertyMetadata(null));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(Card), new PropertyMetadata(null));
    }
}
