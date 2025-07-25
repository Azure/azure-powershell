// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerEndpointStatus.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   Auto-update policy detail
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Commands.StorageSync.Interop.DataObjects
{

    public class ServerEndpointStatus
    {
        // Endpoint management properties
        public string ServerEndpointName;
        public string SubscriptionId;
        public string ResourceGroupName;
        public string StorageSyncServiceName;
        public string SyncGroupName;
        public string ServerLocalPath;
        public bool CloudTieringEnabled;
        public UInt32 VolumeFreeSpacePercent;
        public UInt32 TierFilesOlderThanDays;
        public string InitialDownloadPolicy;
        public string LocalCacheMode;
        public string InitialUploadPolicy;
        // Endpoint report properties
        public string StatusReportError;
        public string StatusReportErrorDescription;
        public DateTime? StatusReportLastStatisticDataCollectionTime;
        public UInt32 StatusReportNamespaceFileCount;
        public double StatusReportNamespaceSizeGB;
        public double StatusReportVolumeCapacityGB;
        public double StatusReportObservedVolumeFreeSpacePercent;
        public DateTime? StatusReportLastTieringTime;
        public UInt32 StatusReportLastTieringFileCount;
        public double StatusReportLastTieringFileDataSizeGB;
        public UInt32 StatusReportLastTieringFileFailureCount;
        public DateTime? StatusReportLastScrubbingTime;
        public string StatusReportLastScrubbingType;
        public UInt32 StatusReportLastScrubbingItemsDetected;
        public UInt32 StatusReportLastScrubbingItemsRepaired;
        public UInt32 StatusReportLastScrubbingItemsNotRepaired;
        public UInt64 StatusReportRecalledFileCount;
        public double StatusReportRecalledFileDataSizeGB;
        public UInt64 StatusReportRecalledFileFailureCount;
    }

    public class ServerJsonData
    {
        public List<ServerEndpointStatus> ServerEndpoints;
    }

}
