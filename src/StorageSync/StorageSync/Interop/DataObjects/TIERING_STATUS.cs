// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TIERING_STATUS_VOLUME.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   COM related 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Commands.StorageSync.Interop.DataObjects
{
    using System.Runtime.InteropServices;
    using System;

    /// <summary>
    ///  This structure should resemble
    ///
    ///{
    ///    BOOL IsTieringEnabled;
    ///    UINT SpacePolicyPercentage;
    ///    UINT TierFilesOlderThanDays;
    ///    BSTR ReplicaGroupId;
    ///    ULONGLONG NamespaceLogicalSizeBytes;
    ///    DWORD NamespaceFilesCount;
    ///    BSTR TieringHealth;
    ///    ULONGLONG TieredFileLogicalSizeBytes;
    ///    DWORD FilesTieredCount;
    ///    ULONGLONG LastTieringSessionStartTime;
    ///    ULONGLONG LastTieringSessionEndTime;
    ///    DWORD LastTieringSessionFilesTieredCount;
    ///    ULONGLONG LastTieringSessionSpaceReclaimedBytes;
    ///    ULONGLONG LastUpdatedTime;
    ///}
    /// </summary>

    [StructLayout(LayoutKind.Sequential)]
    public struct TIERING_STATUS
    {
        public bool IsTieringEnabled;
        public uint SpacePolicyPercentage;
        public uint TierFilesOlderThanDays;
        [MarshalAs(UnmanagedType.BStr)]
        public string ReplicaGroupId;
        public ulong NamespaceLogicalSizeBytes;
        public uint NamespaceFilesCount;
        [MarshalAs(UnmanagedType.BStr)]
        public string TieringHealth;
        public ulong TieredFilesLogicalSizeBytes;
        public uint FilesTieredCount;
        public ulong LastTieringSessionStartTime;
        public ulong LastTieringSessionEndTime;
        public uint LastTieringSessionFilesTieredCount;
        public ulong LastTieringSessionSpaceReclaimedBytes;
        public ulong LastUpdatedTime;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct VOLUME_STATUS
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string VolumeType;
        [MarshalAs(UnmanagedType.BStr)]
        public string VolumeLocalPath;
        public float CurrentVolumeFreeSpacePercentage;
        public ulong CurrentVolumeFreeSpaceBytes;
        public ulong BytesPerCluster;
        public ulong StorageSyncReservedSVIBytes;
    };
}
