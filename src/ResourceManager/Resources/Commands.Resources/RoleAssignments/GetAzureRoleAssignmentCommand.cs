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
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Filters role assignments
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRoleAssignment", DefaultParameterSetName = ParameterSet.Empty), OutputType(typeof(List<PSRoleAssignment>))]
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
        [ValidateNotNullOrEmpty]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Mail,
            HelpMessage = "The user email address.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithMail,
            HelpMessage = "The user email address.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithMail,
            HelpMessage = "The user email address.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithMail,
            HelpMessage = "The user email address.")]
        [ValidateNotNullOrEmpty]
        public string Mail { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithUPN,
            HelpMessage = "The user UPN.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithUPN,
            HelpMessage = "The user UPN.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithUPN,
            HelpMessage = "The user UPN.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.UPN,
            HelpMessage = "The user UPN.")]
        [ValidateNotNullOrEmpty]
        [Alias("UPN")]
        public string UserPrincipalName { get; set; }

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
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithMail,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithMail,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithUPN,
            HelpMessage = "Resource group to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithUPN,
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
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithMail,
            HelpMessage = "Resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithUPN,
            HelpMessage = "Resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Resource to assign the role to.")]
        [ValidateNotNullOrEmpty]
        public string ResourceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Resource,
            HelpMessage = "Type of the resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Type of the resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithMail,
            HelpMessage = "Type of the resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithUPN,
            HelpMessage = "Type of the resource to assign the role to.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Type of the resource to assign the role to.")]
        [ValidateNotNullOrEmpty]
        public string ResourceType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Resource,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithMail,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithUPN,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Parent resource of the resource to assign the role to, if there is any.")]
        [ValidateNotNullOrEmpty]
        public string ParentResource { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Mail,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.UPN,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPN,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Scope,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithMail,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithObjectId,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithUPN,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroup,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithMail,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithObjectId,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithUPN,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceGroupWithSPN,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Resource,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithMail,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithObjectId,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithUPN,
            HelpMessage = "Role to assign the principals with.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ResourceWithSPN,
            HelpMessage = "Role to assign the principals with.")]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Scope,
            HelpMessage = "Scope of the role assignment. In the format of relative URI.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithObjectId,
            HelpMessage = "Scope of the role assignment. In the format of relative URI.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithMail,
            HelpMessage = "Scope of the role assignment. In the format of relative URI.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithUPN,
            HelpMessage = "Scope of the role assignment. In the format of relative URI.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ScopeWithSPN,
            HelpMessage = "Scope of the role assignment. In the format of relative URI.")]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        public override void ExecuteCmdlet()
        {
            FilterRoleAssignmentsOptions options = new FilterRoleAssignmentsOptions()
            {
                Scope = Scope,
                RoleDefinition = RoleDefinitionName,
                ADObjectFilter = new ADObjectFilterOptions
                {
                    Mail = Mail,
                    UPN = UserPrincipalName,
                    SPN = ServicePrincipalName,
                    Id = ObjectId == Guid.Empty ? null : ObjectId.ToString(),
                },
                ResourceIdentifier = new ResourceIdentifier()
                {
                    ParentResource = ParentResource,
                    ResourceGroupName = ResourceGroupName,
                    ResourceName = ResourceName,
                    ResourceType = ResourceType,
                    Subscription = string.IsNullOrEmpty(ResourceGroupName) ? null : CurrentContext.Subscription.Id.ToString()
                }
            };

            WriteObject(PoliciesClient.FilterRoleAssignments(options), true);
        }
    }
}