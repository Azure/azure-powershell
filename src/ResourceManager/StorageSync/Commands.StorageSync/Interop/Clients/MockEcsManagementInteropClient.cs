using Commands.StorageSync.Interop.DataObjects;
using Commands.StorageSync.Interop.Enums;
using Commands.StorageSync.Interop.Exceptions;
using Commands.StorageSync.Interop.Interfaces;
using System;
using System.Management.Automation;
using System.Runtime.InteropServices;


namespace Commands.StorageSync.Interop.Clients
{
    public class MockEcsManagementInteropClient : IEcsManagement
    {
         protected virtual bool HasValidHandle => true;

        public MockEcsManagementInteropClient()
        {
        }

        protected virtual IEcsManagement Initialize()
        {
            return this;
        }

        public void Dispose()
        {
        }
        public int ValidateSyncServer([In, MarshalAs(UnmanagedType.BStr)] string serviceUri, [In, MarshalAs(UnmanagedType.BStr)] string subscriptionId, [In, MarshalAs(UnmanagedType.BStr)] string storageSyncServiceName, [In, MarshalAs(UnmanagedType.BStr)] string resourceGroupName)
        {
            return 0;
        }

        public int EnsureSyncServerCertificate([In, MarshalAs(UnmanagedType.BStr)] string serviceUri, [In, MarshalAs(UnmanagedType.BStr)] string subscriptionId, [In, MarshalAs(UnmanagedType.BStr)] string storageSyncServiceName, [In, MarshalAs(UnmanagedType.BStr)] string resourceGroupName, [In, MarshalAs(UnmanagedType.BStr)] string certificateProviderName, [In, MarshalAs(UnmanagedType.BStr)] string certificateHashAlgorithm, [In, MarshalAs(UnmanagedType.U4)] uint certificateKeyLength)
        {
            return 0;
        }

        public int RegisterSyncServer([In, MarshalAs(UnmanagedType.BStr)] string serviceUri, [In, MarshalAs(UnmanagedType.BStr)] string subscriptionId, [In, MarshalAs(UnmanagedType.BStr)] string storageSyncServiceName, [In, MarshalAs(UnmanagedType.BStr)] string resourceGroupName, [In, MarshalAs(UnmanagedType.BStr)] string certificateProviderName, [In, MarshalAs(UnmanagedType.BStr)] string certificateHashAlgorithm, [In, MarshalAs(UnmanagedType.U4)] uint certificateKeyLength, [In, MarshalAs(UnmanagedType.BStr)] string monitoringDataPath)
        {
            return 0;
        }

        public int ResetSyncServerConfiguration([In, MarshalAs(UnmanagedType.Bool)] bool cleanClusterRegistration)
        {
            return 0;
        }

        public int GhostPath([In, MarshalAs(UnmanagedType.BStr)] string path, [In, MarshalAs(UnmanagedType.Struct), Out] ref GHOSTING_STATS ghostingStats)
        {
            ghostingStats.AlreadyTieredCount = 0;
            ghostingStats.TieredCount = 0;
            return 0;
        }

        public void SetProxySetting([In, MarshalAs(UnmanagedType.Struct)] ProxySetting proxySetting)
        {
        }

        public ProxySetting GetProxySetting()
        {
            return new ProxySetting() { };
        }

        public void RemoveProxySetting()
        {
        }

        public int ScrubFiles([In, MarshalAs(UnmanagedType.BStr)] string path, [In, MarshalAs(UnmanagedType.U4)] ScrubbingMode mode, [In, MarshalAs(UnmanagedType.Bool)] bool isDeepScan, [In, MarshalAs(UnmanagedType.BStr)] string reportPath, [In, MarshalAs(UnmanagedType.Struct), Out] ref SCRUBBING_STATS scrubbingStats)
        {
            scrubbingStats.ErrorFilesCreated = 0;
            return 0;
        }

        public int GetStorageSyncServerEndpointStatus([In, MarshalAs(UnmanagedType.BStr)] string path, [In, Out, MarshalAs(UnmanagedType.BStr)] ref string serverEndpointReports)
        {
            serverEndpointReports = "";
            return 0;
        }

        public int GetStorageSyncRegisteredServerStatus([In, MarshalAs(UnmanagedType.BStr), Out] ref string registeredServerStats)
        {
            registeredServerStats = "";
            return 0;
        }

