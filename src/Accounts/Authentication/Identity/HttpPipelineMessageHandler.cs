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
//

using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    /// <summary>
    /// An HttpMessageHandler which delegates SendAsync to a specified HttpPipeline.
    /// </summary>
    internal class HttpPipelineMessageHandler : HttpMessageHandler
    {
        private readonly HttpPipeline _pipeline;

        public HttpPipelineMessageHandler(HttpPipeline pipeline)
        {
            _pipeline = pipeline;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Request pipelineRequest = await ToPipelineRequestAsync(request).ConfigureAwait(false);

            Response pipelineResponse = await _pipeline.SendRequestAsync(pipelineRequest, cancellationToken).ConfigureAwait(false);

            return ToHttpResponseMessage(pipelineResponse);
        }

        private async Task<Request> ToPipelineRequestAsync(HttpRequestMessage request)
        {
            Request pipelineRequest = _pipeline.CreateRequest();

            pipelineRequest.Method = RequestMethod.Parse(request.Method.Method);

            pipelineRequest.Uri.Reset(request.RequestUri);

            pipelineRequest.Content = await ToPipelineRequestContentAsync(request.Content).ConfigureAwait(false);

            foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
            {
                foreach (var value in header.Value)
                {
                    pipelineRequest.Headers.Add(header.Key, value);
                }
            }

            if (request.Content != null)
            {
                foreach (System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.IEnumerable<string>> header in request.Content.Headers)
                {
                    foreach (var value in header.Value)
                    {
                        pipelineRequest.Headers.Add(header.Key, value);
                    }
                }
            }

            return pipelineRequest;
        }

        private static HttpResponseMessage ToHttpResponseMessage(Response response)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage
            {
                StatusCode = (HttpStatusCode)response.Status
            };
            if (response.ContentStream != null)
            {
                responseMessage.Content = new StreamContent(response.ContentStream);
            }

            foreach (HttpHeader header in response.Headers)
            {
                if (response.Headers.TryGetValues(header.Name, out IEnumerable<string> values))
                {
                    if (!responseMessage.Headers.TryAddWithoutValidation(header.Name, values))
                    {
                        if ((responseMessage.Content == null) || !responseMessage.Content.Headers.TryAddWithoutValidation(header.Name, values))
                        {
                            throw new InvalidOperationException("Unable to add header to response or content");
                        }
                    }
                }
            }

            return responseMessage;
        }

        private static async Task<RequestContent> ToPipelineRequestContentAsync(HttpContent content)
        {
            if (content != null)
            {
                return RequestContent.Create(await content.ReadAsStreamAsync().ConfigureAwait(false));
            }

            return null;
        }
    }
}
