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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using System;
    using System.Collections;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Newtonsoft.Json.Linq;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

    /// <summary>
    /// Finds the resource group.
    /// </summary>
    [Cmdlet(VerbsCommon.Find, "AzureRmResourceGroup"), OutputType(typeof(PSObject))]
    public class FindAzureResourceGroupCmdlet : ResourceManagerCmdletBase
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The tag filter for the OData query. The expected format is @{tagName=$null} or @{tagName = 'tagValue'}.")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Finishes the pipeline execution and runs the cmdlet.
        /// </summary>
        protected override void OnEndProcessing()
        {
            base.OnEndProcessing();

            this.RunCmdlet();
        }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        private void RunCmdlet()
        {
            PaginatedResponseHelper.ForEach(
               getFirstPage: () => this.GetResourceGroups(),
               getNextPage: nextLink => this.GetNextLink<JObject>(nextLink),
               cancellationToken: this.CancellationToken,
               action: resourceGroups => this.WriteObject(sendToPipeline: resourceGroups.CoalesceEnumerable().SelectArray(resourceGroup => resourceGroup.ToPsObject()), enumerateCollection: true));
        }

        /// <summary>
        /// Queries the ARM cache and returns the cached resource groups that match the query specified.
        /// </summary>
        private async Task<ResponseWithContinuation<JObject[]>> GetResourceGroups()
        {
            var resourceGroupsId = string.Format("/subscriptions/{0}/resourceGroups", Uri.EscapeDataString(this.DefaultContext.Subscription.Id.ToString()));

            var apiVersion = await this
                .DetermineApiVersion(resourceId: resourceGroupsId)
                .ConfigureAwait(continueOnCapturedContext: false);

            string queryString = null;

            if (this.Tag != null)
            {
                var tagValuePair = TagsConversionHelper.Create(this.Tag);

                if (tagValuePair == null)
                {
                    throw new ArgumentException(ProjectResources.InvalidTagFormat);
                }

                queryString = tagValuePair.Value != null
                    ? string.Format("$filter=tagname eq '{0}' and tagvalue eq '{1}'", tagValuePair.Name, tagValuePair.Value)
                    : string.Format("$filter=tagname eq '{0}'", tagValuePair.Name);
            }

            return await this
                .GetResourcesClient()
                .ListObjectColleciton<JObject>(
                    resourceCollectionId: resourceGroupsId,
                    apiVersion: apiVersion,
                    cancellationToken: this.CancellationToken.Value,
                    odataQuery: queryString)
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Gets the next set of resources using the <paramref name="nextLink"/>
        /// </summary>
        /// <param name="nextLink">The next link.</param>
        private Task<ResponseWithContinuation<TType[]>> GetNextLink<TType>(string nextLink)
        {
            return this
                .GetResourcesClient()
                .ListNextBatch<TType>(nextLink: nextLink, cancellationToken: this.CancellationToken.Value);
        }
    }
}
