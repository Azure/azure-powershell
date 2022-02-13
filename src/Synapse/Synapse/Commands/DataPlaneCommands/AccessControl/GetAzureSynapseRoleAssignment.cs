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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;
using static Microsoft.Azure.Commands.Synapse.Models.SynapseConstants;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.RoleAssignment,
        DefaultParameterSetName = GetByWorkspaceNameAndNameParameterSet)]
    [OutputType(typeof(PSRoleAssignmentDetails))]
    public class GetAzureSynapseRoleAssignment : SynapseRoleCmdletBase
    {
        private const string GetByWorkspaceNameAndNameParameterSet = "GetByWorkspaceNameAndNameParameterSet";
        private const string GetByWorkspaceNameAndIdParameterSet = "GetByWorkspaceNameAndIdParameterSet";
        private const string GetByWorkspaceObjectAndNameParameterSet = "GetByWorkspaceObjectAndNameParameterSet";
        private const string GetByWorkspaceObjectAndIdParameterSet = "GetByWorkspaceObjectAndIdParameterSet";
        private const string GetByWorkspaceNameAndRoleDefinitionIdAndObjectIdParameterSet = "GetByWorkspaceNameAndRoleDefinitionIdAndObjectIdParameterSet";
        private const string GetByWorkspaceObjectAndRoleDefinitionIdAndObjectIdParameterSet = "GetByWorkspaceObjectAndRoleDefinitionIdAndObjectIdParameterSet";
        private const string GetByWorkspaceNameAndAssignmentIdParameterSet = "GetByWorkspaceNameAndAssignmentIdParameterSet";
        private const string GetByWorkspaceObjectAndAssignmentIdParameterSet = "GetByWorkspaceObjectAndAssignmentIdParameterSet";
        private const string GetByWorkspaceNameAndServicePrincipalNameParameterSet = "GetByWorkspaceNameAndServicePrincipalNameParameterSet";
        private const string GetByWorkspaceObjectAndServicePrincipalNameParameterSet = "GetByWorkspaceObjectAndServicePrincipalNameParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndAssignmentIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByWorkspaceObjectAndNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByWorkspaceObjectAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByWorkspaceObjectAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByWorkspaceObjectAndAssignmentIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByWorkspaceObjectAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndAssignmentIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleAssignmentId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndAssignmentIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleAssignmentId)]
        [ValidateNotNullOrEmpty]
        public string RoleAssignmentId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndServicePrincipalNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndServicePrincipalNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RoleDefinitionName)]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionId)]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.SignInName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SignInName)]
        [Alias("Email", "UserPrincipalName")]
        [ValidateNotNullOrEmpty]
        public string SignInName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndServicePrincipalNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ServicePrincipalName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.ServicePrincipalName)]
        [ValidateNotNullOrEmpty]
        public string ServicePrincipalName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.PrincipalId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.PrincipalId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.PrincipalId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.PrincipalId)]
        [Alias("Id", "PrincipalId")]
        [ValidateNotNullOrEmpty]
        public string ObjectId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItemType)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItemType)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItemType)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndServicePrincipalNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItemType)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItemType)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItemType)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItemType)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndServicePrincipalNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItemType)]
        [ValidateNotNullOrEmpty]
        public WorkspaceItemType ItemType { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItem)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItem)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItem)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndServicePrincipalNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItem)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItem)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItem)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItem)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndServicePrincipalNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceItem)]
        [ValidateNotNullOrEmpty]
        public string Item { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.RoleDefinitionName))
            {
                this.RoleDefinitionId = SynapseAnalyticsClient.GetRoleDefinitionIdFromRoleDefinitionName(this.RoleDefinitionName);
            }

            if (this.IsParameterBound(c => c.SignInName))
            {
                this.ObjectId = SynapseAnalyticsClient.GetObjectIdFromSignInName(this.SignInName);
            }

            if (this.IsParameterBound(c => c.ServicePrincipalName))
            {
                this.ObjectId = SynapseAnalyticsClient.GetObjectIdFromServicePrincipalName(this.ServicePrincipalName);
            }

            string itemType = null;
            if (this.IsParameterBound(c => c.ItemType))
            {
                itemType = this.ItemType.GetItemTypeString();
            }

            if (this.IsParameterBound(c => c.RoleAssignmentId))
            {
                WriteObject(new PSRoleAssignmentDetails(SynapseAnalyticsClient.GetRoleAssignmentById(this.RoleAssignmentId)));
            }
            else
            {
                var roleAssignments = SynapseAnalyticsClient.ListRoleAssignments(this.RoleDefinitionId, this.ObjectId).Select(element => new PSRoleAssignmentDetails(element));
                string allowedScopePattern = null;
                if (this.IsParameterBound(c => c.ItemType) && this.IsParameterBound(c => c.Item))
                {
                    allowedScopePattern = $"(^workspaces/{this.WorkspaceName}$)|(^workspaces/{this.WorkspaceName}/{itemType}/{this.Item}$)";
                }
                else if (this.IsParameterBound(c => c.ItemType) && !this.IsParameterBound(c => c.Item))
                {
                    allowedScopePattern = $"(^workspaces/{this.WorkspaceName}$)|(^workspaces/{this.WorkspaceName}/{itemType}/[^/]+$)";
                }
                else if (!this.IsParameterBound(c => c.ItemType) && this.IsParameterBound(c => c.Item))
                {
                    allowedScopePattern = $"(^workspaces/{this.WorkspaceName}$)|(^workspaces/{this.WorkspaceName}/[^/]+/{this.Item}$)";
                }

                if (!string.IsNullOrEmpty(allowedScopePattern))
                {
                    roleAssignments = roleAssignments.Where(ra => ra.Scope == null || Regex.IsMatch(ra.Scope, allowedScopePattern, RegexOptions.IgnoreCase));
                }

                WriteObject(roleAssignments, true);
            }
        }
    }
}
