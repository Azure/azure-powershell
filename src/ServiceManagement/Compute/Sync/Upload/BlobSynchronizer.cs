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
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Microsoft.WindowsAzure.Commands.Sync.Upload
{
    public class BlobSynchronizer
    {
        private readonly UploadContext context;
        private byte[] md5Hash;
        private readonly IEnumerable<DataWithRange> dataWithRanges;
        private readonly int maxParallelism;
        private readonly long dataToUpload;
        private readonly long alreadyUploadedData;
        private CloudPageBlob blob;

        public BlobSynchronizer(UploadContext context, int maxParallelism)
        {
            this.context = context;
            this.md5Hash = context.Md5HashOfLocalVhd;
            this.dataWithRanges = context.UploadableDataWithRanges;
            this.dataToUpload = context.UploadableDataSize;
            this.alreadyUploadedData = context.AlreadyUploadedDataSize;
            this.blob = context.DestinationBlob;
            this.maxParallelism = maxParallelism;
        }

        public bool Synchronize()
        {
            var uploadStatus = new ProgressStatus(alreadyUploadedData, alreadyUploadedData + dataToUpload, new ComputeStats());

            using (new ServicePointHandler(blob.Uri, this.maxParallelism))
            using (new ProgressTracker(uploadStatus))
            {
                var loopResult = Parallel.ForEach(dataWithRanges,
                                                  () => new CloudPageBlob(blob.Uri, blob.ServiceClient.Credentials),
                                                  (dwr, b) =>
                                                      {
                                                          using (dwr)
                                                          {
                                                              var md5HashOfDataChunk = GetBase64EncodedMd5Hash(dwr.Data, (int)dwr.Range.Length);
                                                              using (var stream = new MemoryStream(dwr.Data, 0, (int)dwr.Range.Length))
                                                              {
                                                                  b.Properties.ContentMD5 = md5HashOfDataChunk;
                                                                  b.WritePages(stream, dwr.Range.StartIndex);
                                                              }
                                                          }
                                                          uploadStatus.AddToProcessedBytes((int)dwr.Range.Length);
                                                      }, this.maxParallelism);
                if (loopResult.IsExceptional)
                {
                    if (loopResult.Exceptions.Any())
                    {
                        Program.SyncOutput.ErrorUploadFailedWithExceptions(loopResult.Exceptions);

                        throw new AggregateException(loopResult.Exceptions);
                    }
                }
                else
                {
                    using (var bdms = new BlobMetaDataScope(new CloudPageBlob(blob.Uri, blob.ServiceClient.Credentials)))
                    {
                        bdms.Current.SetBlobMd5Hash(md5Hash);
                        bdms.Current.CleanUpUploadMetaData();
                        bdms.Complete();
                    }
                }
            }
            return true;
        }

        private static string GetBase64EncodedMd5Hash(byte[] data, int length)
        {
            using (var hash = MD5.Create())
            {
                hash.TransformBlock(data, 0, length, null, 0);
                hash.TransformFinalBlock(new byte[0], 0, 0);
                var bytes = hash.Hash;
                return Convert.ToBase64String(bytes);
            }
        }
    }
}