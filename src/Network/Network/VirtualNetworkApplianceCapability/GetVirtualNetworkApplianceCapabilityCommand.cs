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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkApplianceCapability", DefaultParameterSetName = ResourceNameParameterSet, HelpUri = "https://learn.microsoft.com/powershell/module/az.network/get-azvirtualnetworkappliancecapability"), OutputType(typeof(PSVirtualNetworkApplianceCapability))]
    public class GetVirtualNetworkApplianceCapabilityCommand : VirtualNetworkApplianceCapabilityBaseCmdlet
    {
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The capability name.",
            ParameterSetName = ResourceNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Alias("ApplianceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the parent Virtual Network Appliance.",
            ParameterSetName = ResourceNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworkAppliances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string VirtualNetworkApplianceName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = ResourceNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource Id of the capability.",
            ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                ParseCapabilityResourceId(this.ResourceId, out string parsedResourceGroupName, out string parsedApplianceName, out string parsedCapabilityName);
                this.ResourceGroupName = parsedResourceGroupName;
                this.VirtualNetworkApplianceName = parsedApplianceName;
                this.Name = parsedCapabilityName;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                var capability = this.GetVirtualNetworkApplianceCapability(this.ResourceGroupName, this.VirtualNetworkApplianceName, this.Name);
                WriteObject(capability);
            }
            else
            {
                IPage<VirtualNetworkApplianceCapability> page = this.VirtualNetworkApplianceCapabilitiesClient.List(this.ResourceGroupName, this.VirtualNetworkApplianceName);
                var all = ListNextLink<VirtualNetworkApplianceCapability>.GetAllResourcesByPollingNextLink(page, this.VirtualNetworkApplianceCapabilitiesClient.ListNext);

                var results = new List<PSVirtualNetworkApplianceCapability>();
                foreach (var capability in all)
                {
                    results.Add(this.ToPsVirtualNetworkApplianceCapability(capability, this.ResourceGroupName, this.VirtualNetworkApplianceName));
                }

                WriteObject(results, true);
            }
        }
    }
}