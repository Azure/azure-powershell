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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBMongoDBCollection", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSMongoDBCollectionGetResults), typeof(PSThroughputSettingsGetResults))]
    public class GetAzCosmosDBMongoDBCollection : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName;

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName;

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.CollectionNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.MongoDatabaseObjectHelpMessage )]
        [ValidateNotNull]
        public PSMongoDBDatabaseGetResults InputObject{ get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.MongoCollectionDetailedParamHelpMessage)]
        public SwitchParameter Detailed { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                DatabaseName = resourceIdentifier.ResourceName;
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }

            if (!string.IsNullOrEmpty(Name))
            {
                MongoDBCollectionGetResults mongoDBCollectionGetResults = CosmosDBManagementClient.MongoDBResources.GetMongoDBCollectionWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSMongoDBCollectionGetResults(mongoDBCollectionGetResults));

                if (Detailed)
                {
                    ThroughputSettingsGetResults throughputSettingsGetResults = CosmosDBManagementClient.MongoDBResources.GetMongoDBCollectionThroughputWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, Name).GetAwaiter().GetResult().Body;
                    WriteObject(throughputSettingsGetResults);
                }
            }
            else
            {
                IEnumerable<MongoDBCollectionGetResults> mongoDBCollections = CosmosDBManagementClient.MongoDBResources.ListMongoDBCollectionsWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName).GetAwaiter().GetResult().Body;
                
                foreach(MongoDBCollectionGetResults mongoDBCollection in mongoDBCollections)
                    WriteObject(new PSMongoDBCollectionGetResults(mongoDBCollection));
            }

            return;
        }
    }
}
