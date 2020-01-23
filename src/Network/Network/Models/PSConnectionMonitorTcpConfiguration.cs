
namespace Microsoft.Azure.Commands.Network.Models
{
    using Microsoft.Azure.Management.Internal.Resources.Utilities;
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSConnectionMonitorTcpConfiguration : PSNetworkWatcherConnectionMonitorProtocolConfiguration
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public short? Port { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool?  DisableTraceRoute { get; set; }
    }
}
