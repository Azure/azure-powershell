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

namespace Microsoft.Azure.Commands.Common.Authentication.Models
{
    /// <summary>
    /// Custom configuration for Hyak cleints
    /// </summary>
    public interface IHyakClientAction
    {
        /// <summary>
        /// Apply the custom configuration to a Hyak client
        /// </summary>
        /// <typeparam name="TClient">The client type</typeparam>
        /// <param name="client">The client to apply configuration to</param>
        /// <param name="profile">The curent container for Azure information</param>
        /// <param name="endpoint">The named endpoint the client is targeting</param>
        void Apply<TClient>(TClient client, IAzureContextContainer profile, string endpoint) where TClient : ServiceClient<TClient>;
    }
}
