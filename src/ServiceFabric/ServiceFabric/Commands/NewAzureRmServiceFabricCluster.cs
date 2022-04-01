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
using System.Reflection;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.WindowsAzure.Commands.Common;
using Newtonsoft.Json;
using OperatingSystem = Microsoft.Azure.Commands.ServiceFabric.Models.OperatingSystem;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Resources;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceFabricCluster", SupportsShouldProcess = true, DefaultParameterSetName = ByDefaultArmTemplate),OutputType(typeof(PSDeploymentResult))]
    public class NewAzureRmServiceFabricCluster : ServiceFabricClusterCertificateCmdlet
    {
        public readonly Dictionary<OperatingSystem, string> OsToVmSkuString = new Dictionary<OperatingSystem, string>()
        {
            {OperatingSystem.WindowsServer2012R2Datacenter, "2012-R2-Datacenter"},
            {OperatingSystem.UbuntuServer1604, "16.04-LTS"},
            {OperatingSystem.UbuntuServer1804, "18.04-LTS"},
            {OperatingSystem.UbuntuServer2004, "20_04-LTS"},
            {OperatingSystem.WindowsServer2016DatacenterwithContainers, "2016-Datacenter-with-Containers"},
            {OperatingSystem.WindowsServer2016Datacenter, "2016-Datacenter"}
        };

        private string resourceLocation;
        public override string KeyVaultResourceGroupLocation
        {
            get
            {
                return this.resourceLocation;
            }
        }

        public const string ErrorFormat = "Error: Code={0}; Message={1}\r\n";
        public const string DefaultPublicDnsFormat = "{0}.{1}.cloudapp.azure.com";

        private readonly string DefaultDurability = DurabilityLevel.Bronze.ToString();

        private string adminUserName = string.Empty; 
        private string reliabilityLevel = ReliabilityLevel.Bronze.ToString();
        private string domainNameLabel = string.Empty;

        private string reliabilityLevelParameter = string.Empty;
        private string durabilityLevelParameter = string.Empty;
        private string clusterNameParameter = string.Empty;
        private string vmInstanceParameter = string.Empty;
        private string adminPasswordParameter = string.Empty;
        private string adminUserParameter = string.Empty;
        private string locationParameter = string.Empty;
        private string skuParameter = string.Empty;
        private string vmImageSkuParameter = string.Empty;

        private string thumbprintParameter = string.Empty;
        private string keyVaultParameter = string.Empty;
        private string certificateUrlParameter = string.Empty;

        private string domainNameLabelParameter = string.Empty;

        /// <summary>
        /// Resource group name
        /// </summary>
        /// 
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingKeyVault,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxAndVaultName,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByDefaultArmTemplate,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "The path to the template file.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The path to the template file.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByExistingKeyVault,
                   HelpMessage = "The path to the template file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateFile { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByExistingKeyVault,
                   HelpMessage = "The path to the template parameter file.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The path to the template parameter file.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "The path to the template parameter file.")]
        [ValidateNotNullOrEmpty]
        public string ParameterFile { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                HelpMessage = "The existing certificate file path for the primary cluster certificate")]
        [ValidateNotNullOrEmpty]
        [Alias("Source")]
        public override string CertificateFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
           HelpMessage = "The folder of the new certificate file to be created")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByDefaultArmTemplate,
           HelpMessage = "The folder of the new certificate file to be created")]
        [ValidateNotNullOrEmpty]
        [Alias("Destination")]
        public override string CertificateOutputFolder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                  HelpMessage = "The password of the certificate file")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                  HelpMessage = "The password of the certificate file")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByDefaultArmTemplate,
                  HelpMessage = "The password of the certificate file")]
        [ValidateNotNullOrEmpty]
        [Alias("CertPassword")]
        public override SecureString CertificatePassword { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "The existing certificate file path for the secondary cluster certificate")]
        [ValidateNotNullOrEmpty]
        [Alias("SecSource")]
        public string SecondaryCertificateFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                 HelpMessage = "The password of the certificate file")]
        [ValidateNotNullOrEmpty]
        [Alias("SecCertPassword")]
        public virtual SecureString SecondaryCertificatePassword { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
              HelpMessage = "Azure key vault resource group name, if not given it will be defaulted to resource group name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
              HelpMessage = "Azure key vault resource group name, if not given it will be defaulted to resource group name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByDefaultArmTemplate,
              HelpMessage = "Azure key vault resource group name, if not given it will be defaulted to resource group name")]
        [ValidateNotNullOrEmpty]
        [Alias("KeyVaultResouceGroupName")]
        public override string KeyVaultResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                HelpMessage = "Azure key vault name, if not given it will be defaulted to the resource group name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                HelpMessage = "Azure key vault name, if not given it will be defaulted to the resource group name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByDefaultArmTemplate,
                HelpMessage = "Azure key vault name, if not given it will be defaulted to the resource group name")]
        [ValidateNotNullOrEmpty]
        public override string KeyVaultName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByExistingKeyVault,
                HelpMessage = "Certificate common name")]
        [Parameter(Mandatory = false, ParameterSetName = ByExistingPfxAndVaultName,
                HelpMessage = "Certificate common name")]
        [Alias("CertCommonName")]
        public override string CertificateCommonName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByExistingKeyVault,
                HelpMessage = "Certificate issuer thumbprint, separated by commas if more than one")]
        [Parameter(Mandatory = false, ParameterSetName = ByExistingPfxAndVaultName,
                HelpMessage = "Certificate issuer thumbprint, separated by commas if more than one")]
        [ValidateNotNullOrEmpty]
        [Alias("CertIssuerThumbprint")]
        public override string CertificateIssuerThumbprint { get; set; }

        #region ByDefaultArmTemplate

        [Parameter(Mandatory = true, ValueFromPipeline = true,ParameterSetName = ByDefaultArmTemplate, 
                   HelpMessage = "The resource group location")]
        [LocationCompleter("Microsoft.ServiceFabric/clusters")]
        public string Location { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true,ParameterSetName = ByDefaultArmTemplate, 
                   HelpMessage = "Specify the name of the cluster, if not given it will be same as resource group name")]
        [ValidateNotNullOrEmpty()]
        [ValidatePattern("^[a-z][a-z0-9-]{4,23}[a-z0-9]$")]
        [Alias("ClusterName")]
        public override string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByDefaultArmTemplate,
                 HelpMessage = "The user name for logging to Vm")]
        [ValidateNotNullOrEmpty()]
        [ValidatePattern("^[a-z][a-z0-9]{1,15}$")]
        public string VmUserName { get; set; }

        private int clusterSize = 5;
        [Parameter(Mandatory = false, ValueFromPipeline = true,ParameterSetName = ByDefaultArmTemplate, 
                   HelpMessage = "The number of nodes in the cluster. Default are 5 nodes")]
        [ValidateRange(1, 99)]
        public int ClusterSize
        {
            get { return this.clusterSize; }
            set { this.clusterSize = value; }
        }

        private string certificateSubjectName;
   
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The subject name of the certificate to be created")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByDefaultArmTemplate,
                   HelpMessage = "The subject name of the certificate to be created")]
        [ValidateNotNullOrEmpty]
        [Alias("Subject")]
        public override string CertificateSubjectName
        {
            get { return this.certificateSubjectName; }
            set
            {
                if (value.IndexOf("cn=", StringComparison.OrdinalIgnoreCase) == -1)
                {
                    this.certificateSubjectName = string.Concat("cn=", value);
                }
                else
                {
                    this.certificateSubjectName = value;
                }
            }
        }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingKeyVault,
                   HelpMessage = "The password of the Vm.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The password of the Vm.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "The password of the Vm.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByDefaultArmTemplate,
                   HelpMessage = "The password of the Vm.")]
        [ValidateNotNullOrEmpty]
        public SecureString VmPassword { get; set; }

        private OperatingSystem os = OperatingSystem.WindowsServer2016Datacenter;
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByDefaultArmTemplate,
                   HelpMessage = "The Operating System of the VMs that make up the cluster.")]
        [Alias("VmImage")]
        public OperatingSystem OS
        {
            get { return this.os; }
            set { this.os = value; }
        }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByDefaultArmTemplate,
                   HelpMessage = "The Vm Sku")]
        [Alias("Sku")]
        public string VmSku { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(target:  this.ResourceGroupName, action: string.Format("Create new cluster {0}", this.Name ?? this.ResourceGroupName)))
            {
                switch (ParameterSetName)
                {
                    case ByDefaultArmTemplate:
                        DeployWithDefaultTemplate();
                        break;
                    default:
                        DeployWithoutDefaultTemplate();
                        break;
                }
            }
        }

        protected override List<string> GetPfxSrcFiles()
        {
            return new List<string>() { this.CertificateFile, this.SecondaryCertificateFile };
        }

        protected override SecureString GetPfxPassword(string pfxFilePath)
        {
            if (this.CertificateFile != null)
            {
                if (this.CertificateFile.Equals(pfxFilePath, StringComparison.OrdinalIgnoreCase))
                {
                    return this.CertificatePassword;
                }
            }

            if (this.SecondaryCertificateFile != null)
            {
                if (this.SecondaryCertificateFile.Equals(pfxFilePath, StringComparison.OrdinalIgnoreCase))
                {
                    return this.SecondaryCertificatePassword;
                }
            }

            throw new PSArgumentException("pfxFilePath");
        }

        protected override void Validate()
        {
            base.Validate();

            if (ParameterSetName.Equals(ByDefaultArmTemplate) &&
                this.VmPassword == null)
            {
                throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidPassword);
            }

            if (this.VmPassword != null)
            {
                var plainPassword = this.VmPassword.ConvertToString();
                if (plainPassword.Length < 12 || plainPassword.Length > 123)
                {
                    throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidPassword);
                }

                int requirements = 0;

                if (plainPassword.Any(char.IsUpper))
                {
                    ++requirements;
                }

                if (plainPassword.Any(char.IsLower))
                {
                    ++requirements;
                }

                if (plainPassword.Any(char.IsDigit))
                {
                    ++requirements;
                }

                if (plainPassword.Any(c => !char.IsLetterOrDigit(c)))
                {
                    ++requirements;
                }

                if (requirements < 3)
                {
                    throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidPassword);
                }
            }
        }

        private void DeployWithoutDefaultTemplate()
        {
            var deployment = CreateBasicDeployment(DeploymentMode.Incremental, this.TemplateFile, this.ParameterFile);

            ParseTemplate(true);
            TranslateParameters(true);
            var parameters = (JObject)deployment.Properties.Parameters;
            ExtractParametersWithoutDefaultTemplate(parameters);

            if (this.VmPassword != null)
            {
                SetParameter(ref parameters, this.adminPasswordParameter, this.VmPassword.ConvertToString());
            }

            ResourceManagerClient.ResourceGroups.CreateOrUpdate(
                this.ResourceGroupName,
                new ResourceGroup
                {
                    Location = this.resourceLocation
                });

            var resourceGroup = this.ResourceManagerClient.ResourceGroups.Get(this.ResourceGroupName);

            SetCertSubjectNameIfApplicable(resourceGroup.Location);

            List<CertificateInformation> certificateInformations;
            parameters = FillCertificateInformationInParameters(parameters, out certificateInformations);

            deployment.Properties.Parameters = parameters;

            WriteVerboseWithTimestamp("Begin to validate deployment");

            var validateResult = this.ResourceManagerClient.Deployments.Validate(
                ResourceGroupName,
                GenerateDeploymentName(),
                deployment);

            CheckValidationResult(validateResult);

            WriteVerboseWithTimestamp("Template is valid");

            WaitForDeployment(deployment, certificateInformations);
        }

        private void DeployWithDefaultTemplate()
        {
            this.Name = this.Name ?? this.ResourceGroupName;
            var existingCluster = SafeGetResource(GetCurrentCluster, true);
            if (existingCluster != null)
            {
                if (!existingCluster.ClusterState.Equals("WaitingForNodes", StringComparison.OrdinalIgnoreCase))
                {
                    throw new PSInvalidOperationException(
                        string.Format(
                            ServiceFabricProperties.Resources.NewExistingCluster,
                            this.ResourceGroupName));
                }

                WriteVerboseWithTimestamp($"Found existing cluster {this.Name} with status: WaitingForNodes");
            }

            SetReliabilityLevel();

            var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (RunningTest)
            {
                assemblyFolder = AppDomain.CurrentDomain.BaseDirectory;
            }

            var templateFilePath = string.Empty;
            var parameterFilePath = string.Empty;
            // Future change: Use GitHub templates when possible
            if (string.IsNullOrWhiteSpace(templateFilePath) || string.IsNullOrWhiteSpace(parameterFilePath))
            {
                string osRelativePath;
                switch (this.OS)
                {
                    case OperatingSystem.WindowsServer2012R2Datacenter:
                    case OperatingSystem.WindowsServer2016Datacenter:
                    case OperatingSystem.WindowsServer2016DatacenterwithContainers:
                        osRelativePath = Constants.WindowsTemplateRelativePath;
                        break;
                    case OperatingSystem.UbuntuServer1604:
                        osRelativePath = Constants.UbuntuServer16TemplateRelativePath;
                        break;
                    case OperatingSystem.UbuntuServer1804:
                        osRelativePath = Constants.UbuntuServer18TemplateRelativePath;
                        break;
                    case OperatingSystem.UbuntuServer2004:
                        osRelativePath = Constants.UbuntuServer20TemplateRelativePath;
                        break;
                    default:
                        throw new NotImplementedException("OS not defined for DeployWithDefaultTemplate");
                }

                string templateDirectory = Path.Combine(assemblyFolder, osRelativePath);
                templateFilePath = Path.Combine(templateDirectory, Constants.TemplateFileName);
                parameterFilePath = Path.Combine(templateDirectory, Constants.ParameterFileName);
            }

            if (!File.Exists(templateFilePath) || !File.Exists(parameterFilePath))
            {
                throw new PSInvalidOperationException("Can't find the template or parameter file");
            }

            this.resourceLocation = this.Location;
            this.TemplateFile = templateFilePath;
            this.ParameterFile = parameterFilePath;

            this.ResourceManagerClient.ResourceGroups.CreateOrUpdate(
                this.ResourceGroupName,
                new ResourceGroup()
                {
                    Location = this.Location
                });

            var deployment = CreateBasicDeployment(DeploymentMode.Incremental, this.TemplateFile, this.ParameterFile);

            ParseTemplate(false);
            TranslateParameters(false);

            var parameters = (JObject)deployment.Properties.Parameters;
            ExtractParametersWithDefaultTemplate(parameters);

            var resourceGroup = this.ResourceManagerClient.ResourceGroups.Get(this.ResourceGroupName);
            SetCertSubjectNameIfApplicable(resourceGroup.Location);
            var certInformation = GetOrCreateCertificateInformation()[0];

            deployment.Properties.Parameters = SetParameters(
               parameters,
               certInformation.KeyVault.Id,
               certInformation.SecretUrl,
               certInformation.CertificateThumbprint,
               this.DefaultDurability,
               this.reliabilityLevel,
               this.Location,
               this.Name,
               this.VmUserName,
               this.VmPassword.ConvertToString(),
               this.VmSku,
               (int)this.clusterSize
              );

            WriteVerboseWithTimestamp("Begin to validate deployment");

            var validateResult = ResourceManagerClient.Deployments.Validate(
                ResourceGroupName,
                GenerateDeploymentName(),
                deployment
             );

            CheckValidationResult(validateResult);

            WriteVerboseWithTimestamp("Template is valid");

            WaitForDeployment(deployment, new List<CertificateInformation>() { certInformation});
        }

        private JObject FillCertificateInformationInParameters(JObject parameters, out List<CertificateInformation> certificateInformations)
        {
            ValidateCertParameters(parameters);

            certificateInformations = new List<CertificateInformation>();
            var sourceVaultValue = TryGetParameter(parameters, Constants.SourceVaultValue);
            var certificateThumbprint = TryGetParameter(parameters, Constants.CertificateThumbprint);
            var certificateUrlValue = TryGetParameter(parameters, Constants.CertificateUrlValue);
            var certificateCommonName = TryGetParameter(parameters, Constants.CertificateCommonName);
            var certificateIssuerThumbprint = TryGetParameter(parameters, Constants.CertificateIssuerThumbprint);

            var secSourceVaultValue = TryGetParameter(parameters, Constants.SecSourceVaultValue);
            var secCertificateThumbprint = TryGetParameter(parameters, Constants.SecCertificateThumbprint);
            var secCertificateUrlValue = TryGetParameter(parameters, Constants.SecCertificateUrlValue);

            List<CertificateInformation> certInfo = GetOrCreateCertificateInformation();
            var firstCert = certInfo[0];
            certificateInformations.Add(firstCert);

            SetParameter(ref parameters, Constants.SourceVaultValue, firstCert.KeyVault.Id);
            SetParameter(ref parameters, Constants.CertificateUrlValue, firstCert.SecretUrl);

            if (this.CertificateCommonName != null)
            {
                if (this.CertificateCommonName != firstCert.CertificateCommonName)
                {
                    throw new PSArgumentException(
                        string.Format(ServiceFabricProperties.Resources.CertificateCommonNameMismatch, 
                        this.CertificateCommonName, 
                        firstCert.CertificateCommonName));
                }

                SetParameter(ref parameters, Constants.CertificateCommonName, firstCert.CertificateCommonName);
                string issuerTP = this.CertificateIssuerThumbprint != null ? this.CertificateIssuerThumbprint : String.Empty;
                SetParameter(ref parameters, Constants.CertificateIssuerThumbprint, issuerTP);
            }
            else
            {
                SetParameter(ref parameters, Constants.CertificateThumbprint, firstCert.CertificateThumbprint);
            }


            if (secSourceVaultValue != null)
            {
                if (certInfo.Count > 1)
                {
                    var secCert = certInfo[1];
                    certificateInformations.Add(secCert);

                    SetParameter(ref parameters, Constants.SecSourceVaultValue, secCert.KeyVault.Id);
                    SetParameter(ref parameters, Constants.SecCertificateThumbprint, secCert.CertificateThumbprint);
                    SetParameter(ref parameters, Constants.SecCertificateUrlValue, secCert.SecretUrl);
                }
            }

            return parameters;
        }

        private void ValidateCertParameters(JObject parameters)
        {
            var sourceVaultValue = TryGetParameter(parameters, Constants.SourceVaultValue);
            var certificateThumbprint = TryGetParameter(parameters, Constants.CertificateThumbprint);
            var certificateUrlValue = TryGetParameter(parameters, Constants.CertificateUrlValue);
            var certificateCommonName = TryGetParameter(parameters, Constants.CertificateCommonName);
            var certificateIssuerThumbprint = TryGetParameter(parameters, Constants.CertificateIssuerThumbprint);

            var secSourceVaultValue = TryGetParameter(parameters, Constants.SecSourceVaultValue);
            var secCertificateThumbprint = TryGetParameter(parameters, Constants.SecCertificateThumbprint);
            var secCertificateUrlValue = TryGetParameter(parameters, Constants.SecCertificateUrlValue);

            if (this.CertificateCommonName != null)
            {
                if (certificateThumbprint != null || secSourceVaultValue != null || secCertificateThumbprint != null || secCertificateUrlValue != null)
                {
                    throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidCertificateInfoCNAndTPInParameterFile);
                }

                if (sourceVaultValue != null && certificateCommonName != null && certificateUrlValue != null && certificateIssuerThumbprint != null)
                {
                    WriteVerboseWithTimestamp("Found primary certificate parameters with common name in parameters file");
                }
                else
                {
                    throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidCertificateInformationCNInParameterFile);
                }
            }
            else
            {
                if (certificateCommonName != null)
                {
                    throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidCertificateInfoCNAndTPInParameterFile);
                }

                if (sourceVaultValue != null && certificateThumbprint != null && certificateUrlValue != null)
                {
                    if (certificateThumbprint != null)
                    {
                        WriteVerboseWithTimestamp("Found primary certificate parameters with thumbprint in parameters file");
                    }
                }
                else
                {
                    throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidCertificateInformationInParameterFile);
                }

                if (secSourceVaultValue != null && secCertificateThumbprint != null && secCertificateUrlValue != null)
                {
                    WriteVerboseWithTimestamp("Found secondary certificate parameters in parameters file");
                }
                else if (secSourceVaultValue == null && secCertificateThumbprint == null && secCertificateUrlValue == null)
                {
                    WriteVerboseWithTimestamp("There is no secondary certificate parameters in parameters file");
                }
                else
                {
                    throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidCertificateInformationInParameterFile);
                }
            }
        }

        private void WaitForDeployment(Deployment deployment, List<CertificateInformation> certInformations)
        {
            var token = new CancellationTokenSource();
            var deploymentName = GenerateDeploymentName();
            DeploymentExtended deploymentDetail = null;
            var deploymentTask = Task.Factory.StartNew(() =>
            {
                try
                {
                    deploymentDetail = ResourceManagerClient.Deployments.CreateOrUpdate(
                        this.ResourceGroupName,
                        deploymentName,
                        deployment);
                }
                finally
                {
                    token.Cancel();
                }
            });

            while (!token.IsCancellationRequested)
            {
                if (!RunningTest)
                {
                    WriteVerboseWithTimestamp(ServiceFabricProperties.Resources.DeploymentVerbose);

                    var c = SafeGetResource(() => this.GetCurrentCluster(), true);
                    if (c != null)
                    {
                        WriteVerboseWithTimestamp(string.Format(ServiceFabricProperties.Resources.ClusterStateVerbose,
                            c.ClusterState));
                    }
                }

                Thread.Sleep(TimeSpan.FromSeconds(WriteVerboseIntervalInSec));
            }

            PrintDetailIfThrow(() => deploymentTask.Wait());

            var cluster = GetCurrentCluster();

            WriteObject(
                new PSDeploymentResult(
                    deploymentDetail == null ? null : new PSDeploymentExtended(deploymentDetail),
                    new PSCluster(cluster),
                    this.adminUserName,
                    certInformations.Select(c => new PSKeyVault()
                    {
                        KeyVaultName = c.KeyVault.Name,
                        KeyVaultId = c.KeyVault.Id,
                        KeyVaultCertificateName = c.CertificateName,
                        KeyVaultCertificateId = c.CertificateUrl,
                        CertificateThumbprint = c.CertificateThumbprint,
                        Certificate = c.Certificate,
                        CertificateSavedLocalPath = c.CertificateOutputPath,
                        SecretIdentifier = c.SecretUrl
                    }).ToList()),
                true);
        }

        private string GenerateDeploymentName()
        {
            if (!string.IsNullOrEmpty(TemplateFile) && !ParameterSetName.Equals(ByDefaultArmTemplate))
            {
                return Path.GetFileNameWithoutExtension(TemplateFile);
            }
            else
            {
                return string.Format("AzurePSDeployment-{0}", DateTime.Now.ToString("MMddHHmmss"));
            }
        }

        private void SetCertSubjectNameIfApplicable(string location)
        {
            if (string.IsNullOrWhiteSpace(this.CertificateSubjectName))
            {
                if (string.IsNullOrWhiteSpace(this.domainNameLabel))
                {
                    throw new PSInvalidOperationException("Please specify the -certificateSubjectName");
                }

                this.CertificateSubjectName = string.Format(DefaultPublicDnsFormat, this.domainNameLabel, location);
            }
        }

        private JObject SetParameters(
            JObject parameters,
            string keyVault,
            string certificateUrl,
            string thumbprint,
            string durabilityLevel,
            string reliability,
            string location = null,
            string clusterName = null,
            string vmUserName = null,
            string adminPassword = null,
            string sku = null,
            int vmSize = -1)
        {
            SetParameter(ref parameters, this.thumbprintParameter, thumbprint);
            SetParameter(ref parameters, this.keyVaultParameter, keyVault);
            SetParameter(ref parameters, this.certificateUrlParameter, certificateUrl);

            SetParameter(ref parameters, this.durabilityLevelParameter, durabilityLevel);
            SetParameter(ref parameters, this.reliabilityLevelParameter, reliability);
            SetParameter(ref parameters, this.skuParameter, sku);
            SetParameter(ref parameters, this.vmImageSkuParameter, OsToVmSkuString[this.OS]);

            if (location != null)
            {
                SetParameter(ref parameters, this.locationParameter, location);
            }

            if (clusterName != null)
            {
                SetParameter(ref parameters, this.clusterNameParameter, clusterName);
            }

            if (vmUserName != null)
            {
                SetParameter(ref parameters, this.adminUserParameter, vmUserName);
            }

            if (adminPassword != null)
            {
                SetParameter(ref parameters, this.adminPasswordParameter, adminPassword);
            }

            if (vmSize != -1)
            {
                SetParameter(ref parameters, this.vmInstanceParameter, vmSize);
            }

            return parameters;
        }

        private void ExtractParametersWithoutDefaultTemplate(JObject parameters)
        {
            this.adminUserName = TryGetParameter(parameters, this.adminUserParameter) ?? this.adminUserParameter;
            this.resourceLocation = TryGetParameter(parameters, this.locationParameter) ?? this.locationParameter;
            this.Name = TryGetParameter(parameters, this.clusterNameParameter) ?? this.clusterNameParameter;
            this.domainNameLabel = TryGetParameter(parameters, this.domainNameLabelParameter) ?? this.domainNameLabelParameter;
        }

        private void ExtractParametersWithDefaultTemplate(JObject parameters)
        {
            this.adminUserName = TryGetParameter((JObject)parameters, this.adminUserParameter) ?? this.adminUserParameter;
            this.domainNameLabel = TryGetParameter((JObject)parameters, this.domainNameLabelParameter) ?? this.domainNameLabelParameter;
        }

        private string TryGetParameter(JObject parameters, string parameterName)
        {
            var value = parameters.GetValue(parameterName, StringComparison.OrdinalIgnoreCase);
            if (value == null)
            {
                return null;
            }

            value = value["value"];
            return value == null ? null : value.ToString();
        }

        private void ParseTemplate(bool customize)
        {
            JObject jObject;
            if (!TryParseJson(this.TemplateFile, out jObject))
            {
                throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidTemplateFile);
            }

            var resources = jObject.SelectToken("resources", true);

            var settings = new JsonSerializerSettings
            {
                Error = (sender, argss) =>
                {
                    argss.ErrorContext.Handled = true;
                }
            };

            var serializer = JsonSerializer.Create(settings);

            foreach (var resource in resources)
            {
                if (resource["type"] == null)
                {
                    throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidTemplateFile);
                }

                var resourceType = resource["type"];

                if (resourceType.ToString().Equals(Constants.VirtualMachineScaleSetsType, StringComparison.OrdinalIgnoreCase))
                {
                    this.locationParameter = ((JValue)resource.SelectToken("location", true)).ToString();
                    var resourceObject = (JObject)resource;
                    this.vmInstanceParameter = ((JValue)resourceObject.SelectToken("sku.capacity", true)).ToString();
                    this.skuParameter = ((JValue) resourceObject.SelectToken("sku.name", true)).ToString();

                    resourceObject = (JObject)resourceObject.SelectToken("properties.virtualMachineProfile", true);
                    var vmssProfile = resourceObject.ToObject<VirtualMachineScaleSetVMProfile>(serializer);
                    this.adminUserParameter = vmssProfile.OsProfile.AdminUsername;
                    this.adminPasswordParameter = vmssProfile.OsProfile.AdminPassword;
                    this.vmImageSkuParameter = vmssProfile.StorageProfile.ImageReference.Sku;

                    if (!customize)
                    {
                        foreach (var secret in vmssProfile.OsProfile.Secrets)
                        {
                            if (
                                !secret.SourceVault.Id.Equals(TranslateToParameterName(secret.SourceVault.Id, this.TemplateFile),
                                    StringComparison.OrdinalIgnoreCase))
                            {
                                this.keyVaultParameter = secret.SourceVault.Id;
                                foreach (var cert in secret.VaultCertificates)
                                {
                                    if (
                                        !cert.CertificateUrl.Equals(TranslateToParameterName(cert.CertificateUrl, this.TemplateFile),
                                            StringComparison.OrdinalIgnoreCase))
                                    {
                                        this.certificateUrlParameter = cert.CertificateUrl;
                                    }
                                }
                            }
                        }
                    }

                    var resourceArray = (JArray)resourceObject.SelectToken("extensionProfile.extensions", true);

                    foreach (var extObject in resourceArray)
                    {
                        var extProperty = (JObject)extObject.SelectToken("properties", true);

                        var publisher = (JValue)extProperty.SelectToken("publisher", true);

                        if (publisher.ToString().Equals(Constants.ServiceFabricPublisher, StringComparison.OrdinalIgnoreCase))
                        {
                            var extSetting = (JObject) extProperty.SelectToken("settings", true);
                            if (extSetting["durabilityLevel"] == null ||
                                extSetting["certificate"] == null ||
                                (extSetting["certificate"]["thumbprint"] == null &&
                                extSetting["certificate"]["commonNames"] == null))
                            {
                                throw new PSArgumentException(
                                    ServiceFabricProperties.Resources.InvalidSFExtensionInTemplate);
                            }

                            if (!customize)
                            {
                                this.durabilityLevelParameter = extSetting["durabilityLevel"].ToString();
                                this.thumbprintParameter = extSetting["certificate"]["thumbprint"].ToString();
                            }
                        }
                    }
                }

                if (resourceType.ToString().Equals(Constants.ServiceFabricType, StringComparison.OrdinalIgnoreCase))
                {
                    this.clusterNameParameter = ((JValue)resource.SelectToken("name", true)).ToString();

                    if (!customize)
                    {
                        this.reliabilityLevelParameter =
                            ((JValue) resource.SelectToken("properties.reliabilityLevel", true)).ToString();
                    }
                }

                if (resourceType.ToString().Equals(Constants.PublicIpAddressesType, StringComparison.OrdinalIgnoreCase))
                {
                    var value = ((JValue)resource.SelectToken("properties.dnsSettings.domainNameLabel", true)).ToString();
                    if (this.domainNameLabelParameter == string.Empty ||
                        value.Length < this.domainNameLabelParameter.Length)
                    {
                        this.domainNameLabelParameter = value;
                    }
                }
            }
        }

        private void TranslateParameters(bool customize)
        {
            this.adminUserParameter = TranslateToParameterName(this.adminUserParameter, this.TemplateFile);
            this.adminPasswordParameter = TranslateToParameterName(this.adminPasswordParameter, this.TemplateFile);
            this.locationParameter = TranslateToParameterName(this.locationParameter, this.TemplateFile);
            this.clusterNameParameter = TranslateToParameterName(this.clusterNameParameter, this.TemplateFile);
            this.domainNameLabelParameter = TranslateToParameterName(this.domainNameLabelParameter, this.TemplateFile);

            if (!customize)
            {
                this.vmInstanceParameter = TranslateToParameterName(this.vmInstanceParameter, this.TemplateFile);
                this.durabilityLevelParameter = TranslateToParameterName(this.durabilityLevelParameter, this.TemplateFile);
                this.reliabilityLevelParameter = TranslateToParameterName(this.reliabilityLevelParameter, this.TemplateFile);
                this.thumbprintParameter = TranslateToParameterName(this.thumbprintParameter, this.TemplateFile);
                this.keyVaultParameter = TranslateToParameterName(this.keyVaultParameter, this.TemplateFile);
                this.certificateUrlParameter = TranslateToParameterName(this.certificateUrlParameter, this.TemplateFile);
                this.skuParameter = TranslateToParameterName(this.skuParameter, this.TemplateFile);
                this.vmImageSkuParameter = TranslateToParameterName(this.vmImageSkuParameter, this.TemplateFile);
            }
        }

        private void SetReliabilityLevel()
        {
            if (this.ClusterSize >= (int)ReliabilityLevel.None &&
               this.ClusterSize < (int)ReliabilityLevel.Bronze)
            {
                this.reliabilityLevel = ReliabilityLevel.None.ToString();
            }
            else if (this.ClusterSize >= (int)ReliabilityLevel.Bronze &&
                     this.ClusterSize < (int)ReliabilityLevel.Silver)
            {
                this.reliabilityLevel = ReliabilityLevel.Bronze.ToString();
            }
            else if (this.ClusterSize >= (int)ReliabilityLevel.Silver &&
                     this.ClusterSize < (int)ReliabilityLevel.Gold)
            {
                this.reliabilityLevel = ReliabilityLevel.Silver.ToString();
            }
            else if (this.ClusterSize >= (int)ReliabilityLevel.Gold &&
                this.ClusterSize < (int)ReliabilityLevel.Platinum)
            {
                this.reliabilityLevel = ReliabilityLevel.Gold.ToString();
            }
            else if (this.ClusterSize >= (int)ReliabilityLevel.Platinum)
            {
                this.reliabilityLevel = ReliabilityLevel.Platinum.ToString();
            }
        }
    }
}
