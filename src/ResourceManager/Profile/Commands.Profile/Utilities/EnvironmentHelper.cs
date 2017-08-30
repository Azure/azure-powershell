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

using Microsoft.Azure.Commands.Profile.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Hyak.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    public class EnvironmentHelper
    {
        /// <summary>
        /// Retrieves the domain.
        /// </summary>
        /// <param name="portalEndpoint">The portal endpoint.</param>
        /// <returns>Domain</returns>
        public virtual string RetrieveDomain(string portalEndpoint)
        {
            // Example format:: portal endpoint: "management.azure.com"; returns: "azure.com"
            if (string.IsNullOrEmpty(portalEndpoint))
            {
                throw new ArgumentException("Invalid Endpoint provided. Portal Endpoint cannot be null.");
            }

            string domainHost = new Uri(portalEndpoint).Host;
            if (string.IsNullOrEmpty(domainHost))
            {
                throw new ApplicationException("Invalid Endpoint provided. Portal Endpoint cannot be null.");
            }

            return domainHost.Replace(domainHost.Split('.')[0], "").TrimStart('.');
        }

        /// <summary>
        /// Retrieves the meta data endpoints.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public virtual async Task<MetadataResponse> RetrieveMetaDataEndpoints(string url)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                throw new ArgumentException("The ResourceManagement Endpoint provided was invalid.");
            }

            url = string.Concat(url.TrimEnd('/').ToLower(), "/metadata/endpoints?api-version=1.0");
            MetadataResponse response = null;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseJson = await client.GetAsync(url).ConfigureAwait(false);
                string content = responseJson.EnsureSuccessStatusCode().Content.ReadAsStringAsync().Result;

                try
                {
                    response = JsonConvert.DeserializeObject<MetadataResponse>(content);
                }
                catch (Exception ex)
                {
                    throw new JsonException(ex.Message);
                }
            }

            if ((null == response) || string.IsNullOrEmpty(response.GalleryEndpoint) || string.IsNullOrEmpty(response.GraphEndpoint)
                || string.IsNullOrEmpty(response.PortalEndpoint))
            {
                throw new CloudException("An error occurred while trying to retrieve metadata endpoints. Please try again later.");
            }

            if (null == response.authentication || string.IsNullOrEmpty(response.authentication.LoginEndpoint)
                || (response.authentication.Audiences.Any(string.IsNullOrEmpty)))
            {
                throw new CloudException("An error occurred while trying to retrieve metadata endpoints. Please try again later.");
            }

            return response;
        }
    }
}
