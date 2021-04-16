using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.RoleScope,
        DefaultParameterSetName = GetByWorkspaceNameParameterSet)]
    [OutputType(typeof(PSSynapseRole))]
    public class GetAzureSynapseRoleScope : SynapseRoleCmdletBase
    {
        private const string GetByWorkspaceNameParameterSet = "GetByWorkspaceNameParameterSet";
        private const string GetByWorkspaceObjectParameterSet = "GetByWorkspaceObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByWorkspaceObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceResourceId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.WorkspaceResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.WorkspaceName = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            var roleScopes = SynapseAnalyticsClient.ListRoleScopes();
            WriteObject(roleScopes, true);
        }
    }
}
