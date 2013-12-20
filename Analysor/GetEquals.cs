using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLAnalysor
{
    public class EqualsAnalysor:IAnalysor
    {
        public void Generate2File(string fileName)
        {
            string path = string.Format(@"E:\work\rule\{0}.xml", fileName);
            XDocument doc = XDocument.Load(path);

            List<string> out_lines = new List<string>();
            out_lines.Add("ruleID,ruleName, groupID, groupName,expression");

            var rules = from t in doc.Descendants("expression")
                        where t.Elements("Equals").Count() >= 1
                        && t.Elements("And").Count() == 0
                        && t.Elements("Or").Count() == 0
                        select new
                        {
                            ruleName = t.Parent.Attribute("ruleName"),
                            ruleID = t.Parent.Attribute("ruleID"),
                            groupName = t.Parent.Element("group").Attribute("groupName"),
                            groupID = t.Parent.Element("group").Attribute("groupID"),
                            EqualElements = t.Elements("Equals"),
                        };

            foreach (var item in rules)
            {
                var equal = from t in item.EqualElements
                            select new
                            {
                                item.ruleID,
                                item.ruleName,
                                item.groupID,
                                item.groupName,
                                equalAttribute = t.Attribute("attribute"),
                                equalAttributeValue = t.Attribute("attributeValue"),
                            };
                foreach (var eq in equal)
                {
                    Console.WriteLine(eq.ruleID);
                    Console.WriteLine(eq.ruleName);
                    Console.WriteLine(eq.groupID);
                    Console.WriteLine(eq.groupName);
                    Console.WriteLine(eq.equalAttribute);
                    Console.WriteLine(eq.equalAttributeValue);
                    Console.WriteLine();

                    out_lines.Add(string.Format(
                        "{0}, {1}, {2}, {3}, {4} = {5}"
                        , eq.ruleID.Value
                        , eq.ruleName.Value
                        , eq.groupID.Value
                        , eq.groupName.Value
                        , eq.equalAttribute.Value
                        , eq.equalAttributeValue.Value
                        ));
                }

            }

            string outpath = string.Format(@"E:\work\rule\out\Equals_{0}.csv", fileName);
            Helper.output2file(outpath, out_lines);
        }
    }
}
