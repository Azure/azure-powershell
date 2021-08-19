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
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.TriggerRun,
        DefaultParameterSetName = InvokeByName)]
    [OutputType(typeof(bool))]
    public class InvokeAzureSynapseTriggerRun : SynapseArtifactsCmdletBase
    {
        private const string InvokeByName = "InvokeByName";
        private const string InvokeByWorkspaceObject = "InvokeByWorkspaceObject";
        private const string InvokeByTrObject = "InvokeByTRObject";

        [Parameter(ValueFromPipeline = true, ParameterSetName = InvokeByTrObject, 
            Mandatory = true, HelpMessage = HelpMessages.HelpTriggerRun)]
        [ValidateNotNullOrEmpty]
        public PSTriggerRun TriggerRunObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = InvokeByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = InvokeByTrObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = InvokeByWorkspaceObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.TriggerName)]
        [ValidateNotNullOrEmpty]
        [Alias("TriggerName")]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.TriggerRunId)]
        [ValidateNotNullOrEmpty]
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
                SynapseAnalyticsClient.RerunTriggerRun(Name, TriggerRunId);
            }

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
