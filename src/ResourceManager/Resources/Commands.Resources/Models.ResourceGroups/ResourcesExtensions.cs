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
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.Azure.Management.Authorization.Models;

namespace Microsoft.Azure.Commands.Resources.Models
{
    public static class ResourcesExtensions
    {
        public static PSResourceGroup ToPSResourceGroup(this ResourceGroupExtended resourceGroup, ResourcesClient client, bool detailed)
        {
            var result = new PSResourceGroup
            {
                ResourceGroupName = resourceGroup.Name,
                Location = resourceGroup.Location,
                ProvisioningState = resourceGroup.ProvisioningState,
                Tags = TagsConversionHelper.CreateTagHashtable(resourceGroup.Tags),
                ResourceId = resourceGroup.Id
            };

            if (detailed)
            {
                result.Resources = client.FilterResources(new FilterResourcesOptions { ResourceGroup = resourceGroup.Name })
                    .Select(r => r.ToPSResource(client, true)).ToList();
            }

            return result;
        }

        public static PSResourceGroupDeployment ToPSResourceGroupDeployment(this DeploymentGetResult result, string resourceGroup)
        {
            PSResourceGroupDeployment deployment = new PSResourceGroupDeployment();

            if (result != null)
            {
                deployment = CreatePSResourceGroupDeployment(result.Deployment.Name, resourceGroup, result.Deployment.Properties);
            }

            return deployment;
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

        public static PSResourceManagerError ToPSResourceManagerError(this ResourceManagementError error)
        {
            return new PSResourceManagerError
                {
                    Code = error.Code,
                    Message = error.Message
                };
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

        public static PSResourceProvider ToPSResourceProvider(this Provider provider)
        {
            return new PSResourceProvider
            {
                ProviderNamespace = provider.Namespace,
                RegistrationState = provider.RegistrationState,
                ResourceTypes =
                    provider.ResourceTypes.Select(
                        resourceType =>
                            new PSResourceProviderResourceType
                            {
                                ResourceTypeName = resourceType.Name,
                                Locations = resourceType.Locations.ToArray(),
                                ApiVersions = resourceType.ApiVersions.ToArray(),
                            }).ToArray(),
            };
        }

        public static PSResourceProviderOperation ToPSResourceProviderOperation(this ResourceProviderOperationDefinition resourceProviderOperationDefinition)
        {
            return new PSResourceProviderOperation
            {
                OperationName = resourceProviderOperationDefinition.Name,
                Description = resourceProviderOperationDefinition.ResourceProviderOperationDisplayProperties.Description,
                ProviderNamespace = resourceProviderOperationDefinition.ResourceProviderOperationDisplayProperties.Provider,
                ResourceName = resourceProviderOperationDefinition.ResourceProviderOperationDisplayProperties.Resource
            };
        }

        public static PSResourceProviderLocationInfo ToPSResourceProviderLocationInfo(this ProviderResourceType resourceType, string providerNamespace)
        {
            PSResourceProviderLocationInfo result = new PSResourceProviderLocationInfo();
            if (resourceType != null)
            {
                resourceType.Locations = resourceType.Locations ?? new List<string>();
                for (int i = 0; i < ResourcesClient.KnownLocationsNormalized.Count; i++)
                {
                    if (resourceType.Locations.Remove(ResourcesClient.KnownLocationsNormalized[i]))
                    {
                        resourceType.Locations.Add(ResourcesClient.KnownLocations[i]);
                    }
                }

                result.Name = string.IsNullOrEmpty(providerNamespace) ? resourceType.Name : string.Join("/", providerNamespace, resourceType.Name);
                result.Locations = resourceType.Locations.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();
                result.LocationsString = string.Join(", ", result.Locations);
            }

            return result;
        }

        public static PSGalleryItem ToPSGalleryItem(this GalleryItem gallery)
        {
            PSGalleryItem psGalleryItem = new PSGalleryItem();
            foreach (PropertyInfo prop in gallery.GetType().GetProperties())
            {
                (typeof(PSGalleryItem)).GetProperty(prop.Name).SetValue(psGalleryItem, prop.GetValue(gallery, null), null);
            }

            return psGalleryItem;
        }

        // TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
        //public static PSDeploymentEventData ToPSDeploymentEventData(this EventData eventData)
        //{
        //    if (eventData == null)
        //    {
        //        return null;
        //    }
        //    PSDeploymentEventData psObject = new PSDeploymentEventData
        //        {
        //            Authorization = eventData.Authorization.ToPSDeploymentEventDataAuthorization(),
        //            ResourceUri = eventData.ResourceUri,
        //            SubscriptionId = eventData.SubscriptionId,
        //            EventId = eventData.EventDataId,
        //            EventName = eventData.EventName.LocalizedValue,
        //            EventSource = eventData.EventSource.LocalizedValue,
        //            Channels = eventData.EventChannels.ToString(),
        //            Level = eventData.Level.ToString(),
        //            Description = eventData.Description,
        //            Timestamp = eventData.EventTimestamp,
        //            OperationId = eventData.OperationId,
        //            OperationName = eventData.OperationName.LocalizedValue,
        //            Status = eventData.Status.LocalizedValue,
        //            SubStatus = eventData.SubStatus.LocalizedValue,
        //            Caller = GetEventDataCaller(eventData.Claims),
        //            CorrelationId = eventData.CorrelationId,
        //            ResourceGroupName = eventData.ResourceGroupName,
        //            ResourceProvider = eventData.ResourceProviderName.LocalizedValue,
        //            HttpRequest = eventData.HttpRequest.ToPSDeploymentEventDataHttpRequest(),
        //            Claims = eventData.Claims,
        //            Properties = eventData.Properties
        //        };
        //    return psObject;
        //}

        // TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
        //public static PSDeploymentEventDataHttpRequest ToPSDeploymentEventDataHttpRequest(this HttpRequestInfo httpRequest)
        //{
        //    if (httpRequest == null)
        //    {
        //        return null;
        //    }
        //    PSDeploymentEventDataHttpRequest psObject = new PSDeploymentEventDataHttpRequest
        //    {
        //        ClientId = httpRequest.ClientRequestId,
        //        Method = httpRequest.Method,
        //        Url = httpRequest.Uri,
        //        ClientIpAddress = httpRequest.ClientIpAddress
        //    };
        //    return psObject;
        //}

        // TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
        //public static PSDeploymentEventDataAuthorization ToPSDeploymentEventDataAuthorization(this SenderAuthorization authorization)
        //{
        //    if (authorization == null)
        //    {
        //        return null;
        //    }
        //    PSDeploymentEventDataAuthorization psObject = new PSDeploymentEventDataAuthorization
        //    {
        //        Action = authorization.Action,
        //        Role = authorization.Role,
        //        Scope = authorization.Scope,
        //        Condition = authorization.Condition
        //    };
        //    return psObject;
        //}

        public static string ConstructResourcesTable(List<PSResource> resources)
        {
            StringBuilder resourcesTable = new StringBuilder();

            if (resources != null && resources.Count > 0)
            {
                int maxNameLength = Math.Max("Name".Length, resources.Where(r => r.Name != null).DefaultIfEmpty(EmptyResource).Max(r => r.Name.Length));
                int maxTypeLength = Math.Max("Type".Length, resources.Where(r => r.ResourceType != null).DefaultIfEmpty(EmptyResource).Max(r => r.ResourceType.Length));
                int maxLocationLength = Math.Max("Location".Length, resources.Where(r => r.Location != null).DefaultIfEmpty(EmptyResource).Max(r => r.Location.Length));

                string rowFormat = "{0, -" + maxNameLength + "}  {1, -" + maxTypeLength + "}  {2, -" + maxLocationLength + "}\r\n";
                resourcesTable.AppendLine();
                resourcesTable.AppendFormat(rowFormat, "Name", "Type", "Location");
                resourcesTable.AppendFormat(rowFormat, 
                    GeneralUtilities.GenerateSeparator(maxNameLength, "="),
                    GeneralUtilities.GenerateSeparator(maxTypeLength, "="),
                    GeneralUtilities.GenerateSeparator(maxLocationLength, "="));

                foreach (PSResource resource in resources)
                {
                    resourcesTable.AppendFormat(rowFormat, resource.Name, resource.ResourceType, resource.Location);
                }
            }

            return resourcesTable.ToString();
        }

        public static string ConstructTagsTable(Hashtable[] tags)
        {
            if (tags == null)
            {
                return null;
            }

            Hashtable emptyHashtable = new Hashtable
                {
                    {"Name", string.Empty},
                    {"Value", string.Empty}
                };
            StringBuilder resourcesTable = new StringBuilder();

            if (tags.Length > 0)
            {
                int maxNameLength = Math.Max("Name".Length, tags.Where(ht => ht.ContainsKey("Name")).DefaultIfEmpty(emptyHashtable).Max(ht => ht["Name"].ToString().Length));
                int maxValueLength = Math.Max("Value".Length, tags.Where(ht => ht.ContainsKey("Value")).DefaultIfEmpty(emptyHashtable).Max(ht => ht["Value"].ToString().Length));

                string rowFormat = "{0, -" + maxNameLength + "}  {1, -" + maxValueLength + "}\r\n";
                resourcesTable.AppendLine();
                resourcesTable.AppendFormat(rowFormat, "Name", "Value");
                resourcesTable.AppendFormat(rowFormat,
                    GeneralUtilities.GenerateSeparator(maxNameLength, "="),
                    GeneralUtilities.GenerateSeparator(maxValueLength, "="));

                foreach (Hashtable tag in tags)
                {
                    PSTagValuePair tagValuePair = TagsConversionHelper.Create(tag);
                    if (tagValuePair != null)
                    {
                        if (tagValuePair.Name.StartsWith(TagsClient.ExecludedTagPrefix))
                        {
                            continue;
                        }

                        if (tagValuePair.Value == null)
                        {
                            tagValuePair.Value = string.Empty;
                        }
                        resourcesTable.AppendFormat(rowFormat, tagValuePair.Name, tagValuePair.Value);
                    }
                }
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
                deploymentObject.Mode = properties.Mode;
                deploymentObject.ProvisioningState = properties.ProvisioningState;
                deploymentObject.TemplateLink = properties.TemplateLink;
                deploymentObject.Timestamp = properties.Timestamp;
                deploymentObject.CorrelationId = properties.CorrelationId;

                if(properties.DebugSettingResponse != null && !string.IsNullOrEmpty(properties.DebugSettingResponse.DeploymentDebugDetailLevel))
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

        private static PSResource EmptyResource
        {
            get
            {
                return new PSResource
                {
                    Name = string.Empty,
                    Location = string.Empty,
                    ParentResource = string.Empty,
                    PropertiesText = string.Empty,
                    ResourceGroupName = string.Empty,
                    Properties = new Dictionary<string, string>(),
                    ResourceType = string.Empty,
                    ResourceId = string.Empty
                };
            }
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

        public static PSPermission ToPSPermission(this Permission permission)
        {
            return new PSPermission()
            {
                Actions = new List<string>(permission.Actions),
                NotActions = new List<string>(permission.NotActions)
            };
        }
    }
}