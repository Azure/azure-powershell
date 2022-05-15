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
    using System;
    using System.Globalization;
    using System.IO;
    using System.Management.Automation;
    using System.Security;
    using Microsoft.Azure.Commands.ApiManagement.Models;
    using Properties;
    using ResourceManager.Common;
    using WindowsAzure.Commands.Common;
    using SdkModels = Microsoft.Azure.Management.ApiManagement.Models;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementCustomHostnameConfiguration", DefaultParameterSetName = "NoChangeCertificate")]
    [OutputType(typeof(PsApiManagementCustomHostNameConfiguration))]
    public class NewAzureApiManagementCustomHostnameConfiguration : AzureRMCmdlet
    {
        private const string NoChangeCertificate = "NoChangeCertificate";
        private const string SslCertificateFromFile = "SslCertificateFromFile";
        private const string SslCertificateFromKeyVault = "SslCertificateFromKeyVault";
        private const string SslCertificateManaged = "SslCertificateManaged";

        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = NoChangeCertificate, Mandatory = true, HelpMessage = "Custom Hostname")]
        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateFromFile, Mandatory = true, HelpMessage = "Custom Hostname")]
        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateFromKeyVault, Mandatory = true, HelpMessage = "Custom Hostname")]
        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateManaged, Mandatory = true, HelpMessage = "Custom Hostname")]
        [ValidateNotNullOrEmpty]
        public string Hostname { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = NoChangeCertificate, Mandatory = true, HelpMessage = "Hostname Type")]
        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateFromFile, Mandatory = true, HelpMessage = "Hostname Type")]
        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateFromKeyVault, Mandatory = true, HelpMessage = "Hostname Type")]
        [Parameter(ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateManaged, Mandatory = true, HelpMessage = "Hostname Type")]
        public PsApiManagementHostnameType HostnameType { get; set; }
        
        [Parameter(
            ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateFromKeyVault,
            Mandatory = true,
            HelpMessage = "KeyVaultId to the secret storing the Custom SSL Certificate.")]
        public string KeyVaultId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            ParameterSetName = SslCertificateFromKeyVault,
            Mandatory = false,
            HelpMessage = "User-Assigned Managed Identity ClientId to authenticate to KeyVault to fetch Custom SSL Certificate.")]
        public string IdentityClientId { get; set; }

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

        [Parameter(
            Mandatory = true,
            ParameterSetName = SslCertificateManaged,
            HelpMessage = "Determines whether we want to provision a managed certificate whose rotation is managed " +
            "by the platform")]
        public SwitchParameter ManagedCertificate { get; set; }

        public override void ExecuteCmdlet()
        {
            var hostnameConfig = new PsApiManagementCustomHostNameConfiguration();
            hostnameConfig.Hostname = Hostname;
            hostnameConfig.HostnameType = HostnameType;

            if (!string.IsNullOrWhiteSpace(KeyVaultId))
            {
                hostnameConfig.KeyVaultId = KeyVaultId;
                hostnameConfig.CertificateSource = SdkModels.CertificateSource.KeyVault;
                if (!string.IsNullOrWhiteSpace(IdentityClientId))
                {
                    hostnameConfig.IdentityClientId = IdentityClientId;
                }
            }
            else if (!string.IsNullOrWhiteSpace(PfxPath))
            {
                FileInfo localFile = new FileInfo(this.GetUnresolvedProviderPathFromPSPath(this.PfxPath));
                if (!localFile.Exists)
                {
                    throw new FileNotFoundException(string.Format(CultureInfo.CurrentCulture, Resources.SourceFileNotFound, this.PfxPath));
                }

                byte[] certificate;
                using (var certStream = File.OpenRead(localFile.FullName))
                {
                    certificate = new byte[certStream.Length];
                    certStream.Read(certificate, 0, certificate.Length);
                }
                var encodedCertificate = Convert.ToBase64String(certificate);
                hostnameConfig.EncodedCertificate = encodedCertificate;
                hostnameConfig.CertificateSource = SdkModels.CertificateSource.Custom;

                if (PfxPassword != null)
                {
                    hostnameConfig.CertificatePassword = PfxPassword.ConvertToString();
                }
            }
            else if (HostNameCertificateInformation != null)
            {
                hostnameConfig.CertificateInformation = HostNameCertificateInformation;
            }
            else if (ManagedCertificate.IsPresent)
            {
                // managed certificate
                hostnameConfig.CertificateSource = SdkModels.CertificateSource.Managed;
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
