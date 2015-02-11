using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Properties;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.ApplicationGateway
{
    [Cmdlet(VerbsLifecycle.Start, "AzureApplicationGateway"), OutputType(typeof(ApplicationGatewayOperationResponse))]
    public class StartApplicationGatewayCommand : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Gateway Name representing the Application Gateway")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.StartAzureApplicationGatewayBeginOperation, CommandRuntime.ToString()));
            var responseObject = Client.ExecuteApplicationGatewayOperation(Name, "start");
            WriteVerboseWithTimestamp(string.Format(Resources.StartAzureApplicationGatewayCompletedOperation, CommandRuntime.ToString()));

            WriteObject(responseObject);
        }
    }
}
