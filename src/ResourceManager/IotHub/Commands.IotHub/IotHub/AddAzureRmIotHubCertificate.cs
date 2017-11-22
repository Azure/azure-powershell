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

namespace Microsoft.Azure.Commands.Management.IotHub
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using System.Security.Cryptography.X509Certificates;
    using System.IO;
    using System.Globalization;

    [Cmdlet(VerbsCommon.Add, "AzureRmIotHubCertificate")]
    [OutputType(typeof(PSCertificateDescription))]
    public class AddAzureRmIotHubCertificate : IotHubBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "Name of the Certificate")]
        [ValidateNotNullOrEmpty]
        public string CertificateName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = "base-64 representation of X509 certificate .cer file or .pem file path.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(
            Position = 4,
            Mandatory = false,
            HelpMessage = "Etag of the Certificate")]
        [ValidateNotNullOrEmpty]
        public string Etag { get; set; }

        public override void ExecuteCmdlet()
        {
            string certificate = string.Empty;
            FileInfo fileInfo = new FileInfo(this.Path);
            switch(fileInfo.Extension.ToLower(CultureInfo.InvariantCulture))
            {
                case ".cer":
                    var certificateByteContent = File.ReadAllBytes(this.Path);
                    certificate = Convert.ToBase64String(certificateByteContent);
                    break;
                case ".pem":
                    certificate = File.ReadAllText(this.Path);
                    break;
                default:
                    certificate = this.Path;
                    break;
            }
            
            CertificateBodyDescription certificateBodyDescription = new CertificateBodyDescription();
            certificateBodyDescription.Certificate = certificate;

            CertificateDescription certificateDescription;
            if (this.Etag != null)
            {
                certificateDescription = this.IotHubClient.Certificates.CreateOrUpdate(this.ResourceGroupName, this.Name, this.CertificateName, certificateBodyDescription, this.Etag);
            }
            else
            {
                certificateDescription = this.IotHubClient.Certificates.CreateOrUpdate(this.ResourceGroupName, this.Name, this.CertificateName, certificateBodyDescription);
            }

            this.WriteObject(IotHubUtils.ToPSCertificateDescription(certificateDescription), true);
        }
    }
}



