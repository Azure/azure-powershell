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
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    /// <summary>
    /// Helper functions for <see cref="System.Threading.Tasks.Task{TResult}"/>
    /// </summary>
    public class Tasks
    {
        /// <summary>
        /// Create a <see cref="System.Threading.Tasks.Task{TResult}"/> which has completed
        /// with the given value.
        /// </summary>
        /// <remarks>This does the same thing as Task.FromResult, but that
        /// method only exists in .NET 4.5. Since this project targets
        /// .NET 4.0, this method helps.</remarks>
        /// <typeparam name="TResult">Type of result</typeparam>
        /// <param name="result">Result value</param>
        /// <returns>The completed task.</returns>
        public static Task<TResult> FromResult<TResult>(TResult result)
        {
            var taskSource = new TaskCompletionSource<TResult>();
            taskSource.SetResult(result);
            return taskSource.Task;
        }

        public static Task<TResult> FromException<TResult>(Exception ex)
        {
            var taskSource = new TaskCompletionSource<TResult>();
            taskSource.SetException(ex);
            return taskSource.Task;
        }
    }
}
