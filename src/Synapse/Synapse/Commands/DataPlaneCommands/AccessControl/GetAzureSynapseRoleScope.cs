using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
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

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByWorkspaceNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        public override void ExecuteCmdlet()
        {
            var roleScopes = SynapseAnalyticsClient.ListRoleScopes();
            WriteObject(roleScopes, true);
        }
    }
}
