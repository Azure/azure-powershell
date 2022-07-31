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

using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Management.EventHub.Models;
using System;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.EventHub.Commands.EventHub
{
    /// <summary>
    /// 'Set-AzEventHubCluster' Cmdlet updates the specified Cluster details
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubCluster", DefaultParameterSetName = ClusterPropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSEventHubClusterAttributes))]
    public class SetAzureEventHubCluster : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }


        [CmdletParameterBreakingChange("Name", ChangeDescription = "'Name' Parameter is being deprecated from " + ClusterResourceIdParameterSet + " without being replaced. ResourceId's are implicit of resource name.")]
        [Parameter(Mandatory = true, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Cluster Name")]
        [Parameter(Mandatory = false, ParameterSetName = ClusterResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Cluster Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }


        [CmdletParameterBreakingChange("Location", ChangeDescription = "Location Parameter is being deprecated without being replaced")]
        [Parameter(Mandatory = false, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of Cluster")]
        public string Location { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Cluster Capacity (CU), curerntrly, allowed value = 1")]
        [Parameter(Mandatory = false, ParameterSetName = ClusterResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Cluster Capacity (CU), curerntrly, allowed value = 1")]
        public int? Capacity { get; set; }


        [Parameter(Mandatory = true, ParameterSetName = ClusterInputObjectParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Cluster Name")]
        [ValidateNotNullOrEmpty]
        public PSEventHubClusterAttributes InputObject { get; set; }


        [Parameter(Mandatory = true, ParameterSetName = ClusterResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Resource ID of Cluster")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Hashtables which represents resource Tags for Clusters")]
        [Parameter(Mandatory = false, ParameterSetName = ClusterResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Hashtables which represents resource Tags for Clusters")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ClusterInputObjectParameterSet) || ParameterSetName.Equals(ClusterResourceIdParameterSet))
            {
                ResourceId = ResourceId ?? InputObject?.Id;
                ResourceIdParser resourceIdParser = new ResourceIdParser(1, ResourceId, ClusterURL);
                ResourceGroupName = resourceIdParser.ResourceGroupName;
                Name = resourceIdParser.TopLevelResourceName;
            }

            if (ShouldProcess(target: Name, action: string.Format("Update cluster {0} in ResourceGroup {1}", Name, ResourceGroupName)))
            {
                try
                {
                    Cluster clusterPayload = UtilityClient.GetEventHubCluster(ResourceGroupName, Name);
                    Cluster updatedPayload = null;

                    if (ParameterSetName.Equals(ClusterPropertiesParameterSet) || ParameterSetName.Equals(ClusterResourceIdParameterSet))
                    {
                        updatedPayload = UpdateClusterPayload(clusterPayload);
                    }

                    else if (ParameterSetName.Equals(ClusterInputObjectParameterSet))
                    {
                        updatedPayload = MapInputObject();
                    }

                    PSEventHubClusterAttributes updatedCluster = new PSEventHubClusterAttributes(UtilityClient.CreateOrUpdateEventHubCluster(ResourceGroupName, Name, updatedPayload));
                    WriteObject(updatedCluster);
                }
                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
                catch (Exception ex)
                {
                    WriteError(new ErrorRecord(ex, ex.Message, ErrorCategory.OpenError, ex));
                }
            }
        }

        internal Cluster MapInputObject()
        {
            Cluster cluster = new Cluster()
            {
                Location = InputObject.Location,
                SupportsScaling = InputObject.SupportsScaling,
                Tags = InputObject.Tags
            };

            if (InputObject.Capacity != null)
            {
                cluster.Sku = new ClusterSku()
                {
                    Capacity = InputObject.Capacity
                };
            }

            return cluster;
        }

        internal Cluster UpdateClusterPayload(Cluster cluster)
        {
            if (this.IsParameterBound(c => c.Capacity))
            {
                cluster.Sku.Capacity = Capacity;
            }

            if (this.IsParameterBound(c => c.Tag))
            {
                cluster.Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);
            }

            if (this.IsParameterBound(c => c.Location))
            {
                cluster.Location = Location;
            }

            return cluster;
        }
    }
}
