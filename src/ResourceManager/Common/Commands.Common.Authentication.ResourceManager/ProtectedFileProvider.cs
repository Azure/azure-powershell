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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager.Properties;
using System.Text;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Common.Authentication.ResourceManager
{
    public enum FileProtection
    {
        SharedRead,
        ExclusiveWrite
    }

    /// <summary>
    /// Protect access to a shared file.  File can be accessed in ReadOnly or ReadWrite mode
    /// </summary>
    public abstract class ProtectedFileProvider : IFileProvider, IDisposable
    {
        public const int MaxTries = 30;
        static readonly TimeSpan RetryInterval = TimeSpan.FromMilliseconds(500);
        protected Stream _stream;
        object _initializationLock = new object();
        public string FilePath { get; set; }

        protected IDataStore DataStore { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Stream Stream
        {
            get
            {
                if (_stream == null)
                {
                    InitializeStream();
                }

                return _stream;
            }
        }

        /// <summary>
        /// A reader for the stream associated with this file provider
        /// </summary>
        public StreamReader CreateReader()
        {
            if (Stream == null || !Stream.CanRead || !Stream.CanSeek)
            {
                throw new IOException(string.Format(Resources.UnreadableStream, FilePath));
            }

            Stream.Seek(0, SeekOrigin.Begin);
            return new StreamReader(Stream, Encoding.UTF8);
        }

        /// <summary>
        /// A reader for the stream associated with this file provider
        /// </summary>
        public StreamWriter CreateWriter()
        {
            if (Stream == null || !Stream.CanWrite || !Stream.CanSeek)
            {
                throw new IOException(string.Format(Resources.UnwritableStream, FilePath));
            }

            Stream.Seek(0, SeekOrigin.Begin);
            return new StreamWriter(Stream, Encoding.UTF8);
        }

        protected virtual void InitializeStream()
        {
            lock (_initializationLock)
            {
                if (_stream == null)
                {
                    Stream stream;
                    if (!TryGetStreamLock(AcquireLock, FilePath, out stream))
                    {
                        throw new UnauthorizedAccessException(string.Format(Resources.FileLockFailure, FilePath));
                    }

                    _stream = stream;
                }
            }
        }

        protected abstract Stream AcquireLock(string filePath);

        static bool TryGetStreamLock(Func<string, Stream> acquireLock, string filePath, out Stream stream)
        {
            stream = null;
            int tries = 0;
            do
            {
                try
                {
                    stream = acquireLock(filePath);
                }
                catch (IOException)
                {
                    tries++;
                    TestMockSupport.Delay(RetryInterval);
                }
            }
            while (tries <= MaxTries && stream == null);
            return stream != null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                var stream = Interlocked.Exchange(ref _stream, null);
                if (stream != null)
                {
                    FileStream file = stream as FileStream;
                    if (file != null)
                    {
                        file.Flush(true);
                    }
                    else
                    {
                        stream.Flush();
                    }

                    stream.Close();
                }
            }
        }

        /// <summary>
        /// Dispose the file and the file lock
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Protect access to file usign the given protection level
        /// </summary>
        /// <param name="filePath">The path to the file</param>
        /// <param name="protectionLevel">The protection level over the file</param>
        /// <param name="dataStore">The data store to use for file access</param>
        /// <returns>A file provider with the specified access to the file</returns>
        public static ProtectedFileProvider CreateFileProvider(string filePath, FileProtection protectionLevel, IDataStore dataStore)
        {
            if (null == dataStore)
            {
                throw new ArgumentNullException(nameof(dataStore), Resources.NullDataStore);
            }

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentOutOfRangeException(nameof(filePath), Resources.InvalidFilePath);
            }

            ProtectedFileProvider provider;
            switch (protectionLevel)
            {
                case FileProtection.ExclusiveWrite:
                    provider = new ExclusiveWriteFileProvider();
                    break;
                default:
                    provider = new SharedReadOnlyFileProvider();
                    break;
            }

            provider.DataStore = dataStore;
            provider.FilePath = filePath;
            return provider;
        }

        /// <summary>
        /// Protect access to file usign the given protection level
        /// </summary>
        /// <param name="filePath">The path to the file</param>
        /// <param name="protectionLevel">The protection level over the file</param>
        /// <returns>A file provider with the specified access to the file</returns>
        public static ProtectedFileProvider CreateFileProvider(string filePath, FileProtection protectionLevel = FileProtection.SharedRead)
        {
            return CreateFileProvider(filePath, protectionLevel, AzureSession.Instance.DataStore);
        }

        private class SharedReadOnlyFileProvider : ProtectedFileProvider
        {
            protected override Stream AcquireLock(string filePath)
            {
                return DataStore.OpenForSharedRead(filePath);
            }
        }

        private class ExclusiveWriteFileProvider : ProtectedFileProvider
        {
            protected override Stream AcquireLock(string filePath)
            {
                return DataStore.OpenForExclusiveWrite(filePath);
            }
        }
    }
}
