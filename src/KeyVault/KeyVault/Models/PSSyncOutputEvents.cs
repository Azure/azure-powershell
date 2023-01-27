using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Progress;
using ProgressRecord = System.Management.Automation.ProgressRecord;
using Rsrc = Microsoft.Azure.Commands.KeyVault.Properties.Resources;

namespace Microsoft.Azure.Commands.KeyVault.Models
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
                return string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            }
            return string.Format(Rsrc.PSSyncOutputEventsFormatDuration, ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
        }


        private void LogProgress(int activityId, string activity, double precentComplete, TimeSpan remainingTime, double avgThroughputMbps)
        {
            
            var message = string.Format("Logging Progress",
                                        precentComplete,
                                        FormatDuration(remainingTime),
                                        avgThroughputMbps);
            
            ProgressRecord progressRecord = new ProgressRecord(activityId, activity, message);
            progressRecord.SecondsRemaining = (int)remainingTime.TotalSeconds;
            progressRecord.PercentComplete = (int)precentComplete < 100 ? (int)precentComplete : 100;

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

        private void LogMessage(string format, params object[] parameters)
        {
            var message = string.Format(format, parameters);
            cmdlet.WriteVerbose(message);
        }

        private void LogError(Exception e)
        {
            ErrorRecord errorRecord = new ErrorRecord(e, string.Empty, ErrorCategory.NotSpecified, null);
            cmdlet.WriteError(errorRecord);
        }


        public void ProgressOperationStatus(Progress.ProgressRecord record)
        {
            ProgressOperationStatus(record.PercentComplete, record.AvgThroughputMbPerSecond, record.RemainingTime);
        }

        public void ProgressOperationStatus(double percentComplete, double avgThroughputMbps, TimeSpan remainingTime)
        {
            LogProgress(1, "Creating KeyVaults", percentComplete, remainingTime, avgThroughputMbps);
        }

        public void ProgressOperationComplete(TimeSpan elapsed)
        {
            LogProgressComplete(1, Rsrc.PSSyncOutputEventsCalculatingMD5Hash);
            LogMessage(Rsrc.PSSyncOutputEventsElapsedTimeForOperation, FormatDuration(elapsed));
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
            /*
            var storageException = lastException as StorageException;
            var message = ExceptionUtil.DumpStorageExceptionErrorDetails(storageException);
            if (message != string.Empty)
            {
                LogDebug(message);
            }
            */
        }

        

        private void LogDebug(string format, params object[] parameters)
        {
            var message = string.Format(format, parameters);
            cmdlet.WriteDebug(message);
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
                disposed = true;
            }
        }
    }
}
