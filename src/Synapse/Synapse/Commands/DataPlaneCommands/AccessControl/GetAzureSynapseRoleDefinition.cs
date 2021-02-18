using Azure.Analytics.Synapse.AccessControl.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.RoleDefinition,
        DefaultParameterSetName = GetByWorkspaceNameAndIdParameterSet)]
    [OutputType(typeof(PSSynapseRole))]
    public class GetAzureSynapseRoleDefinition : SynapseRoleCmdletBase
    {
        private const string GetByWorkspaceNameAndIdParameterSet = "GetByWorkspaceNameAndIdParameterSet";
        private const string GetByWorkspaceObjectAndIdParameterSet = "GetByWorkspaceObjectAndIdParameterSet";
        private const string GetByWorkspaceNameAndNameParameterSet = "GetByWorkspaceNameAndNameParameterSet";
        private const string GetByWorkspaceObjectAndNameParameterSet = "GetByWorkspaceObjectAndNameParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByWorkspaceObjectAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByWorkspaceObjectAndNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RoleDefinitionId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RoleDefinitionId)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameAndNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RoleDefinitionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectAndNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RoleDefinitionName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.Id))
            {
                WriteObject(new PSSynapseRole(SynapseAnalyticsClient.GetRoleDefinitionById(this.Id)));
            }
            else
            {
                var roleDefinitions = SynapseAnalyticsClient.GetRoleDefinitions()
                    .Select(element => new PSSynapseRole(element));
                if (this.IsParameterBound(c => c.Name))
                {
                    PSSynapseRole role = roleDefinitions.SingleOrDefault(element => element.Name == this.Name);
                    if (role == null)
                    {
                        throw new InvalidOperationException(String.Format(Resources.RoleDefinitionNameDoesNotExist, this.Name));
                    }
                    WriteObject(role);
                }
                else
                {
                    WriteObject(roleDefinitions, true);
                }
            } 
        }
    }
}
