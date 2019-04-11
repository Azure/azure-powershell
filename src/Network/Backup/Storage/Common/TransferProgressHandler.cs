using Microsoft.WindowsAzure.Storage.DataMovement;
using System;

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    internal class TransferProgressHandler : IProgress<TransferStatus>
    {
        private Action<TransferStatus> progressHandler;

        public TransferProgressHandler(Action<TransferStatus> progressHandler)
        {
            this.progressHandler = progressHandler;
        }

        public void Report(TransferStatus value)
        {
            this.progressHandler(value);
        }
    }
}
