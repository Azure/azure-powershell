using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Properties;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.ApplicationGateway
{
    [Cmdlet(VerbsCommon.Add, "AzureApplicationGatewaySslCertificate"), OutputType(typeof(ApplicationGatewayOperationResponse))]
    public class AddApplicationGatewayCertificateCommand : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Gateway Name representing the Application Gateway")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Certificate Name")]
        [ValidateNotNullOrEmpty]
        public string CertificateName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Certificate Password")]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path of Certificate File")]
        [ValidateNotNullOrEmpty]
        public string CertificateFile { get; set; }
        public override void ExecuteCmdlet()
        {            
            WriteVerboseWithTimestamp(string.Format(Resources.AddAzureApplicationGatewaySslCertificateBeginOperation, CommandRuntime.ToString()));
            var responseObject = Client.AddApplicationGatewayCertificate(Name, CertificateName, Password, CertificateFile);
            WriteVerboseWithTimestamp(string.Format(Resources.AddAzureApplicationGatewaySslCertificateCompletedOperation, CommandRuntime.ToString()));

            WriteObject(responseObject);
        }
    }
}
