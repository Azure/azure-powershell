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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// A helper class that handles common tasks that deal with the <see cref="Resource{JToken}"/> class.
    /// </summary>
    internal static class ResourceExtensions
    {
        /// <summary>
        /// Converts a <see cref="Resource{JToken}"/> object into a <see cref="PSObject"/> object.
        /// </summary>
        /// <param name="resource">The <see cref="Resource{JToken}"/> object.</param>
        internal static PSObject ToPsObject(this Resource<JToken> resource)
        {
            var resourceType = string.IsNullOrEmpty(resource.Id)
                ? null
                : ResourceIdUtility.GetResourceType(resource.Id);

            var extensionResourceType = string.IsNullOrEmpty(resource.Id)
                ? null
                : ResourceIdUtility.GetExtensionResourceType(resource.Id);

            var objectDefinition = new Dictionary<string, object>
            {
                { "Name", resource.Name },
                { "ResourceId", string.IsNullOrEmpty(resource.Id) ? null : resource.Id },
                { "ResourceName", string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetResourceName(resource.Id) },
                { "ResourceType", resourceType },
                { "ExtensionResourceName", string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetExtensionResourceName(resource.Id) },
                { "ExtensionResourceType", extensionResourceType },
                { "Kind", resource.Kind },
                { "ResourceGroupName", string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetResourceGroupName(resource.Id) },
                { "Location", resource.Location },
                { "SubscriptionId", string.IsNullOrEmpty(resource.Id) ? null : ResourceIdUtility.GetSubscriptionId(resource.Id) },
                { "Tags", TagsHelper.GetTagsHashtable(resource.Tags) },
                { "Plan", resource.Plan.ToJToken().ToPsObject() },
                { "Properties", ResourceExtensions.GetProperties(resource) },
                { "CreatedTime", resource.CreatedTime },
                { "ChangedTime", resource.ChangedTime },
                { "ETag", resource.ETag },
                { "Sku", resource.Sku.ToJToken().ToPsObject() },
                { "Zones", resource.Zones },
            };

            var resourceTypeName = resourceType == null && extensionResourceType == null
                ? null
                : (resourceType + extensionResourceType).Replace('/', '.');

            var psObject =
                PowerShellUtilities.ConstructPSObject(
                resourceTypeName,
                objectDefinition.Where(kvp => kvp.Value != null).SelectManyArray(kvp => new[] { kvp.Key, kvp.Value }));

            psObject.TypeNames.Add(Constants.MicrosoftAzureResource);
            return psObject;
        }

        /// <summary>
        /// Gets the properties object
        /// </summary>
        /// <param name="resource">The <see cref="Resource{JToken}"/> object.</param>
        private static object GetProperties(Resource<JToken> resource)
        {
            if (resource.Properties == null)
            {
                return null;
            }

            return (object)resource.Properties.ToPsObject();
        }

        /// <summary>
        /// Converts a <see cref="JToken"/> to a <see cref="Resource{JToken}"/>.
        /// </summary>
        /// <param name="jtoken">The <see cref="JToken"/>.</param>
        internal static Resource<JToken> ToResource(this JToken jtoken)
        {
            return jtoken.ToObject<Resource<JToken>>(JsonExtensions.JsonMediaTypeSerializer);
        }

        /// <summary>00
        /// Converts a <see cref="JToken"/> to a <see cref="Resource{JToken}"/>.
        /// </summary>
        /// <typeparam name="TType">The type of the properties.</typeparam>
        /// <param name="jtoken">The <see cref="JToken"/>.</param>
        internal static Resource<TType> ToResource<TType>(this JToken jtoken)
        {
            return jtoken.ToObject<Resource<TType>>(JsonExtensions.JsonMediaTypeSerializer);
        }
    }
}