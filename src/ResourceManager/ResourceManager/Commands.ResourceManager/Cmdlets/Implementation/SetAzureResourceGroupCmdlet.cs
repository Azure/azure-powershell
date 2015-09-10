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
    using System.Collections;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A cmdlet that updates a resource group.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureResourceGroup", DefaultParameterSetName = SetAzureResourceGroupCmdlet.ResourceGroupNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSObject))]
    public sealed class SetAzureResourceGroupCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// The resource Id parameter set.
        /// </summary>
        internal const string ResourceIdParameterSet = "The resource Id parameter set.";

        /// <summary>
        /// The resource name parameter set.
        /// </summary>
        internal const string ResourceGroupNameParameterSet = "The resource name parameter set.";

        /// <summary>
        /// Gets or sets the resource id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = SetAzureResourceGroupCmdlet.ResourceIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The fully qualified resource group Id, including the subscription. e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        [Parameter(ParameterSetName = SetAzureResourceGroupCmdlet.ResourceGroupNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [Alias("Tags")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents resource group tags.")]
        public Hashtable[] Tag { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            string resourceId = this.Id ?? ResourceIdUtility.GetResourceId(this.Profile.Context.Subscription.Id, this.Name, null, null);
            var apiVersion = this.DetermineApiVersion(resourceId: resourceId).Result;
            var resource = this.GetExistingResource(resourceId, apiVersion).Result.ToResource();

            var operationResult = this.GetResourcesClient()
                        .PutResource(
                            resourceId: resourceId,
                            apiVersion: apiVersion,
                            resource: this.GetResource(resource.Location).ToJToken(),
                            cancellationToken: this.CancellationToken.Value,
                            odataQuery: null)
                        .Result;

            var managementUri = this.GetResourcesClient()
              .GetResourceManagementRequestUri(
                  resourceId: resourceId,
                  apiVersion: apiVersion,
                  odataQuery: null);

            var activity = string.Format("PUT {0}", managementUri.PathAndQuery);
            var result = this.GetLongRunningOperationTracker(activityName: activity, isResourceCreateOrUpdate: true)
                .WaitOnOperation(operationResult: operationResult);

            this.TryConvertToResourceAndWriteObject(result, ResourceObjectFormat.New);
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private Resource<JToken> GetResource(string location)
        {
            return new Resource<JToken>()
            {
                Name = this.Name,
                Location = location,
                Tags = TagsHelper.GetTagsDictionary(this.Tag)
            };
        }

        /// <summary>
        /// Gets a resource.
        /// </summary>
        private async Task<JObject> GetExistingResource(string resourceId, string apiVersion)
        {
            return await this
                .GetResourcesClient()
                .GetResource<JObject>(
                    resourceId: resourceId,
                    apiVersion: apiVersion,
                    cancellationToken: this.CancellationToken.Value)
                .ConfigureAwait(continueOnCapturedContext: false);
        }
    }

}