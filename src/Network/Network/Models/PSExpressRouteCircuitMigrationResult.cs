using System;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSExpressRouteCircuitMigrationResult
    {
        public string Status { get; set; }

        public string Phase { get; set; }

        public string FailureReason { get; set; }

        public string NewSTag { get; set; }

        public DateTime? PreparedAt { get; set; }

        public DateTime? PrepareExpiryTime { get; set; }

        public string NewCrossConnectionUrl { get; set; }

        public bool? ShouldRollback { get; set; }

        public PSExpressRouteCircuitMigrationHealthDetails Details { get; set; }
    }
}