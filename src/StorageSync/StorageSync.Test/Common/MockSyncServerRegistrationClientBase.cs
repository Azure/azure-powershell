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

namespace Microsoft.Azure.Commands.StorageSync.Test.Common
{
    /// <summary>
    /// Abstract class for ISyncServerRegistration interface.
    /// Base class for Sync Server Registration Client
    /// Implements the <see cref="Commands.StorageSync.Interop.Interfaces.ISyncServerRegistration" />
    /// </summary>
    /// <seealso cref="Commands.StorageSync.Interop.Interfaces.ISyncServerRegistration" />
    public abstract class MockSyncServerRegistrationClientBase : ISyncServerRegistration
    {
        public bool EnableMIChecking { get; protected set; } = true;

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
        /// <returns>ServerApplicationIdentity or null</returns>
        public abstract ServerApplicationIdentity GetServerApplicationIdentityOrNull();

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
        /// Connects the local server to an existing registered server resource.
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
        /// <param name="assignIdentity">Assign Identity</param>
        /// <param name="serverId">Server ID returned by Azure.</param>
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
            string serverMachineName,
            bool assignIdentity,
            Guid serverId);

        /// <summary>
        /// Persisting the register server resource from cloud to the local service.
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
        /// 3. Uses the server ID returned by Azure
        /// 4. Gets cluster information
        /// 5. Populates registration data
        /// </summary>
        /// <param name="storageSyncServiceTenantId">Storage Sync Service Tenant Id</param>
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
        /// <param name="registeredServerResource">Registered server resource created in Azure.</param>
        /// <returns>Registered Server Resource</returns>
        /// <exception cref="Commands.StorageSync.Interop.Exceptions.ServerRegistrationException">
        /// </exception>
        /// <exception cref="ServerRegistrationException"></exception>
        public RegisteredServer Connect(
            string storageSyncServiceTenantId,
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
            RegisteredServer registeredServerResource)
        {
            if (registeredServerResource == null)
            {
                throw new ArgumentNullException(nameof(registeredServerResource));
            }

            ServerApplicationIdentity serverApplicationIdentity = GetServerApplicationIdentityOrNull();
            Guid? applicationId = serverApplicationIdentity?.ApplicationId;

            if (serverApplicationIdentity == null || applicationId.GetValueOrDefault() == Guid.Empty)
            {
                throw new PSArgumentException("This server is not configured properly to use managed identities.");
            }

            if (serverApplicationIdentity.TenantId != Guid.Empty)
            {
                if (!string.Equals(storageSyncServiceTenantId, serverApplicationIdentity.TenantId.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    throw new ServerRegistrationException(
                        $"Cross-tenant registration is not allowed. The server belongs to tenant '{serverApplicationIdentity.TenantId}' but the Storage Sync Service is in tenant '{storageSyncServiceTenantId}'.");
                }
            }

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

            if (!Guid.TryParse(registeredServerResource.ServerId, out Guid registeredServerId)
                || registeredServerId == Guid.Empty)
            {
                throw new PSArgumentException("The registered server resource does not contain a valid server ID.", nameof(registeredServerResource));
            }

            var serverRegistrationData = Setup(managementEndpointUri, subscriptionId, storageSyncServiceName, resourceGroupName, certificateProviderName, certificateHashAlgorithm, certificateKeyLength, applicationId, monitoringDataPath, agentVersion, serverMachineName, true, registeredServerId);
            if (null == serverRegistrationData)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.ProcessSyncRegistrationFailed);
            }

            if (!Guid.TryParse(registeredServerResource.ApplicationId, out Guid registeredApplicationId)
                || registeredApplicationId != applicationId.Value)
            {
                throw new PSArgumentException("The registered server application ID does not match the local server managed identity.", nameof(registeredServerResource));
            }

            registeredServerResource.ServerRole = serverRegistrationData.ServerRole.ToString();
            registeredServerResource.ClusterId = serverRegistrationData.ClusterId.GetValueOrDefault() == Guid.Empty
                ? null
                : serverRegistrationData.ClusterId.Value.ToString();
            registeredServerResource.ClusterName = serverRegistrationData.ClusterName;
            registeredServerResource.AgentVersion = serverRegistrationData.AgentVersion;
            registeredServerResource.ServerOSVersion = serverRegistrationData.ServerOSVersion;

            if (!Persist(registeredServerResource, subscriptionId, storageSyncServiceName, resourceGroupName, monitoringDataPath))
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.PersistSyncServerRegistrationFailed);
            }

            return registeredServerResource;
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
