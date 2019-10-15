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
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.CosmosDB.Models;
using System.Reflection;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlContainer" , DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSSqlDatabase))]
    public class SetAzCosmosDBSqlContainer : AzureCosmosDBCmdletBase
    {

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ContainerNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.IndexingPolicyHelpMessage)]
        public PSSqlIndexingPolicy IndexingPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PartitionKeyPathHelpMessage)]
        public string PartitionKeyPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.SqlContainerThroughputHelpMessage)]
        public int? Throughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TtlInSecondsHelpMessage)]
        public int? TtlInSeconds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.UniqueKeyPolciyHelpMessage)]
        public PSSqlUniqueKeyPolicy UniqueKeyPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ConflictResolutionPolicyHelpMessage)]
        public PSConflictResolutionPolicy ConflictResolutionPolicy { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.SqlDatabaseObjectHelpMessage)]
        public PSSqlDatabase InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName.Equals(ParentObjectParameterSet))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                DatabaseName = resourceIdentifier.ResourceName;
                AccountName = resourceIdentifier.ParentResource;
            }

            SqlContainerCreateUpdateParametersInner createUpdateSqlContainerParameters = new SqlContainerCreateUpdateParametersInner();
            SqlContainerResource sqlContainerResource = new SqlContainerResource();
            if(TtlInSeconds != null)
            {
                sqlContainerResource.DefaultTtl = TtlInSeconds;
            }
            //if (IndexingPolicy != null)
            //{
            //    IndexingPolicy indexingPolicy = new IndexingPolicy();
            //    IncludedPath includedPath = new IncludedPath();
                
            //    foreach(string path in IndexingPolicy.Index)
            //    {
            //        includedPath.Path.
            //    }
            //    //sqlContainerResource.IndexingPolicy = new IndexingPolicy(includedPaths: IndexingPolicy.IncludedPath, excludedPaths: IndexingPolicy.ExcludedPath);
            //}

            if(UniqueKeyPolicy != null)
            {
                UniqueKeyPolicy uniqueKeyPolicy = new UniqueKeyPolicy();
                foreach (PSSqlUniqueKey uniqueKey in UniqueKeyPolicy.UniqueKey)
                {
                    UniqueKey key = new UniqueKey(uniqueKey.Path);
                    uniqueKeyPolicy.UniqueKeys.Add(key);
                }
                sqlContainerResource.UniqueKeyPolicy = uniqueKeyPolicy;
            }

            if(ConflictResolutionPolicy != null)
            {
                ConflictResolutionPolicy conflictResolutionPolicy = new ConflictResolutionPolicy();
                conflictResolutionPolicy.ConflictResolutionPath = ConflictResolutionPolicy.Path;
                conflictResolutionPolicy.ConflictResolutionProcedure = ConflictResolutionPolicy.StoredProcedureName;
                conflictResolutionPolicy.Mode = ConflictResolutionPolicy.Type;

                sqlContainerResource.ConflictResolutionPolicy = conflictResolutionPolicy;
            }

            var response = CosmosClient.DatabaseAccounts.BeginCreateUpdateSqlContainerWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, Name, createUpdateSqlContainerParameters).Result;
            return;
        }
    }
}
