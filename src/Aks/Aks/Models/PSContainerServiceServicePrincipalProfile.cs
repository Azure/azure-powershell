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
using Microsoft.Azure.Management.ContainerService.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Aks.Models
{
    /// <summary>
    /// Information about a service principal identity for the cluster to use
    /// for manipulating Azure APIs. Either secret or keyVaultSecretRef must be
    /// specified.
    /// </summary>
    public partial class PSContainerServiceServicePrincipalProfile
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ContainerServiceServicePrincipalProfile class.
        /// </summary>
        public PSContainerServiceServicePrincipalProfile(){}

        /// <summary>
        /// Initializes a new instance of the
        /// ContainerServiceServicePrincipalProfile class.
        /// </summary>
        /// <param name="clientId">The ID for the service principal.</param>
        /// <param name="secret">The secret password associated with the
        /// service principal in plain text.</param>
        public PSContainerServiceServicePrincipalProfile(string clientId, string secret = default(string))
        {
            ClientId = clientId;
            Secret = secret;
        }

        /// <summary>
        /// Gets or sets the ID for the service principal.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the secret password associated with the service
        /// principal in plain text.
        /// </summary>
        public string Secret { get; set; }
    }
}