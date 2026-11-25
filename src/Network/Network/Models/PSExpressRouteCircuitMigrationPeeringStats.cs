using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSExpressRouteCircuitMigrationPeeringStats
    {
        public DateTime? Timestamp { get; set; }

        public List<PSExpressRouteCircuitMigrationMetric> Metrics { get; set; }
    }
}