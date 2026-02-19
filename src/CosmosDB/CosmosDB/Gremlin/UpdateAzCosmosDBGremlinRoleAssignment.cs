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
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBGremlinRoleAssignment", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSGremlinRoleDefinitionGetResults), typeof(ResourceNotFoundException))]
    public class UpdateAzCosmosDBGremlinRoleAssignment : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.RoleAssignmentIdHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.RoleAssignmentIdHelpMessage)]
        public string Id { get; set; } = default(Guid).ToString();

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.RoleDefinitionIdHelpMessage)]
        public string RoleDefinitionId { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.RoleDefinitionNameHelpMessage)]
        public string RoleDefinitionName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.ScopeHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.ScopeHelpMessage)]
        public string Scope { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, ParameterSetName = FieldsParameterSet, HelpMessage = Constants.PrincipalIdHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.PrincipalIdHelpMessage)]
        public string PrincipalId { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        public PSGremlinRoleDefinitionGetResults ParentObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.RoleAssignmentHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSGremlinRoleAssignmentGetResults InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                RoleDefinitionId = ParentObject.Id;
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.GetDatabaseAccountName();
            }
            else if (ParameterSetName.Equals(ObjectParameterSet, StringComparison.Ordinal))
            {
                Id = InputObject.Id;
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.GetDatabaseAccountName();
                RoleDefinitionId = InputObject.RoleDefinitionId;
                Scope = InputObject.Scope;
                PrincipalId = InputObject.PrincipalId;
            }

            if (!string.IsNullOrWhiteSpace(RoleDefinitionId) && !string.IsNullOrWhiteSpace(RoleDefinitionName))
            {
                throw new ArgumentException($"Cannot specify both [{nameof(RoleDefinitionId)}] and [{nameof(RoleDefinitionName)}]");
            }

            if (!string.IsNullOrWhiteSpace(RoleDefinitionName))
            {
                IEnumerable<GremlinRoleDefinitionResource> gremlinRoleDefinitions =
                    CosmosDBManagementClient.GremlinResources.ListGremlinRoleDefinitionsWithHttpMessagesAsync(ResourceGroupName, AccountName).GetAwaiter().GetResult().Body
                        .Where(r => String.Equals(r.RoleName, RoleDefinitionName, StringComparison.OrdinalIgnoreCase));

                if (!gremlinRoleDefinitions.Any())
                {
                    throw new ResourceNotFoundException(message: string.Format(ExceptionMessage.NotFoundGremlinRoleResourceName, "Assignment", RoleDefinitionName));
                }

                RoleDefinitionId = gremlinRoleDefinitions.FirstOrDefault().Id;
            }

            Id = GremlinRoleHelper.ParseToRoleAssignmentId(Id);

            GremlinRoleAssignmentResource readGremlinRoleAssignmentGetResults = null;
            try
            {
                readGremlinRoleAssignmentGetResults = CosmosDBManagementClient.GremlinResources.GetGremlinRoleAssignment(ResourceGroupName, AccountName, Id);
            }
            catch (ErrorResponseAutoGeneratedException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(message: string.Format(ExceptionMessage.NotFoundGremlinRoleResourceId, "Assignment", Id), innerException: e);
                }
                else
                {
                    throw e;
                }
            }

            GremlinRoleAssignmentResource gremlinRoleAssignmentCreateUpdateParameters = new GremlinRoleAssignmentResource
            {
                RoleDefinitionId = GremlinRoleHelper.ParseToFullyQualifiedRoleDefinitionId(RoleDefinitionId ?? readGremlinRoleAssignmentGetResults.RoleDefinitionId, DefaultProfile.DefaultContext.Subscription.Id, ResourceGroupName, AccountName),
                Scope = GremlinRoleHelper.ParseToFullyQualifiedScope(Scope ?? readGremlinRoleAssignmentGetResults.Scope, DefaultProfile.DefaultContext.Subscription.Id, ResourceGroupName, AccountName),
                PrincipalId = PrincipalId ?? readGremlinRoleAssignmentGetResults.PrincipalId,
            };

            if (ShouldProcess(Id, "Updating an existing CosmosDB Gremlin Role Definition"))
            {
                GremlinRoleAssignmentResource gremlinRoleAssignmentGetResults = CosmosDBManagementClient.GremlinResources.CreateUpdateGremlinRoleAssignmentWithHttpMessagesAsync(ResourceGroupName, AccountName, GremlinRoleHelper.ParseToRoleAssignmentId(Id), gremlinRoleAssignmentCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSGremlinRoleAssignmentGetResults(gremlinRoleAssignmentGetResults));
            }

            return;
        }
    }
}
