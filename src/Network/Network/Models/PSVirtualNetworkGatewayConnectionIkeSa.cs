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
    using System;
    using System.Collections.Generic;

    public class PSVirtualNetworkGatewayConnectionIkeSa
    {
        public List<PSVirtualNetworkGatewayConnectionIkeSaMainModeSa> ikesas;

        public PSVirtualNetworkGatewayConnectionIkeSa()
        {
            ikesas = new List<PSVirtualNetworkGatewayConnectionIkeSaMainModeSa>();
        }
    }

    public class PSVirtualNetworkGatewayConnectionIkeSaMainModeSa
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string localEndpoint { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string remoteEndpoint { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public ulong initiatorCookie { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public ulong responderCookie { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public uint localUdpEncapsulationPort { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public uint remoteUdpEncapsulationPort { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string encryption { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string integrity { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string dhGroup { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public uint lifeTimeSeconds { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool isSaInitiator { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public UInt32 elapsedTimeInseconds { get; set; }

        public List<PSVirtualNetworkGatewayConnectionIkeSaQuickModeSa> quickModeSa { get; set; }

        public PSVirtualNetworkGatewayConnectionIkeSaMainModeSa()
        {
            quickModeSa = new List<PSVirtualNetworkGatewayConnectionIkeSaQuickModeSa>();
        }
    }

    public class PSVirtualNetworkGatewayConnectionIkeSaQuickModeSa
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string localEndpoint { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string remoteEndpoint { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string encryption { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string integrity { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string pfsGroupId { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public uint inboundSPI { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public uint outboundSPI { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public List<string> localTrafficSelectors { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public List<string> remoteTrafficSelectors { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public ulong lifetimeKilobytes { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public ulong lifeTimeSeconds { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool isSaInitiator { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public UInt32 elapsedTimeInseconds { get; set; }

        public PSVirtualNetworkGatewayConnectionIkeSaQuickModeSa()
        {
            localTrafficSelectors = new List<string>();
            remoteTrafficSelectors = new List<string>();
        }
    }
}
