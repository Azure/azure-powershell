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

namespace Microsoft.Azure.Commands.Common.Strategies
{
    /// <summary>
    /// Task progress.
    /// </summary>
    public interface ITaskProgress
    {
        /// <summary>
        /// Resource configuration related to the task.
        /// </summary>
        IResourceConfig Config { get; }

        /// <summary>
        /// Absolute progress [0..1].
        /// </summary>
        /// <returns></returns>
        double GetProgress();

        /// <summary>
        /// true if the task is done.
        /// </summary>
        bool IsDone { get; }
    }
}
