using System;

namespace BacktracePatcher
{
    public class PerfMapItem
    {
        public string Address { get; set; }
        public string Size { get; set; }
        public string Name { get; set; }

        public static PerfMapItem Parse(string line)
        {
            var index1 = line.IndexOf(' ');
            if (index1 == -1 || index1 == 0)
                return null;
            var index2 = line.IndexOf(' ', index1 + 1);
            if (index2 == -1)
                return null;
            return new PerfMapItem
            {
                Address = line.Substring(0, index1),
                Size = line.Substring(index1 + 1, index2 - index1 - 1),
                Name = line.Substring(index2 + 1)
            };
        }

        public void Print()
        {
            Console.WriteLine(Address + " " + Size + " " + Name);
        }
    }
}