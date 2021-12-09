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

using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSManagedIdentity
    {
        public PSManagedIdentity(ManagedIdentity identity)
        {
            this.PrincipalId = identity?.PrincipalId;
            this.TenantId = identity?.TenantId;
            this.Type = identity?.Type;
            this.UserAssignedIdentities = identity?.UserAssignedIdentities;
        }

        /// <summary>
        /// Gets the principal ID of the workspace managed identity
        /// </summary>
        public string PrincipalId { get; }

        /// <summary>
        /// Gets the tenant ID of the workspace managed identity
        /// </summary>
        public Guid? TenantId { get; }

        /// <summary>
        /// Gets or sets the type of managed identity for the workspace.Possible values include: 'None', 'SystemAssigned','SystemAssigned,UserAssigned'
        /// </summary>
        public ResourceIdentityType? Type { get; set; }

        /// <summary>
        ///  Gets or sets the user assigned managed identities.
        /// </summary>
        public IDictionary<string, UserAssignedManagedIdentity> UserAssignedIdentities { get; set; }
    }
}