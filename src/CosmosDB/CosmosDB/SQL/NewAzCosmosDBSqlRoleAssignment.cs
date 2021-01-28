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

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlRoleAssignment", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSqlRoleAssignmentGetResults))]
    public class NewAzCosmosDBSqlRoleAssignment : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.RoleDefinitionIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.RoleDefinitionNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.ScopeHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.ScopeHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ScopeHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.PrincipalIdHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.PrincipalIdHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.PrincipalIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string PrincipalId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.RoleAssignmentIdHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.RoleAssignmentIdHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.RoleAssignmentIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; } = default(Guid).ToString();

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.RoleDefinitionHelpMessage)]
        [ValidateNotNull]
        public PSSqlRoleDefinitionGetResults ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                RoleDefinitionId = ParentObject.Id;
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.GetDatabaseAccountName();
            }
            else if (ParameterSetName.Equals(NameParameterSet, StringComparison.Ordinal))
            {
                IEnumerable<SqlRoleDefinitionGetResults> sqlRoleDefinitions = CosmosDBManagementClient.SqlResources.ListSqlRoleDefinitionsWithHttpMessagesAsync(ResourceGroupName, AccountName).GetAwaiter().GetResult().Body.Where(r => String.Equals(r.RoleName, RoleDefinitionName));

                if (!sqlRoleDefinitions.Any())
                {
                    throw new ResourceNotFoundException(message: string.Format(ExceptionMessage.NotFoundSqlRoleResourceName, "Assignment", RoleDefinitionName));
                }

                RoleDefinitionId = sqlRoleDefinitions.FirstOrDefault().Id;
            }

            Id = String.Equals(Id, default(Guid).ToString()) ? Guid.NewGuid().ToString() : RoleHelper.ParseToRoleAssignmentId(Id);

            SqlRoleAssignmentGetResults readSqlRoleAssignmentGetResults = null;
            try
            {
                readSqlRoleAssignmentGetResults = CosmosDBManagementClient.SqlResources.GetSqlRoleAssignment(Id, ResourceGroupName, AccountName);
            }
            catch (DefaultErrorResponseException e)
            {
                if (e.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            if (readSqlRoleAssignmentGetResults != null)
            {
                throw new ConflictingResourceException(message: string.Format(ExceptionMessage.ConflictSqlRoleResourceId, "Assignment", Id));
            }

            SqlRoleAssignmentCreateUpdateParameters sqlRoleAssignmentCreateUpdateParameters = new SqlRoleAssignmentCreateUpdateParameters
            {
                RoleDefinitionId = RoleHelper.ParseToFullyQualifiedRoleDefinitionId(RoleDefinitionId, DefaultProfile.DefaultContext.Subscription.Id, ResourceGroupName, AccountName),
                Scope = RoleHelper.ParseToFullyQualifiedScope(Scope, DefaultProfile.DefaultContext.Subscription.Id, ResourceGroupName, AccountName),
                PrincipalId = PrincipalId
            };
            
            if (ShouldProcess(Id.ToString(), "Creating a new CosmosDB Sql Role Assignment"))
            {
                SqlRoleAssignmentGetResults sqlRoleAssignmentGetResults = CosmosDBManagementClient.SqlResources.CreateUpdateSqlRoleAssignmentWithHttpMessagesAsync(Id, ResourceGroupName, AccountName, sqlRoleAssignmentCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSSqlRoleAssignmentGetResults(sqlRoleAssignmentGetResults));
            }
            return;
        }
    }
}
