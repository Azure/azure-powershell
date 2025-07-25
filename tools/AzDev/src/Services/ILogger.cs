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

namespace AzDev.Services
{
    /// <summary>
    /// Provides logging methods that can be used by various components.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a debug message.
        /// </summary>
        void Debug(string message);

        /// <summary>
        /// Logs a verbose message.
        /// </summary>
        void Verbose(string message);

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        void Warning(string message);

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        void Information(string message);
    }
}
