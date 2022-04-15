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

using Microsoft.WindowsAzure.Commands.Sync.Download;
using Microsoft.WindowsAzure.Commands.Tools.Vhd;
using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using Microsoft.WindowsAzure.Commands.Sync.Upload;
using Microsoft.WindowsAzure.Commands.Sync;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace Microsoft.Azure.Commands.Compute.Sync.Upload
{
    public class DiskUploadCreator
    {
        protected FileInfo localVhd;
        private LocalMetaData operationMetaData;

        private const int MegaByte = 1024 * 1024;
        private const int PageSizeInBytes = 2 * MegaByte;
        private const int MaxBufferSize = 20 * MegaByte;
        private const long FourTeraByte = 4 * 1024L * 1024L * 1024L * 1024L;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Need to keep UploadContext till the end of upload")]
        public UploadContextDisk Create(FileInfo localVhd, PSPageBlobClient pageblob, bool overWrite)
        {
            AssertIfValidhVhd(localVhd);
            AssertIfValidVhdSize(localVhd);

            UploadContextDisk context = null;
            bool completed = false;
            this.localVhd = localVhd;
            try
            {
                context = new UploadContextDisk
                {
                    DestinationDisk = pageblob,
                    SingleInstanceMutex = AcquireSingleInstanceMutex(pageblob.Uri)
                };

                PopulateContextWithUploadableRanges(localVhd, context, false);
                PopulateContextWithDataToUpload(localVhd, context);

                context.Md5HashOfLocalVhd = MD5HashOfLocalVhd;
                completed = true;
            }
            finally
            {
                if (!completed && context != null)
                {
                    context.Dispose();
                }
            }
            return context;
        }

        public LocalMetaData OperationMetaData
        {
            [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
            get
            {
                if (this.operationMetaData == null)
                {
                    this.operationMetaData = new LocalMetaData
                    {
                        FileMetaData = FileMetaData.Create(localVhd.FullName),
                        SystemInformation = SystemInformation.Create()
                    };
                }
                return operationMetaData;
            }
        }

        public byte[] MD5HashOfLocalVhd
        {
            get { return OperationMetaData.FileMetaData.MD5Hash; }
        }

        public static void AssertIfValidhVhd(FileInfo vhdFile)
        {
            var vhdValidationResults = VhdValidator.Validate(VhdValidationType.IsVhd, vhdFile.FullName);
            if (vhdValidationResults.Count(r => r.ErrorCode != 0) != 0)
            {
                string message = String.Format("'{0}' is not a valid VHD file.", vhdFile.FullName);
                throw new InvalidOperationException(message, vhdValidationResults[0].Error);
            }
        }

        private static void AssertIfValidVhdSize(FileInfo fileInfo)
        {
            using (var stream = new VirtualDiskStream(fileInfo.FullName))
            {
                if (stream.Length > FourTeraByte)
                {
                    var lengthString = stream.Length.ToString("N0", CultureInfo.CurrentCulture);
                    var expectedLengthString = FourTeraByte.ToString("N0", CultureInfo.CurrentCulture);
                    string message = String.Format("VHD size is too large ('{0}'), maximum allowed size is '{1}'.", lengthString, expectedLengthString);
                    throw new InvalidOperationException(message);
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Need to keep Mutex open till the end of upload")]
        private static Mutex AcquireSingleInstanceMutex(Uri destinationBlobUri)
        {
            string mutexName = GetMutexName(destinationBlobUri);

            bool throwing = true;
            Mutex singleInstanceMutex = null;
            try
            {
                singleInstanceMutex = new Mutex(false, @"Global\" + mutexName);
                if (!singleInstanceMutex.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    var message = String.Format("An upload is already in progress on this machine");
                    throw new InvalidOperationException(message);
                }
                throwing = false;
                return singleInstanceMutex;
            }
            finally
            {
                if (throwing && singleInstanceMutex != null)
                {
                    singleInstanceMutex.ReleaseMutex();
                    singleInstanceMutex.Close();
                }
            }
        }

        private static string GetMutexName(Uri destinationBlobUri)
        {
            var invariant = destinationBlobUri.ToString().ToLowerInvariant();
            var bytes = Encoding.Unicode.GetBytes(invariant);
            using (var md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        protected static void PopulateContextWithUploadableRanges(FileInfo vhdFile, UploadContextDisk context, bool resume)
        {
            using (var vds = new VirtualDiskStream(vhdFile.FullName))
            {
                IEnumerable<IndexRange> ranges = vds.Extents.Select(e => e.Range).ToArray();

                var bs = new BufferedStream(vds);
                // linear still
                //var uploadableRanges = IndexRangeHelper.ChunkRangesBySize(ranges.Take(3000), PageSizeInBytes).ToArray();
                var uploadableRanges = IndexRangeHelper.ChunkRangesBySize(ranges, PageSizeInBytes).ToArray();

                // detecting empty data blocks line. Takes long 
                var nonEmptyUploadableRanges = GetNonEmptyRanges(bs, uploadableRanges).ToArray();
                context.UploadableDataSize = nonEmptyUploadableRanges.Sum(r => r.Length);
                context.UploadableRanges = nonEmptyUploadableRanges;
            }
        }

        protected static void PopulateContextWithDataToUpload(FileInfo vhdFile, UploadContextDisk context)
        {
            context.UploadableDataWithRanges = GetDataWithRangesToUpload(vhdFile, context);
        }


        protected static IEnumerable<IndexRange> GetNonEmptyRanges(Stream stream, IEnumerable<IndexRange> uploadableRanges)
        {
            Program.SyncOutput.MessageDetectingActualDataBlocks();
            var manager = BufferManager.CreateBufferManager(Int32.MaxValue, MaxBufferSize);
            int totalRangeCount = uploadableRanges.Count();
            int processedRangeCount = 0;

            foreach (var range in uploadableRanges)
            {

                var dataWithRange = new DataWithRange(manager)
                {
                    Data = ReadBytes(stream, range, manager),
                    Range = range
                };
                using (dataWithRange)
                {
                    if (dataWithRange.IsAllZero())
                    {
                        Program.SyncOutput.DebugEmptyBlockDetected(dataWithRange.Range);
                    }
                    else
                    {
                        yield return dataWithRange.Range;
                    }
                }

                Program.SyncOutput.ProgressEmptyBlockDetection(++processedRangeCount, totalRangeCount);
            }

            Program.SyncOutput.MessageDetectingActualDataBlocksCompleted();
            yield break;
        }

        protected static IEnumerable<DataWithRange> GetDataWithRangesToUpload(FileInfo vhdFile, UploadContextDisk context)
        {
            var uploadableRanges = context.UploadableRanges;
            var manager = BufferManager.CreateBufferManager(Int32.MaxValue, MaxBufferSize);
            using (var vds = new VirtualDiskStream(vhdFile.FullName))
            {
                foreach (var range in uploadableRanges)
                {
                    var localRange = range;
                    yield return new DataWithRange(manager)
                    {
                        Data = ReadBytes(vds, localRange, manager),
                        Range = localRange
                    };
                }
            }
            yield break;
        }

        private static byte[] ReadBytes(Stream stream, IndexRange rangeToRead, BufferManager manager)
        {

            stream.Seek(rangeToRead.StartIndex, SeekOrigin.Begin);

            var bufferSize = (int)rangeToRead.Length;
            var buffer = manager.TakeBuffer(bufferSize);

            int bytesTotal = 0;
            while (bytesTotal < bufferSize)
            {
                int bytesRead = stream.Read(buffer, bytesTotal, bufferSize - bytesTotal);
                bytesTotal += bytesRead;
            }

            return buffer;
        }

    }
}