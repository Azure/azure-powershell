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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.EventHub.Commands.EventHub
{
    /// <summary>
    /// 'New-AzEventHubCluster' Cmdlet creates a new Cluster in the specified ResourceGroup and Location
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubCluster", DefaultParameterSetName = ClusterPropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSEventHubClusterAttributes))]
    public class NewAzureRmEventHubCluster : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Cluster Name")]
        [Parameter(Mandatory = true, ParameterSetName = ClusterResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Cluster Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Location of Cluster")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Cluster Capacity (CU), curerntrly, allowed value = 1")]
        [ValidateNotNullOrEmpty]
        public int? Capacity { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Hashtables which represents resource Tags for Clusters")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ClusterResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Resource ID of Cluster")]
        [Parameter(Mandatory = false, ParameterSetName = ClusterPropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource ID of Cluster")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }


        public override void ExecuteCmdlet()
        {

            PSEventHubClusterAttributes cluster = new PSEventHubClusterAttributes(); 

            if (ParameterSetName.Equals(ClusterPropertiesParameterSet))
            {
                cluster.Location = Location;
                if (this.IsParameterBound(c => c.Capacity))
                {
                    cluster.Sku.Capacity = Capacity;
                }
                else
                {
                    cluster.Sku.Capacity = 1;
                }

                if (this.IsParameterBound(c => c.Tag))
                {
                    cluster.Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);
                }                               
            }

            if (ParameterSetName.Equals(ClusterResourceIdParameterSet))
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(ResourceId);
                cluster = Client.GetEventHubCluster(identifier.ResourceGroupName, identifier.ResourceName);
                cluster.Name = Name; 
            }

            if (ShouldProcess(target:cluster.Name, action:string.Format("Create cluster {0} in ResourveGroup - {1}",cluster.Name,ResourceGroupName)))
            {
                try
                {
                    WriteObject(Client.CreateOrUpdateEventHubCluster(ResourceGroupName, Name, cluster));
                }
                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
            }
                        
        }
    }
}
