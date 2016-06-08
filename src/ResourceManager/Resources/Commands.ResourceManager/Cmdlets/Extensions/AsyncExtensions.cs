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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The asynchronous extensions.
    /// </summary>
    public static class AsyncExtensions
    {
        /// <summary>
        /// Creates a task that will complete when all of the supplied tasks have completed. Multiple exceptions will be wrapped
        /// as single aggregate exception. This extension method is intend to be used with await operator exclusively.
        /// </summary>
        /// <typeparam name="T">The type of the result produced by task.</typeparam>
        /// <param name="tasks">The asynchronous tasks.</param>
        public static Task<T[]> WhenAllForAwait<T>(this IEnumerable<Task<T>> tasks)
        {
            return Task.WhenAll(tasks).WrapMultipleExceptionsForAwait();
        }

        /// <summary>
        /// Creates a task that will complete when all of the supplied tasks have completed. Multiple exceptions will be wrapped
        /// as single aggregate exception. This extension method is intend to be used with await operator exclusively.
        /// </summary>
        /// <param name="tasks">The asynchronous tasks.</param>
        public static Task WhenAllForAwait(this IEnumerable<Task> tasks)
        {
            return Task.WhenAll(tasks).WrapMultipleExceptionsForAwait();
        }

        /// <summary>
        /// Wraps the multiple exceptions as single aggregate exception for await operator.
        /// </summary>
        /// <param name="task">The asynchronous task.</param>
        public static Task WrapMultipleExceptionsForAwait(this Task task)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            task.ContinueWith(
                continuationAction: ignored => AsyncExtensions.CompleteTaskAndWrapMultipleExceptions(task, tcs),
                continuationOptions: TaskContinuationOptions.ExecuteSynchronously,
                cancellationToken: CancellationToken.None,
                scheduler: TaskScheduler.Default);

            return tcs.Task;
        }

        /// <summary>
        /// Wraps the multiple exceptions as single aggregate exception for await operator.
        /// </summary>
        /// <typeparam name="T">The type of the result produced by task.</typeparam>
        /// <param name="task">The asynchronous task.</param>
        public static Task<T> WrapMultipleExceptionsForAwait<T>(this Task<T> task)
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
            task.ContinueWith(
                continuationAction: ignored => AsyncExtensions.CompleteTaskAndWrapMultipleExceptions(task, tcs),
                continuationOptions: TaskContinuationOptions.ExecuteSynchronously,
                cancellationToken: CancellationToken.None,
                scheduler: TaskScheduler.Default);

            return tcs.Task;
        }

        /// <summary>
        /// Completes the task completion source and wraps multiple exceptions as single aggregate exception.
        /// </summary>
        /// <typeparam name="T">The type of the result produced by task.</typeparam>
        /// <param name="task">The asynchronous task.</param>
        /// <param name="completionSource">The task completion source.</param>
        private static void CompleteTaskAndWrapMultipleExceptions<T>(Task task, TaskCompletionSource<T> completionSource)
        {
            switch (task.Status)
            {
                case TaskStatus.Canceled:
                    completionSource.SetCanceled();
                    break;
                case TaskStatus.RanToCompletion:
                    var genericTask = task as Task<T>;
                    completionSource.SetResult(genericTask != null ? genericTask.Result : default(T));
                    break;
                case TaskStatus.Faulted:
                    completionSource.SetException(task.Exception.InnerExceptions.Count > 1 ? task.Exception : task.Exception.InnerException);
                    break;
            }
        }
    }
}
