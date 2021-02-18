
namespace Microsoft.Azure.Commands.Network.Models
{
    using WindowsAzure.Commands.Common.Attributes;

    public class PSNetworkWatcherConnectionMonitorTcpConfiguration : PSNetworkWatcherConnectionMonitorProtocolConfiguration
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public int? Port { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool?  DisableTraceRoute { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string DestinationPortBehavior { get; set; }
    }
}
