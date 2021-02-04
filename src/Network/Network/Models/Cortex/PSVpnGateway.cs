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

    public class PSVpnGateway : PSTopLevelResource
    {
        public List<PSVpnConnection> Connections { get; set; }
        
        public PSBgpSettings BgpSettings { get; set; }

        [Ps1Xml(Label = "Virtual Hub", Target = ViewControl.Table, ScriptBlock = "$_.VirtualHub.Id")]
        public PSResourceId VirtualHub { get; set; }

        [Ps1Xml(Label = "Scale Unit", Target = ViewControl.Table)]
        public int VpnGatewayScaleUnit { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        public List<PSVpnGatewayIpConfiguration> IpConfigurations { get; set;}

        public List<PSVpnGatewayNatRule> NatRules { get; set; }

        [Ps1Xml(Label = "Enable RoutingPreferenceInternet", Target = ViewControl.Table)]
        public bool? IsRoutingPreferenceInternet { get; set; }
    }
}
