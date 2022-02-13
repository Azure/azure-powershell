// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.ServiceFabric.Common
{
    using Microsoft.Azure.Management.ServiceFabric;
    using Microsoft.Azure.Management.ServiceFabric.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    internal static class ClusterOperations
    {
        public static async Task<AzureOperationResponse<Cluster>> BeginUpdateWithHttpMessagesAsync(this ServiceFabricManagementClient sfManagementClient, string resourceGroupName, string clusterName, dynamic parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (resourceGroupName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "resourceGroupName");
            }
            if (clusterName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "clusterName");
            }
            if (sfManagementClient.SubscriptionId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "sfManagementClient.SubscriptionId");
            }
            if (parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
            }

            string apiVersion = "2020-03-01";

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("clusterName", clusterName);
                tracingParameters.Add("apiVersion", apiVersion);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, sfManagementClient, "BeginUpdate", tracingParameters);
            }

            // Construct URL
            var baseUrl = sfManagementClient.BaseUri.AbsoluteUri;
            var url = new System.Uri(new System.Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceFabric/clusters/{clusterName}").ToString();
            url = url.Replace("{resourceGroupName}", System.Uri.EscapeDataString(resourceGroupName));
            url = url.Replace("{clusterName}", System.Uri.EscapeDataString(clusterName));
            url = url.Replace("{subscriptionId}", System.Uri.EscapeDataString(sfManagementClient.SubscriptionId));
            List<string> _queryParameters = new List<string>();
            if (apiVersion != null)
            {
                _queryParameters.Add(string.Format("api-version={0}", System.Uri.EscapeDataString(apiVersion)));
            }

            if (_queryParameters.Count > 0)
            {
                url += (url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }

            // Create HTTP transport objects
            var httpRequest = new HttpRequestMessage();
            HttpResponseMessage httpResponse = null;
            httpRequest.Method = new HttpMethod("PATCH");
            httpRequest.RequestUri = new System.Uri(url);

            // Set Headers
            if (sfManagementClient.GenerateClientRequestId != null && sfManagementClient.GenerateClientRequestId.Value)
            {
                httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }

            if (sfManagementClient.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", sfManagementClient.AcceptLanguage);
            }

            if (customHeaders != null)
            {
                foreach (var _header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(_header.Key))
                    {
                        httpRequest.Headers.Remove(_header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string requestContent = null;
            if (parameters != null)
            {
                var dynamicSerializationSettings = sfManagementClient.SerializationSettings.DeepCopy();
                dynamicSerializationSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();

                requestContent = Rest.Serialization.SafeJsonConvert.SerializeObject(parameters, dynamicSerializationSettings);
                httpRequest.Content = new StringContent(requestContent, System.Text.Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            }

            // Set Credentials
            if (sfManagementClient.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await sfManagementClient.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }

            cancellationToken.ThrowIfCancellationRequested();
            httpResponse = await sfManagementClient.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }

            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = null;
            if ((int)statusCode != 200 && (int)statusCode != 202)
            {
                var ex = new ErrorModelException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                try
                {
                    responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    ErrorModel _errorBody = Rest.Serialization.SafeJsonConvert.DeserializeObject<ErrorModel>(responseContent, sfManagementClient.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }

                ex.Request = new HttpRequestMessageWrapper(httpRequest, requestContent);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }

                httpRequest.Dispose();
                if (httpResponse != null)
                {
                    httpResponse.Dispose();
                }

                throw ex;
            }

            // Create Result
            var result = new AzureOperationResponse<Cluster>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }

            // Deserialize Response
            if ((int)statusCode == 200)
            {
                responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    result.Body = Rest.Serialization.SafeJsonConvert.DeserializeObject<Cluster>(responseContent, sfManagementClient.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    httpRequest.Dispose();
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", responseContent, ex);
                }
            }

            // Deserialize Response
            if ((int)statusCode == 202)
            {
                responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    result.Body = Rest.Serialization.SafeJsonConvert.DeserializeObject<Cluster>(responseContent, sfManagementClient.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    httpRequest.Dispose();
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", responseContent, ex);
                }
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }

            return result;
        }
    }
}
