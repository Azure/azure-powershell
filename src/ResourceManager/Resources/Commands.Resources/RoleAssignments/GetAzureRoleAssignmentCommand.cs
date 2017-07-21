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

using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Filters role assignments
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRoleAssignment", DefaultParameterSetName = ParameterSet.Empty), OutputType(typeof(List<PSRoleAssignment>))]
    public class GetAzureRoleAssignmentCommand : ResourcesBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId,
            HelpMessage = "The user or group object id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithObjectId,
            HelpMessage = "The user or group object id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "The user or group object id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithObjectId,
            HelpMessage = "The user or group object id.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleIdWithScopeAndObjectId,
            HelpMessage = "The user or group object id.")]
        [ValidateGuidNotEmpty]
        [Alias("Id", "PrincipalId")]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSignInName,
            HelpMessage = "The user SignInName.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "The user SignInName.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSignInName,
            HelpMessage = "The user SignInName.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SignInName,
            HelpMessage = "The user SignInName.")]
        [ValidateNotNullOrEmpty]
        [Alias("Email", "UserPrincipalName")]
        public string SignInName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSPN,
            HelpMessage = "The app SPN.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "The app SPN.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "The app SPN.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPN,
            HelpMessage = "The app SPN.")]
        [ValidateNotNullOrEmpty]
        [Alias("SPN")]
        public string ServicePrincipalName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroup,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Resource,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithObjectId,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSignInName,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSPN,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Resource group to assign the role to.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Resource,
            HelpMessage = "Resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Resource to assign the role to.")]
        [ValidateNotNullOrEmpty]
        public string ResourceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Resource,
            HelpMessage = "Type of the resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Type of the resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Type of the resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Type of the resource to assign the role to.")]
        [ValidateNotNullOrEmpty]
        public string ResourceType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Resource,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [ValidateNotNullOrEmpty]
        public string ParentResource { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SignInName,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPN,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Scope,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithObjectId,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSignInName,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroup,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithObjectId,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSignInName,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSPN,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Resource,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Role to assign the principals with.")]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleIdWithScopeAndObjectId,
            HelpMessage = "Role Id the principal is assigned to.")]
        [ValidateGuidNotEmpty]
        public Guid RoleDefinitionId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Scope,
            HelpMessage = "Scope of the role assignment. In the format of relative URI.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithObjectId,
            HelpMessage = "Scope of the role assignment. In the format of relative URI.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSignInName,
            HelpMessage = "Scope of the role assignment. In the format of relative URI.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "Scope of the role assignment. In the format of relative URI.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleIdWithScopeAndObjectId,
            HelpMessage = "Scope of the role assignment. In the format of relative URI.")]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ObjectId,
            HelpMessage = "If specified, returns role assignments directly assigned to the principal as well as assignments to the principal's groups (transitive). Supported only for User Principals.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.SignInName,
            HelpMessage = "If specified, returns role assignments directly assigned to the principal as well as assignments to the principal's groups (transitive). Supported only for User Principals.")]
        public SwitchParameter ExpandPrincipalGroups { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ObjectId,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.SignInName,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.SPN,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.Scope,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ScopeWithObjectId,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ScopeWithSignInName,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ResourceGroup,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ResourceGroupWithObjectId,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ResourceGroupWithSignInName,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ResourceGroupWithSPN,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.Resource,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "If specified, also returns the subscription classic administrators as role assignments.")]
        public SwitchParameter IncludeClassicAdministrators { get; set; }

        public override void ExecuteCmdlet()
        {
            FilterRoleAssignmentsOptions options = new FilterRoleAssignmentsOptions()
            {
                Scope = Scope,
                RoleDefinitionName = RoleDefinitionName,
                RoleDefinitionId = RoleDefinitionId == Guid.Empty ? null : RoleDefinitionId.ToString(),
                ADObjectFilter = new ADObjectFilterOptions
                {
                    UPN = SignInName,
                    SPN = ServicePrincipalName,
                    Id = ObjectId == Guid.Empty ? null : ObjectId.ToString(),
                },
                ResourceIdentifier = new ResourceIdentifier()
                {
                    ParentResource = ParentResource,
                    ResourceGroupName = ResourceGroupName,
                    ResourceName = ResourceName,
                    ResourceType = ResourceType,
                    Subscription = string.IsNullOrEmpty(ResourceGroupName) ? null : DefaultProfile.DefaultContext.Subscription.Id.ToString()
                },
                ExpandPrincipalGroups = ExpandPrincipalGroups.IsPresent,
                IncludeClassicAdministrators = IncludeClassicAdministrators.IsPresent,
                ExcludeAssignmentsForDeletedPrincipals = true
            };

            AuthorizationClient.ValidateScope(options.Scope, true);

            List<PSRoleAssignment> ra = PoliciesClient.FilterRoleAssignments(options, DefaultProfile.DefaultContext.Subscription.Id.ToString());

            WriteObject(ra, enumerateCollection: true);
        }
    }
}