using Commands.StorageSync.Interop.DataObjects;
using Commands.StorageSync.Interop.Enums;
using Commands.StorageSync.Interop.Exceptions;
using Commands.StorageSync.Interop.Interfaces;
using Kailani.Hfs.V1.Data.Contracts.Registration;
using Kailani.Hfs.V1.Data.Contracts.ResourceEntity;
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Management.StorageSync.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Management.Automation;
using System.Text.RegularExpressions;

namespace Commands.StorageSync.Interop.Clients
{
    /// <summary>
    /// Sync Server Registration Client
    /// </summary>
    public class SyncServerRegistrationClient : SyncServerRegistrationClientBase
    {

        /// <summary>
        /// Parameterzed constructor for Sync Server Registration Client
        /// </summary>
        /// <param name="ecsManagementInteropClient"></param>
        public SyncServerRegistrationClient(IEcsManagement ecsManagementInteropClient) : base(ecsManagementInteropClient)
        {
        }

        /// <summary>
        /// Validate sync server registration.
        /// </summary>
        /// <param name="managementEndpointUri">Management Endpoint Uri</param>
        /// <param name="subscriptionId">Subscription Id</param>
        /// <param name="storageSyncServiceName">Storage Sync Service Name</param>
        /// <param name="resourceGroupName">Resource Group Name</param>
        /// <param name="monitoringDataPath">Monitoring data path</param>
        /// <returns>success status</returns>
        public override bool Validate(Uri managementEndpointUri, Guid subscriptionId, string storageSyncServiceName, string resourceGroupName, string monitoringDataPath)
        {
            //Check.NotNull(nameof(managementEndpointUri), managementEndpointUri);
            //Check.NotNullOrEmpty(nameof(managementEndpointUri), managementEndpointUri.OriginalString);
            //Check.True(nameof(managementEndpointUri), managementEndpointUri.IsWellFormedOriginalString());
            //Check.False(nameof(subscriptionId), Guid.Empty.Equals(subscriptionId));
            //Check.NotNullOrEmpty(nameof(storageSyncServiceName), storageSyncServiceName);
            //Check.NotNullOrEmpty(nameof(resourceGroupName), resourceGroupName);
            //Check.NotNullOrEmpty(nameof(monitoringDataPath), monitoringDataPath);

            //HfsTracer.TraceInfo($"MonitoringDataPath was provided by the user: {monitoringDataPath}");

            DirectoryInfo directoryInfo;
            if (!Directory.Exists(monitoringDataPath) && !TryCreateDirectory(monitoringDataPath,out directoryInfo))
            {
                //HfsTracer.TraceInfo($"MonitoringDataPath provided by the user: {monitoringDataPath} is invalid or path does not exist");
                throw new ServerRegistrationException(ServerRegistrationErrorCode.MonitoringDataPathIsInvalid);
            }

            int hr = this.EcsManagementInteropClient.ValidateSyncServer(
                                       managementEndpointUri.OriginalString,
                                       subscriptionId.ToString(),
                                       storageSyncServiceName,
                                       resourceGroupName);
            //HfsTracer.TraceInfo($"SyncServerRegistrationClient:Validate HRESULT: {hr}");
            bool success = hr == 0;

            if (!success)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.ValidateSyncServerFailed, hr, ErrorCategory.InvalidResult);
            }

