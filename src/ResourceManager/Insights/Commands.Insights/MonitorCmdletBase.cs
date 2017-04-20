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

using System.Globalization;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using Microsoft.Rest;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Insights
{
    /// <summary>
    /// Base class for the Azure Insights SDK Cmdlets
    /// </summary>
    public abstract class MonitorCmdletBase : AzureRMCmdlet
    {
        /// <summary>
        /// Executes the Cmdlet. This is a callback function to simplify the exception handling
        /// </summary>
        protected abstract void ProcessRecordInternal();

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.ProcessRecordInternal();
            }
            catch (AggregateException ex)
            {
                // Process the exception to be as informative as possible to the user
                var exTemp = ex.Flatten().InnerException ?? ex;
                string exName = exTemp.GetType().Name;
                string message = exTemp.Message;
                string code = null;
                HttpStatusCode? statusCode = null;
                string reasonPhrase = null;

                if (exTemp is RestException)
                {
                    // All the following Exceptions have the same structure, but their common ancestor does not contain Body nor Response
                    var cloudException = exTemp as CloudException;
                    if (cloudException != null)
                    {
                        message = cloudException.Body.Message;
                        code = cloudException.Body.Code;
                        statusCode = cloudException.Response.StatusCode;
                        reasonPhrase = cloudException.Response.ReasonPhrase;
                    }
                    else
                    {
                        // New model to report errors (from Swagger Spec)
                        var errorResponse = exTemp as Microsoft.Azure.Insights.Models.ErrorResponseException;
                        if (errorResponse != null)
                        {
                            message = errorResponse.Body.Message;
                            code = errorResponse.Body.Code;
                            statusCode = errorResponse.Response.StatusCode;
                            reasonPhrase = errorResponse.Response.ReasonPhrase;
                        }
                        else
                        {
                            // New model to report errors (from Swagger Spec)
                            var errorResponse2 = exTemp as Microsoft.Azure.Management.Insights.Models.ErrorResponseException;
                            if (errorResponse2 != null)
                            {
                                message = errorResponse2.Body.Message;
                                code = errorResponse2.Body.Code;
                                statusCode = errorResponse2.Response.StatusCode;
                                reasonPhrase = errorResponse2.Response.ReasonPhrase;
                            }
                            else
                            {
                                message = exTemp.Message;
                            }
                        }
                    }
                }

                throw new PSInvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Exception type: {0}, Message: {1}, Code: {2}, Status code:{3}, Reason phrase: {4}",
                        exName,
                        string.IsNullOrWhiteSpace(message) ? "Null/Empty" : message,
                        code ?? "Null",
                        statusCode.HasValue ? statusCode.Value.ToString() : "Null",
                        reasonPhrase ?? "Null"),
                    exTemp);
            }
        }
    }
}
