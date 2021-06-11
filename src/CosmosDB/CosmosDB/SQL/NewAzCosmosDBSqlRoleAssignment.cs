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
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlRoleAssignment", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSqlRoleAssignmentGetResults))]
    public class NewAzCosmosDBSqlRoleAssignment : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, HelpMessage = Constants.RoleAssignmentIdHelpMessage)]
        public string Id { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.RoleDefinitionIdHelpMessage)]
        public string RoleDefinitionId { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.RoleDefinitionNameHelpMessage)]
        public string RoleDefinitionName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.ScopeHelpMessage)]
        public string Scope { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.PrincipalIdHelpMessage)]
        public string PrincipalId { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.RoleDefinitionHelpMessage)]
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

            Id = string.IsNullOrWhiteSpace(Id) ? Guid.NewGuid().ToString() : RoleHelper.ParseToRoleAssignmentId(Id);

            SqlRoleAssignmentGetResults readSqlRoleAssignmentGetResults = null;
            try
            {
                readSqlRoleAssignmentGetResults = CosmosDBManagementClient.SqlResources.GetSqlRoleAssignment(Id, ResourceGroupName, AccountName);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != HttpStatusCode.NotFound)
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
