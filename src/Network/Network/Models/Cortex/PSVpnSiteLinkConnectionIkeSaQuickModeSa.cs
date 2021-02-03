namespace Microsoft.Azure.Commands.Network.Models.Cortex
{
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class PSVpnSiteLinkConnectionIkeSaQuickModeSa
    {
        public PSVpnSiteLinkConnectionIkeSaQuickModeSa()
        {
            localTrafficSelectors = new List<string>();
            remoteTrafficSelectors = new List<string>();
        }

        [JsonProperty("LocalEndpoint")]
        [Ps1Xml(Target = ViewControl.Table)]
        public string localEndpoint { get; set; }

        [JsonProperty("RemoteEndpoint")]
        [Ps1Xml(Target = ViewControl.Table)]
        public string remoteEndpoint { get; set; }

        [JsonProperty("Encryption")]
        [Ps1Xml(Target = ViewControl.Table)]
        public string encryption { get; set; }

        [JsonProperty("Integrity")]
        [Ps1Xml(Target = ViewControl.Table)]
        public string integrity { get; set; }

        [JsonProperty("PfsGroupId")]
        [Ps1Xml(Target = ViewControl.Table)]
        public string pfsGroupId { get; set; }

        [JsonProperty("InboundSPI")]
        [Ps1Xml(Target = ViewControl.Table)]
        public uint inboundSPI { get; set; }

        [JsonProperty("OutboundSPI")]
        [Ps1Xml(Target = ViewControl.Table)]
        public uint outboundSPI { get; set; }

        [JsonProperty("LocalTrafficSelectors")]
        [Ps1Xml(Target = ViewControl.Table)]
        public List<string> localTrafficSelectors { get; set; }

        [JsonProperty("RemoteTrafficSelectors")]
        [Ps1Xml(Target = ViewControl.Table)]
        public List<string> remoteTrafficSelectors { get; set; }

        [JsonProperty("LifetimeKilobytes")]
        [Ps1Xml(Target = ViewControl.Table)]
        public ulong lifetimeKilobytes { get; set; }

        [JsonProperty("LifetimeSeconds")]
        [Ps1Xml(Target = ViewControl.Table)]
        public ulong lifeTimeSeconds { get; set; }

        [JsonProperty("IsSaInitiator")]
        [Ps1Xml(Target = ViewControl.Table)]
        public bool isSaInitiator { get; set; }

        [JsonProperty("ElapsedTimeInseconds")]
        [Ps1Xml(Target = ViewControl.Table)]
        public UInt32 elapsedTimeInseconds { get; set; }
    }
}
