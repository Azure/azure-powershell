// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEcsManagement.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   COM related 
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Commands.StorageSync.Interop.Interfaces
{
    using DataObjects;
    using Enums;
    using System;
    using System.Runtime.InteropServices;

    [Guid("F29EAB44-2C63-4ACE-8C05-67C2203CBED2"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEcsManagement : IDisposable
    {
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

        int ResetSyncServerConfiguration(
            [In, MarshalAs(UnmanagedType.Bool)]
            bool cleanClusterRegistration);

        int GhostPath(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path,
            [In, Out, MarshalAs(UnmanagedType.Struct)]
            ref GHOSTING_STATS ghostingStats);

        void SetProxySetting(
            [In, MarshalAs(UnmanagedType.Struct)]
            ProxySetting proxySetting);

        ProxySetting GetProxySetting();

        void RemoveProxySetting();

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

        RecallOutput RecallFile(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path);

        bool IsPathUnderSyncShare(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path);

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

        int GetSyncServerCertificate(
            [In, MarshalAs(UnmanagedType.Bool)]
            bool isPrimary,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string serverCertificate);

        int GetSyncServerId(
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string serverId);

        int RegisterMonitoringAgent(
            [MarshalAs(UnmanagedType.BStr)]
            string serverRegistrationData,
            [MarshalAs(UnmanagedType.BStr)]
            string monitoringDataPath);

        [return: MarshalAs(UnmanagedType.BStr)]
        string NewNetworkLimit(
            [In, MarshalAs(UnmanagedType.Interface)]
            INetworkLimitConfigEntry config);

        [return: MarshalAs(UnmanagedType.Interface)]
        INetworkLimitConfigurationEntryEnumeration GetNetworkLimits();

        [return: MarshalAs(UnmanagedType.Interface)]
        INetworkLimitConfigEntry GetNetworkLimit(
            [In, MarshalAs(UnmanagedType.BStr)]
            string id);

        void RemoveNetworkLimit(
            [In, MarshalAs(UnmanagedType.BStr)]
            string id);

        int GetClusterInfo(
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string clusterId,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string clusterName);

        bool IsInCluster();

        int ValidateSyncServer(
            [In, MarshalAs(UnmanagedType.BStr)]
            string serviceUri,
            [In, MarshalAs(UnmanagedType.BStr)]
            string subscriptionId,
            [In, MarshalAs(UnmanagedType.BStr)]
            string storageSyncServiceName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string resourceGroupName);

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
        
        int GarbageCollectStableVersions(
            [In, MarshalAs(UnmanagedType.BStr)]
            string Path,
            [In, MarshalAs(UnmanagedType.U4)]
            GarbageCollectionMode Mode,
            [In, Out, MarshalAs(UnmanagedType.Struct)]
            ref GARBAGECOLLECTION_STATS GarbageCollectionStats);

        int GetStorageSyncServerEndpointStatus(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path,
            [In, Out, MarshalAs(UnmanagedType.BStr)]
            ref string serverEndpointReports);

        int GetStorageSyncRegisteredServerStatus(
            [In, MarshalAs(UnmanagedType.BStr), Out]
            ref string registeredServerStats);

        int RolloverSecondaryCertificate(
            [In, MarshalAs(UnmanagedType.BStr)]
            string certificateProviderName,
            [In, MarshalAs(UnmanagedType.BStr)]
            string certificateHashAlgorithm,
            [In, MarshalAs(UnmanagedType.U4)]
            uint certificateKeyLength,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string serverCertificateThumbprint);

        int GetServerCertificateThumbprints(
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string primaryCertificateThumbprint,
            [Out, MarshalAs(UnmanagedType.BStr)]
            out string secondaryCertificateThumbprint);

        int DeleteServerCertificate(
            [In, MarshalAs(UnmanagedType.BStr)]
            string certificateThumbprint);

        int SwitchToSecondaryCertificateAndUpdateMonitoring();

        bool IsTieredFileOrphaned(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path);

        bool DeleteOrphanedTieredFile(
            [In, MarshalAs(UnmanagedType.BStr)]
            string path);
    }
}
