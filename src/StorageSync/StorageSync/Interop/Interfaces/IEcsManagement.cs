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

namespace Commands.StorageSync.Interop.Interfaces
{
    using DataObjects;
    using Enums;
    using Commands.StorageSync.Interop.Interfaces;
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;

    /// <summary>
    /// Interface IEcsManagement
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    [Guid("F29EAB44-2C63-4ACE-8C05-67C2203CBED2"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEcsManagement : IDisposable
    {
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
        int RegisterSyncServer(
            [In, MarshalAs(UnmanagedType.BStr)]
            string serviceUri,
            [In, MarshalAs(UnmanagedType.BStr)]
            string subscriptionId,
            [In, MarshalAs(UnmanagedType.BStr)]
            string storageSyncServiceName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string resourceGroupName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string certificateProviderName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string certificateHashAlgorithm,
            [In, MarshalAs(UnmanagedType.U4)]
            uint certificateKeyLength,
            [In, MarshalAs(UnmanagedType.BStr)]
            string monitoringDataPath);

        /// <summary>
        /// Resets the sync server configuration.
        /// </summary>
        /// <param name="cleanClusterRegistration">if set to <c>true</c> [clean cluster registration].</param>
        /// <returns>System.Int32.</returns>
        int ResetSyncServerConfiguration(
            [In, MarshalAs(UnmanagedType.Bool)]
            bool cleanClusterRegistration);

        /// <summary>
        /// Ghosts the path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="ghostingStats">The ghosting stats.</param>
        /// <returns>System.Int32.</returns>
        int GhostPath(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path,
            [In, Out, MarshalAs(UnmanagedType.Struct)]
            ref GHOSTING_STATS ghostingStats);

        /// <summary>
        /// Sets the proxy setting.
        /// </summary>
        /// <param name="proxySetting">The proxy setting.</param>
        void SetProxySetting(
            [In, MarshalAs(UnmanagedType.Struct)]
            ProxySetting proxySetting);

        /// <summary>
        /// Gets the proxy setting.
        /// </summary>
        /// <returns>ProxySetting.</returns>
        ProxySetting GetProxySetting();

        /// <summary>
        /// Removes the proxy setting.
        /// </summary>
        void RemoveProxySetting();

        /// <summary>
        /// Scrubs the files.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="isDeepScan">if set to <c>true</c> [is deep scan].</param>
        /// <param name="reportPath">The report path.</param>
        /// <param name="scrubbingStats">The scrubbing stats.</param>
        /// <returns>System.Int32.</returns>
        int ScrubFiles(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path,
            [In, MarshalAs(UnmanagedType.U4)]
            ScrubbingMode mode,
            [In, MarshalAs(UnmanagedType.Bool)]
            bool isDeepScan,
            [In, MarshalAs(UnmanagedType.BStr)]
            string reportPath,
            [In, Out, MarshalAs(UnmanagedType.Struct)]
            ref SCRUBBING_STATS scrubbingStats);

        /// <summary>
        /// Recalls the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="retryCount">Retry count</param>
        /// <param name="retryDelaySeconds">Retry Delay seconds</param>
        /// <returns>RecallOutput.</returns>
        RecallOutput RecallFile(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path,
            [In, MarshalAs(UnmanagedType.U4)]
            uint retryCount,
            [In, MarshalAs(UnmanagedType.U4)]
            uint retryDelaySeconds);

        /// <summary>
        /// Determines whether [is path under sync share] [the specified path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="fileIdStr">File Id</param>
        /// <param name="isPathUnderShare">Is path under share.</param>
        /// <param name="isPathShareRoot">Is path share root.</param>
        /// <returns><c>true</c> if [is path under sync share] [the specified path]; otherwise, <c>false</c>.</returns>
        void IsPathUnderSyncShare(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string fileIdStr,
            [Out, MarshalAs(UnmanagedType.Bool)]
            out bool isPathUnderShare,
            [Out, MarshalAs(UnmanagedType.Bool)]
            out bool isPathShareRoot);

        /// <summary>
        /// Persists the sync server registration.
        /// </summary>
        /// <param name="serviceUri">The service URI.</param>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <param name="storageSyncServiceName">Name of the storage sync service.</param>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="clusterId">The cluster identifier.</param>
        /// <param name="clusterName">Name of the cluster.</param>
        /// <param name="discoveryUri">The discovery URI.</param>
        /// <param name="storageSyncServiceUid">The storage sync service uid.</param>
        /// <param name="serviceLocation">The service location.</param>
        /// <param name="resourceLocation">The resource location.</param>
        /// <returns>System.Int32.</returns>
        int PersistSyncServerRegistration(
            [In, MarshalAs(UnmanagedType.BStr)]
            string serviceUri,
            [In, MarshalAs(UnmanagedType.BStr)]
            string subscriptionId,
            [In, MarshalAs(UnmanagedType.BStr)]
            string storageSyncServiceName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string resourceGroupName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string clusterId,
            [In, MarshalAs(UnmanagedType.BStr)]
            string clusterName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string discoveryUri,
            [In, MarshalAs(UnmanagedType.BStr)]
            string storageSyncServiceUid,
            [In, MarshalAs(UnmanagedType.BStr)]
            string serviceLocation,
            [In, MarshalAs(UnmanagedType.BStr)]
            string resourceLocation);

        /// <summary>
        /// Gets the sync server certificate.
        /// </summary>
        /// <param name="isPrimary">if set to <c>true</c> [is primary].</param>
        /// <param name="serverCertificate">The server certificate.</param>
        /// <returns>System.Int32.</returns>
        int GetSyncServerCertificate(
            [In, MarshalAs(UnmanagedType.Bool)]
            bool isPrimary,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string serverCertificate);

        /// <summary>
        /// Gets the sync server identifier.
        /// </summary>
        /// <param name="serverId">The server identifier.</param>
        /// <returns>System.Int32.</returns>
        int GetSyncServerId(
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string serverId);

        /// <summary>
        /// Registers the monitoring agent.
        /// </summary>
        /// <param name="serverRegistrationData">The server registration data.</param>
        /// <param name="monitoringDataPath">The monitoring data path.</param>
        /// <returns>System.Int32.</returns>
        int RegisterMonitoringAgent(
            [MarshalAs(UnmanagedType.BStr)]
            string serverRegistrationData,
            [MarshalAs(UnmanagedType.BStr)]
            string monitoringDataPath);

        /// <summary>
        /// Creates new networklimit.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>System.String.</returns>
        [return: MarshalAs(UnmanagedType.BStr)]
        string NewNetworkLimit(
            [In, MarshalAs(UnmanagedType.Interface)]
            INetworkLimitConfigEntry config);

        /// <summary>
        /// Gets the network limits.
        /// </summary>
        /// <returns>INetworkLimitConfigurationEntryEnumeration.</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        INetworkLimitConfigurationEntryEnumeration GetNetworkLimits();

        /// <summary>
        /// Gets the network limit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>INetworkLimitConfigEntry.</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        INetworkLimitConfigEntry GetNetworkLimit(
            [In, MarshalAs(UnmanagedType.BStr)]
            string id);

        /// <summary>
        /// Removes the network limit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void RemoveNetworkLimit(
            [In, MarshalAs(UnmanagedType.BStr)]
            string id);

        /// <summary>
        /// Gets the cluster information.
        /// </summary>
        /// <param name="clusterId">The cluster identifier.</param>
        /// <param name="clusterName">Name of the cluster.</param>
        /// <returns>System.Int32.</returns>
        int GetClusterInfo(
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string clusterId,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string clusterName);

        /// <summary>
        /// Determines whether [is in cluster].
        /// </summary>
        /// <returns><c>true</c> if [is in cluster]; otherwise, <c>false</c>.</returns>
        bool IsInCluster();

        /// <summary>
        /// Validates the sync server.
        /// </summary>
        /// <param name="serviceUri">The service URI.</param>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <param name="storageSyncServiceName">Name of the storage sync service.</param>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <returns>System.Int32.</returns>
        int ValidateSyncServer(
            [In, MarshalAs(UnmanagedType.BStr)]
            string serviceUri,
            [In, MarshalAs(UnmanagedType.BStr)]
            string subscriptionId,
            [In, MarshalAs(UnmanagedType.BStr)]
            string storageSyncServiceName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string resourceGroupName);

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
        int EnsureSyncServerCertificate(
            [In, MarshalAs(UnmanagedType.BStr)]
            string serviceUri,
            [In, MarshalAs(UnmanagedType.BStr)]
            string subscriptionId,
            [In, MarshalAs(UnmanagedType.BStr)]
            string storageSyncServiceName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string resourceGroupName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string certificateProviderName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string certificateHashAlgorithm,
            [In, MarshalAs(UnmanagedType.U4)]
            uint certificateKeyLength);

        /// <summary>
        /// Garbages the collect stable versions.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <param name="Mode">The mode.</param>
        /// <param name="GarbageCollectionStats">The garbage collection stats.</param>
        /// <returns>System.Int32.</returns>
        int GarbageCollectStableVersions(
            [In, MarshalAs(UnmanagedType.BStr)]
            string Path,
            [In, MarshalAs(UnmanagedType.U4)]
            GarbageCollectionMode Mode,
            [In, Out, MarshalAs(UnmanagedType.Struct)]
            ref GARBAGECOLLECTION_STATS GarbageCollectionStats);

        /// <summary>
        /// Gets the storage sync server endpoint status.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="serverEndpointReports">The server endpoint reports.</param>
        /// <returns>System.Int32.</returns>
        int GetStorageSyncServerEndpointStatus(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path,
            [In, Out, MarshalAs(UnmanagedType.BStr)]
            ref string serverEndpointReports);

        /// <summary>
        /// Gets the storage sync registered server status.
        /// </summary>
        /// <param name="registeredServerStats">The registered server stats.</param>
        /// <returns>System.Int32.</returns>
        int GetStorageSyncRegisteredServerStatus(
            [In, MarshalAs(UnmanagedType.BStr), Out]
            ref string registeredServerStats);

        /// <summary>
        /// Rollovers the secondary certificate.
        /// </summary>
        /// <param name="certificateProviderName">Name of the certificate provider.</param>
        /// <param name="certificateHashAlgorithm">The certificate hash algorithm.</param>
        /// <param name="certificateKeyLength">Length of the certificate key.</param>
        /// <param name="serverCertificateThumbprint">The server certificate thumbprint.</param>
        /// <returns>System.Int32.</returns>
        int RolloverSecondaryCertificate(
            [In, MarshalAs(UnmanagedType.BStr)]
            string certificateProviderName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string certificateHashAlgorithm,
            [In, MarshalAs(UnmanagedType.U4)]
            uint certificateKeyLength,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string serverCertificateThumbprint);

        /// <summary>
        /// Gets the server certificate thumbprints.
        /// </summary>
        /// <param name="primaryCertificateThumbprint">The primary certificate thumbprint.</param>
        /// <param name="secondaryCertificateThumbprint">The secondary certificate thumbprint.</param>
        /// <returns>System.Int32.</returns>
        int GetServerCertificateThumbprints(
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string primaryCertificateThumbprint,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string secondaryCertificateThumbprint);

        /// <summary>
        /// Deletes the server certificate.
        /// </summary>
        /// <param name="certificateThumbprint">The certificate thumbprint.</param>
        /// <returns>System.Int32.</returns>
        int DeleteServerCertificate(
            [In, MarshalAs(UnmanagedType.BStr)]
            string certificateThumbprint);

        /// <summary>
        /// Switches to secondary certificate and update monitoring.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int SwitchToSecondaryCertificateAndUpdateMonitoring();

        /// <summary>
        /// Determines whether [is tiered file orphaned] [the specified path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if [is tiered file orphaned] [the specified path]; otherwise, <c>false</c>.</returns>
        bool IsTieredFileOrphaned(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path);

        /// <summary>
        /// Deletes the orphaned tiered file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool DeleteOrphanedTieredFile(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path);


        void SetAutoUpdatePolicy(
            [In, MarshalAs(UnmanagedType.Struct)]
            AutoUpdatePolicy autoUpdatePolicy);

        AutoUpdatePolicy GetAutoUpdatePolicy();

        bool GetFilePathUsingId(
            [In, MarshalAs(UnmanagedType.BStr)]
            string volumeGuid,
            [In, MarshalAs(UnmanagedType.U8)]
            ulong fileId,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string filePath);

        void LogOrphanedTieredFilesTelemetry(
            [In, MarshalAs(UnmanagedType.Struct)]
            OrphanedTieredFilesTelemetryReport orphanedTieredFilesTelemetryReport);

        void PopulateFileInfoUsingHeatOrder(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path,
            [In, MarshalAs(UnmanagedType.BStr)]
            string recallCmdletLogPath,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string recallMountPath,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string volumeGuid);

        void LogRecallFilesTelemetry(
            [In, MarshalAs(UnmanagedType.Struct)]
            RecallFilesTelemetryReport recallFilesTelemetryReport);

        HeatStoreSummary PopulateHeatStoreInformation(
            [In, MarshalAs(UnmanagedType.BStr)]
            string volumePath,
            [In, MarshalAs(UnmanagedType.BStr)]
            string reportDirectoryPath,
            [In, MarshalAs(UnmanagedType.U4)]
            HeatStoreEnumeratorType enumeratorType,
            [In, MarshalAs(UnmanagedType.U8)]
            ulong maxRecordsLimit);

        [return: MarshalAs(UnmanagedType.BStr)]
        string GetFileLockIdUsingPath(
            [In, MarshalAs(UnmanagedType.BStr)]
            string filePath);

        void SetLockBypassForSyncShare(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, MarshalAs(UnmanagedType.Bool)]
            bool bypassValue);

