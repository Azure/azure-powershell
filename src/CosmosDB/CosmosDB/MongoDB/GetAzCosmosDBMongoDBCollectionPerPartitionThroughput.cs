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

using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.CosmosDB;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBMongoDBCollectionPerPartitionThroughput", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSPhysicalPartitionThroughputInfo))]
    public class GetAzCosmosDBMongoDBCollectionPerPartitionThroughput : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName;

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ContainerNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.SqlDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public PSSqlDatabaseGetResults ParentObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.SqlContainerObjectHelpMessage)]
        [ValidateNotNull]
        public PSSqlContainerGetResults InputObject { get; set; }        

        [Parameter(Mandatory = false, HelpMessage = Constants.PhysicalPartitionIdsHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string[] PhysicalPartitionIds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.GetAllPhysicalPartitionsThroughputHelpMessage)]        
        public SwitchParameter AllPartitions { get; set; }

        public void PopulateFromParentObject()
        {
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
            ResourceGroupName = resourceIdentifier.ResourceGroupName;
            DatabaseName = resourceIdentifier.ResourceName;
            AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
        }

        public void PopulateFromInputObject()
        {
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
            ResourceGroupName = resourceIdentifier.ResourceGroupName;
            Name = resourceIdentifier.ResourceName;
            DatabaseName = ResourceIdentifierExtensions.GetSqlDatabaseName(resourceIdentifier);
            AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
        }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                PopulateFromParentObject();
            }
            else if (ParameterSetName.Equals(ObjectParameterSet, StringComparison.Ordinal))
            {
                PopulateFromInputObject();
            }

            if (ShouldProcess(Name, "Retrieving throughput distribution."))
            {
                List<PhysicalPartitionId> physicalPartitionIds = new List<PhysicalPartitionId>();
                if (this.AllPartitions.IsPresent)
                {
                    physicalPartitionIds.Add(new PhysicalPartitionId("-1"));
                }
                else
                {
                    if(this.PhysicalPartitionIds == null)
                    {
                        throw new ArgumentException("List of PhysicalPartitionId cannot be null if the 'AllPartitions' switch is not enabled.");
                    }

                    foreach (string physicalPartitionId in this.PhysicalPartitionIds)
                    {
                        if(string.IsNullOrEmpty(physicalPartitionId))
                        {
                            throw new ArgumentException("PhysicalPartitionId cannot be null or empty.");
                        }

                        physicalPartitionIds.Add(new PhysicalPartitionId(physicalPartitionId));
                    }
                }

                RetrieveThroughputParameters retrieveThroughputParameters = new RetrieveThroughputParameters();
                retrieveThroughputParameters.Resource = new RetrieveThroughputPropertiesResource(physicalPartitionIds);

                PhysicalPartitionThroughputInfoResult physicalPartitionThroughputInfoResult = 
                    CosmosDBManagementClient.MongoDBResources.MongoDBContainerRetrieveThroughputDistribution(
                        this.ResourceGroupName, 
                        this.AccountName, 
                        this.DatabaseName, 
                        this.Name, 
                        retrieveThroughputParameters);

                List<PSPhysicalPartitionThroughputInfo> physicalPartitionThroughputInfos = new List<PSPhysicalPartitionThroughputInfo>();
                foreach (PhysicalPartitionThroughputInfoResource item in physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo)
                {
                    physicalPartitionThroughputInfos.Add(new PSPhysicalPartitionThroughputInfo(item.Id, item.Throughput.Value));
                }

                WriteObject(physicalPartitionThroughputInfos);
            }
        }
    }   
}
