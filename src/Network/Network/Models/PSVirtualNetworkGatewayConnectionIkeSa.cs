// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network.Models
{
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class PSVirtualNetworkGatewayConnectionIkeSaMainModeSa
    {
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
        public List<PSVirtualNetworkGatewayConnectionIkeSaQuickModeSa> quickModeSa { get; set; }

        public PSVirtualNetworkGatewayConnectionIkeSaMainModeSa()
        {
            quickModeSa = new List<PSVirtualNetworkGatewayConnectionIkeSaQuickModeSa>();
        }
    }

    public class PSVirtualNetworkGatewayConnectionIkeSaQuickModeSa
    {
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

        public PSVirtualNetworkGatewayConnectionIkeSaQuickModeSa()
        {
            localTrafficSelectors = new List<string>();
            remoteTrafficSelectors = new List<string>();
        }
    }
}
