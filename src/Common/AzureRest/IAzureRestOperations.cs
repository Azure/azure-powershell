using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Internal.Common
{
    /// <summary>
    /// AzureRest operations.
    /// </summary>
    public partial interface IAzureRestOperations
    {
        /// <summary>
        /// Support universal HTTP request
        /// </summary>
        /// <typeparam name="T">Type of return object</typeparam>
        /// <param name="method">Http Method</param>
        /// <param name="path">The path compoment in URL</param>
        /// <param name="queries">The queries compoment in URL</param>
        /// <param name="fragment">The fragment compoment in URL</param>
        /// <param name="content">The content in request body</param>
        /// <param name="customHeaders">The headers that will be added to request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<T>> BeginHttpMessagesAsync<T>(HttpMethod method, string path, IDictionary<string, IList<string>> queries = null, string fragment = null, Object content = null, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// GET request to resource URI
        /// </summary>
        /// <typeparam name="T">Type of return object</typeparam>
        /// <param name="resourceUri">
        /// URI represents resource and correlated. Use the format
        /// /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}
        /// /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}/...
        /// </param>
        /// <param name="apiVersion">The API version to use for the operation.</param>
        /// <param name="customHeaders">The headers that will be added to request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<T> BeginHttpGetMessagesAsync<T>(string resourceUri, string apiVersion, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// DELETE request to resource URI
        /// </summary>
        /// <param name="resourceUri">
        /// URI represents resource and correlated. Use the format
        /// /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}
        /// /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}/...
        /// </param>
        /// <param name="apiVersion">The API version to use for the operation.</param>
        /// <param name="customHeaders">The headers that will be added to request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task BeginHttpDeleteMessagesAsync(string resourceUri, string apiVersion, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update(PUT, POST, PATCH) request to resource URI
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">Http Method</param>
        /// <param name="resourceUri">
        /// URI represents resource and correlated. Use the format
        /// /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}
        /// /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}/...
        /// </param>
        /// <param name="apiVersion">The API version to use for the operation.</param>
        /// <param name="content">The content in request body</param>
        /// <param name="customHeaders">The headers that will be added to request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<T> BeginHttpUpdateMessagesAsync<T>(HttpMethod method, string resourceUri, string apiVersion, Object content, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        [Obsolete("GetResouce<T> is deprecated, please use GetResource<T> instead.", true)]
        T GetResouce<T>(string resourceId, string apiVersion, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        [Obsolete("GetResouceList<T> is deprecated, please use GetResourceList<T> instead.", true)]
        List<T> GetResouceList<T>(string resourceUri, string apiVersion, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        [Obsolete("GetResoucePage<T> is deprecated, please use GetResourcePage<T> instead.", true)]
        P GetResoucePage<P, T>(string resourceUri, string apiVersion, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken)) where P : IPage<T>;

        [Obsolete("DeleteResouce is deprecated, please use DeleteResource instead.", true)]
        void DeleteResouce(string resourceUri, string apiVersion, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        [Obsolete("PutResouce<T> is deprecated, please use PutResource<T> instead.", true)]
        T PutResouce<T>(string resourceUri, string apiVersion, Object content, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        [Obsolete("PostResouce<T> is deprecated, please use PostResource<T> instead.", true)]
        T PostResouce<T>(string resourceUri, string apiVersion, Object content, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        [Obsolete("PatchResouce<T> is deprecated, please use PatchResource<T> instead.", true)]
        T PatchResouce<T>(string resourceUri, string apiVersion, Object content, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        T GetResource<T>(string resourceId, string apiVersion, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        List<T> GetResourceList<T>(string resourceUri, string apiVersion, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        P GetResourcePage<P, T>(string resourceUri, string apiVersion, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken)) where P : IPage<T>;

        void DeleteResource(string resourceUri, string apiVersion, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        T PutResource<T>(string resourceUri, string apiVersion, Object content, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        T PostResource<T>(string resourceUri, string apiVersion, Object content, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        T PatchResource<T>(string resourceUri, string apiVersion, Object content, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /*Generic Section*/

        /// <summary>
        /// Support universal HTTP request
        /// </summary>
        /// <param name="method">Http Method</param>
        /// <param name="path">The path compoment in URL</param>
        /// <param name="queries">The queries compoment in URL</param>
        /// <param name="fragment">The fragment compoment in URL</param>
        /// <param name="content">The content in request body</param>
        /// <param name="customHeaders">The headers that will be added to request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<string>> BeginHttpMessagesAsyncWithFullResponse(HttpMethod method, string path, IDictionary<string, IList<string>> queries = null, string fragment = null, Object content = null, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// GET request to resource URI
        /// </summary>
        /// <param name="resourceUri">
        /// URI represents resource and correlated. Use the format
        /// /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}
        /// /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}/...
        /// </param>
        /// <param name="apiVersion">The API version to use for the operation.</param>
        /// <param name="customHeaders">The headers that will be added to request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<string>> BeginHttpGetMessagesAsyncWithFullResponse(string resourceUri, string apiVersion, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// DELETE request to resource URI
        /// </summary>
        /// <param name="resourceUri">
        /// URI represents resource and correlated. Use the format
        /// /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}
        /// /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}/...
        /// </param>
        /// <param name="apiVersion">The API version to use for the operation.</param>
        /// <param name="customHeaders">The headers that will be added to request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<string>> BeginHttpDeleteMessagesAsyncWithFullResponse(string resourceUri, string apiVersion, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update(PUT, POST, PATCH) request to resource URI
        /// </summary>
        /// <param name="method">Http Method</param>
        /// <param name="resourceUri">
        /// URI represents resource and correlated. Use the format
        /// /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}
        /// /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}/...
        /// </param>
        /// <param name="apiVersion">The API version to use for the operation.</param>
        /// <param name="content">The content in request body</param>
        /// <param name="customHeaders">The headers that will be added to request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<string>> BeginHttpUpdateMessagesAsyncWithFullResponse(HttpMethod method, string resourceUri, string apiVersion, Object content, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        AzureOperationResponse<string> GetResourceWithFullResponse(string resourceId, string apiVersion, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        AzureOperationResponse<string> DeleteResourceWithFullResponse(string resourceUri, string apiVersion, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        AzureOperationResponse<string> PutResourceWithFullResponse(string resourceUri, string apiVersion, Object content, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        AzureOperationResponse<string> PostResourceWithFullResponse(string resourceUri, string apiVersion, Object content, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        AzureOperationResponse<string> PatchResourceWithFullResponse(string resourceUri, string apiVersion, Object content, IDictionary<string, IList<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
