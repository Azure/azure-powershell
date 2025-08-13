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

using Microsoft.Azure.Management.Sql.DataSyncV2.Models;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.DataSync.Model
{
    /// <summary>
    /// Helper class for constructing DataSyncParticipantIdentity objects.
    /// This class is static because it only provides stateless utility methods
    /// and should not be instantiated. Can be called for both Sync Group and Sync Member scenarios.
    /// </summary>
    public static class AzureSqlSyncIdentityHelper
    {
        /// <summary>
        /// Creates a DataSyncParticipantIdentity for a user-assigned managed identity.
        /// </summary>
        /// <param name="identityResourceId">The resource ID of the user-assigned managed identity.</param>
        /// <returns>A DataSyncParticipantIdentity object configured for user-assigned identity.</returns>
        public static DataSyncParticipantIdentity CreateUserAssignedIdentity(string identityResourceId)
        {
            return new DataSyncParticipantIdentity
            {
                Type = "UserAssigned",
                UserAssignedIdentities = new Dictionary<string, DataSyncParticipantUserAssignedIdentity>
                {
                    [identityResourceId] = new DataSyncParticipantUserAssignedIdentity()
                }
            };
        }
    }
}