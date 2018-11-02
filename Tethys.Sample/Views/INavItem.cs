using System.Collections.Generic;

namespace Tethys.Sample.Views
{
    interface INavItem
    {
        List<IDetailPage> Pages { get; }
    }
}
