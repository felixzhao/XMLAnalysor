using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLAnalysor
{
    public class RemoveEquals : IAnalysor
    {
        public void Generate2File(string fileName)
        {
            string path = string.Format(@"E:\work\rule\{0}.xml", fileName);
            XDocument xdoc = XDocument.Load(path);

            var rules = from t in xdoc.Descendants("expression")
                        where t.Elements("Equals").Count() >= 1
                        && t.Elements("And").Count() == 0
                        && t.Elements("Or").Count() == 0
                        select t.Parent
                        ;

            rules.ToList().ForEach(x => x.Remove());

            string outpath = string.Format(@"E:\work\rule\Removed_Equals_{0}.xml", fileName);
            Helper.outputString2file(outpath, xdoc.ToString());
        }
    }
}
