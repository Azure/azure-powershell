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
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkProfileContainerNicConfigIpConfig", SupportsShouldProcess = true), OutputType(typeof(PSContainerNetworkInterfaceConfiguration))]
    public partial class AddAzureNetworkProfileContainerNetworkInterfaceConfigIpConfigCommand : AzureNetworkProfileContainerNetworkInterfaceConfigIpConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The reference of the container network interface configuration.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSContainerNetworkInterfaceConfiguration ContainerNetworkInterfaceConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the container network interface configuration.")]
        public override string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.ContainerNetworkInterfaceConfiguration.IpConfigurations == null)
            {
                this.ContainerNetworkInterfaceConfiguration.IpConfigurations = new List<PSIPConfigurationProfile>();
            }

            var existingIpConfigurationProfile = this.ContainerNetworkInterfaceConfiguration.IpConfigurations.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));
            if (existingIpConfigurationProfile != null)
            {
                throw new ArgumentException("ContainerNetworkInterfaceConfiguration with the specified name already exists");
            }

            var vIpConfigurationProfile = new PSIPConfigurationProfile();

            vIpConfigurationProfile.Name = this.Name;

            if (!string.IsNullOrEmpty(this.SubnetId))
            {
                vIpConfigurationProfile.Subnet = new PSSubnet();
                vIpConfigurationProfile.Subnet.Id = this.SubnetId;
            }

            var generatedId = string.Format(
                "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/networkProfiles/{2}/{3}/{4}/{5}/{6}",
                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                Microsoft.Azure.Commands.Network.Properties.Resources.ResourceGroupNotSet,
                Microsoft.Azure.Commands.Network.Properties.Resources.NetworkProfileNameNotSet,
                "containerNetworkInterfaceConfigurations",
                this.ContainerNetworkInterfaceConfiguration.Name,
                "ipConfigurations",
                this.Name);

            vIpConfigurationProfile.Id = generatedId;

            this.ContainerNetworkInterfaceConfiguration.IpConfigurations.Add(vIpConfigurationProfile);
            WriteObject(this.ContainerNetworkInterfaceConfiguration, true);
        }
    }
}
