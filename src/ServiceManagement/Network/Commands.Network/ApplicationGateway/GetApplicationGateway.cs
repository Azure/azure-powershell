using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Properties;
using Microsoft.WindowsAzure.Management.Network.Models;
using PowerShellAppGwModel = Microsoft.Azure.Commands.Network.ApplicationGateway.Model;

namespace Microsoft.Azure.Commands.Network.ApplicationGateway
{
    [Cmdlet(VerbsCommon.Get, "AzureApplicationGateway"), OutputType(typeof(PowerShellAppGwModel.ApplicationGateway), typeof(IEnumerable<PowerShellAppGwModel.ApplicationGateway>))]
    public class GetApplicationGatewayCommand : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Gateway Name representing the Application Gateway")]        
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                GetByGatewayName();
            }
            else
            {
                GetNoGatewayName();
            }
        }

        private void GetByGatewayName()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewayBeginOperation, CommandRuntime.ToString()));
            var gateway = Client.GetApplicationGateway(Name);
            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewayCompletedOperation, CommandRuntime.ToString()));

            WriteObject(gateway);
        }

        private void GetNoGatewayName()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewayBeginOperation, CommandRuntime.ToString()));
            var gateways = Client.ListApplicationGateway();
            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewayCompletedOperation, CommandRuntime.ToString()));

            WriteObject(gateways, true);   
        }
    }
}
