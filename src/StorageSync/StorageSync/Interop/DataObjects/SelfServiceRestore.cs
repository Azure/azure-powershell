// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelfServiceRestore.cs" company="Microsoft Corporation.">
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
    public struct SelfServiceRestore
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string Volume;
        [MarshalAs(UnmanagedType.BStr)]
        public string VolumeGuid;
        [MarshalAs(UnmanagedType.Bool)]
        public bool PolicyEnabled;
        public UInt32 CompatibleForDays;
        [MarshalAs(UnmanagedType.BStr)]
        public string OldestCompatibleVssSnapshotTime;
    }
}