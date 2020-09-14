using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsLifecycle.Start, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Trigger,
        DefaultParameterSetName = StartByName, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class StartAzureSynapseTrigger : SynapseArtifactsCmdletBase
    {
        private const string StartByName = "StartByName";
        private const string StartByObject = "StartByObject";
        private const string StartByInputObject = "StartByInputObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StartByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StartByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StartByName,
            Mandatory = true, HelpMessage = HelpMessages.TriggerName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StartByObject,
            Mandatory = true, HelpMessage = HelpMessages.TriggerName)]
        [ValidateNotNullOrEmpty]
        [Alias("TriggerName")]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StartByInputObject,
            Mandatory = true, HelpMessage = HelpMessages.TriggerObject)]
        [ValidateNotNull]
        public PSTriggerResource InputObject { get; set; }

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

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.WorkspaceName = this.InputObject.WorkspaceName;
                this.Name = this.InputObject.Name;
            }

            if (this.ShouldProcess(this.Name, String.Format(Resources.StartingSynapseTrigger, this.Name, this.WorkspaceName)))
            {
                SynapseAnalyticsClient.StartStartTrigger(this.Name);
                if (PassThru)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
