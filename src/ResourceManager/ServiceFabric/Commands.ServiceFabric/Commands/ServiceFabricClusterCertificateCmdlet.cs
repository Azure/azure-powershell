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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.KeyVault;
using Newtonsoft.Json;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Common;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public abstract class ServiceFabricClusterCertificateCmdlet : ServiceFabricClusterCmdlet
    {
        protected const string ExistingKeyVault = "ByExistingKeyVault";
        protected const string ByNewPfxAndVaultName = "ByNewPfxAndVaultName";
        protected const string ByExistingPfxAndVaultName = "ByExistingPfxAndVaultName";

        //Used only by NewAzureRmServicefabricCluster
        protected const string ByDefaultArmTemplate = "ByDefaultArmTemplate";

        private string keyVaultCertificateName { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ExistingKeyVault, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ExistingKeyVault, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public override string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
            HelpMessage = "Azure key vault resource group name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
            HelpMessage = "Azure key vault resource group name")]
        [ValidateNotNullOrEmpty]
        public virtual string KeyVaultResouceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "Azure key vault name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "Azure key vault name")]
        [ValidateNotNullOrEmpty]
        public virtual string KeyVaultName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ExistingKeyVault,
                   HelpMessage = "The existing Azure key vault secret URL")]
        [ValidateNotNullOrEmpty]
        public string SecretIdentifier { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "The existing Pfx file path")]
        [ValidateNotNullOrEmpty]
        [Alias("Source")]
        public virtual string PfxSourceFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The folder path of the new Pfx file to be created")]
        [ValidateNotNullOrEmpty]
        [Alias("Destination")]
        public virtual string PfxOutputFolder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "The password of the pfx file")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The password of the pfx file")]
        [ValidateNotNullOrEmpty]
        [Alias("CertPassword")]
        public virtual SecureString CertificatePassword { get; set; }

        private string certificateSubjectName;
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
            HelpMessage = "The subject name of the certificate to be created")]
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
            }
        }

        public Lazy<IResourceManagementClient> resourceManagerClient;

        public IResourceManagementClient ResourceManagerClient
        {
            get { return resourceManagerClient.Value; }
        }

        public virtual string KeyVaultResouceGroupLocation
        {
            get
            {
                return ResourceManagerClient.ResourceGroups.Get(this.ResourceGroupName).Location;
            }
        }

        public ServiceFabricClusterCertificateCmdlet()
        {
            resourceManagerClient = new Lazy<IResourceManagementClient>(() =>
            AzureSession.ClientFactory.CreateArmClient<ResourceManagementClient>(
                DefaultProfile.Context,
                AzureEnvironment.Endpoint.ResourceManager));
        }

        public override void ExecuteCmdlet()
        {
            this.Validate();

        }

        protected virtual List<string> GetPfxSrcFiles()
        {
            return new List<string>() {this.PfxSourceFile};
        }

        protected virtual SecureString GetPfxPassword(string pfxFilePath)
        {
            return this.CertificatePassword;
        }                                   

        protected virtual void Validate()
        {
            if (!string.IsNullOrWhiteSpace(this.PfxOutputFolder))
            {
                if (!Directory.Exists(this.PfxOutputFolder))
                {
                    throw new PSArgumentException(string.Format(ServiceFabricProperties.Resources.InvalidDirectory, this.PfxOutputFolder));
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

            if (this.CertificatePassword != null && this.PfxSourceFile == null && this.PfxOutputFolder == null)
            {
                throw new PSArgumentException("PfxOutputFolder must be given if CertificatePassword is specified");
            }

            if (this.PfxOutputFolder != null && this.CertificatePassword == null)
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
                X509CertificateProperties = new X509CertificateProperties() { Subject = subjectName },
                IssuerParameters = new IssuerParameters() { Name = Constants.SelfSignedIssuerName }
            };

            WriteVerboseWithTimestamp(string.Format("Begin to create self signed certificate {0}", this.keyVaultCertificateName));
           
            var operation = this.KeyVaultClient.CreateCertificateAsync(keyVaultUrl, this.keyVaultCertificateName, policy).Result;

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

            WriteVerboseWithTimestamp(string.Format("Self signed certificate created: {0}", certificateBundle.CertificateIdentifier));

            if (!string.IsNullOrEmpty(this.PfxOutputFolder))
            {
                outputFilePath = GeneratePfxName(this.PfxOutputFolder);
                var secretBundle = this.KeyVaultClient.GetSecretAsync(keyVaultUrl, this.keyVaultCertificateName).Result;
                var kvSecretBytes = Convert.FromBase64String(secretBundle.Value);
                var certCollection = new X509Certificate2Collection();
                certCollection.Import(kvSecretBytes,null,X509KeyStorageFlags.Exportable);
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
            if (string.IsNullOrEmpty(this.KeyVaultResouceGroupName))
            {
                this.KeyVaultResouceGroupName = this.ResourceGroupName;
            }

            if (string.IsNullOrEmpty(this.KeyVaultName))
            {
                this.KeyVaultName = this.ResourceGroupName;
            }

            if (ParameterSetName != ExistingKeyVault)
            {
                var resourceGroup = SafeGetResource(
                    () => this.ResourceManagerClient.ResourceGroups.Get(
                        this.KeyVaultResouceGroupName));

                if (resourceGroup == null)
                {
                    this.ResourceManagerClient.ResourceGroups.CreateOrUpdate(
                        this.KeyVaultResouceGroupName,
                        new ResourceGroup()
                        {
                            Location = this.KeyVaultResouceGroupLocation
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
                        GetKeyVaultReady(out vault, out certificateBundle, out thumbprint, out pfxOutputPath, null);

                        certificateInformations.Add(new CertificateInformation()
                        {
                            KeyVault = vault,
                            Certificate = certificateBundle.Cer == null ? null : new X509Certificate2(certificateBundle.Cer),
                            SecretUrl = certificateBundle.SecretIdentifier.Identifier,
                            CertificateUrl = certificateBundle.CertificateIdentifier.Identifier,
                            CertificateName = certificateBundle.CertificateIdentifier.Name,
                            Thumbprint = thumbprint,
                            SecretName = certificateBundle.SecretIdentifier.Name,
                            Version = certificateBundle.SecretIdentifier.Version,
                            PfxFileOutputPath = pfxOutputPath
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
                            GetKeyVaultReady(out vault, out certificateBundle, out thumbprint, out pfxOutputPath, srcPfx);

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
                                Thumbprint = thumbprint,
                                SecretName = certificateBundle.SecretIdentifier.Name,
                                Version = certificateBundle.SecretIdentifier.Version
                        });
                        }

                        return certificateInformations;
                    }
                case ExistingKeyVault:
                    {
                        var vault = TryGetKeyVault(this.SecretIdentifier);

                        string vaultSecretName;
                        string version;
                        ExtractSecretNameFromSecretIdentifier(this.SecretIdentifier, out vaultSecretName, out version);
                        certificateInformations.Add(new CertificateInformation()
                        {
                            KeyVault = vault,
                            SecretUrl = this.SecretIdentifier,
                            Thumbprint = GetThumbprintFromSecret(this.SecretIdentifier),
                            SecretName = vaultSecretName,
                            Version = version
                        });

                        return certificateInformations;
                    }
                default:
                    throw new PSArgumentException("Invalid ParameterSetName");
            }
        }

        internal Task AddCertToVmssTask(VirtualMachineScaleSet vmss, CertificateInformation certInformation)
        {
            var secretGroup = vmss.VirtualMachineProfile.OsProfile.Secrets.SingleOrDefault(
                s => s.SourceVault.Id.Equals(certInformation.KeyVault.Id, StringComparison.OrdinalIgnoreCase));
            if (secretGroup == null)
            {
                vmss.VirtualMachineProfile.OsProfile.Secrets.Add(
                    new VaultSecretGroup()
                    {
                        SourceVault = new Management.Compute.Models.SubResource()
                        {
                            Id = certInformation.KeyVault.Id
                        },
                        VaultCertificates = new List<VaultCertificate>()
                        {
                          new VaultCertificate()
                          {
                          CertificateStore = Constants.DefaultCertificateStore,
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
                                CertificateStore = Constants.DefaultCertificateStore,
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
                            CertificateStore = Constants.DefaultCertificateStore,
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

        protected void GetKeyVaultReady(out Vault vault, out CertificateBundle certificateBundle, out string thumbprint, out string pfxOutputPath, string srcPfxPath = null)
        { 
            vault = TryGetKeyVault(this.KeyVaultResouceGroupName, this.KeyVaultName);
            pfxOutputPath = null;
            if (vault == null)
            {
                WriteVerboseWithTimestamp(string.Format("Creating Azure Key Vault {0}", this.KeyVaultName));
                vault = CreateKeyVault(this.Name, this.KeyVaultName, this.KeyVaultResouceGroupLocation, this.KeyVaultResouceGroupName);
                WriteVerboseWithTimestamp(string.Format("Key Vault is created: {0}", vault.Id));
            }

            SetCertificateName();

            if (!string.IsNullOrEmpty(srcPfxPath))
            {
                certificateBundle = ImportCertificateToAzureKeyVault(
                    this.KeyVaultName,
                    this.keyVaultCertificateName,
                    srcPfxPath,
                    GetPfxPassword(srcPfxPath),
                    out thumbprint);
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

        protected void SetCertificateName()
        {
            this.keyVaultCertificateName = string.Format("{0}{1}", this.ResourceGroupName,
                DateTime.Now.ToString("yyyyMMddHHmmss"));
        }

        private string GetThumbprintFromSecret(string secretUrl)
        {
            if (RunningTest)
            {
                if (!string.IsNullOrWhiteSpace(TestThumbprint))
                {
                    return TestThumbprint;
                }  
            }

            if (string.IsNullOrWhiteSpace(secretUrl))
            {
                throw new PSArgumentException("secretUrl");
            }

            var secretBundle = this.KeyVaultClient.GetSecretAsync(secretUrl).Result;
            var secretValue = secretBundle.Value;
            try
            {
                if (secretValue != null)
                {
                    var secretBytes = Convert.FromBase64String(secretValue);
                    try
                    {
                        var certCollection = new X509Certificate2Collection();
                        certCollection.Import(secretBytes, null, X509KeyStorageFlags.Exportable);
                        return certCollection[0].Thumbprint;
                    }
                    catch (CryptographicException)
                    {
                        var content = Encoding.UTF8.GetString(secretBytes);
                        var jsonBlob = JsonConvert.DeserializeObject<JsonBlob>(content);
                        var certCollection = new X509Certificate2Collection();
                        if (jsonBlob.DataType.Equals("pfx", StringComparison.CurrentCultureIgnoreCase))
                        {
                            certCollection.Import(
                                Convert.FromBase64String(jsonBlob.Data),
                                jsonBlob.Password,
                                X509KeyStorageFlags.Exportable);

                            return certCollection[0].Thumbprint;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                WriteError(new ErrorRecord(
                    e,
                    string.Empty,
                    ErrorCategory.NotSpecified,
                    null));

                throw;
            }

            throw new PSInvalidOperationException(string.Format("Failed to find the thumbprint from {0}", secretUrl));
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
    }
}