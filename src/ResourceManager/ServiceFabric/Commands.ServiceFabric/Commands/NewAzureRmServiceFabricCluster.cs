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
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.WindowsAzure.Commands.Common;
using Newtonsoft.Json;
using OperatingSystem = Microsoft.Azure.Commands.ServiceFabric.Models.OperatingSystem;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.New, CmdletNoun.AzureRmServiceFabricCluster, SupportsShouldProcess = true, DefaultParameterSetName = ByDefaultArmTemplate),
     OutputType(typeof(PSDeploymentResult))]
    public class NewAzureRmServiceFabricCluster : ServiceFabricClusterCertificateCmdlet
    {
        public const string WindowsTemplateRelativePath = @"Template\Windows";
        public const string LinuxTemplateRelativePath = @"Template\Linux";
        public const string ParameterFileName = @"parameter.json";
        public const string TemplateFileName = @"template.json";
        
        public readonly Dictionary<OperatingSystem, string> OsToVmSkuString = new Dictionary<OperatingSystem, string>()
        {
            {OperatingSystem.WindowsServer2012R2Datacenter, "2012-R2-Datacenter"},
            {OperatingSystem.UbuntuServer1604, "16.04"},
            {OperatingSystem.WindowsServer2016DatacenterwithContainers, "2016-Datacenter-with-Containers"},
            {OperatingSystem.WindowsServer2016Datacenter, "2016-Datacenter"}
        };

        private string resourceLocation;
        public override string KeyVaultResouceGroupLocation
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
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ExistingKeyVault, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByDefaultArmTemplate, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipeline = true,
                   HelpMessage = "The path to the template file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipeline = true,
                   HelpMessage = "The path to the template file.")]
        [Parameter(Mandatory = true, ParameterSetName = ExistingKeyVault, ValueFromPipeline = true,
                   HelpMessage = "The path to the template file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateFile { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ExistingKeyVault, ValueFromPipeline = true,
                   HelpMessage = "The path to the template parameter file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipeline = true,
                   HelpMessage = "The path to the template parameter file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipeline = true,
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
              HelpMessage = "Azure key vault resource group name, it not given it will be defaulted to resource group name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
              HelpMessage = "Azure key vault resource group name, it not given it will be defaulted to resource group name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByDefaultArmTemplate,
              HelpMessage = "Azure key vault resource group name, it not given it will be defaulted to resource group name")]
        [ValidateNotNullOrEmpty]
        public override string KeyVaultResouceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                HelpMessage = "Azure key vault name, it not given it will be defaulted to the resource group name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                HelpMessage = "Azure key vault name, it not given it will be defaulted to the resource group name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByDefaultArmTemplate,
                HelpMessage = "Azure key vault name, it not given it will be defaulted to the resource group name")]
        [ValidateNotNullOrEmpty]
        public override string KeyVaultName { get; set; }

        #region ByDefaultArmTemplate

        [Parameter(Mandatory = true, ParameterSetName = ByDefaultArmTemplate, ValueFromPipeline = true,
                   HelpMessage = "The resource group location")]
        [LocationCompleter("Microsoft.ServiceFabric/clusters")]
        public string Location { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByDefaultArmTemplate, ValueFromPipeline = true,
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
        [Parameter(Mandatory = false, ParameterSetName = ByDefaultArmTemplate, ValueFromPipeline = true,
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

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByDefaultArmTemplate,
                   HelpMessage = "The password of the Vm")]
        [ValidateNotNullOrEmpty]
        public SecureString VmPassword { get; set; }

        private OperatingSystem os = OperatingSystem.WindowsServer2016Datacenter;
        [Parameter(Mandatory = false, ParameterSetName = ByDefaultArmTemplate, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The Operating System of the VMs that make up the cluster.")]
        [Alias("VmImage")]
        public OperatingSystem OS
        {
            get { return this.os; }
            set { this.os = value; }
        }

        [Parameter(Mandatory = false, ParameterSetName = ByDefaultArmTemplate, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The Vm Sku")]
        [Alias("Sku")]
        public string VmSku { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(target:  this.ResourceGroupName, action: string.Format("Create an new cluster {0} ", this.Name ??this.ResourceGroupName)))
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

            if (ParameterSetName.Equals(ByDefaultArmTemplate))
            {
                if (this.VmPassword == null)
                {
                    throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidPassword);
                }

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

                if (plainPassword.Any(char.IsLetterOrDigit))
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
            var deployment = CreateBasicDeployment(DeploymentMode.Incremental, null);

            ParseTemplate(true);
            TranslateParameters(true);
            ExtractParametersWithoutDefaultTemplate((JObject)deployment.Properties.Parameters);

            ResourceManagerClient.ResourceGroups.CreateOrUpdate(
                this.ResourceGroupName,
                new ResourceGroup
                {
                    Location = this.resourceLocation
                });

            var resourceGroup = this.ResourceManagerClient.ResourceGroups.Get(this.ResourceGroupName);

            SetCertSubjectNameIfApplicable(resourceGroup.Location);

            List<CertificateInformation> certificateInformations;
            deployment.Properties.Parameters =
                FillCertificateInformationInParameters((JObject) deployment.Properties.Parameters, out certificateInformations);

            WriteVerboseWithTimestamp("Begin to validate deployment");

            var validateResult = this.ResourceManagerClient.Deployments.Validate(
              ResourceGroupName,
              GenerateDeploymentName(),
              deployment
              );

            CheckValidationResult(validateResult);

            WriteVerboseWithTimestamp("Template is valid");

            WaitForDeployment(deployment, certificateInformations);
        }

        private void DeployWithDefaultTemplate()
        {
            this.Name = this.Name ?? this.ResourceGroupName;
            var existingCluster = SafeGetResource(() => SFRPClient.Clusters.Get(this.ResourceGroupName, this.Name), true);

            if (existingCluster != null)
            {
                if (!existingCluster.ClusterState.Equals("WaitingForNodes", StringComparison.OrdinalIgnoreCase))
                {
                    throw new PSInvalidOperationException(
                        string.Format(
                            ServiceFabricProperties.Resources.NewExistingCluster,
                            this.ResourceGroupName));
                }
                else
                {
                    WriteVerboseWithTimestamp(string.Format("Found existing cluster {0} which's status is waiting for nodes", this.Name));
                }
            }

            SetReliabilityLevel();

            var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var templateFilePath = string.Empty;
            var parameterFilePath = string.Empty;
            if (this.OS != OperatingSystem.UbuntuServer1604)
            {
                templateFilePath = Path.Combine(assemblyFolder, WindowsTemplateRelativePath, TemplateFileName);
                parameterFilePath = Path.Combine(assemblyFolder, WindowsTemplateRelativePath, ParameterFileName);
            }
            else
            {
                templateFilePath = Path.Combine(assemblyFolder, LinuxTemplateRelativePath, TemplateFileName);
                parameterFilePath = Path.Combine(assemblyFolder, LinuxTemplateRelativePath, ParameterFileName);
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

            var deployment = CreateBasicDeployment(DeploymentMode.Incremental, null);

            ParseTemplate(false);
            TranslateParameters(false);
            var parameters = (JObject)deployment.Properties.Parameters;

            SetParameter(ref parameters, this.clusterNameParameter, this.Name);

            ExtractParametersWithDefaultTemplate((JObject)deployment.Properties.Parameters);

            var resourceGroup = this.ResourceManagerClient.ResourceGroups.Get(this.ResourceGroupName);
            SetCertSubjectNameIfApplicable(resourceGroup.Location);
            var certInformation = GetOrCreateCertificateInformation()[0];

            deployment.Properties.Parameters = SetParameters(
               (JObject)deployment.Properties.Parameters,
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
            certificateInformations = new List<CertificateInformation>();
            var sourceVaultValue = TryGetParameter(parameters, Constants.SourceVaultValue);
            var certificateThumbprint = TryGetParameter(parameters, Constants.CertificateThumbprint);
            var certificateUrlValue = TryGetParameter(parameters, Constants.CertificateUrlValue);

            var secSourceVaultValue = TryGetParameter(parameters, Constants.SecSourceVaultValue);
            var secCertificateThumbprint = TryGetParameter(parameters, Constants.SecCertificateThumbprint);
            var secCertificateUrlValue = TryGetParameter(parameters, Constants.SecCertificateUrlValue);

            if (sourceVaultValue != null && certificateThumbprint != null && certificateUrlValue != null)
            {
                WriteVerboseWithTimestamp("Found primary certificate parameters in parameters file");
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

            var firstCert = GetOrCreateCertificateInformation()[0];
            certificateInformations.Add(firstCert);

            SetParameter(ref parameters, Constants.SourceVaultValue, firstCert.KeyVault.Id);
            SetParameter(ref parameters, Constants.CertificateThumbprint, firstCert.CertificateThumbprint);
            SetParameter(ref parameters, Constants.CertificateUrlValue, firstCert.SecretUrl);

            if (secSourceVaultValue != null)
            {
                var secCert = GetOrCreateCertificateInformation()[0];
                certificateInformations.Add(firstCert);

                SetParameter(ref parameters, Constants.SecSourceVaultValue, secCert.KeyVault.Id);
                SetParameter(ref parameters, Constants.SecCertificateThumbprint, secCert.CertificateThumbprint);
                SetParameter(ref parameters, Constants.SecCertificateUrlValue, secCert.SecretUrl);
            }

            return parameters;
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

                    var c = SafeGetResource(() => this.SFRPClient.Clusters.Get(this.ResourceGroupName, this.Name), true);
                    if (c != null)
                    {
                        WriteVerboseWithTimestamp(string.Format(ServiceFabricProperties.Resources.ClusterStateVerbose,
                            c.ClusterState));
                    }
                }

                Thread.Sleep(TimeSpan.FromSeconds(WriteVerboseIntervalInSec));
            }

            PrintDetailIfThrow(() => deploymentTask.Wait());

            var cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.Name);

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

        private Deployment CreateBasicDeployment(DeploymentMode deploymentMode, string debugSetting, JObject parameters = null)
        {
            var deployment = new Deployment
            {
                Properties = new DeploymentProperties
                {
                    Mode = deploymentMode
                }
            };

            if (!string.IsNullOrEmpty(debugSetting))
            {
                deployment.Properties.DebugSetting = new DebugSetting()
                {
                    DetailLevel = debugSetting
                };
            }

            JObject templateJObject;

            if (!TryParse(FileUtilities.DataStore.ReadFileAsText(this.TemplateFile), out templateJObject))
            {
                throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidTemplateFile);
            }

            deployment.Properties.Template = templateJObject;

            if (parameters == null)
            {
                JObject parameterJObject;

                if (!TryParse(FileUtilities.DataStore.ReadFileAsText(this.ParameterFile), out parameterJObject))
                {
                    throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidTemplateParameterFile);
                }

                if (parameterJObject["parameters"] == null)
                {
                    throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidTemplateParameterFile);
                }

                deployment.Properties.Parameters = parameterJObject["parameters"];
            }
            else
            {
                deployment.Properties.Parameters = parameters;
            }

            return deployment;
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

        private void SetParameter(ref JObject parameters, string parameterName, int value)
        {
            var token = parameters.Children().SingleOrDefault(
                    j => ((JProperty)j).Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase));

            if (token != null)
            {
                token.First()["value"] = value;
            }
        }

        private void SetParameter(ref JObject parameters, string parameterName, string value)
        {
            if (value != null)
            {
                var token = parameters.Children().SingleOrDefault(
                        j => ((JProperty)j).Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase));

                if (token != null && token.Any())
                {
                    token.First()["value"] = value;
                }
            }
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
            var templateString = FileUtilities.DataStore.ReadFileAsText(this.TemplateFile);

            JObject jObject;
            if (!TryParse(templateString, out jObject))
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
                    throw new InvalidOperationException(ServiceFabricProperties.Resources.InvalidTemplateFile);
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
                                !secret.SourceVault.Id.Equals(TranslateToParameterName(secret.SourceVault.Id),
                                    StringComparison.OrdinalIgnoreCase))
                            {
                                this.keyVaultParameter = secret.SourceVault.Id;
                                foreach (var cert in secret.VaultCertificates)
                                {
                                    if (
                                        !cert.CertificateUrl.Equals(TranslateToParameterName(cert.CertificateUrl),
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
                                extSetting["certificate"]["thumbprint"] == null)
                            {
                                throw new InvalidOperationException(
                                    ServiceFabricProperties.Resources.InvalidTemplateFile);
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
            this.adminUserParameter = TranslateToParameterName(this.adminUserParameter);
            this.locationParameter = TranslateToParameterName(this.locationParameter);
            this.clusterNameParameter = TranslateToParameterName(this.clusterNameParameter);
            this.domainNameLabelParameter = TranslateToParameterName(this.domainNameLabelParameter);

            if (!customize)
            {
                this.adminPasswordParameter = TranslateToParameterName(this.adminPasswordParameter);
                this.vmInstanceParameter = TranslateToParameterName(this.vmInstanceParameter);
                this.durabilityLevelParameter = TranslateToParameterName(this.durabilityLevelParameter);
                this.reliabilityLevelParameter = TranslateToParameterName(this.reliabilityLevelParameter);
                this.thumbprintParameter = TranslateToParameterName(this.thumbprintParameter);
                this.keyVaultParameter = TranslateToParameterName(this.keyVaultParameter);
                this.certificateUrlParameter = TranslateToParameterName(this.certificateUrlParameter);
                this.skuParameter = TranslateToParameterName(this.skuParameter);
                this.vmImageSkuParameter = TranslateToParameterName(this.vmImageSkuParameter);
            }
        }

        private string TranslateToParameterName(string parameter)
        {
            var parameterArray = parameter.Split(
                new char[] { '[', ']', '(', ')', '\'' },
                StringSplitOptions.RemoveEmptyEntries);

            if (parameterArray.Count() <= 1)
            {
                return parameter;
            }

            if (parameterArray[0].Equals("variables", StringComparison.OrdinalIgnoreCase))
            {
                var templateString = FileUtilities.DataStore.ReadFileAsText(this.TemplateFile);

                JObject jObject;
                if (!TryParse(templateString, out jObject))
                {
                    throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidTemplateFile);
                }

                var variables = jObject.SelectToken("variables", true);
                return TranslateToParameterName(variables[parameterArray[1]].ToString());
            }
            else
            {
                return parameterArray[1];
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

        private bool TryParse(string content, out JObject jObject)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new PSArgumentException(content);
            }

            try
            {
                jObject = JObject.Parse(content);
                return true;
            }
            catch (JsonReaderException)
            {
                jObject = null;
                return false;
            }
        }

        private void DisplayInnerDetailErrorMessage(ResourceManagementErrorWithDetails error)
        {
            var ex = new Exception(string.Format(ErrorFormat, error.Code, error.Message));
            WriteError(
               new ErrorRecord(
                   ex,
                   string.Empty,
                   ErrorCategory.NotSpecified,
                   null));

            if (error.Details != null)
            {
                foreach (var innerError in error.Details)
                {
                    DisplayInnerDetailErrorMessage(innerError);
                }
            }
        }

        private void CheckValidationResult(DeploymentValidateResult validateResult)
        {
            if (validateResult.Error != null)
            {
                if (validateResult.Error.Details != null)
                {
                    foreach (var error in validateResult.Error.Details)
                    {
                        var ex = new Exception(
                            string.Format(ErrorFormat, error.Code, error.Message));
                        WriteError(
                            new ErrorRecord(
                                ex,
                                string.Empty,
                                ErrorCategory.NotSpecified,
                                null));

                        if (error.Details != null && error.Details.Count > 0)
                        {
                            foreach (var innerError in error.Details)
                            {
                                DisplayInnerDetailErrorMessage(innerError);
                            }
                        }
                    }
                }
                else
                {
                    var ex = new Exception(
                           string.Format(ErrorFormat, validateResult.Error.Code, validateResult.Error.Message));
                    WriteError(
                           new ErrorRecord(
                               ex,
                               string.Empty,
                               ErrorCategory.NotSpecified,
                               null));
                }

                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.DeploymentFailed);
            } 
        }
    }
}