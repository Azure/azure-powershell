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
    [Cmdlet(VerbsCommon.New, CmdletNoun.AzureRmServiceFabricCluster)]
    public class NewAzureRmServiceFabricCluster : ServiceFabricClusterCertificateCmdlet
    {
        public override string ClusterName { get; set; }

        public const string WindowsTemplateRelativePath = @"Template\Windows";
        public const string LinuxTemplateRelativePath = @"Template\Linux";
        public const string ParameterFileName = @"parameter.json";
        public const string TemplateFileName = @"template.json";
    
        private string adminUserName = string.Empty;
        private string durability = DurabilityLevel.Bronze.ToString();
        private string reliabilityLevel = ReliabilityLevel.Bronze.ToString();

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
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByDefaultArmTemplate, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByExistingPfxSetAndVaultId, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The path of the template file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByNewPfxAndVaultId, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The path of the template file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The path of the template file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The path of the template file.")]
        [Parameter(Mandatory = true, ParameterSetName = ExistingKeyVaultSet, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The path of the template file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateFile { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByExistingPfxSetAndVaultId, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The path of the template parameter file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByNewPfxAndVaultId, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The path of the template parameter file.")]
        [Parameter(Mandatory = true, ParameterSetName = ExistingKeyVaultSet, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The path of the template parameter file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The path of the template parameter file.")]
        [Parameter(Mandatory = true, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The path of the template parameter file.")]
        [ValidateNotNullOrEmpty]
        public string ParameterFile { get; set; }

        #region ByDefaultArmTemplate

        [Parameter(Mandatory = true, ParameterSetName = ByDefaultArmTemplate, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The resource group location")]
        public string Location { get; set; }

        private int clusterSize = 5;
        [Parameter(Mandatory = false, ParameterSetName = ByDefaultArmTemplate, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The cluster size, the default is 5 nodes clusters")]
        [ValidateRange(1, 2147483647)]
        public int ClusterSize
        {
            get { return this.clusterSize; }
            set { this.clusterSize = value; }
        }

        private string certificateSubjectName;
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultId,
                   HelpMessage = "The Dns name of the certificate to be created")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The Dns name of the certificate to be created")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByDefaultArmTemplate,
                   HelpMessage = "The Dns name of the certificate to be created")]
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

        private OS os = OS.Windows;
        [Parameter(Mandatory = false, ParameterSetName = ByDefaultArmTemplate, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The OS of the cluster")]
        [Alias("OperatingSystem")]
        public OS OS
        {
            get { return this.os; }
            set { this.os = value; }
        }

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

        private void DeployWithoutDefaultTemplate()
        {
            var deploymentName = GenerateDeploymentName();
            var deployment = CreateBasicDeployment(DeploymentMode.Incremental, null);

            ParseTempldate();
            GetParameters((JObject)deployment.Properties.Parameters);
   
            var certInformation = GetOrCreateCertificateInformation();

            deployment.Properties.Parameters = SetParameters(
                (JObject)deployment.Properties.Parameters,
                certInformation.KeyVault.Id,
                certInformation.SecretUrl,
                certInformation.Thumbprint,
                this.durability,
                this.reliabilityLevel);   

            ResourceManagerClient.ResourceGroups.CreateOrUpdate(
                this.ResourceGroupName,
                new ResourceGroup
                {
                    Location = this.resourceLocation
                });

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

            var cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.ClusterName);
            WriteObject(new PSDeploymentResult(
                deploymentDetail,
                new PSCluster(cluster))
            {
                VmUserName = this.adminUserParameter
            }, true);
        }

        private void DeployWithDefaultTemplate()
        {
            this.ClusterName = this.ResourceGroupName;
            var existingCluster = SafeGetResource(
                 () => SFRPClient.Clusters.Get(this.ResourceGroupName, this.ClusterName));

            if (this.ClusterSize == 1)
            {
                this.reliabilityLevel = "None";
            }

            if (existingCluster != null)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                    ServiceFabricProperties.Resources.NewExistingCluster,
                    this.ResourceGroupName));
            }

            var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string templateFilePath = string.Empty;
            string parameterFilePath = string.Empty;
            if (OS == OS.Windows)
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

            this.resourceLocation = Location;
            this.TemplateFile = templateFilePath;
            this.ParameterFile = parameterFilePath;
            if(string.IsNullOrEmpty(PfxDestinationFile))
           
            this.ClusterName = this.ResourceGroupName;

            this.ResourceManagerClient.ResourceGroups.CreateOrUpdate(
                this.ResourceGroupName,
                new ResourceGroup()
                {
                    Location = this.Location
                });

            var deployment = CreateBasicDeployment(DeploymentMode.Incremental, null);
            ParseTempldate();

            this.adminUserName = GetParameter((JObject)deployment.Properties.Parameters, this.adminUserParameter) ?? this.adminUserParameter;

            var certInformation = GetOrCreateCertificateInformation();

            deployment.Properties.Parameters = SetParameters(
               (JObject)deployment.Properties.Parameters,
               certInformation.KeyVault.Id,
               certInformation.SecretUrl,
               certInformation.Thumbprint,
               this.durability,
               this.reliabilityLevel,
               this.Location,
               this.ClusterName,
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

            PrintDetailIfThrow(()=> 
                deploymentDetail = ResourceManagerClient.Deployments.CreateOrUpdate(  
                    ResourceGroupName, 
                    deploymentName,  
                    deployment));

            var cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.ClusterName);
            WriteObject(new PSDeploymentResult(
                deploymentDetail,
                new PSCluster(cluster))
            {
                VmUserName = this.adminUserName
            }, true);
        }

        private string GenerateDeploymentName()
        {
            if (!string.IsNullOrEmpty(TemplateFile))
            {
                return Path.GetFileNameWithoutExtension(TemplateFile);
            }
            else
            {
                return Guid.NewGuid().ToString();
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

            deployment.Properties.Template = JObject.Parse(
                     FileUtilities.DataStore.ReadFileAsText(TemplateFile));

            if (parameters == null)
            {
                deployment.Properties.Parameters = JObject.Parse(
                    FileUtilities.DataStore.ReadFileAsText(ParameterFile))["parameters"];
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


        private void GetParameters(JObject parameters)
        {
            this.adminUserName = GetParameter(parameters, this.adminUserParameter) ?? this.adminUserParameter;
            this.resourceLocation = GetParameter(parameters, this.locationParameter) ?? this.locationParameter;
            this.ClusterName = GetParameter(parameters, this.clusterNameParameter) ?? this.clusterNameParameter;
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

        private string GetParameter(JObject parameters, string parameterName)
        {
            return parameters.GetValue(
                parameterName,
                StringComparison.OrdinalIgnoreCase)["value"].ToString();
        }

        private void ParseTempldate()
        {
            var templateString = FileUtilities.DataStore.ReadFileAsText(this.TemplateFile);
            var jObject = JObject.Parse(templateString);
            var resources = jObject.SelectToken("resources");

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
                if (resource["type"].ToString().Equals(Constants.VirtualMachineScaleSetsType, StringComparison.OrdinalIgnoreCase))
                {
                    this.locationParameter = ((JValue)resource.SelectToken("location")).ToString();
                    var resourceObject = (JObject)resource;
                    this.vmInstanceParameter = ((JValue)resourceObject.SelectToken("sku.capacity", true)).ToString();

                    resourceObject = (JObject)resourceObject.SelectToken("properties.virtualMachineProfile", true);
                    var vmssProfile = resourceObject.ToObject<VirtualMachineScaleSetVMProfile>(serializer);
                    this.adminUserParameter = vmssProfile.OsProfile.AdminUsername;
                    this.adminPasswordParameter = vmssProfile.OsProfile.AdminPassword;

                    foreach (var secret in vmssProfile.OsProfile.Secrets)
                    {
                        if (!secret.SourceVault.Id.Equals(GetParameterName(secret.SourceVault.Id)))
                        {
                            keyVaultParameter = secret.SourceVault.Id;
                            foreach (var cert in secret.VaultCertificates)
                            {
                                if (!cert.CertificateUrl.Equals(GetParameterName(cert.CertificateUrl)))
                                {
                                    this.certificateUrlParameter = cert.CertificateUrl;
                                }
                            }
                        }
                    }

                    var resourceArray = (JArray)resourceObject.SelectToken("extensionProfile.extensions");

                    foreach (var extObject in resourceArray)
                    {
                        var extProperty = (JObject)extObject.SelectToken("properties", true);

                        var publisher = (JValue)extProperty.SelectToken("publisher", true);

                        if (publisher.ToString().Equals(Constants.ServiceFabricPublisher, StringComparison.OrdinalIgnoreCase))
                        {
                            var extSetting = (JObject)extProperty.SelectToken("settings", true);

                            this.durabilityLevelParameter = extSetting["durabilityLevel"].ToString();
                            this.thumbprintParameter = extSetting["certificate"]["thumbprint"].ToString();
                        }
                    }
                }

                if (resource["type"].ToString().Equals(Constants.ServiceFabricType, StringComparison.OrdinalIgnoreCase))
                {
                    this.clusterNameParameter = ((JValue)resource.SelectToken("name")).ToString();
                    this.reliabilityLevelParameter =
                        ((JValue) resource.SelectToken("properties.reliabilityLevel")).ToString();
                }
            }

            this.adminUserParameter = GetParameterName(this.adminUserParameter);
            this.locationParameter = GetParameterName(this.locationParameter);
            this.thumbprintParameter = GetParameterName(this.thumbprintParameter);
            this.keyVaultParameter = GetParameterName(this.keyVaultParameter);
            this.certificateUrlParameter = GetParameterName(this.certificateUrlParameter);
            this.clusterNameParameter = GetParameterName(this.clusterNameParameter);
            this.adminPasswordParameter = GetParameterName(this.adminPasswordParameter);
            this.vmInstanceParameter = GetParameterName(this.vmInstanceParameter);
            this.durabilityLevelParameter = GetParameterName(this.durabilityLevelParameter);
            this.reliabilityLevelParameter = GetParameterName(this.reliabilityLevelParameter);
        }

        private string GetParameterName(string parameter)
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
                var jObject = JObject.Parse(templateString);
                var variables = jObject.SelectToken("variables");
                return GetParameterName(variables[parameterArray[1]].ToString());
            }
            else
            {
                return parameterArray[1];
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