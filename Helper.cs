using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLAnalysor
{
    public class Helper
    {
        public static void output2file(string outpath, List<string> lines)
        {
            System.IO.File.WriteAllLines(outpath, lines);
        }

        public static void outputString2file(string outpath, string xmlString)
        {
            System.IO.File.WriteAllText(outpath, xmlString);
        }
    }
}
