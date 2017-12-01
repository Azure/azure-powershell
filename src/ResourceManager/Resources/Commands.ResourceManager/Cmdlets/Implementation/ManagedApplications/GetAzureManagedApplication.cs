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
    using Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Newtonsoft.Json.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// Gets the managed application.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmManagedApplication", DefaultParameterSetName = GetAzureManagedApplicationCmdlet.ParameterlessSet), OutputType(typeof(PSObject))]
    public class GetAzureManagedApplicationCmdlet : ManagedApplicationCmdletBase
    {
        /// <summary>
        /// The managed application Id parameter set.
        /// </summary>
        internal const string ManagedApplicationIdParameterSet = "GetById";

        /// <summary>
        /// The managed application name parameter set.
        /// </summary>
        internal const string ManagedApplicationNameParameterSet = "GetByNameAndResourceGroup";

        /// <summary>
        /// The list all managed application parameter set.
        /// </summary>
        internal const string ParameterlessSet = "GetBySubscription";

        /// <summary>
        /// Gets or sets the managed application name parameter.
        /// </summary>
        [Parameter(ParameterSetName = GetAzureManagedApplicationCmdlet.ManagedApplicationNameParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The managed application name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the managed application resource group parameter
        /// </summary>
        [Parameter(ParameterSetName = GetAzureManagedApplicationCmdlet.ManagedApplicationNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the managed application id parameter
        /// </summary>
        [Alias("ResourceId", "ManagedApplicationId")]
        [Parameter(ParameterSetName = GetAzureManagedApplicationCmdlet.ManagedApplicationIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The fully qualified managed application Id, including the subscription. e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();

            this.RunCmdlet();
        }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        private void RunCmdlet()
        {
            PaginatedResponseHelper.ForEach(
                getFirstPage: () => this.GetResources(),
                getNextPage: nextLink => this.GetNextLink<JObject>(nextLink),
                cancellationToken: this.CancellationToken,
                action: resources => this.WriteObject(sendToPipeline: this.GetOutputObjects("ManagedApplicationId", resources), enumerateCollection: true));
        }

        /// <summary>
        /// Queries the ARM cache and returns the cached resource that match the query specified.
        /// </summary>
        private async Task<ResponseWithContinuation<JObject[]>> GetResources()
        {
            string resourceId = this.Id ?? this.GetResourceId();

            var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.ApplicationApiVersion : this.ApiVersion;

            if (!string.IsNullOrEmpty(ResourceIdUtility.GetResourceName(resourceId)))
            {
                var resource = await this
                    .GetResourcesClient()
                    .GetResource<JObject>(
                        resourceId: resourceId,
                        apiVersion: apiVersion,
                        cancellationToken: this.CancellationToken.Value)
                    .ConfigureAwait(continueOnCapturedContext: false);
                ResponseWithContinuation<JObject[]> retVal;
                return resource.TryConvertTo(out retVal) && retVal.Value != null
                    ? retVal
                    : new ResponseWithContinuation<JObject[]> { Value = resource.AsArray() };
            }
            else
            {
                return await this
                .GetResourcesClient()
                .ListObjectColleciton<JObject>(
                    resourceCollectionId: resourceId,
                    apiVersion: apiVersion,
                    cancellationToken: this.CancellationToken.Value)
                .ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Gets the resource Id
        /// </summary>
        private string GetResourceId()
        {
            var subscriptionId = DefaultContext.Subscription.Id;
            if (string.IsNullOrEmpty(this.Name) && string.IsNullOrEmpty(this.ResourceGroupName))
            {
                return string.Format("/subscriptions/{0}/providers/{1}",
                    subscriptionId.ToString(),
                    Constants.MicrosoftApplicationType);
            }
            else if (string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.ResourceGroupName))
            {
                return string.Format("/subscriptions/{0}/resourcegroups/{1}/providers/{2}",
                    subscriptionId.ToString(),
                    this.ResourceGroupName,
                    Constants.MicrosoftApplicationType);
            }
            else if (!string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.ResourceGroupName))
            {
                return string.Format("/subscriptions/{0}/resourcegroups/{1}/providers/{2}/{3}",
                    subscriptionId.ToString(),
                    this.ResourceGroupName,
                    Constants.MicrosoftApplicationType,
                    this.Name);
            }
            return this.Id;
        }
    }
}
