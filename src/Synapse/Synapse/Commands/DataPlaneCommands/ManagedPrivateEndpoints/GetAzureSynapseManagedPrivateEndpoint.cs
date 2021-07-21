using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;


namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.ManagedPrivateEndpoint,
        DefaultParameterSetName = GetByName)]
    [OutputType(typeof(PSManagedPrivateEndpointResource))]
    public class GetAzureSynapseManagedPrivateEndpoint : SynapseManagedPrivateEndpointsClientCmdletBase
    {
        private const string GetByName = "GetByName";
        private const string GetByObject = "GetByObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.ManagedPrivateEndpointName)]
        [ValidateNotNullOrEmpty]
        [Alias("ManagedPrivateEndpointName")]
        public string PrivateEndpointName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.VirtualNetworkName)]
        [ValidateNotNullOrEmpty]
        [Alias("VNetName")]
        public string VirtualNetworkName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }
            if(this.IsParameterBound(c => this.PrivateEndpointName))
            {
                if (!string.IsNullOrEmpty(PrivateEndpointName) && !string.IsNullOrEmpty(VirtualNetworkName))
                {
                    WriteObject(new PSManagedPrivateEndpointResource(SynapseManagedPrivateEndpointsClient.GetManagedPrivateEndpoint(this.PrivateEndpointName, this.VirtualNetworkName), this.WorkspaceName));
                }
            }
            else
            {
                var privateEndpoints = SynapseManagedPrivateEndpointsClient.ListManagedPrivateEndpoints(this.VirtualNetworkName)
                   .Select(element => new PSManagedPrivateEndpointResource(element, this.WorkspaceName));
                WriteObject(privateEndpoints, true);
            }

            
       }
    }
}
