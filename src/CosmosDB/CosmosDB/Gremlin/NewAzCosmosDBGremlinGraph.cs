﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Rest.Azure;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.Management.CosmosDB;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBGremlinGraph", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSGremlinGraphGetResults), typeof(Exception))]
    public class NewAzCosmosDBGremlinGraph : AzureCosmosDBCmdletBase
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

        [Parameter(Mandatory = true, HelpMessage = Constants.GraphNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.IndexingPolicyHelpMessage)]
        [ValidateNotNull]
        public PSIndexingPolicy IndexingPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PartitionKeyVersionHelpMessage)]
        public int? PartitionKeyVersion { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.PartitionKeyKindHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string PartitionKeyKind { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.PartitionKeyPathHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string[] PartitionKeyPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.GremlinGraphThroughputHelpMessage)]
        public int? Throughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TtlInSecondsHelpMessage)]
        public int? TtlInSeconds { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.UniqueKeyPolciyHelpMessage)]
        [ValidateNotNull]
        public PSUniqueKeyPolicy UniqueKeyPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ConflictResolutionPolicyModeHelpMessage)]
        [PSArgumentCompleter("Custom", "LastWriterWins", "Manual")]
        [ValidateNotNullOrEmpty]
        public string ConflictResolutionPolicyMode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ConflictResolutionPolicyPathHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ConflictResolutionPolicyPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ConflictResolutionPolicyProcedureHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ConflictResolutionPolicyProcedure { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.ConflictResolutionPolicyHelpMessage)]
        [ValidateNotNull]
        public PSConflictResolutionPolicy ConflictResolutionPolicy { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.GremlinDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public PSGremlinDatabaseGetResults ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                DatabaseName = resourceIdentifier.ResourceName;
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }

            GremlinGraphGetResults readGremlinGraphGetResults = null;
            try
            {
                readGremlinGraphGetResults = CosmosDBManagementClient.GremlinResources.GetGremlinGraph(ResourceGroupName, AccountName, DatabaseName, Name);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            if (readGremlinGraphGetResults != null)
            {
                throw new ConflictingResourceException(message: string.Format(ExceptionMessage.Conflict, Name));
            }

            List<string> Paths = new List<string>();
            foreach (string path in PartitionKeyPath)
                Paths.Add(path);

            GremlinGraphResource gremlinGraphResource = new GremlinGraphResource
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

                    foreach (string path in uniqueKey.Paths)
                    {
                        key.Paths.Add(path);
                    }

                    uniqueKeyPolicy.UniqueKeys.Add(key);
                }

                gremlinGraphResource.UniqueKeyPolicy = uniqueKeyPolicy;
            }

            if (TtlInSeconds != null)
            {
                gremlinGraphResource.DefaultTtl = TtlInSeconds;
            }

            if (ConflictResolutionPolicy != null)
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

                gremlinGraphResource.ConflictResolutionPolicy = conflictResolutionPolicy;
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

                gremlinGraphResource.IndexingPolicy = indexingPolicy;
            }

            IDictionary<string, string> options = new Dictionary<string, string>();
            if (Throughput != null)
            {
                options.Add("Throughput", Throughput.ToString());
            }

            GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters = new GremlinGraphCreateUpdateParameters
            {
                Resource = gremlinGraphResource,
                Options = options
            };

            if (ShouldProcess(Name, "Creating a new CosmosDB Gremlin Graph"))
            {
                GremlinGraphGetResults gremlinGraphGetResults = CosmosDBManagementClient.GremlinResources.CreateUpdateGremlinGraphWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, Name, gremlinGraphCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSGremlinGraphGetResults(gremlinGraphGetResults));
            }

            return;
        }
    }
}
