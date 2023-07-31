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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBMongoDBRoleDefinition", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSMongoDBRoleDefinitionGetResults))]
    public class GetAzCosmosDBMongoDBRoleDefinition : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, HelpMessage = Constants.MongoDBRoleDefinitionIdHelpMessage)]
        public string Id { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, HelpMessage = Constants.MongoDBRoleDefinitionDatabaseName)]
        public string DatabaseName { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        public PSDatabaseAccountGetResults DatabaseAccountObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(DatabaseAccountObject.Id);
                AccountName = resourceIdentifier.ResourceName;
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (!string.IsNullOrEmpty(Id))
            {
                MongoRoleDefinitionGetResults mongoRoleDefinitionGetResults = CosmosDBManagementClient.MongoDbResources.GetMongoRoleDefinitionWithHttpMessagesAsync(MongoRoleHelper.ParseToMongoDbRoleDefinitionId(Id), ResourceGroupName, AccountName).GetAwaiter().GetResult().Body;

                if (DatabaseName == null || (mongoRoleDefinitionGetResults.DatabaseName != null || mongoRoleDefinitionGetResults.DatabaseName.Equals(DatabaseName)))
                {
                    WriteObject(new PSMongoDBRoleDefinitionGetResults(mongoRoleDefinitionGetResults));
                }
            }
            else
            {
                IEnumerable<MongoRoleDefinitionGetResults> mongoRoleDefinitions = CosmosDBManagementClient.MongoDbResources.ListMongoRoleDefinitionsWithHttpMessagesAsync(ResourceGroupName, AccountName).GetAwaiter().GetResult().Body;

                if (DatabaseName == null)
                {
                    foreach (MongoRoleDefinitionGetResults mongoRoleDefinitionGetResults in mongoRoleDefinitions)
                    {
                        WriteObject(new PSMongoDBRoleDefinitionGetResults(mongoRoleDefinitionGetResults));
                    }
                }
                else
                {
                    foreach (MongoRoleDefinitionGetResults mongoRoleDefinitionGetResults in mongoRoleDefinitions)
                    {
                        if (mongoRoleDefinitionGetResults.DatabaseName != null && mongoRoleDefinitionGetResults.DatabaseName.Equals(DatabaseName))
                        {
                            WriteObject(new PSMongoDBRoleDefinitionGetResults(mongoRoleDefinitionGetResults));
                        }
                    }
                }    
            }

            return;
        }
    }
}
