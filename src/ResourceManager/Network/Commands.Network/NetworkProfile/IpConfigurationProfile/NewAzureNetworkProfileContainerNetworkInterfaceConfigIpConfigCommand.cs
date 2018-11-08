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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ContainerNicConfigIpConfig", SupportsShouldProcess = true), OutputType(typeof(PSContainerNetworkInterfaceConfiguration))]
    public partial class NewAzureNetworkProfileContainerNetworkInterfaceConfigIpConfigCommand : AzureNetworkProfileContainerNetworkInterfaceConfigIpConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the container network interface configuration ip configuration profile.")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Subnet")]
        public override PSSubnet Subnet { get; set; }

        public override void Execute()
        {
            base.Execute();

            var vContainerNetworkInterfaceConfigurationIpConfigurationProfiles = new PSIPConfigurationProfile();
            vContainerNetworkInterfaceConfigurationIpConfigurationProfiles.Name = this.Name;
            vContainerNetworkInterfaceConfigurationIpConfigurationProfiles.Subnet = this.Subnet;

            var generatedId = string.Format(
                "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/networkProfiles/{2}/{3}/{4}/{5}/{6}",
                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                Microsoft.Azure.Commands.Network.Properties.Resources.ResourceGroupNotSet,
                Microsoft.Azure.Commands.Network.Properties.Resources.NetworkProfileNameNotSet,
                "containerNetworkInterfaceConfigurations",
                Microsoft.Azure.Commands.Network.Properties.Resources.ContainerNetworkInterfaceConfigurationNameNotSet,
                "ipConfigurations",
                this.Name);
            vContainerNetworkInterfaceConfigurationIpConfigurationProfiles.Id = generatedId;

            WriteObject(vContainerNetworkInterfaceConfigurationIpConfigurationProfiles, true);
        }
    }
}
