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

using Microsoft.Azure.Management.Sql.Models;
using System;
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
        /// Constructs a <see cref="DataSyncParticipantIdentity"/> of type "UserAssigned"
        /// with an optional UAMI to add and an optional UAMI to remove.
        /// </summary>
        /// <param name="addResourceId">
        /// A single UAMI resource ID to add. If null or empty, no UAMI is added.
        /// </param>
        /// <param name="removeResourceId">
        /// A single UAMI resource ID to remove. If null, no UAMI is removed (mapped to null in the dictionary).
        /// </param>
        /// <returns>
        /// A <see cref="DataSyncParticipantIdentity"/> object of type "UserAssigned" containing a dictionary of user-assigned identities:
        /// - Key = UAMI resource ID
        /// - Value = <see cref="DataSyncParticipantUserAssignedIdentity"/> for addition, or <c>null</c> for removal
        /// </returns>
        public static DataSyncParticipantIdentity CreateUserAssignedIdentity(
            string addResourceId,
            string removeResourceId = null)  // default null ensures backward compatibility
        {
            var userAssignedDict = new Dictionary<string, DataSyncParticipantUserAssignedIdentity>();

            if (!string.IsNullOrEmpty(addResourceId))
            {
                userAssignedDict[addResourceId] = new DataSyncParticipantUserAssignedIdentity();
            }

            if (!string.IsNullOrEmpty(removeResourceId))
            {
                userAssignedDict[removeResourceId] = null;
            }

            return new DataSyncParticipantIdentity
            {
                Type = "UserAssigned",
                UserAssignedIdentities = userAssignedDict
            };
        }
    }
}