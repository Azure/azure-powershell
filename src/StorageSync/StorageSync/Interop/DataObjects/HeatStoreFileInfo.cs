// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HeatStoreFileInfo.cs" company="Microsoft Corporation.">
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
    public struct HeatStoreFileInfo
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string FilePath;
        public UInt64 FileId;
        public UInt64 HeatHistory;
        public UInt64 Epoch;
        public bool GhostingState;
        public bool SyncState;
        [MarshalAs(UnmanagedType.BStr)]
        public string LastAccessTimeUtc;
        [MarshalAs(UnmanagedType.BStr)]
        public string LastGhostingTimeUtc;
        public UInt64 TotalGhostingCount;
        [MarshalAs(UnmanagedType.BStr)]
        public string GhostingReason;
        public UInt64 PhysicalSizeBytes;
        public UInt64 LogicalSizeBytes;
        public UInt32 ReparseTag;
    }
}