namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSVirtualNetworkUsage
    {
        public string Id { get; set; }
        public long CurrentValue { get; set; }
        public long Limit { get; set; }
        public string Unit { get; set; }
        public PSUsageName Name { get; set; }
    }
}