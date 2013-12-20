using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLAnalysor
{

    public class XMLAnalysorFactory
    {
        private List<string> _pathList;

        public List<string> PathList
        {
            get { return _pathList; }
            set { _pathList = value; }
        }

        public void Factory(AnalysorType ana)
        {
            IAnalysor analysor = null;
            switch (ana)
            {
                case AnalysorType.Equals:
                    analysor = new EqualsAnalysor();
                    break;
                case AnalysorType.And_Equals:
                    analysor = new Analysis_AND_Equals();
                    break;
                default:
                    break;
            }

            foreach (var path in _pathList)
            {
                analysor.Generate2File(path);
            }

        }
    }
}
