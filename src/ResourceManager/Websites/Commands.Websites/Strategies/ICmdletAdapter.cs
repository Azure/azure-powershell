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
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.WebApps.Strategies
{
    public interface ICmdletAdapter : IShouldProcess
    {
        /// <summary>
        /// Path information for the current running cmdlet
        /// </summary>
        SessionState SessionState { get; }

        /// <summary>
        /// Given the target and description of a change, determine if the change should occur
        /// </summary>
        /// <param name="target">The resource that is changing</param>
        /// <param name="action">A description fo the proposed change</param>
        /// <returns>True if the change should proceeed, false otherwise</returns>
        Task<bool> ShouldChangeAsync(string target, string action);

        /// <summary>
        /// Given the target and prompt information describing a special condition for a change, determine whether the change should proceed
        /// </summary>
        /// <param name="query">A textual description of the special circumstances that require special confirmation</param>
        /// <param name="caption">A summary description of the special condition that requires confirmation</param>
        /// <returns>True if the change shoudl proceed, false otherwise</returns>
        Task<bool> ShouldContinueChangeAsync(string query, string caption);

        /// <summary>
        /// Report an error
        /// </summary>
        /// <param name="exception">The exception descriging the error</param>
        /// <returns>nothing</returns>
        void WriteExceptionAsync(Exception exception);

        /// <summary>
        /// Write an object to the ouput stream
        /// </summary>
        /// <param name="output">The oject to write</param>
        void WriteObjectAsync(object output);

        /// <summary>
        /// Write an object to the outpit stream
        /// </summary>
        /// <param name="output">The object to write</param>
        /// <param name="enumerateCollection">Indicate whether write each element of a collection to the output stream</param>
        void WriteObjectAsync(object output, bool enumerateCollection);

        /// <summary>
        /// Log additional information
        /// </summary>
        /// <param name="verboseMessage">The additional information to log</param>
        /// <returns>nothing</returns>
        void WriteVerboseAsync(string verboseMessage);

        /// <summary>
        /// Log debugging information
        /// </summary>
        /// <param name="debugMessage">The debug information to log</param>
        /// <returns>nothing</returns>
        void WriteDebugAsync(string debugMessage);

        /// <summary>
        /// Log a warning message
        /// </summary>
        /// <param name="warningMessage">The warning to log</param>
        /// <returns>nothing</returns>
        void WriteWarningAsync(string warningMessage);

        /// <summary>
        /// Log the beginning of an activity
        /// </summary>
        /// <param name="description">A description of the activity that is starting</param>
        /// <param name="initialStatus">The inbitial status of the activity</param>
        /// <returns>An activity tracker</returns>
        void ReportTaskProgress(ITaskProgress progress);

        /// <summary>
        /// Complete all processing
        /// </summary>
        /// <returns>nothing</returns>
        void Complete();
    }
}
