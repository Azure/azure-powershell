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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.RestClients
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Operations;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A client for managing resources behind the Azure Resource Manager service.
    /// </summary>
    public class ResourceManagerRestRestClient : ResourceManagerRestClientBase
    {
        /// <summary>
        /// The endpoint that this client will communicate with.
        /// </summary>
        public Uri EndpointUri { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceManagerRestRestClient"/> class.
        /// </summary>
        /// <param name="endpointUri">The endpoint that this client will communicate with.</param>
        /// <param name="httpClientHelper">The azure http client wrapper to use.</param>
        public ResourceManagerRestRestClient(Uri endpointUri, Components.HttpClientHelper httpClientHelper)
            : base(httpClientHelper: httpClientHelper)
        {
            this.EndpointUri = endpointUri;
        }

        /// <summary>
        /// Get a single resource.
        /// </summary>
        /// <param name="resourceCollectionId">The resource collection Id.</param>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the request.</param>
        /// <param name="odataQuery">The OData query.</param> 
        public Task<ResponseWithContinuation<TType[]>> ListObjectColleciton<TType>(
            string resourceCollectionId,
            string apiVersion,
            CancellationToken cancellationToken,
            string odataQuery = null)
        {
            var requestUri = this.GetResourceManagementRequestUri(
                resourceId: resourceCollectionId,
                apiVersion: apiVersion,
                odataQuery: odataQuery);

            return this.SendRequestAsync<ResponseWithContinuation<TType[]>>(
                httpMethod: HttpMethod.Get,
                requestUri: requestUri,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Lists all the resources under the user's tenant.
        /// </summary>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="cancellationToken"></param>
        /// <param name="top">The number of resources to fetch.</param>
        /// <param name="filter">The filter query.</param>
        public Task<ResponseWithContinuation<TType[]>> ListResources<TType>(
            string apiVersion,
            CancellationToken cancellationToken,
            int? top = null,
            string filter = null)
        {
            var requestUri = this.GetResourceManagementRequestUri(
                resourceId: string.Empty,
                action: "resources",
                top: top == null ? null : string.Format("$top={0}", top.Value),
                odataQuery: string.IsNullOrWhiteSpace(filter) ? null : string.Format("$filter={0}", filter),
                apiVersion: apiVersion);

            return this.SendRequestAsync<ResponseWithContinuation<TType[]>>(
                httpMethod: HttpMethod.Get,
                requestUri: requestUri,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Lists all the resources under a single the subscription.
        /// </summary>
        /// <param name="subscriptionId">The subscription Id.</param>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="cancellationToken"></param>
        /// <param name="top">The number of resources to fetch.</param>
        /// <param name="filter">The filter query.</param>
        public Task<ResponseWithContinuation<TType[]>> ListResources<TType>(
            Guid subscriptionId,
            string apiVersion,
            CancellationToken cancellationToken,
            int? top = null,
            string filter = null)
        {
            var resourceId = ResourceIdUtility.GetResourceId(
                subscriptionId: subscriptionId,
                resourceGroupName: null,
                resourceType: null,
                resourceName: null);

            var requestUri = this.GetResourceManagementRequestUri(
                resourceId: resourceId,
                action: "resources",
                top: top == null ? null : string.Format("$top={0}", top.Value),
                odataQuery: string.IsNullOrWhiteSpace(filter) ? null : string.Format("$filter={0}", filter),
                apiVersion: apiVersion);

            return this.SendRequestAsync<ResponseWithContinuation<TType[]>>(
                httpMethod: HttpMethod.Get,
                requestUri: requestUri,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get all the resources in a single resource group.
        /// </summary>
        /// <param name="subscriptionId">The subscription Id.</param>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="cancellationToken"></param>
        /// <param name="top">The number of resources to fetch.</param>
        /// <param name="filter">The filter query.</param>
        public Task<ResponseWithContinuation<TType[]>> ListResources<TType>(
            Guid subscriptionId,
            string resourceGroupName,
            string apiVersion,
            CancellationToken cancellationToken,
            int? top = null,
            string filter = null)
        {
            var resourceId = ResourceIdUtility.GetResourceId(
                subscriptionId: subscriptionId,
                resourceGroupName: resourceGroupName,
                resourceType: null,
                resourceName: null);

            var requestUri = this.GetResourceManagementRequestUri(
                resourceId: resourceId,
                action: "resources",
                top: top == null ? null : string.Format("$top={0}", top.Value),
                odataQuery: string.IsNullOrWhiteSpace(filter) ? null : string.Format("$filter={0}", filter),
                apiVersion: apiVersion);

            return this.SendRequestAsync<ResponseWithContinuation<TType[]>>(
                httpMethod: HttpMethod.Get,
                requestUri: requestUri,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get the next batch of resource from a <see cref="ResponseWithContinuation{TType}"/> object's next link.
        /// </summary>
        /// <param name="nextLink">The next link used to get the rest of the results.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the request.</param>
        public Task<ResponseWithContinuation<TType[]>> ListNextBatch<TType>(
            string nextLink,
            CancellationToken cancellationToken)
        {
            var requestUri = new Uri(nextLink);

            return this.SendRequestAsync<ResponseWithContinuation<TType[]>>(
                httpMethod: HttpMethod.Get,
                requestUri: requestUri,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get a single resource.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the request.</param>
        /// <param name="odataQuery">The OData query.</param> 
        public async Task<HttpStatusCode> HeadResource(
            string resourceId,
            string apiVersion,
            CancellationToken cancellationToken,
            string odataQuery = null)
        {
            var requestUri = this.GetResourceManagementRequestUri(
                resourceId: resourceId,
                apiVersion: apiVersion,
                odataQuery: odataQuery);

            var responseMessage = await this
                .SendRequestAsync(
                    httpMethod: HttpMethod.Head,
                    requestUri: requestUri,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            return responseMessage.StatusCode;
        }

        /// <summary>
        /// Get a single resource.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the request.</param>
        /// <param name="odataQuery">The OData query.</param> 
        public Task<TType> GetResource<TType>(
            string resourceId,
            string apiVersion,
            CancellationToken cancellationToken,
            string odataQuery = null)
        {
            var requestUri = this.GetResourceManagementRequestUri(
                resourceId: resourceId,
                apiVersion: apiVersion,
                odataQuery: odataQuery);

            return this.SendRequestAsync<TType>(
                httpMethod: HttpMethod.Get,
                requestUri: requestUri,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get a the operation result.
        /// </summary>
        /// <param name="operationUri">The operation <see cref="Uri"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the request.</param>
        public Task<OperationResult> GetOperationResult(
            Uri operationUri,
            CancellationToken cancellationToken)
        {
            return this.PerformOperationAsync(
                httpMethod: HttpMethod.Get,
                requestUri: operationUri,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get the azure async operation resource.
        /// </summary>
        /// <param name="operationUri">The operation <see cref="Uri"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the request.</param>
        public Task<AzureAsyncOperationResource> GetAzureAsyncOperationResource(
            Uri operationUri,
            CancellationToken cancellationToken)
        {
            return this.SendRequestAsync<AzureAsyncOperationResource>(
                 httpMethod: HttpMethod.Get,
                 requestUri: operationUri,
                 cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get a nested resource.
        /// </summary>
        /// <param name="operationUri">The operation <see cref="Uri"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the request.</param>
        public Task<OperationResult> GetOperationResult<TType>(
            Uri operationUri,
            CancellationToken cancellationToken)
        {
            return this.PerformOperationAsync(
                httpMethod: HttpMethod.Get,
                requestUri: operationUri,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Put a single resource.
        /// </summary>
        /// <param name="resourceId">The subscription Id.</param>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="resource">The resource to put.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the request.</param>
        /// <param name="odataQuery">The OData query.</param>
        public Task<OperationResult> PutResource(
            string resourceId,
            string apiVersion,
            JToken resource,
            CancellationToken cancellationToken,
            string odataQuery = null)
        {
            var requestUri = this.GetResourceManagementRequestUri(
                resourceId: resourceId,
                apiVersion: apiVersion,
                odataQuery: odataQuery);

            return this.PerformOperationAsync(
                httpMethod: HttpMethod.Put,
                requestUri: requestUri,
                content: resource,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get a nested resource.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="resource">The resource to put.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the request.</param>
        /// <param name="odataQuery">The OData query.</param>
        public Task<OperationResult> PatchResource(
            string resourceId,
            string apiVersion,
            JToken resource,
            CancellationToken cancellationToken,
            string odataQuery = null)
        {
            var requestUri = this.GetResourceManagementRequestUri(
                resourceId: resourceId,
                apiVersion: apiVersion,
                odataQuery: odataQuery);

            return this.PerformOperationAsync(
                httpMethod: HttpMethodExt.Patch,
                requestUri: requestUri,
                content: resource,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get a nested resource.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the request.</param>
        /// <param name="odataQuery">The OData query.</param>
        public Task<OperationResult> DeleteResource(
            string resourceId,
            string apiVersion,
            CancellationToken cancellationToken,
            string odataQuery = null)
        {
            var requestUri = this.GetResourceManagementRequestUri(
                resourceId: resourceId,
                apiVersion: apiVersion,
                odataQuery: odataQuery);

            return this.PerformOperationAsync(
                httpMethod: HttpMethod.Delete,
                requestUri: requestUri,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get a nested resource.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the request.</param>
        /// <param name="odataQuery">The OData query.</param>
        /// <param name="parameters">The parameters to pass.</param>
        public Task<OperationResult> InvokeActionOnResource(
            string resourceId,
            string action,
            string apiVersion,
            CancellationToken cancellationToken,
            string odataQuery = null,
            JObject parameters = null)
        {
            var requestUri = this.GetResourceManagementRequestUri(
                resourceId: resourceId,
                apiVersion: apiVersion,
                action: action,
                odataQuery: odataQuery);

            return this.PerformOperationAsync(
                httpMethod: HttpMethod.Post,
                requestUri: requestUri,
                content: parameters,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get a nested resource.
        /// </summary>
        /// <typeparam name="TResult">The type of the result</typeparam>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="apiVersion">The API version to use.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the request.</param>
        /// <param name="odataQuery">The OData query.</param>
        /// <param name="parameters">The parameters to pass.</param>
        public Task<OperationResult> InvokeActionOnResource<TResult>(
            string resourceId,
            string action,
            string apiVersion,
            CancellationToken cancellationToken,
            string odataQuery = null,
            JToken parameters = null)
        {
            var requestUri = this.GetResourceManagementRequestUri(
                resourceId: resourceId,
                apiVersion: apiVersion,
                action: action,
                odataQuery: odataQuery);

            return this.PerformOperationAsync(
                httpMethod: HttpMethod.Post,
                requestUri: requestUri,
                content: parameters,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Generates a resource management request <see cref="Uri"/> based on the input parameters. Supports both subscription and tenant level resource and the condensed resource type and name format.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="apiVersion">The API version.</param>
        /// <param name="action">The action.</param>
        /// <param name="odataQuery">The OData query.</param>
        /// <param name="top">Top resources - used in list queries.</param>
        public Uri GetResourceManagementRequestUri(
            string resourceId,
            string apiVersion,
            string action = null,
            string odataQuery = null,
            string top = null)
        {
            var resourceIdStringBuilder = new StringBuilder(resourceId.CoalesceString().TrimEnd('/'));

            if (!string.IsNullOrWhiteSpace(action))
            {
                resourceIdStringBuilder.AppendFormat("/{0}", action);
            }

            var parts = new[]
            {
                top,
                odataQuery,
                string.Format("api-version={0}", apiVersion)
            };

            var queryString = parts.Where(part => !string.IsNullOrWhiteSpace(part)).ConcatStrings("&");

            resourceIdStringBuilder.AppendFormat("?{0}", queryString);

            var relativeUri = resourceIdStringBuilder.ToString()
                .Select(character => char.IsWhiteSpace(character) ? "%20" : character.ToString())
                .ConcatStrings();

            return new Uri(baseUri: this.EndpointUri, relativeUri: relativeUri);
        }
    }
}
