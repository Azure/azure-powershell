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

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.New, CmdletNoun.AzureRmServiceFabricCluster, SupportsShouldProcess = true), OutputType(typeof(PSDeploymentResult))]
    public class NewAzureRmServiceFabricCluster : ServiceFabricClusterCertificateCmdlet
    {
        public override string Name { get; set; }

        public const string WindowsTemplateRelativePath = @"Template\Windows";
        public const string LinuxTemplateRelativePath = @"Template\Linux";
        public const string ParameterFileName = @"parameter.json";
        public const string TemplateFileName = @"template.json";

        public const string DefaultPublicDnsFormat = "{0}.{1}.cloudapp.azure.com";

        private string adminUserName = string.Empty;
        private string durability = DurabilityLevel.Bronze.ToString();
        private string reliabilityLevel = ReliabilityLevel.Bronze.ToString();
        private string domainNameLabel = string.Empty;

        private string reliabilityLevelParameter = string.Empty;
        private string durabilityLevelParameter = string.Empty;
        private string clusterNameParameter = string.Empty;
        private string vmInstanceParameter = string.Empty;
        private string adminPasswordParameter = string.Empty;
        private string adminUserParameter = string.Empty;
        private string locationParameter = string.Empty;
        private string thumbprintParameter = string.Empty;
        private string keyVaultParameter = string.Empty;
        private string certificateUrlParameter = string.Empty;
        private string domainNameLabelParameter = string.Empty;

        /// <summary>
        /// Resource group name
        /// </summary>
        /// 
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ExistingKeyVault, ValueFromPipeline = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipeline = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipeline = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByExistingPfxAndVaultId, ValueFromPipeline = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByDefaultArmTemplate, ValueFromPipeline = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByNewPfxAndVaultId, ValueFromPipeline = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByExistingPfxAndVaultId, ValueFromPipeline = true,
                   HelpMessage = "The path to the template file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByNewPfxAndVaultId, ValueFromPipeline = true,
                   HelpMessage = "The path to the template file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipeline = true,
                   HelpMessage = "The path to the template file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipeline = true,
                   HelpMessage = "The path to the template file.")]
        [Parameter(Mandatory = true, ParameterSetName = ExistingKeyVault, ValueFromPipeline = true,
                   HelpMessage = "The path to the template file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateFile { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByExistingPfxAndVaultId, ValueFromPipeline = true,
                   HelpMessage = "The path to the template parameter file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByNewPfxAndVaultId, ValueFromPipeline = true,
                   HelpMessage = "The path to the template parameter file.")]
        [Parameter(Mandatory = true, ParameterSetName = ExistingKeyVault, ValueFromPipeline = true,
                   HelpMessage = "The path to the template parameter file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipeline = true,
                   HelpMessage = "The path to the template parameter file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipeline = true,
                   HelpMessage = "The path to the template parameter file.")]
        [ValidateNotNullOrEmpty]
        public string ParameterFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "Azure key vault resource group name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "Azure key vault resource group name")]
        [ValidateNotNullOrEmpty]
        public override string KeyVaultResouceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
                HelpMessage = "Azure key vault name")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultName,
                HelpMessage = "Azure key vault name")]
        [ValidateNotNullOrEmpty]
        public override string KeyVaultName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultId,
                   HelpMessage = "Azure key vault resource id")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ByExistingPfxAndVaultId,
                   HelpMessage = "Azure key vault resource id")]
        [ValidateNotNullOrEmpty]
        public override string KeyVaultResouceId { get; set; }

        #region ByDefaultArmTemplate

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
        public override string KeyVaultCertificateName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByDefaultArmTemplate, ValueFromPipeline = true,
                   HelpMessage = "The resource group location")]
        public string Location { get; set; }

        private int clusterSize = 5;
        [Parameter(Mandatory = false, ParameterSetName = ByDefaultArmTemplate, ValueFromPipeline = true,
                   HelpMessage = "The number of nodes in the cluster. Default is 5 nodes")]
        [ValidateRange(1, 2147483647)]
        public int ClusterSize
        {
            get { return this.clusterSize; }
            set { this.clusterSize = value; }
        }

        private string certificateSubjectName;
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultId,
                   HelpMessage = "The subject name of the certificate to be created")]
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

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByDefaultArmTemplate,
                   HelpMessage = "The password of the Vm")]
        [ValidateNotNullOrEmpty]
        public SecureString VmPassword { get; set; }

        private VmImage vmImage = VmImage.Windows;
        [Parameter(Mandatory = false, ParameterSetName = ByDefaultArmTemplate, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The OS type of the cluster")]
        public VmImage VmImage
        {
            get { return this.vmImage; }
            set { this.vmImage = value; }
        }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultId,
          HelpMessage = "The destination path of the new Pfx file to be created")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByNewPfxAndVaultName,
          HelpMessage = "The destination path of the new Pfx file to be created")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ByDefaultArmTemplate,
          HelpMessage = "The destination path of the new Pfx file to be created")]
        [ValidateNotNullOrEmpty]
        [Alias("Destination")]
        public override string PfxDestinationFile { get; set; }
        #endregion

        private string resourceLocation;

        public override string KeyVaultResouceGroupLocation
        {
            get
            {
                return this.resourceLocation;
            }
        }

        public const string ErrorFormat = "Error: Code={0}; Message={1}\r\n";

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.Name, action: string.Format("Create an new cluster {0} ", this.Name)))
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

        private void DeployWithoutDefaultTemplate()
        {
            var deploymentName = GenerateDeploymentName();
            var deployment = CreateBasicDeployment(DeploymentMode.Incremental, null);

            ParseTemplate();
            ExtractParametersWithoutDefaultTemplate((JObject)deployment.Properties.Parameters);

            ResourceManagerClient.ResourceGroups.CreateOrUpdate(
                this.ResourceGroupName,
                new ResourceGroup
                {
                    Location = this.resourceLocation
                });

            var resourceGroup = this.ResourceManagerClient.ResourceGroups.Get(this.ResourceGroupName);

            SetCertSubjectNameIfApplicable(resourceGroup.Location);

            var certInformation = GetOrCreateCertificateInformation();

            deployment.Properties.Parameters = SetParameters(
                (JObject)deployment.Properties.Parameters,
                certInformation.KeyVault.Id,
                certInformation.SecretUrl,
                certInformation.Thumbprint,
                this.durability,
                this.reliabilityLevel);

            var validateResult = ResourceManagerClient.Deployments.Validate(
              ResourceGroupName,
              GenerateDeploymentName(),
              deployment
              );

            CheckValidationResult(validateResult);

            DeploymentExtended deploymentDetail = null;

            PrintDetailIfThrow(() =>
                 deploymentDetail = ResourceManagerClient.Deployments.CreateOrUpdate(
                     ResourceGroupName,
                     deploymentName,
                     deployment));

            var cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.Name);

            WriteObject(
                new PSDeploymentResult(
                    deploymentDetail== null ? null : new PSDeploymentExtended(deploymentDetail),
                    new PSCluster(cluster),
                    this.adminUserParameter,
                    certInformation.Certificate,
                    certInformation.Thumbprint,
                    certInformation.KeyVault.Name,
                    certInformation.CertificateName,
                    certInformation.SecretName,
                    certInformation.Version),
                true);
        }

        private void DeployWithDefaultTemplate()
        {
            this.Name = this.ResourceGroupName;
            var existingCluster = SafeGetResource(
                 () => SFRPClient.Clusters.Get(this.ResourceGroupName, this.Name));

            SetReliabilityLevel();

            if (existingCluster != null)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.NewExistingCluster,
                        this.ResourceGroupName));
            }

            var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var templateFilePath = string.Empty;
            var parameterFilePath = string.Empty;
            if (VmImage == VmImage.Windows)
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
                throw new PSInvalidOperationException("Can't find the template and parameter file");
            }

            this.resourceLocation = this.Location;
            this.TemplateFile = templateFilePath;
            this.ParameterFile = parameterFilePath;

            this.Name = this.ResourceGroupName;

            this.ResourceManagerClient.ResourceGroups.CreateOrUpdate(
                this.ResourceGroupName,
                new ResourceGroup()
                {
                    Location = this.Location
                });

            var deployment = CreateBasicDeployment(DeploymentMode.Incremental, null);
            ParseTemplate();

            var parameters = (JObject)deployment.Properties.Parameters;
            SetParameter(ref parameters, this.clusterNameParameter, this.Name);

            ExtractParametersWithDefaultTemplate((JObject)deployment.Properties.Parameters);

            var resourceGroup = this.ResourceManagerClient.ResourceGroups.Get(this.ResourceGroupName);
            SetCertSubjectNameIfApplicable(resourceGroup.Location);
            var certInformation = GetOrCreateCertificateInformation();

            deployment.Properties.Parameters = SetParameters(
               (JObject)deployment.Properties.Parameters,
               certInformation.KeyVault.Id,
               certInformation.SecretUrl,
               certInformation.Thumbprint,
               this.durability,
               this.reliabilityLevel,
               this.Location,
               this.Name,
               this.VmPassword.ConvertToString(),
               (int)this.clusterSize
              );

            var validateResult = ResourceManagerClient.Deployments.Validate(
                ResourceGroupName,
                GenerateDeploymentName(),
                deployment
             );

            CheckValidationResult(validateResult);

            var deploymentName = GenerateDeploymentName();

            DeploymentExtended deploymentDetail = null;

            PrintDetailIfThrow(() =>
                deploymentDetail = ResourceManagerClient.Deployments.CreateOrUpdate(
                    ResourceGroupName,
                    deploymentName,
                    deployment));

            var cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.Name);

            WriteObject(
                new PSDeploymentResult(
                    deploymentDetail == null ? null : new PSDeploymentExtended(deploymentDetail),
                    new PSCluster(cluster),
                    this.adminUserParameter,
                    certInformation.Certificate,
                    certInformation.Thumbprint,
                    certInformation.KeyVault.Name,
                    certInformation.CertificateName,
                    certInformation.SecretName,
                    certInformation.Version),
                true);
        }

        private string GenerateDeploymentName()
        {
            if (!string.IsNullOrEmpty(TemplateFile))
            {
                return Path.GetFileNameWithoutExtension(TemplateFile);
            }
            else
            {
                return string.Format("AzureSDKDeployment-{0}", DateTime.Now.ToString("MMddHHmmss"));
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
            string adminPassword = null,
            int vmSize = -1)
        {
            SetParameter(ref parameters, this.thumbprintParameter, thumbprint);
            SetParameter(ref parameters, this.keyVaultParameter, keyVault);
            SetParameter(ref parameters, this.certificateUrlParameter, certificateUrl);
            SetParameter(ref parameters, this.durabilityLevelParameter, durabilityLevel);
            SetParameter(ref parameters, this.reliabilityLevelParameter, reliability);

            if (location != null)
            {
                SetParameter(ref parameters, this.locationParameter, location);
            }

            if (clusterName != null)
            {
                SetParameter(ref parameters, this.clusterNameParameter, clusterName);
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
            var token = parameters.Children().SingleOrDefault(
                    j => ((JProperty)j).Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase));

            if (token != null)
            {
                token.First()["value"] = value;
            }
        }

        private string TryGetParameter(JObject parameters, string parameterName)
        {
            var value = parameters.GetValue(
                parameterName,
                StringComparison.OrdinalIgnoreCase)["value"];

            return value?.ToString();
        }

        private void ParseTemplate()
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
                if (resource["type"].ToString()
                    .Equals(Constants.VirtualMachineScaleSetsType, StringComparison.OrdinalIgnoreCase))
                {
                    this.locationParameter = ((JValue)resource.SelectToken("location", true)).ToString();
                    var resourceObject = (JObject)resource;
                    this.vmInstanceParameter = ((JValue)resourceObject.SelectToken("sku.capacity", true)).ToString();

                    resourceObject = (JObject)resourceObject.SelectToken("properties.virtualMachineProfile", true);
                    var vmssProfile = resourceObject.ToObject<VirtualMachineScaleSetVMProfile>(serializer);
                    this.adminUserParameter = vmssProfile.OsProfile.AdminUsername;
                    this.adminPasswordParameter = vmssProfile.OsProfile.AdminPassword;

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

                    var resourceArray = (JArray)resourceObject.SelectToken("extensionProfile.extensions", true);

                    foreach (var extObject in resourceArray)
                    {
                        var extProperty = (JObject)extObject.SelectToken("properties", true);

                        var publisher = (JValue)extProperty.SelectToken("publisher", true);

                        if (publisher.ToString().Equals(Constants.ServiceFabricPublisher, StringComparison.OrdinalIgnoreCase))
                        {
                            var extSetting = (JObject)extProperty.SelectToken("settings", true);
                            if (extSetting["durabilityLevel"] == null ||
                                extSetting["certificate"] == null ||
                                extSetting["certificate"]["thumbprint"] == null)
                            {
                                throw new InvalidOperationException(ServiceFabricProperties.Resources.InvalidTemplateFile);
                            }

                            this.durabilityLevelParameter = extSetting["durabilityLevel"].ToString();
                            this.thumbprintParameter = extSetting["certificate"]["thumbprint"].ToString();
                        }
                    }
                }

                if (resource["type"].ToString().Equals(Constants.ServiceFabricType, StringComparison.OrdinalIgnoreCase))
                {
                    this.clusterNameParameter = ((JValue)resource.SelectToken("name", true)).ToString();
                    this.reliabilityLevelParameter =
                        ((JValue)resource.SelectToken("properties.reliabilityLevel", true)).ToString();
                }

                if (resource["type"].ToString().Equals(Constants.PublicIpAddressesType, StringComparison.OrdinalIgnoreCase))
                {
                    this.domainNameLabelParameter =
                        ((JValue)resource.SelectToken("properties.dnsSettings.domainNameLabel", true)).ToString();
                }
            }

            this.adminUserParameter = TranslateToParameterName(this.adminUserParameter);
            this.locationParameter = TranslateToParameterName(this.locationParameter);
            this.thumbprintParameter = TranslateToParameterName(this.thumbprintParameter);
            this.keyVaultParameter = TranslateToParameterName(this.keyVaultParameter);
            this.certificateUrlParameter = TranslateToParameterName(this.certificateUrlParameter);
            this.clusterNameParameter = TranslateToParameterName(this.clusterNameParameter);
            this.adminPasswordParameter = TranslateToParameterName(this.adminPasswordParameter);
            this.vmInstanceParameter = TranslateToParameterName(this.vmInstanceParameter);
            this.durabilityLevelParameter = TranslateToParameterName(this.durabilityLevelParameter);
            this.reliabilityLevelParameter = TranslateToParameterName(this.reliabilityLevelParameter);
            this.domainNameLabelParameter = TranslateToParameterName(this.domainNameLabelParameter);
        }

        private string TranslateToParameterName(string parameter)
        {
            var parameterArray = parameter.Split(
                new char[] { '[', ']', '(', ')', '\'' },
                StringSplitOptions.RemoveEmptyEntries);

            if (parameterArray.Count() == 1)
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

                var variables = jObject.SelectToken("variables");
                return TranslateToParameterName(variables[parameterArray[1]].ToString());
            }
            else
            {
                return parameterArray[1];
            }
        }

        private void SetReliabilityLevel()
        {
            if (this.ClusterSize == (int)ReliabilityLevel.None)
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
            catch (Exception)
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
            else
            {
                WriteVerbose(ServiceFabricProperties.Resources.DeploymentSucceeded);
            }
        }
    }
}