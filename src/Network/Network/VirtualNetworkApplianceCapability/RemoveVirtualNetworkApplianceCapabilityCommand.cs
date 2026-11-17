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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkApplianceCapability", SupportsShouldProcess = true, DefaultParameterSetName = ResourceNameParameterSet, HelpUri = "https://learn.microsoft.com/powershell/module/az.network/remove-azvirtualnetworkappliancecapability"), OutputType(typeof(bool))]
    public class RemoveVirtualNetworkApplianceCapabilityCommand : VirtualNetworkApplianceCapabilityBaseCmdlet
    {
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
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

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Virtual Network Appliance capability object.",
            ParameterSetName = InputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetworkApplianceCapability InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

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
            else if (ParameterSetName.Equals(InputObjectParameterSet))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.VirtualNetworkApplianceName = this.InputObject.VirtualNetworkApplianceName;
                this.Name = this.InputObject.Name;
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, Name),
                Properties.Resources.RemoveResourceMessage,
                Name,
                () =>
                {
                    this.VirtualNetworkApplianceCapabilitiesClient.Delete(this.ResourceGroupName, this.VirtualNetworkApplianceName, this.Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
