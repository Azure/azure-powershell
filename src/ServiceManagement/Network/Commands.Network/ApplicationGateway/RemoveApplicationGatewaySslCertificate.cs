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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway
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
