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

using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Resources.Models;
using System.Collections.Generic;
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
    }
}