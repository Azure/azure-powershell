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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Newtonsoft.Json.Linq;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.New, CmdletNoun.AzureRmServiceFabricCluster)]
    public class NewAzureRmServiceFabricCluster : ServiceFabricClusterCertificateCmdlet
    {
        public override string ClusterName { get; set; }

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
        public string TemplateParameterFile { get; set; }

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
        public DeploymentMode Mode { get; set; }

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
            string clusterName = null;
            string location = null;
            var deploymentName = GenerateDeploymentName();
            var deployment = CreateBasicDeployment(this.Mode, null);

            GetClusterNameAndLocation((JObject)deployment.Properties.Template, out clusterName, out location);
            if (IsARMParameter(ref clusterName))
            {
               this.ClusterName = clusterName = ParseParameter(
                    (JObject)deployment.Properties.Parameters,
                    clusterName);
            }

            if (IsARMParameter(ref location))
            {
                this.resourceLocation = location = ParseParameter(
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

            ResourceManagerClient.Deployments.CreateOrUpdate(
                ResourceGroupName,
                deploymentName,
                deployment);

            var cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.ClusterName);
            WriteObject(new PsCluster(cluster), true);
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
            string debugSetting)
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

            deployment.Properties.Parameters = JObject.Parse(
                FileUtilities.DataStore.ReadFileAsText(TemplateParameterFile))["parameters"];

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
                            @"Service Fabric",
                            StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (item["type"] != null && string.Compare(
                            item["type"].ToString(),
                            @"Microsoft.Compute/virtualMachineScaleSets",
                            StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            var extensions = item["properties"]
                                                  ["virtualMachineProfile"]
                                                  ["extensionProfile"]
                                                  ["extensions"];

                            //Windows extention
                            var extension = extensions.Children().First(e => string.Compare(
                                e["properties"]["type"].ToString(),
                                "ServiceFabricNode",
                                StringComparison.OrdinalIgnoreCase) == 0);

                            //Linux extention
                            if (extension == null || !extension.Any())
                            {
                                extension = extensions.Children().First(e => string.Compare(
                                    e["properties"]["type"].ToString(),
                                    "ServiceFabricLinuxNode",
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
                            @"Microsoft.ServiceFabric/clusters",
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
                        @"Service Fabric",
                        StringComparison.OrdinalIgnoreCase) == 0)
                {
                    if (item["type"] != null && string.Compare(
                            item["type"].ToString(),
                            @"Microsoft.ServiceFabric/clusters",
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
            return valueStr.Split('\"').SingleOrDefault(v => !string.IsNullOrWhiteSpace(v)).Trim();
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
             
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.DeploymentFailed);
            }
            else
            {
                WriteVerbose(ServiceFabricProperties.Resources.DeploymentSucceeded);
            }
        }
    }
}