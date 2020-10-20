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
    using System.Collections.Generic;

    public class PSVpnSite : PSTopLevelResource
    {
        [Ps1Xml(Label = "Address Space", Target = ViewControl.Table, ScriptBlock = "$_.AddressSpace.AddressPrefixes")]
        public PSAddressSpace AddressSpace { get; set; }

        public PSBgpSettings BgpSettings { get; set; }

        public PSVpnSiteDeviceProperties DeviceProperties { get; set; }

        [Ps1Xml(Label = "Ip Address", Target = ViewControl.Table)]
        public string IpAddress { get; set; }

        [Ps1Xml(Label = "Virtual WAN Id", Target = ViewControl.Table, ScriptBlock = "$_.VirtualWan.Id")]
        public PSResourceId VirtualWan { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        public List<PSVpnSiteLink> VpnSiteLinks { get; set; }
    }
}
