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
using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.InternalObjects;
using Microsoft.Azure.Commands.StorageSync.Interop.Enums;
using Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity;
using Microsoft.Azure.Management.StorageSync.Models;
using Newtonsoft.Json;
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
    /// Implements the <see cref="Commands.StorageSync.Interop.Clients.SyncServerRegistrationClientBase" />
    /// </summary>
    /// <seealso cref="Commands.StorageSync.Interop.Clients.SyncServerRegistrationClientBase" />
    public class SyncServerRegistrationClient : SyncServerRegistrationClientBase
    {
        protected readonly IServerManagedIdentityProvider ServerManagedIdentityProvider;

        /// <summary>
        /// Parameterzed constructor for Sync Server Registration Client
        /// </summary>
        /// <param name="ecsManagementInteropClient">The ecs management interop client.</param>
        /// <param name="serverManagedIdentityProvider">The server managed identity provider.</param>
        public SyncServerRegistrationClient(IEcsManagement ecsManagementInteropClient, IServerManagedIdentityProvider serverManagedIdentityProvider) : base(ecsManagementInteropClient)
        {
            this.ServerManagedIdentityProvider= serverManagedIdentityProvider;
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
        /// <exception cref="Commands.StorageSync.Interop.Exceptions.ServerRegistrationException">
        /// </exception>
        /// <exception cref="ServerRegistrationException"></exception>
        public override bool Validate(Uri managementEndpointUri, Guid subscriptionId, string storageSyncServiceName, string resourceGroupName, string monitoringDataPath)
        {
            if (!Directory.Exists(monitoringDataPath) && !TryCreateDirectory(monitoringDataPath, out DirectoryInfo directoryInfo))
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.MonitoringDataPathIsInvalid);
            }

            int hr = EcsManagementInteropClient.ValidateSyncServer(
                                       managementEndpointUri.OriginalString,
                                       subscriptionId.ToString(),
                                       storageSyncServiceName,
                                       resourceGroupName);
            bool success = hr == 0;

            if (!success)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.ValidateSyncServerFailed, hr, ErrorCategory.InvalidResult);
            }

            return success;
        }

        /// <summary>
        /// Setup for registration with certificate.
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
        /// <param name="applicationId">Server Identity Id</param>
        /// <param name="monitoringDataPath">Monitoring data path</param>
        /// <param name="agentVersion">Agent Version</param>
        /// <param name="serverMachineName">Server Machine name</param>
        /// <returns>Registered Server Resource</returns>
        /// <exception cref="Commands.StorageSync.Interop.Exceptions.ServerRegistrationException">
        /// </exception>
        /// <exception cref="ArgumentException">serverGuid
        /// or
        /// clusterId</exception>
        /// <exception cref="ServerRegistrationException"></exception>
        public override ServerRegistrationData Setup(
            Uri managementEndpointUri,
            Guid subscriptionId,
            string storageSyncServiceName,
            string resourceGroupName,
            string certificateProviderName,
            string certificateHashAlgorithm,
            uint certificateKeyLength,
            Guid? applicationId,
            string monitoringDataPath,
            string agentVersion,
            string serverMachineName)
        {

            bool isCertificateRegistration = applicationId.GetValueOrDefault(Guid.Empty) == Guid.Empty;
            string syncServerCertificate = default;

            int hr;
            bool success;

            //if (isCertificateRegistration)
            {
                hr = this.EcsManagementInteropClient.EnsureSyncServerCertificate(managementEndpointUri.OriginalString,
                    subscriptionId.ToString(),
                    storageSyncServiceName,
                    resourceGroupName,
                    certificateProviderName,
                    certificateHashAlgorithm,
                    certificateKeyLength);
                success = hr == 0;

                if (!success)
                {
                    throw new ServerRegistrationException(ServerRegistrationErrorCode.EnsureSyncServerCertificateFailed, hr, ErrorCategory.InvalidResult);
                }

                hr = this.EcsManagementInteropClient.GetSyncServerCertificate(isPrimary: true, serverCertificate: out syncServerCertificate);
                success = hr == 0;

                if (!success)
                {
                    throw new ServerRegistrationException(ServerRegistrationErrorCode.GetSyncServerCertificateFailed, hr, ErrorCategory.InvalidResult);
                }
            }

            hr = EcsManagementInteropClient.GetSyncServerId(out string syncServerId);

            bool hasServerGuid = Guid.TryParse(syncServerId, out Guid serverGuid);
            if (!hasServerGuid)
            {
                throw new ArgumentException(nameof(Guid.Empty));
            }

            success = hr == 0;
            if (!success)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.GetSyncServerIdFailed, hr, ErrorCategory.InvalidResult);
            }

            bool isInCluster;
            try
            {
                isInCluster = this.EcsManagementInteropClient.IsInCluster();
            }
            catch (Exception)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.CheckIsInClusterFailed, hr, ErrorCategory.InvalidResult);
            }

            string clusterId = default;
            string clusterName = default;

            if (isInCluster)
            {
                hr = EcsManagementInteropClient.GetClusterInfo(out clusterId, out clusterName);
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

            string osVersion;

            // Get OS version using Win32_OperatingSystem WMI object
            try
            {
                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                ManagementObject info = searcher.Get().Cast<ManagementObject>().FirstOrDefault();

                PropertyData versionProperty = info.Properties["Version"];
                PropertyData servicePackMajorVersionProperty = info.Properties["ServicePackMajorVersion"];

                string version = versionProperty.Value.ToString();
                var versionRegex = new Regex(@"^\d*\.\d*\.\d*$");

                string servicePackMajorVersion = servicePackMajorVersionProperty.Value.ToString();

                // we expect the version format to be something like 10.0.14943.0
                // In order to construct this, we need to combine the version output with the service pack major version.
                osVersion = $"{version}.{servicePackMajorVersion}";
            }
            catch (Exception)
            {
                // Fall back to the old way
                osVersion = Environment.OSVersion.Version.ToString();
            }

            var serverRegistrationData = new ServerRegistrationData
            {
                Id = resourceId,
                ServerId = serverGuid,
                ServerCertificate = syncServerCertificate != null ? syncServerCertificate.ToBase64Bytes(throwException: true): null,
                ServerRole = isInCluster ? ServerRoleType.ClusterNode : ServerRoleType.Standalone,
                ServerOSVersion = osVersion,
                ApplicationId = applicationId,
                AgentVersion = agentVersion,
                ServerMachineName = serverMachineName
            };

            if (isInCluster)
            {
                bool clusterGuidValue = Guid.TryParse(clusterId, out Guid clusterGuid);
                if (!clusterGuidValue)
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
        /// <exception cref="ArgumentException">StorageSyncServiceUid
        /// or
        /// ServerRole
        /// or
        /// ClusterId</exception>
        /// <exception cref="Commands.StorageSync.Interop.Exceptions.ServerRegistrationException">
        /// </exception>
        /// <exception cref="ServerRegistrationException">StorageSyncServiceUid
        /// or
        /// ServerRole
        /// or
        /// ClusterId</exception>
        public override bool Persist(RegisteredServer registeredServerResource, Guid subscriptionId, string storageSyncServiceName, string resourceGroupName, string monitoringDataPath)
        {
            var storageSyncServiceUid = Guid.Empty;
            bool hasStorageSyncServiceUid = Guid.TryParse(registeredServerResource.StorageSyncServiceUid, out storageSyncServiceUid);
            if (!hasStorageSyncServiceUid)
            {
                throw new ArgumentException(nameof(registeredServerResource.StorageSyncServiceUid));
            }

            bool hasServerRole = Enum.TryParse(registeredServerResource.ServerRole, out ServerRoleType serverRole);
            if (!hasServerRole)
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

            int hr = EcsManagementInteropClient.PersistSyncServerRegistration(
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

            bool success = hr == 0;

            if (!success)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.PersistSyncServerRegistrationFailed, hr, ErrorCategory.InvalidResult);
            }

            var monitoringConfiguration = default(HybridMonitoringConfigurationResource);

            if (!string.IsNullOrEmpty(registeredServerResource.MonitoringConfiguration))
            {
                monitoringConfiguration = JsonConvert.DeserializeObject<HybridMonitoringConfigurationResource>(registeredServerResource.MonitoringConfiguration);
            }
            ServerRegistrationInformation registrationInfo = new ServerRegistrationInformation
            {
                ServiceEndpoint = registeredServerResource.MonitoringEndpointUri ?? registeredServerResource.ManagementEndpointUri,
                SubscriptionId = subscriptionId,
                ResourceGroupName = resourceGroupName,
                StorageSyncServiceName = storageSyncServiceName,
                StorageSyncServiceUid = storageSyncServiceUid,
                ClusterName = registeredServerResource.ClusterName ?? string.Empty,
                ClusterId = clusterId,
                MonitoringConfiguration = monitoringConfiguration,
                ResourceLocation = registeredServerResource.ResourceLocation
            };

            bool isCertificateRegistration = string.IsNullOrEmpty(registeredServerResource.ApplicationId);

            if (registeredServerResource.ServerCertificate != null)
            {
                registrationInfo.ServerCertificate = registeredServerResource.ServerCertificate.ToBase64Bytes(); // use certificate
            }
            if (!string.IsNullOrEmpty(registeredServerResource.ApplicationId))
            {
                registrationInfo.ApplicationId = Guid.Parse(registeredServerResource.ApplicationId); // use Managed Identity ID
            }
 
            // We try to register monitoring agent but do not gurantee it to succeed.
            hr = EcsManagementInteropClient.RegisterMonitoringAgent(
               JsonConvert.SerializeObject(registrationInfo),
                monitoringDataPath);
            success = hr == 0;

            if (!success)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.RegisterMonitoringAgentFailed, hr, ErrorCategory.InvalidResult);
            }

            return success;
        }

        /// <summary>
        /// Tries the create directory.
        /// </summary>
        /// <param name="monitoringDataPath">The monitoring data path.</param>
        /// <param name="directoryInfo">The directory information.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
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
            }
            return false;
        }

        /// <summary>
        /// This function will get the application id of the server if identity is available.
        /// </summary>
        /// <returns>Application id or null.</returns>
        public override Guid? GetApplicationIdOrNull()
        {
            LocalServerType localServerType = this.ServerManagedIdentityProvider.GetServerType(this.EcsManagementInteropClient);

            if(localServerType != LocalServerType.HybridServer)
            {
                return this.ServerManagedIdentityProvider.GetServerApplicationId(localServerType, throwIfNotFound: true, validateSystemAssignedManagedIdentity: true);
            }
            return null;
        }
    }
}
