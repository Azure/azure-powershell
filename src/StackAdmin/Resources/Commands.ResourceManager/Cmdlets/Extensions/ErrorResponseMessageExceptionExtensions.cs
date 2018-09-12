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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ErrorResponses;
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Helper class that converts <see cref="ErrorResponseMessageException"/> objects into <see cref="ErrorRecord"/>
    /// </summary>
    internal static class ErrorResponseMessageExceptionExtensions
    {
        /// <summary>
        /// Converts <see cref="ErrorResponseMessageException"/> objects into <see cref="ErrorRecord"/>
        /// </summary>
        /// <param name="exception">The exception</param>
        internal static ErrorRecord ToErrorRecord(this ErrorResponseMessageException exception)
        {
            // TODO: Improve this.
            return new ErrorRecord(exception, exception.ErrorResponseMessage == null ? exception.HttpStatus.ToString() : exception.ErrorResponseMessage.Error.Code, ErrorCategory.CloseError, null);
        }

        /// <summary>
        /// Converts <see cref="Exception"/> objects into <see cref="ErrorRecord"/>
        /// </summary>
        /// <param name="exception">The exception</param>
        internal static ErrorRecord ToErrorRecord(this Exception exception)
        {
            // TODO: Improve this.
            return new ErrorRecord(exception, exception.Message, ErrorCategory.CloseError, null);
        }

        /// <summary>
        /// Converts <see cref="AggregateException"/> objects into <see cref="ErrorRecord"/>
        /// </summary>
        /// <param name="exception">The exception</param>
        internal static ErrorRecord ToErrorRecord(this AggregateException aggregateException)
        {
            // TODO: Improve this.
            return new ErrorRecord(aggregateException, aggregateException.ToString(), ErrorCategory.CloseError, null);
        }
    }
}
