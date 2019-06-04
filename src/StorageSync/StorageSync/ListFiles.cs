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

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;
    using ft = System.Runtime.InteropServices.ComTypes;

    /// <summary>
    /// Class NativeMethods.
    /// </summary>
    internal static partial class NativeMethods
    {
        /// <summary>
        /// The invalid handle value
        /// </summary>
        public static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        /// <summary>
        /// The file attribute directory
        /// </summary>
        public static int FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        /// <summary>
        /// The maximum path
        /// </summary>
        public const int MAX_PATH = 260;

        /// <summary>
        /// Struct WIN32_FIND_DATA
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct WIN32_FIND_DATA
        {
            /// <summary>
            /// The dw file attributes
            /// </summary>
            internal FileAttributes dwFileAttributes;
            /// <summary>
            /// The ft creation time
            /// </summary>
            internal ft.FILETIME ftCreationTime;
            /// <summary>
            /// The ft last access time
            /// </summary>
            internal ft.FILETIME ftLastAccessTime;
            /// <summary>
            /// The ft last write time
            /// </summary>
            internal ft.FILETIME ftLastWriteTime;
            /// <summary>
            /// The n file size high
            /// </summary>
            internal int nFileSizeHigh;
            /// <summary>
            /// The n file size low
            /// </summary>
            internal int nFileSizeLow;
            /// <summary>
            /// The dw reserved0
            /// </summary>
            internal int dwReserved0;
            /// <summary>
            /// The dw reserved1
            /// </summary>
            internal int dwReserved1;
            /// <summary>
            /// The c file name
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            internal string cFileName;
            // not using this
            /// <summary>
            /// The c alternate
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            internal string cAlternate;
        }

        /// <summary>
        /// Finds the first file.
        /// </summary>
        /// <param name="lpFileName">Name of the lp file.</param>
        /// <param name="lpFindFileData">The lp find file data.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

        /// <summary>
        /// Finds the next file.
        /// </summary>
        /// <param name="hFindFile">The h find file.</param>
        /// <param name="lpFindFileData">The lp find file data.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);

        /// <summary>
        /// Finds the close.
        /// </summary>
        /// <param name="hFindFile">The h find file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool FindClose(IntPtr hFindFile);
    }

    /// <summary>
    /// Class ListFiles.
    /// </summary>
    public static class ListFiles
    {
        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <param name="dirName">Name of the dir.</param>
        /// <returns>List&lt;Tuple&lt;System.String, System.Int64&gt;&gt;.</returns>
        public static List<Tuple<string, long>> GetFiles(string dirName)
        {
            List<Tuple<string, long>> results = new List<Tuple<string, long>>();

            NativeMethods.WIN32_FIND_DATA findData;

            IntPtr findHandle = NativeMethods.FindFirstFile(dirName + @"\*", out findData);

            if (findHandle == NativeMethods.INVALID_HANDLE_VALUE)
            {
                return results;
            }

            try
            {
                bool found;
                do
                {
                    string currentFileName = findData.cFileName;

                    if (((int)findData.dwFileAttributes & NativeMethods.FILE_ATTRIBUTE_DIRECTORY) == 0)
                    {
                        long fileSizeTmp = findData.nFileSizeHigh;
                        long fileSize = (fileSizeTmp << 32) + findData.nFileSizeLow;
                        results.Add(Tuple.Create(currentFileName, fileSize));
                    }

                    // find next
                    found = NativeMethods.FindNextFile(findHandle, out findData);
                }
                while (found);
            }
            finally
            {
                if (findHandle != NativeMethods.INVALID_HANDLE_VALUE)
                {
                    // close the find handle
                    NativeMethods.FindClose(findHandle);
                }
            }
            return results;
        }

        /// <summary>
        /// Gets the directories.
        /// </summary>
        /// <param name="dirName">Name of the dir.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> GetDirectories(string dirName)
        {
            List<string> results = new List<string>();

            NativeMethods.WIN32_FIND_DATA findData;

            IntPtr findHandle = NativeMethods.FindFirstFile(dirName + @"\*", out findData);

            if (findHandle == NativeMethods.INVALID_HANDLE_VALUE)
            {
                return results;
            }

            try
            {
                bool found;
                do
                {
                    string currentFileName = findData.cFileName;

                    if (((int)findData.dwFileAttributes & NativeMethods.FILE_ATTRIBUTE_DIRECTORY) != 0 &&
                        currentFileName != "." &&
                        currentFileName != "..")
                    {
                        results.Add(currentFileName);
                    }

                    // find next
                    found = NativeMethods.FindNextFile(findHandle, out findData);
                }
                while (found);
            }
            finally
            {
                if (findHandle != NativeMethods.INVALID_HANDLE_VALUE)
                {
                    // close the find handle
                    NativeMethods.FindClose(findHandle);
                }
            }
            return results;
        }

        /// <summary>
        /// Ensures the unc prefix present.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">path</exception>
        public static string EnsureUncPrefixPresent(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException(nameof(path));
            }

            if (path.StartsWith(@"\\?\") || path.StartsWith(@"\\?\unc\"))
            {
                return path;
            }

            if (path.StartsWith(@"\\"))
            {
                // Its smb server path, make sure it start with \\?\unc\
                return @"\\?\unc\" + path.Substring(2);
            }

            return @"\\?\" + path;
        }

        /// <summary>
        /// Ensures the unc prefix is not present.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">path</exception>
        public static string EnsureUncPrefixIsNotPresent(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException(nameof(path));
            }

            if (path.StartsWith(@"\\?\unc\"))
            {
                return @"\\" + path.Substring(8);
            }

            if (path.StartsWith(@"\\?\"))
            {
                return path.Substring(4);
            }

            return path;
        }
    }
}
