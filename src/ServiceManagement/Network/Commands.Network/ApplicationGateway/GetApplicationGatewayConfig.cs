using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Properties;
using Microsoft.WindowsAzure.Management.Network.Models;
using PowerShellAppGwModel = Microsoft.Azure.Commands.Network.ApplicationGateway.Model;

namespace Microsoft.Azure.Commands.Network.ApplicationGateway
{
    [Cmdlet(VerbsCommon.Get, "AzureApplicationGatewayConfig"), OutputType(typeof(PowerShellAppGwModel.ApplicationGatewayConfigContext))]
    public class GetApplicationGatewayConfigCommand : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Gateway Name representing the Application Gateway")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The file path to save the application gateway configuration to.")]
        [ValidateNotNullOrEmpty]
        public string ExportToFile  { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewayConfigBeginOperation, CommandRuntime.ToString()));
            PowerShellAppGwModel.ApplicationGatewayConfigContext config = Client.GetApplicationGatewayConfig(Name);

            if (!string.IsNullOrEmpty(this.ExportToFile))
            {
                config.ExportToFile(this.ExportToFile);
            }

            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewayConfigCompletedOperation, CommandRuntime.ToString()));

            WriteObject(config);
        }
    }
}
