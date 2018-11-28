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

using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using System;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.Sync
{
    public class Program
    {
        static public ISyncOutputEvents SyncOutput
        {
            get
            {
                return RawEvents;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                RawEvents = value;
            }
        }
        //        static public IProgramConfiguration Configuration { get; private set; }
        //private static ISyncOutputEvents RawEvents = new SyncOutputEvents();
        private static ISyncOutputEvents RawEvents = null;
    }

    public interface ISyncOutputEvents
    {
        void MessageCreatingNewPageBlob(long pageBlobSize);
        void MessageResumingUpload();
        void ErrorUploadFailedWithExceptions(IList<Exception> exjceptions);


        void ProgressCopyComplete(TimeSpan elapsed);
        void ProgressCopyStatus(double precentComplete, double avgThroughputMbps, TimeSpan remainingTime);
        void ProgressCopyStatus(ProgressRecord record);

        void ProgressUploadStatus(ProgressRecord record);
        void ProgressUploadStatus(double precentComplete, double avgThroughputMbps, TimeSpan remainingTime);
        void ProgressUploadComplete(TimeSpan elapsed);

        void ProgressDownloadStatus(ProgressRecord record);
        void ProgressDownloadStatus(double precentComplete, double avgThroughputMbps, TimeSpan remainingTime);
        void ProgressDownloadComplete(TimeSpan elapsed);

        void ProgressOperationStatus(ProgressRecord record);
        void ProgressOperationStatus(double percentComplete, double avgThroughputMbps, TimeSpan remainingTime);
        void ProgressOperationComplete(TimeSpan elapsed);

        void MessageCalculatingMD5Hash(string filePath);
        void MessageMD5HashCalculationFinished();

        void MessageRetryingAfterANetworkDisruption();
        void DebugRetryingAfterException(Exception lastException);

        void MessageDetectingActualDataBlocks();
        void MessageDetectingActualDataBlocksCompleted();
        void MessagePrintBlockRange(IndexRange range);
        void DebugEmptyBlockDetected(IndexRange range);
        void ProgressEmptyBlockDetection(int processedRangeCount, int totalRangeCount);

        void WriteVerboseWithTimestamp(string message, params object[] args);
    }
}
