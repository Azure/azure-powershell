using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSVirtualNetworkUsage
    {
        public string Id { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public double CurrentValue { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public double Limit { get; set; }
        public string Unit { get; set; }
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, ScriptBlock = "$_.Name.LocalizedValue")]
        public PSUsageName Name { get; set; }
    }
}