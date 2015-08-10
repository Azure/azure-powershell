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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Properties;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway
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
