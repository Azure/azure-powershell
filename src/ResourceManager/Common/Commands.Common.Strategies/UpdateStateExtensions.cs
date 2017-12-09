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
        public static async Task<IState> UpdateStateAsync<TModel>(
            this ResourceConfig<TModel> config,
            IClient client,
            IState target,
            CancellationToken cancellationToken,
            IShouldProcess shouldProcess,
            IProgressReport progressReport)
            where TModel : class
        {
            var context = new Context(
                new StateOperationContext(client, cancellationToken),
                target,
                shouldProcess,
                progressReport,
                config.GetProgressMap(target));
            await context.UpdateStateAsync(config);
            return context.Result;
        }

        sealed class TaskProgress : ITaskProgress
        {
            public IResourceConfig Config { get; }

            public bool IsDone { get; set; } = false;

            DateTime _StartTime { get; } = DateTime.UtcNow;

            readonly TimeSlot _TimeSlot;

            readonly int _Duration;

            readonly int _TotalDuration;

            public TaskProgress(
                int totalDuration, IResourceConfig config, Tuple<TimeSlot, int> timeSlotAndDuration)
            {
                Config = config;
                _TotalDuration = totalDuration;
                _TimeSlot = timeSlotAndDuration.Item1;
                _Duration = timeSlotAndDuration.Item2;
            }

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

            public double GetProgress()
                => _TimeSlot.GetTaskProgress(GetProgressTime()) / _TotalDuration;
        }

        sealed class Context
        {
            public IState Result => _OperationContext.Result;

            readonly StateOperationContext _OperationContext;

            readonly IState _Target;

            readonly IShouldProcess _ShouldProcess;

            readonly IProgressReport _ProgressReport;

            readonly ProgressMap _ProgressMap;

            public Context(
                StateOperationContext operationContext,
                IState target,
                IShouldProcess shouldProcess,
                IProgressReport progressReport,
                ProgressMap progressMap)
            {
                _OperationContext = operationContext;
                _Target = target;
                _ShouldProcess = shouldProcess;
                _ProgressReport = progressReport;
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
                                _ProgressReport.NewTask(taskProgress);
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
