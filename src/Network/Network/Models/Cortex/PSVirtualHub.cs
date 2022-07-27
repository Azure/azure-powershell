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
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSVirtualHub : PSTopLevelResource
    {
        [Ps1Xml(Label = "Virtual Wan Id", Target = ViewControl.Table, ScriptBlock = "$_.VirtualWan.Id")]
        public PSResourceId VirtualWan { get; set; }

        public PSResourceId VpnGateway { get; set; }

        public PSResourceId P2SVpnGateway { get; set; }

        public PSResourceId ExpressRouteGateway { get; set; }

        public PSResourceId SecurityPartnerProvider { get; set; }

        public PSResourceId AzureFirewall { get; set; }

        public List<PSHubVirtualNetworkConnection> VirtualNetworkConnections { get; set; }

        public List<PSVirtualHubRouteTable> RouteTables { get; set; }

        public PSVirtualHubRouteTable RouteTable { get; set; }

        public List<PSHubIpConfiguration> IpConfigurations { get; set; }

        public List<PSBgpConnection> BgpConnections { get; set; }

        public uint VirtualRouterAsn { get; set; }

        public List<string> VirtualRouterIps { get; set; }

        public SwitchParameter AllowBranchToBranchTraffic { get; set; }

        [Ps1Xml(Label = "Address Prefix", Target = ViewControl.Table)]
        public string AddressPrefix { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
        
        [Ps1Xml(Label = "Sku", Target = ViewControl.Table)]
        public string Sku { get; set; }

        [Ps1Xml(Label = "RoutingState", Target = ViewControl.Table)]
        public string RoutingState { get; set; }
        
        [Ps1Xml(Label = "Preferred Routing Gateway", Target = ViewControl.Table)]
        public string PreferredRoutingGateway { get; set; }

        [Ps1Xml(Label = "Hub Routing Preference", Target = ViewControl.Table)]
        public string HubRoutingPreference { get; set; }
    }
}