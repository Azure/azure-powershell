// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecallFilesReport.cs" company="Microsoft Corporation.">
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
    public struct RecallFilesTelemetryReport
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string CmdletName;
        [MarshalAs(UnmanagedType.BStr)]
        public string Path;
        [MarshalAs(UnmanagedType.BStr)]
        public string PathFileId;
        public UInt32 NumberOfFilesProcessed;
        public UInt32 NumberOfFilesRecalled;
        public UInt32 NumberOfFilesFailedToRecall;
        public UInt32 NumberofFilesSkipped;
        public UInt64 SpaceClaimedInBytes;
        public Int32 ErrorCode;
        [MarshalAs(UnmanagedType.BStr)]
        public string Description;
    }
}
