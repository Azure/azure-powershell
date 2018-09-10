using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSEndpointServiceResult
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string Name { get; set; }
        public string Id { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string Type { get; set; }
    }
}