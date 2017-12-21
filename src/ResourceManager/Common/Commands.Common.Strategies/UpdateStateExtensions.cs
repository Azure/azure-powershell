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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class UpdateStateExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="config">A resource config.</param>
        /// <param name="client">Management client.</param>
        /// <param name="target">An Azure target state.</param>
        /// <param name="cancellationToken">A task cancellation token.</param>
        /// <param name="shouldProcess">A should process interface.</param>
        /// <param name="reportTaskProgress">A callback to report task progress.</param>
        /// <returns></returns>
        public static async Task<IState> UpdateStateAsync<TModel>(
            this ResourceConfig<TModel> config,
            IClient client,
            IState target,
            CancellationToken cancellationToken,
            IShouldProcess shouldProcess,
            Action<ITaskProgress> reportTaskProgress)
            where TModel : class
        {
            if (target.Get(config) == null)
            {
                return new State();
            }
            var context = new Context(
                new StateOperationContext(client, cancellationToken),
                target,
                shouldProcess,
                reportTaskProgress,
                config.GetProgressMap(target));
            await context.UpdateStateAsync(config);
            return context.Result;
        }

        sealed class TaskProgress : ITaskProgress
        {
            /// <summary>
            /// A task resource config.
            /// </summary>
            public IResourceConfig Config { get; }

            public bool IsDone { get; set; } = false;

            /// <summary>
            /// A start time of the task.
            /// </summary>
            readonly DateTime _StartTime = DateTime.UtcNow;

            /// <summary>
            /// Progress time slot.
            /// </summary>
            readonly TimeSlot _TimeSlot;

            /// <summary>
            /// Task duration, in seconds.
            /// </summary>
            readonly int _Duration;

            /// <summary>
            /// A duration of all tasks, in seconds.
            /// </summary>
            readonly int _TotalDuration;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="totalDuration">A duration of all tasks, in seconds.</param>
            /// <param name="config">A resource config.</param>
            /// <param name="timeSlotAndDuration">A time slot and duration (in seconds) of the task.
            /// </param>
            public TaskProgress(
                int totalDuration, IResourceConfig config, Tuple<TimeSlot, int> timeSlotAndDuration)
            {
                Config = config;
                _TotalDuration = totalDuration;
                _TimeSlot = timeSlotAndDuration.Item1;
                _Duration = timeSlotAndDuration.Item2;
            }

            /// <summary>
            /// Get task progress time.
            /// </summary>
            /// <returns></returns>
            int GetProgressTime()
            {
                if (IsDone)
                {
                    return _Duration;
                }
                else
                {
                    var seconds = (int)(DateTime.UtcNow - _StartTime).TotalSeconds;
                    seconds *= 2;
                    return seconds <= 0
                        ? 0
                        : _Duration * seconds / (_Duration + seconds);
                }
            }

            /// <summary>
            /// An absolute progress contributed by this task [0..1].
            /// </summary>
            /// <returns></returns>
            public double GetProgress()
                => _TimeSlot.GetTaskProgress(GetProgressTime()) / _TotalDuration;
        }

        sealed class Context
        {
            public IState Result => _OperationContext.Result;

            readonly StateOperationContext _OperationContext;

            readonly IState _Target;

            readonly IShouldProcess _ShouldProcess;

            /// <summary>
            /// A callback to report a progress.
            /// </summary>
            readonly Action<ITaskProgress> _ReportTaskProgress;

            readonly ProgressMap _ProgressMap;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="operationContext">a state operation context.</param>
            /// <param name="target">An Azure target state.</param>
            /// <param name="shouldProcess">A 'should process' interface</param>
            /// <param name="reportTaskProgress">A callback to report progress.</param>
            /// <param name="progressMap">Task progress information.</param>
            public Context(
                StateOperationContext operationContext,
                IState target,
                IShouldProcess shouldProcess,
                Action<ITaskProgress> reportTaskProgress,
                ProgressMap progressMap)
            {
                _OperationContext = operationContext;
                _Target = target;
                _ShouldProcess = shouldProcess;
                _ReportTaskProgress = reportTaskProgress;
                _ProgressMap = progressMap;
            }

            public async Task UpdateStateAsync<TModel>(ResourceConfig<TModel> config)
                where TModel : class
            {
                var model = _Target.Get(config);
                if (model != null)
                {
                    await _OperationContext.GetOrAdd(
                        config,
                        async () =>
                        {
                            // wait for all dependencies
                            var dependencyTasks = config
                                .GetResourceDependencies()
                                .Select(UpdateStateAsyncDispatch);
                            await Task.WhenAll(dependencyTasks);
                            // call the CreateOrUpdateAsync function for the resource.
                            if (await _ShouldProcess.ShouldCreate(config, model))
                            {
                                var taskProgress = new TaskProgress(
                                    _ProgressMap.Duration, config, _ProgressMap.Get(config));
                                _ReportTaskProgress(taskProgress);
                                var result = await config.CreateOrUpdateAsync(
                                    _OperationContext.Client,
                                    model,
                                    _OperationContext.CancellationToken);
                                taskProgress.IsDone = true;
                                return result;
                            }
                            else
                            {
                                return null;
                            }
                        });
                }
            }

            public Task UpdateStateAsyncDispatch(IResourceConfig config)
                => config.Accept(new UpdateStateAsyncVisitor(), this);
        }

        sealed class UpdateStateAsyncVisitor : IResourceConfigVisitor<Context, Task>
        {
            public Task Visit<TModel>(ResourceConfig<TModel> config, Context context)
                where TModel : class
                => context.UpdateStateAsync(config);
        }
    }
}
