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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlRoleDefinition", DefaultParameterSetName = FieldsDataActionsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSqlRoleDefinitionGetResults))]
    public class NewAzCosmosDBSqlRoleDefinition : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = FieldsDataActionsParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = FieldsPermissionsParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsDataActionsParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = FieldsPermissionsParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]

        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = FieldsDataActionsParameterSet, HelpMessage = Constants.TypeHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = FieldsPermissionsParameterSet, HelpMessage = Constants.TypeHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = ParentObjectDataActionsParameterSet, HelpMessage = Constants.TypeHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = ParentObjectPermissionsParameterSet, HelpMessage = Constants.TypeHelpMessage)]
        [PSArgumentCompleter("BuiltInRole", "CustomRole")]
        public string Type { get; set; } = "CustomRole";

        [Parameter(Mandatory = true, ParameterSetName = FieldsDataActionsParameterSet, HelpMessage = Constants.RoleNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = FieldsPermissionsParameterSet, HelpMessage = Constants.RoleNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectDataActionsParameterSet, HelpMessage = Constants.RoleNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectPermissionsParameterSet, HelpMessage = Constants.RoleNameHelpMessage)]
        public string RoleName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsDataActionsParameterSet, HelpMessage = Constants.DataActionsHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectDataActionsParameterSet, HelpMessage = Constants.DataActionsHelpMessage)]
        public List<string> DataAction { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsPermissionsParameterSet, HelpMessage = Constants.PermissionsHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectPermissionsParameterSet, HelpMessage = Constants.PermissionsHelpMessage)]
        public List<PSPermission> Permission { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsDataActionsParameterSet, HelpMessage = Constants.AssignableScopesHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = FieldsPermissionsParameterSet, HelpMessage = Constants.AssignableScopesHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectDataActionsParameterSet, HelpMessage = Constants.AssignableScopesHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectPermissionsParameterSet, HelpMessage = Constants.AssignableScopesHelpMessage)]
        public List<string> AssignableScope { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = FieldsDataActionsParameterSet, HelpMessage = Constants.RoleDefinitionIdHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = FieldsPermissionsParameterSet, HelpMessage = Constants.RoleDefinitionIdHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = ParentObjectDataActionsParameterSet, HelpMessage = Constants.RoleDefinitionIdHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = ParentObjectPermissionsParameterSet, HelpMessage = Constants.RoleDefinitionIdHelpMessage)]
        public string Id { get; set; } = default(Guid).ToString();

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectDataActionsParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectPermissionsParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [ValidateNotNull]
        public PSDatabaseAccountGetResults ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectDataActionsParameterSet, StringComparison.Ordinal) 
                || ParameterSetName.Equals(ParentObjectPermissionsParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.ResourceName;
            }

            List<Permission> permissions;
            if (ParameterSetName.Equals(FieldsDataActionsParameterSet, StringComparison.Ordinal)
                || ParameterSetName.Equals(ParentObjectDataActionsParameterSet, StringComparison.Ordinal))
            {
                permissions = new List<Permission>
                {
                    new Permission
                    {
                        DataActions = DataAction
                    }
                };            
            }
            else
            {
                permissions = new List<Permission>(Permission.Select(p => new Permission(p.DataActions)));
            }

            Id = String.Equals(Id, default(Guid).ToString()) ? Guid.NewGuid().ToString() : RoleHelper.ParseToRoleDefinitionId(Id);

            SqlRoleDefinitionGetResults readSqlRoleDefinitionGetResults = null;
            try
            {
                readSqlRoleDefinitionGetResults = CosmosDBManagementClient.SqlResources.GetSqlRoleDefinition(Id, ResourceGroupName, AccountName);
            }
            catch (DefaultErrorResponseException e)
            {
                if (e.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            if (readSqlRoleDefinitionGetResults != null)
            {
                throw new ConflictingResourceException(message: string.Format(ExceptionMessage.ConflictSqlRoleResourceId, "Definition", Id));
            }

            AssignableScope = new List<string>(AssignableScope.Select(s => RoleHelper.ParseToFullyQualifiedScope(s, DefaultProfile.DefaultContext.Subscription.Id, ResourceGroupName, AccountName)));

            SqlRoleDefinitionCreateUpdateParameters sqlRoleDefinitionCreateUpdateParameters = new SqlRoleDefinitionCreateUpdateParameters
            {
                RoleName = RoleName,
                Type = String.Equals(Type, "CustomRole") ? RoleDefinitionType.CustomRole : RoleDefinitionType.BuiltInRole,
                AssignableScopes = AssignableScope,
                Permissions = permissions
            };

            if (ShouldProcess(Id, "Creating a new CosmosDB Sql Role Definition"))
            {
                SqlRoleDefinitionGetResults sqlRoleDefinitionGetResults = CosmosDBManagementClient.SqlResources.CreateUpdateSqlRoleDefinitionWithHttpMessagesAsync(Id, ResourceGroupName, AccountName, sqlRoleDefinitionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSSqlRoleDefinitionGetResults(sqlRoleDefinitionGetResults));
            }

            return;
        }
    }
}
