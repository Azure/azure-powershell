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
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBMongoDBUserDefinition", DefaultParameterSetName = FieldsDataActionsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSMongoDBUserDefinitionGetResults))]
    public class UpdateAzCosmosDBMongoDBUserDefinition : AzureCosmosDBCmdletBase
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
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        public PSDatabaseAccountGetResults DatabaseAccountObject { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.MongoDBUserDefinitionHelpMessage)]
        public PSMongoDBUserDefinitionGetResults InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            IList<Role> roles = null;

            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(DatabaseAccountObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName.Equals(ObjectParameterSet))
            {
                UserName = InputObject.UserName;
                Password = InputObject.Password;
                Id = InputObject.Id;
                Mechanisms = InputObject.Mechanisms;
                DatabaseName = InputObject.DatabaseName;
                CustomData = InputObject.CustomData;
                roles = new List<Role>(InputObject.Roles);

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.GetDatabaseAccountName();
            }

            Id = string.IsNullOrWhiteSpace(Id) ? Guid.NewGuid().ToString() : MongoRoleHelper.ParseToMongoDbUserDefinitionId(Id);

            MongoUserDefinitionGetResults mongoUserDefinitionGetResults = null;
            try
            {
                mongoUserDefinitionGetResults = CosmosDBManagementClient.MongoDbResources.GetMongoUserDefinition(Id, ResourceGroupName, AccountName);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(message: string.Format(ExceptionMessage.NotFoundMongoDBRoleResourceId, "Definition", Id), innerException: e);
                }
                else
                {
                    throw e;
                }
            }

            roles = Roles != null ? Roles.Select(role => PSMongoRole.ToSDKModel(role)).ToList() : mongoUserDefinitionGetResults.Roles;

            MongoUserDefinitionCreateUpdateParameters mongoUserDefinitionCreateUpdateParameters = new MongoUserDefinitionCreateUpdateParameters(
                userName: UserName ?? mongoUserDefinitionGetResults.UserName,
                password: Password ?? mongoUserDefinitionGetResults.Password,
                mechanisms: Mechanisms ?? mongoUserDefinitionGetResults.Mechanisms,
                databaseName: DatabaseName ?? mongoUserDefinitionGetResults.DatabaseName,
                roles: roles,
                customData: CustomData ?? mongoUserDefinitionGetResults.CustomData);

            if (ShouldProcess(Id, "Updating the CosmosDB MongoDB User Definition"))
            {
                mongoUserDefinitionGetResults = CosmosDBManagementClient.MongoDbResources.CreateUpdateMongoUserDefinitionWithHttpMessagesAsync(Id, ResourceGroupName, AccountName, mongoUserDefinitionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSMongoDBUserDefinitionGetResults(mongoUserDefinitionGetResults));
            }

            return;
        }
    }
}
