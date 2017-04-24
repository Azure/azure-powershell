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
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public abstract class ServiceFabricClusterCertificateCmdlet : ServiceFabricClusterCmdlet
    {
        protected const string ExistingKeyVault = "ByExistingKeyVault";
        protected const string ByNewPfxAndVaultName = "ByNewPfxAndVaultName";
        protected const string ByExistingPfxAndVaultName = "ByExistingPfxAndVaultName";
        protected const string ByNewPfxAndVaultId = "ByNewPfxAndVaultId";
        protected const string ByExistingPfxAndVaultId = "ByExistingPfxAndVaultId";

        //Used only by NewAzureRmServicefabricCluster
        protected const string ByDefaultArmTemplate = "ByDefaultArmTemplate";

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ExistingKeyVault, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByExistingPfxAndVaultId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByNewPfxAndVaultId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ExistingKeyVault, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByExistingPfxAndVaultId, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByNewPfxAndVaultId, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
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

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                  HelpMessage = "Azure key vault certificate name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                  HelpMessage = "Azure key vault certificate name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultId,
                  HelpMessage = "Azure key vault certificate name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultId,
                  HelpMessage = "Azure key vault certificate name.")]
        [ValidateNotNullOrEmpty]
        [Alias("CertificateName")]
        public virtual string KeyVaultCertificateName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultId,
                   HelpMessage = "Azure key vault resource id")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultId,
                   HelpMessage = "Azure key vault resource id")]
        [ValidateNotNullOrEmpty]
        public virtual string KeyVaultResouceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ExistingKeyVault,
                   HelpMessage = "The existing Azure key vault secret URL")]
        [ValidateNotNullOrEmpty]
        public string SecretIdentifier { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultId,
                   HelpMessage = "The existing Pfx file path")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "The existing Pfx file path")]
        [ValidateNotNullOrEmpty]
        [Alias("Source")]
        public string PfxSourceFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultId,
                   HelpMessage = "The destination path of the new Pfx file to be created")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The destination path of the new Pfx file to be created")]
        [ValidateNotNullOrEmpty]
        [Alias("Destination")]
        public virtual string PfxDestinationFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultId,
                   HelpMessage = "The password of the pfx file")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "The password of the pfx file")]
        [ValidateNotNullOrEmpty]
        [Alias("CertPassword")]
        public virtual SecureString CertificatePassword { get; set; }

        private string certificateSubjectName;
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultId,
            HelpMessage = "The subject name of the certificate to be created")]
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

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ExistingKeyVault,
                  HelpMessage = "The thumbprint for the Azure key vault secret")]
        [ValidateNotNullOrEmpty]
        [Alias("Thumbprint")]
        public string CertificateThumprint { get; set; }

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

        private void CreateSelfSignedCertificate(string subjectName, string keyVaultUrl, out string thumbprint, out CertificateBundle certificateBundle)
        {
            var policy = new CertificatePolicy()
            {
                SecretProperties = new SecretProperties { ContentType = Constants.SecretContentType },
                X509CertificateProperties = new X509CertificateProperties() { Subject = subjectName },
                IssuerParameters = new IssuerParameters() { Name = Constants.SelfSignedIssuerName }
            };

            var operation = this.KeyVaultClient.CreateCertificateAsync(keyVaultUrl, this.KeyVaultCertificateName, policy).Result;
            while (operation != null && operation.Error == null && operation.Status.Equals("inProgress", StringComparison.OrdinalIgnoreCase))
            {
                operation = this.KeyVaultClient.GetCertificateOperationAsync(keyVaultUrl, this.KeyVaultCertificateName).Result;
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));
            }
            if (operation == null || operation.Error != null || !operation.Status.Equals("completed", StringComparison.OrdinalIgnoreCase))
            {
                throw new PSInvalidOperationException("Failed to create certificate");
            }

            certificateBundle = this.KeyVaultClient.GetCertificateAsync(keyVaultUrl, this.KeyVaultCertificateName).Result;
            thumbprint = BitConverter.ToString(certificateBundle.X509Thumbprint).Replace("-", "");

            if (!string.IsNullOrEmpty(PfxDestinationFile))
            {
                var secretBundle = this.KeyVaultClient.GetSecretAsync(keyVaultUrl, this.KeyVaultCertificateName).Result;
                var certOutPutDirectory = Path.GetDirectoryName(this.PfxDestinationFile);
                if (!Directory.Exists(certOutPutDirectory))
                {
                    throw new PSArgumentException(string.Format("Invalid directory {0}", certOutPutDirectory));
                }

                var fileName = Path.GetFileName(this.PfxDestinationFile);
                if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    throw new PSArgumentException(string.Format("File name contains invalid chars {0}", fileName));
                }

                File.WriteAllBytes(this.PfxDestinationFile, Convert.FromBase64String(secretBundle.Value));
            }
        }

        internal CertificateInformation GetOrCreateCertificateInformation()
        {
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
                if (!string.IsNullOrWhiteSpace(this.KeyVaultResouceId))
                {
                    ExtractVaultNameAndGroupNameFromId();
                }

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
                case ByNewPfxAndVaultId:
                case ByDefaultArmTemplate:
                    {
                        string thumbprint = null;
                        Vault vault = null;
                        CertificateBundle certificateBundle = null;
                        GetKeyVaultReady(out vault, out certificateBundle, out thumbprint, null);

                        return new CertificateInformation()
                        {
                            KeyVault = vault,
                            Certificate = certificateBundle.Cer == null ? null : new X509Certificate2(certificateBundle.Cer),
                            SecretUrl = certificateBundle.SecretIdentifier.Identifier,
                            CertificateUrl = certificateBundle.CertificateIdentifier.Identifier,
                            CertificateName = certificateBundle.CertificateIdentifier.Name,
                            Thumbprint = thumbprint,
                            SecretName = certificateBundle.SecretIdentifier.Name,
                            Version = certificateBundle.SecretIdentifier.Version
                        };
                    }

                case ByExistingPfxAndVaultName:
                case ByExistingPfxAndVaultId:
                    {
                        Vault vault = null;
                        CertificateBundle certificateBundle = null;
                        string thumbprint = null;
                        GetKeyVaultReady(out vault, out certificateBundle, out thumbprint, this.PfxSourceFile);

                        return new CertificateInformation()
                        {
                            KeyVault = vault,
                            Certificate = certificateBundle.Cer == null ? null : new X509Certificate2(certificateBundle.Cer),
                            CertificateUrl = certificateBundle.CertificateIdentifier.Identifier,
                            CertificateName = certificateBundle.CertificateIdentifier.Name,
                            SecretUrl = certificateBundle.SecretIdentifier.Identifier,
                            Thumbprint = thumbprint,
                            SecretName = certificateBundle.SecretIdentifier.Name,
                            Version = certificateBundle.SecretIdentifier.Version
                        };
                    }
                case ExistingKeyVault:
                    {
                        var vault = TryGetKeyVault(this.SecretIdentifier);
                        string vaultSecretName;
                        string version;
                        ExtractSecretNameFromSecretIdentifier(this.SecretIdentifier, out vaultSecretName, out version);
                        return new CertificateInformation()
                        {
                            KeyVault = vault,
                            SecretUrl = this.SecretIdentifier,
                            Thumbprint = GetThumbprintFromSecret(this.SecretIdentifier),
                            SecretName = vaultSecretName,
                            Version = version
                        };
                    }
                default:
                    throw new PSArgumentException("Invalid ParameterSetName");
            }
        }

        internal Task AddCertToVmss(VirtualMachineScaleSet vmss, CertificateInformation certInformation)
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

        protected void GetKeyVaultReady(out Vault vault, out CertificateBundle certificateBundle, out string thumbprint, string srcPfxPath = null)
        { 
            vault = TryGetKeyVault(this.KeyVaultResouceGroupName, this.KeyVaultName);

            if (vault == null)
            {
                vault = CreateKeyVault(this.Name, this.KeyVaultName, this.KeyVaultResouceGroupLocation, this.KeyVaultResouceGroupName);
            }

            SetCertificateName();

            if (!string.IsNullOrEmpty(srcPfxPath))
            {
                certificateBundle = ImportCertificateToAzureKeyVault(
                    this.KeyVaultName,
                    this.KeyVaultCertificateName,
                    srcPfxPath,
                    this.CertificatePassword,
                    out thumbprint);
            }
            else
            {
                var vaultUrl = CreateVaultUri(vault.Name);
                CreateSelfSignedCertificate(
                    this.CertificateSubjectName,
                    vaultUrl.ToString(),
                    out thumbprint,
                    out certificateBundle);
            }
        }

        protected void SetCertificateName()
        {
            if (string.IsNullOrWhiteSpace(this.KeyVaultCertificateName))
            {
                this.KeyVaultCertificateName = string.Format("{0}{1}", this.ResourceGroupName, DateTime.Now.ToString("yyyyMMddHHmmss"));
            }
        }

        private string GetThumbprintFromSecret(string secretUrl)
        {
            if (!string.IsNullOrWhiteSpace(this.CertificateThumprint))
            {
                return this.CertificateThumprint;
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

            throw new PSInvalidOperationException(string.Format("Failed to find the thumbprint from {0} , please specify thumbprint explicitly using -CertificateThumprint", secretUrl));
        }

        private void ExtractVaultNameAndGroupNameFromId()
        {
            if (string.IsNullOrWhiteSpace(this.KeyVaultResouceId))
            {
                return;
            }

            var keyVaultId = this.KeyVaultResouceId;
            keyVaultId = keyVaultId.Trim('/');
            var tokens = keyVaultId.Split('/');

            if (tokens.Length != 8)
            {
                throw new PSArgumentException(keyVaultId);
            }

            if (!string.Equals(tokens[0], "subscriptions", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new PSArgumentException("subscriptions");
            }

            if (!string.Equals(tokens[2], "resourcegroups", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new PSArgumentException("resourcegroups");
            }

            if (!string.Equals(tokens[4], "providers", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new PSArgumentException("providers");
            }

            var resourceType = string.Format("{0}/{1}", tokens[5], tokens[6]);
            if (!string.Equals(resourceType, Common.Constants.KeyVaultType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new PSArgumentException("resourceType");
            }

            this.KeyVaultName = tokens[7];
            this.KeyVaultResouceGroupName = tokens[3];
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