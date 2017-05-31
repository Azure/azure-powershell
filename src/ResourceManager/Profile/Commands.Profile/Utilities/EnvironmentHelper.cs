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

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    using Microsoft.Azure.Commands.Profile.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Hyak.Common;
    using Newtonsoft.Json;

    internal static class EnvironmentHelper
    {
        /// <summary>
        /// Gets the valid endpoint.
        /// </summary>
        /// <param name="armEndpoint">The arm endpoint.</param>
        /// <returns></returns>
        internal static string GetValidEndpoint(string armEndpoint)
        {
            if (!armEndpoint.Contains("https://"))
            {
                if (armEndpoint.Contains("http://"))
                {
                    armEndpoint = armEndpoint.Substring(7);
                    armEndpoint = "https://" + armEndpoint;
                }
                else
                {
                    armEndpoint = "https://" + armEndpoint;
                }
            }

            armEndpoint = armEndpoint.TrimEnd('/');

            return armEndpoint;
        }

        /// <summary>
        /// Retrieves the domain.
        /// </summary>
        /// <param name="portalEndpoint">The portal endpoint.</param>
        /// <returns>Domain</returns>
        internal static string RetrieveDomain(string portalEndpoint)
        {
            return portalEndpoint.Replace(portalEndpoint.Split('.')[0], "").TrimEnd('/').TrimStart('.');
        }

        /// <summary>
        /// Retrieves the meta data endpoints.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        internal static async Task<MetadataResponse> RetrieveMetaDataEndpoints(string url)
        {
            string validUrl = GetValidEndpoint(url);
            validUrl = String.Concat(validUrl.ToLower(), "/metadata/endpoints?api-version=1.0");
            MetadataResponse response = null;
            using (HttpClient client = new HttpClient())
            {
                // Create HTTP transport objects
                HttpRequestMessage httpRequest = null;
                try
                {
                    httpRequest = new HttpRequestMessage
                                  {
                                      Method = HttpMethod.Get,
                                      RequestUri = new Uri(validUrl)
                                  };

                    // Send Request
                    HttpResponseMessage httpResponse = null;
                    try
                    {
                        httpResponse = await client.SendAsync(httpRequest).ConfigureAwait(false);
                        HttpStatusCode statusCode = httpResponse.StatusCode;
                        if (statusCode != HttpStatusCode.OK)
                        {
                            CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                            throw ex;
                        }

                        if (statusCode == HttpStatusCode.OK)
                        {
                            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                            response = JsonConvert.DeserializeObject<MetadataResponse>(responseContent);
                        }
                    }
                    finally
                    {
                        httpResponse?.Dispose();
                    }
                }
                finally
                {
                    httpRequest?.Dispose();
                }
            }
            return response;
        }
    }
}
