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

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// An exception that may occur while we're parsing or constructing the command line.
    /// </summary>
    internal sealed class CommandLineException : Exception
    {
        /// <summary>
        /// Creates a new instance of <see cref="CommandLineException"/>.
        /// </summary>
        public CommandLineException() : base() {}

        /// <summary>
        /// Creates a new instance of <see cref="CommandLineException"/> with a specific error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public CommandLineException(string message) : base(message) {}

        /// <summary>
        /// Creates a new instance of <see cref="CommandLineException"/> with a specific error message and a reference to
        /// the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.</param>
        public CommandLineException(string message, Exception innerException) : base(message, innerException) {}
    }
}
