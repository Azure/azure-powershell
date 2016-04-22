using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Management.ServerManagement;

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Gateway
{
    [Cmdlet(VerbsCommon.New, "AzureRmServerManagementGateway"), OutputType(typeof(Model.Gateway))]
    public class NewServerManagementGatewayCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the gateway to create.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string GatewayName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group location.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Allow the gateway to auto-upgrade itself.", ValueFromPipelineByPropertyName = true)]
        public SwitchParameter AutoUpgrade { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Key/value pairs associated with the gateway.", ValueFromPipelineByPropertyName = true)]
        public Hashtable Tags { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            // create the gateway object
            WriteVerbose($"Creating gateway for {ResourceGroupName}/{GatewayName}/{Location}");
            var gateway = new Model.Gateway(Client.Gateway.Create(ResourceGroupName, GatewayName, Location, Tags,
                AutoUpgrade.IsPresent
                    ? Microsoft.Azure.Management.ServerManagement.Models.AutoUpgrade.On
                    : Microsoft.Azure.Management.ServerManagement.Models.AutoUpgrade.Off));


            // create the gawe
            WriteObject(gateway);
        }
    }
}
