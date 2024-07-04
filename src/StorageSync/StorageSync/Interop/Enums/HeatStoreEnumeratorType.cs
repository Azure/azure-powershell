// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HeatStoreEnumeratorType.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   COM related
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Commands.StorageSync.Interop.Enums
{
    public enum HeatStoreEnumeratorType
    {
        LastAccessTimeWithSyncAndTieringOrder = 1,
        Epoch,
        FileId,
        SyncGid,
        FilesToBeTieredBySpacePolicy,
        AscendingEpoch,
        FilesToBeTieredByDatePolicy,
        InverseHeatHistoryV2,
        DescendingLastAccessTime,
        OrderTieredFilesWillBeRecalled
    }
}