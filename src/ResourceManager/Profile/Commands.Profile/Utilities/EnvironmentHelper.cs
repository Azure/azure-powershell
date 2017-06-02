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
        /// Retrieves the domain.
        /// </summary>
        /// <param name="portalEndpoint">The portal endpoint.</param>
        /// <returns>Domain</returns>
        internal static string RetrieveDomain(string portalEndpoint)
        {
            // Todo: Revisit this when azure metadata endpoint supports keyvault suffix and storage endpoints
            // Example format:: portal endpoint: "management.azure.com"; returns: "azure.com"
            return portalEndpoint.Replace(portalEndpoint.Split('.')[0], "").TrimEnd('/').TrimStart('.');
        }

        /// <summary>
        /// Retrieves the meta data endpoints.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        internal static async Task<MetadataResponse> RetrieveMetaDataEndpoints(string url)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                throw new ArgumentException("The ResourceManagement Endpoint provided was invalid.");
            }
            url = String.Concat(url.ToLower(), "/metadata/endpoints?api-version=1.0");
            MetadataResponse response = null;
            using (HttpClient client = new HttpClient())
            {
                string responseJson = await client.GetStringAsync(url).ConfigureAwait(false);
                response = JsonConvert.DeserializeObject<MetadataResponse>(responseJson);
            }
            return response;
        }
    }
}
