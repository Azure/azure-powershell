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
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBMongoDBRoleDefinition", DefaultParameterSetName = FieldsDataActionsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSMongoDBCollectionGetResults))]
    public class UpdateAzCosmosDBMongoDBRoleDefinition : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.MongoDBRoleDefinitionIdHelpMessage)]
        public string Id { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, HelpMessage = Constants.MongoDBRoleNameHelpMessage)]
        public string RoleName { get; set; }

        [PSArgumentCompleter("BuiltInRole", "CustomRole")]
        [Parameter(Mandatory = false, HelpMessage = Constants.MongoDBTypeHelpMessage)]
        public string Type { get; set; } = MongoRoleDefinitionType.CustomRole.ToString();

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, HelpMessage = Constants.MongoDBRoleDefinitionDatabaseName)]
        public string DatabaseName { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = false, HelpMessage = Constants.MongoRoleDefinitionPrivilegesHelpMessage)]
        public List<PSMongoPrivilege> Privileges { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = false, HelpMessage = Constants.MongoDBInheritedRolesHelpMessage)]
        public List<PSMongoRole> Roles { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        public PSDatabaseAccountGetResults DatabaseAccountObject { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.MongoDBRoleDefinitionHelpMessage)]
        public PSMongoDBRoleDefinitionGetResults InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            IList<Privilege> privileges = null;
            IList<Role> roles = null;

            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(DatabaseAccountObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName.Equals(ObjectParameterSet))
            {
                RoleName = InputObject.RoleName;
                Type = InputObject.Type;
                Id = InputObject.Id;
                DatabaseName = InputObject.DatabaseName;
                privileges = new List<Privilege>(InputObject.Privileges);
                roles = new List<Role>(InputObject.Roles);

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.GetDatabaseAccountName();
            }

            Id = string.IsNullOrWhiteSpace(Id) ? Guid.NewGuid().ToString() : MongoRoleHelper.ParseToMongoDbRoleDefinitionId(Id);

            MongoRoleDefinitionGetResults mongoRoleDefinitionGetResults = null;
            try
            {
                mongoRoleDefinitionGetResults = CosmosDBManagementClient.MongoDbResources.GetMongoRoleDefinition(Id, ResourceGroupName, AccountName);
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

            privileges = Privileges != null ?
                Privileges.Select(privilege => PSMongoPrivilege.ToSDKModel(privilege)).ToList() :
                mongoRoleDefinitionGetResults.Privileges;

            roles = Roles != null ? Roles.Select(role => PSMongoRole.ToSDKModel(role)).ToList() : mongoRoleDefinitionGetResults.Roles;

            MongoRoleDefinitionCreateUpdateParameters mongoRoleDefinitionCreateUpdateParameters = new MongoRoleDefinitionCreateUpdateParameters(
                roleName: RoleName ?? mongoRoleDefinitionGetResults.RoleName,
                type: Type != null ? (MongoRoleDefinitionType)Enum.Parse(typeof(MongoRoleDefinitionType), Type) : mongoRoleDefinitionGetResults.PropertiesType,
                databaseName: DatabaseName ?? mongoRoleDefinitionGetResults.DatabaseName,
                privileges: privileges,
                roles: roles);

            if (ShouldProcess(Id, "Updating the CosmosDB MongoDB Role Definition"))
            {
                mongoRoleDefinitionGetResults = CosmosDBManagementClient.MongoDbResources.CreateUpdateMongoRoleDefinitionWithHttpMessagesAsync(Id, ResourceGroupName, AccountName, mongoRoleDefinitionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSMongoDBRoleDefinitionGetResults(mongoRoleDefinitionGetResults));
            }

            return;
        }
    }
}
