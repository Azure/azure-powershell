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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkApplianceCapability", SupportsShouldProcess = true, DefaultParameterSetName = ResourceNameParameterSet, HelpUri = "https://learn.microsoft.com/powershell/module/az.network/new-azvirtualnetworkappliancecapability"), OutputType(typeof(PSVirtualNetworkApplianceCapability))]
    public class NewVirtualNetworkApplianceCapabilityCommand : VirtualNetworkApplianceCapabilityBaseCmdlet
    {
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";

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
            HelpMessage = "The capability kind. Possible values: PLGatewayFastpath, PLGateway, PLIPForwarders, NAT64.")]
        [ValidateSet("PLGatewayFastpath", "PLGateway", "PLIPForwarders", "NAT64", IgnoreCase = true)]
        public virtual string Kind { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The IP version the capability applies to. Required for the Private Link kinds: PLGatewayFastpath requires DualStack; PLGateway and PLIPForwarders require IPv6. Must not be set for NAT64 (property-less). Possible values: IPv6, DualStack.")]
        [ValidateSet("IPv6", "DualStack", IgnoreCase = true)]
        public virtual string IpVersion { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            // Validate and build the payload before any service call so client-side errors (e.g. an unsupported
            // kind/ipVersion combination) surface without network I/O.
            var parameters = BuildCapabilityParameters(this.Kind, this.IpVersion);

            var present = this.IsVirtualNetworkApplianceCapabilityPresent(this.ResourceGroupName, this.VirtualNetworkApplianceName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var response = this.VirtualNetworkApplianceCapabilitiesClient.CreateOrUpdate(this.ResourceGroupName, this.VirtualNetworkApplianceName, this.Name, parameters);
                    var capability = ToPsVirtualNetworkApplianceCapability(response, this.ResourceGroupName, this.VirtualNetworkApplianceName);
                    WriteObject(capability);
                },
                () => present);
        }
    }
}
