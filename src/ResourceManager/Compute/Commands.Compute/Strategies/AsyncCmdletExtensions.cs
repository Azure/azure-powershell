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

using Microsoft.Azure.Commands.Common.Strategies;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    static class AsyncCmdletExtensions
    {
        /// <summary>
        /// Note: the function must be called in the main PowerShell thread.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="createAndStartTask"></param>
        public static void StartAndWait(
            this Cmdlet cmdlet, Func<IAsyncCmdlet, Task> createAndStartTask)
            => new AsyncCmdlet(cmdlet).StartAndWait(createAndStartTask);

        sealed class AsyncCmdlet : IAsyncCmdlet
        {
            public SyncTaskScheduler Scheduler { get; } = new SyncTaskScheduler();

            readonly Cmdlet _Cmdlet;

            public List<ITaskProgress> TaskProgressList { get; } 
                = new List<ITaskProgress>();

            IEnumerable<ITaskProgress> IAsyncCmdlet.TaskProgressList
                => TaskProgressList;

            public AsyncCmdlet(Cmdlet cmdlet)
            {
                _Cmdlet = cmdlet;
            }

            public void WriteVerbose(string message)
                => Scheduler.BeginInvoke(() => _Cmdlet.WriteVerbose(message));

            public Task<bool> ShouldProcessAsync(string target, string action)
                => Scheduler.Invoke(() => _Cmdlet.ShouldProcess(target, action));

            public void WriteObject(object value)
                => Scheduler.BeginInvoke(() => _Cmdlet.WriteObject(value));

            public void ReportTaskProgress(ITaskProgress taskProgress)
                => Scheduler.BeginInvoke(() => TaskProgressList.Add(taskProgress));

            public void WriteProgress(
                string activity, string statusDescription, string currentOperation, int percentComplete)
                => _Cmdlet.WriteProgress(
                    new ProgressRecord(
                        0,
                        activity,
                        statusDescription)
                    {
                        CurrentOperation = currentOperation,
                        PercentComplete = percentComplete,
                    });
        }
    }
}