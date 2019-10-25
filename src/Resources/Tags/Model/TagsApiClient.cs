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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.RestClients;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Collections;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using System.Threading;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;

namespace Microsoft.Azure.Commands.Tags.Model
{
    public class TagsApiClient
    {
        public string SubscriptionId { get; set; }

        public ResourceManagerRestRestClient ResourceManagerRestClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        private string GetTagsResourceId(string resourceId) => $"{resourceId}/providers/Microsoft.Resources/tags/default";

        /// <summary>
        /// Creates new tags client instance.
        /// </summary>
        /// <param name="context">The Azure context instance</param>
        public TagsApiClient(IAzureContext context, ResourceManagerRestRestClient resourceManagerRestClient, Action<string> verboseLogger, Action<string> errorLogger)
        {
            this.SubscriptionId = context.Subscription.Id;
            this.ResourceManagerRestClient = resourceManagerRestClient;
            this.VerboseLogger = verboseLogger;
            this.ErrorLogger = errorLogger;
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public TagsApiClient(string subscriptionId, ResourceManagerRestRestClient resourceManagerRestClient)
        {
            this.SubscriptionId = subscriptionId;
            this.ResourceManagerRestClient = resourceManagerRestClient;
        }

        /// <summary>
        /// Patches tags on a resource.
        /// </summary>
        /// <param name="resourceId">The resource identifier.</param>
        /// <param name="apiVersion">The API version.</param>
        /// <param name="tags">The tags to use for patching.</param>
        /// <param name="operation">The patch operation.</param>
        public TagsResource PatchTags(string resourceId, string apiVersion, InsensitiveDictionary<string> tags, PatchOperation operation)
        {
            var patchTagsRequestBody = new PatchTagsResource
            {
                Operation = operation,
                Properties = new TagsResource { Tags = tags }
            };

            return this.ResourceManagerRestClient
                .PatchResource(
                    resourceId: this.GetTagsResourceId(resourceId),
                    apiVersion: apiVersion,
                    resource: patchTagsRequestBody.ToJToken(),
                    cancellationToken: CancellationToken.None)
                .Result
                .Value
                .FromJson<TagsResource>();
        }

        /// <summary>
        /// Gets the tags on a resource.
        /// </summary>
        /// <param name="resourceId">The resource identifier.</param>
        /// <param name="apiVersion">The API version.</param>
        public TagsResource GetTags(string resourceId, string apiVersion)
        {
            return this.ResourceManagerRestClient
                .GetResource<TagsResource>(
                    resourceId: this.GetTagsResourceId(resourceId),
                    apiVersion: apiVersion,
                    cancellationToken: CancellationToken.None)
                .Result;
        }
    }
}
