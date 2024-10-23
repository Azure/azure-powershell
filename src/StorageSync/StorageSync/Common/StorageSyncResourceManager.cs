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

using Commands.StorageSync.Interop.Clients;
using Commands.StorageSync.Interop.DataObjects;
using Commands.StorageSync.Interop.Interfaces;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;
using Microsoft.Azure.Commands.StorageSync.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity;
using Microsoft.Win32;
using System;

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    /// <summary>
    /// Class StorageSyncResourceManager.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Interfaces.IStorageSyncResourceManager" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Interfaces.IStorageSyncResourceManager" />
    public class StorageSyncResourceManager : IStorageSyncResourceManager
    {
        public StorageSyncResourceManager(IServerManagedIdentityProvider serverManagedIdentityProvider)
        {
            ServerManagedIdentityProvider = serverManagedIdentityProvider;
        }

        /// <summary>
        /// Creates the ecs management.
        /// </summary>
        /// <returns>IEcsManagement.</returns>
        public IEcsManagement CreateEcsManagement() => new EcsManagementInteropClient();

        public IServerManagedIdentityProvider ServerManagedIdentityProvider { get; private set; }

        /// <summary>
        /// Creates the ecs management.
        /// </summary>
        /// <returns>IEcsManagement.</returns>
        public ISyncServerRegistration CreateSyncServerManagement() => new SyncServerRegistrationClient(CreateEcsManagement(), ServerManagedIdentityProvider);

        /// <summary>
        /// Gets the afs agent installer path.
        /// </summary>
        /// <param name="afsAgentInstallerPath">The afs agent installer path.</param>
        /// <returns>System.String.</returns>
        public bool TryGetAfsAgentInstallerPath(out string afsAgentInstallerPath)
        {
            afsAgentInstallerPath = null;

            if (!RegistryUtility.TryGetValue<string>(StorageSyncConstants.AfsAgentInstallerPathRegistryKeyValueName, StorageSyncConstants.AfsAgentRegistryKey, out afsAgentInstallerPath, RegistryValueKind.String, RegistryValueOptions.None))
            {
                if (!RegistryUtility.TryGetValue<string>(StorageSyncConstants.AfsAgentInstallerPathRegistryKeyValueName, StorageSyncConstants.AfsAgentRegistryKey, out afsAgentInstallerPath, RegistryValueKind.String, RegistryValueOptions.None, RegistryView.Registry64))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <returns>Guid.</returns>
        public Guid GetGuid() => Guid.NewGuid();

        /// <summary>
        /// Gets the afs agent version.
        /// </summary>
        /// <param name="afsAgentVersion">The afs agent version.</param>
        /// <returns>System.String.</returns>
        public bool TryGetAfsAgentVersion(out string afsAgentVersion)
        {
            afsAgentVersion = null;

            if (!RegistryUtility.TryGetValue<string>(StorageSyncConstants.AfsAgentVersionRegistryKeyValueName, StorageSyncConstants.AfsAgentRegistryKey, out afsAgentVersion, RegistryValueKind.String, RegistryValueOptions.None))
            {
                if (!RegistryUtility.TryGetValue<string>(StorageSyncConstants.AfsAgentVersionRegistryKeyValueName, StorageSyncConstants.AfsAgentRegistryKey, out afsAgentVersion, RegistryValueKind.String, RegistryValueOptions.None, RegistryView.Registry64))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Updates the server registration data.
        /// </summary>
        /// <param name="pServerRegistrationData">The p server registration data.</param>
        /// <returns>ServerRegistrationData.</returns>
        public ServerRegistrationData UpdateServerRegistrationData(ServerRegistrationData pServerRegistrationData) => pServerRegistrationData;

        /// <summary>
        /// Waits for access propogation.
        /// </summary>
        public void Wait()
        {
            System.Threading.Thread.Sleep(40 * 1000);
        }

        /// <summary>
        /// Gets the tenant identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetTenantId() => null;

        /// <summary>
        /// Get Service Principal Or Null
        /// </summary>
        /// <returns>MicrosoftGraphServicePrincipal</returns>
        public MicrosoftGraphServicePrincipal GetServicePrincipalOrNull() => null;
    }
}