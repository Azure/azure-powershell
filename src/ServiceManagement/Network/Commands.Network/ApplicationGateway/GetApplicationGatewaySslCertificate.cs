// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Properties;
using Microsoft.WindowsAzure.Management.Network.Models;
using PowerShellAppGwModel = Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway
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
