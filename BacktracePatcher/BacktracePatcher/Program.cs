using System;
using System.IO;

namespace BacktracePatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Please, provide paths to perfmap and backtraces files");
                return;
            }
            var perfMapFileName = args[0];
            var backtraceFileName = args[1];
            var perfMap = PerfMap.Parse(File.ReadAllLines(perfMapFileName));
            var backtrace = Backtrace.Parse(File.ReadAllLines(backtraceFileName));
            
            backtrace.Patch(perfMap);
            backtrace.Print();
        }
    }
}