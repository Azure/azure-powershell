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
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class SyncTaskScheduler
    {
        readonly ConcurrentQueue<Task> _Tasks = new ConcurrentQueue<Task>();

        public async Task<T> Invoke<T>(Func<T> func)
        {
            var task = new Task<T>(func);
            _Tasks.Enqueue(task);
            // note: don't use 'await' keyword for the 'task' because it may start the task in 
            // another thread.
            while (!task.IsCompleted)
            {
                await Task.Yield();
            }
            return task.Result;
        }

        public void BeginInvoke(Action action)
            => _Tasks.Enqueue(new Task(action));

        /// <summary>
        /// Wait for the given task to complete.
        /// </summary>
        /// <param name="task">running task</param>
        /// <param name="progressUpdate">an action to update/show task progress.</param>
        public void Wait(Task task, Action progressUpdate)
        {
            while (!task.IsCompleted)
            {
                HandleActions();
                progressUpdate();
                Thread.Yield();
            }
            HandleActions();
            if (task.IsFaulted)
            {
                throw task.Exception.InnerException;
            }
        }

        void HandleActions()
        {
            Task task;
            while (_Tasks.TryDequeue(out task))
            {
                task.RunSynchronously();
            }
        }
    }
}