using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Properties;
using Microsoft.WindowsAzure.Management.Network.Models;
using PowerShellAppGwModel = Microsoft.Azure.Commands.Network.ApplicationGateway.Model;

namespace Microsoft.Azure.Commands.Network.ApplicationGateway
{
    [Cmdlet(VerbsCommon.Get, "AzureApplicationGatewaySslCertificate"), 
        OutputType(typeof(PowerShellAppGwModel.ApplicationGatewayCertificate), typeof(List<PowerShellAppGwModel.ApplicationGatewayCertificate>))]
    public class GetApplicationGatewayCertificateCommand : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Gateway Name representing the Application Gateway")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Certificate Name")]
        [ValidateNotNullOrEmpty]
        public string CertificateName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(CertificateName))
            {
                GetByCertificateName();
            }
            else
            {
                GetNoCertificateName();
            }
        }

        private void GetByCertificateName()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewaySslCertificateBeginOperation, CommandRuntime.ToString()));
            var certificate = Client.GetApplicationGatewayCertificate(Name, CertificateName);
            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewaySslCertificateCompletedOperation, CommandRuntime.ToString()));

            WriteObject(certificate);
        }

        private void GetNoCertificateName()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewaySslCertificateBeginOperation, CommandRuntime.ToString()));
            var certificates = Client.ListApplicationGatewayCertificate(Name);
            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewaySslCertificateCompletedOperation, CommandRuntime.ToString()));

            WriteObject(certificates, true);
        }
    }
}
