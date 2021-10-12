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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using static Microsoft.Azure.Commands.Synapse.Models.SynapseConstants;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.RoleAssignment, 
        DefaultParameterSetName = NewByWorkspaceNameAndNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSRoleAssignmentDetails))]
    public class NewAzureSynapseRoleAssignment : SynapseRoleCmdletBase
    {
        private const string NewByWorkspaceNameAndNameParameterSet = "NewByWorkspaceNameAndNameParameterSet";
        private const string NewByWorkspaceNameAndIdParameterSet = "NewByWorkspaceNameAndIdParameterSet";
        private const string NewByWorkspaceObjectAndNameParameterSet = "NewByWorkspaceObjectAndNameParameterSet";
        private const string NewByWorkspaceObjectAndIdParameterSet = "NewByWorkspaceObjectAndIdParameterSet";
        private const string NewByWorkspaceNameAndRoleDefinitionIdAndObjectIdParameterSet = "NewByWorkspaceNameAndRoleDefinitionIdAndObjectIdParameterSet";
        private const string NewByWorkspaceObjectAndRoleDefinitionIdAndObjectIdParameterSet = "NewByWorkspaceObjectAndRoleDefinitionIdAndObjectIdParameterSet";
        private const string NewByWorkspaceNameAndServicePrincipalNameParameterSet = "NewByWorkspaceNameAndServicePrincipalNameParameterSet";
        private const string NewByWorkspaceObjectAndServicePrincipalNameParameterSet = "NewByWorkspaceObjectAndServicePrincipalNameParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceNameAndNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceNameAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceNameAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceNameAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = NewByWorkspaceObjectAndNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = NewByWorkspaceObjectAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = NewByWorkspaceObjectAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = NewByWorkspaceObjectAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceNameAndNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceNameAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceObjectAndNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceObjectAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceNameAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceObjectAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionName)]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceNameAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceObjectAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionId)]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceNameAndNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SignInName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceObjectAndNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SignInName)]
        [Alias("Email", "UserPrincipalName")]
        [ValidateNotNullOrEmpty]
        public string SignInName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceNameAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.ServicePrincipalName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceObjectAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.ServicePrincipalName)]
        [ValidateNotNullOrEmpty]
        public string ServicePrincipalName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceNameAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PrincipalId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceObjectAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PrincipalId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceNameAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PrincipalId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByWorkspaceObjectAndRoleDefinitionIdAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PrincipalId)]
        [Alias("Id", "PrincipalId")]
        [ValidateNotNullOrEmpty]
        public string ObjectId { get; set; }

        // Compared with Remove-AzSynapseRoleAssignment and Get-AzSynapseRoleAssignment, no need to specify roleAssignment, it is created as
        // random uuid. Hence unnecessary to specify the ParameterSetName
        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.WorkspaceItemType)]
        [ValidateNotNullOrEmpty]
        public WorkspaceItemType ItemType { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.WorkspaceItem)]
        [ValidateNotNullOrEmpty]
        public string Item { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

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

            if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.CreatingSynapseRoleAssignment, this.WorkspaceName, this.RoleDefinitionId, this.ObjectId)))
            {
                // Item type and item should appear Report error if either item type or item is specified.
                if ((!this.IsParameterBound(c => c.ItemType) && this.IsParameterBound(c => c.Item)) ||
                    (this.IsParameterBound(c => c.ItemType) && !this.IsParameterBound(c => c.Item)))
                {
                    throw new AzPSInvalidOperationException(String.Format(Resources.WorkspaceItemTypeAndItemNotAppearTogether));
                }

                string roleAssignmentId = Guid.NewGuid().ToString();
                string scope = SynapseAnalyticsClient.GetRoleAssignmentScope(this.WorkspaceName, itemType, this.Item);
                PSRoleAssignmentDetails roleAssignmentDetails = new PSRoleAssignmentDetails(SynapseAnalyticsClient.CreateRoleAssignment(roleAssignmentId, this.RoleDefinitionId, this.ObjectId, scope));
                WriteObject(roleAssignmentDetails);
            }
        }
    }
}
