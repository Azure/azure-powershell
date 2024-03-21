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


//This class is split from the ResourcesExtensions class. Since this module has both cmdlets that use the old sdk version and cmdlets that use the new one, we needed client extension classes for both and with this split
//this class acts as the client for the cmdlets using the newer bits while the ResourcesExtensions class acts as the client for the cmdlets using old sdk

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.NewSdkExtensions
{
    public static class ResourcesExtensions
    {
        public static PSResourceGroup ToPSResourceGroup(this ResourceGroup resourceGroup)
        {
            var result = new PSResourceGroup
            {
                ResourceGroupName = resourceGroup.Name,
                Location = resourceGroup.Location,
                ProvisioningState = resourceGroup.Properties == null ? null : resourceGroup.Properties.ProvisioningState,
                Tags = TagsConversionHelper.CreateTagHashtable(resourceGroup.Tags),
                ResourceId = resourceGroup.Id,
                ManagedBy = resourceGroup.ManagedBy
            };

            return result;
        }

        public static PSResourceGroupDeployment ToPSResourceGroupDeployment(this DeploymentExtended result, string resourceGroup)
        {
            PSResourceGroupDeployment deployment = new PSResourceGroupDeployment();

            if (result != null)
            {
                deployment = CreatePSResourceGroupDeployment(result, resourceGroup);
            }

            return deployment;
        }

        public static PSDeployment ToPSDeployment(this DeploymentExtended result, string managementGroupId = null, string resourceGroupName = null)
        {
            PSDeployment deployment = new PSDeployment();

            if (result != null)
            {
                deployment = CreatePSDeployment(result, managementGroupId, resourceGroupName);
            }

            return deployment;
        }

        public static PSDeploymentOperation ToPSDeploymentOperation(this DeploymentOperation result)
        {
            if (result != null)
            {
                return new PSDeploymentOperation()
                {
                    Id = result.Id,
                    OperationId = result.OperationId,
                    ProvisioningState = result.Properties.ProvisioningState,
                    StatusCode = result.Properties.StatusCode,
                    StatusMessage = result.Properties.StatusMessage?.Error?.ToFormattedString(),
                    TargetResource = result.Properties.TargetResource?.Id
                };
            }

            return null;
        }

        public static PSResourceManagerError ToPSResourceManagerError(this ErrorResponse error)
        {
            PSResourceManagerError rmError = new PSResourceManagerError
            {
                Code = error.Code,
                Message = error.Message,
                Target = string.IsNullOrEmpty(error.Target) ? null : error.Target
            };

            if(error.Details != null)
            {
                List<PSResourceManagerError> innerRMError = new List<PSResourceManagerError>();
                error.Details.ForEach(detail => innerRMError.Add(detail.ToPSResourceManagerError()));
                rmError.Details = innerRMError;
            }

            return rmError;
        }

        public static string ToFormattedString(this ErrorResponse error, int level = 0)
        {
            if (error.Details == null)
            {
                return string.Format(ProjectResources.DeploymentOperationErrorMessageNoDetails, error.Message, error.Code);
            }

            string errorDetail = null;

            foreach (ErrorResponse detail in error.Details)
            {
                errorDetail += GetIndentation(level) + ToFormattedString(detail, level + 1) + System.Environment.NewLine;
            }

            return string.Format(ProjectResources.DeploymentOperationErrorMessage, error.Message, error.Code, errorDetail);
        }

        private static string GetIndentation(int l)
        {
            return new StringBuilder().Append(' ', l * 2).Append(" - ").ToString();
        }

        public static PSResourceProvider ToPSResourceProvider(this Provider provider)
        {
            return new PSResourceProvider
            {
                ProviderNamespace = provider.NamespaceProperty,
                RegistrationState = provider.RegistrationState,
                ResourceTypes = provider.ResourceTypes.Select(resourceType => new PSResourceProviderResourceType
                {
                    ResourceTypeName = resourceType.ResourceType,
                    Locations = resourceType.Locations != null ? resourceType.Locations.ToArray() : null,
                    ApiVersions = resourceType.ApiVersions != null ? resourceType.ApiVersions.ToArray() : null,
                }).ToArray(),
            };
        }

        public static string ConstructTagsTable(Hashtable tags)
        {
            if (tags == null || tags.Count == 0)
            {
                return null;
            }

            StringBuilder resourcesTable = new StringBuilder();

            var tagsDictionary = TagsConversionHelper.CreateTagDictionary(tags, false);

            int maxNameLength = Math.Max("Name".Length, tagsDictionary.Max(tag => tag.Key.Length));
            int maxValueLength = Math.Max("Value".Length, tagsDictionary.Max(tag => tag.Value.Length));

            string rowFormat = "{0, -" + maxNameLength + "}  {1, -" + maxValueLength + "}\r\n";
            resourcesTable.AppendLine();
            resourcesTable.AppendFormat(rowFormat, "Name", "Value");
            resourcesTable.AppendFormat(rowFormat,
                GeneralUtilities.GenerateSeparator(maxNameLength, "="),
                GeneralUtilities.GenerateSeparator(maxValueLength, "="));

            foreach (var tag in tagsDictionary)
            {
                if (tag.Key.StartsWith(TagsClient.ExecludedTagPrefix))
                {
                    continue;
                }

                resourcesTable.AppendFormat(rowFormat, tag.Key, tag.Value);
            }

            return resourcesTable.ToString();
        }

        private static string ConstructTemplateLinkView(TemplateLink templateLink)
        {
            if (templateLink == null)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();

            result.AppendLine();
            result.AppendLine(string.Format("{0, -15}: {1}", "Uri", templateLink.Uri));
            result.AppendLine(string.Format("{0, -15}: {1}", "ContentVersion", templateLink.ContentVersion));

            return result.ToString();
        }

        public static string ConstructOutputTable(IDictionary<string, object> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }

            var maxNameLength = 18;
            dictionary.Keys.ForEach(k => maxNameLength = Math.Max(maxNameLength, k.Length + 2));

            StringBuilder output = new StringBuilder();
                
                if (dictionary.Count > 0)
                {
                    string rowFormat = "{0, -" + maxNameLength + "}  {1}\r\n";
                    output.AppendLine();
                    output.AppendFormat(rowFormat, "Key", "Value");
                    output.AppendFormat(rowFormat, GeneralUtilities.GenerateSeparator(maxNameLength, "="), GeneralUtilities.GenerateSeparator(maxNameLength, "="));

                    foreach (KeyValuePair<string, object> pair in dictionary)
                    {
                        String val = pair.Value.ToString().Replace("\n", "\n" + GeneralUtilities.GenerateSeparator(maxNameLength, " ") + "  ");
                        output.AppendFormat(rowFormat, pair.Key, val);
                    }
                }

            return output.ToString();
        }
        public static string Indent(this string value, int size)
        {
            string[] lines = value.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();
            foreach (var s in lines)
            {
                sb.Append(new string(' ', size)).Append(s).Append(Environment.NewLine);
            }
            return sb.ToString().TrimEnd();
        }

        public static string ConstructDeploymentVariableTable(Dictionary<string, DeploymentVariable> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }

            var maxNameLength = 15;
            dictionary.Keys.ForEach(k => maxNameLength = Math.Max(maxNameLength, k.Length + 2));

            var maxTypeLength = 25;
            dictionary.Values.ForEach(v => maxTypeLength = Math.Max(maxTypeLength, v.Type.Length + 2));

            StringBuilder result = new StringBuilder();

            if (dictionary.Count > 0)
            {
                string rowFormat = "{0, -" + maxNameLength +"}  {1, -" + maxTypeLength + "}  {2, -10}\r\n";
                result.AppendLine();
                result.AppendFormat(rowFormat, "Name", "Type", "Value");
                result.AppendFormat(rowFormat, GeneralUtilities.GenerateSeparator(maxNameLength, "="), GeneralUtilities.GenerateSeparator(maxTypeLength, "="), GeneralUtilities.GenerateSeparator(10, "="));

                foreach (KeyValuePair<string, DeploymentVariable> pair in dictionary)
                {
                    result.AppendFormat(rowFormat, pair.Key, pair.Value.Type, 
                        JsonConvert.SerializeObject(pair.Value.Value).Indent(maxNameLength + maxTypeLength + 4).Trim());
                }
            }

            return result.ToString();
        }

        private static PSDeployment CreatePSDeployment(
            DeploymentExtended deployment,
            string managementGroupId,
            string resourceGroup)
        {
            PSDeployment deploymentObject = new PSDeployment
            {
                Id = deployment.Id,
                DeploymentName = deployment.Name,
                Location = deployment.Location,
                ManagementGroupId = managementGroupId,
                ResourceGroupName = resourceGroup,
                Tags = deployment.Tags == null ? new Dictionary<string, string>() : new Dictionary<string, string>(deployment.Tags)
            };

            SetDeploymentProperties(deploymentObject, deployment.Properties);

            return deploymentObject;
        }

        private static PSResourceGroupDeployment CreatePSResourceGroupDeployment(
            DeploymentExtended deployment,
            string resourceGroup)
        {
            PSResourceGroupDeployment deploymentObject = new PSResourceGroupDeployment
            {
                DeploymentName = deployment.Name,
                ResourceGroupName = resourceGroup,
                Tags = deployment.Tags == null ? null : new Dictionary<string, string>(deployment.Tags)
            };

            SetDeploymentProperties(deploymentObject, deployment.Properties);

            return deploymentObject;
        }

        private static void SetDeploymentProperties(PSDeploymentObject deploymentObject, DeploymentPropertiesExtended properties)
        {
            if (properties != null)
            {
                deploymentObject.Mode = properties.Mode.Value;
                deploymentObject.ProvisioningState = properties.ProvisioningState;
                deploymentObject.TemplateLink = properties.TemplateLink;
                deploymentObject.Timestamp = properties.Timestamp == null ? default(DateTime) : properties.Timestamp.Value;
                deploymentObject.CorrelationId = properties.CorrelationId;

                if (properties.DebugSetting != null && !string.IsNullOrEmpty(properties.DebugSetting.DetailLevel))
                {
                    deploymentObject.DeploymentDebugLogLevel = properties.DebugSetting.DetailLevel;
                }

                if (properties.Outputs != null)
                {
                    var outputs = properties.Outputs.ToString().FromJson<Dictionary<string, DeploymentVariable>>();
                    // Continue deserialize if the type of Value in DeploymentVariable is array
                    outputs?.Values.ForEach(dv => {
                        if ("Array".Equals(dv?.Type) && dv?.Value != null)
                        {
                            dv.Value = dv.Value.ToString().FromJson<object[]>();
                        }
                    });
                    deploymentObject.Outputs = outputs;
                }

                if (properties.Parameters != null)
                {
                    var parameters = properties.Parameters.ToString().FromJson<Dictionary<string, DeploymentVariable>>();
                    // Continue deserialize if the type of Value in DeploymentVariable is array
                    parameters?.Values.ForEach(dv => {
                        if ("Array".Equals(dv?.Type) && dv?.Value != null)
                        {
                            dv.Value = dv.Value.ToString().FromJson<object[]>();
                        }
                    });
                    deploymentObject.Parameters = parameters;
                }

                if (properties.TemplateLink != null)
                {
                    deploymentObject.TemplateLinkString = ConstructTemplateLinkView(properties.TemplateLink);
                }
            }
        }

        public static PSProviderFeature ToPSProviderFeature(this FeatureResult feature)
        {
            return new PSProviderFeature
            {
                FeatureName = feature.Name.Substring(feature.Name.IndexOf('/') + 1),
                ProviderName = feature.Name.Substring(0, feature.Name.IndexOf('/')),
                RegistrationState = feature.Properties.State,
            };
        }

        public static Hashtable ToHashtable(this object obj)
        {
            return new Hashtable(obj.GetType()
                .GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
                .ToDictionary(p => p.Name, p => p.GetValue(obj, null)));

        }   
    }
}