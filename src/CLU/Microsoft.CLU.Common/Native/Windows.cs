using System;
using System.Runtime.InteropServices;

namespace Microsoft.CLU.Native
{
    /// <summary>
    /// Provide access to Windows native APIs.
    /// </summary>
    internal static class Windows
    {
        /// <summary>
        /// Process related APIs.
        /// </summary>
        internal static class Process
        {
            #region Windows Platform Specific types and exported methods

            /// <summary>
            /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms682489(v=vs.85).aspx
            /// </summary>
            [Flags]
            private enum SnapshotFlags : uint
            {
                TH32CS_SNAPHEAPLIST = 0x00000001,
                TH32CS_SNAPPROCESS = 0x00000002,
                TH32CS_SNAPTHREAD = 0x00000004,
                TH32CS_SNAPMODULE = 0x00000008,
                TH32CS_SNAPMODULE32 = 0x00000010,
                TH32CS_INHERIT = 0x80000000,
                TH32CS_SNAPALL = 0x00000001 | 0x00000002 | 0x00000004 | 0x00000008
            }

            /// <summary>
            /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms684839(v=vs.85).aspx
            /// </summary>
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            private struct PROCESSENTRY32
            {
                public uint dwSize;
                public uint cntUsage;
                public uint th32ProcessID;
                public IntPtr th32DefaultHeapID;
                public uint th32ModuleID;
                public uint cntThreads;
                public uint th32ParentProcessID;
                public int pcPriClassBase;
                public uint dwFlags;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public string szExeFile;
            };

            /// <summary>
            /// Win32 invalid handle value.
            /// </summary>
            public static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

            /// <summary>
            /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms682489(v=vs.85).aspx
            /// </summary>
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern IntPtr CreateToolhelp32Snapshot([In] uint dwFlags, [In] uint th32ProcessID);

            /// <summary>
            /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms684834(v=vs.85).aspx
            /// </summary>
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern bool Process32First([In] IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

            /// <summary>
            /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms684836(v=vs.85).aspx
            /// </summary>
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern bool Process32Next([In] IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

            /// <summary>
            /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms724211(v=vs.85).aspx
            /// </summary>
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseHandle([In] IntPtr hHandle);

            #endregion

            #region WinAPI

            /// <summary>
            /// Gets process ID of an ancestor process of a current Windows process.
            /// </summary>
            /// <param name="level">The ancestor level</param>
            /// <returns>The ancestor process ID</returns>
            public static uint GetAncestorPID(uint level)
            {
                return GetAncestorPID((uint)System.Diagnostics.Process.GetCurrentProcess().Id, level);
            }

            /// <summary>
            /// Gets process ID of an ancestor process of a Windows process identified by the given process ID.
            /// </summary>
            /// <param name="processID">The process ID</param>
            /// <param name="level">The ancestor level</param>
            /// <returns>The ancestor process ID</returns>
            public static uint GetAncestorPID(uint processID, uint level)
            {
                if (level == 0)
                {
                    return processID;
                }

                uint pid = GetPPID(processID);
                while (level > 1)
                {
                    pid = GetPPID(pid);
                    level--;
                }

                return pid;
            }

            /// <summary>
            /// Gets Parent process ID of the current Windows process.
            /// </summary>
            /// <returns>The parent process ID</returns>
            public static uint GetPPID()
            {
                return GetPPID((uint)System.Diagnostics.Process.GetCurrentProcess().Id);
            }

            /// <summary>
            /// Gets Parent process ID of a Windows Process identified by the given process ID.
            /// </summary>
            /// <param name="processID">The process ID</param>
            /// <returns>The parent process ID</returns>
            public static uint GetPPID(uint processID)
            {
                uint INCLUDE_ALLPROCESS = 0;
                IntPtr hSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.TH32CS_SNAPPROCESS, INCLUDE_ALLPROCESS);
                if (hSnapshot == INVALID_HANDLE_VALUE)
                {
                    throw new InvalidOperationException($"Invokng kernel32::CreateToolhelp32Snapshot failed. ErrorCode: {Marshal.GetLastWin32Error()}");
                }

                PROCESSENTRY32 processEntry = new PROCESSENTRY32();
                processEntry.dwSize = (uint)Marshal.SizeOf<PROCESSENTRY32>();

                try
                {
                    if (!Process32First(hSnapshot, ref processEntry))
                    {
                        throw new InvalidOperationException($"Invokng kernel32::Process32First failed. ErrorCode: {Marshal.GetLastWin32Error()}");
                    }

                    do
                    {
                        if (processEntry.th32ProcessID == processID)
                        {
                            return processEntry.th32ParentProcessID;
                        }
                    } while (Process32Next(hSnapshot, ref processEntry));

                    throw new InvalidOperationException($"Process with ID {processID} not found");
                }
                finally
                {
                    CloseHandle(hSnapshot);
                }
            }

            #endregion
        }
    }
}
