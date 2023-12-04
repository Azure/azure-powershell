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
using SDKTagsObject = Microsoft.Azure.Management.Resources.Models.Tags;

namespace Microsoft.Azure.Commands.Tags.Client
{
    public class TagsClient
    {
        public const string ExecludedTagPrefix = "hidden-related:/";

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
            return ResourceManagementClient.Tags.CreateOrUpdateAtScope(scope: scope, parameters: tagResource)?.ToPSTagResource();
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
            return ResourceManagementClient.Tags.UpdateAtScope(scope: scope, parameters: tagPatchResource)?.ToPSTagResource();
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
            ResourceManagementClient.Tags.DeleteAtScope(scope);

            return tags;
        }
    }
}
