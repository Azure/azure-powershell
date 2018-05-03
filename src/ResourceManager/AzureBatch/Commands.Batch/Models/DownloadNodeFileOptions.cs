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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class DownloadNodeFileOptions : NodeFileOperationParameters
    {
        public class ByteRange
        {
            public ByteRange(long start, long end)
            {
                this.Start = start;
                this.End = end;
            }

            public long Start { get; }
            public long End { get; }
        }

        public DownloadNodeFileOptions(
            BatchAccountContext context,
            string jobId,
            string taskId,
            string poolId,
            string computeNodeId,
            string path,
            PSNodeFile nodeFile,
            string destinationPath,
            Stream stream,
            ByteRange byteRange,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
            : base(context, jobId, taskId, poolId, computeNodeId, path, nodeFile, additionalBehaviors)
        {
            if (string.IsNullOrWhiteSpace(destinationPath) && stream == null)
            {
                throw new ArgumentNullException(Resources.NoDownloadDestination);
            }

            this.DestinationPath = destinationPath;
            this.Range = byteRange;
            this.Stream = stream;
        }

        /// <summary>
        /// The path to the directory where the node file will be downloaded
        /// </summary>
        public string DestinationPath { get; set; }

        /// <summary>
        /// The byte range to be downloaded.
        /// </summary>
        public ByteRange Range { get; }

        /// <summary>
        /// The Stream into which the node file data will be written. This stream will not be closed or rewound by this call.
        /// </summary>
        internal Stream Stream { get; set; }
    }
}
