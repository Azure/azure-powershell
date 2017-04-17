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
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.WindowsAzure.Commands.Common;

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
        public const string DefaultPfxName = "ServiceFabricSelfSigned";

        private const string PfxFileSuffix = ".pfx";
        private string vmUserName = string.Empty;

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

        [Parameter(Mandatory = false, ParameterSetName = ByExistingPfxSetAndVaultId, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The deployment mode.")]
        [Parameter(Mandatory = false, ParameterSetName = ByNewPfxAndVaultId, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The deployment mode.")]
        [Parameter(Mandatory = false, ParameterSetName = ByExistingPfxAndVaultName, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The deployment mode.")]
        [Parameter(Mandatory = false, ParameterSetName = ByNewPfxAndVaultName, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The deployment mode.")]
        [Parameter(Mandatory = false, ParameterSetName = ExistingKeyVaultSet, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The deployment mode.")]
        [Parameter(Mandatory = false, ParameterSetName = ByDefaultArmTemplate, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The deployment mode.")]
        public DeploymentMode Mode { get; set; }

        #region ByDefaultArmTemplate

        [Parameter(Mandatory = true, ParameterSetName = ByDefaultArmTemplate, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The resource group location")]
        public string Location { get; set; }

        private ClusterSize clusterSize = ClusterSize.FiveNodes;
        [Parameter(Mandatory = false, ParameterSetName = ByDefaultArmTemplate, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The cluster size, the default is 5 nodes clusters")]
        public ClusterSize ClusterSize
        {
            get { return this.clusterSize; }
            set { this.clusterSize = value; }
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultId,
                 HelpMessage = "The password of the pfx file")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxSetAndVaultId,
                 HelpMessage = "The password of the pfx file")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
                 HelpMessage = "The password of the pfx file")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxAndVaultName,
                 HelpMessage = "The password of the pfx file")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByDefaultArmTemplate,
                   HelpMessage = "The password of the pfx file")]
        [ValidateNotNullOrEmpty]
        [Alias("CertPwd")]
        public override SecureString CertificatePassword { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultId,
                   HelpMessage = "The Dns name of the certificate to be created")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The Dns name of the certificate to be created")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByDefaultArmTemplate,
                   HelpMessage = "The Dns name of the certificate to be created")]
        [ValidateNotNullOrEmpty]
        [Alias("Dns")]
        public override string CertificateDnsName { get; set; }

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
            string clusterName = null;
            string location = null;
            var deploymentName = GenerateDeploymentName();
            var deployment = CreateBasicDeployment(this.Mode, null);

            this.vmUserName = ((JObject)deployment.Properties.Parameters)["adminUserName"]["value"].ToString();

            GetClusterNameAndLocation((JObject)deployment.Properties.Template, out clusterName, out location);
            if (IsARMParameter(ref clusterName))
            {
                this.ClusterName = ParseParameter(
                     (JObject)deployment.Properties.Parameters,
                     clusterName);
            }

            if (IsARMParameter(ref location))
            {
                this.resourceLocation = ParseParameter(
                    (JObject)deployment.Properties.Parameters,
                    location);
            }

            var certInformation = GetOrCreateCertificateInformation();

            deployment.Properties.Template = ReplaceTemplate(
                (JObject)deployment.Properties.Template,
                certInformation.Thumbprint,
                null,
                certInformation.KeyVault.Id,
                certInformation.SecretUrl,
                null
                );

            if (deployment.Properties.Template == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.FailedToParseTemplateFile);
            }

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

            var deploymentDetail = ResourceManagerClient.Deployments.CreateOrUpdate(
                ResourceGroupName,
                deploymentName,
                deployment);

            var cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.ClusterName);
            WriteObject(new PSDeploymentResult(
                deploymentDetail,
                new PSCluster(cluster))
                {
                    VmUserName = this.vmUserName
                }, true);
        }

        private void DeployWithDefaultTemplate()
        {
            this.ClusterName = this.ResourceGroupName;
            var existingCluster = SafeGetResource(
                 () => SFRPClient.Clusters.Get(this.ResourceGroupName, this.ClusterName));

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
            this.PfxDestinationFile = Path.Combine(
                this.GetDefaultPfxName(this.SessionState.Path.CurrentFileSystemLocation.Path)
                );
            this.ClusterName = this.ResourceGroupName;

            this.ResourceManagerClient.ResourceGroups.CreateOrUpdate(
                this.ResourceGroupName,
                new ResourceGroup()
                {
                    Location = this.Location
                });            

            var clusterSizes = (int)this.clusterSize;
            var parameters = ReplaceParameterFile(
                this.Location,
                this.ClusterName,
                this.VmPassword.ConvertToString(),
                clusterSizes);

            var deployment = CreateBasicDeployment(this.Mode, null, parameters);

            var certInformation = GetOrCreateCertificateInformation();

            deployment.Properties.Template = ReplaceTemplate(
                (JObject)deployment.Properties.Template,
                certInformation.Thumbprint,
                null,
                certInformation.KeyVault.Id,
                certInformation.SecretUrl,
                null
                );

            var validateResult = ResourceManagerClient.Deployments.Validate(
                ResourceGroupName,
                GenerateDeploymentName(),
                deployment
             );

            CheckValidationResult(validateResult);

            var deploymentName = GenerateDeploymentName();
            var deploymentDetail = ResourceManagerClient.Deployments.CreateOrUpdate(
                ResourceGroupName,
                deploymentName,
                deployment);

            var cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.ClusterName);
            WriteObject(new PSDeploymentResult(
                deploymentDetail,
                new PSCluster(cluster))
                {
                    VmUserName = this.vmUserName
                }, true);
        }

        private string GetDefaultPfxName(string outPutDir)
        {
            var filePath = Path.Combine(outPutDir, string.Concat(DefaultPfxName, PfxFileSuffix));
            int i = 1;
            while (File.Exists(filePath))
            {
                filePath = Path.Combine(outPutDir, string.Concat(DefaultPfxName, i++.ToString(), PfxFileSuffix));
            }

            return filePath;
        }

        private bool IsARMParameter(ref string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
            {
                throw new PSArgumentException("Parameter");
            }

            if (parameter.IndexOf('[') == -1 ||
                parameter.IndexOf("parameters", StringComparison.InvariantCultureIgnoreCase) == -1)
            {
                return false;
            }
            else
            {
                int front = parameter.IndexOf('(');
                int back = parameter.IndexOf(')');
                var subStr = parameter.Substring(front + 1, back - front - 1);
                var p = subStr.Trim().Split('\'').Where(s => !string.IsNullOrEmpty(s));
                if (p.Count() != 1)
                {
                    throw new PSInvalidOperationException(ServiceFabricProperties.Resources.FailedToParseParameterFile);
                }

                parameter = p.First().Trim();
                return true;
            }
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

        private Deployment CreateBasicDeployment(
            DeploymentMode deploymentMode,
            string debugSetting,
            JObject parameters = null)
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

        private JObject ReplaceTemplate(
            JObject template,
            string certificateThumbprint,
            string secondaryCertificateThumbprint,
            string sourceVaultValue,
            string certificateUrl,
            string secondaryCertificateUrl
            )
        {
            if (string.IsNullOrEmpty(certificateThumbprint) ||
                string.IsNullOrEmpty(sourceVaultValue) ||
                string.IsNullOrEmpty(certificateUrl))
            {
                throw new Exception();
            }

            var resources = template["resources"];
            if (resources != null)
            {
                foreach (var item in resources.Children())
                {
                    if (item["tags"] != null
                        && item["tags"]["resourceType"] != null
                        && string.Compare(
                            item["tags"]["resourceType"].ToString(),
                            Constants.ServieFabricTag,
                            StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (item["type"] != null && string.Compare(
                            item["type"].ToString(),
                            Constants.VirtualMachineScaleSetsType,
                            StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            var extensions = item["properties"]
                                                  ["virtualMachineProfile"]
                                                  ["extensionProfile"]
                                                  ["extensions"];

                            //Windows extention
                            var extension = extensions.Children().First(e => string.Compare(
                                e["properties"]["type"].ToString(),
                                Constants.ServiceFabricWindowsNodeExtName,
                                StringComparison.OrdinalIgnoreCase) == 0);

                            //Linux extention
                            if (extension == null || !extension.Any())
                            {
                                extension = extensions.Children().First(e => string.Compare(
                                    e["properties"]["type"].ToString(),
                                    Constants.ServiceFabricLinuxNodeExtName,
                                    StringComparison.OrdinalIgnoreCase) == 0);
                            }

                            if (extension == null || !extension.Any())
                            {
                                throw new PSArgumentException();
                            }

                            var certificate = extension["properties"]["settings"]["certificate"];

                            if (!string.IsNullOrEmpty(certificateThumbprint))
                            {
                                certificate["thumbprint"] = certificateThumbprint;
                            }

                            if (!string.IsNullOrEmpty(secondaryCertificateThumbprint))
                            {
                                var certificateSecondary = extension["properties"]["settings"]["certificateSecondary"];
                                if (certificateSecondary == null)
                                {
                                    extension["properties"]["settings"]["certificateSecondary"] = certificate;
                                    extension["properties"]["settings"]["certificateSecondary"]["thumbprint"] = secondaryCertificateThumbprint;
                                }
                            }

                            var secrets = item["properties"]
                                              ["virtualMachineProfile"]
                                              ["osProfile"]
                                              ["secrets"].First();

                            var sourceVault = secrets["sourceVault"];
                            sourceVault["id"] = sourceVaultValue;
                            var vaultCertificates = (JArray)secrets["vaultCertificates"];

                            vaultCertificates[0]["certificateUrl"] = certificateUrl;
                            if (!string.IsNullOrEmpty(secondaryCertificateUrl))
                            {
                                if (vaultCertificates.Count == 1)
                                {
                                    vaultCertificates.AddFirst(vaultCertificates.First());
                                }

                                vaultCertificates[1]["certificateUrl"] = secondaryCertificateUrl;
                            }
                        }

                        if (item["type"] != null && string.Compare(
                            item["type"].ToString(),
                            Constants.ServiceFabricType,
                            StringComparison.OrdinalIgnoreCase) == 0)
                        {

                            item["properties"]["certificate"]["thumbprint"] = certificateThumbprint;
                            if (!string.IsNullOrEmpty(secondaryCertificateThumbprint))
                            {
                                item["properties"]["certificate"]["thumbprintSecondary"] = secondaryCertificateThumbprint;
                            }
                        }

                    }
                }

                return template;
            }

            return null;
        }

        private JObject ReplaceParameterFile(
            string clusterLocation,
            string clusterName,
            string adminPassword,
            int nt0InstanceCount)
        {
            var parameters = JObject.Parse(
                    FileUtilities.DataStore.ReadFileAsText(this.ParameterFile))["parameters"];

            parameters["clusterLocation"]["value"] = clusterLocation;
            parameters["clusterName"]["value"] = clusterName;
            parameters["adminPassword"]["value"] = adminPassword;
            parameters["nt0InstanceCount"]["value"] = nt0InstanceCount;

            this.vmUserName = parameters["adminUserName"]["value"].ToString();

            return (JObject)parameters;
        }

        private void GetClusterNameAndLocation(
            JObject template,
            out string clusterName,
            out string location)
        {
            clusterName = null;
            location = null;

            var resources = template["resources"];
            foreach (var item in resources.Children())
            {
                if (item["tags"] != null
                    && item["tags"]["resourceType"] != null
                    && string.Compare(
                        item["tags"]["resourceType"].ToString(),
                        Constants.ServieFabricTag,
                        StringComparison.OrdinalIgnoreCase) == 0)
                {
                    if (item["type"] != null && string.Compare(
                            item["type"].ToString(),
                            Constants.ServiceFabricType,
                            StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        location = item["location"].ToString();
                        clusterName = item["name"].ToString();
                    }
                }
            }
        }

        private string ParseParameter(JObject parameters, string propertyName)
        {
            var valueStr = parameters[propertyName]["value"].ToString().Trim();
            var singleOrDefault = valueStr.Split('\"').SingleOrDefault(v => !string.IsNullOrWhiteSpace(v));
            return singleOrDefault?.Trim();
        }

        private void DisplayInnerDetailErrorMessage(
            ResourceManagementErrorWithDetails error)
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

        private void CheckValidationResult(
            DeploymentValidateResult validateResult)
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