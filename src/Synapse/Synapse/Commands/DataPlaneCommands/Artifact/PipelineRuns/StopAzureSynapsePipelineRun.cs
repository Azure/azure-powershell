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
    [Cmdlet(VerbsLifecycle.Stop, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.PipelineRun,
        DefaultParameterSetName = RemoveByName, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class StopAzureSynapsePipelineRun : SynapseArtifactsCmdletBase
    {
        private const string RemoveByName = "RemoveByName";
        private const string RemoveByObject = "RemoveByObject";
        private const string RemoveByInputObject = "RemoveByInputObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = RemoveByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = RemoveByName,
            HelpMessage = HelpMessages.RunId)]
        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = RemoveByObject,
            HelpMessage = HelpMessages.RunId)]
        [ValidateNotNullOrEmpty]
        public string PipelineRunId { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = RemoveByInputObject,
            Mandatory = true, HelpMessage = HelpMessages.PipelineRunObject)]
        [ValidateNotNull]
        public PSPipelineRun InputObject { get; set; }

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
                this.PipelineRunId = this.InputObject.RunId;
            }

            if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.StoppingPipelineRun, this.PipelineRunId)))
            {
                SynapseAnalyticsClient.CancelPipelineRun(this.PipelineRunId);
                if (this.PassThru)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
