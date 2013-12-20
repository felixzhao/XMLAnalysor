using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLAnalysor
{
    public class Analysis_AND_Equals : IAnalysor
    {
        public void Generate2File(string fileName)
        {
            string path = string.Format(@"E:\work\rule\{0}.xml", fileName);
            XDocument doc = XDocument.Load(path);

            List<string> out_lines = new List<string>();
            out_lines.Add("ruleID,ruleName, groupID, groupName,expression");

            var rules = from t in doc.Descendants("expression")
                        where
                        t.Elements("Equals").Count() == 0
                        && t.Elements("And").Count() >= 1
                        && t.Elements("Or").Count() == 0
                        select new
                        {
                            ruleName = t.Parent.Attribute("ruleName"),
                            ruleID = t.Parent.Attribute("ruleID"),
                            groupName = t.Parent.Element("group").Attribute("groupName"),
                            groupID = t.Parent.Element("group").Attribute("groupID"),
                            innerElements = t.Elements("And"),
                        };

            foreach (var item in rules)
            {
                var equal = from t in item.innerElements.Descendants("Equals")
                            where t.Parent.Elements("InGroup").Count() == 0
                            select new
                            {
                                item.ruleID,
                                item.ruleName,
                                item.groupID,
                                item.groupName,
                                equalAttribute = t.Attribute("attribute"),
                                equalAttributeValue = t.Attribute("attributeValue"),
                            };
                if (equal.Count() > 0)
                {

                    string out_string = string.Format(
                            "{0}, {1}, {2}, {3},"
                            , equal.First().ruleID.Value
                            , equal.First().ruleName.Value
                            , equal.First().groupID.Value
                            , equal.First().groupName.Value
                        );

                    foreach (var eq in equal)
                    {
                        out_string += string.Format(
                            " {0} = {1} & "
                            , eq.equalAttribute.Value
                            , eq.equalAttributeValue.Value
                            );
                    }
                    out_string = out_string.Remove(out_string.Length - 2);
                    out_lines.Add(out_string);
                }

            }

            string outpath = string.Format(@"E:\work\rule\out\AND_Equals_{0}.csv", fileName);
            Helper.output2file(outpath, out_lines);
        }
    }
}
