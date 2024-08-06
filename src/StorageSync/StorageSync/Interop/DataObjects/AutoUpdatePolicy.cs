// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoUpdatePolicy.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   Auto-update policy detail
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Commands.StorageSync.Interop.DataObjects
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct AutoUpdatePolicy
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string PolicyMode;
        [MarshalAs(UnmanagedType.BStr)]
        public string ScheduledWeekDay;
        public uint ScheduledHour;
    }

}
