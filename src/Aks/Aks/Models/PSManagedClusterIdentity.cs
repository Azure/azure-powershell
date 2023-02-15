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
    /// Identity for the managed cluster.
    /// </summary>
    public partial class PSManagedClusterIdentity
    {
        /// <summary>
        /// Gets the principal id of the system assigned identity which is used
        /// by master components.
        /// </summary>
        public string PrincipalId { get; private set; }

        /// <summary>
        /// Gets the tenant id of the system assigned identity which is used by
        /// master components.
        /// </summary>
        public string TenantId { get; private set; }

        /// <summary>
        /// Gets or sets the user identity associated with the managed cluster. This identity
        /// will be used in control plane. Only one user assigned identity is allowed.
        ///
        /// The keys must be ARM resource IDs in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        public IDictionary<string, PSManagedClusterIdentityUserAssignedIdentitiesValue> UserAssignedIdentities
        {
            get;
            set;
        }



        /// <summary>
        /// Gets or sets the type of identity used for the managed cluster.
        /// Type 'SystemAssigned' will use an implicitly created identity in
        /// master components and an auto-created user assigned identity in MC_
        /// resource group in agent nodes. Type 'None' will not use MSI for the
        /// managed cluster, service principal will be used instead. Possible
        /// values include: 'SystemAssigned', 'None', 'UserAssigned'
        /// </summary>
        public PSResourceIdentityType? Type { get; set; }
    }
}
