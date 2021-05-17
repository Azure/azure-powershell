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
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlRoleDefinition", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSqlRoleDefinitionGetResults), typeof(ResourceNotFoundException))]
    public class UpdateAzCosmosDBSqlRoleDefinition : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.RoleDefinitionIdHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.RoleDefinitionIdHelpMessage)]
        public string Id { get; set; } = default(Guid).ToString();

        [PSArgumentCompleter("BuiltInRole", "CustomRole")]
        [Parameter(Mandatory = false, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.TypeHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.TypeHelpMessage)]
        public string Type { get; set; } = RoleDefinitionType.CustomRole.ToString();

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.RoleNameHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.RoleNameHelpMessage)]
        public string RoleName { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = false, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.DataActionsHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.DataActionsHelpMessage)]
        public List<string> DataAction { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = false, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.PermissionsHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.PermissionsHelpMessage)]
        public List<PSPermission> Permission { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = false, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.AssignableScopesHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.AssignableScopesHelpMessage)]
        public List<string> AssignableScope { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        public PSDatabaseAccountGetResults ParentObject { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.RoleDefinitionHelpMessage)]
        public PSSqlRoleDefinitionGetResults InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            List<Permission> permissions = null;
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName.Equals(ObjectParameterSet))
            {
                RoleName = InputObject.RoleName;
                Type = InputObject.Type;
                AssignableScope = new List<String>(InputObject.AssignableScopes);
                Id = InputObject.Id;
                permissions = new List<Permission>(InputObject.Permissions);

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.GetDatabaseAccountName();
            }

            if (DataAction != null && Permission != null)
            {
                throw new ArgumentException($"Cannot specify both [{nameof(DataAction)}] and [{nameof(Permission)}]");
            }

            if (DataAction != null)
            {
                permissions = new List<Permission>
                {
                    new Permission
                    {
                        DataActions = DataAction
                    }
                };
            }
            else if (Permission != null)
            {
                permissions = new List<Permission>(Permission.Select(p => new Permission(p.DataActions)));
            }

            Id = RoleHelper.ParseToRoleDefinitionId(Id);

            SqlRoleDefinitionGetResults readSqlRoleDefinitionGetResults = null;
            try
            {
                readSqlRoleDefinitionGetResults = CosmosDBManagementClient.SqlResources.GetSqlRoleDefinition(Id, ResourceGroupName, AccountName);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(message: string.Format(ExceptionMessage.NotFoundSqlRoleResourceId, "Definition", Id), innerException: e);
                }
                else
                {
                    throw e;
                }
            }

            AssignableScope = AssignableScope ?? new List<string>(readSqlRoleDefinitionGetResults.AssignableScopes);
            AssignableScope = new List<string>(AssignableScope.Select(s => RoleHelper.ParseToFullyQualifiedScope(s, DefaultProfile.DefaultContext.Subscription.Id, ResourceGroupName, AccountName)));

            SqlRoleDefinitionCreateUpdateParameters sqlRoleDefinitionCreateUpdateParameters = new SqlRoleDefinitionCreateUpdateParameters
            {
                RoleName = RoleName ?? readSqlRoleDefinitionGetResults.RoleName,
                Type = (RoleDefinitionType)Enum.Parse(typeof(RoleDefinitionType), Type ?? readSqlRoleDefinitionGetResults.Type),
                AssignableScopes = AssignableScope,
                Permissions = permissions ?? readSqlRoleDefinitionGetResults.Permissions,
            };

            if (ShouldProcess(Id, "Updating an existing CosmosDB Sql Role Definition"))
            {
                SqlRoleDefinitionGetResults sqlRoleDefinitionGetResults = CosmosDBManagementClient.SqlResources.CreateUpdateSqlRoleDefinitionWithHttpMessagesAsync(Id, ResourceGroupName, AccountName, sqlRoleDefinitionCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSSqlRoleDefinitionGetResults(sqlRoleDefinitionGetResults));
            }

            return;
        }
    }
}
