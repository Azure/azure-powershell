// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Win32Helper.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   Native code PInvokes
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Commands.StorageSync.Interop.DataObjects
{
    using Commands.StorageSync.Interop.Enums;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// TODO : Make it internal
    /// </summary>
    public class Win32Helper
    {
        [DllImport("ole32.Dll")]
        static public extern int
            CoCreateInstance(
            ref Guid clsid,
            [MarshalAs(UnmanagedType.IUnknown)]
            object inner,
            uint context,
            ref Guid uuid,
            out IntPtr rReturnedComObject);

        [DllImport("ole32.Dll")]
        static public extern Int32 CoInitialize(
            [In] IntPtr reserved3
            );

        [DllImport("ole32.DLL", CharSet = CharSet.Auto)]
        public static extern int CoSetProxyBlanket(
                                             IntPtr pProxy,
                                             uint dwAuthnSvc,
                                             uint dwAuthzSvc,
                                             string pServerPrincName,
                                             RpcAuthnLevel dwAuthnLevel,
                                             RpcImpLevel dwImpLevel,
                                             IntPtr pAuthInfo,
                                             OleAuthCapabilities dwCapababilities);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static public extern IntPtr FindFirstFile(string lpFileName, out
                                WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static public extern bool FindNextFile(IntPtr hFindFile, out
                                        WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static public extern bool FindClose(IntPtr hFindFile);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static public extern Int64 GetFileAttributes(string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static public extern Int64 GetLastError();
    }
}
