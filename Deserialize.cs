using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLAnalysor
{
    public class Deserialize
    {
        static void deserail()
        {
            Site site = null;

            string path = @"E:\work\rule\AMS_UGS.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(Site));

            StreamReader reader = new StreamReader(path);
            site = (Site)serializer.Deserialize(reader);
            reader.Close();

            #region Debug

            var type = site.rules[3].expression.And[1].GetType();

            #endregion

            //string outString = Analysor(site);

            //Console.Write(outString);

        }
    }
}
