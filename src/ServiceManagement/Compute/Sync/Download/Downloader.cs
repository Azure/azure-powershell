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

using Microsoft.WindowsAzure.Commands.Sync.Threading;
using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;

namespace Microsoft.WindowsAzure.Commands.Sync.Download
{
    public class Downloader
    {
        private const int DefaultConnectionLimit = 24;
        private DownloaderParameters parameters;

        public Downloader(BlobUri blobUri, string storageAccountKey, string locaFilePath)
        {
            this.parameters = new DownloaderParameters
            {
                BlobUri = blobUri,
                LocalFilePath = locaFilePath,
                ConnectionLimit = DefaultConnectionLimit,
                StorageAccountKey = storageAccountKey,
                ValidateFreeDiskSpace = false,
                ProgressDownloadStatus = Program.SyncOutput.ProgressDownloadStatus,
                ProgressDownloadComplete = Program.SyncOutput.ProgressDownloadComplete
            };
        }

        public Downloader(DownloaderParameters parameters)
        {
            this.parameters = parameters;
        }

        public void Download()
        {
            if (parameters.OverWrite)
            {
                DeleteTempVhdIfExist(parameters.LocalFilePath);
            }
            else
            {
                if (File.Exists(parameters.LocalFilePath))
                {
                    var message = String.Format("File already exists, you can use Overwrite option to delete it:'{0}'", parameters.LocalFilePath);
                    throw new ArgumentException(message);
                }
            }

            var blobHandle = new BlobHandle(parameters.BlobUri, this.parameters.StorageAccountKey);

            if (parameters.ValidateFreeDiskSpace)
            {
                TryValidateFreeDiskSpace(parameters.LocalFilePath, blobHandle.Length);
            }

            const int megaByte = 1024 * 1024;

            var ranges = blobHandle.GetUploadableRanges();
            var bufferManager = BufferManager.CreateBufferManager(Int32.MaxValue, 20 * megaByte);
            var downloadStatus = new ProgressStatus(0, ranges.Sum(r => r.Length), new ComputeStats());

            Trace.WriteLine(String.Format("Total Data:{0}", ranges.Sum(r => r.Length)));

            Program.SyncOutput.WriteVerboseWithTimestamp("Downloading the blob: {0}", parameters.BlobUri.BlobName);

            var fileStreamLock = new object();
            using (new ServicePointHandler(parameters.BlobUri.Uri, parameters.ConnectionLimit))
            {
                using (new ProgressTracker(downloadStatus, parameters.ProgressDownloadStatus, parameters.ProgressDownloadComplete, TimeSpan.FromSeconds(1)))
                {
                    using (var fileStream = new FileStream(parameters.LocalFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write, 8 * megaByte, FileOptions.WriteThrough))
                    {
                        fileStream.SetLength(0);
                        fileStream.SetLength(blobHandle.Length);

                        LoopResult lr = Parallel.ForEach<IndexRange, Stream>(ranges,
                                    blobHandle.OpenStream,
                                    (r, b) =>
                                        {
                                            b.Seek(r.StartIndex, SeekOrigin.Begin);

                                            byte[] buffer = this.EnsureReadAsSize(b, (int)r.Length, bufferManager);

                                            lock (fileStreamLock)
                                            {
                                                Trace.WriteLine(String.Format("Range:{0}", r));
                                                fileStream.Seek(r.StartIndex, SeekOrigin.Begin);
                                                fileStream.Write(buffer, 0, (int)r.Length);
                                                fileStream.Flush();
                                            }

                                            downloadStatus.AddToProcessedBytes((int)r.Length);
                                        },
                                    pbwlf =>
                                        {
                                            pbwlf.Dispose();
                                        },
                                    parameters.ConnectionLimit);

                        if (lr.IsExceptional)
                        {
                            throw new AggregateException(lr.Exceptions);
                        }
                    }
                }
            }
            Program.SyncOutput.WriteVerboseWithTimestamp("Blob downloaded successfullty: {0}", parameters.BlobUri.BlobName);
        }

        private void TryValidateFreeDiskSpace(string destination, long blobLength)
        {
            try
            {
                DriveInfo info = new DriveInfo(destination);
                if (info.AvailableFreeSpace < blobLength)
                {
                    string message = String.Format("Insufficient disk space: Blob's size is {0}, however available space is {1}.", blobLength, info.AvailableFreeSpace);
                    throw new ArgumentOutOfRangeException(message);
                }
            }
            catch (Exception)
            {
            }
        }

        private void DeleteTempVhdIfExist(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        private byte[] EnsureReadAsSize(Stream stream, int size, BufferManager manager)
        {
            byte[] buffer = manager.TakeBuffer(size);
            int byteRead = 0;
            int totalRead = 0;
            int sizeLeft = size;
            do
            {
                byteRead = stream.Read(buffer, totalRead, sizeLeft);
                totalRead += byteRead;
                if (totalRead == size)
                {
                    break;
                }

                sizeLeft = sizeLeft - byteRead;
            } while (true);

            return buffer;
        }
    }
}
