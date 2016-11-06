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
using System.Reflection;
using System.Text;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Resources.Models
{
    public static class ResourcesExtensions
    {
        public static PSGalleryItem ToPSGalleryItem(this GalleryItem gallery)
        {
            PSGalleryItem psGalleryItem = new PSGalleryItem();
            foreach (PropertyInfo prop in gallery.GetType().GetProperties())
            {
                (typeof(PSGalleryItem)).GetProperty(prop.Name).SetValue(psGalleryItem, prop.GetValue(gallery, null), null);
            }

            return psGalleryItem;
        }

        public static PSResource ToPSResource(this GenericResourceExtended resource, ResourcesClient client, bool minimal)
        {
            ResourceIdentifier identifier = new ResourceIdentifier(resource.Id);
            return new PSResource
            {
                Name = identifier.ResourceName,
                Location = resource.Location,
                ResourceType = identifier.ResourceType,
                ResourceGroupName = identifier.ResourceGroupName,
                ParentResource = identifier.ParentResource,
                Properties = JsonUtilities.DeserializeJson(resource.Properties),
                PropertiesText = resource.Properties,
                Tags = TagsConversionHelper.CreateTagHashtable(resource.Tags),
                Permissions = minimal ? null : client.GetResourcePermissions(identifier),
                ResourceId = identifier.ToString()
            };
        }

        public static PSPermission ToPSPermission(this Permission permission)
        {
            return new PSPermission()
            {
                Actions = new List<string>(permission.Actions),
                NotActions = new List<string>(permission.NotActions)
            };
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

        private static string GetEventDataCaller(Dictionary<string, string> claims)
        {
            string name = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";

            if (claims == null || !claims.ContainsKey(name))
            {
                return null;
            }
            else
            {
                return claims[name];
            }
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

        public static string ConstructPermissionsTable(List<PSPermission> permissions)
        {
            StringBuilder permissionsTable = new StringBuilder();

            if (permissions != null && permissions.Count > 0)
            {
                int maxActionsLength = Math.Max("Actions".Length, permissions.Where(p => p.Actions != null).DefaultIfEmpty(EmptyPermission).Max(p => p.ActionsString.Length));
                int maxNotActionsLength = Math.Max("NotActions".Length, permissions.Where(p => p.NotActions != null).DefaultIfEmpty(EmptyPermission).Max(p => p.NotActionsString.Length));

                string rowFormat = "{0, -" + maxActionsLength + "}  {1, -" + maxNotActionsLength + "}\r\n";
                permissionsTable.AppendLine();
                permissionsTable.AppendFormat(rowFormat, "Actions", "NotActions");
                permissionsTable.AppendFormat(rowFormat,
                    GeneralUtilities.GenerateSeparator(maxActionsLength, "="),
                    GeneralUtilities.GenerateSeparator(maxNotActionsLength, "="));

                foreach (PSPermission permission in permissions)
                {
                    permissionsTable.AppendFormat(rowFormat, permission.ActionsString, permission.NotActionsString);
                }
            }

            return permissionsTable.ToString();
        }
        private static PSPermission EmptyPermission
        {
            get
            {
                return new PSPermission()
                {
                    Actions = new List<string>(),
                    NotActions = new List<string>()
                };
            }
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
                deploymentObject.Mode = properties.Mode;
                deploymentObject.ProvisioningState = properties.ProvisioningState;
                deploymentObject.TemplateLink = properties.TemplateLink;
                deploymentObject.Timestamp = properties.Timestamp;
                deploymentObject.CorrelationId = properties.CorrelationId;

                if (properties.DebugSettingResponse != null && !string.IsNullOrEmpty(properties.DebugSettingResponse.DeploymentDebugDetailLevel))
                {
                    deploymentObject.DeploymentDebugLogLevel = properties.DebugSettingResponse.DeploymentDebugDetailLevel;
                }

                if (!string.IsNullOrEmpty(properties.Outputs))
                {
                    Dictionary<string, DeploymentVariable> outputs = JsonConvert.DeserializeObject<Dictionary<string, DeploymentVariable>>(properties.Outputs);
                    deploymentObject.Outputs = outputs;
                }

                if (!string.IsNullOrEmpty(properties.Parameters))
                {
                    Dictionary<string, DeploymentVariable> parameters = JsonConvert.DeserializeObject<Dictionary<string, DeploymentVariable>>(properties.Parameters);
                    deploymentObject.Parameters = parameters;
                }

                if (properties.TemplateLink != null)
                {
                    deploymentObject.TemplateLinkString = ConstructTemplateLinkView(properties.TemplateLink);
                }
            }

            return deploymentObject;
        }
    }
}