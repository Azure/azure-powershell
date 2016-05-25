using Microsoft.WindowsAzure.Storage.DataMovement;
using System;

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    internal class TransferProgressHandler : IProgress<TransferProgress>
    {
        private Action<TransferProgress> progressHandler;

        public TransferProgressHandler(Action<TransferProgress> progressHandler)
        {
            this.progressHandler = progressHandler;
        }

        public void Report(TransferProgress value)
        {
            this.progressHandler(value);
        }
    }
}
