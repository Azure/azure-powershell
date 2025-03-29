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

using Commands.StorageSync.Interop.DataObjects;
using Commands.StorageSync.Interop.Interfaces;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;
using System;

namespace Microsoft.Azure.Commands.StorageSync.Interfaces
{
    /// <summary>
    /// Interface IStorageSyncResourceManager
    /// </summary>
    public interface IStorageSyncResourceManager
    {
        /// <summary>
        /// Get Service Principal Or Null
        /// </summary>
        /// <returns>MicrosoftGraphServicePrincipal</returns>
        MicrosoftGraphServicePrincipal GetServicePrincipalOrNull();

        /// <summary>
        /// Creates the ecs management.
        /// </summary>
        /// <returns>IEcsManagement.</returns>
        IEcsManagement CreateEcsManagement();

        /// <summary>
        /// Creates the ecs management.
        /// </summary>
        /// <returns>IEcsManagement.</returns>
        ISyncServerRegistration CreateSyncServerManagement();

        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <returns>Guid.</returns>
        Guid GetGuid();

        /// <summary>
        /// Gets the afs agent installer path.
        /// </summary>
        /// <param name="afsAgentInstallerPath">The afs agent installer path.</param>
        /// <returns>System.String.</returns>
        bool TryGetAfsAgentInstallerPath(out string afsAgentInstallerPath);

        /// <summary>
        /// Gets the afs agent version.
        /// </summary>
        /// <param name="afsAgentVersion">The afs agent version.</param>
        /// <returns>System.String.</returns>
        bool TryGetAfsAgentVersion(out string afsAgentVersion);

        /// <summary>
        /// Updates the server registration data.
        /// </summary>
        /// <param name="pServerRegistrationData">The p server registration data.</param>
        /// <returns>ServerRegistrationData.</returns>
        ServerRegistrationData UpdateServerRegistrationData(ServerRegistrationData pServerRegistrationData);
        /// <summary>
        /// Waits for access propogation.
        /// </summary>
        void Wait();

        /// <summary>
        /// Gets the tenant identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetTenantId();
    }
}