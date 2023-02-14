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

namespace Microsoft.Azure.Commands.Aks.Models
{
    /// <summary>
    /// AADProfile specifies attributes for Azure Active Directory integration.
    /// </summary>
    public partial class PSManagedClusterAadProfile
    {
        /// <summary>
        /// Gets or sets whether to enable managed AAD.
        /// </summary>
        public bool? Managed { get; set; }
		
        /// <summary>
        /// Gets or sets whether to enable Azure RBAC for Kubernetes
        /// authorization.
        /// </summary>
        public bool? EnableAzureRBAC { get; set; }

        /// <summary>
        /// Gets or sets the list of AAD group object IDs that will have admin
        /// role of the cluster.
        /// </summary>
        public IList<string> AdminGroupObjectIDs { get; set; }

		
        /// <summary>
        /// Gets or sets the client AAD application ID.
        /// </summary>
        public string ClientAppID { get; set; }

        /// <summary>
        /// Gets or sets the server AAD application ID.
        /// </summary>
        public string ServerAppID { get; set; }

        /// <summary>
        /// Gets or sets the server AAD application secret.
        /// </summary>
        public string ServerAppSecret { get; set; }

        /// <summary>
        /// Gets or sets the AAD tenant ID to use for authentication. If not
        /// specified, will use the tenant of the deployment subscription.
        /// </summary>
        public string TenantID { get; set; }
    }
}