        HeatStoreFileInfo GetHeatStoreFileInformation(
            [In, MarshalAs(UnmanagedType.BStr)]
            string filePath);

        SelfServiceRestore EnableSelfServiceRestore(
            [In, MarshalAs(UnmanagedType.BStr)]
            string volume);

        SelfServiceRestore GetSelfServiceRestore(
            [In, MarshalAs(UnmanagedType.BStr)]
            string volume);

        void DisableSelfServiceRestore(
            [In, MarshalAs(UnmanagedType.BStr)]
            string volume);

        void RunNetworkConnectivityCheck(
           [In, MarshalAs(UnmanagedType.Bool)]
            bool measureBandwidth,
           [Out, MarshalAs(UnmanagedType.Bool)]
            out bool testPassed,
           [Out, MarshalAs(UnmanagedType.BStr)]
            out string report);

        void TriggerOrphanedTieredFilesCleanup(
           [In, MarshalAs(UnmanagedType.BStr)]
            string dataPath,
           [In, MarshalAs(UnmanagedType.BStr)]
            string context,
           [In, MarshalAs(UnmanagedType.BStr)]
            string clientCorrelationId);

        [return: MarshalAs(UnmanagedType.Bool)]
        bool DoesOrphanedTieredFilesMarkerExist(
           [In, MarshalAs(UnmanagedType.BStr)]
            string dataPath,
           [In, MarshalAs(UnmanagedType.BStr)]
            string context,
           [In, MarshalAs(UnmanagedType.BStr)]
            string clientCorrelationId);

