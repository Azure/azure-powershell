using System.Runtime.InteropServices;

namespace Microsoft.CLU.Native
{
    /// <summary>
    /// Provide access to Unix native APIs.
    /// </summary>
    internal static class Unix
    {
        /// <summary>
        /// Process related APIs.
        /// </summary>
        internal static class Process
        {
            #region Unix Platform Specific types and exported methods

            /// <summary>
            /// see http://linux.die.net/man/2/getpgid
            /// pid is a signed integer type.
            /// </summary>
            [DllImport("libc", SetLastError = true, CharSet = CharSet.Ansi)]
            private static extern int getpgid([In] int pid);

            /// <summary>
            /// see http://linux.die.net/man/2/getpgid
            /// </summary>
            [DllImport("libc", SetLastError = true, CharSet = CharSet.Ansi)]
            private static extern int getpgrp();

            /// <summary>
            /// see http://linux.die.net/man/2/getppid
            /// </summary>
            [DllImport("libc", SetLastError = true, CharSet = CharSet.Ansi)]
            private static extern int getppid();

            #endregion

            #region UnixAPI

            /// <summary>
            /// Get process group ID.
            /// </summary>
            /// <param name="processID">The process ID, default is zero</param>
            /// <returns>The process group ID</returns>
            public static int GetPGID(int processID = 0)
            {
                return getpgid(processID);
            }

            /// <summary>
            /// Get calling process group ID.
            /// </summary>
            /// <returns>The process group ID</returns>
            public static int GetPGRP()
            {
                return getpgrp();
            }

            /// <summary>
            /// Get calling process parent process ID.
            /// </summary>
            /// <returns>The process ID</returns>
            public static int GetPPID()
            {
                return getppid();
            }


            #endregion
        }
    }
}
