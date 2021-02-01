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
using System.Runtime.CompilerServices;

namespace Microsoft.Azure.Commands.Common.Exceptions
{
    /// <summary>
    /// Represents resource not found error from Azure service in Azure PowerShell.
    /// </summary>
    public class AzPSResourceNotFoundCloudException : AzPSCloudException
    {
        /// <summary>
        /// Construtor of AzPSResourceNotFoundCloudException
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="desensitizedMessage">The error message which doesn't contain PII.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. Default value is null.</param>
        /// <param name="lineNumber">The number of line when exception happens.</param>
        /// <param name="filePath">The file path when exception happens.</param>
        public AzPSResourceNotFoundCloudException(
            string message,
            string desensitizedMessage = null,
            Exception innerException = null,
            [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = null)
            : this(message, ErrorKind.UserError, desensitizedMessage, innerException, lineNumber, filePath)
        {
        }

        /// <summary>
        /// Constructor of AzPSResourceNotFoundCloudException
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="errorKind">ErrorKind that causes this exception.</param>
        /// <param name="desensitizedMessage">The error message which doesn't contain PII.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. Default value is null.</param>
        /// <param name="lineNumber">The number of line when exception happens.</param>
        /// <param name="filePath">The file path when exception happens.</param>
        public AzPSResourceNotFoundCloudException(
            string message,
            ErrorKind errorKind,
            string desensitizedMessage = null,
            Exception innerException = null,
            [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = null)
            : base(message, errorKind, desensitizedMessage, innerException, lineNumber, filePath)
        {
        }
    }
}
