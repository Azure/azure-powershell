// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HeatStoreSummary.cs" company="Microsoft Corporation.">
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
    public struct HeatStoreSummary
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string HeatStoreDBPath;
        public UInt64 HeatStoreRecordCount;
        [MarshalAs(UnmanagedType.BStr)]
        public string HeatStoreReportPath;
        public UInt32 ExecutionTimeInSeconds;
        public UInt32 ErrorCode;
        [MarshalAs(UnmanagedType.BStr)]
        public string ErrorString;
    }
}