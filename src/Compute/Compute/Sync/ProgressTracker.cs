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
using System.Diagnostics;

namespace Microsoft.WindowsAzure.Commands.Sync
{
    public class ProgressTracker : IDisposable
    {
        private readonly ProgressStatus progressStatus;
        private readonly Action<ProgressRecord> progressAction;
        private readonly Action<TimeSpan> completionAction;
        private Stopwatch stopWatch;
        private bool isDisposed;

        public ProgressTracker(ProgressStatus progressStatus) :
            this(progressStatus, Program.SyncOutput.ProgressUploadStatus, Program.SyncOutput.ProgressUploadComplete)
        {
        }

        public ProgressTracker(ProgressStatus progressStatus, Action<ProgressRecord> progressAction, Action<TimeSpan> completionAction)
        {
            this.progressStatus = progressStatus;
            this.progressAction = progressAction;
            this.completionAction = completionAction;
            this.stopWatch = Stopwatch.StartNew();
        }

        public void Update()
        {
            ProgressRecord progressRecord;
            if (progressStatus.TryGetProgressRecord(out progressRecord))
            {
                this.progressAction(progressRecord);
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    stopWatch.Stop();
                    if (stopWatch.Elapsed != TimeSpan.Zero)
                    {
                        this.completionAction(stopWatch.Elapsed);
                    }

                    this.isDisposed = true;
                }
            }
        }
    }
}