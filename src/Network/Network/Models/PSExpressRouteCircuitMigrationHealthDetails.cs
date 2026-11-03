using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSExpressRouteCircuitMigrationHealthDetails
    {
        public List<PSExpressRouteCircuitMigrationPortInfo> PortMigrationInfos { get; set; }
    }
}