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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBMongoDBCollection", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSMongoDBCollectionGetResults), typeof(ConflictingResourceException))]
    public class NewAzCosmosDBMongoDBCollection : AzureCosmosDBCmdletBase
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

        [Parameter(Mandatory = true, HelpMessage = Constants.CollectionNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.SqlContainerThroughputHelpMessage)]
        public int? Throughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AutoscaleMaxThroughputHelpMessage)]
        public int? AutoscaleMaxThroughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.MongoShardKeyHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Shard { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.MongoCollectionAnalyticalStorageTtlHelpMessage)]
        public int? AnalyticalStorageTtl { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.MongoIndexHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSMongoIndex[] Index { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.MongoDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public PSMongoDBDatabaseGetResults ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                DatabaseName = resourceIdentifier.ResourceName;
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }

            MongoDBCollectionGetResults readMongoDBCollectionGetResults = null;
            try
            {
                readMongoDBCollectionGetResults = CosmosDBManagementClient.MongoDBResources.GetMongoDBCollection(ResourceGroupName, AccountName, DatabaseName, Name);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            if (readMongoDBCollectionGetResults != null)
            {
                throw new ConflictingResourceException(message: string.Format(ExceptionMessage.Conflict, Name));
            }

            MongoDBCollectionResource mongoDBCollectionResource = new MongoDBCollectionResource
            {
                Id = Name
            };

            if(Shard != null)
            {
                mongoDBCollectionResource.ShardKey = new Dictionary<string, string> { { Shard, "Hash" } };
            }

            if(Index != null)
            {
                List<MongoIndex> Indexes = new List<MongoIndex>();                
                foreach(PSMongoIndex psMongoIndex in Index)
                {
                    Indexes.Add(PSMongoIndex.ToSDKModel(psMongoIndex));
                }

                mongoDBCollectionResource.Indexes = Indexes;
            }

            if(AnalyticalStorageTtl != null)
            {
                mongoDBCollectionResource.AnalyticalStorageTtl = AnalyticalStorageTtl;
            }

            CreateUpdateOptions options = ThroughputHelper.PopulateCreateUpdateOptions(Throughput, AutoscaleMaxThroughput);

            MongoDBCollectionCreateUpdateParameters mongoDBCollectionCreateUpdateParameters = new MongoDBCollectionCreateUpdateParameters
            {
                Resource = mongoDBCollectionResource,
                Options = options
            };

            if (ShouldProcess(Name, "Creating a new CosmosDB MongoDB Collection"))
            {
                MongoDBCollectionGetResults mongoDBCollectionGetResults = CosmosDBManagementClient.MongoDBResources.CreateUpdateMongoDBCollectionWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, Name, mongoDBCollectionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSMongoDBCollectionGetResults(mongoDBCollectionGetResults));
            }

            return;
        }
    }
}
