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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InterconnectBlock", SupportsShouldProcess = true)]
    [OutputType(typeof(PSInterconnectBlock))]
    public class NewAzureInterconnectBlock : ComputeAutomationBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Compute/interconnectBlocks")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ARM resource ID of the Microsoft.Network/interconnectGroups resource. Required at create and immutable thereafter.")]
        [ValidateNotNullOrEmpty]
        public string InterconnectGroupId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The VM SKU name for the Interconnect Block (e.g. Standard_ND128isr_GB300_v6). Immutable after create.")]
        [ValidateNotNullOrEmpty]
        public string SkuName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The number of VM instances to reserve. Must be a multiple of 18.")]
        public long SkuCapacity { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The availability zones for the Interconnect Block. Immutable after create.")]
        public string[] Zone { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The SKU tier.")]
        public string SkuTier { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "List of availability zones to exclude from placement.")]
        public string[] PlacementExcludeZone { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "List of availability zones to include for placement.")]
        public string[] PlacementIncludeZone { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The zone placement policy. Accepted value: Any.")]
        public string PlacementZonePlacementPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Name, VerbsCommon.New))
                {
                    var interconnectBlock = new InterconnectBlock();
                    interconnectBlock.Location = this.Location;

                    interconnectBlock.Sku = new Sku();
                    interconnectBlock.Sku.Name = this.SkuName;
                    interconnectBlock.Sku.Capacity = this.SkuCapacity;

                    if (this.IsParameterBound(c => c.SkuTier))
                    {
                        interconnectBlock.Sku.Tier = this.SkuTier;
                    }

                    if (this.IsParameterBound(c => c.Zone))
                    {
                        interconnectBlock.Zones = this.Zone;
                    }

                    if (this.IsParameterBound(c => c.Tag))
                    {
                        interconnectBlock.Tags = this.Tag.Cast<DictionaryEntry>().ToDictionary(ht => (string)ht.Key, ht => (string)ht.Value);
                    }

                    if (this.IsParameterBound(c => c.PlacementExcludeZone) ||
                        this.IsParameterBound(c => c.PlacementIncludeZone) ||
                        this.IsParameterBound(c => c.PlacementZonePlacementPolicy))
                    {
                        interconnectBlock.Placement = new Placement();
                        if (this.IsParameterBound(c => c.PlacementExcludeZone))
                        {
                            interconnectBlock.Placement.ExcludeZones = this.PlacementExcludeZone;
                        }
                        if (this.IsParameterBound(c => c.PlacementIncludeZone))
                        {
                            interconnectBlock.Placement.IncludeZones = this.PlacementIncludeZone;
                        }
                        if (this.IsParameterBound(c => c.PlacementZonePlacementPolicy))
                        {
                            interconnectBlock.Placement.ZonePlacementPolicy = this.PlacementZonePlacementPolicy;
                        }
                    }

                    interconnectBlock.Properties = new InterconnectBlockProperties(
                        interconnectGroup: new ApiEntityReference { Id = this.InterconnectGroupId });

                    var result = InterconnectBlocksClient.CreateOrUpdate(this.ResourceGroupName, this.Name, interconnectBlock);
                    var psObject = new PSInterconnectBlock();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<InterconnectBlock, PSInterconnectBlock>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }
    }
}
