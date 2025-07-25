// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrphanedTieredFilesReport.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   COM related
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Commands.StorageSync.Interop.DataObjects
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct OrphanedTieredFilesTelemetryReport
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string CmdletName;
        [MarshalAs(UnmanagedType.BStr)]
        public string Path;
        public UInt64 ProcessedCount;
        public UInt64 OrphanedCount;
        public UInt64 FailedCount;
        public UInt64 ExecutionTimeSeconds;
        public Int32 ErrorCode;
        [MarshalAs(UnmanagedType.BStr)]
        public string Description;
    }

    public struct OrphanedTieredFilesReport
    {
        public List<string> OrphanedTieredFiles;
        public UInt64 ProcessedCount;
        public UInt64 OrphanedCount;
        public UInt64 FailedCount;
    }
}
