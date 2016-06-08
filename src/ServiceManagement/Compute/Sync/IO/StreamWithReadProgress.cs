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

namespace Microsoft.WindowsAzure.Commands.Sync.IO
{
    internal class StreamWithReadProgress : Stream
    {
        private readonly Stream innerStream;
        private readonly TimeSpan progressInterval;
        private ProgressStatus readStatus;
        private ProgressTracker progressTracker;

        public StreamWithReadProgress(Stream innerStream, TimeSpan progressInterval)
        {
            this.innerStream = innerStream;
            this.progressInterval = progressInterval;
            this.readStatus = new ProgressStatus(0, this.innerStream.Length, new ComputeStats());

            this.progressTracker = new ProgressTracker(this.readStatus,
                Program.SyncOutput.ProgressOperationStatus,
                Program.SyncOutput.ProgressOperationComplete,
                this.progressInterval);
        }

        public override void Flush()
        {
            this.innerStream.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.innerStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            this.innerStream.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var readCount = this.innerStream.Read(buffer, offset, count);
            readStatus.AddToProcessedBytes(readCount);
            return readCount;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.innerStream.Write(buffer, offset, count);
        }

        public override bool CanRead
        {
            get { return this.innerStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return this.innerStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return this.innerStream.CanWrite; }
        }

        public override long Length
        {
            get { return this.innerStream.Length; }
        }

        public override long Position
        {
            get { return this.innerStream.Position; }
            set { this.innerStream.Position = value; }
        }

        public override void Close()
        {
            this.progressTracker.Dispose();
            this.innerStream.Close();
        }

        protected override void Dispose(bool disposing)
        {
            this.progressTracker.Dispose();
            this.innerStream.Dispose();
        }
    }
}