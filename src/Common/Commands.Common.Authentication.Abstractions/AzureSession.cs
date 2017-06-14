﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Represents the current Azure session.
    /// </summary>
    public abstract class AzureSession : IAzureSession
    {
        static IAzureSession _instance;
        static bool _initialized = false;
        static ReaderWriterLockSlim sessionLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        /// <summary>
        /// Gets or sets Azure client factory.
        /// </summary>
        public IClientFactory ClientFactory { get; set; }

        /// <summary>
        /// Gets or sets Azure authentication factory.
        /// </summary>
        public IAuthenticationFactory AuthenticationFactory { get; set; }

        /// <summary>
        /// Gets or sets data persistence store.
        /// </summary>
        public IDataStore DataStore { get; set; }

        /// <summary>
        /// Gets or sets the token cache store.
        /// </summary>
        public IAzureTokenCache TokenCache { get; set; }

        /// <summary>
        /// Gets or sets profile directory.
        /// </summary>
        public string ProfileDirectory { get; set; }

        /// <summary>
        /// Gets or sets token cache file path.
        /// </summary>
        public string TokenCacheFile { get; set; }

        /// <summary>
        /// Gets or sets profile file name.
        /// </summary>
        public string ProfileFile { get; set; }

        /// <summary>
        /// Gets or sets file name for the migration backup.
        /// </summary>
        public string OldProfileFileBackup { get; set; }

        /// <summary>
        /// Gets or sets old profile file name.
        /// </summary>
        public string OldProfileFile { get; set; }

        /// <summary>
        /// The directory contianing the ARM ContextContainer
        /// </summary>
        public string ARMProfileDirectory { get; set; }

        /// <summary>
        /// The name fo the ARMContextContainer
        /// </summary>
        public string ARMProfileFile { get; set; }

        /// <summary>
        /// Custom metadata for the session
        /// </summary>
        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public static IAzureSession Instance
        {
            get
            {
                try
                {
                    sessionLock.EnterReadLock();
                    try
                    {
                        if (null == _instance)
                        {
                            throw new InvalidOperationException(Abstractions.Properties.Resources.SessionNotInitialized);
                        }

                        return _instance;
                    }
                    finally
                    {
                        sessionLock.ExitReadLock();
                    }
                }
                catch (LockRecursionException lockException)
                {
                    throw new InvalidOperationException(Abstractions.Properties.Resources.SessionLockReadRecursion, lockException);
                }
                catch (ObjectDisposedException disposedException)
                {
                    throw new InvalidOperationException(Abstractions.Properties.Resources.SessionLockReadDisposed, disposedException);
                }
            }
        }

        public abstract TraceLevel AuthenticationLegacyTraceLevel { get; set; }

        public abstract TraceListenerCollection AuthenticationTraceListeners { get; }

        public abstract SourceLevels AuthenticationTraceSourceLevel { get; set; }

        /// <summary>
        /// Initialize the AzureSession, avoid contention at startup
        /// </summary>
        /// <param name="instance">The instance of AzureSession to use</param>
        /// <param name="overwrite">If true, always overwrite the current instance.  Otherwise do not initialize</param>
        public static void Initialize(Func<IAzureSession> instanceCreator, bool overwrite)
        {
            try
            {
                sessionLock.EnterWriteLock();
                try
                {
                    if (!_initialized || overwrite)
                    {
                        _initialized = true;
                        _instance = instanceCreator();
                    }
                }
                finally
                {
                    sessionLock.ExitWriteLock();
                }
            }
            catch (LockRecursionException lockException)
            {
                throw new InvalidOperationException(Abstractions.Properties.Resources.SessionLockWriteRecursion, lockException);
            }
            catch (ObjectDisposedException disposedException)
            {
                throw new InvalidOperationException(Abstractions.Properties.Resources.SessionLockWriteDisposed, disposedException);
            }
        }

        /// <summary>
        /// Initialize the current instance, if it it not already inbitialized
        /// </summary>
        /// <param name="instance"></param>
        public static void Initialize(Func<IAzureSession> instanceCreator)
        {
            Initialize(instanceCreator, false);
        }
    }
}
