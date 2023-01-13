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

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Utilities
{
    internal static class HttpRequestMessageExtension
    {
        internal static HttpRequestMessage CloneAndDispose(this HttpRequestMessage original, System.Uri requestUri = null, System.Net.Http.HttpMethod method = null)
        {
            using (original)
            {
                return original.Clone(requestUri, method);
            }
        }

        internal static Task<HttpRequestMessage> CloneWithContentAndDispose(this HttpRequestMessage original, System.Uri requestUri = null, System.Net.Http.HttpMethod method = null)
        {
            using (original)
            {
                return original.CloneWithContent(requestUri, method);
            }
        }

        /// <summary>
        /// Clones an HttpRequestMessage (without the content)
        /// </summary>
        /// <param name="original">Original HttpRequestMessage (Will be diposed before returning)</param>
        /// <param name="requestUri"></param>
        /// <param name="method"></param>
        /// <returns>A clone of the HttpRequestMessage</returns>
        internal static HttpRequestMessage Clone(this HttpRequestMessage original, System.Uri requestUri = null, System.Net.Http.HttpMethod method = null)
        {
            var clone = new HttpRequestMessage
            {
                Method = method ?? original.Method,
                RequestUri = requestUri ?? original.RequestUri,
                Version = original.Version,
            };

            foreach (KeyValuePair<string, object> prop in original.Properties)
            {
                clone.Properties.Add(prop);
            }

            foreach (KeyValuePair<string, IEnumerable<string>> header in original.Headers)
            {
                /*
                **temporarily skip cloning telemetry related headers**
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
                */
                if (!"x-ms-unique-id".Equals(header.Key) && !"x-ms-client-request-id".Equals(header.Key) && !"CommandName".Equals(header.Key) && !"FullCommandName".Equals(header.Key) && !"ParameterSetName".Equals(header.Key) && !"User-Agent".Equals(header.Key))
                {
                    clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            return clone;
        }

        /// <summary>
        /// Clones an HttpRequestMessage (including the content stream and content headers) 
        /// </summary>
        /// <param name="original">Original HttpRequestMessage (Will be diposed before returning)</param>
        /// <param name="requestUri"></param>
        /// <param name="method"></param>
        /// <returns>A clone of the HttpRequestMessage</returns>
        internal static async Task<HttpRequestMessage> CloneWithContent(this HttpRequestMessage original, System.Uri requestUri = null, System.Net.Http.HttpMethod method = null)
        {
            var clone = original.Clone(requestUri, method);
            var stream = new System.IO.MemoryStream();
            if (original.Content != null)
            {
                await original.Content.CopyToAsync(stream).ConfigureAwait(false);
                stream.Position = 0;
                clone.Content = new StreamContent(stream);
                if (original.Content.Headers != null)
                {
                    foreach (var h in original.Content.Headers)
                    {
                        clone.Content.Headers.Add(h.Key, h.Value);
                    }
                }
            }
            return clone;
        }
    }
}
