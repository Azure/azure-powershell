using System.Management.Automation;
using Microsoft.Azure.Management.ServerManagement;

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Session
{
    [Cmdlet(VerbsCommon.Get, "AzureRmServerManagementSession"), OutputType(typeof(Model.Session))]
    public class GetServerManagementSessionCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the node.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the session.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SessionName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            WriteVerbose($"Getting Session resource for {ResourceGroupName}/{NodeName}/{SessionName}");
            WriteObject(new Model.Session(Client.Session.Get(ResourceGroupName, NodeName, SessionName)));
        }
    }
}