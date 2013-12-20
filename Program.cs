using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace XMLAnalysor
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathlist = new List<string>
            {
                "LAR_UGS",
                "APJ_User_groups",
                "AMS_UGS",
                "EMEA_UGS",
            };

            XMLAnalysorFactory factory = new XMLAnalysorFactory();
            factory.PathList = pathlist;
            factory.Factory(AnalysorType.And_Equals);

            Console.WriteLine("... ...");
            Console.ReadKey();
        }
    }
}
