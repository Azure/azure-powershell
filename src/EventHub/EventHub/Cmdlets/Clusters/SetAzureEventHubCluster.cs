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
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.EventHub
{
    /// <summary>
    /// 'Set-AzEventHub' Cmdlet updates the specified EventHub
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubCluster", DefaultParameterSetName = ClusterPropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSEventHubClusterAttributes))]
    public class SetAzureEventHubCluster : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Cluster Name")]
        [Parameter(Mandatory = true, ParameterSetName = ClusterResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Cluster Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of Cluster")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Cluster Capacity (CU), curerntrly, allowed value = 1")]
        [ValidateNotNullOrEmpty]
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
            PSEventHubClusterAttributes cluster = new PSEventHubClusterAttributes();

            if (ParameterSetName.Equals(ClusterInputObjectParameterSet))
            {
                cluster = InputObject;
                cluster.Name = Name;
                cluster.Location = InputObject.Location;
            }

            if (ParameterSetName.Equals(ClusterPropertiesParameterSet))
            {
                if (Tag != null)
                {
                    cluster.Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);
                }               

                if (Capacity != null)
                {
                    cluster.Sku.Capacity = Capacity;
                }
                else
                {
                    cluster.Sku.Capacity = 1;
                }

                if (Location != null)
                {
                    cluster.Location = Location;
                }
                else
                {
                    // Get a EventHub
                    PSEventHubClusterAttributes clusterGet = Client.GetEventHubCluster(ResourceGroupName, Name);
                    cluster.Location = clusterGet.Location;
                }
            }

            if (ShouldProcess(target: cluster.Name, action: string.Format(Resources.CreateEventHub, cluster.Name, Name)))
            {
                try
                {
                    WriteObject(Client.UpdateEventHubCluster(ResourceGroupName, Name, cluster));
                }
                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
            }
        }
    }
}
