// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NEW_SYNC_SESSION_SCHEDULE_RESULT.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   COM related 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Commands.StorageSync.Interop.DataObjects
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct NEW_SYNC_SESSION_SCHEDULE_RESULT
    {
        public    bool        SessionScheduled;
        [MarshalAs(UnmanagedType.BStr)]
        public string         SessionScheduledTime;
    };
}
