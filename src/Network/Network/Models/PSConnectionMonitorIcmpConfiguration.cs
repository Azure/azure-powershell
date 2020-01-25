namespace Microsoft.Azure.Commands.Network.Models
{
    using WindowsAzure.Commands.Common.Attributes;

    public class PSNetworkWatcherConnectionMonitorIcmpConfiguration : PSNetworkWatcherConnectionMonitorProtocolConfiguration
    {

        [Ps1Xml(Target = ViewControl.Table)]
        public bool? DisableTraceRoute { get; set; }
    }
}
