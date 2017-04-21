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
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.KeyVault;
using Newtonsoft.Json;
using Microsoft.Azure.Commands.ServiceFabric.Common;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public abstract class ServiceFabricClusterCertificateCmdlet : ServiceFabricClusterCmdlet
    {
        protected const string ExistingKeyVaultSet = "ByExistingKeyVault";
        protected const string ByNewPfxAndVaultName = "ByNewPfxAndVaultName";
        protected const string ByExistingPfxAndVaultName = "ByExistingPfxAndVaultName";
        protected const string ByNewPfxAndVaultId = "ByNewPfxAndVaultId";
        protected const string ByExistingPfxSetAndVaultId = "ByExistingPfxSetAndVaultId";

        //Used only by NewAzureRmServicefabricCluster
        protected const string ByDefaultArmTemplate = "ByDefaultArmTemplate";

        private string secretName;

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ExistingKeyVaultSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByExistingPfxSetAndVaultId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ExistingKeyVaultSet, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByExistingPfxSetAndVaultId, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "Azure key vault name")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "Azure key vault name")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "Azure key vault resource group name")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "Azure key vault resource group name")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultResouceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultId,
                   HelpMessage = "Azure key vault resource id")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxSetAndVaultId,
                   HelpMessage = "Azure key vault resource id")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultResouceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExistingKeyVaultSet,
                   HelpMessage = "The existing Azure key vault secret URL")]
        [ValidateNotNullOrEmpty]
        public string SecretIdentifier { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxSetAndVaultId,
                   HelpMessage = "The existing Pfx file path")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "The existing Pfx file path")]
        [ValidateNotNullOrEmpty]
        [Alias("Source")]
        public string PfxSourceFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultId,
                   HelpMessage = "The destination path of the new Pfx file to be created")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The destination path of the new Pfx file to be created")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByDefaultArmTemplate,
                   HelpMessage = "The destination path of the new Pfx file to be created")]
        [ValidateNotNullOrEmpty]
        [Alias("Destination")]
        public string PfxDestinationFile { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxSetAndVaultId,
                   HelpMessage = "The password of the pfx file")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "The password of the pfx file")]
        [ValidateNotNullOrEmpty]
        [Alias("Password")]
        public virtual SecureString CertificatePassword { get; set; }

        private string certificateSubjectName;
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultId,
            HelpMessage = "The Dns name of the certificate to be created")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
            HelpMessage = "The Dns name of the certificate to be created")]
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

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ExistingKeyVaultSet,
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

        private void CreateSelfSignedCertificate(string subjectName, string keyVaultUrl, out string thumbprint, out SecretBundle secretBundle)
        {
            string certificateName = this.ClusterName;

            var policy = new CertificatePolicy()
            {
                SecretProperties = new SecretProperties { ContentType = Constants.SecretContentType },
                X509CertificateProperties = new X509CertificateProperties() { Subject = subjectName },
                IssuerParameters = new IssuerParameters() { Name = Constants.SelfSignedIssuerName }
            };

            var operation = this.KeyVaultClient.CreateCertificateAsync(keyVaultUrl, certificateName, policy).Result;
            while (operation != null && operation.Error == null && operation.Status.Equals("inProgress", StringComparison.OrdinalIgnoreCase))
            {
                operation = this.KeyVaultClient.GetCertificateOperationAsync(keyVaultUrl, certificateName).Result;
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));
            }
            if (operation == null || operation.Error != null || !operation.Status.Equals("completed", StringComparison.OrdinalIgnoreCase))
            {
                throw new PSInvalidOperationException("Failed to create certificate");
            }

            var certificateBundle = this.KeyVaultClient.GetCertificateAsync(keyVaultUrl, certificateName).Result;
            thumbprint = BitConverter.ToString(certificateBundle.X509Thumbprint).Replace("-", "");
            secretBundle = this.KeyVaultClient.GetSecretAsync(keyVaultUrl, certificateName).Result;

            if (!string.IsNullOrEmpty(PfxDestinationFile))
            {
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

                File.WriteAllText(fileName, secretBundle.Value);
            }
        }

        internal CertificateInformation GetOrCreateCertificateInformation()
        {
            if (ParameterSetName == ByNewPfxAndVaultName)
            {
                if (string.IsNullOrEmpty(this.KeyVaultResouceGroupName))
                {
                    this.KeyVaultResouceGroupName = this.ResourceGroupName;
                }

                if (string.IsNullOrEmpty(this.KeyVaultName))
                {
                    this.KeyVaultName = this.ResourceGroupName;
                }
            }

            if (ParameterSetName != ExistingKeyVaultSet)
            {
                if (!string.IsNullOrWhiteSpace(this.KeyVaultResouceId))
                {
                    ExtractVaultNameAndGroupNameFromId();
                }

                // only for NewAzureRmServiceFabricCluster cmdlet
                if (ParameterSetName.CompareTo(ByDefaultArmTemplate) == 0)
                {
                    this.KeyVaultName = this.ResourceGroupName;
                    // The resource group should be created before this
                    this.KeyVaultResouceGroupName = this.ResourceGroupName;
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
                        SecretBundle secretBundle = null;
                        GetKeyVaultReady(out vault, out secretBundle, out thumbprint, null);

                        return new CertificateInformation()
                        {
                            KeyVault = vault,
                            SecretUrl = secretBundle.SecretIdentifier.Identifier,
                            Thumbprint = thumbprint
                        };
                    }

                case ByExistingPfxAndVaultName:
                case ByExistingPfxSetAndVaultId:
                    {
                        Vault vault = null;
                        SecretBundle secretBundle = null;
                        string thumbprint = null;
                        GetKeyVaultReady(out vault, out secretBundle, out thumbprint, this.PfxSourceFile);

                        return new CertificateInformation()
                        {
                            KeyVault = vault,
                            SecretUrl = secretBundle.SecretIdentifier.Identifier,
                            Thumbprint = thumbprint
                        };
                    }
                case ExistingKeyVaultSet:
                    {
                        var vault = GetKeyVault(this.SecretIdentifier);

                        return new CertificateInformation()
                        {
                            KeyVault = vault,
                            SecretUrl = this.SecretIdentifier,
                            Thumbprint = GetThumbprintFromSecret(this.SecretIdentifier)
                        };
                    }
            }

            return null;
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

        protected void GetKeyVaultReady(
            out Vault vault,
            out SecretBundle secretBundle,
            out string thumbprint,
            string srcPfxPath)
        {

            if (string.IsNullOrEmpty(this.secretName))
            {
                this.secretName = string.IsNullOrEmpty(this.PfxDestinationFile) ?
                    Path.GetFileNameWithoutExtension(this.PfxSourceFile) :
                    Path.GetFileNameWithoutExtension(this.PfxDestinationFile);
                if (string.IsNullOrWhiteSpace(this.secretName))
                {
                    this.secretName = this.ClusterName;
                }

                if (this.secretName.Contains("."))
                {
                    this.secretName = this.secretName.Replace(".", "");
                }
            }

            vault = GetKeyVault(this.KeyVaultResouceGroupName, this.KeyVaultName);

            if (vault == null)
            {
                vault = CreateKeyVault(
                    this.KeyVaultName,
                    this.KeyVaultResouceGroupLocation,
                    this.KeyVaultResouceGroupName);
            }

            if (!string.IsNullOrEmpty(srcPfxPath))
            {
                secretBundle = SetAzureKeyVaultSecret(
                    this.KeyVaultName,
                    this.secretName,
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
                    out secretBundle);
            }
        }
    }
}