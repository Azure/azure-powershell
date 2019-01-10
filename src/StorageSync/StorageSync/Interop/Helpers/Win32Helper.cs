// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Commands.StorageSync.Interop.DataObjects
{
    using Commands.StorageSync.Interop.Enums;
    using System;
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
