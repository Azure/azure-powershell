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
using Microsoft.Azure.Commands.StorageSync.Interop.Enums;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

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

        public RecallOutput RecallFile([In, MarshalAs(UnmanagedType.BStr)] string path, [In, MarshalAs(UnmanagedType.U4)] uint retryCount, [In, MarshalAs(UnmanagedType.U4)] uint retryDelaySeconds)
        {
            return new RecallOutput() { };
        }

        public void IsPathUnderSyncShare([In, MarshalAs(UnmanagedType.BStr)] string path, [MarshalAs(UnmanagedType.BStr), Out] out string fileIdStr, [MarshalAs(UnmanagedType.Bool), Out] out bool isPathUnderShare, [MarshalAs(UnmanagedType.Bool), Out] out bool isPathShareRoot)
        {
            throw new NotImplementedException();
        }

        public void SetAutoUpdatePolicy([In, MarshalAs(UnmanagedType.Struct)] AutoUpdatePolicy autoUpdatePolicy)
        {
            throw new NotImplementedException();
        }

        public AutoUpdatePolicy GetAutoUpdatePolicy()
        {
            throw new NotImplementedException();
        }

        public bool GetFilePathUsingId([In, MarshalAs(UnmanagedType.BStr)] string volumeGuid, [In, MarshalAs(UnmanagedType.U8)] ulong fileId, [MarshalAs(UnmanagedType.BStr), Out] out string filePath)
        {
            throw new NotImplementedException();
        }

        public void LogOrphanedTieredFilesTelemetry([In, MarshalAs(UnmanagedType.Struct)] OrphanedTieredFilesTelemetryReport orphanedTieredFilesTelemetryReport)
        {
            throw new NotImplementedException();
        }

        public void PopulateFileInfoUsingHeatOrder([In, MarshalAs(UnmanagedType.BStr)] string path, [In, MarshalAs(UnmanagedType.BStr)] string recallCmdletLogPath, [MarshalAs(UnmanagedType.BStr), Out] out string recallMountPath, [MarshalAs(UnmanagedType.BStr), Out] out string volumeGuid)
        {
            throw new NotImplementedException();
        }

        public void LogRecallFilesTelemetry([In, MarshalAs(UnmanagedType.Struct)] RecallFilesTelemetryReport recallFilesTelemetryReport)
        {
            throw new NotImplementedException();
        }

        public HeatStoreSummary PopulateHeatStoreInformation([In, MarshalAs(UnmanagedType.BStr)] string volumePath, [In, MarshalAs(UnmanagedType.BStr)] string reportDirectoryPath, [In, MarshalAs(UnmanagedType.U4)] HeatStoreEnumeratorType enumeratorType, [In, MarshalAs(UnmanagedType.U8)] ulong maxRecordsLimit)
        {
            throw new NotImplementedException();
        }

        [return: MarshalAs(UnmanagedType.BStr)]
        public string GetFileLockIdUsingPath([In, MarshalAs(UnmanagedType.BStr)] string filePath)
        {
            throw new NotImplementedException();
        }

        public void SetLockBypassForSyncShare([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot, [In, MarshalAs(UnmanagedType.Bool)] bool bypassValue)
        {
            throw new NotImplementedException();
        }

        public HeatStoreFileInfo GetHeatStoreFileInformation([In, MarshalAs(UnmanagedType.BStr)] string filePath)
        {
            throw new NotImplementedException();
        }

        public SelfServiceRestore EnableSelfServiceRestore([In, MarshalAs(UnmanagedType.BStr)] string volume)
        {
            throw new NotImplementedException();
        }

        public SelfServiceRestore GetSelfServiceRestore([In, MarshalAs(UnmanagedType.BStr)] string volume)
        {
            throw new NotImplementedException();
        }

        public void DisableSelfServiceRestore([In, MarshalAs(UnmanagedType.BStr)] string volume)
        {
            throw new NotImplementedException();
        }

        public void RunNetworkConnectivityCheck([In, MarshalAs(UnmanagedType.Bool)] bool measureBandwidth, [MarshalAs(UnmanagedType.Bool), Out] out bool testPassed, [MarshalAs(UnmanagedType.BStr), Out] out string report)
        {
            throw new NotImplementedException();
        }

        public void TriggerOrphanedTieredFilesCleanup([In, MarshalAs(UnmanagedType.BStr)] string dataPath, [In, MarshalAs(UnmanagedType.BStr)] string context, [In, MarshalAs(UnmanagedType.BStr)] string clientCorrelationId)
        {
            throw new NotImplementedException();
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        public bool DoesOrphanedTieredFilesMarkerExist([In, MarshalAs(UnmanagedType.BStr)] string dataPath, [In, MarshalAs(UnmanagedType.BStr)] string context, [In, MarshalAs(UnmanagedType.BStr)] string clientCorrelationId)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrphanedTieredFilesMarker([In, MarshalAs(UnmanagedType.BStr)] string dataPath)
        {
            throw new NotImplementedException();
        }

        [return: MarshalAs(UnmanagedType.U4)]
        public uint GetReparseTag([In, MarshalAs(UnmanagedType.BStr)] string filePath)
        {
            throw new NotImplementedException();
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        public bool IsPathUnderSVIOrRecycleBin([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            throw new NotImplementedException();
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public IFileAccessPatternStatsEnumerator GetFileAccessPattern([In, MarshalAs(UnmanagedType.BStr)] string serverEndpointPath)
        {
            throw new NotImplementedException();
        }

        public TieringPolicyRecommendations GetTieringPolicyRecommendations([In, MarshalAs(UnmanagedType.BStr)] string serverEndpointPath, [In, MarshalAs(UnmanagedType.U4)] PolicyAdvisorMode policyAdvisorMode)
        {
            throw new NotImplementedException();
        }

        public LockingStateInfo GetLockingStateInformationUsingFilePath([In, MarshalAs(UnmanagedType.BStr)] string filePath)
        {
            throw new NotImplementedException();
        }

        public LockingStateInfo GetLockingStateInformationUsingLockId([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot, [In, MarshalAs(UnmanagedType.BStr)] string lockId)
        {
            throw new NotImplementedException();
        }

        public int InitializeCmdletGhosting([In, MarshalAs(UnmanagedType.BStr)] string path, [MarshalAs(UnmanagedType.BStr), Out] out string tieringCmdletLogPath, [MarshalAs(UnmanagedType.U4), Out] out uint totalFiles, [MarshalAs(UnmanagedType.BStr), Out] out string ghostingSessionGuid)
        {
            throw new NotImplementedException();
        }

        public int GhostBatch([In, MarshalAs(UnmanagedType.BStr)] string tieringCmdletLogPath, [In, MarshalAs(UnmanagedType.BStr)] string ghostingSessionGuid, [MarshalAs(UnmanagedType.U4), Out] out uint fileCount, [In, MarshalAs(UnmanagedType.Struct), Out] ref GHOSTING_STATS ghostingStats, [In, MarshalAs(UnmanagedType.U4)] uint minimumFileAgeDays)
        {
            throw new NotImplementedException();
        }

        public int FinalizeCmdletGhosting([In, MarshalAs(UnmanagedType.BStr)] string tieringCmdletLogPath, [In, MarshalAs(UnmanagedType.BStr)] string ghostingSessionGuid)
        {
            throw new NotImplementedException();
        }

        public int AddAllowedServerEndpointPath([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            throw new NotImplementedException();
        }

        public int GetAllowedServerEndpointPaths([In, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR), Out] ref string[] paths)
        {
            throw new NotImplementedException();
        }

        public int RemoveAllowedServerEndpointPath([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            throw new NotImplementedException();
        }

        public int SetIsAuthoritativeSyncEnabled([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot, [In, MarshalAs(UnmanagedType.Bool)] bool isAuthoritativeSyncEnabled)
        {
            throw new NotImplementedException();
        }

        public int GetIsAuthoritativeSyncEnabled([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot, [MarshalAs(UnmanagedType.Bool), Out] out bool isAuthoritativeSyncEnabled)
        {
            throw new NotImplementedException();
        }

        public int GetReplicaFlags([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot, [MarshalAs(UnmanagedType.U4), Out] out SyncFlags replicaFlags)
        {
            throw new NotImplementedException();
        }

        public int SetIsSyncDisabled([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot, [In, MarshalAs(UnmanagedType.Bool)] bool isSyncDisabled)
        {
            throw new NotImplementedException();
        }

        public void PopulateFileInfoUsingRPIterator([In, MarshalAs(UnmanagedType.BStr)] string syncGroupName, [In, MarshalAs(UnmanagedType.BStr)] string recallCmdletLogPath, [MarshalAs(UnmanagedType.BStr), Out] out string volumeGuid)
        {
            throw new NotImplementedException();
        }

        public int SetMaxFileSizeLimit([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot, [In, MarshalAs(UnmanagedType.U8)] ulong maxFileSize)
        {
            throw new NotImplementedException();
        }

        public int GetMaxFileSizeLimit([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot, [MarshalAs(UnmanagedType.U8), Out] out ulong maxFileSize)
        {
            throw new NotImplementedException();
        }

        public int GetIsSyncDisabled([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot, [MarshalAs(UnmanagedType.Bool), Out] out bool isSyncDisabled)
        {
            throw new NotImplementedException();
        }

        public int SetServiceRootCertificateThumbprint([In, MarshalAs(UnmanagedType.BStr)] string serviceRootCertificateThumbprint)
        {
            throw new NotImplementedException();
        }

        public int GetServiceRootCertificateThumbprint([MarshalAs(UnmanagedType.BStr), Out] out string serviceRootCertificateThumbprint)
        {
            throw new NotImplementedException();
        }

        public int NewSyncSession([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot, [In, MarshalAs(UnmanagedType.U4)] SyncDirection syncDirection, [In, MarshalAs(UnmanagedType.U4)] SyncScenario syncScenario, [MarshalAs(UnmanagedType.Bool), Out] bool cancelExisting, [In, MarshalAs(UnmanagedType.Struct), Out] ref NEW_SYNC_SESSION_SCHEDULE_RESULT newSyncSessionScheduleResult)
        {
            throw new NotImplementedException();
        }

        public int GetSyncSessionStatuses([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot, [In, MarshalAs(UnmanagedType.BStr)] string sessionId, [In, MarshalAs(UnmanagedType.U4)] uint limit, [In, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1), Out] ref byte[] inProgressSyncSessionStatusList, [In, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1), Out] ref byte[] completedSyncSessionStatusList)
        {
            throw new NotImplementedException();
        }

        public int GetErrorTextDescription([In, MarshalAs(UnmanagedType.I8)] long hr, [MarshalAs(UnmanagedType.BStr), Out] out string errorText)
        {
            throw new NotImplementedException();
        }

        public VOLUME_STATUS GetVolumeStatus([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot)
        {
            throw new NotImplementedException();
        }

        public TIERING_STATUS GetTieringStatusEndpoint([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot)
        {
            throw new NotImplementedException();
        }

        public void DiagnoseServerIssues([MarshalAs(UnmanagedType.BStr), Out] out string diagnosisOutputsJson)
        {
            throw new NotImplementedException();
        }

        public int TriggerServerChangeDetection([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot, [In, MarshalAs(UnmanagedType.Bool)] bool deepScan) => 0;

        public int GetServerChangeDetectionStatuses([In, MarshalAs(UnmanagedType.BStr)] string syncShareRoot, [In, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1), Out] ref byte[] inProgressStatus, [In, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1), Out] ref byte[] completedStatus) => 0;

        public int StableVersionsDeepGC([In, MarshalAs(UnmanagedType.BStr)] string Path, [In, MarshalAs(UnmanagedType.U4)] uint cookie, [In, MarshalAs(UnmanagedType.Struct), Out] ref STABLEVERSION_DEEP_GC_STATS StableVersionDeepGCStats) => 0;
        public int GetMIConfigurationStatus([MarshalAs(UnmanagedType.U4), Out] out uint serverType, [MarshalAs(UnmanagedType.U4), Out] out uint serverAuthType)
        {
            serverType = (int)LocalServerType.AzureVirtualMachineServer;
            serverAuthType = (int)RegisteredServerAuthType.Certificate;
            return 0;
        }

        public IConnectionPoint GetScrubbingEngineConnectionPoint() => null;

        public IConnectionPoint GetStableVersionDeepGcConnectionPoint() => null;
    }
}
