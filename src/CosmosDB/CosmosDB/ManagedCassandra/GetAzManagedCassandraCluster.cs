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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using System;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedCassandraCluster", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSClusterResource))]
    public class GetAzManagedCassandraCluster : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ManagedCassandraClusterNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.ManagedCassandraClusterObjectHelpMessage)]
        [ValidateNotNull]
        public PSClusterResource InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!ParameterSetName.Equals(NameParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = null;
                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    resourceIdentifier = new ResourceIdentifier(ResourceId);
                }
                else if (ParameterSetName.Equals(ObjectParameterSet))
                {
                    resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                }
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                ClusterName = resourceIdentifier.ResourceName;
            }

            if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(ClusterName))
            {
                ClusterResource clusterResource = CosmosDBManagementClient.CassandraClusters.GetWithHttpMessagesAsync(ResourceGroupName, ClusterName).GetAwaiter().GetResult().Body;
                WriteObject(new PSClusterResource(clusterResource));
            }
            else if (!string.IsNullOrEmpty(ResourceGroupName))
            {
                IEnumerable<ClusterResource> clusterResources = CosmosDBManagementClient.CassandraClusters.ListByResourceGroupWithHttpMessagesAsync(ResourceGroupName).GetAwaiter().GetResult().Body;

                foreach (ClusterResource clusterResource in clusterResources)
                {
                    WriteObject(new PSClusterResource(clusterResource));
                }
            }
            else
            {
                IEnumerable<ClusterResource> clusterResources = CosmosDBManagementClient.CassandraClusters.ListBySubscriptionWithHttpMessagesAsync().GetAwaiter().GetResult().Body;

                foreach (ClusterResource clusterResource in clusterResources)
                {
                    WriteObject(new PSClusterResource(clusterResource));
                }
            }

            return;
        }
    }
}
