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
    using System;
    using System.Runtime.InteropServices;

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
        /// <returns>RecallOutput.</returns>
        RecallOutput RecallFile(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path);

        /// <summary>
        /// Determines whether [is path under sync share] [the specified path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if [is path under sync share] [the specified path]; otherwise, <c>false</c>.</returns>
        bool IsPathUnderSyncShare(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path);

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
    }
}
