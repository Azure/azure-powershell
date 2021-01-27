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

using Azure.Identity;
using Azure.Security.KeyVault.Certificates;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models;
using Microsoft.Azure.Commands.Common.KeyVault.Version2016_10_1.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

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

        private void CreateSelfSignedCertificate(string subjectName, string keyVaultUrl, out string thumbprint, out KeyVaultCertificateWithPolicy certificatePolicy, out string outputFilePath)
        {
            outputFilePath = string.Empty;
            var policy = new CertificatePolicy(Constants.SelfSignedIssuerName, subjectName)
            {
                ContentType = new CertificateContentType(Constants.SecretContentType),
            };
            policy.EnhancedKeyUsage.Add("1.3.6.1.5.5.7.3.1");
            policy.EnhancedKeyUsage.Add("1.3.6.1.5.5.7.3.2");

            WriteVerboseWithTimestamp(string.Format("Begin to create self signed certificate {0}", this.keyVaultCertificateName));
             
            CertificateOperation operation;
            try
            {
                operation = this.CertificateClient.Value.StartCreateCertificateAsync(this.keyVaultCertificateName, policy).Result;
            }
            catch (Exception ex)
            {
                WriteErrorWithTimestamp(ex.ToString());
                throw;
            }

            var retry = 120;// 240 * 5 = 20 minutes
            while (retry-- >= 0 && operation != null && operation.Properties.Error == null && operation.Properties.Status.Equals("inProgress", StringComparison.OrdinalIgnoreCase))
            {
                operation = this.CertificateClient.Value.GetCertificateOperationAsync(this.keyVaultCertificateName).Result;
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(WriteVerboseIntervalInSec));
                WriteVerboseWithTimestamp(string.Format("Creating self signed certificate {0} with status {1}", this.keyVaultCertificateName, operation.Properties.Status));
            }

            if (retry < 0)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.CreateSelfSignedCertificateTimeout);
            }

            if (operation == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.NoCertificateOperationReturned);
            }

            if (operation.Properties.Error != null)
            {
                throw new PSInvalidOperationException(
                    string.Format(ServiceFabricProperties.Resources.CreateSelfSignedCertificateFailedWithErrorDetail,
                    operation.Properties.Status,
                    operation.Properties.StatusDetails,
                    operation.Properties.Error.Code,
                    operation.Properties.Error.Message));
            }

            if (!operation.Properties.Status.Equals("completed", StringComparison.OrdinalIgnoreCase) && operation.Properties.Error == null)
            {
                throw new PSInvalidOperationException(
                 string.Format(ServiceFabricProperties.Resources.CreateSelfSignedCertificateFailedWithoutErrorDetail,
                 operation.Properties.Status,
                 operation.Properties.StatusDetails));
            }
             
            KeyVaultCertificateWithPolicy certificateWithPolicy = this.CertificateClient.Value.GetCertificateAsync(this.keyVaultCertificateName).GetAwaiter().GetResult();
            certificatePolicy = certificateWithPolicy;

            thumbprint = BitConverter.ToString(certificatePolicy.Properties.X509Thumbprint).Replace("-", "");

            WriteVerboseWithTimestamp(string.Format("Self signed certificate created: {0}", certificatePolicy.Id));

           if (!string.IsNullOrEmpty(this.CertificateOutputFolder))
            {
                outputFilePath = GeneratePfxName(this.CertificateOutputFolder);
                var secretBundle = this.SecretClient.Value.GetSecretAsync(this.keyVaultCertificateName).GetAwaiter().GetResult().Value;
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
                        KeyVaultCertificateWithPolicy certificatePolicy = null;
                        
                        string pfxOutputPath = null;
                        string commonName = null;
                        GetKeyVaultReady(out vault, out certificatePolicy, out thumbprint, out pfxOutputPath, out commonName, null);

                        certificateInformations.Add(new CertificateInformation()
                        {
                            KeyVault = vault,
                            Certificate = certificatePolicy.Cer == null ? null : new X509Certificate2(certificatePolicy.Cer),
                            SecretUrl = certificatePolicy.SecretId.ToString(),
                            CertificateUrl = certificatePolicy.Id.ToString(),
                            CertificateName = certificatePolicy.Name,
                            CertificateThumbprint = thumbprint,
                            SecretName = certificatePolicy.Name,
                            Version = certificatePolicy.Properties.Version,
                            CertificateOutputPath = pfxOutputPath
                        }); ;

                        return certificateInformations;
                    }

                case ByExistingPfxAndVaultName:
                    {
                        var sourcePfxPath = GetPfxSrcFiles();
                        foreach (var srcPfx in sourcePfxPath)
                        {
                            Vault vault = null;
                            KeyVaultCertificateWithPolicy certificatePolicy = null;
                            
                            string thumbprint = null;
                            string pfxOutputPath = null;
                            string commonName = null;
                            GetKeyVaultReady(out vault, out certificatePolicy, out thumbprint, out pfxOutputPath, out commonName, srcPfx);

                            certificateInformations.Add(new CertificateInformation()
                            {
                                KeyVault = vault,
                                Certificate =
                                    certificatePolicy.Cer == null
                                        ? null
                                        : new X509Certificate2(certificatePolicy.Cer),
                                CertificateUrl = certificatePolicy.Properties.VaultUri.ToString(),
                                CertificateName = certificatePolicy.Name,
                                SecretUrl = certificatePolicy.SecretId.ToString(),
                                CertificateThumbprint = thumbprint,
                                CertificateCommonName = commonName,
                                SecretName = certificatePolicy.Name,
                                Version = certificatePolicy.Properties.Version
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

        internal List<Task> CreateAddOrRemoveCertVMSSTasks(CertificateInformation certInformation, string clusterId, bool isClusterCert = true, bool addCert = true)
        {
            var allTasks = new List<Task>();
            var vmssPages = this.ComputeClient.VirtualMachineScaleSets.List(this.ResourceGroupName);

            if (vmssPages == null || !vmssPages.Any())
            {
                throw new PSArgumentException(string.Format(
                    ServiceFabricProperties.Resources.NoVMSSFoundInRG,
                    this.ResourceGroupName));
            }

            do
            {
                if (!vmssPages.Any())
                {
                    break;
                }

                foreach (var vmss in vmssPages)
                {
                    VirtualMachineScaleSetExtension sfExt;
                    if (TryGetFabricVmExt(vmss.VirtualMachineProfile.ExtensionProfile?.Extensions, out sfExt))
                    {
                        if (!string.Equals(GetClusterIdFromExtension(sfExt), clusterId, StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        WriteVerboseWithTimestamp(string.Format("Found VMSS: {0}, id: {1} for cluster {2}", vmss.Name, vmss.Id, clusterId));

                        var extConfig = (JObject)sfExt.Settings;

                        if (addCert)
                        {
                            if (isClusterCert)
                            {
                                if (this.CertificateCommonName != null)
                                {
                                    JArray newCommonNames = (JArray)extConfig.SelectToken("certificate.commonNames");
                                    newCommonNames.Add(this.CertificateCommonName);

                                    extConfig["certificate"]["commonNames"] = newCommonNames;
                                }
                                else
                                {
                                    var input = string.Format(
                                        @"{{""thumbprint"":""{0}"",""x509StoreName"":""{1}""}}",
                                        certInformation.CertificateThumbprint,
                                        Constants.DefaultCertificateStore);

                                    extConfig["certificateSecondary"] = JObject.Parse(input);
                                }

                                vmss.VirtualMachineProfile.ExtensionProfile.Extensions.Single(
                                    extension =>
                                    extension.Name.Equals(sfExt.Name, StringComparison.OrdinalIgnoreCase)).Settings = extConfig;
                            }

                            allTasks.Add(AddCertToVmssTask(vmss, certInformation));
                        }
                        else
                        {
                            if (isClusterCert)
                            {
                                if (this.CertificateCommonName != null)
                                {
                                    JArray commonNames = (JArray)extConfig.SelectToken("certificate.commonNames");
                                    var commonNameToRemove = commonNames.FirstOrDefault(commonName => (string)commonName == this.CertificateCommonName);
                                    if (commonNameToRemove != null)
                                    {
                                        commonNames.Remove(commonNameToRemove);
                                    }
                                }
                                else
                                {
                                    string secondaryThumbprint = (string)extConfig["certificateSecondary"]["thumbprint"];
                                    if (certInformation.CertificateThumbprint.Equals(secondaryThumbprint, StringComparison.OrdinalIgnoreCase))
                                    {
                                        extConfig.Remove("certificateSecondary");
                                    }
                                }

                                vmss.VirtualMachineProfile.ExtensionProfile.Extensions.Single(
                                    extension =>
                                    extension.Name.Equals(sfExt.Name, StringComparison.OrdinalIgnoreCase)).Settings = extConfig;
                            }

                            allTasks.Add(RemoveCertFromVmssTask(vmss, certInformation));
                        }
                    }
                }


            } while (!string.IsNullOrEmpty(vmssPages.NextPageLink) &&
                     (vmssPages = this.ComputeClient.VirtualMachineScaleSets.ListNext(vmssPages.NextPageLink)) != null);

            if (allTasks.Count() == 0)
            {
                throw new ItemNotFoundException(string.Format(ServiceFabricProperties.Resources.NoVmssFoundForCluster, this.ResourceGroupName, clusterId));
            }

            return allTasks;
        }

        protected void GetKeyVaultReady(out Vault vault, out KeyVaultCertificateWithPolicy certificatePolicy, out string thumbprint, out string pfxOutputPath, out string commonName, string srcPfxPath = null)
        {
            vault = TryGetKeyVault(this.KeyVaultResourceGroupName, this.KeyVaultName);
            pfxOutputPath = null;
            if (vault == null)
            {
                WriteVerboseWithTimestamp(string.Format("Creating Azure Key Vault {0}", this.KeyVaultName));
                vault = CreateKeyVault(this.Name, this.KeyVaultName, this.KeyVaultResourceGroupLocation, this.KeyVaultResourceGroupName);
                WriteVerboseWithTimestamp(string.Format("Key Vault is created: {0}", vault.Id));
            }

            //Create certificate client and secret client
            var keyVaultUri = vault.Properties.VaultUri;
            CertificateClient = new Lazy<CertificateClient>(() => new CertificateClient(new Uri(keyVaultUri), new DefaultAzureCredential()));
            SecretClient = new Lazy<SecretClient>(() => new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential()));
            this.keyVaultCertificateName = CreateDefaultCertificateName(this.ResourceGroupName);

            commonName = string.Empty;
            if (!string.IsNullOrEmpty(srcPfxPath))
            {
                certificatePolicy = ImportCertificateToAzureKeyVault(
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
                    out certificatePolicy,
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

            //Create certificate client and secret client
            CertificateClient = new Lazy<CertificateClient>(() => new CertificateClient(new Uri(vault.Properties.VaultUri), new DefaultAzureCredential()));
            SecretClient = new Lazy<SecretClient>(() => new SecretClient(new Uri(vault.Properties.VaultUri), new DefaultAzureCredential()));

            KeyVaultCertificateWithPolicy certificatePolicy = this.CertificateClient.Value.GetCertificateAsync(certName).GetAwaiter().GetResult();
            
            string thumbprint;
            string commonName;
            if (certificatePolicy.Cer == null)
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
                var certificate = new X509Certificate2(certificatePolicy.Cer);  
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

        private Task RemoveCertFromVmssTask(VirtualMachineScaleSet vmss, CertificateInformation certInformation)
        {
            var secretGroup = vmss.VirtualMachineProfile.OsProfile.Secrets.SingleOrDefault(
                s => s.SourceVault.Id.Equals(certInformation.KeyVault.Id, StringComparison.OrdinalIgnoreCase));

            bool removeNeeded = false;
            if (secretGroup != null)
            {
                if (secretGroup.VaultCertificates != null)
                {
                    if (secretGroup.VaultCertificates.Count() == 1 && secretGroup.VaultCertificates.First().CertificateUrl.Equals(certInformation.SecretUrl))
                    {
                        vmss.VirtualMachineProfile.OsProfile.Secrets.Remove(secretGroup);
                        removeNeeded = true;
                    }
                    else
                    {
                        var certAdded = secretGroup.VaultCertificates.Single(cert => cert.CertificateUrl.Equals(certInformation.SecretUrl));
                        if (certAdded != null)
                        {
                            secretGroup.VaultCertificates.Remove(certAdded);
                            removeNeeded = true;
                        }
                    }
                }
            }

            if (removeNeeded)
            {
                return ComputeClient.VirtualMachineScaleSets.CreateOrUpdateAsync(
                       this.ResourceGroupName,
                       vmss.Name,
                       vmss);
            }
            else
            {
                return null;
            }
        }
    }
}
