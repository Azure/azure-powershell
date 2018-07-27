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

    internal static partial class NativeMethods
    {
        public static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        public static int FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        public const int MAX_PATH = 260;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct WIN32_FIND_DATA
        {
            internal FileAttributes dwFileAttributes;
            internal ft.FILETIME ftCreationTime;
            internal ft.FILETIME ftLastAccessTime;
            internal ft.FILETIME ftLastWriteTime;
            internal int nFileSizeHigh;
            internal int nFileSizeLow;
            internal int dwReserved0;
            internal int dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            internal string cFileName;
            // not using this
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            internal string cAlternate;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool FindClose(IntPtr hFindFile);
    }

    public static class ListFiles
    {
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
