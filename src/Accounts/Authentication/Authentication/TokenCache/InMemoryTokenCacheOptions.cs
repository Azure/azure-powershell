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
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Azure.Identity;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class InMemoryTokenCacheOptions : UnsafeTokenCacheOptions
    {
        internal ReadOnlyMemory<byte> CachedToken { get; private set; }
        private ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();

        public InMemoryTokenCacheOptions()
            : this(new ReadOnlyMemory<byte>())
        {
        }

        public InMemoryTokenCacheOptions(ReadOnlyMemory<byte> token)
        {
            CachedToken = token;
        }

        protected override async Task<ReadOnlyMemory<byte>> RefreshCacheAsync()
        {
            readerWriterLockSlim.EnterReadLock();
            try
            {
                return await Task.FromResult(CachedToken);
            }
            finally
            {
                readerWriterLockSlim.ExitReadLock();
            }
        }

        protected override Task TokenCacheUpdatedAsync(TokenCacheUpdatedArgs tokenCacheUpdatedArgs)
        {
            readerWriterLockSlim.EnterWriteLock();
            try
            {
                CachedToken = tokenCacheUpdatedArgs.UnsafeCacheData;
            }
            finally
            {
                readerWriterLockSlim.ExitWriteLock();
            }
            return Task.CompletedTask;
        }

        public void Serialize(Stream stream)
        {
            readerWriterLockSlim.EnterReadLock();
            try
            {
                if (CachedToken.Length > 0)
                {
                    var bytes = CachedToken.ToArray();
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            finally
            {
                readerWriterLockSlim.ExitReadLock();
            }
        }

        public static InMemoryTokenCacheOptions Deserialize(Stream stream)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                var token = memoryStream.ToArray();
                return new InMemoryTokenCacheOptions(token);
            }
        }
    }
}
