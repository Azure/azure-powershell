using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.ManagedPrivateEndpoint,
        DefaultParameterSetName = RemoveByName, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureSynapseManagedPrivateEndpoint : SynapseManagedPrivateEndpointsClientCmdletBase
    {
        private const string RemoveByName = "RemoveByName";
        private const string RemoveByObject = "RemoveByObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = RemoveByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByName,
            Mandatory = true, HelpMessage = HelpMessages.ManagedPrivateEndpointName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveByObject,
            Mandatory = true, HelpMessage = HelpMessages.ManagedPrivateEndpointName)]
        [ValidateNotNullOrEmpty]
        [Alias("ManagedPrivateEndpointName")]
        public string PrivateEndpointName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.VirtualNetworkName)]
        [ValidateNotNullOrEmpty]
        [Alias("VNetName")]
        public string VirtualNetworkName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }


        [Parameter(Mandatory = false, HelpMessage = HelpMessages.Force)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveSynapseManagedPrivateEndpoint, this.PrivateEndpointName),
                string.Format(Resources.RemovingSynapseManagedPrivateEndpoint, this.PrivateEndpointName, this.WorkspaceName),
                PrivateEndpointName,
                () =>
                {
                    SynapseManagedPrivateEndpointsClient.DeleteManagedPrivateEndpoint(this.PrivateEndpointName,this.VirtualNetworkName);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
