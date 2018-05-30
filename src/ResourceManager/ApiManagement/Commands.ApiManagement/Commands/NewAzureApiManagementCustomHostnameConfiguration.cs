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

    [Cmdlet(VerbsCommon.New, "AzureRmApiManagementCustomHostnameConfiguration", DefaultParameterSetName = "NoChangeCertificate")]
    [OutputType(typeof(PsApiManagementCustomHostNameConfiguration))]
    public class NewAzureApiManagementCustomHostnameConfiguration : AzureRMCmdlet
    {
        private const string NoChangeCertificate = "NoChangeCertificate";
        private const string SslCertificateFromFile = "SslCertificateFromFile";
        private const string SslCertificateFromKeyVault = "SslCertificateFromKeyVault";

        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = NoChangeCertificate, Mandatory = true, HelpMessage = "Custom Hostname")]
        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateFromFile, Mandatory = true, HelpMessage = "Custom Hostname")]
        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateFromKeyVault, Mandatory = true, HelpMessage = "Custom Hostname")]
        [ValidateNotNullOrEmpty]
        public string Hostname { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = NoChangeCertificate, Mandatory = true, HelpMessage = "Hostname Type")]
        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateFromFile, Mandatory = true, HelpMessage = "Hostname Type")]
        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateFromKeyVault, Mandatory = true, HelpMessage = "Hostname Type")]
        public PsApiManagementHostnameType HostnameType { get; set; }
        
        [Parameter(
            ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateFromKeyVault,
            Mandatory = true,
            HelpMessage = "KeyVaultId to the secret storing the Custom SSL Certificate.")]
        public string KeyVaultId { get; set; }

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
        public PsApiManagementCertificateInformation HostNameCertificateInformation { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Determines whether the value is a secret and should be encrypted or not." +
                  " This parameter is optional. Default Value is false.")]
        public SwitchParameter DefaultSslBinding { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Determines whether the value is a secret and should be encrypted or not." +
                  " This parameter is optional. Default Value is false.")]
        public SwitchParameter NegotiateClientCertificate { get; set; }

        public override void ExecuteCmdlet()
        {
            var hostnameConfig = new PsApiManagementCustomHostNameConfiguration();
            hostnameConfig.Hostname = Hostname;
            hostnameConfig.HostnameType = HostnameType;

            if (!string.IsNullOrWhiteSpace(KeyVaultId))
            {
                hostnameConfig.KeyVaultId = KeyVaultId;
            }
            else if (!string.IsNullOrWhiteSpace(PfxPath))
            {
                byte[] certificate;
                using (var certStream = File.OpenRead(PfxPath))
                {
                    certificate = new byte[certStream.Length];
                    certStream.Read(certificate, 0, certificate.Length);
                }
                var encodedCertificate = Convert.ToBase64String(certificate);
                hostnameConfig.EncodedCertificate = encodedCertificate;

                if (PfxPassword != null)
                {
                    hostnameConfig.CertificatePassword = PfxPassword.ConvertToString();
                }
            }
            else if (HostNameCertificateInformation != null)
            {
                hostnameConfig.CertificateInformation = HostNameCertificateInformation;
            }
            else
            {
                throw new Exception("Missing Certificate configuration.");
            }

            hostnameConfig.DefaultSslBinding = DefaultSslBinding;
            hostnameConfig.NegotiateClientCertificate = NegotiateClientCertificate;

            WriteObject(hostnameConfig);
        }
    }
}