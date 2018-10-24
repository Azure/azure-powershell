// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Interop.cs" company="Microsoft Corporation.">
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
    public struct GHOSTING_STATS
    {
        public UInt32 TieredCount;
        public UInt32 AlreadyTieredCount;
        public UInt32 SkippedForSizeCount;
        public UInt32 SkippedForAgeCount;
        public UInt32 SkippedForUnsupportedReparsePointCount;
        public UInt32 FailedToTierCount;
        public UInt64 ReclaimedSpaceBytes;
        public UInt64 SkippedForStableVersionFailure;
    }

}
