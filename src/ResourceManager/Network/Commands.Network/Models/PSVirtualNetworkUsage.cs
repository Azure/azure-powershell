namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSVirtualNetworkUsage
    {
        public string Id { get; set; }
        public double CurrentValue { get; set; }
        public double Limit { get; set; }
        public string Unit { get; set; }
        public PSUsageName Name { get; set; }
    }
}