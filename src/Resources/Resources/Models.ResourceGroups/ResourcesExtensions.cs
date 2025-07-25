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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using AuthorizationPermission = Microsoft.Azure.Management.Authorization.Models.Permission;

// TODO: Remove IfDef code
#if !NETSTANDARD
using Microsoft.Azure.Commands.Resources.Models.Gallery;
#endif

namespace Microsoft.Azure.Commands.Resources.Models
{
    public static class ResourcesExtensions
    {
// TODO: Remove IfDef code
#if !NETSTANDARD
        public static PSGalleryItem ToPSGalleryItem(this GalleryItem gallery)
        {
            PSGalleryItem psGalleryItem = new PSGalleryItem();
            foreach (PropertyInfo prop in gallery.GetType().GetProperties())
            {
                (typeof(PSGalleryItem)).GetProperty(prop.Name).SetValue(psGalleryItem, prop.GetValue(gallery, null), null);
            }

            return psGalleryItem;
        }
#endif

        public static PSResource ToPSResource(this GenericResource resource, ResourcesClient client, bool minimal)
        {
            var identifier = new ResourceIdentifier(resource.Id);
            return new PSResource
            {
                Name = identifier.ResourceName,
                Location = resource.Location,
                ResourceType = identifier.ResourceType,
                ResourceGroupName = identifier.ResourceGroupName,
                ParentResource = identifier.ParentResource,
                Properties = JsonUtilities.DeserializeJson(resource.Properties?.ToString()),
                PropertiesText = resource.Properties?.ToString(),
                Tags = TagsConversionHelper.CreateTagHashtable(resource.Tags),
                Permissions = minimal ? null : client.GetResourcePermissions(identifier),
                ResourceId = identifier.ToString()
            };
        }

        public static PSPermission ToPSPermission(this AuthorizationPermission permission)
        {
            return new PSPermission
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

            var result = new StringBuilder();

            result.AppendLine();
            result.AppendLine(string.Format("{0, -15}: {1}", "Uri", templateLink.Uri));
            result.AppendLine(string.Format("{0, -15}: {1}", "ContentVersion", templateLink.ContentVersion));

            return result.ToString();
        }

        private static string GetEventDataCaller(Dictionary<string, string> claims)
        {
            const string name = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";

            if (claims == null || !claims.ContainsKey(name))
            {
                return null;
            }

            return claims[name];
        }

        public static string ConstructDeploymentVariableTable(Dictionary<string, DeploymentVariable> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }
            
            if (dictionary.Count <= 0) return string.Empty;

            const string rowFormat = "{0, -15}  {1, -25}  {2, -10}\r\n";

            var result = new StringBuilder();
            result.AppendLine();
            result.AppendFormat(rowFormat, "Name", "Type", "Value");
            result.AppendFormat(rowFormat, GeneralUtilities.GenerateSeparator(15, "="), GeneralUtilities.GenerateSeparator(25, "="), GeneralUtilities.GenerateSeparator(10, "="));

            foreach (var pair in dictionary)
            {
                result.AppendFormat(rowFormat, pair.Key, pair.Value.Type, pair.Value.Value);
            }

            return result.ToString();

        }

        public static string ConstructTagsTable(Hashtable tags)
        {
            if (tags == null || tags.Count == 0)
            {
                return null;
            }

            var resourcesTable = new StringBuilder();

            var tagsDictionary = TagsConversionHelper.CreateTagDictionary(tags, false);

            var maxNameLength = Math.Max("Name".Length, tagsDictionary.Max(tag => tag.Key.Length));
            var maxValueLength = Math.Max("Value".Length, tagsDictionary.Max(tag => tag.Value.Length));

            var rowFormat = "{0, -" + maxNameLength + "}  {1, -" + maxValueLength + "}\r\n";
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
            var permissionsTable = new StringBuilder();
            if (permissions != null && permissions.Count > 0)
            {
                var maxActionsLength = Math.Max("Actions".Length, permissions.Where(p => p.Actions != null).DefaultIfEmpty(EmptyPermission).Max(p => p.ActionsString.Length));
                var maxNotActionsLength = Math.Max("NotActions".Length, permissions.Where(p => p.NotActions != null).DefaultIfEmpty(EmptyPermission).Max(p => p.NotActionsString.Length));

                var rowFormat = "{0, -" + maxActionsLength + "}  {1, -" + maxNotActionsLength + "}\r\n";
                permissionsTable.AppendLine();
                permissionsTable.AppendFormat(rowFormat, "Actions", "NotActions");
                permissionsTable.AppendFormat(rowFormat,
                GeneralUtilities.GenerateSeparator(maxActionsLength, "="),
                GeneralUtilities.GenerateSeparator(maxNotActionsLength, "="));

                foreach (var permission in permissions)
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
                return new PSPermission
                {
                    Actions = new List<string>(),
                    NotActions = new List<string>()
                };
            }
        }

        public static PSResourceGroupDeployment ToPSResourceGroupDeployment(this DeploymentExtended result, string resourceGroup)
        {
            var deployment = new PSResourceGroupDeployment();

            if (result != null)
            {
                deployment = CreatePSResourceGroupDeployment(result.Name, resourceGroup, result.Properties);
            }

            return deployment;
        }

        private static PSResourceGroupDeployment CreatePSResourceGroupDeployment(
            string name,
            string resourceGroup,
            DeploymentPropertiesExtended properties)
        {
            var deploymentObject = new PSResourceGroupDeployment
            {
                DeploymentName = name, ResourceGroupName = resourceGroup
            };
            if (properties == null) return deploymentObject;

            deploymentObject.Mode = properties.Mode();
            deploymentObject.Timestamp = properties.Timestamp();
            deploymentObject.ProvisioningState = properties.ProvisioningState;
            deploymentObject.TemplateLink = properties.TemplateLink;
            deploymentObject.CorrelationId = properties.CorrelationId;
            deploymentObject.OnErrorDeployment = properties.OnErrorDeployment;

            if (properties.DebugSetting() != null && !string.IsNullOrEmpty(properties.DebugSetting().DetailLevel()))
            {
                deploymentObject.DeploymentDebugLogLevel = properties.DebugSetting().DetailLevel();
            }

            if (properties.Outputs != null && !string.IsNullOrEmpty(properties.Outputs.ToString()))
            {
                var outputs = properties.Outputs.ToString().FromJson<Dictionary<string, DeploymentVariable>>();
                deploymentObject.Outputs = outputs;
            }

            if (properties.Parameters != null && !string.IsNullOrEmpty(properties.Parameters.ToString()))
            {
                var parameters = properties.Parameters.ToString().FromJson<Dictionary<string, DeploymentVariable>>();
                deploymentObject.Parameters = parameters;
            }

            if (properties.TemplateLink != null)
            {
                deploymentObject.TemplateLinkString = ConstructTemplateLinkView(properties.TemplateLink);
            }

            return deploymentObject;
        }
    }
}