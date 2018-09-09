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

using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmVpnClientRootCertificate"), OutputType(typeof(PSVpnClientRootCertificate))]
    public class NewAzureVpnClientRootCertificateCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Client Root certificate")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Client Root Public certificate data")]
        [ValidateNotNullOrEmpty]
        public string PublicCertData { get; set; }

        public override void Execute()
        {

            base.Execute();
            var vpnClientRootCertificate = new PSVpnClientRootCertificate();
            vpnClientRootCertificate.Name = this.Name;
            vpnClientRootCertificate.PublicCertData = this.PublicCertData;

            WriteObject(vpnClientRootCertificate);
        }
    }
}
