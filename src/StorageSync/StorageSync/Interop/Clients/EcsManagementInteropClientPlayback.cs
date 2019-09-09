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
using Commands.StorageSync.Interop.Interfaces;
using System;
using System.Runtime.InteropServices;


namespace Commands.StorageSync.Interop.Clients
{
    /// <summary>
    /// Class EcsManagementInteropClientPlayback.
    /// Implements the <see cref="Commands.StorageSync.Interop.Interfaces.IEcsManagement" />
    /// </summary>
    /// <seealso cref="Commands.StorageSync.Interop.Interfaces.IEcsManagement" />
    public class EcsManagementInteropClientPlayback : IEcsManagement
    {
        /// <summary>
        /// Gets a value indicating whether this instance has valid handle.
        /// </summary>
        /// <value><c>true</c> if this instance has valid handle; otherwise, <c>false</c>.</value>
        protected virtual bool HasValidHandle => true;

        /// <summary>
        /// Initializes a new instance of the <see cref="EcsManagementInteropClientPlayback" /> class.
        /// </summary>
        public EcsManagementInteropClientPlayback()
        {
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns>IEcsManagement.</returns>
        protected virtual IEcsManagement Initialize()
        {
            return this;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
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
            return 0;
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
            return 0;
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
            return 0;
        }

        /// <summary>
        /// Resets the sync server configuration.
        /// </summary>
        /// <param name="cleanClusterRegistration">if set to <c>true</c> [clean cluster registration].</param>
        /// <returns>System.Int32.</returns>
        public int ResetSyncServerConfiguration([In, MarshalAs(UnmanagedType.Bool)] bool cleanClusterRegistration)
        {
            return 0;
        }

        /// <summary>
        /// Ghosts the path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="ghostingStats">The ghosting stats.</param>
        /// <returns>System.Int32.</returns>
        public int GhostPath([In, MarshalAs(UnmanagedType.BStr)] string path, [In, MarshalAs(UnmanagedType.Struct), Out] ref GHOSTING_STATS ghostingStats)
        {
            ghostingStats.AlreadyTieredCount = 0;
            ghostingStats.TieredCount = 0;
            return 0;
        }

        /// <summary>
        /// Sets the proxy setting.
        /// </summary>
        /// <param name="proxySetting">The proxy setting.</param>
        public void SetProxySetting([In, MarshalAs(UnmanagedType.Struct)] ProxySetting proxySetting)
        {
        }

        /// <summary>
        /// Gets the proxy setting.
        /// </summary>
        /// <returns>ProxySetting.</returns>
        public ProxySetting GetProxySetting()
        {
            return new ProxySetting() { };
        }

        /// <summary>
        /// Removes the proxy setting.
        /// </summary>
        public void RemoveProxySetting()
        {
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
            scrubbingStats.ErrorFilesCreated = 0;
            return 0;
        }

        /// <summary>
        /// Gets the storage sync server endpoint status.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="serverEndpointReports">The server endpoint reports.</param>
        /// <returns>System.Int32.</returns>
        public int GetStorageSyncServerEndpointStatus([In, MarshalAs(UnmanagedType.BStr)] string path, [In, Out, MarshalAs(UnmanagedType.BStr)] ref string serverEndpointReports)
        {
            serverEndpointReports = "";
            return 0;
        }

        /// <summary>
        /// Gets the storage sync registered server status.
        /// </summary>
        /// <param name="registeredServerStats">The registered server stats.</param>
        /// <returns>System.Int32.</returns>
        public int GetStorageSyncRegisteredServerStatus([In, MarshalAs(UnmanagedType.BStr), Out] ref string registeredServerStats)
        {
            registeredServerStats = "";
            return 0;
        }

        /// <summary>
        /// Determines whether [is tiered file orphaned] [the specified path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if [is tiered file orphaned] [the specified path]; otherwise, <c>false</c>.</returns>
        public bool IsTieredFileOrphaned([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            return false;
        }

        /// <summary>
        /// Deletes the orphaned tiered file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool DeleteOrphanedTieredFile([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            return true;
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
            garbageCollectionStats.StableVersionsAlreadyDeleted = 0;
            return 0;
        }

        /// <summary>
        /// Recalls the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>RecallOutput.</returns>
        public RecallOutput RecallFile([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            return new RecallOutput() { };
        }

        /// <summary>
        /// Determines whether [is path under sync share] [the specified path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if [is path under sync share] [the specified path]; otherwise, <c>false</c>.</returns>
        public bool IsPathUnderSyncShare([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            return true;
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
            return 0;
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
            [In, MarshalAs(UnmanagedType.BStr)]    string certificateProviderName,
            [In, MarshalAs(UnmanagedType.BStr)]    string certificateHashAlgorithm,
            [In, MarshalAs(UnmanagedType.U4)]      uint certificateKeyLength,
            [Out, MarshalAs(UnmanagedType.BStr)]   out string serverCertificateThumbprint)
        {
            serverCertificateThumbprint = "MIIDEDCCAfigAwIBAgIQRW74/KVvT5FL7qO4rVn7HzANBgkqhkiG9w0BAQ0FADAwMS4wLAYDVQQDEyVhbmt1c2hiLXZtMDIubnRkZXYuY29ycC5taWNyb3NvZnQuY29tMB4XDTE4MTAyMTE5MTQxNVoXDTE5MTAyMjE5MTQxNVowMDEuMCwGA1UEAxMlYW5rdXNoYi12bTAyLm50ZGV2LmNvcnAubWljcm9zb2Z0LmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKsuJgPpe6VXGKG+/bz4pmEwd2/IUP6bOAyQNHoJ4DuFF0BGEmIhMAi6lhhYpjwtPMylEtRpSvimqm4fp41x0uEf4EIGVDKQwM5l5w+3WJ1gEM8Pb2c9ujHr2g9WX20+7xVTHZ+Oujn4vAachiy5fApT2F9+COZTCUn0bUW7kxjrDAHeaaqSz4nhbgq91ZuLPhaO4xcfADiNdgYTu4Y5w6tcsjITx9yujmhMey22FSpQ39u5L67H3/86ythb+8bqjRHuq6rtFvzssnMz8mTRa11KAEZiGugpz5uImXB75vIzH6M0yNg+D4aVhfxFGKuDnBJrT8y/KvRBpflQ/fgam8ECAwEAAaMmMCQwIgYDVR0lAQH/BBgwFgYIKwYBBQUHAwIGCisGAQQBgjcKAwwwDQYJKoZIhvcNAQENBQADggEBAJ2nnFx6L7x8nksInMMxQsNyKFAHvJ3PMFeNnM0XuVWPXDK/MdyDZhSh2ySbI7la8bdeALsoH9o97hWwLeN8VTox+yXey3PqyR1vo+cql9WQmEOt+fpKcvVdCYLflqLDG+v3ZPgyfiKEK2/xMhJrW0pJX5LjMAX/ttK5C+SKo48h5Jbm4ilJk7l7zlT1LSMVQMWglTdMIAXhtNLjqRGR/6ENeCxubkVEys84inhJ3sONZpuIyrwR6FkD+WloP4lgwyA07/n1YJ6+AoR/T6koeBMPsQEG8Vj4V5kbT1SNY1Wnd9TQZr7/N33Do4CV7kJUXp+i2VquPRzlnMBH9ya5Fqg=";
            return 0;
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
            primaryCertificateThumbprint = "MIIDEDCCAfigAwIBAgIQRW74/KVvT5FL7qO4rVn7HzANBgkqhkiG9w0BAQ0FADAwMS4wLAYDVQQDEyVhbmt1c2hiLXZtMDIubnRkZXYuY29ycC5taWNyb3NvZnQuY29tMB4XDTE4MTAyMTE5MTQxNVoXDTE5MTAyMjE5MTQxNVowMDEuMCwGA1UEAxMlYW5rdXNoYi12bTAyLm50ZGV2LmNvcnAubWljcm9zb2Z0LmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKsuJgPpe6VXGKG+/bz4pmEwd2/IUP6bOAyQNHoJ4DuFF0BGEmIhMAi6lhhYpjwtPMylEtRpSvimqm4fp41x0uEf4EIGVDKQwM5l5w+3WJ1gEM8Pb2c9ujHr2g9WX20+7xVTHZ+Oujn4vAachiy5fApT2F9+COZTCUn0bUW7kxjrDAHeaaqSz4nhbgq91ZuLPhaO4xcfADiNdgYTu4Y5w6tcsjITx9yujmhMey22FSpQ39u5L67H3/86ythb+8bqjRHuq6rtFvzssnMz8mTRa11KAEZiGugpz5uImXB75vIzH6M0yNg+D4aVhfxFGKuDnBJrT8y/KvRBpflQ/fgam8ECAwEAAaMmMCQwIgYDVR0lAQH/BBgwFgYIKwYBBQUHAwIGCisGAQQBgjcKAwwwDQYJKoZIhvcNAQENBQADggEBAJ2nnFx6L7x8nksInMMxQsNyKFAHvJ3PMFeNnM0XuVWPXDK/MdyDZhSh2ySbI7la8bdeALsoH9o97hWwLeN8VTox+yXey3PqyR1vo+cql9WQmEOt+fpKcvVdCYLflqLDG+v3ZPgyfiKEK2/xMhJrW0pJX5LjMAX/ttK5C+SKo48h5Jbm4ilJk7l7zlT1LSMVQMWglTdMIAXhtNLjqRGR/6ENeCxubkVEys84inhJ3sONZpuIyrwR6FkD+WloP4lgwyA07/n1YJ6+AoR/T6koeBMPsQEG8Vj4V5kbT1SNY1Wnd9TQZr7/N33Do4CV7kJUXp+i2VquPRzlnMBH9ya5Fqg=";
            secondaryCertificateThumbprint = "MIIDEDCCAfigAwIBAgIQRW74/KVvT5FL7qO4rVn7HzANBgkqhkiG9w0BAQ0FADAwMS4wLAYDVQQDEyVhbmt1c2hiLXZtMDIubnRkZXYuY29ycC5taWNyb3NvZnQuY29tMB4XDTE4MTAyMTE5MTQxNVoXDTE5MTAyMjE5MTQxNVowMDEuMCwGA1UEAxMlYW5rdXNoYi12bTAyLm50ZGV2LmNvcnAubWljcm9zb2Z0LmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKsuJgPpe6VXGKG+/bz4pmEwd2/IUP6bOAyQNHoJ4DuFF0BGEmIhMAi6lhhYpjwtPMylEtRpSvimqm4fp41x0uEf4EIGVDKQwM5l5w+3WJ1gEM8Pb2c9ujHr2g9WX20+7xVTHZ+Oujn4vAachiy5fApT2F9+COZTCUn0bUW7kxjrDAHeaaqSz4nhbgq91ZuLPhaO4xcfADiNdgYTu4Y5w6tcsjITx9yujmhMey22FSpQ39u5L67H3/86ythb+8bqjRHuq6rtFvzssnMz8mTRa11KAEZiGugpz5uImXB75vIzH6M0yNg+D4aVhfxFGKuDnBJrT8y/KvRBpflQ/fgam8ECAwEAAaMmMCQwIgYDVR0lAQH/BBgwFgYIKwYBBQUHAwIGCisGAQQBgjcKAwwwDQYJKoZIhvcNAQENBQADggEBAJ2nnFx6L7x8nksInMMxQsNyKFAHvJ3PMFeNnM0XuVWPXDK/MdyDZhSh2ySbI7la8bdeALsoH9o97hWwLeN8VTox+yXey3PqyR1vo+cql9WQmEOt+fpKcvVdCYLflqLDG+v3ZPgyfiKEK2/xMhJrW0pJX5LjMAX/ttK5C+SKo48h5Jbm4ilJk7l7zlT1LSMVQMWhlTdMIAXhtNLjqRGR/6ENeCxubkVEys84inhJ3sONZpuIyrwR6FkD+WloP4lgwyA07/n1YJ6+AoR/T6koeBMPsQEG8Vj4V5kbT1SNY1Wnd9TQZr7/N33Do4CV7kJUXp+i2VquPRzlnMBH9ya5Fqg=";
            return 0;
        }

        /// <summary>
        /// Deletes the server certificate.
        /// </summary>
        /// <param name="certificateThumbprint">The certificate thumbprint.</param>
        /// <returns>System.Int32.</returns>
        public int DeleteServerCertificate(
            [In, MarshalAs(UnmanagedType.BStr)] string certificateThumbprint)
        {
            return 0;
        }

        /// <summary>
        /// Switches to secondary certificate and update monitoring.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int SwitchToSecondaryCertificateAndUpdateMonitoring()
        {
            return 0;
        }

        /// <summary>
        /// Gets the sync server certificate.
        /// </summary>
        /// <param name="isPrimary">if set to <c>true</c> [is primary].</param>
        /// <param name="serverCertificate">The server certificate.</param>
        /// <returns>System.Int32.</returns>
        public int GetSyncServerCertificate([In, MarshalAs(UnmanagedType.Bool)] bool isPrimary, [MarshalAs(UnmanagedType.BStr), Out] out string serverCertificate)
        {
            serverCertificate = "MIIDEDCCAfigAwIBAgIQRW74/KVvT5FL7qO4rVn7HzANBgkqhkiG9w0BAQ0FADAwMS4wLAYDVQQDEyVhbmt1c2hiLXZtMDIubnRkZXYuY29ycC5taWNyb3NvZnQuY29tMB4XDTE4MTAyMTE5MTQxNVoXDTE5MTAyMjE5MTQxNVowMDEuMCwGA1UEAxMlYW5rdXNoYi12bTAyLm50ZGV2LmNvcnAubWljcm9zb2Z0LmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKsuJgPpe6VXGKG+/bz4pmEwd2/IUP6bOAyQNHoJ4DuFF0BGEmIhMAi6lhhYpjwtPMylEtRpSvimqm4fp41x0uEf4EIGVDKQwM5l5w+3WJ1gEM8Pb2c9ujHr2g9WX20+7xVTHZ+Oujn4vAachiy5fApT2F9+COZTCUn0bUW7kxjrDAHeaaqSz4nhbgq91ZuLPhaO4xcfADiNdgYTu4Y5w6tcsjITx9yujmhMey22FSpQ39u5L67H3/86ythb+8bqjRHuq6rtFvzssnMz8mTRa11KAEZiGugpz5uImXB75vIzH6M0yNg+D4aVhfxFGKuDnBJrT8y/KvRBpflQ/fgam8ECAwEAAaMmMCQwIgYDVR0lAQH/BBgwFgYIKwYBBQUHAwIGCisGAQQBgjcKAwwwDQYJKoZIhvcNAQENBQADggEBAJ2nnFx6L7x8nksInMMxQsNyKFAHvJ3PMFeNnM0XuVWPXDK/MdyDZhSh2ySbI7la8bdeALsoH9o97hWwLeN8VTox+yXey3PqyR1vo+cql9WQmEOt+fpKcvVdCYLflqLDG+v3ZPgyfiKEK2/xMhJrW0pJX5LjMAX/ttK5C+SKo48h5Jbm4ilJk7l7zlT1LSMVQMWglTdMIAXhtNLjqRGR/6ENeCxubkVEys84inhJ3sONZpuIyrwR6FkD+WloP4lgwyA07/n1YJ6+AoR/T6koeBMPsQEG8Vj4V5kbT1SNY1Wnd9TQZr7/N33Do4CV7kJUXp+i2VquPRzlnMBH9ya5Fqg=";
            return 0;
        }

        /// <summary>
        /// Gets the sync server identifier.
        /// </summary>
        /// <param name="serverId">The server identifier.</param>
        /// <returns>System.Int32.</returns>
        public int GetSyncServerId([MarshalAs(UnmanagedType.BStr), Out] out string serverId)
        {
            if (!Guid.TryParse(Environment.GetEnvironmentVariable("REGISTEREDSERVER_SERVER_ID"), out Guid serverGuid))
            {
                serverGuid = Guid.NewGuid();
            }

            serverId = serverGuid.ToString();
            return 0;
        }

        /// <summary>
        /// Registers the monitoring agent.
        /// </summary>
        /// <param name="serverRegistrationData">The server registration data.</param>
        /// <param name="monitoringDataPath">The monitoring data path.</param>
        /// <returns>System.Int32.</returns>
        public int RegisterMonitoringAgent([MarshalAs(UnmanagedType.BStr)] string serverRegistrationData, [MarshalAs(UnmanagedType.BStr)] string monitoringDataPath)
        {
            return 0;
        }

        /// <summary>
        /// Creates new networklimit.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="NotImplementedException"></exception>
        [return: MarshalAs(UnmanagedType.BStr)]
        public string NewNetworkLimit([In, MarshalAs(UnmanagedType.Interface)] INetworkLimitConfigEntry config)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the network limits.
        /// </summary>
        /// <returns>INetworkLimitConfigurationEntryEnumeration.</returns>
        /// <exception cref="NotImplementedException"></exception>
        [return: MarshalAs(UnmanagedType.Interface)]
        public INetworkLimitConfigurationEntryEnumeration GetNetworkLimits()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the network limit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>INetworkLimitConfigEntry.</returns>
        /// <exception cref="NotImplementedException"></exception>
        [return: MarshalAs(UnmanagedType.Interface)]
        public INetworkLimitConfigEntry GetNetworkLimit([In, MarshalAs(UnmanagedType.BStr)] string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the network limit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void RemoveNetworkLimit([In, MarshalAs(UnmanagedType.BStr)] string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the cluster information.
        /// </summary>
        /// <param name="clusterId">The cluster identifier.</param>
        /// <param name="clusterName">Name of the cluster.</param>
        /// <returns>System.Int32.</returns>
        public int GetClusterInfo([MarshalAs(UnmanagedType.BStr), Out] out string clusterId, [MarshalAs(UnmanagedType.BStr), Out] out string clusterName)
        {
            clusterId = null;
            clusterName = null;
            return 0;
        }

        /// <summary>
        /// Determines whether [is in cluster].
        /// </summary>
        /// <returns><c>true</c> if [is in cluster]; otherwise, <c>false</c>.</returns>
        public bool IsInCluster()
        {
            return false;
        }
    }
}
