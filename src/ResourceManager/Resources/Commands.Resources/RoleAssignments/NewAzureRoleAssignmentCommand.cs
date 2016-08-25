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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Creates new role assignment.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmRoleAssignment", DefaultParameterSetName = ParameterSet.Empty), OutputType(typeof(PSRoleAssignment))]
    public class NewAzureRoleAssignmentCommand : ResourcesBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithObjectId,
            HelpMessage = "The user or group object id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "The user or group object id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithObjectId,
            HelpMessage = "The user or group object id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "The user or group object id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleIdWithScopeAndObjectId,
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
        [ValidateNotNullOrEmpty]
        [Alias("Email", "UserPrincipalName")]
        public string SignInName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSPN,
            HelpMessage = "The app SPN.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "The app SPN.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "The app SPN.")]
        [ValidateNotNullOrEmpty]
        [Alias("SPN")]
        public string ServicePrincipalName { get; set; }

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

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Resource to assign the role to.")]
        [ValidateNotNullOrEmpty]
        public string ResourceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Type of the resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Type of the resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Type of the resource to assign the role to.")]
        [ValidateNotNullOrEmpty]
        public string ResourceType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [ValidateNotNullOrEmpty]
        public string ParentResource { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "Scope of the role assignment. In the format of relative URI. If not specified, will assign the role at subscription level. If specified, it can either start with \"/subscriptions/<id>\" or the part after that. If it's latter, the current subscription id will be used.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithObjectId,
            HelpMessage = "Scope of the role assignment. In the format of relative URI. If not specified, will assign the role at subscription level. If specified, it can either start with \"/subscriptions/<id>\" or the part after that. If it's latter, the current subscription id will be used.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSignInName,
            HelpMessage = "Scope of the role assignment. In the format of relative URI. If not specified, will assign the role at subscription level. If specified, it can either start with \"/subscriptions/<id>\" or the part after that. If it's latter, the current subscription id will be used.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "Scope of the role assignment. In the format of relative URI. If not specified, will assign the role at subscription level. If specified, it can either start with \"/subscriptions/<id>\" or the part after that. If it's latter, the current subscription id will be used.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleIdWithScopeAndObjectId,
            HelpMessage = "Scope of the role assignment. In the format of relative URI. If not specified, will assign the role at subscription level. If specified, it can either start with \"/subscriptions/<id>\" or the part after that. If it's latter, the current subscription id will be used.")]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithObjectId,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSignInName,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithObjectId,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSignInName,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSignInName,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSPN,
            HelpMessage = "Role name to assign the principals with.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Role name to assign the principals with.")]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleIdWithScopeAndObjectId,
            HelpMessage = "Role Id the principal is assigned to.")]
        [ValidateGuidNotEmpty]
        public Guid RoleDefinitionId { get; set; }

        public override void ExecuteCmdlet()
        {
            FilterRoleAssignmentsOptions parameters = new FilterRoleAssignmentsOptions()
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
                    Subscription = DefaultProfile.Context.Subscription.Id.ToString(),
                }
            };

            WriteObject(PoliciesClient.CreateRoleAssignment(parameters));
        }
    }
}