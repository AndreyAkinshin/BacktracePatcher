using System;

namespace BacktracePatcher
{
    public class BacktraceItem
    {
        public string[] Lines { get; set; }

        public void Patch(PerfMap perfMap)
        {
            if (Lines.Length == 1 && Lines[0].Contains("?? ()"))
            {                
                var sp = Lines[0].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (sp.Length >= 4)
                {                    
                    var address = sp[1];                    
                    var name = perfMap.Resolve(address);
                    if (name != null)
                        Lines[0] = Lines[0].Replace("?? ()", name);
                }
            }
        }
    }
}