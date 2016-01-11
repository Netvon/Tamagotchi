using System;
using System.Collections.Generic;
using System.Linq;
using Tamagotchi.Web.TamagotchiService;

namespace Tamagotchi.Web.Models
{
    public class TamagotchiOverviewModel
    {
        public TamagotchiOverviewModel(IEnumerable<TamagotchiContract> tamagotchis, int page, int max_page)
        {
            Tamagotchis = tamagotchis;
            Page = page;
            MaxPage = max_page;
        }

        public IEnumerable<TamagotchiContract> Tamagotchis { get; }
        public int Page { get; }
        public int MaxPage { get; }

        public int NextPage => Math.Min(Page + 1, MaxPage);
        public int PrevPage => Math.Max(Page - 1, 0);

        public bool HasPrevPage => PrevPage >= 0 && PrevPage != Page;
        public bool HasNextPage => NextPage <= (MaxPage - 1);

        public IEnumerable<int> Pages
        {
            get
            {
                var @out = Enumerable.Range(1, MaxPage);

                if (@out.Count() > 10)
                {
                    var adjusted = @out.Skip(Page);

                    var fiveBegin = adjusted.Take(5);

                    var skip = adjusted.Count() - 5;

                    var fiveEnd = adjusted.Skip(skip);

                    return fiveBegin.Union(fiveEnd);
                }

                return @out;
            }
        }
    }
}