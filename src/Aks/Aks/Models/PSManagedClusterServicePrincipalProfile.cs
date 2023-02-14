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


namespace Microsoft.Azure.Commands.Aks.Models
{
    /// <summary>
    /// Information about a service principal identity for the cluster to use
    /// for manipulating Azure APIs.
    /// </summary>
    public partial class PSManagedClusterServicePrincipalProfile
    {
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
