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
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Authorization;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Cmdlet to get existing resources.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneApps", DefaultParameterSetName = GetAzureResourceCmdlet.ListResourcesParameterSet), OutputType(typeof(PSObject))]
    public sealed class GetAzureRmIntuneAppsCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// Contains the errors that encountered while satifying the request.
        /// </summary>
        private readonly ConcurrentBag<ErrorRecord> errors = new ConcurrentBag<ErrorRecord>();

        /// <summary>
        /// The list resources parameter set.
        /// </summary>
        internal const string ListResourcesParameterSet = "Lists the resources based on the specified scope.";

        /// <summary>
        /// The get resource parameter set.
        /// </summary>
        internal const string GetResourceParameterSet = "Get a single resource.";

        /// <summary>
        /// The list tenant resources parameter set.
        /// </summary>
        internal const string ListTenantResourcesParameterSet = "Lists the resources based on the specified scope at the tenant level.";

        /// <summary>
        /// The get tenant resource parameter set.
        /// </summary>
        internal const string GetTenantResourceParameterSet = "Get a single resource at the tenant level.";

        /// <summary>
        /// The get tenant resource parameter set.
        /// </summary>
        internal const string GetResourceByIdParameterSet = "Get a single resource by its Id.";

        /// <summary>
        /// The get tenant resource parameter set.
        /// </summary>
        internal const string MultiSubscriptionListResourcesParameterSet = "Get a resources using a multi-subscription query.";

        /// <summary>
        /// Caches the current subscription ids to get all subscription ids in the pipeline.
        /// </summary>
        private readonly List<Guid> subscriptionIds = new List<Guid>();

        /// <summary>
        /// Gets or sets the expand properties property.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "When specified, expands the properties of the resource.")]
        public SwitchParameter ExpandProperties { get; set; }

        /// <summary>
        /// Gets or sets the top parameter.
        /// </summary>
        [Parameter(ParameterSetName = GetAzureResourceCmdlet.ListResourcesParameterSet, Mandatory = false, HelpMessage = "The number of resources to retrieve.")]
        [Parameter(ParameterSetName = GetAzureResourceCmdlet.ListTenantResourcesParameterSet, Mandatory = false, HelpMessage = "The number of resources to retrieve.")]
        [Parameter(ParameterSetName = GetAzureResourceCmdlet.MultiSubscriptionListResourcesParameterSet, Mandatory = false, HelpMessage = "The number of resources to retrieve.")]
        [ValidateNotNullOrEmpty]
        public int? Top { get; set; }

        /// <summary>
        /// Gets or sets the OData query parameter.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "An OData style filter which will be appended to the request in addition to any other filters.")]
        [ValidateNotNullOrEmpty]
        public platform? Platform { get; set; }

        public enum platform
        {
            ios,
            android,
            windows,
            none

        }
        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        public Guid? SubscriptionId { get; set; }

        /// <summary>
        /// Collects subscription ids from the pipeline.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
        }

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
                getFirstPage: () => this.GetResources(),
                getNextPage: nextLink => this.GetNextLink<JObject>(nextLink),
                cancellationToken: this.CancellationToken,
                action: resources =>
                {
                    Resource<JToken> resource;
                    if (resources.CoalesceEnumerable().FirstOrDefault().TryConvertTo(out resource))
                    {
                        var genericResources = resources.CoalesceEnumerable().Where(res => res != null).SelectArray(res => res.ToResource());

                        foreach (var batch in genericResources.Batch())
                        {
                            var items = batch;
                            if (this.ExpandProperties)
                            {
                                items = this.GetPopulatedResource(batch).Result;
                            }

                            var powerShellObjects = items.SelectArray(genericResource => genericResource.ToPsObject());

                            this.WriteObject(sendToPipeline: powerShellObjects, enumerateCollection: true);
                        }
                    }
                    else
                    {
                        this.WriteObject(sendToPipeline: resources.CoalesceEnumerable().SelectArray(res => res.ToPsObject()), enumerateCollection: true);
                    }
                });

            if (this.errors.Count != 0)
            {
                foreach (var error in this.errors)
                {
                    this.WriteError(error);
                }
            }
        }

        /// <summary>
        /// Queries the ARM cache and returns the cached resource that match the query specified.
        /// </summary>
        private async Task<ResponseWithContinuation<JObject[]>> GetResources()
        {
            return await this.ListResourcesTypeCollection().ConfigureAwait(continueOnCapturedContext: false);
        }       

        /// <summary>
        /// Lists resources in a type collection.
        /// </summary>
        private async Task<ResponseWithContinuation<JObject[]>> ListResourcesTypeCollection()
        {
            var resourceCollectionId = "/providers/Microsoft.Intune/Locations/akdirtest/apps";

            var apiVersion = "2015-01-08-alpha";

            var odataQuery = this.Platform ==null? null : string.Format("$filter=platform eq '{0}'", this.Platform.ToString());

            return await this
                .GetResourcesClient()
                .ListObjectColleciton<JObject>(
                    resourceCollectionId: resourceCollectionId,
                    apiVersion: apiVersion,
                    cancellationToken: this.CancellationToken.Value,
                    odataQuery: odataQuery)
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        private async Task GetLocations()
        {
            var resourceId = "/providers/Microsoft.Intune/locations/hostName";
            var apiVersion = "2015-01-08-alpha";
            var location = await this.GetResourcesClient().GetResource<JObject>(resourceId, apiVersion, this.CancellationToken.Value);
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

        /// <summary>
        /// Populates the properties on an array of resources.
        /// </summary>
        /// <param name="resources">The resource.</param>
        private async Task<Resource<JToken>[]> GetPopulatedResource(IEnumerable<Resource<JToken>> resources)
        {
            return await resources
                .Select(resource => this.GetPopulatedResource(resource))
                .WhenAllForAwait()
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Populates the properties of a single resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        private async Task<Resource<JToken>> GetPopulatedResource(Resource<JToken> resource)
        {
            try
            {
                var apiVersion = await ApiVersionHelper
                    .DetermineApiVersion(
                        DefaultContext,
                        resourceId: resource.Id,
                        cancellationToken: this.CancellationToken.Value,
                        pre: this.Pre)
                    .ConfigureAwait(continueOnCapturedContext: false);

                return await this
                    .GetResourcesClient()
                    .GetResource<Resource<JToken>>(
                        resourceId: resource.Id,
                        apiVersion: apiVersion,
                        cancellationToken: this.CancellationToken.Value)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
            catch (Exception ex)
            {
                if (ex.IsFatal())
                {
                    throw;
                }

                ex = (ex is AggregateException)
                    ? (ex as AggregateException).Flatten()
                    : ex;

                this.errors.Add(new ErrorRecord(ex, "ErrorExpandingProperties", ErrorCategory.CloseError, resource));
            }

            return resource;
        }
    }
}