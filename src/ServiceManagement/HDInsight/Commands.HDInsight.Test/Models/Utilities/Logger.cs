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
using Microsoft.WindowsAzure.Management.HDInsight.Logging;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities
{
    /// <summary>
    ///     The default implementation of the logger.  All messages are
    ///     simply passed into the LogWriter.
    /// </summary>
    internal class Logger : ILogger
    {
        private readonly List<ILogWriter> writers = new List<ILogWriter>();

        /// <inheritdoc />
        public void AddWriter(ILogWriter writer)
        {
            this.writers.Add(writer);
        }

        /// <inheritdoc />
        public void RemoveWriter(ILogWriter writer)
        {
            this.writers.Remove(writer);
        }

        /// <inheritdoc />
        public void LogMessage(string message)
        {
            this.LogMessage(message, Severity.Message, Verbosity.Normal);
        }

        public void LogMessage(string message, Severity severity, Verbosity verbosity)
        {
            foreach (ILogWriter logWriter in this.writers)
            {
                logWriter.Log(severity, verbosity, message);
            }
        }
    }
}
