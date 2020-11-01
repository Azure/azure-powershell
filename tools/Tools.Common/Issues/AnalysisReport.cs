using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Common.Issues
{
    public class AnalysisReport
    {
        private List<int> _problemIdList;
        public List<int> ProblemIdList
        {
            get
            {
                if(_problemIdList == null)
                {
                    _problemIdList = new List<int>();
                }
                return _problemIdList;
            }
        }

        public AnalysisReport()
        {

        }
    }
}
