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

using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

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

        public static string ConstructTagsTable(Hashtable[] tags)
        {
            //if (tags == null)
            //{
            //    return null;
            //}

            //Hashtable emptyHashtable = new Hashtable
            //    {
            //        {"Name", string.Empty},
            //        {"Value", string.Empty}
            //    };
            //StringBuilder resourcesTable = new StringBuilder();

            //if (tags.Length > 0)
            //{
            //    int maxNameLength = Math.Max("Name".Length, tags.Where(ht => ht.ContainsKey("Name")).DefaultIfEmpty(emptyHashtable).Max(ht => ht["Name"].ToString().Length));
            //    int maxValueLength = Math.Max("Value".Length, tags.Where(ht => ht.ContainsKey("Value")).DefaultIfEmpty(emptyHashtable).Max(ht => ht["Value"].ToString().Length));

            //    string rowFormat = "{0, -" + maxNameLength + "}  {1, -" + maxValueLength + "}\r\n";
            //    resourcesTable.AppendLine();
            //    resourcesTable.AppendFormat(rowFormat, "Name", "Value");
            //    resourcesTable.AppendFormat(rowFormat,
            //        GeneralUtilities.GenerateSeparator(maxNameLength, "="),
            //        GeneralUtilities.GenerateSeparator(maxValueLength, "="));

            //    foreach (Hashtable tag in tags)
            //    {
            //        PSTagValuePair tagValuePair = TagsConversionHelper.Create(tag);
            //        if (tagValuePair != null)
            //        {
            //            if (tagValuePair.Name.StartsWith(TagsClient.ExecludedTagPrefix))
            //            {
            //                continue;
            //            }

            //            if (tagValuePair.Value == null)
            //            {
            //                tagValuePair.Value = string.Empty;
            //            }
            //            resourcesTable.AppendFormat(rowFormat, tagValuePair.Name, tagValuePair.Value);
            //        }
            //    }
            //}

            //return resourcesTable.ToString();
            return null;
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

    }
}