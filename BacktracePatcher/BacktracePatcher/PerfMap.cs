using System.Collections.Generic;
using System.Linq;

namespace BacktracePatcher
{
    public class PerfMap
    {
        public List<PerfMapItem> Items { get; private set; }

        public static PerfMap Parse(string[] lines)
        {
            return new PerfMap
            {
                Items = lines.Select(PerfMapItem.Parse).Where(it => it != null).ToList()
            };
        }

        public void Print()
        {
            foreach (var item in Items)
                item.Print();
        }

        public string Resolve(string address)
        {
            return Items
                .FirstOrDefault(item => address.EndsWith(item.Address))
                ?.Name;
        }
    }
}