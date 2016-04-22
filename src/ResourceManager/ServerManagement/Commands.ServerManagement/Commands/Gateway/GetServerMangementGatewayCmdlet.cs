using System.Management.Automation;
using Microsoft.Azure.Management.ServerManagement;

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Gateway
{
    [Cmdlet(VerbsCommon.Get, "AzureRmServerManagementGateway"), OutputType(typeof(Model.Gateway))]
    public class GetServerManagementGatewayCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "The targeted resource group.", ValueFromPipelineByPropertyName = true)]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                // list the gateways for the Resource Group
                WriteVerbose($"Listing gateways in resource group {ResourceGroupName}");
                foreach (var gateway in Client.Gateway.ListForResourceGroup(ResourceGroupName))
                {
                    WriteObject(new Model.Gateway( gateway));
                }
            }
            else
            {
                WriteVerbose($"Listing gateways in whole subscription");
                // list the gateways for the subscription
                foreach (var gateway in Client.Gateway.List())
                {
                    WriteObject(new Model.Gateway(gateway));
                }
            }

        }
    }
}