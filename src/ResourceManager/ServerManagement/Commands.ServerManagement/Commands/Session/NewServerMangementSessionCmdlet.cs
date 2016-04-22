using System;
using System.Management.Automation;
using Microsoft.Azure.Management.ServerManagement;

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Session
{
    [Cmdlet(VerbsCommon.New, "AzureRmServerManagementSession"), OutputType(typeof(Model.Session))]
    public class NewServerManagementSessionCmdlet : ServerManagementCmdlet
    {
        #region ByName
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.", ValueFromPipelineByPropertyName = true,ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the node.", ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }
        #endregion

        #region ByNode
        [Parameter(Mandatory = true, HelpMessage = "The the node to create the session on.", ValueFromPipeline = true, ParameterSetName = "ByNode")]
        [ValidateNotNull]
        public Model.Node Node { get; set; }
        #endregion

        [Parameter(Mandatory = false, HelpMessage = "The name of the session to create. (Defaults to random)", ValueFromPipelineByPropertyName = true)]
        public string SessionName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The credentials to connect to the node.")]
        public PSCredential Credential { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Node != null)
            {
                ResourceGroupName = Node.ResourceGroupName;
                NodeName = Node.Name;
                if (Node.Credential != null && Credential == null)
                {
                    Credential = Node.Credential;
                }
                WriteVerbose($"Using Node object to for resourcegroup/node name");
            }

            if (SessionName == null)
            {
                SessionName = Guid.NewGuid().ToString();
                WriteVerbose($"Generating Session name {SessionName}");
            }

            WriteVerbose($"Getting Session resource for {ResourceGroupName}/{NodeName}/{SessionName}");
            WriteObject(new Model.Session(Client.Session.Create(ResourceGroupName, NodeName, SessionName, Credential.UserName, ToPlainText(Credential.Password))));
        }
    }
}