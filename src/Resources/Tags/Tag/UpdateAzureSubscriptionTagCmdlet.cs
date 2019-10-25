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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Tags.Model;
using ResourceStrings = Microsoft.Azure.Commands.Tags.Properties.Resources;

namespace Microsoft.Azure.Commands.Tags.Tag
{
    /// <summary>
    /// A cmdlet that updates tags on a subscription.
    /// </summary>
    [Cmdlet("Update", AzureRMConstants.AzureRMPrefix + "SubscriptionTag", SupportsShouldProcess = true), OutputType(typeof(TagsResource))]
    public sealed class UpdateAzureSubscriptionTagCmdlet : TagBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [Alias("Tags")]
        [Parameter(Mandatory = true, HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                ResourceStrings.UpdatingSubscriptionTags,
                this.DefaultContext.Subscription.Id,
                () =>
                {
                    var tagsResource = this.TagsApiClient.PatchTags(
                        resourceId: $"subscriptions/{this.DefaultContext.Subscription.Id}",
                        apiVersion: "2019-10-01",
                        tags: TagsHelper.GetTagsDictionary(this.Tag),
                        operation: PatchOperation.Replace);

                    WriteObject(tagsResource);
                });
        }
    }
}
