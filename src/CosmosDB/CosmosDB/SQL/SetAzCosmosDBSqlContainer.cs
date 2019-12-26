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
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlContainer" , DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSqlDatabaseGetResults))]
    public class SetAzCosmosDBSqlContainer : AzureCosmosDBCmdletBase
    {

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.ContainerNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.IndexingPolicyHelpMessage)]
        public PSSqlIndexingPolicy IndexingPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PartitionKeyVersionHelpMessage)]
        public int? PartitionKeyVersion { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.PartitionKeyKindHelpMessage)]
        public string PartitionKeyKind { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.PartitionKeyPathHelpMessage)]
        public string[] PartitionKeyPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.SqlContainerThroughputHelpMessage)]
        public int? Throughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TtlInSecondsHelpMessage)]
        public int? TtlInSeconds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.UniqueKeyPolciyHelpMessage)]
        public PSSqlUniqueKeyPolicy UniqueKeyPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ConflictResolutionPolicyHelpMessage)]
        public PSSqlConflictResolutionPolicy ConflictResolutionPolicy { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.SqlDatabaseObjectHelpMessage)]
        public PSSqlDatabaseGetResults InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                DatabaseName = resourceIdentifier.ResourceName;
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }

            List<string> Paths = new List<string>();

            foreach (string path in PartitionKeyPath)
                Paths.Add(path);

            SqlContainerResource sqlContainerResource = new SqlContainerResource
            {
                Id = Name,
                PartitionKey = new ContainerPartitionKey
                {
                    Kind = PartitionKeyKind,
                    Paths = Paths,
                    Version = PartitionKeyVersion
                }
            };

            if (UniqueKeyPolicy != null)
            {
                UniqueKeyPolicy uniqueKeyPolicy = new UniqueKeyPolicy();

                foreach (PSSqlUniqueKey uniqueKey in UniqueKeyPolicy.UniqueKey)
                {
                    UniqueKey key = new UniqueKey(uniqueKey.Path);
                    uniqueKeyPolicy.UniqueKeys.Add(key);
                }

                sqlContainerResource.UniqueKeyPolicy = uniqueKeyPolicy;
            }

            if (TtlInSeconds != null)
            {
                sqlContainerResource.DefaultTtl = TtlInSeconds;
            }

            if (ConflictResolutionPolicy != null)
            {
                ConflictResolutionPolicy conflictResolutionPolicy = new ConflictResolutionPolicy
                {
                    Mode = ConflictResolutionPolicy.Type
                };

                if (ConflictResolutionPolicy.Type.Equals("LastWriterWins", StringComparison.OrdinalIgnoreCase))
                {
                    conflictResolutionPolicy.ConflictResolutionPath = ConflictResolutionPolicy.Path;
                }
                else if (ConflictResolutionPolicy.Type.Equals("Custom", StringComparison.OrdinalIgnoreCase))
                {
                    conflictResolutionPolicy.ConflictResolutionProcedure = ConflictResolutionPolicy.ConflictResolutionProcedure;
                }

                sqlContainerResource.ConflictResolutionPolicy = conflictResolutionPolicy;
            }

            if(IndexingPolicy != null)
            {
                IList<IncludedPath> includedPaths = new List<IncludedPath>();
                IList<ExcludedPath> excludedPaths = new List<ExcludedPath>();

                foreach (string path in IndexingPolicy.IncludedPaths)
                    includedPaths.Add(new IncludedPath(path: path));

                foreach (string path in IndexingPolicy.IncludedPaths)
                    excludedPaths.Add(new ExcludedPath(path: path));

                IndexingPolicy indexingPolicy = new IndexingPolicy
                {
                    Automatic = IndexingPolicy.Automatic,
                    IndexingMode = IndexingPolicy.IndexingMode,
                    IncludedPaths = includedPaths,
                    ExcludedPaths = excludedPaths
                };

                sqlContainerResource.IndexingPolicy = indexingPolicy;
            }

            SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters = new SqlContainerCreateUpdateParameters
            {
                Resource = sqlContainerResource,
                Options = new Dictionary<string, string>() { }
            };

            SqlContainerGetResults sqlContainerGetResults = CosmosDBManagementClient.SqlResources.CreateUpdateSqlContainerWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, Name, sqlContainerCreateUpdateParameters).GetAwaiter().GetResult().Body;
            WriteObject(new PSSqlContainerGetResults(sqlContainerGetResults));

            return;
        }
    }
}
