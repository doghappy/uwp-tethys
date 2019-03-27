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

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Worktile.Tethys.Sample.Views.Basic
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class NavViewPage : Page
    {
        public NavViewPage()
        {
            this.InitializeComponent();
            Items = new List<WtApp>
            {
                new WtApp { Glyph = "\ue618", GlyphO = "\ue61e", Name = "消息" },
                new WtApp { Glyph = "\ue70d", GlyphO = "\ue61a", Name = "项目" },
                new WtApp { Glyph = "\ue614", GlyphO = "\ue70c", Name = "任务" },
                new WtApp { Glyph = "\ue619", GlyphO = "\ue615", Name = "日程" }
            };
        }

        public List<WtApp> Items { get; }
    }

    public class WtApp
    {
        public string Glyph { get; set; }
        public string GlyphO { get; set; }
        public string Name { get; set; }
    }
}
