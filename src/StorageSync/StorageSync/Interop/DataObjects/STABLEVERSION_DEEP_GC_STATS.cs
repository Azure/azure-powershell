// --------------------------------------------------------------------------------------------------------------------
// <copyright file="STABLEVERSION_DEEP_GC_STATS.cs" company="Microsoft Corporation.">
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
    public struct STABLEVERSION_DEEP_GC_STATS
    {
        public UInt32 ReparsePointsIterated;
        public UInt32 StableVersionsGarbageCollected;
        public UInt32 StableVersionsValidationFailed;
        public UInt32 StableVersionsGarbageCollectionFailed;
    }
}
