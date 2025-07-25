using Azure.Storage.Files.Shares.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    // Wrapper of Microsoft.Azure.Storage.File.CopyState
    // Since file cmdlet migrate to Track2, to avoid breaking, parse Track2 ShareFileProperties to PSCopyState, which has same child properties as Track1 CopyState
    internal class PSCopyState
    {
        public string CopyId { get; internal set; }
        public DateTimeOffset? CompletionTime { get; internal set; }

        public PSCopyStatus Status { get; internal set; }

        public Uri Source { get; internal set; }

        public long? BytesCopied { get; internal set; }


        public long? TotalBytes { get; internal set; }

        public string StatusDescription { get; internal set; }

        public DateTimeOffset? DestinationSnapshotTime { get; internal set; }

        public PSCopyState(ShareFileProperties fileProperties)
        {
            CopyId = fileProperties.CopyId;
            CompletionTime = fileProperties.CopyCompletedOn;
            Status = GetPSCopyStatus(fileProperties.CopyStatus);
            Source = new Uri(fileProperties.CopySource);
            if (!string.IsNullOrEmpty(fileProperties.CopyProgress))
            {
                BytesCopied = Convert.ToInt64(fileProperties.CopyProgress.Split(new char[] { '/' })[0]);
                TotalBytes = Convert.ToInt64(fileProperties.CopyProgress.Split(new char[] { '/' })[1]);
            }
            StatusDescription = fileProperties.CopyStatusDescription;
            DestinationSnapshotTime = null; // This is in Track1 SDK, only for blob incremental copy. Track2 File SDK not has this value. 

        }

        static private PSCopyStatus GetPSCopyStatus(CopyStatus copystatus)
        {
            switch(copystatus)
            {
                case CopyStatus.Pending:
                    return PSCopyStatus.Pending;
                case CopyStatus.Success:
                    return PSCopyStatus.Success;
                case CopyStatus.Aborted:
                    return PSCopyStatus.Aborted;
                case CopyStatus.Failed:
                    return PSCopyStatus.Failed;
                default:
                    return PSCopyStatus.Invalid;

            }
        }

    }


    // Wrapper of Microsoft.Azure.Storage.File.CopyStatus
    // Since file cmdlet migrate to Track2, to avoid breaking, parse Track2 ShareFileProperties to PSCopyStatus, which has same value as Track1 CopyStatus
    public enum PSCopyStatus
    {
        Invalid,
        Pending,
        Success,
        Aborted,
        Failed
    }
}
