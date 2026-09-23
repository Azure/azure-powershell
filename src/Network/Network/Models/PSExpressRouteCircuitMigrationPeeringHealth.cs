namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSExpressRouteCircuitMigrationPeeringHealth
    {
        public string Type { get; set; }

        public PSExpressRouteCircuitMigrationPeeringStats StatsCurrent { get; set; }

        public PSExpressRouteCircuitMigrationPeeringStats StatsAtPrepare { get; set; }
    }
}