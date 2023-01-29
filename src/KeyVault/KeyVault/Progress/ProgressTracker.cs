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

using System.Diagnostics;
using System;

namespace Microsoft.Azure.Commands.KeyVault.Progress
{
    public class ProgressTracker
    {
        private readonly ProgressStatus progressStatus;
        private readonly Action<ProgressRecord, string> progressAction;
        private readonly Action<TimeSpan> completionAction;
        public int speed;
        private Stopwatch stopWatch;

        public ProgressTracker(ProgressStatus progressStatus, Action<ProgressRecord, string> progressAction, Action<TimeSpan> completionAction, int speed = 5)
        {
            this.progressStatus = progressStatus;
            this.progressAction = progressAction;
            this.completionAction = completionAction;
            this.speed = speed;
            this.stopWatch = Stopwatch.StartNew();
        }

        public void Update(string actionName)
        {
            ProgressRecord progressRecord;
            progressStatus.AddToProcessedBytes(speed);
            if (progressStatus.TryGetProgressRecord(out progressRecord))
            {
                this.progressAction(progressRecord, actionName);
            }
        }
    }
}