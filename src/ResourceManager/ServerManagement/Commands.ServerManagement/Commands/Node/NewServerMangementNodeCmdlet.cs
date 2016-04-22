using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Management.ServerManagement;

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Node
{
    [Cmdlet(VerbsCommon.New, "AzureRmServerManagementNode"), OutputType(typeof(Model.Node))]
    public class NewServerManagementNodeCmdlet : ServerManagementCmdlet
    {
        #region ByName
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.", ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the gateway.", ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string GatewayName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group location.", ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }
        #endregion

        #region ByObject
        [Parameter(Mandatory = true, HelpMessage = "The gateway to place the node in.", ValueFromPipeline = true, ParameterSetName = "ByObject")]
        [ValidateNotNull]
        public Model.Gateway Gateway { get; set; }
        #endregion

        [Parameter(Mandatory = true, HelpMessage = "The name of the node to create.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The computer name of the node to connect to (will default to NodeName).", ValueFromPipelineByPropertyName = true)]
        public string ComputerName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The credentials to connect to the node.")]
        [ValidateNotNullOrEmpty]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Key/value pairs associated with the object.", ValueFromPipelineByPropertyName = true)]
        public Hashtable Tags { get; set; }
        
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Gateway != null)
            {
                WriteVerbose($"Using Gateway object for resource/gateway name/location");
                ResourceGroupName = Gateway.ResourceGroupName;
                GatewayName = Gateway.Name;
                Location = Gateway.Location;
            }

            WriteVerbose($"Creating new Node for {ResourceGroupName}/{NodeName}/{Location}/{GatewayName}");
            WriteObject(new Model.Node(Client.Node.Create(ResourceGroupName, NodeName ,Location, Tags, GatewayName, ComputerName ?? NodeName, Credential.UserName, ToPlainText(Credential.Password))){ Credential = Credential});
        }
    }
}