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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AvailabilitySet", SupportsShouldProcess = true)]
    [OutputType(typeof(PSAvailabilitySet))]
    public class UpdateAzureAvailabilitySetCommand : AvailabilitySetBaseCmdlet
    {
        private const string SkuParameterSetName = "SkuParameterSet";

        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public PSAvailabilitySet AvailabilitySet { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            ParameterSetName = SkuParameterSetName,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The Name of Sku")]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false)]
        [AllowEmptyString]
        public string ProximityPlacementGroupId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Key-value pairs in the form of a hash table."
            )]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the api-version to determine which Scheduled Events configuration schema version will be delivered. Format: YYYY-MM-DD")]
        public string ScheduledEventsApiVersion { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies if Scheduled Events should be auto-approved when all instances are down.")]
        public bool? EnableAllInstancesDown { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(AvailabilitySet.Name, VerbsData.Update))
            {
                base.ExecuteCmdlet();

                ExecuteClientAction(() =>
                {
                    var avSetParams = new AvailabilitySet
                    {
                        Location = this.AvailabilitySet.Location,
                        PlatformUpdateDomainCount = this.AvailabilitySet.PlatformUpdateDomainCount,
                        PlatformFaultDomainCount = this.AvailabilitySet.PlatformFaultDomainCount,
                        Tags = Tag == null ? null : Tag.Cast<DictionaryEntry>().ToDictionary(d => (string)d.Key, d => (string)d.Value),
                        Sku = new Sku(this.IsParameterBound(c => c.Sku) ? this.Sku : this.AvailabilitySet.Sku, null, null),
                        ProximityPlacementGroup = this.IsParameterBound(c => c.ProximityPlacementGroupId) 
                                                ? new SubResource(this.ProximityPlacementGroupId)
                                                : this.AvailabilitySet.ProximityPlacementGroup
                    };

                    if (avSetParams.ProximityPlacementGroup != null && string.IsNullOrEmpty(avSetParams.ProximityPlacementGroup.Id))
                    {
                        avSetParams.ProximityPlacementGroup.Id = null;
                    }

                    if (this.IsParameterBound(c => c.ScheduledEventsApiVersion) || this.IsParameterBound(c => c.EnableAllInstancesDown))
                    {
                        if (avSetParams.ScheduledEventsPolicy == null)
                        {
                            avSetParams.ScheduledEventsPolicy = new ScheduledEventsPolicy();
                        }

                        if (this.IsParameterBound(c => c.ScheduledEventsApiVersion))
                        {
                            if (avSetParams.ScheduledEventsPolicy.ScheduledEventsAdditionalPublishingTargets == null)
                            {
                                avSetParams.ScheduledEventsPolicy.ScheduledEventsAdditionalPublishingTargets = new ScheduledEventsAdditionalPublishingTargets();
                            }
                            if (avSetParams.ScheduledEventsPolicy.ScheduledEventsAdditionalPublishingTargets.EventGridAndResourceGraph == null)
                            {
                                avSetParams.ScheduledEventsPolicy.ScheduledEventsAdditionalPublishingTargets.EventGridAndResourceGraph = new EventGridAndResourceGraph();
                            }
                            avSetParams.ScheduledEventsPolicy.ScheduledEventsAdditionalPublishingTargets.EventGridAndResourceGraph.ScheduledEventsApiVersion = this.ScheduledEventsApiVersion;
                        }

                        if (this.IsParameterBound(c => c.EnableAllInstancesDown))
                        {
                            if (avSetParams.ScheduledEventsPolicy.AllInstancesDown == null)
                            {
                                avSetParams.ScheduledEventsPolicy.AllInstancesDown = new AllInstancesDown();
                            }
                            avSetParams.ScheduledEventsPolicy.AllInstancesDown.AutomaticallyApprove = this.EnableAllInstancesDown;
                        }
                    }

                    var result = this.AvailabilitySetClient.CreateOrUpdateWithHttpMessagesAsync(
                        this.AvailabilitySet.ResourceGroupName,
                        this.AvailabilitySet.Name,
                        avSetParams).GetAwaiter().GetResult();

                    var psResult = ComputeAutoMapperProfile.Mapper.Map<PSAvailabilitySet>(result);
                    if (result.Body != null)
                    {
                        psResult = ComputeAutoMapperProfile.Mapper.Map(result.Body, psResult);
                    }
                    WriteObject(psResult);
                });
            }
        }
    }
}
