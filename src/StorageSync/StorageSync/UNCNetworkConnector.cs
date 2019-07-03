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
    using System.Runtime.InteropServices;
    using NET_API_STATUS = System.UInt32;

    /// <summary>
    /// Class NativeMethods.
    /// </summary>
    internal static partial class NativeMethods
    {
        #region definitions
        /// <summary>
        /// Locals the free.
        /// </summary>
        /// <param name="hMem">The h memory.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LocalFree(IntPtr hMem);

        /// <summary>
        /// Formats the message.
        /// </summary>
        /// <param name="dwFlags">The dw flags.</param>
        /// <param name="lpSource">The lp source.</param>
        /// <param name="dwMessageId">The dw message identifier.</param>
        /// <param name="dwLanguageId">The dw language identifier.</param>
        /// <param name="lpBuffer">The lp buffer.</param>
        /// <param name="nSize">Size of the n.</param>
        /// <param name="Arguments">The arguments.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int FormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer, uint nSize, IntPtr Arguments);

        /// <summary>
        /// Enum FormatMessageFlags
        /// </summary>
        [Flags]
        private enum FormatMessageFlags : uint
        {
            /// <summary>
            /// The format message allocate buffer
            /// </summary>
            FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100,
            /// <summary>
            /// The format message ignore inserts
            /// </summary>
            FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200,
            /// <summary>
            /// The format message from system
            /// </summary>
            FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000,
            /// <summary>
            /// The format message argument array
            /// </summary>
            FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x00002000,
            /// <summary>
            /// The format message from hmodule
            /// </summary>
            FORMAT_MESSAGE_FROM_HMODULE = 0x00000800,
            /// <summary>
            /// The format message from string
            /// </summary>
            FORMAT_MESSAGE_FROM_STRING = 0x00000400,
        }

        /// <summary>
        /// Struct USE_INFO_2
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct USE_INFO_2
        {
            /// <summary>
            /// The ui2 local
            /// </summary>
            internal string ui2_local;
            /// <summary>
            /// The ui2 remote
            /// </summary>
            internal string ui2_remote;
            /// <summary>
            /// The ui2 password
            /// </summary>
            internal string ui2_password;
            /// <summary>
            /// The ui2 status
            /// </summary>
            internal UInt32 ui2_status;
            /// <summary>
            /// The ui2 asg type
            /// </summary>
            internal UInt32 ui2_asg_type;
            /// <summary>
            /// The ui2 refcount
            /// </summary>
            internal UInt32 ui2_refcount;
            /// <summary>
            /// The ui2 usecount
            /// </summary>
            internal UInt32 ui2_usecount;
            /// <summary>
            /// The ui2 username
            /// </summary>
            internal string ui2_username;
            /// <summary>
            /// The ui2 domainname
            /// </summary>
            internal string ui2_domainname;
        }

        /// <summary>
        /// Nets the use add.
        /// </summary>
        /// <param name="UncServerName">Name of the unc server.</param>
        /// <param name="Level">The level.</param>
        /// <param name="Buf">The buf.</param>
        /// <param name="ParmError">The parm error.</param>
        /// <returns>NET_API_STATUS.</returns>
        [DllImport("NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern NET_API_STATUS NetUseAdd(
            string UncServerName,
            UInt32 Level,
            ref USE_INFO_2 Buf,
            out UInt32 ParmError);

        /// <summary>
        /// Nets the use delete.
        /// </summary>
        /// <param name="UncServerName">Name of the unc server.</param>
        /// <param name="UseName">Name of the use.</param>
        /// <param name="ForceCond">The force cond.</param>
        /// <returns>NET_API_STATUS.</returns>
        [DllImport("NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern NET_API_STATUS NetUseDel(
            string UncServerName,
            string UseName,
            UInt32 ForceCond);

        #endregion

        /// <summary>
        /// Gets the system message.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <returns>System.String.</returns>
        public static string GetSystemMessage(int errorCode)
        {
            try
            {
                IntPtr lpMsgBuf = IntPtr.Zero;

                int dwChars = FormatMessage(
                    FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER | FormatMessageFlags.FORMAT_MESSAGE_FROM_SYSTEM | FormatMessageFlags.FORMAT_MESSAGE_IGNORE_INSERTS,
                    IntPtr.Zero,
                    (uint)errorCode,
                    0, // Default language
                    ref lpMsgBuf,
                    0,
                    IntPtr.Zero);
                if (dwChars == 0)
                {
                    int le = Marshal.GetLastWin32Error();
                    return "Unable to get error code string from System - Error " + le.ToString();
                }

                string sRet = Marshal.PtrToStringAnsi(lpMsgBuf);

                lpMsgBuf = LocalFree(lpMsgBuf);
                return sRet;
            }
            catch (Exception e)
            {
                return "Unable to get error code string from System -> " + e.ToString();
            }
        }
    }

    /// <summary>
    /// Class UncNetworkConnector. This class cannot be inherited.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public sealed class UncNetworkConnector : IDisposable
    {
        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed = false;
        /// <summary>
        /// The unc path
        /// </summary>
        private string UNCPath;
        /// <summary>
        /// Gets or sets the last error.
        /// </summary>
        /// <value>The last error.</value>
        public int LastError { get; set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                NetUseDelete();
            }
            disposed = true;
            GC.SuppressFinalize(this);
        }

        /*
         * UNCPath: Fully qualified domain name UNC path
         * Domain: Domain of User
         * 
         * Return: True on success. LastError will hold the system error code in case of failure.
         **/
        /// <summary>
        /// Nets the use with credentials.
        /// </summary>
        /// <param name="userUNCPath">The user unc path.</param>
        /// <param name="User">The user.</param>
        /// <param name="Domain">The domain.</param>
        /// <param name="Password">The password.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool NetUseWithCredentials(string userUNCPath, string User, string Domain, string Password)
        {
            UNCPath = userUNCPath;

            uint returncode;

            NativeMethods.USE_INFO_2 useinfo = new NativeMethods.USE_INFO_2();

            useinfo.ui2_local = null;
            useinfo.ui2_remote = UNCPath;
            useinfo.ui2_username = User;
            useinfo.ui2_domainname = Domain;
            useinfo.ui2_password = Password;
            // useinfo.ui2_asg_type = 0;
            useinfo.ui2_usecount = 1;
            uint paramErrorIndex;
            try
            {
                returncode = NativeMethods.NetUseAdd(null, 2, ref useinfo, out paramErrorIndex);
            }
            catch
            {
                LastError = Marshal.GetLastWin32Error();
                return false;
            }

            if (returncode != 0)
            {
                LastError = (int)returncode;
            }

            return returncode == 0;
        }

        /// <summary>
        /// Gets the last error.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetLastError()
        {
            return NativeMethods.GetSystemMessage(LastError);
        }

        // Return: True on success. LastError will hold the system error code in case of failure.
        /// <summary>
        /// Nets the use delete.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool NetUseDelete()
        {
            uint returncode;
            try
            {
                returncode = NativeMethods.NetUseDel(null, UNCPath, 2);
                return (returncode == 0);
            }
            catch
            {
                LastError = Marshal.GetLastWin32Error();
                return false;
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="UncNetworkConnector" /> class.
        /// </summary>
        ~UncNetworkConnector()
        {
            Dispose();
        }

    }
}
 
 
 