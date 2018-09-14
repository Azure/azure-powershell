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
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkProfileContainerNicConfig", SupportsShouldProcess = true), OutputType(typeof(PSNetworkProfile))]
    public partial class AddAzureNetworkProfileContainerNetworkInterfaceConfigCommand : AzureNetworkProfileContainerNetworkInterfaceConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The reference of the network profile resource.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSNetworkProfile NetworkProfile { get; set; }

        public override void Execute()
        {

            var existingContainerNetworkInterfaceConfiguration = this.NetworkProfile.ContainerNetworkInterfaceConfigurations.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));
            if (existingContainerNetworkInterfaceConfiguration != null)
            {
                throw new ArgumentException("ContainerNetworkInterfaceConfiguration with the specified name already exists");
            }

            // ContainerNetworkInterfaceConfigurations
            if (this.NetworkProfile.ContainerNetworkInterfaceConfigurations == null)
            {
                this.NetworkProfile.ContainerNetworkInterfaceConfigurations = new List<PSContainerNetworkInterfaceConfiguration>();
            }

            var vContainerNetworkInterfaceConfigurations = new PSContainerNetworkInterfaceConfiguration();

            vContainerNetworkInterfaceConfigurations.Name = this.Name;
            vContainerNetworkInterfaceConfigurations.IpConfigurations = this.IpConfiguration;
            var generatedId = string.Format(
                "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/networkProfiles/{2}/{3}/{4}",
                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                this.NetworkProfile.ResourceGroupName,
                this.NetworkProfile.Name,
                "ContainerNetworkInterfaceConfigurations",
                this.Name);
            vContainerNetworkInterfaceConfigurations.Id = generatedId;

            this.NetworkProfile.ContainerNetworkInterfaceConfigurations.Add(vContainerNetworkInterfaceConfigurations);
            WriteObject(this.NetworkProfile, true);
        }
    }
}
