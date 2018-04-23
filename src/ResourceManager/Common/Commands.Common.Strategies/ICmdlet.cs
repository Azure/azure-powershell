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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    /// <summary>
    /// An interface for a cmdlet for dependency injection.
    /// </summary>
    public interface ICmdlet
    {
        /// <summary>
        /// Verbose output. See also PowerShell `WriteVerbose`.
        /// </summary>
        /// <param name="message"></param>
        void WriteVerbose(string message);

        /// <summary>
        /// See PowerShell `ShouldProcess`.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        bool ShouldProcess(string target, string action);

        /// <summary>
        /// See also PowerShell `WriteObject`.
        /// </summary>
        /// <param name="value"></param>
        void WriteObject(object value);

        /// <summary>
        /// See also PowerShell `WriteProgress`.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="statusDescription"></param>
        /// <param name="currentOperation"></param>
        /// <param name="percentComplete"></param>
        void WriteProgress(
            string activity,
            string statusDescription,
            string currentOperation,
            int percentComplete);

        /// <summary>
        /// See also `VerbsCommon.New`.
        /// </summary>
        string VerbsNew { get; }

        /// <summary>
        /// Cmdlet parameters.
        /// </summary>
        IEnumerable<KeyValuePair<string, object>> Parameters { get; }
    }
}
