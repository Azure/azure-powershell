using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Properties;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.ApplicationGateway
{
    [Cmdlet(VerbsLifecycle.Stop, "AzureApplicationGateway"), OutputType(typeof(ApplicationGatewayOperationResponse))]
    public class StopApplicationGatewayCommand : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Gateway Name representing the Application Gateway")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.StopAzureApplicationGatewayBeginOperation, CommandRuntime.ToString()));
            var responseObject = Client.ExecuteApplicationGatewayOperation(Name, "stop");
            WriteVerboseWithTimestamp(string.Format(Resources.StopAzureApplicationGatewayCompletedOperation, CommandRuntime.ToString()));

            WriteObject(responseObject);
        }
    }
}
