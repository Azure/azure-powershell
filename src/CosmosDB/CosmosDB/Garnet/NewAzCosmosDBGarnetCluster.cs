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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBGarnetCluster", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSGarnetClusterResource), typeof(ConflictingResourceException))]
    public class NewAzCosmosDBGarnetCluster : NewOrUpdateAzGarnetCluster
    {
        [Parameter(Mandatory = true, HelpMessage = Constants.GarnetClusterLocationHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.GarnetClusterSubnetIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.GarnetClusterReplicationFactorHelpMessage)]
        public int? ReplicationFactor { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.GarnetClusterShardCountHelpMessage)]
        public int? ShardCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.GarnetClusterNodeSkuHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string NodeSku { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.GarnetClusterAvailabilityZoneHelpMessage)]
        public bool? AvailabilityZone { get; set; }

        public override void ExecuteCmdlet()
        {
            GarnetClusterResource existingCluster = null;
            try
            {
                existingCluster = CosmosDBManagementClient.GarnetClusters.GetWithHttpMessagesAsync(ResourceGroupName, ClusterName).GetAwaiter().GetResult().Body;
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            if (existingCluster != null)
            {
                throw new ConflictingResourceException(message: string.Format(ExceptionMessage.Conflict, ClusterName));
            }

            Dictionary<string, string> tagsDict = new Dictionary<string, string>();
            if (Tag != null)
            {
                tagsDict = base.PopulateTags(Tag);
            }

            IList<string> extensionsList = null;
            if (Extensions != null)
            {
                extensionsList = new List<string>(Extensions);
            }

            GarnetClusterResource clusterCreateParameters = new GarnetClusterResource
            {
                Properties = new GarnetClusterResourceProperties
                {
                    SubnetId = SubnetId,
                    ReplicationFactor = ReplicationFactor,
                    ShardCount = ShardCount,
                    NodeSku = NodeSku,
                    AvailabilityZone = AvailabilityZone,
                    AuthenticationMethod = AuthenticationMethod,
                    Persistence = Persistence,
                    ClusterType = ClusterType,
                    Extensions = extensionsList,
                },
                Location = Location,
                Tags = tagsDict
            };

            if (ShouldProcess(ClusterName, "Creating a new Garnet Cluster"))
            {
                GarnetClusterResource result = CosmosDBManagementClient.GarnetClusters.CreateUpdateWithHttpMessagesAsync(ResourceGroupName, ClusterName, clusterCreateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSGarnetClusterResource(result));
            }

            return;
        }
    }
}
