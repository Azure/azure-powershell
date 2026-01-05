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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkAppliance", SupportsShouldProcess = true, DefaultParameterSetName = ResourceNameParameterSet, HelpUri = "https://learn.microsoft.com/powershell/module/az.network/new-azvirtualnetworkappliance"), OutputType(typeof(PSVirtualNetworkAppliance))]
    public class NewVirtualNetworkApplianceCommand : VirtualNetworkApplianceBaseCmdlet
    {
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = ResourceNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

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
            HelpMessage = "The location.")]
        [LocationCompleter("Microsoft.Network/virtualNetworkAppliances")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The subnet resource ID for the Virtual Network Appliance.")]
        [ValidateNotNullOrEmpty]
        public virtual string SubnetId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bandwidth of the Virtual Network Appliance in Gbps. Valid values are: 50, 100, 200.")]
        [ValidateNotNullOrEmpty]
        public virtual string BandwidthInGbps { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var present = this.IsVirtualNetworkAppliancePresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var vna = CreateVirtualNetworkAppliance();
                    WriteObject(vna);
                },
                () => present);
        }

        private PSVirtualNetworkAppliance CreateVirtualNetworkAppliance()
        {
            var vnaModel = new VirtualNetworkAppliance
            {
                Location = this.Location,
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true),
                Subnet = new Subnet { Id = this.SubnetId }
            };

            // Set bandwidth (required)
            vnaModel.BandwidthInGbps = this.BandwidthInGbps;

            // Create the resource
            var vnaResponse = this.VirtualNetworkAppliancesClient.CreateOrUpdate(this.ResourceGroupName, this.Name, vnaModel);

            var psVna = this.ToPsVirtualNetworkAppliance(vnaResponse);
            psVna.ResourceGroupName = this.ResourceGroupName;

            return psVna;
        }
    }
}
