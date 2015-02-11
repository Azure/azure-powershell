using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Properties;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.ApplicationGateway
{
    [Cmdlet(VerbsCommon.New, "AzureApplicationGateway"), OutputType(typeof(ApplicationGatewayOperationResponse))]
    public class NewApplicationGatewayCommand : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of Application Gateway")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of of virtual network application gateway should be deployed in")]
        [ValidateNotNullOrEmpty]
        public string VnetName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subnets")]
        [ValidateNotNullOrEmpty]
        public List<string> Subnets { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Number of instances")]
        public uint InstanceCount { get; set; }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Size of application gateway Small/Medium/Large/ExtraLarge/A8")]
        public string GatewaySize { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description of application gateway")]
        public string Description { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.NewAzureApplicationGatewayBeginOperation, CommandRuntime.ToString()));
            var responseObject = Client.CreateApplicationGateway(Name, VnetName, Subnets, Description, InstanceCount, GatewaySize);
            WriteVerboseWithTimestamp(string.Format(Resources.NewAzureApplicationGatewayCompletedOperation, CommandRuntime.ToString()));

            WriteObject(responseObject);
        }
    }
}
    