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

using Microsoft.WindowsAzure.Commands.Sync;
using Microsoft.WindowsAzure.Commands.Sync.Upload;
using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using ProgressRecord = System.Management.Automation.ProgressRecord;
using Rsrc = Microsoft.Azure.Commands.Compute.Properties.Resources;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSSyncOutputEvents : ISyncOutputEvents, IDisposable
    {
        private readonly PSCmdlet cmdlet;
        private bool disposed;

        public PSSyncOutputEvents(PSCmdlet cmdlet)
        {
            this.cmdlet = cmdlet;
        }

        private static string FormatDuration(TimeSpan ts)
        {
            if (ts.Days == 0)
            {
                return String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            }
            return String.Format(Rsrc.PSSyncOutputEventsFormatDuration, ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
        }

        public void ProgressCopyStatus(WindowsAzure.Commands.Sync.ProgressRecord record)
        {
            ProgressCopyStatus(record.PercentComplete, record.AvgThroughputMbPerSecond, record.RemainingTime);
        }

        public void ProgressCopyStatus(double precentComplete, double avgThroughputMbps, TimeSpan remainingTime)
        {
            LogProgress(0, Rsrc.PSSyncOutputEventsCopying, precentComplete, remainingTime, avgThroughputMbps);
        }

        public void ProgressCopyComplete(TimeSpan elapsed)
        {
            LogProgressComplete(0, Rsrc.PSSyncOutputEventsCopying);
            LogMessage(Rsrc.PSSyncOutputEventsElapsedTimeForCopy, FormatDuration(elapsed));
        }

        public void ProgressUploadStatus(WindowsAzure.Commands.Sync.ProgressRecord record)
        {
            ProgressUploadStatus(record.PercentComplete, record.AvgThroughputMbPerSecond, record.RemainingTime);
        }

        public void ProgressUploadStatus(double precentComplete, double avgThroughputMbps, TimeSpan remainingTime)
        {
            LogProgress(0, Rsrc.PSSyncOutputEventsUploading, precentComplete, remainingTime, avgThroughputMbps);
        }

        private void LogProgress(int activityId, string activity, double precentComplete, TimeSpan remainingTime, double avgThroughputMbps)
        {
            var message = String.Format(Rsrc.PSSyncOutputEventsLogProgress,
                                        precentComplete,
                                        FormatDuration(remainingTime),
                                        avgThroughputMbps);
            ProgressRecord progressRecord = new ProgressRecord(activityId, activity, message);
            progressRecord.SecondsRemaining = (int)remainingTime.TotalSeconds;
            progressRecord.PercentComplete = (int)precentComplete;

            cmdlet.WriteProgress(progressRecord);
        }

        private void LogProgressComplete(int activityId, string activity)
        {
            ProgressRecord progressRecord = new ProgressRecord(activityId,
                                                               activity,
                                                               Rsrc.PSSyncOutputEventsLogProgressCompleteCompleted);
            progressRecord.RecordType = ProgressRecordType.Completed;

            cmdlet.WriteProgress(progressRecord);
        }

        public void MessageCreatingNewPageBlob(long pageBlobSize)
        {
            LogMessage(Rsrc.PSSyncOutputEventsCreatingNewPageBlob, pageBlobSize);
        }

        private void LogMessage(string format, params object[] parameters)
        {
            var message = String.Format(format, parameters);
            cmdlet.WriteVerbose(message);
        }

        private void LogError(Exception e)
        {
            ErrorRecord errorRecord = new ErrorRecord(e, String.Empty, ErrorCategory.NotSpecified, null);
            cmdlet.WriteError(errorRecord);
        }

        public void MessageResumingUpload()
        {
            LogMessage(Rsrc.PSSyncOutputEventsResumingUpload);
        }

        public void ProgressUploadComplete(TimeSpan elapsed)
        {
            LogProgressComplete(0, Rsrc.PSSyncOutputEventsUploading);
            LogMessage(Rsrc.PSSyncOutputEventsElapsedTimeForUpload, FormatDuration(elapsed));
        }

        public void ProgressDownloadStatus(WindowsAzure.Commands.Sync.ProgressRecord record)
        {
            ProgressDownloadStatus(record.PercentComplete, record.AvgThroughputMbPerSecond, record.RemainingTime);
        }

        public void ProgressDownloadStatus(double precentComplete, double avgThroughputMbps, TimeSpan remainingTime)
        {
            LogProgress(0, Rsrc.PSSyncOutputEventsDownloading, precentComplete, remainingTime, avgThroughputMbps);
        }

        public void ProgressDownloadComplete(TimeSpan elapsed)
        {
            LogProgressComplete(0, Rsrc.PSSyncOutputEventsDownloading);
            LogMessage(Rsrc.PSSyncOutputEventsElapsedTimeForDownload, FormatDuration(elapsed));
        }

        public void ProgressOperationStatus(WindowsAzure.Commands.Sync.ProgressRecord record)
        {
            ProgressOperationStatus(record.PercentComplete, record.AvgThroughputMbPerSecond, record.RemainingTime);
        }

        public void ProgressOperationStatus(double percentComplete, double avgThroughputMbps, TimeSpan remainingTime)
        {
            LogProgress(1, Rsrc.PSSyncOutputEventsCalculatingMD5Hash, percentComplete, remainingTime, avgThroughputMbps);
        }

        public void ProgressOperationComplete(TimeSpan elapsed)
        {
            LogProgressComplete(1, Rsrc.PSSyncOutputEventsCalculatingMD5Hash);
            LogMessage(Rsrc.PSSyncOutputEventsElapsedTimeForOperation, FormatDuration(elapsed));
        }


        public void ErrorUploadFailedWithExceptions(IList<Exception> exceptions)
        {
            LogMessage(Rsrc.PSSyncOutputEventsUploadFailedWithException);
            foreach (var exception in exceptions)
            {
                LogError(exception);
            }
        }

        public void MessageCalculatingMD5Hash(string filePath)
        {
            LogMessage(Rsrc.PSSyncOutputEventsCalculatingMD5HashForFile, filePath);
        }

        public void MessageMD5HashCalculationFinished()
        {
            LogMessage(Rsrc.PSSyncOutputEventsMD5HashCalculationFinished);
        }

        public void MessageRetryingAfterANetworkDisruption()
        {
            LogMessage(Rsrc.PSSyncOutputEventsRetryingAfterANetworkDisruption);
        }

        public void DebugRetryingAfterException(Exception lastException)
        {
            LogDebug(lastException.ToString());

            var storageException = lastException as StorageException;
            var message = ExceptionUtil.DumpStorageExceptionErrorDetails(storageException);
            if (message != String.Empty)
            {
                LogDebug(message);
            }
        }

        public void MessageDetectingActualDataBlocks()
        {
            LogMessage(Rsrc.PSSyncOutputEventsDetectingActualDataBlocks);
        }

        public void MessageDetectingActualDataBlocksCompleted()
        {
            LogMessage(Rsrc.PSSyncOutputEventsDetectingActualDataBlocksCompleted);
        }

        public void MessagePrintBlockRange(IndexRange range)
        {
            LogMessage(Rsrc.PSSyncOutputEventsPrintBlockRange, range, range.Length);
        }

        public void DebugEmptyBlockDetected(IndexRange range)
        {
            LogDebug(Rsrc.PSSyncOutputEventsEmptyBlockDetected, range.ToString());
        }

        private void LogDebug(string format, params object[] parameters)
        {
            var message = String.Format(format, parameters);
            cmdlet.WriteDebug(message);
        }

        public void ProgressEmptyBlockDetection(int processedRangeCount, int totalRangeCount)
        {
            ProgressRecord progressRecord = new ProgressRecord(2,
                                                               Rsrc.PSSyncOutputEventsProgressEmptyBlockDetection,
                                                               Rsrc.PSSyncOutputEventsEmptyBlockDetectionDetecting);

            if (processedRangeCount >= totalRangeCount)
            {
                progressRecord.RecordType = ProgressRecordType.Completed;
                progressRecord.StatusDescription = Rsrc.PSSyncOutputEventsEmptyBlockDetectionCompleted;
            }
            else
            {
                progressRecord.PercentComplete = (int)((double)processedRangeCount / totalRangeCount * 100);
            }

            cmdlet.WriteProgress(progressRecord);
        }

        public void ProgressCopy(double percentageDone)
        {
            var status = String.Format("{0}% Complete", (int)percentageDone);
            ProgressRecord progressRecord = new ProgressRecord(0,
                                                               "Making a copy of the VHD file before resizing",
                                                               status);

            if (percentageDone >= 100.0)
            {
                progressRecord.RecordType = ProgressRecordType.Completed;
                progressRecord.StatusDescription = "100% Complete";
            }
            else
            {
                progressRecord.PercentComplete = (int)percentageDone;
            }

            cmdlet.WriteProgress(progressRecord);
        }

        public void ProgressHyperV(ushort percentComplete, string message)
        {
            var status = String.Format("{0}% Complete", percentComplete);
            ProgressRecord progressRecord = new ProgressRecord(0, message, status);

            if (percentComplete >= 100)
            {
                progressRecord.RecordType = ProgressRecordType.Completed;
                progressRecord.StatusDescription = "100% Complete";
            }
            else
            {
                progressRecord.PercentComplete = percentComplete;
            }

            cmdlet.WriteProgress(progressRecord);
        }

        public void WriteVerboseWithTimestamp(string message, params object[] args)
        {
            var messageWithTimeStamp = string.Format(CultureInfo.CurrentCulture, "{0:T} - {1}", DateTime.Now, string.Format(message, args));
            cmdlet.WriteVerbose(messageWithTimeStamp);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                this.disposed = true;
            }
        }
    }
}
