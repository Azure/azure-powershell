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
    public struct RecallStatistics
    {
        public UInt32 NumberOfFilesProcessed;
        public UInt32 NumberOfFilesRecalled;
        public UInt32 NumberOfFilesFailedToRecall;
        public UInt32 NumberofFilesSkipped;
        public UInt64 SpaceClaimedInBytes;
    }
}