        void RemoveOrphanedTieredFilesMarker(
           [In, MarshalAs(UnmanagedType.BStr)]
            string dataPath);

        [return: MarshalAs(UnmanagedType.U4)]
        uint GetReparseTag(
           [In, MarshalAs(UnmanagedType.BStr)]
            string filePath);

        [return: MarshalAs(UnmanagedType.Bool)]
        bool IsPathUnderSVIOrRecycleBin(
           [In, MarshalAs(UnmanagedType.BStr)]
            string path);

        [return: MarshalAs(UnmanagedType.Interface)]
        IFileAccessPatternStatsEnumerator GetFileAccessPattern(
            [In, MarshalAs(UnmanagedType.BStr)]
            string serverEndpointPath);

        TieringPolicyRecommendations GetTieringPolicyRecommendations(
           [In, MarshalAs(UnmanagedType.BStr)]
            string serverEndpointPath,
           [In, MarshalAs(UnmanagedType.U4)]
            PolicyAdvisorMode policyAdvisorMode);

        LockingStateInfo GetLockingStateInformationUsingFilePath(
            [In, MarshalAs(UnmanagedType.BStr)]
            string filePath);

        LockingStateInfo GetLockingStateInformationUsingLockId(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, MarshalAs(UnmanagedType.BStr)]
            string lockId);

        int InitializeCmdletGhosting(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string tieringCmdletLogPath,
            [Out, MarshalAs(UnmanagedType.U4)]
            out uint totalFiles,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string ghostingSessionGuid);

        int GhostBatch(
            [In, MarshalAs(UnmanagedType.BStr)]
            string tieringCmdletLogPath,
            [In, MarshalAs(UnmanagedType.BStr)]
            string ghostingSessionGuid,
            [Out, MarshalAs(UnmanagedType.U4)]
            out uint fileCount,
            [In, Out, MarshalAs(UnmanagedType.Struct)]
            ref GHOSTING_STATS ghostingStats,
            [In, MarshalAs(UnmanagedType.U4)]
            uint minimumFileAgeDays);

        int FinalizeCmdletGhosting(
            [In, MarshalAs(UnmanagedType.BStr)]
            string tieringCmdletLogPath,
            [In, MarshalAs(UnmanagedType.BStr)]
            string ghostingSessionGuid);

        int AddAllowedServerEndpointPath(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path);

        int GetAllowedServerEndpointPaths(
            [In, Out, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
            ref string[] paths);

        int RemoveAllowedServerEndpointPath(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path);

        int SetIsAuthoritativeSyncEnabled(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, MarshalAs(UnmanagedType.Bool)]
            bool isAuthoritativeSyncEnabled);

        int GetIsAuthoritativeSyncEnabled(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [Out, MarshalAs(UnmanagedType.Bool)]
            out bool isAuthoritativeSyncEnabled);

        int GetReplicaFlags(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [Out, MarshalAs(UnmanagedType.U4)]
            out SyncFlags replicaFlags);

        int SetIsSyncDisabled(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, MarshalAs(UnmanagedType.Bool)]
            bool isSyncDisabled);

        void PopulateFileInfoUsingRPIterator(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncGroupName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string recallCmdletLogPath,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string volumeGuid);

        int SetMaxFileSizeLimit(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, MarshalAs(UnmanagedType.U8)]
            ulong maxFileSize);

        int GetMaxFileSizeLimit(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [Out, MarshalAs(UnmanagedType.U8)]
            out ulong maxFileSize);

        int GetIsSyncDisabled(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [Out, MarshalAs(UnmanagedType.Bool)]
            out bool isSyncDisabled);

        int SetServiceRootCertificateThumbprint(
            [In, MarshalAs(UnmanagedType.BStr)]
            string serviceRootCertificateThumbprint);

        int GetServiceRootCertificateThumbprint(
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string serviceRootCertificateThumbprint);

        int NewSyncSession(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, MarshalAs(UnmanagedType.U4)]
            SyncDirection syncDirection,
            [In, MarshalAs(UnmanagedType.U4)]
            SyncScenario syncScenario,
            [Out, MarshalAs(UnmanagedType.Bool)]
            bool cancelExisting,
            [In, Out, MarshalAs(UnmanagedType.Struct)]
            ref NEW_SYNC_SESSION_SCHEDULE_RESULT newSyncSessionScheduleResult);

        int GetSyncSessionStatuses(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, MarshalAs(UnmanagedType.BStr)]
            string sessionId,
            [In, MarshalAs(UnmanagedType.U4)]
            uint limit,
            [In, Out, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
            ref byte[] inProgressSyncSessionStatusList,
            [In, Out, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
            ref byte[] completedSyncSessionStatusList);

        int GetErrorTextDescription(
            [In, MarshalAs(UnmanagedType.I8)]
            long hr,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string errorText);

        VOLUME_STATUS GetVolumeStatus(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot);

        TIERING_STATUS GetTieringStatusEndpoint(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot);

        void DiagnoseServerIssues(
            [Out, MarshalAs(UnmanagedType.BStr)]
             out string diagnosisOutputsJson);

        int TriggerServerChangeDetection(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, MarshalAs(UnmanagedType.Bool)]
            bool deepScan);

        int GetServerChangeDetectionStatuses(
            [In, MarshalAs(UnmanagedType.BStr)]
            string syncShareRoot,
            [In, Out, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
            ref byte[] inProgressStatus,
            [In, Out, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
            ref byte[] completedStatus);

        int StableVersionsDeepGC(
            [In, MarshalAs(UnmanagedType.BStr)]
            string Path,
            [In, MarshalAs(UnmanagedType.U4)]
            uint cookie,
            [In, Out, MarshalAs(UnmanagedType.Struct)]
            ref STABLEVERSION_DEEP_GC_STATS StableVersionDeepGCStats);

         int GetMIConfigurationStatus(
           [Out, MarshalAs(UnmanagedType.U4)]
            out uint serverType,
           [Out, MarshalAs(UnmanagedType.U4)]
            out uint serverAuthType);

        IConnectionPoint GetScrubbingEngineConnectionPoint();

        IConnectionPoint GetStableVersionDeepGcConnectionPoint();

    }
}
