using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Properties;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.ApplicationGateway
{
    [Cmdlet(VerbsCommon.Remove, "AzureApplicationGatewaySslCertificate"), OutputType(typeof(ApplicationGatewayOperationResponse))]
    public class RemoveApplicationGatewayCertificateCommand : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Gateway Name representing the Application Gateway")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Certificate Name")]
        [ValidateNotNullOrEmpty]
        public string CertificateName { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.RemoveAzureApplicationGatewaySslCertificateBeginOperation, CommandRuntime.ToString()));
            var responseObject = Client.RemoveApplicationGatewayCertificate(Name, CertificateName);
            WriteVerboseWithTimestamp(string.Format(Resources.RemoveAzureApplicationGatewaySslCertificateCompletedOperation, CommandRuntime.ToString()));

            WriteObject(responseObject);
        }
    }
}
