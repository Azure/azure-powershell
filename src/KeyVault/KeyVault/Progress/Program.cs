using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Progress
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
        void ProgressOperationStatus(ProgressRecord record);
        void ProgressOperationStatus(double percentComplete, double avgThroughputMbps, TimeSpan remainingTime);
        void ProgressOperationComplete(TimeSpan elapsed);

        void MessageCalculatingMD5Hash(string filePath);
        void MessageMD5HashCalculationFinished();

        void MessageRetryingAfterANetworkDisruption();
        void DebugRetryingAfterException(Exception lastException);
        // void ProgressHyperV(ushort percentComplete, string message);
        void WriteVerboseWithTimestamp(string message, params object[] args);
    }
}
