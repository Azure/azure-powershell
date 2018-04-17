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
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class AsyncCmdletExtensions
    {
        public static void WriteVerbose(this IAsyncCmdlet cmdlet, string message, params object[] p)
            => cmdlet.WriteVerbose(string.Format(message, p));

        public static string UpdateLocation(
            this IState current, string location, IResourceConfig config)
            => location ?? current.GetLocation(config) ?? "eastus";

        public static async Task<TModel> RunAsync<TModel>(
            this IClient client,
            string subscriptionId,
            IParameters<TModel> parameters,
            IAsyncCmdlet asyncCmdlet,
            CancellationToken cancellationToken)
            where TModel : class
        {
            // create a DAG of configs.
            var config = await parameters.CreateConfigAsync();

            // reade current Azure state.
            var current = await config.GetStateAsync(client, cancellationToken);

            // update location.
            parameters.Location = current.UpdateLocation(parameters.Location, config);

            // update a DAG of configs.
            config = await parameters.CreateConfigAsync();

            var engine = new SdkEngine(subscriptionId);
            var target = config.GetTargetState(current, engine, parameters.Location);

            // apply target state
            var newState = await config.UpdateStateAsync(
                client,
                target,
                cancellationToken,
                new ShouldProcess(asyncCmdlet),
                asyncCmdlet.ReportTaskProgress);

            return newState.Get(config) ?? current.Get(config);
        }

        sealed class ShouldProcess : IShouldProcess
        {
            readonly IAsyncCmdlet _Cmdlet;

            public ShouldProcess(IAsyncCmdlet cmdlet)
            {
                _Cmdlet = cmdlet;
            }

            public Task<bool> ShouldCreate<TModel>(ResourceConfig<TModel> config, TModel model)
                where TModel : class
                => _Cmdlet.ShouldProcessAsync(config.GetFullName(), _Cmdlet.VerbsNew);
        }

        /// <summary>
        /// Note: the function must be called in the main PowerShell thread.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="createAndStartTask"></param>
        public static void StartAndWait(
            this ICmdlet cmdlet, Func<IAsyncCmdlet, Task> createAndStartTask)
        {
            var asyncCmdlet = new AsyncCmdlet(cmdlet);
            string previousX = null;
            string previousOperation = null;
            asyncCmdlet.Scheduler.Wait(
                createAndStartTask(asyncCmdlet),
                () =>
                {
                    if (asyncCmdlet.TaskProgressList.Any())
                    {
                        var progress = 0.0;
                        var activeTasks = new List<string>();
                        foreach (var taskProgress in asyncCmdlet.TaskProgressList)
                        {
                            if (!taskProgress.IsDone)
                            {
                                var config = taskProgress.Config;
                                activeTasks.Add(config.GetFullName());
                            }
                            progress += taskProgress.GetProgress();
                        }
                        var percent = (int)(progress * 100.0);
                        var r = new[] { "|", "/", "-", "\\" };
                        var x = r[DateTime.Now.Second % 4];
                        var operation = activeTasks.Count > 0
                            ? "Creating " + string.Join(", ", activeTasks) + "."
                            : null;

                        // write progress only if it's changed.
                        if (x != previousX || operation != previousOperation)
                        {
                            asyncCmdlet.Cmdlet.WriteProgress(
                                activity: "Creating Azure resources",
                                statusDescription: percent + "% " + x,
                                currentOperation: operation,
                                percentComplete: percent);
                            previousX = x;
                            previousOperation = operation;
                        }
                    }
                });
        }

        sealed class AsyncCmdlet : IAsyncCmdlet
        {
            public SyncTaskScheduler Scheduler { get; } = new SyncTaskScheduler();

            public ICmdlet Cmdlet { get; }

            public List<ITaskProgress> TaskProgressList { get; }
                = new List<ITaskProgress>();

            public string VerbsNew => Cmdlet.VerbsNew;

            public AsyncCmdlet(ICmdlet cmdlet)
            {
                Cmdlet = cmdlet;
            }

            public void WriteVerbose(string message)
                => Scheduler.BeginInvoke(() => Cmdlet.WriteVerbose(message));

            public Task<bool> ShouldProcessAsync(string target, string action)
                => Scheduler.Invoke(() => Cmdlet.ShouldProcess(target, action));

            public void WriteObject(object value)
                => Scheduler.BeginInvoke(() => Cmdlet.WriteObject(value));

            public void ReportTaskProgress(ITaskProgress taskProgress)
                => Scheduler.BeginInvoke(() => TaskProgressList.Add(taskProgress));
        }
    }
}