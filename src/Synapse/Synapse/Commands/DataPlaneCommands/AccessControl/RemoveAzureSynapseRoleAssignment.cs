using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.RoleAssignment,
        DefaultParameterSetName = RemoveByWorkspaceNameAndSignInNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureSynapseRoleAssignment : SynapseRoleCmdletBase
    {
        private const string RemoveByWorkspaceNameAndIdParameterSet = "RemoveByWorkspaceNameAndIdParameterSet";
        private const string RemoveByWorkspaceObjectAndIdParameterSet = "RemoveByWorkspaceObjectAndIdParameterSet";
        private const string RemoveByWorkspaceNameAndSignInNameParameterSet = "RemoveByWorkspaceNameAndNameParameterSet";
        private const string RemoveByWorkspaceObjectAndSignInNameParameterSet = "RemoveByWorkspaceObjectAndNameParameterSet";
        private const string RemoveByWorkspaceNameAndObjectIdParameterSet = "RemoveByWorkspaceNameAndObjectIdParameterSet";
        private const string RemoveByWorkspaceObjectAndObjectIdParameterSet = "RemoveByWorkspaceObjectAndObjectIdParameterSet";
        private const string RemoveByWorkspaceNameAndRoleDefinitionIdParameterSet = "RemoveByWorkspaceNameAndRoleDefinitionIdParameterSet";
        private const string RemoveByWorkspaceObjectAndRoleDefinitionIdParameterSet = "RemoveByWorkspaceObjectAndRoleDefinitionIdParameterSet";
        private const string RemoveByWorkspaceNameAndServicePrincipalNameParameterSet = "RemoveByWorkspaceNameAndServicePrincipalNameParameterSet";
        private const string RemoveByWorkspaceObjectAndServicePrincipalNameParameterSet = "RemoveByWorkspaceObjectAndServicePrincipalNameParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceNameAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceNameAndSignInNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceNameAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceNameAndRoleDefinitionIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceNameAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = RemoveByWorkspaceObjectAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = RemoveByWorkspaceObjectAndSignInNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = RemoveByWorkspaceObjectAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = RemoveByWorkspaceObjectAndRoleDefinitionIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = RemoveByWorkspaceObjectAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceNameAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleAssignmentId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceObjectAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleAssignmentId)]
        [ValidateNotNullOrEmpty]
        public string RoleAssignmentId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceNameAndSignInNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceObjectAndSignInNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceNameAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceObjectAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceNameAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceObjectAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionName)]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceNameAndRoleDefinitionIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceObjectAndRoleDefinitionIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionId)]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceNameAndSignInNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SignInName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceObjectAndSignInNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SignInName)]
        [Alias("Email", "UserPrincipalName")]
        [ValidateNotNullOrEmpty]
        public string SignInName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceNameAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.ServicePrincipalName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceObjectAndServicePrincipalNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.ServicePrincipalName)]
        [ValidateNotNullOrEmpty]
        public string ServicePrincipalName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceNameAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PrincipalId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceObjectAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PrincipalId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceNameAndRoleDefinitionIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PrincipalId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByWorkspaceObjectAndRoleDefinitionIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PrincipalId)]
        [Alias("Id", "PrincipalId")]
        [ValidateNotNullOrEmpty]
        public string ObjectId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.RoleAssignmentId))
            {
                if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.RemovingSynapseRoleAssignmentById, this.RoleAssignmentId, this.WorkspaceName)))
                {
                    SynapseAnalyticsClient.DeleteRoleAssignmentById(this.RoleAssignmentId);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                }
            }
            else
            {
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

                if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.RemovingSynapseRoleAssignment, this.RoleDefinitionId, this.ObjectId, this.WorkspaceName)))
                {
                    SynapseAnalyticsClient.DeleteRoleAssignmentByName(this.RoleDefinitionId, this.ObjectId);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                }
            }
        }
    }
}
