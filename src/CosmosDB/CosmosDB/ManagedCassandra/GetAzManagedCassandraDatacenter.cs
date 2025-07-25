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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedCassandraDatacenter", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSDataCenterResource))]
    public class GetAzManagedCassandraDatacenter: AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ManagedCassandraClusterNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ManagedCassandraDatacenterNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DataCenterName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.ManagedCassandraDatacenterObjectHelpMessage)]
        [ValidateNotNull]
        public PSDataCenterResource InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.ManagedCassandraClusterObjectHelpMessage)]
        [ValidateNotNull]
        public PSClusterResource ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            ResourceIdentifier resourceIdentifier = null;
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                ClusterName = resourceIdentifier.ResourceName;
            }
            else if (!ParameterSetName.Equals(NameParameterSet, StringComparison.Ordinal))
            {
                
                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    resourceIdentifier = new ResourceIdentifier(ResourceId);
                }
                else if (ParameterSetName.Equals(ObjectParameterSet))
                {
                    resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                }

                string[] segments = resourceIdentifier.ToString().Split(new[] { '/' });
                if (segments.Length != 11)
                {
                    throw new ArgumentException("ResourceId is not a valid for a Cassandra data center.");
                }
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                ClusterName = segments[8];
                DataCenterName = segments[10];
            }

            if (!string.IsNullOrEmpty(DataCenterName))
            {
                DataCenterResource dataCenterResource = CosmosDBManagementClient.CassandraDataCenters.GetWithHttpMessagesAsync(ResourceGroupName, ClusterName, DataCenterName).GetAwaiter().GetResult().Body;
                WriteObject(new PSDataCenterResource(dataCenterResource));
            }
            else 
            {
                IEnumerable<DataCenterResource> dataCenterResources = CosmosDBManagementClient.CassandraDataCenters.ListWithHttpMessagesAsync(ResourceGroupName, ClusterName).GetAwaiter().GetResult().Body;

                foreach (DataCenterResource dataCenterResource in dataCenterResources)
                {
                    WriteObject(new PSDataCenterResource(dataCenterResource));
                }                    
            }

            return;
        }
    }
}
