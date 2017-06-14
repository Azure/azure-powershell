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


namespace Microsoft.Azure.Commands.Automation.Common
{
    /// <summary>
    /// StreamType enum represents the 6 types of Powershell Streams supported.
    /// </summary>
    public enum StreamType
    {
        /// <summary>
        /// Indicates Generic stream. Used for querying all the streams regardless of the type.
        /// </summary>
        Any,

        /// <summary>
        /// Indicates Progress Record streams
        /// </summary>
        Progress,

        /// <summary>
        /// Indicates Output Record streams
        /// </summary>
        Output,

        /// <summary>
        /// Indicates Warning Record streams
        /// </summary>
        Warning,

        /// <summary>
        /// Indicates Error Record streams
        /// </summary>
        Error,

        /// <summary>
        /// Indicates Debug Record streams
        /// </summary>
        Debug,

        /// <summary>
        /// Indicates Verbose Record streams
        /// </summary>
        Verbose
    }
}
