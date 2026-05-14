using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSRouteServerPeer : PSChildResource
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public uint PeerAsn { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string PeerIp { get; set; }

        [Ps1Xml(Label = "HubVirtualNetworkConnection id", Target = ViewControl.Table, ScriptBlock = "$_.HubVirtualNetworkConnection.Id")]
        public PSResourceId HubVirtualNetworkConnection { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        public PSRoutingConfiguration RoutingConfiguration { get; set; }

        [JsonIgnore]
        public string RoutingConfigurationText
        {
            get { return JsonConvert.SerializeObject(RoutingConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}