        public bool IsTieredFileOrphaned([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            return false;
        }

        public bool DeleteOrphanedTieredFile([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            return true;
        }

        public int GarbageCollectStableVersions([In, MarshalAs(UnmanagedType.BStr)] string path, [In, MarshalAs(UnmanagedType.U4)] GarbageCollectionMode mode, [In, MarshalAs(UnmanagedType.Struct), Out] ref GARBAGECOLLECTION_STATS garbageCollectionStats)
        {
            garbageCollectionStats.StableVersionsAlreadyDeleted = 0;
            return 0;
        }

        public RecallOutput RecallFile([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            return new RecallOutput() { };
        }

        public bool IsPathUnderSyncShare([In, MarshalAs(UnmanagedType.BStr)] string path)
        {
            return true;
        }

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

        public int RolloverSecondaryCertificate(
            [In, MarshalAs(UnmanagedType.BStr)]    string certificateProviderName,
            [In, MarshalAs(UnmanagedType.BStr)]    string certificateHashAlgorithm,
            [In, MarshalAs(UnmanagedType.U4)]      uint certificateKeyLength,
            [Out, MarshalAs(UnmanagedType.BStr)]   out string serverCertificateThumbprint)
        {
            serverCertificateThumbprint = "MIIDEDCCAfigAwIBAgIQRW74/KVvT5FL7qO4rVn7HzANBgkqhkiG9w0BAQ0FADAwMS4wLAYDVQQDEyVhbmt1c2hiLXZtMDIubnRkZXYuY29ycC5taWNyb3NvZnQuY29tMB4XDTE4MTAyMTE5MTQxNVoXDTE5MTAyMjE5MTQxNVowMDEuMCwGA1UEAxMlYW5rdXNoYi12bTAyLm50ZGV2LmNvcnAubWljcm9zb2Z0LmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKsuJgPpe6VXGKG+/bz4pmEwd2/IUP6bOAyQNHoJ4DuFF0BGEmIhMAi6lhhYpjwtPMylEtRpSvimqm4fp41x0uEf4EIGVDKQwM5l5w+3WJ1gEM8Pb2c9ujHr2g9WX20+7xVTHZ+Oujn4vAachiy5fApT2F9+COZTCUn0bUW7kxjrDAHeaaqSz4nhbgq91ZuLPhaO4xcfADiNdgYTu4Y5w6tcsjITx9yujmhMey22FSpQ39u5L67H3/86ythb+8bqjRHuq6rtFvzssnMz8mTRa11KAEZiGugpz5uImXB75vIzH6M0yNg+D4aVhfxFGKuDnBJrT8y/KvRBpflQ/fgam8ECAwEAAaMmMCQwIgYDVR0lAQH/BBgwFgYIKwYBBQUHAwIGCisGAQQBgjcKAwwwDQYJKoZIhvcNAQENBQADggEBAJ2nnFx6L7x8nksInMMxQsNyKFAHvJ3PMFeNnM0XuVWPXDK/MdyDZhSh2ySbI7la8bdeALsoH9o97hWwLeN8VTox+yXey3PqyR1vo+cql9WQmEOt+fpKcvVdCYLflqLDG+v3ZPgyfiKEK2/xMhJrW0pJX5LjMAX/ttK5C+SKo48h5Jbm4ilJk7l7zlT1LSMVQMWglTdMIAXhtNLjqRGR/6ENeCxubkVEys84inhJ3sONZpuIyrwR6FkD+WloP4lgwyA07/n1YJ6+AoR/T6koeBMPsQEG8Vj4V5kbT1SNY1Wnd9TQZr7/N33Do4CV7kJUXp+i2VquPRzlnMBH9ya5Fqg=";
            return 0;
        }

        public int GetServerCertificateThumbprints(
            [Out, MarshalAs(UnmanagedType.BStr)] out string primaryCertificateThumbprint,
            [Out, MarshalAs(UnmanagedType.BStr)] out string secondaryCertificateThumbprint)
        {
            primaryCertificateThumbprint = "MIIDEDCCAfigAwIBAgIQRW74/KVvT5FL7qO4rVn7HzANBgkqhkiG9w0BAQ0FADAwMS4wLAYDVQQDEyVhbmt1c2hiLXZtMDIubnRkZXYuY29ycC5taWNyb3NvZnQuY29tMB4XDTE4MTAyMTE5MTQxNVoXDTE5MTAyMjE5MTQxNVowMDEuMCwGA1UEAxMlYW5rdXNoYi12bTAyLm50ZGV2LmNvcnAubWljcm9zb2Z0LmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKsuJgPpe6VXGKG+/bz4pmEwd2/IUP6bOAyQNHoJ4DuFF0BGEmIhMAi6lhhYpjwtPMylEtRpSvimqm4fp41x0uEf4EIGVDKQwM5l5w+3WJ1gEM8Pb2c9ujHr2g9WX20+7xVTHZ+Oujn4vAachiy5fApT2F9+COZTCUn0bUW7kxjrDAHeaaqSz4nhbgq91ZuLPhaO4xcfADiNdgYTu4Y5w6tcsjITx9yujmhMey22FSpQ39u5L67H3/86ythb+8bqjRHuq6rtFvzssnMz8mTRa11KAEZiGugpz5uImXB75vIzH6M0yNg+D4aVhfxFGKuDnBJrT8y/KvRBpflQ/fgam8ECAwEAAaMmMCQwIgYDVR0lAQH/BBgwFgYIKwYBBQUHAwIGCisGAQQBgjcKAwwwDQYJKoZIhvcNAQENBQADggEBAJ2nnFx6L7x8nksInMMxQsNyKFAHvJ3PMFeNnM0XuVWPXDK/MdyDZhSh2ySbI7la8bdeALsoH9o97hWwLeN8VTox+yXey3PqyR1vo+cql9WQmEOt+fpKcvVdCYLflqLDG+v3ZPgyfiKEK2/xMhJrW0pJX5LjMAX/ttK5C+SKo48h5Jbm4ilJk7l7zlT1LSMVQMWglTdMIAXhtNLjqRGR/6ENeCxubkVEys84inhJ3sONZpuIyrwR6FkD+WloP4lgwyA07/n1YJ6+AoR/T6koeBMPsQEG8Vj4V5kbT1SNY1Wnd9TQZr7/N33Do4CV7kJUXp+i2VquPRzlnMBH9ya5Fqg=";
            secondaryCertificateThumbprint = "MIIDEDCCAfigAwIBAgIQRW74/KVvT5FL7qO4rVn7HzANBgkqhkiG9w0BAQ0FADAwMS4wLAYDVQQDEyVhbmt1c2hiLXZtMDIubnRkZXYuY29ycC5taWNyb3NvZnQuY29tMB4XDTE4MTAyMTE5MTQxNVoXDTE5MTAyMjE5MTQxNVowMDEuMCwGA1UEAxMlYW5rdXNoYi12bTAyLm50ZGV2LmNvcnAubWljcm9zb2Z0LmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKsuJgPpe6VXGKG+/bz4pmEwd2/IUP6bOAyQNHoJ4DuFF0BGEmIhMAi6lhhYpjwtPMylEtRpSvimqm4fp41x0uEf4EIGVDKQwM5l5w+3WJ1gEM8Pb2c9ujHr2g9WX20+7xVTHZ+Oujn4vAachiy5fApT2F9+COZTCUn0bUW7kxjrDAHeaaqSz4nhbgq91ZuLPhaO4xcfADiNdgYTu4Y5w6tcsjITx9yujmhMey22FSpQ39u5L67H3/86ythb+8bqjRHuq6rtFvzssnMz8mTRa11KAEZiGugpz5uImXB75vIzH6M0yNg+D4aVhfxFGKuDnBJrT8y/KvRBpflQ/fgam8ECAwEAAaMmMCQwIgYDVR0lAQH/BBgwFgYIKwYBBQUHAwIGCisGAQQBgjcKAwwwDQYJKoZIhvcNAQENBQADggEBAJ2nnFx6L7x8nksInMMxQsNyKFAHvJ3PMFeNnM0XuVWPXDK/MdyDZhSh2ySbI7la8bdeALsoH9o97hWwLeN8VTox+yXey3PqyR1vo+cql9WQmEOt+fpKcvVdCYLflqLDG+v3ZPgyfiKEK2/xMhJrW0pJX5LjMAX/ttK5C+SKo48h5Jbm4ilJk7l7zlT1LSMVQMWhlTdMIAXhtNLjqRGR/6ENeCxubkVEys84inhJ3sONZpuIyrwR6FkD+WloP4lgwyA07/n1YJ6+AoR/T6koeBMPsQEG8Vj4V5kbT1SNY1Wnd9TQZr7/N33Do4CV7kJUXp+i2VquPRzlnMBH9ya5Fqg=";
            return 0;
        }

        public int DeleteServerCertificate(
            [In, MarshalAs(UnmanagedType.BStr)] string certificateThumbprint)
        {
            return 0;
        }

        public int SwitchToSecondaryCertificateAndUpdateMonitoring()
        {
            return 0;
        }

        public int GetSyncServerCertificate([In, MarshalAs(UnmanagedType.Bool)] bool isPrimary, [MarshalAs(UnmanagedType.BStr), Out] out string serverCertificate)
        {
            serverCertificate = "MIIDEDCCAfigAwIBAgIQRW74/KVvT5FL7qO4rVn7HzANBgkqhkiG9w0BAQ0FADAwMS4wLAYDVQQDEyVhbmt1c2hiLXZtMDIubnRkZXYuY29ycC5taWNyb3NvZnQuY29tMB4XDTE4MTAyMTE5MTQxNVoXDTE5MTAyMjE5MTQxNVowMDEuMCwGA1UEAxMlYW5rdXNoYi12bTAyLm50ZGV2LmNvcnAubWljcm9zb2Z0LmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKsuJgPpe6VXGKG+/bz4pmEwd2/IUP6bOAyQNHoJ4DuFF0BGEmIhMAi6lhhYpjwtPMylEtRpSvimqm4fp41x0uEf4EIGVDKQwM5l5w+3WJ1gEM8Pb2c9ujHr2g9WX20+7xVTHZ+Oujn4vAachiy5fApT2F9+COZTCUn0bUW7kxjrDAHeaaqSz4nhbgq91ZuLPhaO4xcfADiNdgYTu4Y5w6tcsjITx9yujmhMey22FSpQ39u5L67H3/86ythb+8bqjRHuq6rtFvzssnMz8mTRa11KAEZiGugpz5uImXB75vIzH6M0yNg+D4aVhfxFGKuDnBJrT8y/KvRBpflQ/fgam8ECAwEAAaMmMCQwIgYDVR0lAQH/BBgwFgYIKwYBBQUHAwIGCisGAQQBgjcKAwwwDQYJKoZIhvcNAQENBQADggEBAJ2nnFx6L7x8nksInMMxQsNyKFAHvJ3PMFeNnM0XuVWPXDK/MdyDZhSh2ySbI7la8bdeALsoH9o97hWwLeN8VTox+yXey3PqyR1vo+cql9WQmEOt+fpKcvVdCYLflqLDG+v3ZPgyfiKEK2/xMhJrW0pJX5LjMAX/ttK5C+SKo48h5Jbm4ilJk7l7zlT1LSMVQMWglTdMIAXhtNLjqRGR/6ENeCxubkVEys84inhJ3sONZpuIyrwR6FkD+WloP4lgwyA07/n1YJ6+AoR/T6koeBMPsQEG8Vj4V5kbT1SNY1Wnd9TQZr7/N33Do4CV7kJUXp+i2VquPRzlnMBH9ya5Fqg=";
            return 0;
        }

        public int GetSyncServerId([MarshalAs(UnmanagedType.BStr), Out] out string serverId)
        {
            serverId = Guid.NewGuid().ToString();
            return 0;
        }

        public int RegisterMonitoringAgent([MarshalAs(UnmanagedType.BStr)] string serverRegistrationData, [MarshalAs(UnmanagedType.BStr)] string monitoringDataPath)
        {
            return 0;
        }

        [return: MarshalAs(UnmanagedType.BStr)]
        public string NewNetworkLimit([In, MarshalAs(UnmanagedType.Interface)] INetworkLimitConfigEntry config)
        {
            throw new NotImplementedException();
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public INetworkLimitConfigurationEntryEnumeration GetNetworkLimits()
        {
            throw new NotImplementedException();
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public INetworkLimitConfigEntry GetNetworkLimit([In, MarshalAs(UnmanagedType.BStr)] string id)
        {
            throw new NotImplementedException();
        }

        public void RemoveNetworkLimit([In, MarshalAs(UnmanagedType.BStr)] string id)
        {
            throw new NotImplementedException();
        }

        public int GetClusterInfo([MarshalAs(UnmanagedType.BStr), Out] out string clusterId, [MarshalAs(UnmanagedType.BStr), Out] out string clusterName)
        {
            clusterId = null;
            clusterName = null;
            return 0;
        }

        public bool IsInCluster()
        {
            return false;
        }
    }
}
