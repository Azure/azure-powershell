using Commands.StorageSync.Interop.DataObjects;
using Commands.StorageSync.Interop.Enums;
using Commands.StorageSync.Interop.Exceptions;
using Commands.StorageSync.Interop.Interfaces;
using Microsoft.Azure.Management.StorageSync.Models;
using System;

namespace Commands.StorageSync.Interop.Clients
{
    /// <summary>
    /// Abstract class for ISyncServerRegistration interface.
    /// Base class for Sync Server Registration Client
    /// </summary>
    public abstract class SyncServerRegistrationClientBase : ISyncServerRegistration
    {

        private bool m_isDisposed;

        /// <summary>
        /// ECS Management Interop Client
        /// </summary>
        protected IEcsManagement EcsManagementInteropClient { get; private set; }

        /// <summary>
        /// Parameter constructor for SyncServerRegistrationClientBase
        /// </summary>
        /// <param name="ecsManagementInteropClient"></param>
        public SyncServerRegistrationClientBase(IEcsManagement ecsManagementInteropClient)
        {
            //Check.NotNull(ecsManagementInteropClient);
            this.EcsManagementInteropClient = ecsManagementInteropClient;
        }

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
        /// <param name="monitoringDataPath">Monitoring data path</param>
        /// <param name="agentVersion">Agent Version</param>
        /// <returns>Registered Server resource</returns>
        public abstract ServerRegistrationData Setup(Uri managementEndpointUri, Guid subscriptionId, string storageSyncService, string resourceGroupName, string certificateProviderName, string certificateHashAlgorithm, uint certificateKeyLength, string monitoringDataPath, string agentVersion);

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
        /// <param name="registerOnlineCallback">Register Online Callback</param>
        /// <returns>Registered Server Resource</returns>
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
            Func<string,string,ServerRegistrationData, RegisteredServer> registerOnlineCallback)
        {
            //Check.NotNull(nameof(managementEndpointUri), managementEndpointUri);
            //Check.NotNullOrEmpty(nameof(managementEndpointUri), managementEndpointUri.OriginalString);
            //Check.True(nameof(managementEndpointUri), managementEndpointUri.IsWellFormedOriginalString());
            //Check.False(nameof(subscriptionId), Guid.Empty.Equals(subscriptionId));
            //Check.NotNullOrEmpty(nameof(storageSyncServiceName), storageSyncServiceName);
            //Check.NotNullOrEmpty(nameof(resourceGroupName), resourceGroupName);
            //Check.NotNullOrEmpty(nameof(certificateProviderName), certificateProviderName);
            //Check.NotNullOrEmpty(nameof(certificateHashAlgorithm), certificateHashAlgorithm);
            //Check.GreaterThan<uint>(nameof(certificateKeyLength), certificateKeyLength, 0, "Certificate Key Length must be greater than 0.");
            //Check.NotNullOrEmpty(nameof(monitoringDataPath), monitoringDataPath);
            //Check.NotNullOrEmpty(nameof(agentVersion), agentVersion);
            //Check.NotNull(nameof(registerOnlineCallback), registerOnlineCallback);

            //cmdletConsoleWriterAction("Validating sync server registration started", LogLevel.Verbose);
            //HfsTracer.TraceInfo("SyncServerRegistration : Register : Validating sync server registration");
            if (!this.Validate(managementEndpointUri, subscriptionId, storageSyncServiceName, resourceGroupName, monitoringDataPath))
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.ValidateSyncServerFailed);
            }
            //cmdletConsoleWriterAction("Validating sync server registration completed", LogLevel.Verbose);

            //cmdletConsoleWriterAction("Setting up sync server registration started", LogLevel.Verbose);
            //HfsTracer.TraceInfo("SyncServerRegistration : Register : Setup sync server registration");
            var serverRegistrationData = this.Setup(managementEndpointUri, subscriptionId, storageSyncServiceName, resourceGroupName, certificateProviderName, certificateHashAlgorithm, certificateKeyLength, monitoringDataPath, agentVersion);
            if (null == serverRegistrationData)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.ProcessSyncRegistrationFailed);
            }
            //cmdletConsoleWriterAction("Setting up sync server registration completed", LogLevel.Verbose);

            //cmdletConsoleWriterAction("Registering sync server registration online started", LogLevel.Verbose);
            //HfsTracer.TraceInfo("SyncServerRegistration : Register : Registering online sync server registration to the cloud");
            RegisteredServer resultantRegisteredServerResource = registerOnlineCallback(resourceGroupName, storageSyncServiceName, serverRegistrationData);
            if (null == resultantRegisteredServerResource)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.RegisterOnlineSyncRegistrationFailed);
            }
            //cmdletConsoleWriterAction("Registering sync server registration online completed", LogLevel.Verbose);

            //cmdletConsoleWriterAction("Registering sync server registration to the local server started", LogLevel.Verbose);
            //Check.True(Enum.TryParse(resultantRegisteredServerResource.ServerRole, out ServerRoleType serverRole));

            // Setting ServerCertificate from request resource to response resource so that it can be used by Monitoring pipeline
            resultantRegisteredServerResource.ServerCertificate = Convert.ToBase64String(serverRegistrationData.ServerCertificate);

            //HfsTracer.TraceInfo("SyncServerRegistration : Register : Persisting sync server registration to the local service");
            if (!Persist(resultantRegisteredServerResource, subscriptionId, storageSyncServiceName, resourceGroupName, monitoringDataPath))
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.PersistSyncServerRegistrationFailed);
            }
            //cmdletConsoleWriterAction("Registering sync server registration to the local server completed", LogLevel.Verbose);

            //HfsTracer.TraceInfo($"SyncServerRegistration : Register : Registration completed with success");

            return resultantRegisteredServerResource;
        }

        /// <summary>
        /// This method will clean all of the AFS management configuration on the server. 
        /// This includes all server endpoints (sync folders), the server registration, and the cluster registration (if desired).
        /// 
        /// Note: this unregistration path if offline only.
        /// </summary>
        /// <param name="cleanClusterRegistration">Specify if the cluster registration should be cleaned.</param>
        public void ResetSyncServerConfiguration(bool cleanClusterRegistration)
        {
            EcsManagementInteropClient.ResetSyncServerConfiguration(cleanClusterRegistration);
        }
    }
}
