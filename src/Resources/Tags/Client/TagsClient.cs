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
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Tags.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Rest.Azure;
using SDKTagsObject = Microsoft.Azure.Management.Resources.Models.Tags;

namespace Microsoft.Azure.Commands.Tags.Client
{
    public class TagsClient
    {
        public const string ExecludedTagPrefix = "hidden-related:/";

        private const string ProviderErrorCode = "ProviderError";

        private const string ProvidersSegment = "providers";

        private const string PreviewApiVersionSuffix = "preview";

        private const string TagsResourceName = "default";

        private const string TagsResourceType = "Microsoft.Resources/tags";

        private const string TagsResourceIdSuffix = "/providers/Microsoft.Resources/tags/default";

        public IResourceManagementClient ResourceManagementClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        /// <summary>
        /// Creates new tags client instance.
        /// </summary>
        /// <param name="context">The Azure context instance</param>
        public TagsClient(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {

        }

        /// <summary>
        /// Creates new TagsClient instance
        /// </summary>
        /// <param name="resourceManagementClient">The IResourceManagementClient instance</param>
        public TagsClient(IResourceManagementClient resourceManagementClient)
        {
            ResourceManagementClient = resourceManagementClient;
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public TagsClient()
        {

        }

        public List<PSTag> ListTags()
        {
            var result = new List<TagDetails>();
            var pageOfTags = ResourceManagementClient.Tags.List();
            AddOrMergeTags(result, pageOfTags);
            while (!string.IsNullOrEmpty(pageOfTags.NextPageLink))
            {
                pageOfTags = ResourceManagementClient.Tags.ListNext(pageOfTags.NextPageLink);
                AddOrMergeTags(result, pageOfTags);
            }
            return new List<PSTag>(result.Select(t => t.ToPSTag()));
        }

        private void AddOrMergeTags(List<TagDetails> results, IEnumerable<TagDetails> tags)
        {
            tags.Where(t => !t.TagName.StartsWith(ExecludedTagPrefix)).ForEach(t =>
            {
                var tagNameFound = results.FirstOrDefault(pst => pst.TagName.Equals(t.TagName, StringComparison.OrdinalIgnoreCase));
                if (tagNameFound != null)
                {
                    // tag name already in previous page, merge instead of add
                    tagNameFound.Values = new List<TagValue>(tagNameFound.Values.Concat(t.Values));
                }
                else
                {
                    results.Add(t);
                }
            });
        }

        public PSTag GetTag(string tag)
        {
            List<PSTag> tags = ListTags();
            if (!tags.Exists(t => t.Name.Equals(tag, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception(string.Format(Resources.TagNotFoundMessage, tag));
            }

            return tags.First(t => t.Name.Equals(tag, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Gets the entire set of tags on a resource or subscription.
        /// </summary>
        /// <param name="scope">scope could be a resource or subscription</param>
        /// <returns>PS object PSTagResource</returns>
        public PSTagResource GetTagAtScope(string scope)
        {
            var res = ResourceManagementClient.Tags.GetAtScope(scope);
            return res?.ToPSTagResource();
        }

        /// <summary>
        /// Creates a tag and if the tag name exists add the value to the existing tag name.
        /// </summary>
        /// <param name="tag">The tag name</param>
        /// <param name="values">The tag values</param>
        /// <returns>The tag object</returns>
        public PSTag CreateTag(string tag, List<string> values)
        {
            ResourceManagementClient.Tags.CreateOrUpdate(tag);

            if (values != null)
            {
                values.ForEach(v => ResourceManagementClient.Tags.CreateOrUpdateValue(tag, v));
            }

            return GetTag(tag);
        }

        /// <summary>
        /// Creates or updates the entire set of tags on a resource or subscription.
        /// </summary>
        /// <remarks>
        /// This operation allows adding or replacing the entire set of tags on the
        /// specified resource or subscription. The specified entity can have a maximum
        /// of 50 tags.
        /// </remarks>
        /// <param name="scope">scope could be a resource or subscription</param>
        /// <param name="parameters">dictionary of tags need to be created or updated</param>
        /// <returns>PS object PSTagResource</returns>
        public PSTagResource CreateOrUpdateTagAtScope(string scope, IDictionary<string, string> parameters)
        {
            var tagResource = new TagsResource(properties: new SDKTagsObject(parameters));
            try
            {
                return ResourceManagementClient.Tags.CreateOrUpdateAtScope(scope: scope, parameters: tagResource)?.ToPSTagResource();
            }
            catch (CloudException ex) when (IsResourceProviderTagError(ex, scope))
            {
                return SetTagsOnResource(scope, parameters, ex);
            }
        }

        /// <summary>
        /// Selectively updates the set of tags on a resource or subscription.
        /// </summary>
        /// <remarks>
        /// This operation allows replacing, merging or selectively deleting tags on
        /// the specified resource or subscription. The specified entity can have a
        /// maximum of 50 tags at the end of the operation. The 'replace' option
        /// replaces the entire set of existing tags with a new set. The 'merge' option
        /// allows adding tags with new names and updating the values of tags with
        /// existing names. The 'delete' option allows selectively deleting tags based
        /// on given names or name/value pairs.
        /// </remarks>
        /// <param name="scope"></param>
        /// <param name="operation"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public PSTagResource UpdateTagAtScope(string scope, TagPatchOperation operation, IDictionary<string, string> parameters)
        {
            var tagPatchResource = new TagsPatchResource(operation: operation.ToString(), properties: new SDKTagsObject(parameters));
            try
            {
                return ResourceManagementClient.Tags.UpdateAtScope(scope: scope, parameters: tagPatchResource)?.ToPSTagResource();
            }
            catch (CloudException ex) when (IsResourceProviderTagError(ex, scope))
            {
                return SetTagsOnResource(scope, ApplyTagPatchOperation(GetTagsOnScope(scope), operation, parameters), ex);
            }
        }

        /// <summary>
        /// Deletes the entire tag or specific tag value.
        /// </summary>
        /// <param name="tag">The tag name</param>
        /// <param name="values">Values to remove</param>
        /// <returns></returns>
        public PSTag DeleteTag(string tag, List<string> values)
        {
            PSTag tagObject = null;


            if (values == null || values.Count != 1)
            {
                tagObject = GetTag(tag);
                if (int.Parse(tagObject.Count) > 0)
                {
                    throw new Exception(Resources.CanNotDeleteTag);
                }
            }

            if (values == null || values.Count == 0)
            {
                tagObject = GetTag(tag);
                tagObject.Values.ForEach(v => ResourceManagementClient.Tags.DeleteValue(tag, v.Name));
                ResourceManagementClient.Tags.Delete(tag);
            }
            else
            {
                values.ForEach(v => ResourceManagementClient.Tags.DeleteValue(tag, v));
                tagObject = GetTag(tag);
            }

            return tagObject;
        }

        /// <summary>
        /// Deletes the entire set of tags on a resource or subscription.
        /// </summary>
        /// <param name="scope">scope could be a resource or subscription</param>
        /// <returns>PS object PSTagResource user wants to delete</returns>
        public PSTagResource DeleteTagAtScope(string scope)
        {
            var tags = GetTagAtScope(scope);
            try
            {
                ResourceManagementClient.Tags.DeleteAtScope(scope);
            }
            catch (CloudException ex) when (IsResourceProviderTagError(ex, scope))
            {
                SetTagsOnResource(scope, new Dictionary<string, string>(), ex);
            }

            return tags;
        }

        /// <summary>
        /// Determines whether a failure of the tags endpoint was caused by the resource provider rejecting
        /// the resource payload that Azure Resource Manager replays while applying the tags.
        /// </summary>
        /// <remarks>
        /// When tags are applied through the Microsoft.Resources/tags/default endpoint, Azure Resource Manager
        /// reads the target resource and writes it back to the resource provider with the new tags. Resources
        /// holding a value that their resource provider no longer accepts on write (for example a Service Bus
        /// namespace with a minimumTlsVersion of 1.3) therefore fail with a ProviderError even though only the
        /// tags were meant to be changed. In that case the tags can still be applied by patching the resource
        /// with the tags alone.
        /// </remarks>
        /// <param name="exception">The exception thrown by the tags endpoint</param>
        /// <param name="scope">scope could be a resource, a resource group or a subscription</param>
        /// <returns>True when the tag operation can be retried as a tags only patch of the resource</returns>
        private static bool IsResourceProviderTagError(CloudException exception, string scope)
        {
            return ProviderErrorCode.Equals(exception?.Body?.Code, StringComparison.OrdinalIgnoreCase)
                && TryGetResourceType(scope, out _, out _);
        }

        /// <summary>
        /// Applies the given set of tags to a resource by patching the resource with the tags only.
        /// </summary>
        /// <param name="scope">The resource identifier of the resource to tag</param>
        /// <param name="tags">The complete set of tags the resource should end up with</param>
        /// <param name="originalException">The exception originally thrown by the tags endpoint</param>
        /// <returns>PS object PSTagResource</returns>
        private PSTagResource SetTagsOnResource(string scope, IDictionary<string, string> tags, CloudException originalException)
        {
            try
            {
                var apiVersion = GetApiVersionForResource(scope);
                if (string.IsNullOrWhiteSpace(apiVersion))
                {
                    throw originalException;
                }

                var resource = ResourceManagementClient.Resources.UpdateById(
                    resourceId: scope,
                    apiVersion: apiVersion,
                    parameters: new GenericResource { Tags = tags });

                return new PSTagResource
                {
                    Id = scope + TagsResourceIdSuffix,
                    Name = TagsResourceName,
                    Type = TagsResourceType,
                    Properties = new PSTagsObject(resource?.Tags),
                    PropertiesTable = global::Microsoft.Azure.Management.Internal.Resources.Utilities.ResourcesExtensions.ConstructTagsTable(TagsConversionHelper.CreateTagHashtable(resource?.Tags))
                };
            }
            catch (Exception)
            {
                // The resource could not be patched either, surface the error the tags endpoint returned.
                throw originalException;
            }
        }

        /// <summary>
        /// Gets the tags currently set on the given scope.
        /// </summary>
        /// <param name="scope">scope could be a resource, a resource group or a subscription</param>
        /// <returns>The current set of tags, never null</returns>
        private IDictionary<string, string> GetTagsOnScope(string scope)
        {
            return ResourceManagementClient.Tags.GetAtScope(scope)?.Properties?.TagsProperty
                ?? new Dictionary<string, string>();
        }

        /// <summary>
        /// Computes the set of tags resulting from applying a patch operation to the existing set of tags.
        /// </summary>
        /// <param name="existingTags">The tags currently set on the scope</param>
        /// <param name="operation">The patch operation to apply</param>
        /// <param name="parameters">The tags given to the patch operation</param>
        /// <returns>The resulting set of tags</returns>
        private static IDictionary<string, string> ApplyTagPatchOperation(IDictionary<string, string> existingTags, TagPatchOperation operation, IDictionary<string, string> parameters)
        {
            if (operation == TagPatchOperation.Replace)
            {
                return parameters ?? new Dictionary<string, string>();
            }

            // Tag names are case insensitive in Azure, tag values are not.
            var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (existingTags != null)
            {
                foreach (var tag in existingTags)
                {
                    result[tag.Key] = tag.Value;
                }
            }

            if (parameters != null)
            {
                foreach (var tag in parameters)
                {
                    if (operation == TagPatchOperation.Delete)
                    {
                        // A tag is only removed when its value matches the one given to the delete operation.
                        if (result.TryGetValue(tag.Key, out var existingValue) && string.Equals(existingValue, tag.Value, StringComparison.Ordinal))
                        {
                            result.Remove(tag.Key);
                        }
                    }
                    else
                    {
                        result[tag.Key] = tag.Value;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Determines the API version to use when patching the given resource.
        /// </summary>
        /// <param name="resourceId">The resource identifier of the resource</param>
        /// <returns>The default API version of the resource type, otherwise its latest API version, null when it cannot be determined</returns>
        private string GetApiVersionForResource(string resourceId)
        {
            if (!TryGetResourceType(resourceId, out var providerNamespace, out var resourceType))
            {
                return null;
            }

            var providerResourceType = ResourceManagementClient.Providers.Get(providerNamespace)?.ResourceTypes?
                .FirstOrDefault(rt => string.Equals(rt.ResourceType, resourceType, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(providerResourceType?.DefaultApiVersion))
            {
                return providerResourceType.DefaultApiVersion;
            }

            var apiVersions = providerResourceType?.ApiVersions?.Where(v => !string.IsNullOrWhiteSpace(v)).ToList()
                ?? new List<string>();

            return apiVersions.Where(v => v.IndexOf(PreviewApiVersionSuffix, StringComparison.OrdinalIgnoreCase) < 0)
                    .OrderByDescending(v => v, StringComparer.OrdinalIgnoreCase)
                    .FirstOrDefault()
                ?? apiVersions.OrderByDescending(v => v, StringComparer.OrdinalIgnoreCase).FirstOrDefault();
        }

        /// <summary>
        /// Extracts the provider namespace and the resource type from a resource identifier.
        /// </summary>
        /// <param name="resourceId">The resource identifier</param>
        /// <param name="providerNamespace">The provider namespace of the resource</param>
        /// <param name="resourceType">The fully qualified resource type of the resource, without the provider namespace</param>
        /// <returns>True when the identifier points at a resource, false for subscription and resource group scopes</returns>
        private static bool TryGetResourceType(string resourceId, out string providerNamespace, out string resourceType)
        {
            providerNamespace = null;
            resourceType = null;

            if (string.IsNullOrWhiteSpace(resourceId))
            {
                return false;
            }

            var segments = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var providersIndex = Array.FindLastIndex(segments, s => string.Equals(s, ProvidersSegment, StringComparison.OrdinalIgnoreCase));

            // The provider namespace, the resource type and the resource name have to follow the providers segment.
            if (providersIndex < 0 || segments.Length - providersIndex < 4)
            {
                return false;
            }

            providerNamespace = segments[providersIndex + 1];
            resourceType = string.Join("/", segments.Skip(providersIndex + 2).Where((s, i) => i % 2 == 0));

            return true;
        }
    }
}
