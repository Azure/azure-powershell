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
    using Commands.Common.Authentication.Abstractions;
    using Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// Cmdlet to get existing resources.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmResource", DefaultParameterSetName = ByTagNameValueParameterSet), OutputType(typeof(PSResource))]
    public sealed class GetAzureResourceCmdlet : ResourceManagerCmdletBase
    {
        public const string ByResourceIdParameterSet = "ByResourceId";
        public const string ByTagObjectParameterSet = "ByTagObjectParameterSet";
        public const string ByTagNameValueParameterSet = "ByTagNameValueParameterSet";

        /// <summary>
        /// Contains the errors that encountered while satifying the request.
        /// </summary>
        private readonly ConcurrentBag<ErrorRecord> errors = new ConcurrentBag<ErrorRecord>();

        /// <summary>
        /// Gets or sets the resource name parameter.
        /// </summary>
        [Alias("Id")]
        [Parameter(ParameterSetName = ByResourceIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resource name parameter.
        /// </summary>
        [Alias("ResourceName")]
        [Parameter(ParameterSetName = ByTagObjectParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = ByTagNameValueParameterSet, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource type parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByTagObjectParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = ByTagNameValueParameterSet, Mandatory = false)]
        [ResourceTypeCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the OData query parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByTagObjectParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = ByTagNameValueParameterSet, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ODataQuery { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        [Parameter(ParameterSetName = ByTagObjectParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = ByTagNameValueParameterSet, Mandatory = false)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ByTagObjectParameterSet, Mandatory = true)]
        public Hashtable Tag { get; set; }

        [Parameter(ParameterSetName = ByTagNameValueParameterSet, Mandatory = false)]
        public string TagName { get; set; }

        [Parameter(ParameterSetName = ByTagNameValueParameterSet, Mandatory = false)]
        public string TagValue { get; set; }

        /// <summary>
        /// Gets or sets the expand properties property.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "When specified, expands the properties of the resource.")]
        public SwitchParameter ExpandProperties { get; set; }

        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        public Guid? SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the default api-version to use.
        /// </summary>
        public string DefaultApiVersion { get; set; }

        /// <summary>
        /// Collects subscription ids from the pipeline.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            this.DefaultApiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.ResourcesApiVersion : this.ApiVersion;
            var resourceId = string.Empty;
            if (ShouldConstructResourceId(out resourceId))
            {
                ResourceId = resourceId;
            }

            if (!string.IsNullOrEmpty(ResourceId))
            {
                var resource = ResourceManagerSdkClient.GetById(ResourceId, DefaultApiVersion);
                WriteObject(resource);
            }
            else if (this.IsParameterBound(c => c.ApiVersion) || this.IsParameterBound(c => c.ExpandProperties))
            {
                this.RunCmdlet();
            }
            else
            {
                this.RunSimpleCmdlet();
            }
        }

        /// <summary>
        /// Finishes the pipeline execution and runs the cmdlet.
        /// </summary>
        protected override void OnEndProcessing()
        {
            base.OnEndProcessing();
        }

        private void RunSimpleCmdlet()
        {
            if (this.IsParameterBound(c => c.Tag))
            {
                this.TagName = TagsHelper.GetTagNameFromParameters(this.Tag, null);
                this.TagValue = TagsHelper.GetTagValueFromParameters(this.Tag, null);
            }

            var expression = QueryFilterBuilder.CreateFilter(
                subscriptionId: null,
                resourceGroup: null,
                resourceType: this.ResourceType,
                resourceName: null,
                tagName: null,
                tagValue: null,
                filter: this.ODataQuery);

            var odataQuery = new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(expression);
            var result = Enumerable.Empty<PSResource>();
            if (!string.IsNullOrEmpty(this.ResourceGroupName) && !this.ResourceGroupName.Contains('*'))
            {
                result = this.ResourceManagerSdkClient.ListByResourceGroup(this.ResourceGroupName, odataQuery);
            }
            else
            {
                result = this.ResourceManagerSdkClient.ListResources(odataQuery);
                if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    result = FilterResourceGroupByWildcard(result);
                }
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                result = FilterResourceByWildcard(result);
            }

            if (!string.IsNullOrEmpty(this.TagName))
            {
                result = result.Where(r => r.Tags != null && r.Tags.Keys != null && r.Tags.Keys.Where(k => string.Equals(k, this.TagName, StringComparison.OrdinalIgnoreCase)).Any());
            }

            if (!string.IsNullOrEmpty(this.TagValue))
            {
                result = result.Where(r => r.Tags != null && r.Tags.Values != null && r.Tags.Values.Where(v => string.Equals(v, this.TagValue, StringComparison.OrdinalIgnoreCase)).Any());
            }

            WriteObject(result, true);
        }

        private bool ShouldConstructResourceId(out string resourceId)
        {
            resourceId = null;
            if (this.IsParameterBound(c => c.Name) && !ContainsWildcard(Name) &&
                this.IsParameterBound(c => c.ResourceGroupName) && !ContainsWildcard(ResourceGroupName) &&
                this.IsParameterBound(c => c.ResourceType) && ResourceType.Split('/').Count() == 2)
            {
                resourceId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/{2}/{3}",
                                            DefaultContext.Subscription.Id,
                                            ResourceGroupName,
                                            ResourceType,
                                            Name);
                return true;
            }

            return false;
        }

        private bool ContainsWildcard(string parameter)
        {
            return !string.IsNullOrEmpty(parameter) && (parameter.StartsWith("*") || parameter.EndsWith("*"));
        }

        private IEnumerable<PSResource> FilterResourceGroupByWildcard(IEnumerable<PSResource> result)
        {
            if (this.ResourceGroupName.StartsWith("*"))
            {
                this.ResourceGroupName = this.ResourceGroupName.TrimStart('*');
                if (this.ResourceGroupName.EndsWith("*"))
                {
                    this.ResourceGroupName = this.ResourceGroupName.TrimEnd('*');
                    result = result.Where(r => r.ResourceGroupName.IndexOf(this.ResourceGroupName, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else
                {
                    result = result.Where(r => r.ResourceGroupName.EndsWith(this.ResourceGroupName, StringComparison.OrdinalIgnoreCase));
                }
            }
            else if (this.ResourceGroupName.EndsWith("*"))
            {
                this.ResourceGroupName = this.ResourceGroupName.TrimEnd('*');
                result = result.Where(r => r.ResourceGroupName.StartsWith(this.ResourceGroupName, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }

        private IEnumerable<PSResource> FilterResourceByWildcard(IEnumerable<PSResource> result)
        {
            if (this.Name.StartsWith("*"))
            {
                this.Name = this.Name.TrimStart('*');
                if (this.Name.EndsWith("*"))
                {
                    this.Name = this.Name.TrimEnd('*');
                    result = result.Where(r => r.Name.IndexOf(this.Name, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else
                {
                    result = result.Where(r => r.Name.EndsWith(this.Name, StringComparison.OrdinalIgnoreCase));
                }
            }
            else if (this.Name.EndsWith("*"))
            {
                this.Name = this.Name.TrimEnd('*');
                result = result.Where(r => r.Name.StartsWith(this.Name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                result = result.Where(r => string.Equals(r.Name, this.Name, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        private void RunCmdlet()
        {
            if (string.IsNullOrEmpty(this.ResourceId))
            {
                this.SubscriptionId = DefaultContext.Subscription.GetId();
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
            if (this.IsResourceGet())
            {
                var resource = await this.GetResource().ConfigureAwait(continueOnCapturedContext: false);
                ResponseWithContinuation<JObject[]> retVal;
                return resource.TryConvertTo(out retVal) && retVal.Value != null
                    ? retVal
                    : new ResponseWithContinuation<JObject[]> { Value = resource.AsArray() };
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
        /// Gets a resource.
        /// </summary>
        private async Task<JObject> GetResource()
        {
#pragma warning disable 618

            var resourceId = this.GetResourceId();

#pragma warning restore 618

            var apiVersion = await this
                .DetermineApiVersion(resourceId: resourceId)
                .ConfigureAwait(continueOnCapturedContext: false);

            var odataQuery = QueryFilterBuilder.CreateFilter(
                subscriptionId: null,
                resourceGroup: null,
                resourceType: null,
                resourceName: null,
                tagName: null,
                tagValue: null,
                filter: this.ODataQuery);

            return await this
                .GetResourcesClient()
                .GetResource<JObject>(
                    resourceId: resourceId,
                    apiVersion: apiVersion,
                    cancellationToken: this.CancellationToken.Value,
                    odataQuery: odataQuery)
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Lists resources in a type collection.
        /// </summary>
        private async Task<ResponseWithContinuation<JObject[]>> ListResourcesTypeCollection()
        {
            var resourceCollectionId = ResourceIdUtility.GetResourceId(
                subscriptionId: this.SubscriptionId.AsArray().CoalesceEnumerable().Cast<Guid?>().FirstOrDefault(),
                resourceGroupName: this.ResourceGroupName,
                resourceType: this.ResourceType,
                resourceName: this.Name);

            var odataQuery = QueryFilterBuilder.CreateFilter(
                subscriptionId: null,
                resourceGroup: null,
                resourceType: null,
                resourceName: null,
                tagName: null,
                tagValue: null,
                filter: this.ODataQuery);

            return await this
                .GetResourcesClient()
                .ListObjectColleciton<JObject>(
                    resourceCollectionId: resourceCollectionId,
                    apiVersion: this.DefaultApiVersion,
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
                    subscriptionId: null,
                    resourceGroup: this.ResourceGroupName,
                    resourceType: this.ResourceType,
                    resourceName: this.Name,
                    tagName: null,
                    tagValue: null,
                    filter: this.ODataQuery);

            return await this
                .GetResourcesClient()
                .ListResources<JObject>(
                    apiVersion: this.DefaultApiVersion,
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
                    subscriptionId: null,
                    resourceGroup: null,
                    resourceType: this.ResourceType,
                    resourceName: this.Name,
                    tagName: null,
                    tagValue: null,
                    filter: this.ODataQuery);

            return await this
                .GetResourcesClient()
                .ListResources<JObject>(
                    subscriptionId: this.SubscriptionId.Value,
                    resourceGroupName: this.ResourceGroupName,
                    apiVersion: this.DefaultApiVersion,
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
                    subscriptionId: null,
                    resourceGroup: null,
                    resourceType: this.ResourceType,
                    resourceName: this.Name,
                    tagName: null,
                    tagValue: null,
                    filter: this.ODataQuery);

            return await this
                .GetResourcesClient()
                .ListResources<JObject>(
                    subscriptionId: this.SubscriptionId.Value,
                    apiVersion: this.DefaultApiVersion,
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
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        private string GetResourceId()
        {
            return !string.IsNullOrWhiteSpace(this.ResourceId)
            ? this.ResourceId
            : ResourceIdUtility.GetResourceId(
                subscriptionId: this.SubscriptionId.Value,
                resourceGroupName: this.ResourceGroupName,
                resourceType: this.ResourceType,
                resourceName: this.Name);
        }

        /// <summary>
        /// Returns true if this is a resource get at any level.
        /// </summary>
        private bool IsResourceGet()
        {
            return !string.IsNullOrWhiteSpace(this.ResourceId) ||
                this.IsResourceGroupLevelResourceGet() ||
                this.IsSubscriptionLevelResourceGet() ||
                this.IsTenantLevelResourceGet();
        }

        /// <summary>
        /// Returns true if this is a get on a type collection that is at the subscription level.
        /// </summary>
        private bool IsSubscriptionLevelResourceTypeCollectionGet()
        {
            return this.SubscriptionId.HasValue &&
                this.ResourceGroupName == null &&
                this.Name == null &&
                this.ResourceType != null;
        }

        /// <summary>
        /// Returns true if this is a get on a type collection that is at the resource group.
        /// </summary>
        private bool IsResourceGroupLevelResourceTypeCollectionGet()
        {
            return this.SubscriptionId.HasValue &&
                this.ResourceGroupName != null &&
                this.Name == null &&
                this.ResourceType != null;
        }

        /// <summary>
        /// Returns true if this is a tenant level resource type collection get (a get without a subscription or
        /// resource group or resource name but with a resource or extension type.)
        /// </summary>
        private bool IsTenantLevelResourceTypeCollectionGet()
        {
            return this.SubscriptionId == null &&
                this.ResourceGroupName == null &&
                this.Name == null &&
                this.ResourceType != null;
        }

        /// <summary>
        /// Returns true if this is a subscription level resource get (a get that has a single
        /// subscription and a resource type or name.)
        /// </summary>
        private bool IsSubscriptionLevelResourceGet()
        {
            return this.SubscriptionId.HasValue &&
                this.ResourceGroupName == null &&
                this.Name != null &&
                this.ResourceType != null;
        }

        /// <summary>
        /// Returns true if this is a resource group level resource get (a get that has a single
        /// subscription and resource group name as well as a resource name and type.)
        /// </summary>
        private bool IsResourceGroupLevelResourceGet()
        {
            return this.SubscriptionId.HasValue &&
                this.ResourceGroupName != null &&
                this.Name != null &&
                this.ResourceType != null;
        }

        /// <summary>
        /// Returns true if this is a tenant level query.
        /// </summary>
        private bool IsTenantLevelResourceGet()
        {
            return this.SubscriptionId == null &&
                this.ResourceGroupName == null &&
                this.Name != null &&
                this.ResourceType != null;
        }

        /// <summary>
        /// Returns true if this is a subscription level query.
        /// </summary>
        private bool IsSubscriptionLevelQuery()
        {
            return this.SubscriptionId.HasValue &&
                this.ResourceGroupName == null;
        }

        /// <summary>
        /// Returns true if this is a resource group level query.
        /// </summary>
        private bool IsResourceGroupLevelQuery()
        {
            return this.SubscriptionId.HasValue &&
                this.ResourceGroupName != null &&
                this.Name != null ||
                this.ResourceType != null;
        }
    }
}