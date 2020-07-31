using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.PipelineRun,
        DefaultParameterSetName = GetByNameAndId)]
    [OutputType(typeof(PSPipelineRun))]
    public class GetAzureSynapsePipelineRun : SynapseArtifactsCmdletBase
    {
        private const string GetByNameAndId = "GetByNameAndId";
        private const string GetByObjectAndId = "GetByObjectAndId";
        private const string GetByNameAndTime = "GetByNameAndTime";
        private const string GetByObjectAndTime = "GetByObjectAndTime";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByNameAndId,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByNameAndTime,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByObjectAndId,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByObjectAndTime,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = GetByNameAndId,
            HelpMessage = HelpMessages.RunId)]
        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = GetByObjectAndId,
            HelpMessage = HelpMessages.RunId)]
        [ValidateNotNullOrEmpty]
        public string PipelineRunId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = GetByNameAndTime,
            HelpMessage = HelpMessages.LastUpdatedAfter)]
        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = GetByObjectAndTime,
            HelpMessage = HelpMessages.LastUpdatedAfter)]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset RunStartedAfter { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = GetByNameAndTime,
            HelpMessage = HelpMessages.LastUpdatedBefore)]
        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = GetByObjectAndTime,
            HelpMessage = HelpMessages.LastUpdatedBefore)]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset RunStartedBefore { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.PipelineRunId))
            {
                WriteObject(new PSPipelineRun(SynapseAnalyticsClient.GetPipelineRun(this.PipelineRunId), this.WorkspaceName));
            }
            else
            {
                RunFilterParameters filter = new RunFilterParameters(this.RunStartedAfter, this.RunStartedBefore);
                WriteObject(SynapseAnalyticsClient.QueryPipelineRunsByWorkspace(filter)
                    .Select(element => new PSPipelineRun(element, this.WorkspaceName)),true);
            }
        }
    }
}
