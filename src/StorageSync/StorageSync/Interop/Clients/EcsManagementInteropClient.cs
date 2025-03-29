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
using Microsoft.Azure.Commands.StorageSync.Properties;
using System;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Commands.StorageSync.Interop.Clients
{
    /// <summary>
    /// Class EcsManagementInteropClient.
    /// Implements the <see cref="Commands.StorageSync.Interop.Interfaces.IEcsManagement" />
    /// </summary>
    /// <seealso cref="Commands.StorageSync.Interop.Interfaces.IEcsManagement" />
    public class EcsManagementInteropClient : IEcsManagement
    {
        // Non-constants because they are passed as ref parameters.
        /// <summary>
        /// The CLSID c ecs management
        /// </summary>
        private static Guid CLSID_CEcsManagement = ManagementInteropConstants.CLSID_CEcsManagement;
        /// <summary>
        /// The iid i ecs management
        /// </summary>
        private static Guid IID_IEcsManagement = ManagementInteropConstants.IID_IEcsManagement;
        /// <summary>
        /// The iid i unknown
        /// </summary>
        private static Guid IID_IUnknown = ManagementInteropConstants.IID_IUnknown;
        /// <summary>
        /// the iid stbale version deep gc progress.
        /// </summary>
        private static Guid IID_IStableVersionDeepGcProgress = ManagementInteropConstants.IID_IStableVersionDeepGcProgress;
        /// <summary>
        /// the iid stbale version deep gc progress.
        /// </summary>
        private static Guid IID_IScrubbingEngineConnectionPoint = ManagementInteropConstants.IID_IScrubbingEngineConnectionPoint;

        /// <summary>
        /// The m management object handle
        /// </summary>
        private COMReleaseHandle m_managementObjectHandle = new COMReleaseHandle();
        /// <summary>
        /// The m management object
        /// </summary>
        private IEcsManagement m_managementObject;
        /// <summary>
        /// Gets a value indicating whether this instance has valid handle.
        /// </summary>
        /// <value><c>true</c> if this instance has valid handle; otherwise, <c>false</c>.</value>
        protected virtual bool HasValidHandle
        {
            get { return !m_managementObjectHandle.IsInvalid; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EcsManagementInteropClient" /> class.
        /// </summary>
        public EcsManagementInteropClient()
        {
            m_managementObject = Initialize();
        }
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns>IEcsManagement.</returns>
        /// <exception cref="Commands.StorageSync.Interop.Exceptions.ServerRegistrationException">
        /// </exception>
        /// <exception cref="ServerRegistrationException"></exception>
        protected virtual IEcsManagement Initialize()
        {
            var managementInterfacePointer = IntPtr.Zero;
            int hr = Win32Helper.CoCreateInstance(
                ref CLSID_CEcsManagement,
                null,
                ManagementInteropConstants.CLSCTX_LOCAL_SERVER,
                ref IID_IEcsManagement,
                out managementInterfacePointer);
            //  Validations for ensuring success of creating com instance.
            if (hr != 0)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.CoCreateInstanceFailed, hr, ErrorCategory.InvalidResult);
            }
            if (managementInterfacePointer == IntPtr.Zero)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.CoCreateInstanceFailed, ErrorCategory.InvalidOperation);
            }
            m_managementObjectHandle.AttachHandle(managementInterfacePointer);
            m_managementObject = (IEcsManagement)Marshal.GetObjectForIUnknown(managementInterfacePointer);
            if (m_managementObject == null)
            {
                throw new ServerRegistrationException(ServerRegistrationErrorCode.CoCreateInstanceFailed, ErrorCategory.InvalidOperation);
            }
            CoSetProxyBlanket(managementInterfacePointer);
            return m_managementObject;
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            DisposeInternal(true);
        }
        /// <summary>
        /// Finalizes an instance of the <see cref="EcsManagementInteropClient" /> class.
        /// </summary>
        ~EcsManagementInteropClient()
        {
            DisposeInternal(false);
        }
        /// <summary>
        /// Disposes the internal.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        private void DisposeInternal(bool disposing)
        {
            if (m_managementObject != null)
            {
                if (Marshal.IsComObject(m_managementObject))
                {
                    Marshal.ReleaseComObject(m_managementObject);
                }
                m_managementObject = null;
            }
            if (m_managementObjectHandle != null)
            {
                m_managementObjectHandle.Dispose();
                m_managementObjectHandle = null;
            }
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }
        /// <summary>
        /// Validates the sync server.
        /// </summary>
        /// <param name="serviceUri">The service URI.</param>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <param name="storageSyncServiceName">Name of the storage sync service.</param>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <returns>System.Int32.</returns>
        public int ValidateSyncServer([In, MarshalAs(UnmanagedType.BStr)] string serviceUri, [In, MarshalAs(UnmanagedType.BStr)] string subscriptionId, [In, MarshalAs(UnmanagedType.BStr)] string storageSyncServiceName, [In, MarshalAs(UnmanagedType.BStr)] string resourceGroupName)
        {
            return m_managementObject.ValidateSyncServer(serviceUri, subscriptionId, storageSyncServiceName, resourceGroupName);
        }
        /// <summary>
        /// Ensures the sync server certificate.
        /// </summary>
        /// <param name="serviceUri">The service URI.</param>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <param name="storageSyncServiceName">Name of the storage sync service.</param>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="certificateProviderName">Name of the certificate provider.</param>
        /// <param name="certificateHashAlgorithm">The certificate hash algorithm.</param>
        /// <param name="certificateKeyLength">Length of the certificate key.</param>
        /// <returns>System.Int32.</returns>
        public int EnsureSyncServerCertificate([In, MarshalAs(UnmanagedType.BStr)] string serviceUri, [In, MarshalAs(UnmanagedType.BStr)] string subscriptionId, [In, MarshalAs(UnmanagedType.BStr)] string storageSyncServiceName, [In, MarshalAs(UnmanagedType.BStr)] string resourceGroupName, [In, MarshalAs(UnmanagedType.BStr)] string certificateProviderName, [In, MarshalAs(UnmanagedType.BStr)] string certificateHashAlgorithm, [In, MarshalAs(UnmanagedType.U4)] uint certificateKeyLength)
        {
            return m_managementObject.EnsureSyncServerCertificate(serviceUri, subscriptionId, storageSyncServiceName, resourceGroupName, certificateProviderName, certificateHashAlgorithm, certificateKeyLength);
        }
        /// <summary>
        /// Registers the sync server.
        /// </summary>
        /// <param name="serviceUri">The service URI.</param>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <param name="storageSyncServiceName">Name of the storage sync service.</param>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="certificateProviderName">Name of the certificate provider.</param>
        /// <param name="certificateHashAlgorithm">The certificate hash algorithm.</param>
        /// <param name="certificateKeyLength">Length of the certificate key.</param>
        /// <param name="monitoringDataPath">The monitoring data path.</param>
        /// <returns>System.Int32.</returns>
        public int RegisterSyncServer([In, MarshalAs(UnmanagedType.BStr)] string serviceUri, [In, MarshalAs(UnmanagedType.BStr)] string subscriptionId, [In, MarshalAs(UnmanagedType.BStr)] string storageSyncServiceName, [In, MarshalAs(UnmanagedType.BStr)] string resourceGroupName, [In, MarshalAs(UnmanagedType.BStr)] string certificateProviderName, [In, MarshalAs(UnmanagedType.BStr)] string certificateHashAlgorithm, [In, MarshalAs(UnmanagedType.U4)] uint certificateKeyLength, [In, MarshalAs(UnmanagedType.BStr)] string monitoringDataPath)
        {
            return m_managementObject.RegisterSyncServer(serviceUri, subscriptionId, storageSyncServiceName, resourceGroupName, certificateProviderName, certificateHashAlgorithm, certificateKeyLength, monitoringDataPath);
        }
        /// <summary>
        /// Resets the sync server configuration.
        /// </summary>
        /// <param name="cleanClusterRegistration">if set to <c>true</c> [clean cluster registration].</param>
        /// <returns>System.Int32.</returns>
        public int ResetSyncServerConfiguration([In, MarshalAs(UnmanagedType.Bool)] bool cleanClusterRegistration)
        {
            return m_managementObject.ResetSyncServerConfiguration(cleanClusterRegistration);
        }
        /// <summary>
        /// Ghosts the path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="ghostingStats">The ghosting stats.</param>
        /// <returns>System.Int32.</returns>
        public int GhostPath([In, MarshalAs(UnmanagedType.BStr)] string path, [In, MarshalAs(UnmanagedType.Struct), Out] ref GHOSTING_STATS ghostingStats)
        {
            return m_managementObject.GhostPath(path, ref ghostingStats);
        }
        /// <summary>
        /// Sets the proxy setting.
        /// </summary>
        /// <param name="proxySetting">The proxy setting.</param>
        public void SetProxySetting([In, MarshalAs(UnmanagedType.Struct)] ProxySetting proxySetting)
        {
            m_managementObject.SetProxySetting(proxySetting);
        }
        /// <summary>
        /// Gets the proxy setting.
        /// </summary>
        /// <returns>ProxySetting.</returns>
        public ProxySetting GetProxySetting()
        {
            return m_managementObject.GetProxySetting();
        }
        /// <summary>
        /// Removes the proxy setting.
        /// </summary>
        public void RemoveProxySetting()
        {
            m_managementObject.RemoveProxySetting();
        }
        /// <summary>
        /// Scrubs the files.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="isDeepScan">if set to <c>true</c> [is deep scan].</param>
        /// <param name="reportPath">The report path.</param>
        /// <param name="scrubbingStats">The scrubbing stats.</param>
        /// <returns>System.Int32.</returns>
        public int ScrubFiles([In, MarshalAs(UnmanagedType.BStr)] string path, [In, MarshalAs(UnmanagedType.U4)] ScrubbingMode mode, [In, MarshalAs(UnmanagedType.Bool)] bool isDeepScan, [In, MarshalAs(UnmanagedType.BStr)] string reportPath, [In, MarshalAs(UnmanagedType.Struct), Out] ref SCRUBBING_STATS scrubbingStats)
        {
            return m_managementObject.ScrubFiles(path, mode, isDeepScan, reportPath, ref scrubbingStats);
        }
        /// <summary>
        /// Gets the storage sync server endpoint status.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="serverEndpointReports">The server endpoint reports.</param>
        /// <returns>System.Int32.</returns>
        public int GetStorageSyncServerEndpointStatus([In, MarshalAs(UnmanagedType.BStr)] string path, [In, Out, MarshalAs(UnmanagedType.BStr)] ref string serverEndpointReports)
        {
            return m_managementObject.GetStorageSyncServerEndpointStatus(path, ref serverEndpointReports);
        }
        /// <summary>
        /// Gets the storage sync registered server status.
        /// </summary>
        /// <param name="registeredServerStats">The registered server stats.</param>
        /// <returns>System.Int32.</returns>
        public int GetStorageSyncRegisteredServerStatus([In, MarshalAs(UnmanagedType.BStr), Out] ref string registeredServerStats)
        {
            return m_managementObject.GetStorageSyncRegisteredServerStatus(ref registeredServerStats);
        }
        /// <summary>
        /// Determines whether [is tiered file orphaned] [the specified path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if [is tiered file orphaned] [the specified path]; otherwise, <c>false</c>.</returns>
        public bool IsTieredFileOrphaned([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            return m_managementObject.IsTieredFileOrphaned(path);
        }
        /// <summary>
        /// Deletes the orphaned tiered file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool DeleteOrphanedTieredFile([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            return m_managementObject.DeleteOrphanedTieredFile(path);
        }
        /// <summary>
        /// Garbages the collect stable versions.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="garbageCollectionStats">The garbage collection stats.</param>
        /// <returns>System.Int32.</returns>
        public int GarbageCollectStableVersions([In, MarshalAs(UnmanagedType.BStr)] string path, [In, MarshalAs(UnmanagedType.U4)] GarbageCollectionMode mode, [In, MarshalAs(UnmanagedType.Struct), Out] ref GARBAGECOLLECTION_STATS garbageCollectionStats)
        {
            return m_managementObject.GarbageCollectStableVersions(path, mode, ref garbageCollectionStats);
        }
        /// <summary>
        /// Recalls the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="retryCount"></param>
        /// <param name="retryDelaySeconds"></param>
        /// <returns>RecallOutput.</returns>
        public RecallOutput RecallFile(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path,
            [In, MarshalAs(UnmanagedType.U4)]
            uint retryCount,
            [In, MarshalAs(UnmanagedType.U4)]
            uint retryDelaySeconds
        )
        {
            return m_managementObject.RecallFile(path, retryCount, retryDelaySeconds);
        }
        /// <summary>
        /// Determines whether [is path under sync share] [the specified path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="fileIdStr"></param>
        /// <param name="isPathUnderShare"></param>
        /// <param name="isPathShareRoot"></param>
        /// <returns><c>true</c> if [is path under sync share] [the specified path]; otherwise, <c>false</c>.</returns>
        public void IsPathUnderSyncShare(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string fileIdStr,
            [Out, MarshalAs(UnmanagedType.Bool)]
            out bool isPathUnderShare,
            [Out, MarshalAs(UnmanagedType.Bool)]
            out bool isPathShareRoot
        )
        {
            m_managementObject.IsPathUnderSyncShare(path, out fileIdStr, out isPathUnderShare, out isPathShareRoot);
        }
        /// <summary>
        /// Persists the sync server registration.
        /// </summary>
        /// <param name="serviceUri">The service URI.</param>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <param name="storageSyncServiceName">Name of the storage sync service.</param>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="clusterId">The cluster identifier.</param>
        /// <param name="clusterName">Name of the cluster.</param>
        /// <param name="storageSyncServiceUid">The storage sync service uid.</param>
        /// <param name="discoveryUri">The discovery URI.</param>
        /// <param name="serviceLocation">The service location.</param>
        /// <param name="resourceLocation">The resource location.</param>
        /// <returns>System.Int32.</returns>
        public int PersistSyncServerRegistration(
            [In, MarshalAs(UnmanagedType.BStr)] string serviceUri,
            [In, MarshalAs(UnmanagedType.BStr)] string subscriptionId,
            [In, MarshalAs(UnmanagedType.BStr)] string storageSyncServiceName,
            [In, MarshalAs(UnmanagedType.BStr)] string resourceGroupName,
            [In, MarshalAs(UnmanagedType.BStr)] string clusterId,
            [In, MarshalAs(UnmanagedType.BStr)] string clusterName,
            [In, MarshalAs(UnmanagedType.BStr)] string storageSyncServiceUid,
            [In, MarshalAs(UnmanagedType.BStr)] string discoveryUri,
            [In, MarshalAs(UnmanagedType.BStr)] string serviceLocation,
            [In, MarshalAs(UnmanagedType.BStr)] string resourceLocation)
        {
            return m_managementObject.PersistSyncServerRegistration(
                serviceUri,
                subscriptionId,
                storageSyncServiceName,
                resourceGroupName,
                clusterId,
                clusterName,
                storageSyncServiceUid,
                discoveryUri,
                serviceLocation,
                resourceLocation);
        }
        /// <summary>
        /// Rollovers the secondary certificate.
        /// </summary>
        /// <param name="certificateProviderName">Name of the certificate provider.</param>
        /// <param name="certificateHashAlgorithm">The certificate hash algorithm.</param>
        /// <param name="certificateKeyLength">Length of the certificate key.</param>
        /// <param name="serverCertificateThumbprint">The server certificate thumbprint.</param>
        /// <returns>System.Int32.</returns>
        public int RolloverSecondaryCertificate(
            [In, MarshalAs(UnmanagedType.BStr)] string certificateProviderName,
            [In, MarshalAs(UnmanagedType.BStr)] string certificateHashAlgorithm,
            [In, MarshalAs(UnmanagedType.U4)] uint certificateKeyLength,
            [Out, MarshalAs(UnmanagedType.BStr)] out string serverCertificateThumbprint)
        {
            return m_managementObject.RolloverSecondaryCertificate(certificateProviderName, certificateHashAlgorithm, certificateKeyLength, out serverCertificateThumbprint);
        }
        /// <summary>
        /// Gets the server certificate thumbprints.
        /// </summary>
        /// <param name="primaryCertificateThumbprint">The primary certificate thumbprint.</param>
        /// <param name="secondaryCertificateThumbprint">The secondary certificate thumbprint.</param>
        /// <returns>System.Int32.</returns>
        public int GetServerCertificateThumbprints(
            [Out, MarshalAs(UnmanagedType.BStr)] out string primaryCertificateThumbprint,
            [Out, MarshalAs(UnmanagedType.BStr)] out string secondaryCertificateThumbprint)
        {
            return m_managementObject.GetServerCertificateThumbprints(out primaryCertificateThumbprint, out secondaryCertificateThumbprint);
        }
        /// <summary>
        /// Deletes the server certificate.
        /// </summary>
        /// <param name="certificateThumbprint">The certificate thumbprint.</param>
        /// <returns>System.Int32.</returns>
        public int DeleteServerCertificate(
            [In, MarshalAs(UnmanagedType.BStr)] string certificateThumbprint)
        {
            return m_managementObject.DeleteServerCertificate(certificateThumbprint);
        }
        /// <summary>
        /// Switches to secondary certificate and update monitoring.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int SwitchToSecondaryCertificateAndUpdateMonitoring()
        {
            return m_managementObject.SwitchToSecondaryCertificateAndUpdateMonitoring();
        }
        /// <summary>
        /// Gets the sync server certificate.
        /// </summary>
        /// <param name="isPrimary">if set to <c>true</c> [is primary].</param>
        /// <param name="serverCertificate">The server certificate.</param>
        /// <returns>System.Int32.</returns>
        public int GetSyncServerCertificate([In, MarshalAs(UnmanagedType.Bool)] bool isPrimary, [MarshalAs(UnmanagedType.BStr), Out] out string serverCertificate)
        {
            return m_managementObject.GetSyncServerCertificate(isPrimary, out serverCertificate);
        }
        /// <summary>
        /// Gets the sync server identifier.
        /// </summary>
        /// <param name="serverId">The server identifier.</param>
        /// <returns>System.Int32.</returns>
        public int GetSyncServerId([MarshalAs(UnmanagedType.BStr), Out] out string serverId)
        {
            return m_managementObject.GetSyncServerId(out serverId);
        }
        /// <summary>
        /// Gets the cluster information.
        /// </summary>
        /// <param name="clusterId">The cluster identifier.</param>
        /// <param name="clusterName">Name of the cluster.</param>
        /// <returns>System.Int32.</returns>
        public int GetClusterInfo([MarshalAs(UnmanagedType.BStr), Out] out string clusterId, [MarshalAs(UnmanagedType.BStr), Out] out string clusterName)
        {
            return m_managementObject.GetClusterInfo(out clusterId, out clusterName);
        }
        /// <summary>
        /// Determines whether [is in cluster].
        /// </summary>
        /// <returns><c>true</c> if [is in cluster]; otherwise, <c>false</c>.</returns>
        public bool IsInCluster()
        {
            return m_managementObject.IsInCluster();
        }
        /// <summary>
        /// Registers the monitoring agent.
        /// </summary>
        /// <param name="serverRegistrationData">The server registration data.</param>
        /// <param name="monitoringDataPath">The monitoring data path.</param>
        /// <returns>System.Int32.</returns>
        public int RegisterMonitoringAgent([MarshalAs(UnmanagedType.BStr)] string serverRegistrationData, [MarshalAs(UnmanagedType.BStr)] string monitoringDataPath)
        {
            return m_managementObject.RegisterMonitoringAgent(serverRegistrationData, monitoringDataPath);
        }
        /// <summary>
        /// Creates new networklimit.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>System.String.</returns>
        [return: MarshalAs(UnmanagedType.BStr)]
        public string NewNetworkLimit([In, MarshalAs(UnmanagedType.Interface)] INetworkLimitConfigEntry config)
        {
            return m_managementObject.NewNetworkLimit(config);
        }
        /// <summary>
        /// Gets the network limits.
        /// </summary>
        /// <returns>INetworkLimitConfigurationEntryEnumeration.</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        public INetworkLimitConfigurationEntryEnumeration GetNetworkLimits()
        {
            return m_managementObject.GetNetworkLimits();
        }
        /// <summary>
        /// Gets the network limit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>INetworkLimitConfigEntry.</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        public INetworkLimitConfigEntry GetNetworkLimit([In, MarshalAs(UnmanagedType.BStr)] string id)
        {
            return m_managementObject.GetNetworkLimit(id);
        }
        /// <summary>
        /// Removes the network limit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void RemoveNetworkLimit([In, MarshalAs(UnmanagedType.BStr)] string id)
        {
            m_managementObject.RemoveNetworkLimit(id);
        }
        public void SetAutoUpdatePolicy([In, MarshalAs(UnmanagedType.Struct)] AutoUpdatePolicy autoUpdatePolicy)
        {
            m_managementObject.SetAutoUpdatePolicy(autoUpdatePolicy);
        }
        public void LogOrphanedTieredFilesTelemetry([In, MarshalAs(UnmanagedType.Struct)] OrphanedTieredFilesTelemetryReport orphanedTieredFilesTelemetryReport)
        {
            m_managementObject.LogOrphanedTieredFilesTelemetry(orphanedTieredFilesTelemetryReport);
        }

        public void PopulateFileInfoUsingHeatOrder(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path,
            [In, MarshalAs(UnmanagedType.BStr)]
            string recallCmdletLogPath,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string recallMountPath,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string volumeGuid)
        {
            m_managementObject.PopulateFileInfoUsingHeatOrder(path, recallCmdletLogPath, out recallMountPath, out volumeGuid);
        }

        public void LogRecallFilesTelemetry([In, MarshalAs(UnmanagedType.Struct)] RecallFilesTelemetryReport recallFilesTelemetryReport)
        {
            m_managementObject.LogRecallFilesTelemetry(recallFilesTelemetryReport);
        }

        public AutoUpdatePolicy GetAutoUpdatePolicy()
        {
            return m_managementObject.GetAutoUpdatePolicy();
        }
        public HeatStoreSummary PopulateHeatStoreInformation([In, MarshalAs(UnmanagedType.BStr)] string volumePath, [In, MarshalAs(UnmanagedType.BStr)] string reportDirectoryPath, [In, MarshalAs(UnmanagedType.U4)] HeatStoreEnumeratorType enumeratorType, [In, MarshalAs(UnmanagedType.U8)] ulong maxRecordsLimit)
        {
            return m_managementObject.PopulateHeatStoreInformation(volumePath, reportDirectoryPath, enumeratorType, maxRecordsLimit);
        }
        public bool GetFilePathUsingId([MarshalAs(UnmanagedType.BStr), In] string volumeGuid,
                                       [MarshalAs(UnmanagedType.U8), In] ulong fileId,
                                       [MarshalAs(UnmanagedType.BStr), Out] out string filePath)
        {
            return m_managementObject.GetFilePathUsingId(volumeGuid, fileId, out filePath);
        }
        [return: MarshalAs(UnmanagedType.BStr)]
        public string GetFileLockIdUsingPath([In, MarshalAs(UnmanagedType.BStr)] string filePath)
        {
            return m_managementObject.GetFileLockIdUsingPath(filePath);
        }
        public void SetLockBypassForSyncShare([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot,
                                              [In, MarshalAs(UnmanagedType.Bool)] bool bypassValue)
        {
            m_managementObject.SetLockBypassForSyncShare(syncShareRoot, bypassValue);
        }
        public HeatStoreFileInfo GetHeatStoreFileInformation([In, MarshalAs(UnmanagedType.BStr)] string filePath)
        {
            return m_managementObject.GetHeatStoreFileInformation(filePath);
        }
        public SelfServiceRestore EnableSelfServiceRestore([In, MarshalAs(UnmanagedType.BStr)] string volume)
        {
            return m_managementObject.EnableSelfServiceRestore(volume);
        }
        public SelfServiceRestore GetSelfServiceRestore([In, MarshalAs(UnmanagedType.BStr)] string volume)
        {
            return m_managementObject.GetSelfServiceRestore(volume);
        }
        public void DisableSelfServiceRestore([In, MarshalAs(UnmanagedType.BStr)] string volume)
        {
            m_managementObject.DisableSelfServiceRestore(volume);
        }
        public void RunNetworkConnectivityCheck([In, MarshalAs(UnmanagedType.Bool)] bool measureBandwidth,
                                                [Out, MarshalAs(UnmanagedType.Bool)] out bool testPassed,
                                                [Out, MarshalAs(UnmanagedType.BStr)] out string report)
        {
            m_managementObject.RunNetworkConnectivityCheck(measureBandwidth, out testPassed, out report);
        }
        public void TriggerOrphanedTieredFilesCleanup([In, MarshalAs(UnmanagedType.BStr)] string dataPath,
                                                      [In, MarshalAs(UnmanagedType.BStr)] string context,
                                                      [In, MarshalAs(UnmanagedType.BStr)] string clientCorrelationId)
        {
            m_managementObject.TriggerOrphanedTieredFilesCleanup(dataPath, context, clientCorrelationId);
        }
        [return: MarshalAs(UnmanagedType.Bool)]
        public bool DoesOrphanedTieredFilesMarkerExist([In, MarshalAs(UnmanagedType.BStr)] string dataPath,
                                                       [In, MarshalAs(UnmanagedType.BStr)] string context,
                                                       [In, MarshalAs(UnmanagedType.BStr)] string clientCorrelationId)
        {
            return m_managementObject.DoesOrphanedTieredFilesMarkerExist(dataPath, context, clientCorrelationId);
        }
        public void RemoveOrphanedTieredFilesMarker([In, MarshalAs(UnmanagedType.BStr)] string dataPath)
        {
            m_managementObject.RemoveOrphanedTieredFilesMarker(dataPath);
        }
        [return: MarshalAs(UnmanagedType.U4)]
        public uint GetReparseTag([In, MarshalAs(UnmanagedType.BStr)] string filePath)
        {
            return m_managementObject.GetReparseTag(filePath);
        }
        [return: MarshalAs(UnmanagedType.Bool)]
        public bool IsPathUnderSVIOrRecycleBin([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            return m_managementObject.IsPathUnderSVIOrRecycleBin(path);
        }
        public IFileAccessPatternStatsEnumerator GetFileAccessPattern([In, MarshalAs(UnmanagedType.BStr)] string serverEndpointPath)
        {
            return m_managementObject.GetFileAccessPattern(serverEndpointPath);
        }
        public TieringPolicyRecommendations GetTieringPolicyRecommendations(
            [In, MarshalAs(UnmanagedType.BStr)] string serverEndpointPath,
            [In, MarshalAs(UnmanagedType.U4)] PolicyAdvisorMode policyAdvisorMode
        )
        {
            return m_managementObject.GetTieringPolicyRecommendations(serverEndpointPath, policyAdvisorMode);
        }
        public LockingStateInfo GetLockingStateInformationUsingFilePath([In, MarshalAs(UnmanagedType.BStr)] string filePath)
        {
            return m_managementObject.GetLockingStateInformationUsingFilePath(filePath);
        }
        public LockingStateInfo GetLockingStateInformationUsingLockId(
            [In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot,
            [In, MarshalAs(UnmanagedType.BStr)] string lockId)
        {
            return m_managementObject.GetLockingStateInformationUsingLockId(syncShareRoot, lockId);
        }
        public int InitializeCmdletGhosting(
            [In, MarshalAs(UnmanagedType.BStr)] string path,
            [Out, MarshalAs(UnmanagedType.BStr)] out string tieringCmdletLogPath,
            [Out, MarshalAs(UnmanagedType.U4)] out uint totalFiles,
            [Out, MarshalAs(UnmanagedType.BStr)] out string ghostingSessionGuid)
        {
            return m_managementObject.InitializeCmdletGhosting(path, out tieringCmdletLogPath, out totalFiles, out ghostingSessionGuid);
        }
        public int GhostBatch(
            [In, MarshalAs(UnmanagedType.BStr)] string tieringCmdletLogPath,
            [In, MarshalAs(UnmanagedType.BStr)] string ghostingSessionGuid,
            [Out, MarshalAs(UnmanagedType.U4)] out uint fileCount,
            [In, MarshalAs(UnmanagedType.Struct), Out] ref GHOSTING_STATS ghostingStats,
            [In, MarshalAs(UnmanagedType.U4)] uint minimumFileAgeDays)
        {
            return m_managementObject.GhostBatch(tieringCmdletLogPath, ghostingSessionGuid, out fileCount, ref ghostingStats, minimumFileAgeDays);
        }
        public int FinalizeCmdletGhosting(
            [In, MarshalAs(UnmanagedType.BStr)] string tieringCmdletLogPath,
            [In, MarshalAs(UnmanagedType.BStr)] string ghostingSessionGuid)
        {
            return m_managementObject.FinalizeCmdletGhosting(tieringCmdletLogPath, ghostingSessionGuid);
        }
        public int AddAllowedServerEndpointPath(
            [In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            return m_managementObject.AddAllowedServerEndpointPath(path);
        }
        public int GetAllowedServerEndpointPaths(
            [In, Out, MarshalAs(UnmanagedType.LPArray)] ref string[] paths)
        {
            return m_managementObject.GetAllowedServerEndpointPaths(ref paths);
        }
        public int RemoveAllowedServerEndpointPath(
            [In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            return m_managementObject.RemoveAllowedServerEndpointPath(path);
        }
        public int SetIsAuthoritativeSyncEnabled(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, MarshalAs(UnmanagedType.Bool)]
            bool isAuthoritativeSyncEnabled)
        {
            return m_managementObject.SetIsAuthoritativeSyncEnabled(syncShareRoot, isAuthoritativeSyncEnabled);
        }
        public int GetIsAuthoritativeSyncEnabled(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [Out, MarshalAs(UnmanagedType.Bool)]
            out bool isAuthoritativeSyncEnabled)
        {
            return m_managementObject.GetIsAuthoritativeSyncEnabled(syncShareRoot, out isAuthoritativeSyncEnabled);
        }
        public int GetReplicaFlags(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [Out, MarshalAs(UnmanagedType.U4)]
            out SyncFlags replicaFlags)
        {
            return m_managementObject.GetReplicaFlags(syncShareRoot, out replicaFlags);
        }
        public int SetIsSyncDisabled(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, MarshalAs(UnmanagedType.Bool)]
            bool isSyncDisabled)
        {
            return m_managementObject.SetIsSyncDisabled(syncShareRoot, isSyncDisabled);
        }
        public void PopulateFileInfoUsingRPIterator(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncGroupName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string recallCmdletLogPath,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string volumeGuid)
        {
            m_managementObject.PopulateFileInfoUsingRPIterator(syncGroupName, recallCmdletLogPath, out volumeGuid);
        }
        public int SetMaxFileSizeLimit(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, MarshalAs(UnmanagedType.U8)]
            ulong maxFileSize)
        {
            return m_managementObject.SetMaxFileSizeLimit(syncShareRoot, maxFileSize);
        }
        public int GetMaxFileSizeLimit(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [Out, MarshalAs(UnmanagedType.U8)]
            out ulong maxFileSize)
        {
            return m_managementObject.GetMaxFileSizeLimit(syncShareRoot, out maxFileSize);
        }
        public int GetIsSyncDisabled(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [Out, MarshalAs(UnmanagedType.Bool)]
            out bool isSyncDisabled)
        {
            return m_managementObject.GetIsSyncDisabled(syncShareRoot, out isSyncDisabled);
        }
        public int SetServiceRootCertificateThumbprint(
            [In, MarshalAs(UnmanagedType.BStr)]
            string serviceRootCertificateThumbprint)
        {
            return m_managementObject.SetServiceRootCertificateThumbprint(serviceRootCertificateThumbprint);
        }
        public int GetServiceRootCertificateThumbprint(
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string serviceRootCertificateThumbprint)
        {
            return m_managementObject.GetServiceRootCertificateThumbprint(out serviceRootCertificateThumbprint);
        }
        public int NewSyncSession(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, MarshalAs(UnmanagedType.U4)]
            SyncDirection syncDirection,
            [In, MarshalAs(UnmanagedType.U4)]
            SyncScenario syncScenario,
            [Out, MarshalAs(UnmanagedType.Bool)]
            bool cancelExisting,
            [In, Out, MarshalAs(UnmanagedType.Struct)]
            ref NEW_SYNC_SESSION_SCHEDULE_RESULT newSyncSessionScheduleResult)
        {
            return m_managementObject.NewSyncSession(
                syncShareRoot,
                syncDirection,
                syncScenario,
                cancelExisting,
                ref newSyncSessionScheduleResult);
        }
        public int GetSyncSessionStatuses(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, MarshalAs(UnmanagedType.BStr)]
            string sessionId,
            [In, MarshalAs(UnmanagedType.U4)]
            uint limit,
            [In, Out, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
            ref byte[] inProgressSyncSessionStatusList,
            [In, Out, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
            ref byte[] completedSyncSessionStatusList)
        {
            return m_managementObject.GetSyncSessionStatuses(
                syncShareRoot,
                sessionId,
                limit,
                ref inProgressSyncSessionStatusList,
                ref completedSyncSessionStatusList);
        }
        public int GetErrorTextDescription(
            [In, MarshalAs(UnmanagedType.I8)]
            long hr,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string errorText)
        {
            return m_managementObject.GetErrorTextDescription(hr, out errorText);
        }
        public VOLUME_STATUS GetVolumeStatus(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot)
        {
            return m_managementObject.GetVolumeStatus(syncShareRoot);
        }
        public TIERING_STATUS GetTieringStatusEndpoint(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot)
        {
            return m_managementObject.GetTieringStatusEndpoint(syncShareRoot);
        }
        public void DiagnoseServerIssues([Out, MarshalAs(UnmanagedType.BStr)] out string diagnosisOutputsJson)
        {
            m_managementObject.DiagnoseServerIssues(out diagnosisOutputsJson);
        }
        public int TriggerServerChangeDetection(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, MarshalAs(UnmanagedType.Bool)]
            bool deepScan)
        {
            return m_managementObject.TriggerServerChangeDetection(syncShareRoot, deepScan);
        }
        public int GetServerChangeDetectionStatuses(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, Out, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
            ref byte[] inProgressStatus,
            [In, Out, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
            ref byte[] completedStatus)
        {
            return m_managementObject.GetServerChangeDetectionStatuses(
                syncShareRoot,
                ref inProgressStatus,
                ref completedStatus);
        }
        public int StableVersionsDeepGC([In, MarshalAs(UnmanagedType.BStr)] string path,
                                       [In, MarshalAs(UnmanagedType.U4)] uint cookie,
                                       [In, MarshalAs(UnmanagedType.Struct), Out] ref STABLEVERSION_DEEP_GC_STATS stableVersionDeepGCStats)
        {
            return m_managementObject.StableVersionsDeepGC(path, cookie, ref stableVersionDeepGCStats);
        }
        public int GetMIConfigurationStatus(
            [Out, MarshalAs(UnmanagedType.U4)] out uint serverType,
            [Out, MarshalAs(UnmanagedType.U4)] out uint serverAuthType)
        {
            // returns HRESULT directly, serverType and serverAuthType by reference
            // note that the c++ helper returns a full object with additional info but these are all that
            // are currently needed in the management stack
            return m_managementObject.GetMIConfigurationStatus(out serverType, out serverAuthType);
        }
        public IConnectionPoint GetScrubbingEngineConnectionPoint()
        {
            IConnectionPointContainer m_connectionPointContainer = (IConnectionPointContainer)m_managementObject;
            IConnectionPoint cp;
            m_connectionPointContainer.FindConnectionPoint(ref IID_IScrubbingEngineConnectionPoint, out cp);
            return cp;
        }
        public IConnectionPoint GetStableVersionDeepGcConnectionPoint()
        {
            IConnectionPointContainer m_connectionPointContainer = (IConnectionPointContainer)m_managementObject;
            IConnectionPoint cp;
            m_connectionPointContainer.FindConnectionPoint(ref IID_IStableVersionDeepGcProgress, out cp);
            return cp;
        }
        /// <summary>
        /// Coes the set proxy blanket.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <param name="dwAuthnSvc">The dw authn SVC.</param>
        /// <param name="dwAuthzSvc">The dw authz SVC.</param>
        /// <param name="pServerPrincName">Name of the p server princ.</param>
        /// <param name="dwAuthnLevel">The dw authn level.</param>
        /// <param name="dwImpLevel">The dw imp level.</param>
        /// <param name="dwCapababilities">The dw capababilities.</param>
        /// <param name="exception">if set to <c>true</c> [exception].</param>
        /// <returns>System.Int32.</returns>
        private static int CoSetProxyBlanket(IntPtr proxy,
           uint dwAuthnSvc = ManagementInteropConstants.RPC_C_AUTHN_DEFAULT,
           uint dwAuthzSvc = ManagementInteropConstants.RPC_C_AUTHZ_NONE,
           string pServerPrincName = null,
           RpcAuthnLevel dwAuthnLevel = RpcAuthnLevel.Default,
           RpcImpLevel dwImpLevel = RpcImpLevel.Impersonate,
           OleAuthCapabilities dwCapababilities = OleAuthCapabilities.EOACNONE,
           bool exception = true)
        {
            return CoSetProxyBlanket(
                proxy,
                dwAuthnSvc,
                dwAuthzSvc,
                pServerPrincName,
                dwAuthnLevel,
                dwImpLevel,
                IntPtr.Zero,
                dwCapababilities,
                exception);
        }
        /// <summary>
        /// Coes the set proxy blanket.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <param name="dwAuthnSvc">The dw authn SVC.</param>
        /// <param name="dwAuthzSvc">The dw authz SVC.</param>
        /// <param name="pServerPrincName">Name of the p server princ.</param>
        /// <param name="dwAuthnLevel">The dw authn level.</param>
        /// <param name="dwImpLevel">The dw imp level.</param>
        /// <param name="pAuthInfo">The p authentication information.</param>
        /// <param name="dwCapababilities">The dw capababilities.</param>
        /// <param name="throwOnError">if set to <c>true</c> [throw on error].</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="COMException">CoSetProxyBlanket failed with HRESULT {hr:X}</exception>
        private static int CoSetProxyBlanket(IntPtr proxy,
            uint dwAuthnSvc,
            uint dwAuthzSvc,
            string pServerPrincName,
            RpcAuthnLevel dwAuthnLevel,
            RpcImpLevel dwImpLevel,
            IntPtr pAuthInfo,
            OleAuthCapabilities dwCapababilities,
            bool throwOnError)
        {
            //should be called once for process to be able to call into ecs com api's
            int hr = Win32Helper.CoSetProxyBlanket(
                proxy,
                dwAuthnSvc,
                dwAuthzSvc,
                pServerPrincName,
                dwAuthnLevel,
                dwImpLevel,
                pAuthInfo,
                dwCapababilities);
            //expected is 0
            if (HResult.Failed(hr) && throwOnError)
            {
                throw new COMException($"{StorageSyncResources.ComError1} {hr:X}");
            }
            return hr;
        }

    }
}
