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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Security;
using System.Security.Cryptography.X509Certificates;

using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Imports a certificate to the key vault. The certificate can be created by 
    /// adding the certificate after getting the CSR from 
    /// Add-AzKeyVaultCertificate issued by a Certificate Authority or by 
    /// importing an existing certificate package file that contains both the 
    /// certificate and private key (example: PFX or P12 files).
    /// </summary>
    [Cmdlet("Import", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultCertificate",SupportsShouldProcess = true,DefaultParameterSetName = ImportCertificateFromFileParameterSet)]
    [OutputType(typeof(PSKeyVaultCertificate))]
    public class ImportAzureKeyVaultCertificate : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ImportCertificateFromFileParameterSet = "ImportCertificateFromFile";
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
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
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
        public string FilePath { get; set; }

        /// <summary>
        /// Base64 encoded representation of the certificate object to import
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ImportWithPrivateKeyFromStringParameterSet,
                   HelpMessage = "Base64 encoded representation of the certificate object to import. This certificate needs to contain the private key.")]
        public string CertificateString { get; set; }

        /// <summary>
        /// Specifies type of the certificate to be imported.
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ImportWithPrivateKeyFromStringParameterSet,
                   HelpMessage = "Specifies the type of the certificate to be imported. Regards certificate string as PFX format by default.")]
        [PSArgumentCompleter(Constants.Pkcs12ContentType, Constants.PemContentType)]
        public string ContentType { get; set; } = Constants.Pkcs12ContentType;

        /// <summary>
        /// Password
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ImportCertificateFromFileParameterSet,
                   HelpMessage = "Specifies the password for the certificate and private key file to import.")]
        [Parameter(Mandatory = false,
                    ParameterSetName = ImportWithPrivateKeyFromStringParameterSet,
                    HelpMessage = "Specifies the password for the certificate and private key base64 encoded string to import.")]
        public SecureString Password { get; set; }

        /// <summary>
        /// File Path
        /// </summary>
        [Parameter(Mandatory = false,
                   HelpMessage = "A file path to specify management policy for the certificate that contains JSON encoded policy definition. Mutual-exclusive to PolicyObject.")]
        public string PolicyPath { get; set; }

        /// <summary>
        /// File Path
        /// </summary>
        [Parameter(Mandatory = false,
                    ValueFromPipeline = true,
                    HelpMessage = "An in-memory object to specify management policy for the certificate. Mutual-exclusive to PolicyPath.")]
        public PSKeyVaultCertificatePolicy PolicyObject { get; set; }

        /// <summary>
        /// Certificate Collection
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 2,
                   ValueFromPipeline = true,
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

        protected override void BeginProcessing()
        {
            FilePath = this.TryResolvePath(FilePath);
            PolicyPath = this.TryResolvePath(PolicyPath);
            base.BeginProcessing();
        }

        private void ValidateParameters()
        {
            // Verify the FileNotFound whether exists
            if (this.IsParameterBound(c => c.FilePath))
            {
                if (!File.Exists(FilePath))
                {
                    throw new AzPSArgumentException(string.Format(Resources.FileNotFound, this.FilePath), nameof(FilePath));
                }
                if (IsPemFile(FilePath))
                {
                    ContentType = Constants.PemContentType;
                }
                else
                {
                    ContentType = Constants.Pkcs12ContentType;
                }
            }
            if (this.IsParameterBound(c => c.CertificateCollection))
            {
                ContentType = Constants.Pkcs12ContentType;
            }
            if (this.IsParameterBound(c => c.PolicyPath) && this.IsParameterBound(c => c.PolicyObject))
            {
                throw new AzPSArgumentException($"Parameter {nameof(PolicyPath)} conflicts with Parameter {nameof(PolicyObject)}. Only one of these 2 parameters could be imported at once.", nameof(PolicyPath));
            }
            if (this.IsParameterBound(c => c.PolicyPath))
            {
                if (!File.Exists(PolicyPath))
                {
                    throw new AzPSArgumentException(string.Format(Resources.FileNotFound, this.PolicyPath), nameof(PolicyPath));
                }
                PolicyObject = PSKeyVaultCertificatePolicy.FromJsonFile(PolicyPath);
            }
            if (PolicyObject != null && PolicyObject.SecretContentType != ContentType)
            {
                throw new AzPSArgumentException($"User input {ContentType} conflicts with the ContentType stated as {PolicyObject.SecretContentType} in Certificate Policy.", ContentType);
            }
        }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.ImportCertificate))
            {
                ValidateParameters();

                PSKeyVaultCertificate certBundle = null;

                switch (ParameterSetName)
                {
                    case ImportCertificateFromFileParameterSet:
                        byte[] base64Bytes = File.ReadAllBytes(FilePath);
                        bool doImport = false;

                        if (IsPemFile(FilePath))
                        {
                            doImport = true;
                        }
                        else
                        {

                            X509Certificate2Collection userProvidedCertColl = InitializeCertificateCollection();

                            // look for at least one certificate which contains a private key
                            foreach (var cert in userProvidedCertColl)
                            {
                                doImport |= cert.HasPrivateKey;
                                if (doImport)
                                    break;
                            }
                        }               

                        certBundle = doImport ?
                                this.Track2DataClient.ImportCertificate(
                                    VaultName,
                                    Name,
                                    base64Bytes,
                                    Password,
                                    Tag?.ConvertToDictionary(),
                                    IsPemFile(FilePath) ? Constants.PemContentType : Constants.Pkcs12ContentType,
                                    PolicyObject) :
                                this.Track2DataClient.MergeCertificate(
                                VaultName,
                                Name,
                                new List<byte[]> { base64Bytes },
                                Tag == null ? null : Tag.ConvertToDictionary());

                        break;

                    case ImportWithPrivateKeyFromCollectionParameterSet:
                        certBundle = this.Track2DataClient.ImportCertificate(VaultName, Name, CertificateCollection, null, Tag?.ConvertToDictionary(), certPolicy: PolicyObject);
                        break;

                    case ImportWithPrivateKeyFromStringParameterSet:
                        certBundle = this.Track2DataClient.ImportCertificate(VaultName, Name, CertificateString, Password, Tag?.ConvertToDictionary(), ContentType, certPolicy: PolicyObject);

                        break;
                }

                this.WriteObject(certBundle);
            }
        }

        private bool IsPemFile(string filePath)
        {
            return ".pem".Equals(Path.GetExtension(filePath), StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Initialize certificate collection from FilePath
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>

        internal X509Certificate2Collection InitializeCertificateCollection()
        {
            FileInfo certFile = new FileInfo(ResolveUserPath(this.FilePath));
            if (!certFile.Exists)
            {
                throw new FileNotFoundException(string.Format(KeyVaultProperties.Resources.CertificateFileNotFound, this.FilePath));
            }

            X509Certificate2Collection certificateCollection = new X509Certificate2Collection();
            
            certificateCollection.Import(certFile.FullName, this.Password?.ConvertToString(), X509KeyStorageFlags.Exportable);

            return certificateCollection;
        }
    }
}
