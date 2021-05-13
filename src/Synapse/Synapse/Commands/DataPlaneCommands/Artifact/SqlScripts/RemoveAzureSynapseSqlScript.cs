using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlScript,
        DefaultParameterSetName = RemoveByName, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureSynapseSqlScript : SynapseArtifactsCmdletBase
    {
        private const string RemoveByName = "RemoveByName";
        private const string RemoveByObject = "RemoveByObject";
        private const string RemoveByInputObject = "NewByInputObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = RemoveByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.SqlScriptName)]
        [ValidateNotNullOrEmpty]
        [Alias("SqlScriptName")]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = RemoveByInputObject,
            Mandatory = true, HelpMessage = HelpMessages.SqlScriptObject)]
        [ValidateNotNull]
        public PSSqlScriptResource InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.Force)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.Name = resourceIdentifier.ResourceName;
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveSynapseSqlScript, Name),
                string.Format(Resources.RemovingSynapseSqlScript, this.Name, this.WorkspaceName),
                Name,
                () =>
                {
                    SynapseAnalyticsClient.DeleteSqlScript(this.Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
