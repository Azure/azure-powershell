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
using Commands.StorageSync.Interop.Enums;
using Commands.StorageSync.Interop.Exceptions;
using Commands.StorageSync.Interop.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Interop.Enums;
using Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.Win32;
using System;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Commands.StorageSync.Interop.Clients
{
    /// <summary>
    /// Abstract class for ISyncServerRegistration interface.
    /// Base class for Sync Server Registration Client
    /// Implements the <see cref="Commands.StorageSync.Interop.Interfaces.ISyncServerRegistration" />
    /// </summary>
    /// <seealso cref="Commands.StorageSync.Interop.Interfaces.ISyncServerRegistration" />
    public abstract class MockSyncServerRegistrationClientBase : ISyncServerRegistration
    {
        public bool EnableMIChecking { get; protected set; } = false; // enable it in v19 azure file sync agent

        /// <summary>
        /// The m is disposed
        /// </summary>
        private bool m_isDisposed;

        /// <summary>
        /// ECS Management Interop Client
        /// </summary>
        /// <value>The ecs management interop client.</value>
        protected IEcsManagement EcsManagementInteropClient { get; private set; }

        /// <summary>
        /// Parameter constructor for SyncServerRegistrationClientBase
        /// </summary>
        /// <param name="ecsManagementInteropClient">The ecs management interop client.</param>
        public MockSyncServerRegistrationClientBase(IEcsManagement ecsManagementInteropClient)
        {
            EcsManagementInteropClient = ecsManagementInteropClient;
        }

        /// <summary>
        /// This function will return the application id of the server if it is available.
        /// </summary>
        /// <returns>Application Id or null</returns>
        public abstract Guid? GetApplicationIdOrNull();

        /// <summary>
        /// Validate sync server registration.
        /// </summary>
        /// <param name="managementEndpointUri">Management Endpoint Uri</param>
        /// <param name="subscriptionId">Subscription Id</param>
        /// <param name="storageSyncService">Storage Sync Service Name</param>
        /// <param name="resourceGroupName">Resource Group Name</param>
        /// <param name="monitoringDataPath">Monitoring data path</param>
        /// <returns>success status</returns>
        public abstract bool Validate(Uri managementEndpointUri, Guid subscriptionId, string storageSyncService, string resourceGroupName, string monitoringDataPath);

        /// <summary>
        /// This function processes the registration and perform following steps
        /// 1. EnsureSyncServerCertificate
        /// 2. GetSyncServerCertificate
        /// 3. GetSyncServerId
        /// 4. Get ClusterInfo
        /// 5. Populate RegistrationServerResource
        /// </summary>
        /// <param name="managementEndpointUri">Management Endpoint Uri</param>
        /// <param name="subscriptionId">Subscription Id</param>
        /// <param name="storageSyncService">Storage Sync Service Name</param>
        /// <param name="resourceGroupName">Resource Group Name</param>
        /// <param name="certificateProviderName">Certificate Provider Name</param>
        /// <param name="certificateHashAlgorithm">Certificate Hash Algorithm</param>
        /// <param name="certificateKeyLength">Certificate Key Length</param>
        /// <param name="applicationId">Server Identity Id</param>
        /// <param name="monitoringDataPath">Monitoring data path</param>
        /// <param name="agentVersion">Agent Version</param>
        /// <param name="serverMachineName">Server machine name.</param>
        /// <returns>Registered Server resource</returns>
        public abstract ServerRegistrationData Setup(
            Uri managementEndpointUri,
            Guid subscriptionId,
            string storageSyncService,
            string resourceGroupName,
            string certificateProviderName,
            string certificateHashAlgorithm,
            uint certificateKeyLength,
            Guid? applicationId,
            string monitoringDataPath,
            string agentVersion,
            string serverMachineName);

        /// <summary>
        /// Persisting the register server resource from clooud to the local service.
        /// </summary>
        /// <param name="registeredServerResource">Registered Server Resource</param>
        /// <param name="subscriptionId">Subscription Id</param>
        /// <param name="storageSyncServiceName">Storage Sync Service Name</param>
        /// <param name="resourceGroupName">Resource Group Name</param>
        /// <param name="monitoringDataPath">Monitoring data path</param>
        /// <returns>success status</returns>
        public abstract bool Persist(RegisteredServer registeredServerResource, Guid subscriptionId, string storageSyncServiceName, string resourceGroupName, string monitoringDataPath);

        /// <summary>
        /// Dispose method for cleaning Interop client object.
        /// </summary>
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                if (EcsManagementInteropClient != null)
                {
                    EcsManagementInteropClient.Dispose();
                }

                EcsManagementInteropClient = null;
                m_isDisposed = true;
            }
        }

        /// <summary>
        /// This function processes the registration and perform following steps
        /// 1. EnsureSyncServerCertificate
        /// 2. GetSyncServerCertificate
        /// 3. GetSyncServerId
        /// 4. Get ClusterInfo
        /// 5. Populate RegistrationServerResource
        /// </summary>
        /// <param name="managementEndpointUri">Management endpoint Uri</param>
        /// <param name="subscriptionId">Subscription Id</param>
        /// <param name="storageSyncServiceName">Storage Sync Service Name</param>
        /// <param name="resourceGroupName">Resource Group Name</param>
        /// <param name="certificateProviderName">Certificate Provider Name</param>
        /// <param name="certificateHashAlgorithm">Certificate Hash Algorithm</param>
        /// <param name="certificateKeyLength">Certificate Key Length</param>
        /// <param name="monitoringDataPath">Monitoring data path</param>
        /// <param name="agentVersion">Agent Version</param>
        /// <param name="serverMachineName">Server machine name.</param>
        /// <param name="registerOnlineCallback">Register Online Callback</param>
        /// <returns>Registered Server Resource</returns>
        /// <exception cref="Commands.StorageSync.Interop.Exceptions.ServerRegistrationException">
        /// </exception>
        /// <exception cref="ServerRegistrationException"></exception>
        public RegisteredServer Register(
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
            Func<string, string, ServerRegistrationData, RegisteredServer> registerOnlineCallback)
        {
            // Get ApplicationId
            Guid? applicationId = GetApplicationIdOrNull();

#pragma warning disable CA1416 // Validate platform compatibility
            //RegistryUtility.WriteValue(StorageSyncConstants.ServerAuthRegistryKeyName,
            //           StorageSyncConstants.AfsAgentRegistryKey,
            //          ((applicationId == Guid.Empty) ? RegisteredServerAuthType.Certificate : RegisteredServerAuthType.ManagedIdentity).ToString(),
            //           RegistryValueKind.String,
            //           true);
#pragma warning restore CA1416 // Validate platform compatibility

            if (!Validate(managementEndpointUri, subscriptionId, storageSyncServiceName, resourceGroupName, monitoringDataPath))
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.ValidateSyncServerFailed);
            }

            var serverRegistrationData = Setup(managementEndpointUri, subscriptionId, storageSyncServiceName, resourceGroupName, certificateProviderName, certificateHashAlgorithm, certificateKeyLength, applicationId, monitoringDataPath, agentVersion, serverMachineName);
            if (null == serverRegistrationData)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.ProcessSyncRegistrationFailed);
            }

            RegisteredServer resultantRegisteredServerResource = registerOnlineCallback(resourceGroupName, storageSyncServiceName, serverRegistrationData);
            if (null == resultantRegisteredServerResource)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.RegisterOnlineSyncRegistrationFailed);
            }

            // Setting ServerCertificate from request resource to response resource so that it can be used by Monitoring pipeline
            resultantRegisteredServerResource.ServerCertificate = Convert.ToBase64String(serverRegistrationData.ServerCertificate);

            if (!Persist(resultantRegisteredServerResource, subscriptionId, storageSyncServiceName, resourceGroupName, monitoringDataPath))
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.PersistSyncServerRegistrationFailed);
            }

            return resultantRegisteredServerResource;
        }

        /// <summary>
        /// This method will clean all of the AFS management configuration on the server.
        /// This includes all server endpoints (sync folders), the server registration, and the cluster registration (if desired).
        /// Note: this unregistration path if offline only.
        /// </summary>
        /// <param name="cleanClusterRegistration">Specify if the cluster registration should be cleaned.</param>
        public void ResetSyncServerConfiguration(bool cleanClusterRegistration)
        {
            EcsManagementInteropClient.ResetSyncServerConfiguration(cleanClusterRegistration);
        }

    }
}
