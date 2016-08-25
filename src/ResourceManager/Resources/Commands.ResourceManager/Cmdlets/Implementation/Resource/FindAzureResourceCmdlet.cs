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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// Cmdlet to get existing resources from ARM cache.
    /// </summary>
    [Cmdlet(VerbsCommon.Find, "AzureRmResource", DefaultParameterSetName = FindAzureResourceCmdlet.ListResourcesParameterSet), OutputType(typeof(PSObject))]
    public sealed class FindAzureResourceCmdlet : ResourceManagerCmdletBase
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
        /// The list tenant resources parameter set.
        /// </summary>
        internal const string ListTenantResourcesParameterSet = "Lists the resources based on the specified scope at the tenant level.";

        /// <summary>
        /// The get tenant resource parameter set.
        /// </summary>
        internal const string MultiSubscriptionListResourcesParameterSet = "Get a resources using a multi-subscription query.";

        /// <summary>
        /// Caches the current subscription ids to get all subscription ids in the pipeline.
        /// </summary>
        private readonly List<Guid> subscriptionIds = new List<Guid>();

        /// <summary>
        /// Gets or sets the resource name parameter.
        /// </summary>
        [Alias("Name")]
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.ListResourcesParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource name substring. e.g. if your resource name is testResource, you can specify test.")]
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.ListTenantResourcesParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource name substring. e.g. if your resource name is testResource, you can specify test.")]
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.MultiSubscriptionListResourcesParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource name substring. e.g. if your resource name is testResource, you can specify test.")]
        [ValidateNotNullOrEmpty]
        public string ResourceNameContains { get; set; }

        /// <summary>
        /// Gets or sets the resource type parameter.
        /// </summary>
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.ListResourcesParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource type. e.g. Microsoft.Sql/Servers/Databases.")]
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.ListTenantResourcesParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource type. e.g. Microsoft.Sql/Servers/Databases.")]
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.MultiSubscriptionListResourcesParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource type. e.g. Microsoft.Sql/Servers/Databases.")]
        [ValidateNotNullOrEmpty]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the extension resource type.
        /// </summary>
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.ListResourcesParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The extension resource type. e.g. Microsoft.Sql/Servers/{serverName}/Databases/myDatabase.")]
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.ListTenantResourcesParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The extension resource type. e.g. Microsoft.Sql/Servers/{serverName}/Databases/myDatabase.")]
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.MultiSubscriptionListResourcesParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The extension resource type. e.g. Microsoft.Sql/Servers/{serverName}/Databases/myDatabase.")]
        [ValidateNotNullOrEmpty]
        public string ExtensionResourceType { get; set; }

        /// <summary>
        /// Gets or sets the top parameter.
        /// </summary>
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.ListResourcesParameterSet, Mandatory = false, HelpMessage = "The number of resources to retrieve.")]
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.ListTenantResourcesParameterSet, Mandatory = false, HelpMessage = "The number of resources to retrieve.")]
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.MultiSubscriptionListResourcesParameterSet, Mandatory = false, HelpMessage = "The number of resources to retrieve.")]
        [ValidateNotNullOrEmpty]
        public int? Top { get; set; }

        /// <summary>
        /// Gets or sets the OData query parameter.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "An OData style filter which will be appended to the request in addition to any other filters.")]
        [ValidateNotNullOrEmpty]
        public string ODataQuery { get; set; }

        /// <summary>
        /// Gets or sets the tag name.
        /// </summary>
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.ListResourcesParameterSet, Mandatory = false, HelpMessage = "The name of the tag to query by.")]
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.MultiSubscriptionListResourcesParameterSet, Mandatory = false, HelpMessage = "The name of the tag to query by.")]
        [ValidateNotNullOrEmpty]
        public string TagName { get; set; }

        /// <summary>
        /// Gets or sets the tag value.
        /// </summary>
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.ListResourcesParameterSet, Mandatory = false, HelpMessage = "The value of the tag to query by.")]
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.MultiSubscriptionListResourcesParameterSet, Mandatory = false, HelpMessage = "The value of the tag to query by.")]
        [ValidateNotNullOrEmpty]
        public string TagValue { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        [Alias("ResourceGroupName")]
        [Parameter(Mandatory = false, ParameterSetName = FindAzureResourceCmdlet.ListResourcesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name substring.")]
        [Parameter(Mandatory = false, ParameterSetName = FindAzureResourceCmdlet.MultiSubscriptionListResourcesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name substring.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupNameContains { get; set; }

        /// <summary>
        /// Gets or sets the expand properties property.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "When specified, expands the properties of the resource.")]
        public SwitchParameter ExpandProperties { get; set; }

        /// <summary>
        /// Gets or sets the tenant level parameter.
        /// </summary>
        [Parameter(ParameterSetName = FindAzureResourceCmdlet.ListTenantResourcesParameterSet, Mandatory = true, HelpMessage = "Indicates that this is a tenant level operation.")]
        public SwitchParameter TenantLevel { get; set; }

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
            if (!this.TenantLevel)
            {
                this.SubscriptionId = DefaultContext.Subscription.Id;
            }

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
            if (this.IsResourceTypeCollectionGet())
            {
                return await this.ListResourcesTypeCollection().ConfigureAwait(continueOnCapturedContext: false);
            }

            if (this.IsResourceGroupLevelQuery())
            {
                return await this.ListResourcesInResourceGroup().ConfigureAwait(continueOnCapturedContext: false);
            }

            if (this.IsSubscriptionLevelQuery())
            {
                return await this.ListResourcesInSubscription().ConfigureAwait(continueOnCapturedContext: false);
            }

            return await this.ListResourcesInTenant().ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Lists resources in a type collection.
        /// </summary>
        private async Task<ResponseWithContinuation<JObject[]>> ListResourcesTypeCollection()
        {
            var resourceCollectionId = ResourceIdUtility.GetResourceId(
                subscriptionId: this.SubscriptionId.AsArray().CoalesceEnumerable().Cast<Guid?>().FirstOrDefault(),
                resourceGroupName: null,
                resourceType: this.ResourceType,
                resourceName: null,
                extensionResourceType: this.ExtensionResourceType,
                extensionResourceName: null);

            var apiVersion = await this
                .DetermineApiVersion(resourceId: resourceCollectionId)
                .ConfigureAwait(continueOnCapturedContext: false);

            var odataQuery = QueryFilterBuilder.CreateFilter(
                resourceType: null,
                resourceName: null,
                tagName: this.TagName,
                tagValue: this.TagValue,
                filter: this.ODataQuery,
                resourceGroupNameContains: this.ResourceGroupNameContains,
                nameContains: this.ResourceNameContains);

            return await this
                .GetResourcesClient()
                .ListObjectColleciton<JObject>(
                    resourceCollectionId: resourceCollectionId,
                    apiVersion: apiVersion,
                    cancellationToken: this.CancellationToken.Value,
                    odataQuery: odataQuery)
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Lists the resources in the tenant.
        /// </summary>
        private async Task<ResponseWithContinuation<JObject[]>> ListResourcesInTenant()
        {
            var filterQuery = QueryFilterBuilder
                .CreateFilter(
                    subscriptionIds: new Guid[] { this.SubscriptionId.Value },
                    resourceGroup: null,
                    resourceType: this.ResourceType,
                    resourceName: null,
                    tagName: this.TagName,
                    tagValue: this.TagValue,
                    filter: this.ODataQuery,
                    resourceGroupNameContains: this.ResourceGroupNameContains,
                    nameContains: this.ResourceNameContains);

            var apiVersion = await this
                .DetermineApiVersion(providerNamespace: Constants.MicrosoftResourceNamesapce, resourceType: Constants.ResourceGroups)
                .ConfigureAwait(continueOnCapturedContext: false);

            return await this
                .GetResourcesClient()
                .ListResources<JObject>(
                    apiVersion: apiVersion,
                    top: this.Top,
                    filter: filterQuery,
                    cancellationToken: this.CancellationToken.Value)
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Lists the resources in a resource group.
        /// </summary>
        private async Task<ResponseWithContinuation<JObject[]>> ListResourcesInResourceGroup()
        {
            var filterQuery = QueryFilterBuilder
                .CreateFilter(
                    resourceType: this.ResourceType,
                    resourceName: null,
                    tagName: this.TagName,
                    tagValue: this.TagValue,
                    filter: this.ODataQuery,
                    resourceGroupNameContains: this.ResourceGroupNameContains,
                    nameContains: this.ResourceNameContains);

            var apiVersion = await this
                .DetermineApiVersion(providerNamespace: Constants.MicrosoftResourceNamesapce, resourceType: Constants.ResourceGroups)
                .ConfigureAwait(continueOnCapturedContext: false);

            return await this
                .GetResourcesClient()
                .ListResources<JObject>(
                    subscriptionId: this.SubscriptionId.Value,
                    resourceGroupName: null,
                    apiVersion: apiVersion,
                    top: this.Top,
                    filter: filterQuery,
                    cancellationToken: this.CancellationToken.Value)
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Gets the resources in a subscription.
        /// </summary>
        private async Task<ResponseWithContinuation<JObject[]>> ListResourcesInSubscription()
        {
            var filterQuery = QueryFilterBuilder
                .CreateFilter(
                    resourceType: this.ResourceType,
                    resourceName: null,
                    tagName: this.TagName,
                    tagValue: this.TagValue,
                    filter: this.ODataQuery,
                    nameContains: this.ResourceNameContains);

            var apiVersion = await this
                .DetermineApiVersion(providerNamespace: Constants.MicrosoftResourceNamesapce, resourceType: Constants.ResourceGroups)
                .ConfigureAwait(continueOnCapturedContext: false);

            return await this
                .GetResourcesClient()
                .ListResources<JObject>(
                    subscriptionId: this.SubscriptionId.Value,
                    apiVersion: apiVersion,
                    top: this.Top,
                    filter: filterQuery,
                    cancellationToken: this.CancellationToken.Value)
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
                var apiVersion = await this.DetermineApiVersion(
                        resourceId: resource.Id,
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

        /// <summary>
        /// Returns true if this is get on a resource type collection, at any scope.
        /// </summary>
        private bool IsResourceTypeCollectionGet()
        {
            return (this.TenantLevel) &&
                (this.IsResourceGroupLevelResourceTypeCollectionGet() ||
                this.IsSubscriptionLevelResourceTypeCollectionGet() ||
                this.IsTenantLevelResourceTypeCollectionGet());
        }

        /// <summary>
        /// Returns true if this is a get on a type collection that is at the subscription level.
        /// </summary>
        private bool IsSubscriptionLevelResourceTypeCollectionGet()
        {
            return this.SubscriptionId.HasValue &&
                this.ResourceGroupNameContains == null &&
                (this.ResourceType != null || this.ExtensionResourceType != null);
        }

        /// <summary>
        /// Returns true if this is a get on a type collection that is at the resource group.
        /// </summary>
        private bool IsResourceGroupLevelResourceTypeCollectionGet()
        {
            return this.SubscriptionId.HasValue &&
                this.ResourceGroupNameContains != null &&
                (this.ResourceType != null || this.ExtensionResourceType != null);
        }

        /// <summary>
        /// Returns true if this is a tenant level resource type collection get (a get without a subscription or 
        /// resource group or resource name but with a resource or extension type.)
        /// </summary>
        private bool IsTenantLevelResourceTypeCollectionGet()
        {
            return this.SubscriptionId == null &&
                this.ResourceGroupNameContains == null &&
                (this.ResourceType != null || this.ExtensionResourceType != null);
        }

        /// <summary>
        /// Returns true if this is a subscription level query.
        /// </summary>
        private bool IsSubscriptionLevelQuery()
        {
            return this.SubscriptionId.HasValue &&
                this.ResourceGroupNameContains == null;
        }

        /// <summary>
        /// Returns true if this is a resource group level query.
        /// </summary>
        private bool IsResourceGroupLevelQuery()
        {
            return this.SubscriptionId.HasValue &&
                this.ResourceGroupNameContains != null &&
                (this.TagName != null ||
                this.TagValue != null ||
                this.ResourceType != null ||
                this.ExtensionResourceType != null);
        }
    }
}
