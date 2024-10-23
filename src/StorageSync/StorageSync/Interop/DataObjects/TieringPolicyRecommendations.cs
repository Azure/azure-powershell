// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TieringPolicyRecommendations.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   TieringPolicyRecommendations data object
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Commands.StorageSync.Interop.DataObjects
{
    using System;
    using System.Runtime.InteropServices;
    using Commands.StorageSync.Interop.Enums;

    [StructLayout(LayoutKind.Sequential)]
    public struct TieringPolicyRecommendations
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string VolumeGuid;
        public UInt64 VolumeSizeBytes;
        [MarshalAs(UnmanagedType.BStr)]
        public string ServerEndpointPath;
        public UInt32 DatePolicyDays;
        public UInt32 EffectiveVolumePolicyFreeSpacePercent;
        public UInt64 CacheSizeBytes;
        public UInt64 SizeOutsideTieringScopeBytes;
        public UInt32 PolicyAdvisorMode;
        public UInt32 EvaluationDays;
        public UInt32 EvaluationTargetCacheHitPercent;
        public float ObservedPercentFilesAccessed;
        public float ObservedCacheHitPercent;
        public UInt64 ObservedCacheHitBytes;
        public UInt64 ObservedCacheMissBytes;
        public UInt32 RecommendedDatePolicyDays;
        public UInt64 RequiredCacheSizeBytes;
        public float RecommendedVolumeFreeSpacePercent;
        public UInt64 RecommendedVolumeSizeBytes;
        [MarshalAs(UnmanagedType.BStr)]
        public string DataCollectionUtcTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TieringPolicyRecommendationsOutput
    {
        public string VolumeGuid;
        public UInt64 VolumeSizeBytes;
        public string ServerEndpointPath;
        public UInt32? DatePolicyDays;
        public UInt32 EffectiveVolumePolicyFreeSpacePercent;
        public UInt64 CacheSizeBytes;
        public UInt64 SizeOutsideTieringScopeBytes;
        public string PolicyAdvisorMode;
        public UInt32 EvaluationTargetCacheHitPercent;
        public UInt32 EvaluationDays;
        public float PercentOfTotalFilesAccessedInEndpoint;
        public float? ObservedCacheHitPercent;
        public UInt64? ObservedCacheHitBytes;
        public UInt64? ObservedCacheMissBytes;
        public UInt32? RecommendedDatePolicyDays;
        public UInt64 RequiredCacheSizeBytes;
        public UInt32 RecommendedVolumeFreeSpacePercent;    // This is intentionally not a float data type, since portal/ARM uses whole number
        public UInt64 RecommendedVolumeSizeBytes;
        public string DataCollectionUtcTime;
    }
}
