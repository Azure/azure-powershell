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

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlRoleDefinition", DefaultParameterSetName = FieldsDataActionsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSqlRoleDefinitionGetResults))]
    public class NewAzCosmosDBSqlRoleDefinition : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = FieldsDataActionsParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = FieldsPermissionsParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = FieldsDataActionsParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = FieldsPermissionsParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, HelpMessage = Constants.RoleDefinitionIdHelpMessage)]
        public string Id { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.RoleNameHelpMessage)]
        public string RoleName { get; set; }

        [PSArgumentCompleter("BuiltInRole", "CustomRole")]
        [Parameter(Mandatory = false, HelpMessage = Constants.TypeHelpMessage)]
        public string Type { get; set; } = RoleDefinitionType.CustomRole.ToString();

        [ValidateNotNull]
        [Parameter(Mandatory = true, HelpMessage = Constants.AssignableScopesHelpMessage)]
        public List<string> AssignableScope { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, ParameterSetName = FieldsDataActionsParameterSet, HelpMessage = Constants.DataActionsHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectDataActionsParameterSet, HelpMessage = Constants.DataActionsHelpMessage)]
        public List<string> DataAction { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, ParameterSetName = FieldsPermissionsParameterSet, HelpMessage = Constants.PermissionsHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectPermissionsParameterSet, HelpMessage = Constants.PermissionsHelpMessage)]
        public List<PSPermission> Permission { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectDataActionsParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectPermissionsParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
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

            Id = string.IsNullOrWhiteSpace(Id) ? Guid.NewGuid().ToString() : RoleHelper.ParseToRoleDefinitionId(Id);

            SqlRoleDefinitionGetResults readSqlRoleDefinitionGetResults = null;
            try
            {
                readSqlRoleDefinitionGetResults = CosmosDBManagementClient.SqlResources.GetSqlRoleDefinition(Id, ResourceGroupName, AccountName);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != HttpStatusCode.NotFound)
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
                Type = (RoleDefinitionType)Enum.Parse(typeof(RoleDefinitionType), Type),
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
