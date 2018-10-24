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
    public struct ProxySetting
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string Address;
        public uint Port;
        [MarshalAs(UnmanagedType.BStr)]
        public string UserName;
        [MarshalAs(UnmanagedType.BStr)]
        public string Password;
    }

}
