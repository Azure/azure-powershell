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
using Microsoft.Azure.Management.StorageSync.Models;
using System;

namespace Commands.StorageSync.Interop.Interfaces
{
    /// <summary>
    /// Interface ISyncServerRegistration
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface ISyncServerRegistration : IDisposable
    {
        /// <summary>
        /// Note: This is used for ServerRegistration.exe (UI) and AzureRM Registration paths, NOT SDK tests/Az Modules        /// 
        /// This function processes the registration and performs the following steps:
        /// 1. Validates Sync Server Registration Information
        /// 2. Sets up ServerRegistrationData
        /// 3. Calls RegisterOnline callback to make ARM call (from caller context)
        /// 4. Persists registered server resource from cloud to local FileSyncSvc service
        /// <param name="managementEndpointUri">Management endpoint Uri</param>
        /// <param name="subscriptionId">Subscription Id</param>
        /// <param name="storageSyncServiceName">Storage Sync Service Name</param>
        /// <param name="resourceGroupName">Resource Group Name</param>
        /// <param name="certificateProviderName">Certificate Provider Name</param>
        /// <param name="certificateHashAlgorithm">Certificate Hash Algorithm</param>
        /// <param name="certificateKeyLength">Certificate Key Length</param>
        /// <param name="monitoringDataPath">Monitoring data path</param>
        /// <param name="agentVersion">Agent Version</param>
        /// <param name="serverMachineName">Server Machine Name</param>
        /// <param name="registerOnlineCallback">Register Online Callback</param>
        /// <returns>Registered Server Resource</returns>
        /// </summary>
        RegisteredServer Register(
            Uri managementEndpointUri,
            Guid subscriptionId,
            string storageSyncServiceName,
            string resourceGroupName,
            string certificateProviderName,
            string certificateHashAlgorithm,
            uint certificateKeyLength,
            string monitoringDataPath,
            string agentVersion,
            string serverMachineName,
            Func<string, string, ServerRegistrationData, RegisteredServer> registerOnlineCallback);

        /// <summary>
        /// This function processes the unregistration of the server and performs following steps:
        /// 1. Delete all server endpoints (sync folders)
        /// 2. Delete server registration
        /// 3. (Optional) delete cluster registration
        /// Note: this unregistration path if offline only.
        /// </summary>
        /// <param name="cleanClusterRegistration">if set to <c>true</c> [clean cluster registration].</param>
        void ResetSyncServerConfiguration(bool cleanClusterRegistration);
    }
}
