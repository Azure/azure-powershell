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
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Rest.Azure;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Azure.Management.CosmosDB;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBMongoDBDatabase", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSMongoDBDatabaseGetResults), typeof(ConflictingResourceException))]
    public class NewAzCosmosDBMongoDBDatabase : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.MongoDatabaseThroughputHelpMessage)]
        public int? Throughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AutoscaleMaxThroughputHelpMessage)]
        public int? AutoscaleMaxThroughput { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [ValidateNotNull]
        public PSDatabaseAccountGetResults ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.ResourceName;
            }

            MongoDBDatabaseGetResults readMongoDatabaseGetResults = null;
            try
            {
                readMongoDatabaseGetResults = CosmosDBManagementClient.MongoDbResources.GetMongoDBDatabase(ResourceGroupName, AccountName, Name);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            if (readMongoDatabaseGetResults != null)
            {
                throw new ConflictingResourceException(message: string.Format(ExceptionMessage.Conflict, Name));
            }

            CreateUpdateOptions options = ThroughputHelper.PopulateCreateUpdateOptions(Throughput, AutoscaleMaxThroughput);

            MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters = new MongoDBDatabaseCreateUpdateParameters
            {
                Resource = new MongoDBDatabaseResource
                {
                    Id = Name
                },
                Options = options
            };

            if (ShouldProcess(Name, "Creating a new CosmosDB MongoDB Database"))
            {
                MongoDBDatabaseGetResults mongoDBDatabaseGetResults = CosmosDBManagementClient.MongoDbResources.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(ResourceGroupName, AccountName, Name, mongoDBDatabaseCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSMongoDBDatabaseGetResults(mongoDBDatabaseGetResults));
            }

            return;
        }
    }
}
