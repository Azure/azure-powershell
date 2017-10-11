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
using System.Collections.Generic;
using System.Threading;
using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.WindowsAzure.Commands.Sync.Upload
{
    public class UploadContext : IDisposable
    {
        private bool disposed;

        public CloudPageBlob DestinationBlob { get; set; }

        public IEnumerable<DataWithRange> UploadableDataWithRanges { get; set; }

        public IEnumerable<IndexRange> UploadableRanges { get; set; }

        public long UploadableDataSize { get; set; }

        public long AlreadyUploadedDataSize { get; set; }

        public byte[] Md5HashOfLocalVhd { get; set; }

        public Mutex SingleInstanceMutex { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if(disposing)
            {
                if (SingleInstanceMutex != null)
                {
                    SingleInstanceMutex.ReleaseMutex();
                    SingleInstanceMutex.Close();
                }

                disposed = true;
            }
        }
    }
}