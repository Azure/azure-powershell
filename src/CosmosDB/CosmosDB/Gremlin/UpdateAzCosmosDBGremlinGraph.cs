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
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBGremlinGraph", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSGremlinGraphGetResults), typeof(ResourceNotFoundException))]
    public class UpdateAzCosmosDBGremlinGraph : AzureCosmosDBCmdletBase
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

        [Parameter(Mandatory = false, HelpMessage = Constants.GraphNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.IndexingPolicyHelpMessage)]
        [ValidateNotNull]
        public PSIndexingPolicy IndexingPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PartitionKeyVersionHelpMessage)]
        public int? PartitionKeyVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PartitionKeyKindHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string PartitionKeyKind { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PartitionKeyPathHelpMessage)]
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
        [PSArgumentCompleter(ConflictResolutionMode.Custom, ConflictResolutionMode.LastWriterWins)]
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

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.GremlinGraphObjectHelpMessage)]
        [ValidateNotNull]
        public PSGremlinGraphGetResults InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                DatabaseName = resourceIdentifier.ResourceName;
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }
            else if (ParameterSetName.Equals(ObjectParameterSet))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                DatabaseName = ResourceIdentifierExtensions.GetGremlinDatabaseName(resourceIdentifier);
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
                Name = resourceIdentifier.ResourceName;
            }

            GremlinGraphGetResults readGremlinGraphGetResults = null;
            try
            {
                readGremlinGraphGetResults = CosmosDBManagementClient.GremlinResources.GetGremlinGraph(ResourceGroupName, AccountName, DatabaseName, Name);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(message: string.Format(ExceptionMessage.NotFound, Name), innerException: e);
                }
            }

            GremlinGraphResource gremlinGraphResource = UpdateAzCosmosDBGremlinGraph.PopulateGremlinGraphResourceResource(readGremlinGraphGetResults.Resource);

            if (PartitionKeyPath != null)
            {
                List<string> Paths = new List<string>(PartitionKeyPath);

                gremlinGraphResource.PartitionKey = new ContainerPartitionKey
                {
                    Kind = PartitionKeyKind,
                    Paths = Paths,
                    Version = PartitionKeyVersion
                };
            }

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

            if (ConflictResolutionPolicyMode != null)
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

            if (ShouldProcess(Name, "Updating CosmosDB Gremlin Graph"))
            {
                GremlinGraphGetResults gremlinGraphGetResults = CosmosDBManagementClient.GremlinResources.CreateUpdateGremlinGraphWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, Name, gremlinGraphCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSGremlinGraphGetResults(gremlinGraphGetResults));
            }

            return;
        }

        private static GremlinGraphResource PopulateGremlinGraphResourceResource(GremlinGraphGetPropertiesResource resource)
        {
            return new GremlinGraphResource
            {
                ConflictResolutionPolicy = resource.ConflictResolutionPolicy,
                UniqueKeyPolicy = resource.UniqueKeyPolicy,
                DefaultTtl = resource.DefaultTtl,
                Id = resource.Id,
                IndexingPolicy = resource.IndexingPolicy,
                PartitionKey = resource.PartitionKey
            };
        }
    }
}
