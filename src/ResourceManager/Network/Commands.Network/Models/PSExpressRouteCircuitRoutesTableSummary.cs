using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSExpressRouteCircuitRoutesTableSummary
    {

        public int? AsProperty { get; set; }

        public string Neighbor { get; set; }

        public string StatePfxRcd { get; set; }

        public string UpDown { get; set; }

        public int? V { get; set; }
    }
}
