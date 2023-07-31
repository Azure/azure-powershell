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
using System.Linq;
using System.Net;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBMongoDBUserDefinition", DefaultParameterSetName = FieldsDataActionsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSMongoDBUserDefinitionGetResults))]
    public class NewAzCosmosDBMongoDBUserDefinition : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.MongoDBUserDefinitionIdHelpMessage)]
        public string Id { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.MongoDBUserDefinitionUserNameHelpMessage)]
        public string UserName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.MongoDBUserDefinitionPasswordHelpMessage)]
        public string Password { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, HelpMessage = Constants.MongoDBUserDefinitionPasswordHelpMessage)]
        public string Mechanisms { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.MongoDBRoleDefinitionDatabaseName)]
        public string DatabaseName { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, HelpMessage = Constants.MongoDBInheritedRolesHelpMessage)]
        public List<PSMongoRole> Roles { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, HelpMessage = Constants.MongoDBUserDefinitionCustomDataHelpMessage)]
        public string CustomData { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectDataActionsParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectPermissionsParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        public PSDatabaseAccountGetResults DatabaseAccountObject { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectDataActionsParameterSet, StringComparison.Ordinal)
                || ParameterSetName.Equals(ParentObjectPermissionsParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(DatabaseAccountObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName.Equals(ResourceIdParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.ResourceName;
            }

            Id = string.IsNullOrWhiteSpace(Id) ? Guid.NewGuid().ToString() : MongoRoleHelper.ParseToMongoDbUserDefinitionId(Id);

            IList<Role> roles = (Roles != null && Roles.Any()) ? Roles.Select(role => PSMongoRole.ToSDKModel(role)).ToList() : new List<Role>();
            
            MongoUserDefinitionCreateUpdateParameters mongoUserDefinitionCreateUpdateParameters = new MongoUserDefinitionCreateUpdateParameters(
                userName : UserName,
                password: Password,
                mechanisms : Mechanisms,
                databaseName : DatabaseName,
                roles : roles,
                customData: CustomData);

            if (ShouldProcess(Id, "Creating a new CosmosDB MongoDB User Definition"))
            {
                MongoUserDefinitionGetResults mongoUserDefinitionGetResults = CosmosDBManagementClient.MongoDbResources.CreateUpdateMongoUserDefinitionWithHttpMessagesAsync(Id, ResourceGroupName, AccountName, mongoUserDefinitionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSMongoDBUserDefinitionGetResults(mongoUserDefinitionGetResults));
            }

            return;
        }
    }
}
