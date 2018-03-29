//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.Models;
    using ResourceManager.Common;
    using System;
    using System.IO;
    using System.Management.Automation;
    using System.Security;
    using WindowsAzure.Commands.Common;

    [Cmdlet(VerbsCommon.New, "AzureRmApiManagementSystemCertificate", DefaultParameterSetName = "NoChangeCertificate")]
    [OutputType(typeof(PsApiManagementSystemCertificate))]
    public class NewAzureApiManagementSystemCertificate : AzureRMCmdlet
    {
        private const string NoChangeCertificate = "NoChangeCertificate";
        private const string SslCertificateFromFile = "SslCertificateFromFile";

        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = NoChangeCertificate, Mandatory = true, HelpMessage = "Certificate StoreName")]
        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateFromFile, Mandatory = true, HelpMessage = "Certificate StoreName")]
        [ValidateNotNullOrEmpty]
        public string StoreName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateFromFile,
            Mandatory = true,
            HelpMessage = "Path to a .pfx certificate file.")]
        public string PfxPath { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateFromFile,
            Mandatory = false,
            HelpMessage = "Password for the .pfx certificate file.")]
        public SecureString PfxPassword { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NoChangeCertificate,
            Mandatory = true,
            HelpMessage = "Existing Certificate Configuration.")]
        public PsApiManagementCertificateInformation CertificateInformation { get; set; }

        public override void ExecuteCmdlet()
        {
            var systemCertificate = new PsApiManagementSystemCertificate();
            systemCertificate.StoreName = StoreName;
                        
            if (!string.IsNullOrWhiteSpace(PfxPath))
            {
                byte[] certificate;
                using (var certStream = File.OpenRead(PfxPath))
                {
                    certificate = new byte[certStream.Length];
                    certStream.Read(certificate, 0, certificate.Length);
                }
                var encodedCertificate = Convert.ToBase64String(certificate);
                systemCertificate.EncodedCertificate = encodedCertificate;

                if (PfxPassword != null)
                {
                    systemCertificate.CertificatePassword = PfxPassword.ConvertToString();
                }
            }
            else if (CertificateInformation != null)
            {
                systemCertificate.CertificateInformation = CertificateInformation;
            }
            else
            {
                throw new Exception("Missing Certificate configuration.");
            }

            WriteObject(systemCertificate);
        }
    }
}