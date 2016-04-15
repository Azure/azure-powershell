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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ErrorResponses;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.MachineLearning.WebServices.Extensions
{
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
        /// <param name="aggregateException">The exception</param>
        internal static ErrorRecord ToErrorRecord(this AggregateException aggregateException)
        {
            // TODO: Improve this.
            return new ErrorRecord(aggregateException, aggregateException.ToString(), ErrorCategory.CloseError, null);
        }

        /// <summary>
        /// Converts <see cref="CloudException"/> objects into <see cref="ErrorRecord"/>
        /// </summary>
        /// <param name="cloudException">The exception</param>
        internal static ErrorRecord ToErrorRecord(this CloudException cloudException)
        {
            var errorReport = new StringBuilder();

            string requestId = cloudException.RequestId;
            if (string.IsNullOrWhiteSpace(requestId) && cloudException.Response != null)
            {
                // Try to obtain the request id from the HTTP response associated with the exception
                IEnumerable<string> headerValues = Enumerable.Empty<string>();
                if (cloudException.Response.Headers != null &&
                    cloudException.Response.Headers.TryGetValue("x-ms-request-id", out headerValues))
                {
                    requestId = headerValues.First();
                }
            }

            errorReport.AppendLine();
            errorReport.AppendLine("Request Id: {0}".FormatInvariant(requestId));
            errorReport.AppendLine("Error Code: {0}".FormatInvariant(cloudException.Body.Code));
            errorReport.AppendLine("Error Message: {0}".FormatInvariant(cloudException.Body.Message));
            if (cloudException.Body.Details.Any())
            {
                errorReport.AppendLine("Error Details:");
                foreach (var errorDetail in cloudException.Body.Details)
                {
                    errorReport.AppendLine("\t[Code={0}, Message={1}]".FormatInvariant(errorDetail.Code, errorDetail.Message));
                }
            }

            var returnedError = new Exception(errorReport.ToString());
            return new ErrorRecord(returnedError, "Resource Provider Error", ErrorCategory.CloseError, null);
        }
    }
}
