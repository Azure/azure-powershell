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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.DataMovement;
using Microsoft.WindowsAzure.Storage.DataMovement.TransferJobs;

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    internal sealed class DataManagementWrapper : ITransferJobRunner
    {
        // Powershell could be ran either in 32bit or 64bit
        // The default algorithm to calculate the size may be too much if PSH is ran under 32bit on a 64bit OS with big memory
        private const int Maximum32bitCacheSize = 512 * 1024 * 1024;

        private TransferManager manager;

        public DataManagementWrapper(int concurrency, string clientRequestId)
        {
            TransferOptions options = new TransferOptions()
            {
                ParallelOperations = concurrency,
                ClientRequestIdPrefix = clientRequestId
            };

            if (!Environment.Is64BitProcess && options.MaximumCacheSize > Maximum32bitCacheSize)
            {
                options.MaximumCacheSize = Maximum32bitCacheSize;
            }

            this.manager = new TransferManager(options);
        }

        public Task RunTransferJob(TransferJobBase job, Action<double, double> progressReport, CancellationToken cancellationToken)
        {
            TaskCompletionSource<object> downloadCompletionSource = new TaskCompletionSource<object>();

            job.StartEvent += (sender, eventArgs) =>
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                progressReport(0, 0);
            };

            job.ProgressEvent += (sender, eventArgs) =>
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                progressReport(eventArgs.Progress, eventArgs.Speed);
            };

            job.FinishEvent += (sender, eventArgs) =>
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                if (eventArgs.Exception == null)
                {
                    downloadCompletionSource.SetResult(null);
                }
                else
                {
                    downloadCompletionSource.SetException(eventArgs.Exception);
                }
            };

            this.manager.EnqueueJob(job, cancellationToken);

            return downloadCompletionSource.Task;
        }

        public void Dispose()
        {
            this.manager.Dispose();
            this.manager = null;
        }
    }
}
