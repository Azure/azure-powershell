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

using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Tags.Model;

namespace Microsoft.Azure.Commands.Tags.Tag
{
    /// <summary>
    /// A cmdlet that gets tags on a subscription.
    /// </summary>
    [Cmdlet("Get", AzureRMConstants.AzureRMPrefix + "SubscriptionTag", SupportsShouldProcess = true), OutputType(typeof(TagsResource))]
    public sealed class GetAzureSubscriptionTagCmdlet : TagBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            var tagsResource = this.TagsApiClient.GetTags(
                resourceId: $"subscriptions/{this.DefaultContext.Subscription.Id}",
                apiVersion: "2019-10-01");

            WriteObject(tagsResource);
        }
    }
}
