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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkExtensions
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
                ResourceId = resourceGroup.Id
            };

            return result;
        }

        public static PSResourceGroupDeployment ToPSResourceGroupDeployment(this DeploymentExtended result, string resourceGroup)
        {
            PSResourceGroupDeployment deployment = new PSResourceGroupDeployment();

            if (result != null)
            {
                deployment = CreatePSResourceGroupDeployment(result.Name, resourceGroup, result.Properties);
            }

            return deployment;
        }


        public static PSResourceManagerError ToPSResourceManagerError(this ResourceManagementErrorWithDetails error)
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

        public static PSResourceProvider ToPSResourceProvider(this Provider provider)
        {
            return new PSResourceProvider
            {
                ProviderNamespace = provider.NamespaceProperty,
                RegistrationState = provider.RegistrationState,
                ResourceTypes =
                    provider.ResourceTypes.Select(
                        resourceType =>
                            new PSResourceProviderResourceType
                            {
                                ResourceTypeName = resourceType.ResourceType,
                                Locations = resourceType.Locations != null ? resourceType.Locations.ToArray() : null,
                                ApiVersions = resourceType.ApiVersions != null ? resourceType.ApiVersions.ToArray() : null,
                                ZoneMappings = ResourcesExtensions.BuildZoneMappings(resourceType.ZoneMappings)
                            }).ToArray(),
            };
        }

        public static Hashtable BuildZoneMappings(IList<ZoneMappingType> zoneMappings)
        {
            if (zoneMappings == null)
            {
                return null;
            }

            Hashtable zonesHash = new Hashtable();
            foreach (var zoneMapping in zoneMappings)
            {
                zonesHash[zoneMapping.Location] = zoneMapping.Zones.ToArray();
            }

            return zonesHash;
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

        public static string ConstructDeploymentVariableTable(Dictionary<string, DeploymentVariable> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }

            StringBuilder result = new StringBuilder();

            if (dictionary.Count > 0)
            {
                string rowFormat = "{0, -15}  {1, -25}  {2, -10}\r\n";
                result.AppendLine();
                result.AppendFormat(rowFormat, "Name", "Type", "Value");
                result.AppendFormat(rowFormat, GeneralUtilities.GenerateSeparator(15, "="), GeneralUtilities.GenerateSeparator(25, "="), GeneralUtilities.GenerateSeparator(10, "="));

                foreach (KeyValuePair<string, DeploymentVariable> pair in dictionary)
                {
                    result.AppendFormat(rowFormat, pair.Key, pair.Value.Type, pair.Value.Value);
                }
            }

            return result.ToString();

        }

        private static PSResourceGroupDeployment CreatePSResourceGroupDeployment(
            string name,
            string gesourceGroup,
            DeploymentPropertiesExtended properties)
        {
            PSResourceGroupDeployment deploymentObject = new PSResourceGroupDeployment();

            deploymentObject.DeploymentName = name;
            deploymentObject.ResourceGroupName = gesourceGroup;

            if (properties != null)
            {
                deploymentObject.Mode = properties.Mode.Value;
                deploymentObject.ProvisioningState = properties.ProvisioningState;
                deploymentObject.TemplateLink = properties.TemplateLink;
                deploymentObject.Timestamp = properties.Timestamp == null ? default(DateTime) : properties.Timestamp.Value;
                deploymentObject.CorrelationId = properties.CorrelationId;

                if(properties.DebugSetting != null && !string.IsNullOrEmpty(properties.DebugSetting.DetailLevel))
                {
                    deploymentObject.DeploymentDebugLogLevel = properties.DebugSetting.DetailLevel;
                }

                if (properties.Outputs != null)
                {
                    Dictionary<string, DeploymentVariable> outputs = JsonConvert.DeserializeObject<Dictionary<string, DeploymentVariable>>(properties.Outputs.ToString());
                    deploymentObject.Outputs = outputs;
                }

                if (properties.Parameters != null)
                {
                    Dictionary<string, DeploymentVariable> parameters = JsonConvert.DeserializeObject<Dictionary<string, DeploymentVariable>>(properties.Parameters.ToString());
                    deploymentObject.Parameters = parameters;
                }

                if (properties.TemplateLink != null)
                {
                    deploymentObject.TemplateLinkString = ConstructTemplateLinkView(properties.TemplateLink);
                }
            }

            return deploymentObject;
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
    }
}