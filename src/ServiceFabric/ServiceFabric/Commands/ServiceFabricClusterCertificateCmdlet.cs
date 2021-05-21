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
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Commands.Common.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.WindowsAzure.Commands.Common;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;
using Microsoft.Azure.Commands.Common.KeyVault.Version2016_10_1.Models;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public abstract class ServiceFabricClusterCertificateCmdlet : ServiceFabricClusterCmdlet
    {
        protected const string ByExistingKeyVault = "ByExistingKeyVault";
        protected const string ByNewPfxAndVaultName = "ByNewPfxAndVaultName";
        protected const string ByExistingPfxAndVaultName = "ByExistingPfxAndVaultName";

        //Used only by NewAzureRmServicefabricCluster
        protected const string ByDefaultArmTemplate = "ByDefaultArmTemplate";

        private string keyVaultCertificateName { get; set; }

        private const string BasicConstraintsExtensionName = "Basic Constraints";

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingKeyVault,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxAndVaultName,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingKeyVault,
                   HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public override string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
            HelpMessage = "Azure key vault resource group name, if not given it will be defaulted to resource group name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
            HelpMessage = "Azure key vault resource group name, if not given it will be defaulted to resource group name")]
        [ValidateNotNullOrEmpty]
        [Alias("KeyVaultResouceGroupName")]
        public virtual string KeyVaultResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "Azure key vault name, if not given it will be defaulted to the resource group name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "Azure key vault name, if not given it will be defaulted to the resource group name")]
        [ValidateNotNullOrEmpty]
        public virtual string KeyVaultName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByExistingKeyVault,
                   HelpMessage = "The existing Azure key vault secret URL, for example 'https://mykv.vault.azure.net:443/secrets/mysecrets/55ec7c4dc61a462bbc645ffc9b4b225f'")]
        [ValidateNotNullOrEmpty]
        public string SecretIdentifier { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingKeyVault,
                   HelpMessage = "The thumbprint for the certificate corresponding to the SecretIdentifier. Use this if the certificate is not managed as the key vault would only have the certificate stored as a secret and the cmdlet is unable to retrieve the thumbprint.")]
        [ValidateNotNullOrEmpty]
        public string Thumbprint { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "The path to the existing certificate")]
        [ValidateNotNullOrEmpty]
        [Alias("Source")]
        public virtual string CertificateFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The folder where the new certificate needs to be downloaded.")]
        [ValidateNotNullOrEmpty]
        [Alias("Destination")]
        public virtual string CertificateOutputFolder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "The password of the certificate")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The password of the certificate")]
        [ValidateNotNullOrEmpty]
        [Alias("CertPassword")]
        public virtual SecureString CertificatePassword { get; set; }

        private string certificateSubjectName;
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
            HelpMessage = "The subject name of the certificate")]
        [ValidateNotNullOrEmpty]
        [Alias("Subject")]
        public virtual string CertificateSubjectName
        {
            get { return this.certificateSubjectName; }
            set
            {
                if (!value.StartsWith("cn=", StringComparison.OrdinalIgnoreCase))
                {
                    this.certificateSubjectName = string.Concat("cn=", value);
                }
                else
                {
                    this.certificateSubjectName = value;
                }
            }
        }

        [Parameter(Mandatory = false, ParameterSetName = ByExistingKeyVault,
                HelpMessage = "Certificate common name")]
        [Parameter(Mandatory = false, ParameterSetName = ByExistingPfxAndVaultName,
                HelpMessage = "Certificate common name")]
        [Alias("CertCommonName")]
        public virtual string CertificateCommonName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByExistingKeyVault,
                HelpMessage = "Certificate issuer thumbprint, separated by commas if more than one")]
        [Parameter(Mandatory = false, ParameterSetName = ByExistingPfxAndVaultName,
                HelpMessage = "Certificate issuer thumbprint, separated by commas if more than one")]
        [ValidateNotNullOrEmpty]
        [Alias("CertIssuerThumbprint")]
        public virtual string CertificateIssuerThumbprint { get; set; }

        private Lazy<IResourceManagementClient> resourceManagerClient;

        public IResourceManagementClient ResourceManagerClient
        {
            get { return resourceManagerClient.Value; }
        }

        public virtual string KeyVaultResourceGroupLocation
        {
            get
            {
                return ResourceManagerClient.ResourceGroups.Get(this.ResourceGroupName).Location;
            }
        }

        public ServiceFabricClusterCertificateCmdlet()
        {
            resourceManagerClient = new Lazy<IResourceManagementClient>(() =>
            AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                DefaultContext,
                AzureEnvironment.Endpoint.ResourceManager));
        }

        public override void ExecuteCmdlet()
        {
            this.Validate();
        }

        protected virtual List<string> GetPfxSrcFiles()
        {
            return new List<string>() { this.CertificateFile };
        }

        protected virtual SecureString GetPfxPassword(string pfxFilePath)
        {
            return this.CertificatePassword;
        }

        protected virtual void Validate()
        {
            if (!string.IsNullOrWhiteSpace(this.CertificateOutputFolder))
            {
                if (!Directory.Exists(this.CertificateOutputFolder))
                {
                    throw new PSArgumentException(string.Format(ServiceFabricProperties.Resources.InvalidDirectory, this.CertificateOutputFolder));
                }
            }

            var srcFiles = GetPfxSrcFiles();
            if (srcFiles != null && srcFiles.Any())
            {
                foreach (var srcFile in srcFiles)
                {
                    if (srcFile != null && !File.Exists(srcFile))
                    {
                        throw new PSArgumentException(string.Format(ServiceFabricProperties.Resources.FileNotExist, srcFile));
                    }
                }

            }

            if (this.CertificatePassword != null && this.CertificateFile == null && this.CertificateOutputFolder == null)
            {
                throw new PSArgumentException("CertificateOutputFolder must be given if CertificatePassword is specified");
            }

            if (this.CertificateOutputFolder != null && this.CertificatePassword == null)
            {
                throw new PSArgumentException("CertificatePassword must be given for the Pfx downloaded from Azure KeyVault");
            }
        }

        private void CreateSelfSignedCertificate(string subjectName, string keyVaultUrl, out string thumbprint, out CertificateBundle certificateBundle, out string outputFilePath)
        {
            outputFilePath = string.Empty;
            var policy = new CertificatePolicy()
            {
                SecretProperties = new SecretProperties { ContentType = Constants.SecretContentType },
                X509CertificateProperties = new X509CertificateProperties()
                {
                    Subject = subjectName,
                    Ekus = new List<string> { "1.3.6.1.5.5.7.3.1", "1.3.6.1.5.5.7.3.2" }
                },
                IssuerParameters = new IssuerParameters() { Name = Constants.SelfSignedIssuerName }
            };

            WriteVerboseWithTimestamp(string.Format("Begin to create self signed certificate {0}", this.keyVaultCertificateName));

            CertificateOperation operation;
            try
            {
                operation = this.KeyVaultClient.CreateCertificateAsync(keyVaultUrl, this.keyVaultCertificateName, policy).Result;
            }
            catch (Exception ex)
            {
                WriteErrorWithTimestamp(ex.ToString());
                throw;
            }

            var retry = 120;// 240 * 5 = 20 minutes
            while (retry-- >= 0 && operation != null && operation.Error == null && operation.Status.Equals("inProgress", StringComparison.OrdinalIgnoreCase))
            {
                operation = this.KeyVaultClient.GetCertificateOperationAsync(keyVaultUrl, this.keyVaultCertificateName).Result;
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(WriteVerboseIntervalInSec));
                WriteVerboseWithTimestamp(string.Format("Creating self signed certificate {0} with status {1}", this.keyVaultCertificateName, operation.Status));
            }

            if (retry < 0)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.CreateSelfSignedCertificateTimeout);
            }

            if (operation == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.NoCertificateOperationReturned);
            }

            if (operation.Error != null)
            {
                throw new PSInvalidOperationException(
                    string.Format(ServiceFabricProperties.Resources.CreateSelfSignedCertificateFailedWithErrorDetail,
                    operation.Status,
                    operation.StatusDetails,
                    operation.Error.Code,
                    operation.Error.Message));
            }

            if (!operation.Status.Equals("completed", StringComparison.OrdinalIgnoreCase) && operation.Error == null)
            {
                throw new PSInvalidOperationException(
                 string.Format(ServiceFabricProperties.Resources.CreateSelfSignedCertificateFailedWithoutErrorDetail,
                 operation.Status,
                 operation.StatusDetails));
            }

            certificateBundle = this.KeyVaultClient.GetCertificateAsync(keyVaultUrl, this.keyVaultCertificateName).Result;
            thumbprint = BitConverter.ToString(certificateBundle.X509Thumbprint).Replace("-", "");

            WriteVerboseWithTimestamp(string.Format("Self signed certificate created: {0}", certificateBundle.Id));

            if (!string.IsNullOrEmpty(this.CertificateOutputFolder))
            {
                outputFilePath = GeneratePfxName(this.CertificateOutputFolder);
                var secretBundle = this.KeyVaultClient.GetSecretAsync(keyVaultUrl, this.keyVaultCertificateName).Result;
                var kvSecretBytes = Convert.FromBase64String(secretBundle.Value);
                var certCollection = new X509Certificate2Collection();
                certCollection.Import(kvSecretBytes, null, X509KeyStorageFlags.Exportable);
                var protectedCertificateBytes = certCollection.Export(X509ContentType.Pkcs12, this.CertificatePassword?.ConvertToString());
                File.WriteAllBytes(outputFilePath, protectedCertificateBytes);
            }
        }

        private string GeneratePfxName(string dir)
        {
            var retry = 0;
            var suffx = string.Empty;
            var ret = string.Empty;
            const string fileExt = ".pfx";
            while (File.Exists(ret = Path.Combine(dir, string.Concat(this.keyVaultCertificateName, suffx, fileExt))) && ++retry <= 50)
            {
                suffx = retry.ToString();
            }

            if (retry > 50)
            {
                throw new PSInvalidOperationException("Failed to generate the file, please clean the folder with old file");
            }

            return ret;
        }

        internal List<CertificateInformation> GetOrCreateCertificateInformation()
        {
            var certificateInformations = new List<CertificateInformation>();
            if (string.IsNullOrEmpty(this.KeyVaultResourceGroupName))
            {
                this.KeyVaultResourceGroupName = this.ResourceGroupName;
            }

            if (string.IsNullOrEmpty(this.KeyVaultName))
            {
                this.KeyVaultName = CreateDefaultKeyVaultName(this.ResourceGroupName);
            }

            if (ParameterSetName != ByExistingKeyVault)
            {
                var resourceGroup = SafeGetResource(
                    () => this.ResourceManagerClient.ResourceGroups.Get(
                        this.KeyVaultResourceGroupName),
                        true);

                if (resourceGroup == null)
                {
                    this.ResourceManagerClient.ResourceGroups.CreateOrUpdate(
                        this.KeyVaultResourceGroupName,
                        new ResourceGroup()
                        {
                            Location = this.KeyVaultResourceGroupLocation
                        });
                }
            }

            switch (ParameterSetName)
            {
                case ByNewPfxAndVaultName:
                case ByDefaultArmTemplate:
                    {
                        string thumbprint = null;
                        Vault vault = null;
                        CertificateBundle certificateBundle = null;
                        string pfxOutputPath = null;
                        string commonName = null;
                        GetKeyVaultReady(out vault, out certificateBundle, out thumbprint, out pfxOutputPath, out commonName, null);

                        certificateInformations.Add(new CertificateInformation()
                        {
                            KeyVault = vault,
                            Certificate = certificateBundle.Cer == null ? null : new X509Certificate2(certificateBundle.Cer),
                            SecretUrl = certificateBundle.SecretIdentifier.Identifier,
                            CertificateUrl = certificateBundle.CertificateIdentifier.Identifier,
                            CertificateName = certificateBundle.CertificateIdentifier.Name,
                            CertificateThumbprint = thumbprint,
                            SecretName = certificateBundle.SecretIdentifier.Name,
                            Version = certificateBundle.SecretIdentifier.Version,
                            CertificateOutputPath = pfxOutputPath
                        });

                        return certificateInformations;
                    }

                case ByExistingPfxAndVaultName:
                    {
                        var sourcePfxPath = GetPfxSrcFiles();
                        foreach (var srcPfx in sourcePfxPath)
                        {
                            Vault vault = null;
                            CertificateBundle certificateBundle = null;
                            string thumbprint = null;
                            string pfxOutputPath = null;
                            string commonName = null;
                            GetKeyVaultReady(out vault, out certificateBundle, out thumbprint, out pfxOutputPath, out commonName, srcPfx);

                            certificateInformations.Add(new CertificateInformation()
                            {
                                KeyVault = vault,
                                Certificate =
                                    certificateBundle.Cer == null
                                        ? null
                                        : new X509Certificate2(certificateBundle.Cer),
                                CertificateUrl = certificateBundle.CertificateIdentifier.Identifier,
                                CertificateName = certificateBundle.CertificateIdentifier.Name,
                                SecretUrl = certificateBundle.SecretIdentifier.Identifier,
                                CertificateThumbprint = thumbprint,
                                CertificateCommonName = commonName,
                                SecretName = certificateBundle.SecretIdentifier.Name,
                                Version = certificateBundle.SecretIdentifier.Version
                            });
                        }

                        return certificateInformations;
                    }
                case ByExistingKeyVault:
                    {
                        CertificateInformation certInfor = GetCertificateInforamtionFromSecret(this.SecretIdentifier);
                        certificateInformations.Add(certInfor);

                        return certificateInformations;
                    }
                default:
                    throw new PSArgumentException("Invalid ParameterSetName");
            }
        }

        protected void GetKeyVaultReady(out Vault vault, out CertificateBundle certificateBundle, out string thumbprint, out string pfxOutputPath, out string commonName, string srcPfxPath = null)
        {
            vault = TryGetKeyVault(this.KeyVaultResourceGroupName, this.KeyVaultName);
            pfxOutputPath = null;
            if (vault == null)
            {
                WriteVerboseWithTimestamp(string.Format("Creating Azure Key Vault {0}", this.KeyVaultName));
                vault = CreateKeyVault(this.Name, this.KeyVaultName, this.KeyVaultResourceGroupLocation, this.KeyVaultResourceGroupName);
                WriteVerboseWithTimestamp(string.Format("Key Vault is created: {0}", vault.Id));
            }

            this.keyVaultCertificateName = CreateDefaultCertificateName(this.ResourceGroupName);

            commonName = string.Empty;
            if (!string.IsNullOrEmpty(srcPfxPath))
            {
                certificateBundle = ImportCertificateToAzureKeyVault(
                    this.KeyVaultName,
                    this.keyVaultCertificateName,
                    srcPfxPath,
                    GetPfxPassword(srcPfxPath),
                    out thumbprint,
                    out commonName);
            }
            else
            {
                var vaultUrl = CreateVaultUri(vault.Name);
                CreateSelfSignedCertificate(
                    this.CertificateSubjectName,
                    vaultUrl.ToString(),
                    out thumbprint,
                    out certificateBundle,
                    out pfxOutputPath);
            }
        }

        protected static string CreateDefaultCertificateName(string resourceGroupName)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in resourceGroupName)
            {
                if (IsValidKeyVaultObjectChar(c))
                {
                    sb.Append(c);
                }
            }

            return string.Format("{0}{1}", sb.ToString(), DateTime.Now.ToString("yyyyMMddHHmmss"));
        }

        protected static string CreateDefaultKeyVaultName(string resourceGroupName)
        {
            StringBuilder sb = new StringBuilder();
            var targetCopy = resourceGroupName;
            while (sb.Length < 3)
            {
                foreach (var c in targetCopy)
                {
                    if (IsValidKeyVaultChar(c))
                    {
                        sb.Append(c);
                    }
                }

                // resource group name can't be used for key vault name
                // use random string instread
                if (sb.Length == 0)
                {
                    targetCopy = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                }
            }

            if (sb.Length > 24)
            {
                return sb.ToString().Substring(0, 24);
            }

            return sb.ToString();
        }

        private static bool IsValidKeyVaultChar(char name)
        {
            if (name >= 'a' && name <= 'z') return true;
            if (name >= 'A' && name <= 'Z') return true;
            if (name >= '0' && name <= '9') return true;
            if (name == '-') return true;

            return false;
        }

        private static bool IsValidKeyVaultObjectChar(char name)
        {
            if (name >= 'a' && name <= 'z') return true;
            if (name >= 'A' && name <= 'Z') return true;
            if (name >= '0' && name <= '9') return true;
            if (name == '-') return true;

            return false;
        }

        private CertificateInformation GetCertificateInforamtionFromSecret(string secretIdentifier)
        {
            var vault = TryGetKeyVault(this.SecretIdentifier);

            string certName;
            string certVersion;
            ExtractSecretNameFromSecretIdentifier(this.SecretIdentifier, out certName, out certVersion);
            
            // Test is unable to get the certificate gets unauthorized as the authentication procedure is mocked
            if (RunningTest)
            {
                return new CertificateInformation()
                {
                    KeyVault = vault,
                    SecretUrl = this.SecretIdentifier,
                    CertificateThumbprint = TestThumbprint,
                    CertificateCommonName = TestCommonNameCACert,
                    SecretName = certName,
                    Version = certVersion
                };
            }

            CertificateBundle certBundle = this.KeyVaultClient.GetCertificateAsync(vault.Properties.VaultUri, certName, certVersion).GetAwaiter().GetResult();
            string thumbprint;
            string commonName;
            if (certBundle.Cer == null)
            {
                if (string.IsNullOrWhiteSpace(this.Thumbprint))
                {
                    throw new PSInvalidOperationException(string.Format(
                        ServiceFabricProperties.Resources.CerObjectNotInBundle,
                        vault.Properties.VaultUri,
                        certName,
                        certVersion));
                }
                else
                {
                    thumbprint = this.Thumbprint;
                    commonName = this.CertificateCommonName;
                }
            }
            else
            {
                var certificate = new X509Certificate2(certBundle.Cer);
                thumbprint = certificate.Thumbprint;
                commonName = certificate.GetNameInfo(X509NameType.SimpleName, false);

                if (!string.IsNullOrWhiteSpace(this.Thumbprint) && !string.Equals(this.Thumbprint, thumbprint, StringComparison.OrdinalIgnoreCase))
                {
                    throw new PSArgumentException(string.Format(
                        ServiceFabricProperties.Resources.CertificateThumbprintMismatch,
                        this.Thumbprint,
                        thumbprint,
                        certName,
                        certVersion,
                        vault.Properties.VaultUri));
                }
            }



            WriteVerboseWithTimestamp("Certificate fround for identifier {0} with thumbprint {1} and common name {2}.", secretIdentifier, thumbprint, commonName);

            return new CertificateInformation()
            {
                KeyVault = vault,
                SecretUrl = this.SecretIdentifier,
                CertificateThumbprint = thumbprint,
                CertificateCommonName = commonName,
                SecretName = certName,
                Version = certVersion
            };
        }

        private void ExtractSecretNameFromSecretIdentifier(string secretIdentifier, out string vaultSecretName, out string version)
        {
            vaultSecretName = string.Empty;
            version = string.Empty;

            if (string.IsNullOrWhiteSpace(secretIdentifier))
            {
                return;
            }

            var secretId = secretIdentifier;
            secretId = secretId.Trim('/');
            var separator = new string[] { "/" };
            var tokens = secretId.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length != 5)
            {
                throw new PSArgumentException(secretIdentifier);
            }

            vaultSecretName = tokens[3];
            version = tokens[4];
        }

        private Task AddCertToVmssTask(VirtualMachineScaleSet vmss, CertificateInformation certInformation)
        {
            var secretGroup = vmss.VirtualMachineProfile.OsProfile.Secrets.SingleOrDefault(
                s => s.SourceVault.Id.Equals(certInformation.KeyVault.Id, StringComparison.OrdinalIgnoreCase));


            string configStore = null;
            if (vmss.VirtualMachineProfile.OsProfile.WindowsConfiguration != null)
            {
                configStore = Constants.DefaultCertificateStore;
            }

            if (secretGroup == null)
            {
                vmss.VirtualMachineProfile.OsProfile.Secrets.Add(
                    new VaultSecretGroup()
                    {
                        SourceVault = new Azure.Commands.Common.Compute.Version_2018_04.Models.SubResource()
                        {
                            Id = certInformation.KeyVault.Id
                        },
                        VaultCertificates = new List<VaultCertificate>()
                        {
                          new VaultCertificate()
                          {
                          CertificateStore = configStore,
                          CertificateUrl = certInformation.SecretUrl
                          }
                        }
                    });
            }
            else
            {
                if (secretGroup.VaultCertificates != null)
                {
                    var exsit =
                        secretGroup.VaultCertificates.Any(
                            cert =>
                                cert.CertificateUrl.Equals(certInformation.SecretUrl,
                                    StringComparison.OrdinalIgnoreCase));

                    if (!exsit)
                    {
                        secretGroup.VaultCertificates.Add(
                            new VaultCertificate()
                            {
                                CertificateStore = configStore,
                                CertificateUrl = certInformation.SecretUrl
                            });
                    }
                }
                else
                {
                    secretGroup.VaultCertificates = new List<VaultCertificate>()
                    {
                        new VaultCertificate()
                        {
                            CertificateStore = configStore,
                            CertificateUrl = certInformation.SecretUrl
                        }
                   };
                }
            }

            return ComputeClient.VirtualMachineScaleSets.CreateOrUpdateAsync(
                   this.ResourceGroupName,
                   vmss.Name,
                   vmss);
        }
    }
}
