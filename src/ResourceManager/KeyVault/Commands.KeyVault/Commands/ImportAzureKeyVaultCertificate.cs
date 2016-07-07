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
using System.Collections;
using System.IO;
using System.Security;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Commands.KeyVault.Models;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Imports a certificate to the key vault. The certificate can be created by 
    /// adding the certificate after getting the CSR from 
    /// Add-AzureKeyVaultCertificate issued by a Certificate Authority or by 
    /// importing an existing certificate package file that contains both the 
    /// certificate and private key (example: PFX or P12 files).
    /// </summary>
    [Cmdlet(VerbsData.Import, CmdletNoun.AzureKeyVaultCertificate,
        SupportsShouldProcess = true,
        DefaultParameterSetName = ImportCertificateFromFileParameterSet,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(KeyVaultCertificate))]
    public class ImportAzureKeyVaultCertificate : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ImportCertificateFromFileParameterSet = "ImportCertificateFromFile";
        private const string ImportWithPrivateKeyFromFileParameterSet = "ImportWithPrivateKeyFromFile";
        private const string ImportWithPrivateKeyFromCollectionParameterSet = "ImportWithPrivateKeyFromCollection";
        private const string ImportWithPrivateKeyFromStringParameterSet = "ImportWithPrivateKeyFromString";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// VaultName
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 1,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.CertificateName)]
        public string Name { get; set; }

        /// <summary>
        /// File Path
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ImportCertificateFromFileParameterSet,
                   HelpMessage = "Specifies the path to the file that contains the certificate to add to key vault.")]
        [Parameter(Mandatory = true,
                   ParameterSetName = ImportWithPrivateKeyFromFileParameterSet,
                   HelpMessage = "Specifies the path to the file that contains the certificate and private key to add to key vault.")]
        public string FilePath { get; set; }

        /// <summary>
        /// Certificate as a string
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ImportWithPrivateKeyFromStringParameterSet,
                   HelpMessage = "The certificate and private key to add to key vault as a string.")]
        public string CertificateString { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ImportWithPrivateKeyFromFileParameterSet,
                   HelpMessage = "Specifies the password for the certificate and private key file to import.")]
        [Parameter(Mandatory = false,
                    ParameterSetName = ImportWithPrivateKeyFromStringParameterSet,
                    HelpMessage = "Specifies the password for the certificate and private key base64 encoded string to import.")]
        public SecureString Password { get; set; }

        /// <summary>
        /// Certificate Collection
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ImportWithPrivateKeyFromCollectionParameterSet,
                   HelpMessage = "Specifies the certificate collection to add to key vault.")]
        public X509Certificate2Collection CertificateCollection { get; set; }

        /// <summary>
        /// Certificate tags
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable representing certificate tags.")]        
        public Hashtable Tag { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(Name, Properties.Resources.ImportCertificate))
            {
                List<CertificateBundle> certBundleList = new List<CertificateBundle>();
                CertificateBundle certBundle = null;

                switch (ParameterSetName)
                {
                    case ImportCertificateFromFileParameterSet:

                        certBundle = this.DataServiceClient.MergeCertificate(
                            VaultName,
                            Name,
                            LoadCertificateFromFile(),
                            Tag == null ? null : Tag.ConvertToDictionary());

                        break;

                    case ImportWithPrivateKeyFromFileParameterSet:

                        X509Certificate2Collection userProvidedCertColl = InitializeCertificateCollection();
                        X509Certificate2Collection certColl = new X509Certificate2Collection();

                        byte[] base64Bytes;

                        if (Password == null)
                        {
                            base64Bytes = userProvidedCertColl.Export(X509ContentType.Pfx);
                        }
                        else
                        {
                            base64Bytes = userProvidedCertColl.Export(X509ContentType.Pfx, Password.ConvertToString());
                        }

                        string base64CertCollection = Convert.ToBase64String(base64Bytes);
                        certBundle = this.DataServiceClient.ImportCertificate(VaultName, Name, base64CertCollection, Password, Tag == null ? null : Tag.ConvertToDictionary());

                        break;

                    case ImportWithPrivateKeyFromCollectionParameterSet:
                        certBundle = this.DataServiceClient.ImportCertificate(VaultName, Name, CertificateCollection, Tag == null ? null : Tag.ConvertToDictionary());

                        break;

                    case ImportWithPrivateKeyFromStringParameterSet:
                        certBundle = this.DataServiceClient.ImportCertificate(VaultName, Name, CertificateString, Password, Tag == null ? null : Tag.ConvertToDictionary());

                        break;

                    default:
                        throw new ArgumentException(KeyVaultProperties.Resources.BadParameterSetName);
                }

                var certificate = KeyVaultCertificate.FromCertificateBundle(certBundle);
                this.WriteObject(certificate);
            }
        }

        internal X509Certificate2Collection LoadCertificateFromFile()
        {
            FileInfo certFile = new FileInfo(this.GetUnresolvedProviderPathFromPSPath(this.FilePath));
            if (!certFile.Exists)
            {
                throw new FileNotFoundException(string.Format(KeyVaultProperties.Resources.CertificateFileNotFound, this.FilePath));
            }

            var certificates = new X509Certificate2Collection();
            certificates.Import(certFile.FullName);
            return certificates;
        }

        internal X509Certificate2Collection InitializeCertificateCollection()
        {
            FileInfo certFile = new FileInfo(this.GetUnresolvedProviderPathFromPSPath(this.FilePath));
            if (!certFile.Exists)
            {
                throw new FileNotFoundException(string.Format(KeyVaultProperties.Resources.CertificateFileNotFound, this.FilePath));
            }

            X509Certificate2Collection certificateCollection = new X509Certificate2Collection();

            if (null == this.Password)
            {
                certificateCollection.Import(certFile.FullName);
            }
            else
            {
                certificateCollection.Import(certFile.FullName, this.Password.ConvertToString(), X509KeyStorageFlags.Exportable);
            }

            return certificateCollection;
        }
    }
}
