namespace Commands.StorageSync.Interop.Enums
{
    using System;
    // Refer to the C++ definition of these flags in SyncReplicaHelper.h
    [Flags]
    public enum SyncFlags
    {
        None = 0x0,
        InitialDownloadSyncNeeded = 0x1,
        RecallNeeded = 0x2,
        StableFilePromotionNeeded = 0x4,
        StableFileProtectionBCDRNeeded = 0x8,
        InitialUploadSyncNeeded = 0x10,
        HeatStoreMaintenanceNeeded = 0x20,
        AuthoritativeSyncNeeded = 0x40
    }
}