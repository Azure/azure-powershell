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
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSVpnConnection : PSChildResource
    {
        [Ps1Xml(Label = "Remote VpnSite Id", Target = ViewControl.Table, ScriptBlock = "$_.RemoteVpnSite.Id")]
        public PSResourceId RemoteVpnSite { get; set; }

        public string SharedKey { get; set; }

        [Ps1Xml(Label = "VpnConnectionProtocolType", Target = ViewControl.Table)]
        public string VpnConnectionProtocolType { get; set; }

        [Ps1Xml(Label = "ConnectionStatus", Target = ViewControl.Table)]
        public string ConnectionStatus { get; set; }

        [Ps1Xml(Label = "EgressBytesTransferred", Target = ViewControl.Table)]
        public long? EgressBytesTransferred { get; set; }

        [Ps1Xml(Label = "IngressBytesTransferred", Target = ViewControl.Table)]
        public long? IngressBytesTransferred { get; set; }

        public List<PSIpsecPolicy> IpsecPolicies { get; set; }

        [Ps1Xml(Label = "Connection Bandwidth", Target = ViewControl.Table)]
        public int ConnectionBandwidth { get; set; }

        [Ps1Xml(Label = "BGP Enabled", Target = ViewControl.Table)]
        public bool EnableBgp { get; set; }

        [Ps1Xml(Label = "Use Local Azure IpAddress", Target = ViewControl.Table)]
        public bool UseLocalAzureIpAddress { get; set; }

        [Ps1Xml(Label = "UsePolicyBasedTrafficSelectors", Target = ViewControl.Table)]
        public bool UsePolicyBasedTrafficSelectors { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [Ps1Xml(Label = "VpnLink Connections", Target = ViewControl.Table)]
        public List<PSVpnSiteLinkConnection> VpnLinkConnections { get; set; }

        [Ps1Xml(Label = "Internet Security Enabled", Target = ViewControl.Table)]
        public bool EnableInternetSecurity { get; set; }
    }
}
