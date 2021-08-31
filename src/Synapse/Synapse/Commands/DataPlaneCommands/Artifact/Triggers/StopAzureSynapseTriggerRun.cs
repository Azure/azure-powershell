using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Synapse.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet("Stop", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.TriggerRun,
        DefaultParameterSetName = StopByName, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class StopAzureSynapseTriggerRun : SynapseArtifactsCmdletBase
    {
        private const string StopByName = "StopByName";
        private const string StopByWorkspaceObject = "StopByWorkspaceObject";
        private const string StopByInputObject = "StopByInputObject";

        [Parameter(ValueFromPipeline = true, ParameterSetName = StopByInputObject, 
            Mandatory = true, HelpMessage = HelpMessages.HelpTriggerRun)]
        [ValidateNotNullOrEmpty]
        public PSTriggerRun InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StopByWorkspaceObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByName,
            Mandatory = true, HelpMessage = HelpMessages.TriggerName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByWorkspaceObject,
            Mandatory = true, HelpMessage = HelpMessages.TriggerName)]
        [Alias("TriggerName")]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByName,
            Mandatory = true, HelpMessage = HelpMessages.TriggerRunId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByWorkspaceObject,
            Mandatory = true, HelpMessage = HelpMessages.TriggerRunId)]
        public string TriggerRunId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.WorkspaceName = this.InputObject.WorkspaceName;
                this.Name = this.InputObject.TriggerName;
                this.TriggerRunId = this.InputObject.TriggerRunId;
            }

            if (ShouldProcess(String.Format(Resources.StoppingSynapseTriggerRun, TriggerRunId)))
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
