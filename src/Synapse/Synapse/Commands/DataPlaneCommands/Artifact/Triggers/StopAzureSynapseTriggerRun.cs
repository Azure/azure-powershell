using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet("Stop", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.TriggerRun,
        DefaultParameterSetName = StopByName)]
    [OutputType(typeof(bool))]
    public class StopAzureSynapseTriggerRun : SynapseArtifactsCmdletBase
    {
        private const string StopByName = "StopByName";
        private const string StopByWorkspaceObject = "StopByWorkspaceObject";
        private const string StopByTrObject = "StopByTRObject";

        [Parameter(ValueFromPipeline = true, ParameterSetName = StopByTrObject, 
            Mandatory = true, HelpMessage = HelpMessages.HelpTriggerRun)]
        [ValidateNotNullOrEmpty]
        public PSTriggerRun TriggerRunObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByTrObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StopByWorkspaceObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByTrObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByWorkspaceObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Alias("TriggerName")]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByWorkspaceObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        public string TriggerRunId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.TriggerRunObject))
            {
                this.Name = this.TriggerRunObject.TriggerName;
                this.TriggerRunId = this.TriggerRunObject.TriggerRunId;
            }

            if (ShouldProcess(TriggerRunId))
            {
                SynapseAnalyticsClient.StopTriggerRun(Name, TriggerRunId);
            }

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
