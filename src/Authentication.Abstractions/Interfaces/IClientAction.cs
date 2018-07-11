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

using Microsoft.Rest;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Common.Authentication.Models
{
    /// <summary>
    /// Custom client configuration for Hyak and AutoRest clients
    /// </summary>
    public interface IClientAction: IHyakClientAction
    {
        /// <summary>
        /// The client factory for clients
        /// </summary>
        IClientFactory ClientFactory { get; set; }

        /// <summary>
        /// Apply the client action to the given AutoRest client
        /// </summary>
        /// <typeparam name="TClient">The type of the AutoRest client</typeparam>
        /// <param name="client">The client to apply this action to</param>
        /// <param name="profile">The current container for credentials and target account, subscription, and tenant information</param>
        /// <param name="endpoint">The named endpoint the client targets</param>
        void ApplyArm<TClient>(TClient client, IAzureContextContainer profile, string endpoint) where TClient :ServiceClient<TClient>;
    }
}
