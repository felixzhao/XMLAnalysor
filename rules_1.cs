using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLAnalysor
{
    [XmlRoot("Site")]
    public class Site
    {
        [XmlElement("rules")]
        public rules[] ruleslist { get; set; }
    }

    public class rules
    {
        public string ruleName { get; set; }
        public string ruleID { get; set; }
        public group groupNode { get; set; }
        public expression expressionNode { get; set; }
    }

    public class group
    {
        public string groupName { get; set; }
        public string groupID { get; set; }
    }

    public class expression
    {

    }

    public class Equals
    {
        public string attributeValue { get; set; }
        public string attribute { get; set; }
    }
}
