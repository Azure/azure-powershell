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

using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// A set of utilities shared between service and client
    /// </summary>
    internal static class SharedUtilities
    {
        /// <summary>
        /// default base cache path
        /// </summary>
        private static readonly string s_homeEnvVar = Environment.GetEnvironmentVariable("HOME");
        private static readonly string s_lognameEnvVar = Environment.GetEnvironmentVariable("LOGNAME");
        private static readonly string s_userEnvVar = Environment.GetEnvironmentVariable("USER");
        private static readonly string s_lNameEnvVar = Environment.GetEnvironmentVariable("LNAME");
        private static readonly string s_usernameEnvVar = Environment.GetEnvironmentVariable("USERNAME");

        /// <summary>
        /// For the case where we want to log an exception but not handle it in a when clause
        /// </summary>
        /// <param name="loggingAction">Logging action</param>
        /// <returns>false always in order to skip the exception filter</returns>
        public static bool LogExceptionAndDoNotHandle(Action loggingAction)
        {
            loggingAction();
            return false;
        }

        /// <summary>
        /// Format the guid as a string
        /// </summary>
        /// <param name="guid">Guid to format</param>
        /// <returns>Formatted guid in string format</returns>
        public static string FormatGuidAsString(this Guid guid)
        {
            return guid.ToString("D", CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///  Is this a windows platform
        /// </summary>
        /// <returns>A  value indicating if we are running on windows or not</returns>
        public static bool IsWindowsPlatform()
        {
            return Environment.OSVersion.Platform == PlatformID.Win32NT;
        }

        /// <summary>
        /// Is this a MAC platform
        /// </summary>
        /// <returns>A value indicating if we are running on mac or not</returns>
        public static bool IsMacPlatform()
        {
#if NET45
            // we have to also check for PlatformID.Unix because Mono can sometimes return Unix as the platform on a Mac machine.
            // see http://www.mono-project.com/docs/faq/technical/
            return Environment.OSVersion.Platform == PlatformID.MacOSX || Environment.OSVersion.Platform == PlatformID.Unix;
#else
            return System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX);
#endif
        }

        /// <summary>
        /// Is this a linux platform
        /// </summary>
        /// <returns>A  value indicating if we are running on linux or not</returns>
        public static bool IsLinuxPlatform()
        {
#if NET45
            return Environment.OSVersion.Platform == PlatformID.Unix;
#else
            return System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Linux);
#endif
        }

        /// <summary>
        /// Generate the default file location
        /// </summary>
        /// <returns>Root directory</returns>
        internal static string GetUserRootDirectory()
        {
            return !IsWindowsPlatform()
                ? SharedUtilities.GetUserHomeDirOnUnix()
                : Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }

        /// <summary>
        /// Execute a function within a file lock
        /// </summary>
        /// <param name="function">Function to execute within the filelock</param>
        /// <param name="lockFileLocation">Full path of the file to be locked</param>
        /// <param name="lockRetryCount">Number of retry attempts for acquiring the file lock</param>
        /// <param name="lockRetryWaitInMs">Interval to wait for before retrying to acquire the file lock</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        internal static async Task ExecuteWithinLockAsync(Func<Task> function, string lockFileLocation, int lockRetryCount, int lockRetryWaitInMs, CancellationToken cancellationToken = default(CancellationToken))
        {
            Exception exception = null;
            FileStream fileStream = null;
            for (int tryCount = 0; tryCount < lockRetryCount; tryCount++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // Create lock file dir if it doesn't already exist
                Directory.CreateDirectory(Path.GetDirectoryName(lockFileLocation));
                try
                {
                    // We are using the file locking to synchronize the store, do not allow multiple writers or readers for the file.
                    fileStream = new FileStream(lockFileLocation, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                    break;
                }
                catch (IOException ex)
                {
                    exception = ex;
                    await Task.Delay(TimeSpan.FromMilliseconds(lockRetryWaitInMs)).ConfigureAwait(false);
                }
            }

            if (fileStream == null && exception != null)
            {
                throw new InvalidOperationException("Could not get access to the shared lock file.", exception);
            }

            using (fileStream)
            {
                await function().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Execute a function within a file lock
        /// </summary>
        /// <param name="function">Function to execute within the filelock</param>
        /// <param name="lockFileLocation">Full path of the file to be locked</param>
        /// <param name="lockRetryCount">Number of retry attempts for acquiring the file lock</param>
        /// <param name="lockRetryWaitInMs">Interval to wait for before retrying to acquire the file lock</param>
        /// <param name="cancellationToken">cancellationToken</param>
        internal static void ExecuteWithinLock(Func<bool> function, string lockFileLocation, int lockRetryCount, int lockRetryWaitInMs, CancellationToken cancellationToken = default(CancellationToken))
        {
            Exception exception = null;
            FileStream fileStream = null;
            for (int tryCount = 0; tryCount < lockRetryCount; tryCount++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // Create lock file dir if it doesn't already exist
                Directory.CreateDirectory(Path.GetDirectoryName(lockFileLocation));
                try
                {
                    // We are using the file locking to synchronize the store, do not allow multiple writers or readers for the file.
                    fileStream = new FileStream(lockFileLocation, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
                    break;
                }
                catch (IOException ex)
                {
                    exception = ex;
                    Task.Delay(TimeSpan.FromMilliseconds(lockRetryWaitInMs));
                }
            }

            if (fileStream == null && exception != null)
            {
                throw new InvalidOperationException("Could not get access to the shared lock file.", exception);
            }

            using (fileStream)
            {
                function();
            }
        }

        private static string GetUserHomeDirOnUnix()
        {
            if (SharedUtilities.IsWindowsPlatform())
            {
                throw new NotSupportedException();
            }

            if (!string.IsNullOrEmpty(SharedUtilities.s_homeEnvVar))
            {
                return SharedUtilities.s_homeEnvVar;
            }

            string username = null;
            if (!string.IsNullOrEmpty(SharedUtilities.s_lognameEnvVar))
            {
                username = s_lognameEnvVar;
            }
            else if (!string.IsNullOrEmpty(SharedUtilities.s_userEnvVar))
            {
                username = s_userEnvVar;
            }
            else if (!string.IsNullOrEmpty(SharedUtilities.s_lNameEnvVar))
            {
                username = s_lNameEnvVar;
            }
            else if (!string.IsNullOrEmpty(SharedUtilities.s_usernameEnvVar))
            {
                username = s_usernameEnvVar;
            }

            if (SharedUtilities.IsMacPlatform())
            {
                return !string.IsNullOrEmpty(username) ? Path.Combine("/Users", username) : null;
            }
            else if (SharedUtilities.IsLinuxPlatform())
            {
                if (LinuxNativeMethods.getuid() == LinuxNativeMethods.RootUserId)
                {
                    return "/root";
                }
                else
                {
                    return !string.IsNullOrEmpty(username) ? Path.Combine("/home", username) : null;
                }
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
