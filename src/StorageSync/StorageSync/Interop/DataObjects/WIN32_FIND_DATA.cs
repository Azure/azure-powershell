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

using System.IO;
using System.Runtime.InteropServices;

namespace Commands.StorageSync.Interop.DataObjects
{
    /// <summary>
    /// Struct WIN32_FIND_DATA
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WIN32_FIND_DATA
    {
        /// <summary>
        /// The dw file attributes
        /// </summary>
        public FileAttributes dwFileAttributes;
        /// <summary>
        /// The ft creation time
        /// </summary>
        public FILETIME ftCreationTime;
        /// <summary>
        /// The ft last access time
        /// </summary>
        public FILETIME ftLastAccessTime;
        /// <summary>
        /// The ft last write time
        /// </summary>
        public FILETIME ftLastWriteTime;
        /// <summary>
        /// The n file size high
        /// </summary>
        public int nFileSizeHigh;
        /// <summary>
        /// The n file size low
        /// </summary>
        public int nFileSizeLow;
        /// <summary>
        /// The dw reserved0
        /// </summary>
        public int dwReserved0;
        /// <summary>
        /// The dw reserved1
        /// </summary>
        public int dwReserved1;
        /// <summary>
        /// The c file name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ManagementInteropConstants.MAX_PATH)]
        public string cFileName;
        // not using this
        /// <summary>
        /// The c alternate
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string cAlternate;
    }
}
