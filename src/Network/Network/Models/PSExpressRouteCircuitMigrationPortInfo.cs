using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSExpressRouteCircuitMigrationPortInfo
    {
        public string PortId { get; set; }

        public string Status { get; set; }

        public string Phase { get; set; }

        public string FailureReason { get; set; }

        public List<PSExpressRouteCircuitMigrationPeeringHealth> Peerings { get; set; }

        public string SourcePortId { get; set; }

        public PSExpressRouteCircuitMigrationSourcePortStats SourcePortStats { get; set; }
    }
}