            return success;
        }

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
        /// <param name="storageSyncServiceName">Storage Sync Service Name</param>
        /// <param name="resourceGroupName">Resource Group Name</param>
        /// <param name="certificateProviderName">Certificate Provider Name</param>
        /// <param name="certificateHashAlgorithm">Certificate Hash Algorithm</param>
        /// <param name="certificateKeyLength">Certificate Key Length</param>
        /// <param name="monitoringDataPath">Monitoring data path</param>
        /// <param name="agentVersion">Agent Version</param>
        /// <returns>Registered Server Resource</returns>
        public override ServerRegistrationData Setup(Uri managementEndpointUri, Guid subscriptionId, string storageSyncServiceName, string resourceGroupName, string certificateProviderName, string certificateHashAlgorithm, uint certificateKeyLength, string monitoringDataPath, string agentVersion)
        {
            //Check.NotNull(nameof(managementEndpointUri), managementEndpointUri);
            //Check.NotNullOrEmpty(nameof(managementEndpointUri), managementEndpointUri.OriginalString);
            //Check.True(nameof(managementEndpointUri),managementEndpointUri.IsWellFormedOriginalString());
            //Check.False(nameof(subscriptionId), Guid.Empty.Equals(subscriptionId));
            //Check.NotNullOrEmpty(nameof(storageSyncServiceName), storageSyncServiceName);
            //Check.NotNullOrEmpty(nameof(resourceGroupName), resourceGroupName);
            //Check.NotNullOrEmpty(nameof(certificateProviderName), certificateProviderName);
            //Check.NotNullOrEmpty(nameof(certificateHashAlgorithm), certificateHashAlgorithm);
            //Check.NotNullOrEmpty(nameof(monitoringDataPath), monitoringDataPath);
            //Check.NotNullOrEmpty(nameof(agentVersion), agentVersion);
            //Check.GreaterThan<uint>(nameof(certificateKeyLength), certificateKeyLength, 0,"Certificate key length must be greater than 0");

            int hr = this.EcsManagementInteropClient.EnsureSyncServerCertificate(managementEndpointUri.OriginalString,
                subscriptionId.ToString(),
                storageSyncServiceName,
                resourceGroupName,
                certificateProviderName, 
                certificateHashAlgorithm,
                certificateKeyLength);
            //HfsTracer.TraceInfo($"SyncServerRegistrationClient:Process:EnsureSyncServerCertificate HRESULT: {hr}");
            bool success = hr == 0;

            if (!success)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.EnsureSyncServerCertificateFailed, hr, ErrorCategory.InvalidResult);
            }

            string syncServerCertificate;
            hr = this.EcsManagementInteropClient.GetSyncServerCertificate(isPrimary:true, serverCertificate:out syncServerCertificate);
            //HfsTracer.TraceInfo($"SyncServerRegistrationClient:Process:GetSyncServerCertificate HRESULT: {hr}");
            //Check.NotNullOrEmpty(nameof(syncServerCertificate), syncServerCertificate);
            success = hr == 0;

            if (!success)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.GetSyncServerCertificateFailed, hr, ErrorCategory.InvalidResult);
            }

            string syncServerId;
            hr = this.EcsManagementInteropClient.GetSyncServerId(out syncServerId);
            //HfsTracer.TraceInfo($"SyncServerRegistrationClient:Process:GetSyncServerId HRESULT: {hr}");
            if(!Guid.TryParse(syncServerId, out Guid serverGuid))
            {
                throw new ArgumentException(nameof(serverGuid));
            }
            //Check.True(nameof(syncServerId), Guid.TryParse(syncServerId, out serverGuid));

            success = hr == 0;


            if (!success)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.GetSyncServerIdFailed, hr, ErrorCategory.InvalidResult);
            }

            bool isInCluster;
            isInCluster = this.EcsManagementInteropClient.IsInCluster();
            //HfsTracer.TraceInfo($"SyncServerRegistrationClient:Process:IsInCluster returned : {isInCluster}");

            
            string clusterId = default(string);
            string clusterName = default(string);

            if (isInCluster)
            {
                hr = this.EcsManagementInteropClient.GetClusterInfo(out clusterId, out clusterName);
                //HfsTracer.TraceInfo($"SyncServerRegistrationClient:Process:GetClusterInfo HRESULT: {hr} with Cluster Id = {clusterId} and Cluster name = {clusterName}");
                success = hr == 0;

                if (!success)
                {
                    throw new ServerRegistrationException(ServerRegistrationErrorCode.GetClusterInfoFailed, hr, ErrorCategory.InvalidResult);
                }
            }

            var resources = new List<KeyValuePair<string, string>>
                                    {
                                        new KeyValuePair<string, string>(
                                            StorageSyncConstants.StorageSyncServiceTypeName,
                                            storageSyncServiceName),
                                        new KeyValuePair<string, string>(
                                            StorageSyncConstants.RegisteredServerTypeName,
                                            syncServerId)
                                    };

            string resourceId = ResourceIdFormatter.GenerateResourceId(subscriptionId, resourceGroupName, resources);

            string osVersion = null;

            // Get OS version using Win32_OperatingSystem WMI object
            try 
            {
                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                ManagementObject info = searcher.Get().Cast<ManagementObject>().FirstOrDefault();

                //Check.NotNull(nameof(info), info);
                //Check.NotNull(nameof(info.Properties), info.Properties);

                PropertyData versionProperty = info.Properties["Version"];//Check.NotNull(nameof(versionProperty), info.Properties["Version"]);
                PropertyData servicePackMajorVersionProperty = info.Properties["ServicePackMajorVersion"];//Check.NotNull(nameof(servicePackMajorVersionProperty), info.Properties["ServicePackMajorVersion"]);

                string version = versionProperty.Value.ToString();//Check.NotNullOrEmpty(nameof(version), versionProperty.Value.ToString());
                var versionRegex = new Regex(@"^\d*\.\d*\.\d*$");
                //Check.True(versionRegex.IsMatch(version), "version must be in the format #.#.#!");

                string servicePackMajorVersion = servicePackMajorVersionProperty.Value.ToString();//Check.NotNullOrEmpty(nameof(servicePackMajorVersion), servicePackMajorVersionProperty.Value.ToString());

                // we expect the version format to be something like 10.0.14943.0
                // In order to construct this, we need to combine the version output with the service pack major version.
                osVersion = $"{version}.{servicePackMajorVersion}";
            }
            catch (Exception)
            {
                //HfsTracer.TraceException(ex, System.Diagnostics.Tracing.EventLevel.Warning, "Failed to obtain OS version from Win32_OperatingSystem");
                
                // Fall back to the old way
                osVersion = Environment.OSVersion.Version.ToString();
            }

            var serverRegistrationData = new ServerRegistrationData
            {
                Id = resourceId,
                ServerId = serverGuid,
                ServerCertificate = syncServerCertificate.ToBase64Bytes(true),
                ServerRole = isInCluster ? ServerRoleType.ClusterNode : ServerRoleType.Standalone,
                ServerOSVersion = osVersion,
                AgentVersion = agentVersion
            };

            if (isInCluster)
            {
                if(!Guid.TryParse(clusterId, out Guid clusterGuid))
                {
                    throw new ArgumentException(nameof(clusterId));
                }

                serverRegistrationData.ClusterId = clusterGuid;
                serverRegistrationData.ClusterName = clusterName;
            }
            else
            {
                serverRegistrationData.ClusterId = Guid.Empty;
            }

            return serverRegistrationData;
        }

        /// <summary>
        /// Persisting the register server resource from clooud to the local service.
        /// </summary>
        /// <param name="registeredServerResource">Registered Server Resource</param>
        /// <param name="subscriptionId">Subscription Id</param>
        /// <param name="storageSyncServiceName">Storage Sync Service Name</param>
        /// <param name="resourceGroupName">Resource Group Name</param>
        /// <param name="monitoringDataPath">Monitoring data path</param>
        /// <returns>success status</returns>
        public override bool Persist(RegisteredServer registeredServerResource, Guid subscriptionId, string storageSyncServiceName, string resourceGroupName, string monitoringDataPath)
        {
            if (!Guid.TryParse(registeredServerResource.StorageSyncServiceUid, out Guid storageSyncServiceUid))
            {
                throw new ArgumentException(nameof(registeredServerResource.StorageSyncServiceUid));
            }

            if (!Enum.TryParse(registeredServerResource.ServerRole, out ServerRoleType serverRole))
            {
                throw new ArgumentException(nameof(registeredServerResource.ServerRole));
            }

            Guid clusterId = Guid.Empty;
            if (serverRole == ServerRoleType.ClusterNode)
            {
                if (!Guid.TryParse(registeredServerResource.ClusterId, out clusterId))
                {
                    throw new ArgumentException(nameof(registeredServerResource.ClusterId));
                }
            }

            int hr = this.EcsManagementInteropClient.PersistSyncServerRegistration(
                registeredServerResource.ManagementEndpointUri,
                subscriptionId.ToString(),
                storageSyncServiceName,
                resourceGroupName,
                clusterId.Equals(Guid.Empty) ? string.Empty : clusterId.ToString(),
                registeredServerResource.ClusterName ?? string.Empty,
                storageSyncServiceUid.ToString(),
                registeredServerResource.DiscoveryEndpointUri,
                registeredServerResource.ServiceLocation,
                registeredServerResource.ResourceLocation);

            //HfsTracer.TraceInfo($"SyncServerRegistrationClient:Register:PersistSyncServerRegistration HRESULT: {hr}");
            bool success = hr == 0;

            if (!success)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.PersistSyncServerRegistrationFailed, hr, ErrorCategory.InvalidResult);
            }

            var monitoringConfiguration = ResourcePropertyConversionUtils.DeserializeValue<HybridMonitoringConfigurationResource>(registeredServerResource.MonitoringConfiguration);
            var registrationInfo = new ServerRegistrationInformation(
                serviceEndpoint: registeredServerResource.ManagementEndpointUri,
                subscriptionId: subscriptionId,
                resourceGroupName: resourceGroupName,
                storageSyncServiceName: storageSyncServiceName,
                storageSyncServiceUid: storageSyncServiceUid,
                clusterName: registeredServerResource.ClusterName ?? string.Empty,
                clusterId: clusterId,
                monitoringConfiguration: monitoringConfiguration,
                serverCertificate: registeredServerResource.ServerCertificate.ToBase64Bytes(),
                resourceLocation: registeredServerResource.ResourceLocation
                );
 
            // We try to register monitoring agent but do not gurantee it to succeed.
            hr = EcsManagementInteropClient.RegisterMonitoringAgent(
                registrationInfo.ToJson(), 
                monitoringDataPath);
            //HfsTracer.TraceInfo($"SyncServerRegistrationClient:Register:RegisterMonitoringAgent HRESULT: {hr}");
            success = hr == 0;

            if (!success)
            {
                //throw new ServerRegistrationException(ServerRegistrationErrorCode.RegisterMonitoringAgentFailed, hr, ErrorCategory.InvalidResult);
                //HfsTracer.TraceWarning($"SyncServerRegistrationClient:Register:RegisterMonitoringAgent failed with HRESULT: {hr}. Error Code : {ServerRegistrationErrorCode.RegisterMonitoringAgentFailed}");
            }

            return success;
        }

        private bool TryCreateDirectory(string monitoringDataPath, out DirectoryInfo directoryInfo)
        {
            directoryInfo = null;
            try
            {
                directoryInfo = Directory.CreateDirectory(monitoringDataPath);
                return true;
            }
            catch (Exception)
            {
                // log as warning and continue.
                //HfsTracer.TraceWarning($"TryCreateDirectory: Cannot create directory {monitoringDataPath} with exception {ex.Message}");
            }
            return false;
        }
    }
}
