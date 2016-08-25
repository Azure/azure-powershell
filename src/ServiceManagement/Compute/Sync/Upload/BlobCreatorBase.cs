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

namespace Microsoft.WindowsAzure.Commands.Sync.Upload
{
    public interface ICloudPageBlobObjectFactory
    {
        CloudPageBlob Create(BlobUri destination);
        bool CreateContainer(BlobUri destination);
        BlobRequestOptions CreateRequestOptions();
    }

    public abstract class BlobCreatorBase
    {
        private const long OneTeraByte = 1024L * 1024L * 1024L * 1024L;

        protected FileInfo localVhd;
        protected readonly ICloudPageBlobObjectFactory blobObjectFactory;
        protected Uri destination;
        protected BlobUri blobDestination;
        protected string queryString;
        protected StorageCredentials credentials;
        protected CloudPageBlob destinationBlob;
        protected BlobRequestOptions requestOptions;
        protected bool overWrite;
        private readonly TimeSpan delayBetweenRetries = TimeSpan.FromSeconds(10);

        private const int MegaByte = 1024 * 1024;
        private const int PageSizeInBytes = 2 * MegaByte;
        private const int MaxBufferSize = 20 * MegaByte;

        protected BlobCreatorBase(FileInfo localVhd, BlobUri blobDestination, ICloudPageBlobObjectFactory blobObjectFactory, bool overWrite)
        {
            this.localVhd = localVhd;
            this.blobObjectFactory = blobObjectFactory;
            this.destination = new Uri(blobDestination.BlobPath);
            this.blobDestination = blobDestination;
            this.overWrite = overWrite;

            this.destinationBlob = blobObjectFactory.Create(blobDestination);
            this.requestOptions = this.blobObjectFactory.CreateRequestOptions();
        }

        private LocalMetaData operationMetaData;

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

