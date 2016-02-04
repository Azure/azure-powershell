using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.DataMovement;

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
