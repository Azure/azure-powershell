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
using System.Net;
using System.Text;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.MachineLearning
{
    /// <summary>
    /// Helper class that converts <see cref="ErrorResponseMessageException"/> 
    /// objects into <see cref="ErrorRecord"/>
    /// </summary>
    public class ErrorResponseMessageException : Exception
    {
        /// <summary>
        /// Gets or sets the http status code.
        /// </summary>
        public HttpStatusCode HttpStatus { get; set; }

        /// <summary>
        /// Gets or sets the error response code.
        /// </summary>
        public ErrorResponseMessage ErrorResponseMessage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponseMessageException" /> class.
        /// </summary>
        /// <param name="httpStatus">The http status code.</param>
        /// <param name="errorResponseMessage">The error response code.</param>
        /// <param name="errorMessage">The error response message.</param>
        /// <param name="innerException">Optional. The inner exception.</param>
        public ErrorResponseMessageException(HttpStatusCode httpStatus, ErrorResponseMessage errorResponseMessage, string errorMessage, Exception innerException = null)
            : base(errorMessage, innerException)
        {
            if (((int)httpStatus >= 200 && (int)httpStatus <= 299) || (int)httpStatus == 304)
            {
                throw new ArgumentException(
                    message: "The error response message exception should not be used for successful http response messages.",
                    paramName: "httpStatus");
            }

            this.HttpStatus = httpStatus;
            this.ErrorResponseMessage = errorResponseMessage;
        }
        
        /// <summary>
         /// Converts <see cref="ErrorResponseMessageException"/> objects into 
         /// <see cref="ErrorRecord"/>
         /// </summary>
         /// <param name="exception">The exception</param>
        internal ErrorRecord ToErrorRecord()
        {
            var errorReport = new StringBuilder();
            errorReport.AppendLine();
            if (this.ErrorResponseMessage != null &&
                this.ErrorResponseMessage.Error != null)
            {
                errorReport.AppendLine("Error Code: {0}"
                    .FormatInvariant(this.ErrorResponseMessage.Error.Code));
                errorReport.AppendLine("Error Message: {0}"
                    .FormatInvariant(this.ErrorResponseMessage.Error.Message));
                errorReport.AppendLine("Error Target: {0}"
                    .FormatInvariant(this.ErrorResponseMessage.Error.Target));
                
                if (this.ErrorResponseMessage.Error.Details.Any())
                {
                    errorReport.AppendLine("Error Details:");
                    foreach (var errorDetail in this.ErrorResponseMessage.Error.Details)
                    {
                        errorReport.AppendLine("\t[Code={0}, Message={1}]"
                            .FormatInvariant(errorDetail.Code, errorDetail.Message));
                    }
                }
            }
            else
            {
                errorReport.AppendLine("Error message: {0}".FormatInvariant(this.Message));
            }

            var returnedError = new Exception(errorReport.ToString());
            return new ErrorRecord(
                        returnedError, 
                        "Resource Provider Error", 
                        ErrorCategory.CloseError, 
                        null);
        }
    }
}

