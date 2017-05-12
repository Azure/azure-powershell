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
#if !NETSTANDARD
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Threading;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    public abstract class AzureSMProfileProvider : IProfileProvider
    {
        private static ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private static bool _initialized = false;
        private static AzureSMProfileProvider _instance;
        public static AzureSMProfileProvider Instance
        {   get
            {
                try
                {
                    _lock.EnterReadLock();
                    try
                    {
                        return _instance;
                    }
                    finally
                    {
                        _lock.ExitReadLock();
                    }
                }
                catch (LockRecursionException lockException)
                {
                    throw new InvalidOperationException(Abstractions.Properties.Resources.ProfileLockReadRecursion, lockException);
                }
                catch (ObjectDisposedException disposedException)
                {
                    throw new InvalidOperationException(Abstractions.Properties.Resources.ProfileLockReadDisposed, disposedException);
                }
            }
        }

        public virtual IAzureContextContainer Profile { get; set; }
        public abstract T GetProfile<T>() where T : class, IAzureContextContainer;

        public virtual void ResetDefaultProfile()
        {
            Profile.Clear();
        }

        public abstract void SetTokenCacheForProfile(IAzureContextContainer profile);

        /// <summary>
        /// Set the instance of the profile provider for AzureRM
        /// </summary>
        /// <param name="provider">The provider to initialize with</param>
        /// <param name="overwrite">if true, overwrite the existing provider, if it was previously initialized</param>
        public static void SetInstance(Func<AzureSMProfileProvider> provider, bool overwrite)
        {
            try
            {
                _lock.EnterWriteLock();
                try
                {
                    if (!_initialized || overwrite)
                    {
                        _initialized = true;
                        _instance = provider();
                    }
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }
            catch (LockRecursionException lockException)
            {
                throw new InvalidOperationException(Abstractions.Properties.Resources.ProfileLockWriteRecursion, lockException);
            }
            catch (ObjectDisposedException disposedException)
            {
                throw new InvalidOperationException(Abstractions.Properties.Resources.ProfileLockWriteDisposed, disposedException);
            }
        }

        /// <summary>
        /// Set the instance of the profile provider for AzureRM, if it is not already initialized
        /// </summary>
        /// <param name="provider">The provider</param>
        public static void SetInstance(Func<AzureSMProfileProvider> provider)
        {
            SetInstance(provider, false);
        }
    }
}
#endif
