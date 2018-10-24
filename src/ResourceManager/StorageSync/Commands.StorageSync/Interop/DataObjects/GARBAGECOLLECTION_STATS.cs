// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GARBAGECOLLECTION_STATS.cs" company="Microsoft Corporation.">
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
    public struct GARBAGECOLLECTION_STATS
    {
        public UInt32 StableVersionsDeleted;
        public UInt32 StableVersionsAlreadyDeleted;
        public UInt32 StableVersionsFailedToDelete;
        public UInt32 StableVersionsFailedToDeleteExceededMaxCnt;
    }
}
