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
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ErrorResponses;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

    /// <summary>
    /// A base class for Azure clients.
    /// </summary>
    public class ResourceManagerRestClientBase
    {
        /// <summary>
        /// The azure http client wrapper to use.
        /// </summary>
        private readonly HttpClientHelper httpClientHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceManagerRestClientBase"/> class.
        /// </summary>
        /// <param name="httpClientHelper">The azure http client wrapper to use.</param>
        public ResourceManagerRestClientBase(Components.HttpClientHelper httpClientHelper)
        {
            this.httpClientHelper = httpClientHelper;
        }

        /// <summary>
        /// Performs an operation and returns the result.
        /// </summary>
        /// <param name="httpMethod">The http method to use.</param>
        /// <param name="requestUri">The Uri of the operation.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected async Task<OperationResult> PerformOperationAsync(
            HttpMethod httpMethod,
            Uri requestUri,
            CancellationToken cancellationToken)
        {
            using (var response = await this
                .SendRequestAsync(
                    httpMethod: httpMethod,
                    requestUri: requestUri,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false))
            {
                return await this
                    .GetOperationResult(response: response)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Performs an operation and returns the result.
        /// </summary>
        /// <param name="httpMethod">The http method to use.</param>
        /// <param name="requestUri">The Uri of the operation.</param>
        /// <param name="content">The content.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected async Task<OperationResult> PerformOperationAsync(
            HttpMethod httpMethod,
            Uri requestUri,
            JObject content,
            CancellationToken cancellationToken)
        {
            using (var response = await this
                .SendRequestAsync(
                    httpMethod: httpMethod,
                    requestUri: requestUri,
                    content: content,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false))
            {
                return await this
                    .GetOperationResult(response: response)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Performs an operation and returns the result.
        /// </summary>
        /// <param name="httpMethod">The http method to use.</param>
        /// <param name="requestUri">The Uri of the operation.</param>
        /// <param name="content">The content.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected async Task<OperationResult> PerformOperationAsync(
            HttpMethod httpMethod,
            Uri requestUri,
            JToken content,
            CancellationToken cancellationToken)
        {
            using (var response = await this
                .SendRequestAsync(
                    httpMethod: httpMethod,
                    requestUri: requestUri,
                    content: content,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false))
            {
                return await this
                    .GetOperationResult(response: response)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Sends an HTTP request message and returns the result from the content of the response message.
        /// </summary>
        /// <typeparam name="TResponseType">The type of the result of response from the server.</typeparam>
        /// <param name="httpMethod">The http method to use.</param>
        /// <param name="requestUri">The Uri of the operation.</param>
        /// <param name="content">The content.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected async Task<TResponseType> SendRequestAsync<TResponseType>(
            HttpMethod httpMethod,
            Uri requestUri,
            JObject content,
            CancellationToken cancellationToken)
        {
            using (var response = await this
                .SendRequestAsync(httpMethod: httpMethod, requestUri: requestUri, content: content, cancellationToken: cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false))
            {
                return await response
                    .ReadContentAsJsonAsync<TResponseType>()
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Sends an HTTP request message and returns the result.
        /// </summary>
        /// <param name="httpMethod">The http method to use.</param>
        /// <param name="requestUri">The Uri of the operation.</param>
        /// <param name="content">The content.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected async Task<HttpResponseMessage> SendRequestAsync(
            HttpMethod httpMethod,
            Uri requestUri,
            JToken content,
            CancellationToken cancellationToken)
        {
            var contentString = content == null ? string.Empty : content.ToString();
            using (var httpContent = new StringContent(content: contentString, encoding: Encoding.UTF8, mediaType: "application/json"))
            using (var request = new HttpRequestMessage(method: httpMethod, requestUri: requestUri) { Content = httpContent })
            {
                return await this.SendRequestAsync(request: request, cancellationToken: cancellationToken)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Sends an HTTP request message and returns the result.
        /// </summary>
        /// <typeparam name="TResponseType">The type of the result of response from the server.</typeparam>
        /// <param name="httpMethod">The http method to use.</param>
        /// <param name="requestUri">The Uri of the operation.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected async Task<TResponseType> SendRequestAsync<TResponseType>(
            HttpMethod httpMethod,
            Uri requestUri,
            CancellationToken cancellationToken)
        {
            using (var response = await this
                .SendRequestAsync(httpMethod: httpMethod, requestUri: requestUri, cancellationToken: cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false))
            {
                return await response
                    .ReadContentAsJsonAsync<TResponseType>()
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Sends an HTTP request message and returns the result.
        /// </summary>
        /// <param name="httpMethod">The http method to use.</param>
        /// <param name="requestUri">The Uri of the operation.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected async Task<HttpResponseMessage> SendRequestAsync(
            HttpMethod httpMethod,
            Uri requestUri,
            CancellationToken cancellationToken)
        {
            using (var request = new HttpRequestMessage(method: httpMethod, requestUri: requestUri))
            {
                return await this.SendRequestAsync(request: request, cancellationToken: cancellationToken)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Sends an HTTP request message and returns the result.
        /// </summary>
        /// <param name="request">The http request to send.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            using (var httpClient = this.httpClientHelper.CreateHttpClient())
            {
                try
                {
                    var response = await httpClient
                        .SendAsync(request: request, cancellationToken: cancellationToken)
                        .ConfigureAwait(continueOnCapturedContext: false);

                    if (!response.StatusCode.IsSuccessfulRequest())
                    {
                        var errorResponse = await ResourceManagerRestClientBase
                            .TryReadErrorResponseMessage(response, rewindContentStream: true)
                            .ConfigureAwait(continueOnCapturedContext: false);

                        var message = await ResourceManagerRestClientBase
                            .GetErrorMessage(request: request, response: response, errorResponse: errorResponse)
                            .ConfigureAwait(continueOnCapturedContext: false);

                        throw new ErrorResponseMessageException(
                            httpStatus: response.StatusCode,
                            errorResponseMessage: errorResponse,
                            errorMessage: message);
                    }

                    return response;
                }
                catch (Exception exception)
                {
                    if (exception is OperationCanceledException && !cancellationToken.IsCancellationRequested)
                    {
                        throw new Exception(ProjectResources.OperationFailedWithTimeOut);
                    }

                    throw;
                }
            }
        }

        /// <summary>
        /// Gets the error message for the exception based on the <paramref name="response"/> and <paramref name="errorResponse"/> parameters.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> that was sent.</param>
        /// <param name="response">The <see cref="HttpResponseMessage"/> to read.</param>
        /// <param name="errorResponse">The <see cref="ErrorResponseMessage"/>.</param>
        /// <returns></returns>
        private static Task<string> GetErrorMessage(HttpRequestMessage request, HttpResponseMessage response, ErrorResponseMessage errorResponse)
        {
            return errorResponse != null
                 ? Task.FromResult(string.Format("{0} : {1}", errorResponse.Error.Code, errorResponse.Error.Message))
                 : response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Tries to read the response as an <see cref="ErrorResponseMessage"/> object.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/> to read.</param>
        /// <param name="rewindContentStream">Rewind content stream if set to true.</param>
        private static async Task<ErrorResponseMessage> TryReadErrorResponseMessage(HttpResponseMessage response, bool rewindContentStream = false)
        {
            try
            {
                return await response
                    .ReadContentAsJsonAsync<ErrorResponseMessage>(rewindContentStream: rewindContentStream)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
            catch (FormatException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (JsonException)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets an <see cref="OperationResult"/> from the content of the <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/></param>
        private async Task<OperationResult> GetOperationResult(HttpResponseMessage response)
        {
            var operationResult = new OperationResult
            {
                Value = await response
                    .ReadContentAsStringAsync()
                    .ConfigureAwait(continueOnCapturedContext: false),
            };

            this.PopulateOperationResult(response: response, operationResult: operationResult);
            return operationResult;
        }


        /// <summary>
        /// Populates the operation result.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="operationResult">The operation result.</param>
        private void PopulateOperationResult(HttpResponseMessage response, OperationResult operationResult)
        {
            operationResult.AzureAsyncOperationUri = response.Headers.GetAzureAsyncOperation();
            operationResult.LocationUri = response.Headers.Location;
            operationResult.PercentComplete = response.Headers.GetAzureAzyncOperationPercentComplete();
            operationResult.RetryAfter = response.Headers.RetryAfter == null ? null : response.Headers.RetryAfter.Delta;
            operationResult.HttpStatusCode = response.StatusCode;
            operationResult.OperationUri = response.RequestMessage.RequestUri;
        }

    }
}
