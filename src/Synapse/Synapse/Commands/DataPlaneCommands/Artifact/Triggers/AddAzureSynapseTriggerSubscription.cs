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
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Trigger + SynapseConstants.Subscription,
        DefaultParameterSetName = AddByName, SupportsShouldProcess = true)]
    public class AddAzureSynapseTriggerSubscription : SynapseArtifactsCmdletBase
    {
        private const string AddByName = "AddByName";
        private const string AddByObject = "AddByObject";
        private const string AddByInputObject = "AddByInputObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = AddByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = AddByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = AddByName,
            Mandatory = true, HelpMessage = HelpMessages.TriggerName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = AddByObject,
            Mandatory = true, HelpMessage = HelpMessages.TriggerName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = AddByInputObject,
            Mandatory = true, HelpMessage = HelpMessages.TriggerObject)]
        [ValidateNotNull]
        public PSTriggerResource InputObject { get; set; }

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

            if (this.ShouldProcess(this.Name, String.Format(Resources.AddingSynapseTriggerSubscribe, this.Name)))
            {
                WriteObject(new PSTriggerSubscribeTriggerToEventsOperation(SynapseAnalyticsClient.StartSubscribeTriggerToEvents(this.Name)));
            }
        }
    }
}
