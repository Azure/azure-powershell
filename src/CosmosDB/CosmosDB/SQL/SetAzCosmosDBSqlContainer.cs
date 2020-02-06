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
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.ContainerNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.SqlIndexingPolicyHelpMessage)]
        [ValidateNotNull]
        public PSSqlIndexingPolicy IndexingPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PartitionKeyVersionHelpMessage)]
        public int? PartitionKeyVersion { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.PartitionKeyKindHelpMessage)]
        public string PartitionKeyKind { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.PartitionKeyPathHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string[] PartitionKeyPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.SqlContainerThroughputHelpMessage)]
        public int? Throughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TtlInSecondsHelpMessage)]
        public int? TtlInSeconds { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.SqlUniqueKeyPolciyHelpMessage)]
        [ValidateNotNull]
        public PSSqlUniqueKeyPolicy UniqueKeyPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.SqlConflictResolutionPolicyModeHelpMessage)]
        [PSArgumentCompleter("Custom", "LastWriterWins", "Manual")]
        [ValidateNotNullOrEmpty]
        public string ConflictResolutionPolicyMode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.SqlConflictResolutionPolicyPathHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ConflictResolutionPolicyPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.SqlConflictResolutionPolicyProcedureHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ConflictResolutionPolicyProcedure { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.SqlConflictResolutionPolicyHelpMessage)]
        [ValidateNotNull]
        public PSSqlConflictResolutionPolicy ConflictResolutionPolicy { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.SqlDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public PSSqlDatabaseGetResults InputObject { get; set; }

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
                UniqueKeyPolicy uniqueKeyPolicy = new UniqueKeyPolicy
                {
                    UniqueKeys = new List<UniqueKey>()
                };

                foreach (PSUniqueKey uniqueKey in UniqueKeyPolicy.UniqueKeys)
                {
                    UniqueKey key = new UniqueKey
                    {
                        Paths = new List<string>()
                    };
                    
                    foreach(string path in uniqueKey.Paths)
                    {
                        key.Paths.Add(path);
                    }

                    uniqueKeyPolicy.UniqueKeys.Add(key);
                }

                sqlContainerResource.UniqueKeyPolicy = uniqueKeyPolicy;
            }

            if (TtlInSeconds != null)
            {
                sqlContainerResource.DefaultTtl = TtlInSeconds;
            }

            if(ConflictResolutionPolicy != null)
            {
                ConflictResolutionPolicyMode = ConflictResolutionPolicy.Mode;

                if (ConflictResolutionPolicy.ConflictResolutionPath != null)
                {
                    ConflictResolutionPolicyPath = ConflictResolutionPolicy.ConflictResolutionPath;
                }

                if (ConflictResolutionPolicy.ConflictResolutionProcedure != null)
                {
                    ConflictResolutionPolicyProcedure = ConflictResolutionPolicy.ConflictResolutionProcedure;
                }
            }

            if (ConflictResolutionPolicyMode != null)
            {
                ConflictResolutionPolicy conflictResolutionPolicy = new ConflictResolutionPolicy
                {
                    Mode = ConflictResolutionPolicyMode
                };

                if (ConflictResolutionPolicyMode.Equals("LastWriterWins", StringComparison.OrdinalIgnoreCase))
                {
                    conflictResolutionPolicy.ConflictResolutionPath = ConflictResolutionPolicyPath;
                }
                else if (ConflictResolutionPolicyMode.Equals("Custom", StringComparison.OrdinalIgnoreCase))
                {
                    conflictResolutionPolicy.ConflictResolutionProcedure = ConflictResolutionPolicyProcedure;
                }

                sqlContainerResource.ConflictResolutionPolicy = conflictResolutionPolicy;
            }

            if (IndexingPolicy != null)
            {
                IndexingPolicy indexingPolicy = new IndexingPolicy
                {
                    Automatic = IndexingPolicy.Automatic,
                    IndexingMode = IndexingPolicy.IndexingMode,
                };

                if (IndexingPolicy.IncludedPaths != null)
                {
                    IList<IncludedPath> includedPaths = new List<IncludedPath>();
                    foreach (PSIncludedPath pSIncludedPath in IndexingPolicy.IncludedPaths)
                    {
                        includedPaths.Add(new IncludedPath
                        {
                            Path = pSIncludedPath.Path,
                            Indexes = PSIncludedPath.ConvertPSIndexesToIndexes(pSIncludedPath.Indexes)
                        });
                    }

                    indexingPolicy.IncludedPaths = new List<IncludedPath>(includedPaths);
                }

                if (IndexingPolicy.ExcludedPaths != null && IndexingPolicy.ExcludedPaths.Count > 0)
                {
                    IList<ExcludedPath> excludedPaths = new List<ExcludedPath>();
                    foreach (PSExcludedPath pSExcludedPath in IndexingPolicy.ExcludedPaths)
                    {
                        excludedPaths.Add(new ExcludedPath { Path = pSExcludedPath.Path });
                    }

                    indexingPolicy.ExcludedPaths = new List<ExcludedPath>(excludedPaths);
                }

                if (IndexingPolicy.CompositeIndexes != null)
                {
                    IList<IList<CompositePath>> compositeIndexes = new List<IList<CompositePath>>();
                    foreach (IList<PSCompositePath> pSCompositePathList in IndexingPolicy.CompositeIndexes)
                    {
                        IList<CompositePath> compositePathList = new List<CompositePath>();
                        foreach (PSCompositePath pSCompositePath in pSCompositePathList)
                        {
                            compositePathList.Add(new CompositePath { Order = pSCompositePath.Order, Path = pSCompositePath.Path });
                        }

                        compositeIndexes.Add(compositePathList);
                    }

                    indexingPolicy.CompositeIndexes = new List<IList<CompositePath>>(compositeIndexes);
                }

                if (IndexingPolicy.SpatialIndexes != null && IndexingPolicy.SpatialIndexes.Count > 0)
                {
                    IList<SpatialSpec> spatialIndexes = new List<SpatialSpec>();

                    foreach (PSSpatialSpec pSSpatialSpec in IndexingPolicy.SpatialIndexes)
                    {
                        spatialIndexes.Add(new SpatialSpec { Path = pSSpatialSpec.Path, Types = pSSpatialSpec.Types });
                    }

                    indexingPolicy.SpatialIndexes = new List<SpatialSpec>(spatialIndexes);
                }

                sqlContainerResource.IndexingPolicy = indexingPolicy;
            }

            IDictionary<string, string> options = new Dictionary<string, string>();
            if (Throughput != null)
            {
                options.Add("Throughput", Throughput.ToString());
            }

            SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters = new SqlContainerCreateUpdateParameters
            {
                Resource = sqlContainerResource,
                Options = options
            };

            if (ShouldProcess(Name, "Setting CosmosDB Sql Container"))
            {
                SqlContainerGetResults sqlContainerGetResults = CosmosDBManagementClient.SqlResources.CreateUpdateSqlContainerWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, Name, sqlContainerCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSSqlContainerGetResults(sqlContainerGetResults));
            }

            return;
        }
    }
}
