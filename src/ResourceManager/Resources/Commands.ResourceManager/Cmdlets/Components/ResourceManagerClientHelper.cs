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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.RestClients;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Helper class for constructing <see cref="ResourceManagerRestRestClient"/>.
    /// </summary>
    internal static class ResourceManagerClientHelper
    {
        /// <summary>
        /// Gets a new instance of the <see cref="ResourceManagerRestRestClient"/>.
        /// </summary>
        /// <param name="context">The azure profile.</param>
        internal static ResourceManagerRestRestClient GetResourceManagerClient(AzureContext context, Dictionary<string, string> cmdletHeaderValues = null)
        {
            var endpoint = context.Environment.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);

            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw new ApplicationException(
                    "The endpoint for the Azure Resource Manager service is not set. Please report this issue via GitHub or contact Microsoft customer support.");
            }

            var endpointUri = new Uri(endpoint, UriKind.Absolute);

            return new ResourceManagerRestRestClient(
                endpointUri: endpointUri,
                httpClientHelper: HttpClientHelperFactory.Instance
                .CreateHttpClientHelper(
                        credentials: AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context),
                        headerValues: AzureSession.ClientFactory.UserAgents,
                        cmdletHeaderValues: cmdletHeaderValues));
        }
    }
}
