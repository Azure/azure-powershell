using System.Management.Automation;
using Microsoft.Azure.Management.ServerManagement;

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Node
{
    [Cmdlet(VerbsCommon.Get, "AzureRmServerManagementNode"), OutputType(typeof(Model.Node))]
    public class GetServerManagementNodeCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "The targeted resource group.", ValueFromPipelineByPropertyName = true)]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the node to retrieve.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            // lookup just one node
            if (NodeName != null)
            {
                WriteVerbose($"Getting Node for {NodeName}");
                WriteObject( new Model.Node( Client.Node.Get(ResourceGroupName,NodeName)));
                return;
            }

            // lookup by resource group
            if (!string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                WriteVerbose($"Getting Nodes in resource group {ResourceGroupName}");
                foreach (var node in Client.Node.ListForResourceGroup(ResourceGroupName))
                {
                    WriteObject(new Model.Node(node));
                }
                return;
            }

            // grab everything for the whole subscription
            foreach (var node in Client.Node.List())
            {
                WriteVerbose($"Getting all Nodes in entire subscription ");
                WriteObject(new Model.Node(node));
            }
        }
    }
}