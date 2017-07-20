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

using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// A factory for authenticated and configured Hyak clients
    /// </summary>
    public interface IHyakClientFactory
    {
        /// <summary>
        /// Create a properly configured Hyak client using the given target Azure context and named endpoint
        /// </summary>
        /// <typeparam name="TClient">The client type to create</typeparam>
        /// <param name="context">The azure context to target</param>
        /// <param name="endpoint">The named endpoint the client shoulld target</param>
        /// <returns>A client properly authenticated in the given context, properly configured for use with Azure PowerShell, 
        /// targeting the given named endpoint in the targeted environment</returns>
        TClient CreateClient<TClient>(IAzureContext context, string endpoint) where TClient : ServiceClient<TClient>;

        /// <summary>
        /// Create a properly configured Hyak client using the given target Azure context and named endpoint
        /// </summary>
        /// <typeparam name="TClient">The client type to create</typeparam>
        /// <param name="profile">The container for azure target information</param>
        /// <param name="endpoint">The named endpoint the client shoulld target</param>
        /// <returns>A client properly authenticated in the given context, properly configured for use with Azure PowerShell, 
        /// targeting the given named endpoint in the targeted environment</returns>
        TClient CreateClient<TClient>(IAzureContextContainer profile, string endpoint) where TClient : ServiceClient<TClient>;

        /// <summary>
        /// Create a properly configured Hyak client using the given target Azure context and named endpoint
        /// </summary>
        /// <typeparam name="TClient">The client type to create</typeparam>
        /// <param name="profile">The container for azure target information</param>
        /// <param name="subscription">The azure subscription to target</param>
        /// <param name="endpoint">The named endpoint the client shoulld target</param>
        /// <returns>A client properly authenticated in the given context, properly configured for use with Azure PowerShell, 
        /// targeting the given named endpoint in the targeted environment</returns>
        TClient CreateClient<TClient>(IAzureContextContainer profile, IAzureSubscription subscription, string endpoint) where TClient : ServiceClient<TClient>;

        /// <summary>
        /// Create a properly configured Hyak client using the given target Azure context and named endpoint
        /// </summary>
        /// <typeparam name="TClient">The client type to create</typeparam>
        /// <param name="parameters">The custom parameters passed to the client constructor.  These parameters must 
        /// match an existing constructor for the client</param>
        /// <returns>A client properly configured for use with Azure PowerShell</returns>
        TClient CreateCustomClient<TClient>(params object[] parameters) where TClient : ServiceClient<TClient>;
    }
}
