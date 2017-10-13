using System;
using System.Collections.Generic;
using System.Linq;

namespace BacktracePatcher
{
    public class Backtrace
    {
        public List<BacktraceItem> Items { get; private set; }

        public static Backtrace Parse(string[] lines)
        {
            var items = new List<BacktraceItem>();
            var current = new List<string>();
            foreach (var line in lines.Where(l => l.Length > 0))
            {
                if (line[0] == ' ')
                    current.Add(line);
                else
                {
                    if (current.Count > 0)
                    {
                        items.Add(new BacktraceItem {Lines = current.ToArray()});
                        current.Clear();
                    }
                    current.Add(line);
                }
            }
            if (current.Count > 0)
            {
                items.Add(new BacktraceItem {Lines = current.ToArray()});
                current.Clear();
            }
            return new Backtrace {Items = items};
        }

        public void Print()
        {
            foreach (var item in Items)
            foreach (var line in item.Lines)
                Console.WriteLine(line);
        }

        public void Patch(PerfMap perfMap)
        {
            foreach (var item in Items)
                item.Patch(perfMap);
        }
    }
}