        private static void AssertIfValidVhdSize(FileInfo fileInfo)
        {
            using (var stream = new VirtualDiskStream(fileInfo.FullName))
            {
                if (stream.Length > OneTeraByte)
                {
                    var lengthString = stream.Length.ToString("N0", CultureInfo.CurrentCulture);
                    var expectedLengthString = OneTeraByte.ToString("N0", CultureInfo.CurrentCulture);
                    string message = String.Format("VHD size is too large ('{0}'), maximum allowed size is '{1}'.", lengthString, expectedLengthString);
                    throw new InvalidOperationException(message);
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Need to keep UploadContext till the end of upload")]
        public UploadContext Create()
        {
            AssertIfValidhVhd(localVhd);
            AssertIfValidVhdSize(localVhd);

            this.blobObjectFactory.CreateContainer(blobDestination);

            UploadContext context = null;
            bool completed = false;
            try
            {
                context = new UploadContext
                {
                    DestinationBlob = destinationBlob,
                    SingleInstanceMutex = AcquireSingleInstanceMutex(destinationBlob.Uri)
                };

                if (overWrite)
                {
                    destinationBlob.DeleteIfExists(DeleteSnapshotsOption.IncludeSnapshots, null, requestOptions);
                }

                if (destinationBlob.Exists(requestOptions))
                {
                    Program.SyncOutput.MessageResumingUpload();

                    if (destinationBlob.GetBlobMd5Hash(requestOptions) != null)
                    {
                        throw new InvalidOperationException(
                            "An image already exists in blob storage with this name. If you want to upload again, use the Overwrite option.");
                    }
                    var metaData = destinationBlob.GetUploadMetaData();

                    AssertMetaDataExists(metaData);
                    AssertMetaDataMatch(metaData, OperationMetaData);

                    PopulateContextWithUploadableRanges(localVhd, context, true);
                    PopulateContextWithDataToUpload(localVhd, context);
                }
                else
                {
                    CreateRemoteBlobAndPopulateContext(context);
                }
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

        public static void AssertIfValidhVhd(FileInfo vhdFile)
        {
            var vhdValidationResults = VhdValidator.Validate(VhdValidationType.IsVhd, vhdFile.FullName);
            if (vhdValidationResults.Count(r => r.ErrorCode != 0) != 0)
            {
                string message = String.Format("'{0}' is not a valid VHD file.", vhdFile.FullName);
                throw new InvalidOperationException(message, vhdValidationResults[0].Error);
            }
        }

        protected abstract void CreateRemoteBlobAndPopulateContext(UploadContext context);

        protected static void PopulateContextWithUploadableRanges(FileInfo vhdFile, UploadContext context, bool resume)
        {
            using (var vds = new VirtualDiskStream(vhdFile.FullName))
            {
                IEnumerable<IndexRange> ranges = vds.Extents.Select(e => e.Range).ToArray();

                var bs = new BufferedStream(vds);
                if (resume)
                {
                    var alreadyUploadedRanges = context.DestinationBlob.GetPageRanges().Select(pr => new IndexRange(pr.StartOffset, pr.EndOffset));
                    ranges = IndexRange.SubstractRanges(ranges, alreadyUploadedRanges);
                    context.AlreadyUploadedDataSize = alreadyUploadedRanges.Sum(ir => ir.Length);
                }
                var uploadableRanges = IndexRangeHelper.ChunkRangesBySize(ranges, PageSizeInBytes).ToArray();
                if (vds.DiskType == DiskType.Fixed)
                {
                    var nonEmptyUploadableRanges = GetNonEmptyRanges(bs, uploadableRanges).ToArray();
                    context.UploadableDataSize = nonEmptyUploadableRanges.Sum(r => r.Length);
                    context.UploadableRanges = nonEmptyUploadableRanges;
                }
                else
                {
                    context.UploadableDataSize = uploadableRanges.Sum(r => r.Length);
                    context.UploadableRanges = uploadableRanges;
                }
            }
        }

        protected static void PopulateContextWithDataToUpload(FileInfo vhdFile, UploadContext context)
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

        protected static IEnumerable<DataWithRange> GetDataWithRangesToUpload(FileInfo vhdFile, UploadContext context)
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

            for (int bytesRead = stream.Read(buffer, 0, bufferSize);
                 bytesRead < bufferSize;
                 bytesRead += stream.Read(buffer, bytesRead, bufferSize - bytesRead))
            {
            }
            return buffer;
        }


        private static void AssertMetaDataExists(LocalMetaData blobMetaData)
        {
            if (blobMetaData == null)
            {
                throw new InvalidOperationException("There is no CsUpload metadata on the blob, so CsUpload cannot resume. Use the overwrite option.");
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

        private static void AssertMetaDataMatch(LocalMetaData blobMetaData, LocalMetaData localMetaData)
        {
            var systemInformation = blobMetaData.SystemInformation;

            if (String.Compare(systemInformation.MachineName, Environment.MachineName, CultureInfo.InvariantCulture, CompareOptions.IgnoreCase) != 0)
            {
                var message = String.Format("An upload is already in progress on machine {0} with process id {1}",
                                            systemInformation.MachineName,
                                            systemInformation.CsUploadProcessId);

                throw new InvalidOperationException(message);
            }

            var fileMetaDataMessages = CompareFileMetaData(blobMetaData.FileMetaData, localMetaData.FileMetaData);

            if (fileMetaDataMessages.Count > 0)
            {
                throw new InvalidOperationException(fileMetaDataMessages.Aggregate((r, n) => r + Environment.NewLine + n));
            }
        }

        private static List<string> CompareFileMetaData(FileMetaData blobFileMetaData, FileMetaData localFileMetaData)
        {
            var fileMetaDataMessages = new List<string>();
            if (blobFileMetaData.VhdSize != localFileMetaData.VhdSize)
            {
                var message = String.Format("Logical size of VHD file in blob storage ({0}) and local VHD file ({1}) does not match ",
                                            blobFileMetaData.VhdSize,
                                            localFileMetaData.VhdSize);
                fileMetaDataMessages.Add(message);
            }

            if (blobFileMetaData.Size != localFileMetaData.Size)
            {
                var message = String.Format("Size of VHD file in blob storage ({0}) and local VHD file ({1}) does not match ",
                                            blobFileMetaData.Size,
                                            localFileMetaData.Size);
                fileMetaDataMessages.Add(message);
            }

            if (!blobFileMetaData.MD5Hash.SequenceEqual(localFileMetaData.MD5Hash))
            {
                var message = String.Format("MD5 hash of VHD file in blob storage ({0}) and local VHD file ({1}) does not match ",
                                            blobFileMetaData.MD5Hash.ToString(","),
                                            localFileMetaData.MD5Hash.ToString(","));
                fileMetaDataMessages.Add(message);
            }


            if (DateTime.Compare(blobFileMetaData.LastModifiedDateUtc, localFileMetaData.LastModifiedDateUtc) != 0)
            {
                var message = String.Format("Last modified date of VHD file in blob storage ({0}) and local VHD file ({1}) does not match ",
                                            blobFileMetaData.LastModifiedDateUtc,
                                            localFileMetaData.LastModifiedDateUtc);
                fileMetaDataMessages.Add(message);
            }

            if (blobFileMetaData.FileFullName != localFileMetaData.FileFullName)
            {
                var message = String.Format("Full name of VHD file in blob storage ({0}) and local VHD file ({1}) does not match ",
                                            blobFileMetaData.FileFullName,
                                            localFileMetaData.FileFullName);
                fileMetaDataMessages.Add(message);
            }

            if (blobFileMetaData.CreatedDateUtc != localFileMetaData.CreatedDateUtc)
            {
                var message = String.Format("Full name of VHD file in blob storage ({0}) and local VHD file ({1}) does not match ",
                                            blobFileMetaData.CreatedDateUtc,
                                            localFileMetaData.CreatedDateUtc);
                fileMetaDataMessages.Add(message);
            }
            return fileMetaDataMessages;
        }
    }
}