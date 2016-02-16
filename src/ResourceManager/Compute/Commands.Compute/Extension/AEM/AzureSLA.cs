using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute
{
    public class AzureSLA
    {
        public bool HasSLA { get; internal set; }
        public string IOPS { get; internal set; }
        public string TP { get; internal set; }
    }
}
