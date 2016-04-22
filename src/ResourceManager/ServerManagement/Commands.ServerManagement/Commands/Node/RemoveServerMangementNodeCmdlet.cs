using System.Management.Automation;
using Microsoft.Azure.Management.ServerManagement;

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Node
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmServerManagementNode")]
    public class RemoveServerManagementNodeCmdlet : ServerManagementCmdlet
    {
        #region ByName
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.", ValueFromPipelineByPropertyName = true,ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the node to delete.", ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }
        #endregion

        #region ByObject
        [Parameter(Mandatory = true, HelpMessage = "The node to delete.", ValueFromPipeline = true, ParameterSetName = "ByObject")]
        [ValidateNotNull]
        public Model.Node Node { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (Node != null)
            {
                WriteVerbose($"Using Gateway object for resource/gateway name");
                ResourceGroupName = Node.ResourceGroupName;
                NodeName = Node.Name;
            }

            WriteVerbose($"Removing Node {ResourceGroupName}/{NodeName}");
            Client.Node.Delete(ResourceGroupName, NodeName);
        }
    }
}