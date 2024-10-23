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
    /// Win32 Helper class
    /// </summary>
    public sealed class Win32Helper
    {
        /// <summary>
        /// Coes the create instance.
        /// </summary>
        /// <param name="clsid">The CLSID.</param>
        /// <param name="inner">The inner.</param>
        /// <param name="context">The context.</param>
        /// <param name="uuid">The UUID.</param>
        /// <param name="rReturnedComObject">The r returned COM object.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("ole32.Dll")]
        static public extern int
            CoCreateInstance(
            ref Guid clsid,
            [MarshalAs(UnmanagedType.IUnknown)]
            object inner,
            uint context,
            ref Guid uuid,
            out IntPtr rReturnedComObject);

        /// <summary>
        /// Coes the initialize.
        /// </summary>
        /// <param name="reserved3">The reserved3.</param>
        /// <returns>Int32.</returns>
        [DllImport("ole32.Dll")]
        static public extern Int32 CoInitialize(
            [In] IntPtr reserved3
            );

        /// <summary>
        /// Coes the set proxy blanket.
        /// </summary>
        /// <param name="pProxy">The p proxy.</param>
        /// <param name="dwAuthnSvc">The dw authn SVC.</param>
        /// <param name="dwAuthzSvc">The dw authz SVC.</param>
        /// <param name="pServerPrincName">Name of the p server princ.</param>
        /// <param name="dwAuthnLevel">The dw authn level.</param>
        /// <param name="dwImpLevel">The dw imp level.</param>
        /// <param name="pAuthInfo">The p authentication information.</param>
        /// <param name="dwCapababilities">The dw capababilities.</param>
        /// <returns>System.Int32.</returns>
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

        /// <summary>
        /// Finds the first file.
        /// </summary>
        /// <param name="lpFileName">Name of the lp file.</param>
        /// <param name="lpFindFileData">The lp find file data.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static public extern IntPtr FindFirstFile(string lpFileName, out
                                WIN32_FIND_DATA lpFindFileData);

        /// <summary>
        /// Finds the next file.
        /// </summary>
        /// <param name="hFindFile">The h find file.</param>
        /// <param name="lpFindFileData">The lp find file data.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static public extern bool FindNextFile(IntPtr hFindFile, out
                                        WIN32_FIND_DATA lpFindFileData);

        /// <summary>
        /// Finds the close.
        /// </summary>
        /// <param name="hFindFile">The h find file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static public extern bool FindClose(IntPtr hFindFile);

        /// <summary>
        /// Gets the file attributes.
        /// </summary>
        /// <param name="lpFileName">Name of the lp file.</param>
        /// <returns>Int64.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static public extern Int64 GetFileAttributes(string lpFileName);

        /// <summary>
        /// Gets the last error.
        /// </summary>
        /// <returns>Int64.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static public extern Int64 GetLastError();
    }
}
