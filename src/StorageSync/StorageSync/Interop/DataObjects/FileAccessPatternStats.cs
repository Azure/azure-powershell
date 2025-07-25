// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileAccessPatternStats.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   COM related
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Commands.StorageSync.Interop.DataObjects
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct FileAccessPatternStats
    {
        public UInt64 AccessDaysBucketStart;
        public UInt64 AccessDaysBucketEnd;
        public UInt64 AccessedFileCount;

        public UInt64 AccessedBeforeTieringFileCount;
        public UInt64 AccessedBeforeTieringTierReasonDatePolicy;
        public UInt64 AccessedBeforeTieringTierReasonVolumePolicy;
        public UInt64 AccessedBeforeTieringTierReasonSync;
        public UInt64 AccessedBeforeTieringTierReasonCloudTieringCmdlet;
        public UInt64 AccessedBeforeTieringTierReasonOther;
        public UInt64 AccessedBeforeTieringTierReasonNotGhosted;

        public UInt64 AccessedAfterTieringFileCount;
        public UInt64 AccessedAfterTieringTierReasonDatePolicy;
        public UInt64 AccessedAfterTieringTierReasonVolumePolicy;
        public UInt64 AccessedAfterTieringTierReasonSync;
        public UInt64 AccessedAfterTieringTierReasonCloudTieringCmdlet;
        public UInt64 AccessedAfterTieringTierReasonOther;

        public float CacheHitPercent;
        public UInt64 CacheHitBytes;
        public UInt64 CacheMissBytes;
        [MarshalAs(UnmanagedType.BStr)]
        public string DataCollectionUtcTime;
    }
}