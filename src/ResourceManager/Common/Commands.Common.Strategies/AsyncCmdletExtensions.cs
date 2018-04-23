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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class AsyncCmdletExtensions
    {
        /// <summary>
        /// WriteVerbose function with formatting.
        /// </summary>
        /// <param name="cmdlet">Cmdlet</param>
        /// <param name="message">message with formatting</param>
        /// <param name="p">message parameters</param>
        public static void WriteVerbose(this IAsyncCmdlet cmdlet, string message, params object[] p)
            => cmdlet.WriteVerbose(string.Format(message, p));

        /// <summary>
        /// The function read current Azure state and update it according to the `parameters`.
        /// </summary>
        /// <typeparam name="TModel">A resource model type.</typeparam>
        /// <param name="client">Azure SDK client.</param>
        /// <param name="subscriptionId">Subbscription Id.</param>
        /// <param name="parameters">Cmdlet parameters.</param>
        /// <param name="asyncCmdlet">Asynchronous cmdlet interface.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        public static async Task<TModel> RunAsync<TModel>(
            this IClient client,
            string subscriptionId,
            IParameters<TModel> parameters,
            IAsyncCmdlet asyncCmdlet)
            where TModel : class
        {
            // create a DAG of configs.
            var config = await parameters.CreateConfigAsync();
            // read current Azure state.
            var current = await config.GetStateAsync(client, asyncCmdlet.CancellationToken);
            // update location.
            parameters.Location =
                parameters.Location ?? current.GetLocation(config) ?? parameters.DefaultLocation;
            // update a DAG of configs.
            config = await parameters.CreateConfigAsync();
            // create a target.
            var target = config.GetTargetState(
                current, new SdkEngine(subscriptionId), parameters.Location);
            // print paramaters to a verbose stream.
            foreach (var p in asyncCmdlet.Parameters)
            {
                asyncCmdlet.WriteVerbose(p.Key + " = " + ToPowerShellString(p.Value));
            }

            // apply the target state
            var newState = await config.UpdateStateAsync(
                client,
                target,
                asyncCmdlet.CancellationToken,
                new ShouldProcess(asyncCmdlet),
                asyncCmdlet.ReportTaskProgress);
            // return a resource model
            return newState.Get(config) ?? current.Get(config);
        }

        static string ToPowerShellString(object value)
        {
            if (value == null)
            {
                return "$null";
            }

            var s = value as string;
            if (s != null)
            {
                return "\"" + s + "\"";
            }

            var e = value as IEnumerable;
            if (e != null)
            {
                return string.Join(",", e.Cast<object>().Select(ToPowerShellString));
            }

            return value.ToString();
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
        public static void CmdletStartAndWait(
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

            public IEnumerable<KeyValuePair<string, object>> Parameters
                => Cmdlet.Parameters;

            public CancellationToken CancellationToken { get; }
                = new CancellationToken();

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