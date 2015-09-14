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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A cmdlet that creates a new azure resource group.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRMResourceGroup", SupportsShouldProcess = true), OutputType(typeof(PSObject))]
    public sealed class NewAzureResourceGroupCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group location.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The resource group location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [Alias("Tags")]
        [Parameter(Mandatory = false, HelpMessage = "A hash table which represents resource group tags.")]
        public Hashtable[] Tag { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            string resourceId = ResourceIdUtility.GetResourceId(DefaultContext.Subscription.Id, this.Name, null, null);
            var apiVersion = this.DetermineApiVersion(resourceId: resourceId).Result;

            var operationResult = this.GetResourcesClient()
                .PutResource(
                    resourceId: resourceId,
                    apiVersion: apiVersion,
                    resource: this.GetResource().ToJToken(),
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
        private Resource<JToken> GetResource()
        {
            return new Resource<JToken>()
            {
                Name = this.Name,
                Location = this.Location,
                Tags = TagsHelper.GetTagsDictionary(this.Tag)
            };
        }

    }
}