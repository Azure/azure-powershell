namespace Microsoft.Azure.Commands.Network.Models.Cortex
{
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class PSVpnSiteLinkConnectionIkeSaMainModeSa
    {
        public PSVpnSiteLinkConnectionIkeSaMainModeSa()
        {
            quickModeSa = new List<PSVpnSiteLinkConnectionIkeSaQuickModeSa>();
        }

        [JsonProperty("LocalEndpoint")]
        [Ps1Xml(Target = ViewControl.Table)]
        public string localEndpoint { get; set; }

        [JsonProperty("RemoteEndpoint")]
        [Ps1Xml(Target = ViewControl.Table)]
        public string remoteEndpoint { get; set; }

        [JsonProperty("InitiatorCookie")]
        [Ps1Xml(Target = ViewControl.Table)]
        public ulong initiatorCookie { get; set; }

        [JsonProperty("ResponderCookie")]
        [Ps1Xml(Target = ViewControl.Table)]
        public ulong responderCookie { get; set; }

        [JsonProperty("LocalUdpEncapsulationPort")]
        [Ps1Xml(Target = ViewControl.Table)]
        public uint localUdpEncapsulationPort { get; set; }

        [JsonProperty("RemoteUdpEncapsulationPort")]
        [Ps1Xml(Target = ViewControl.Table)]
        public uint remoteUdpEncapsulationPort { get; set; }

        [JsonProperty("Encryption")]
        [Ps1Xml(Target = ViewControl.Table)]
        public string encryption { get; set; }

        [JsonProperty("Integrity")]
        [Ps1Xml(Target = ViewControl.Table)]
        public string integrity { get; set; }

        [JsonProperty("DhGroup")]
        [Ps1Xml(Target = ViewControl.Table)]
        public string dhGroup { get; set; }

        [JsonProperty("LifeTimeSeconds")]
        [Ps1Xml(Target = ViewControl.Table)]
        public uint lifeTimeSeconds { get; set; }

        [JsonProperty("IsSaInitiator")]
        [Ps1Xml(Target = ViewControl.Table)]
        public bool isSaInitiator { get; set; }

        [JsonProperty("ElapsedTimeInseconds")]
        [Ps1Xml(Target = ViewControl.Table)]
        public UInt32 elapsedTimeInseconds { get; set; }

        [JsonProperty("QuickModeSAs")]
        public List<PSVpnSiteLinkConnectionIkeSaQuickModeSa> quickModeSa { get; set; }
    }
}
