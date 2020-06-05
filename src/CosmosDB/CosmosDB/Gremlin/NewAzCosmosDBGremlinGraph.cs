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

        [Parameter(Mandatory = false, HelpMessage = Constants.AutoscaleMaxThroughputHelpMessage)]
        public int? AutoscaleMaxThroughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TtlInSecondsHelpMessage)]
        public int? TtlInSeconds { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.UniqueKeyPolciyHelpMessage)]
        [ValidateNotNull]
        public PSUniqueKeyPolicy UniqueKeyPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ConflictResolutionPolicyModeHelpMessage)]
        [PSArgumentCompleter(ConflictResolutionMode.LastWriterWins, ConflictResolutionMode.Custom)]
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

            List<string> Paths = new List<string>(PartitionKeyPath);
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
                gremlinGraphResource.UniqueKeyPolicy = PSUniqueKeyPolicy.ToSDKModel(UniqueKeyPolicy);
            }

            if (TtlInSeconds != null)
            {
                gremlinGraphResource.DefaultTtl = TtlInSeconds;
            }

            if (ConflictResolutionPolicy != null)
            {
                gremlinGraphResource.ConflictResolutionPolicy = PSConflictResolutionPolicy.ToSDKModel(ConflictResolutionPolicy);
            }
            else if (ConflictResolutionPolicyMode != null)
            {
                ConflictResolutionPolicy conflictResolutionPolicy = new ConflictResolutionPolicy
                {
                    Mode = ConflictResolutionPolicyMode
                };

                if (ConflictResolutionPolicyMode.Equals(ConflictResolutionMode.LastWriterWins, StringComparison.OrdinalIgnoreCase))
                {
                    conflictResolutionPolicy.ConflictResolutionPath = ConflictResolutionPolicyPath;
                }
                else if (ConflictResolutionPolicyMode.Equals(ConflictResolutionMode.Custom, StringComparison.OrdinalIgnoreCase))
                {
                    conflictResolutionPolicy.ConflictResolutionProcedure = ConflictResolutionPolicyProcedure;
                }

                gremlinGraphResource.ConflictResolutionPolicy = conflictResolutionPolicy;
            }

            if (IndexingPolicy != null)
            {
                gremlinGraphResource.IndexingPolicy = PSIndexingPolicy.ToSDKModel(IndexingPolicy);
            }

            CreateUpdateOptions options = ThroughputHelper.PopulateCreateUpdateOptions(Throughput, AutoscaleMaxThroughput);

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
