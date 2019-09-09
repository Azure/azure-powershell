//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//


namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Management.ApiManagement.Models;
    using Microsoft.Rest.Azure;
    using ResourceManager.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text;

    abstract public class AzureApiManagementCmdletBase : AzureRMCmdlet
    {
        protected static TimeSpan LongRunningOperationDefaultTimeout = TimeSpan.FromSeconds(30);

        private ApiManagementClient _client;

        public ApiManagementClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new ApiManagementClient(DefaultContext);
                }
                return _client;
            }
            set
            {
                _client = value;
            }
        }

        public abstract void ExecuteApiManagementCmdlet();

        public override void ExecuteCmdlet()
        {
            try
            {
                ExecuteApiManagementCmdlet();
            }
            catch (ArgumentException ex)
            {
                WriteError(new ErrorRecord(ex, ex.Message, ErrorCategory.InvalidArgument, ex));
            }
            catch(ErrorResponseException ex)
            {
                HandleException(ex);
            }
            catch(CloudException ex)
            {
                HandleException(ex);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        protected virtual void HandleException(Exception ex)
        {
            WriteExceptionError(ex);
        }

        protected void HandleException(ErrorResponseException ex)
        {
            var errorReport = new StringBuilder();
            errorReport.AppendLine();
            if (ex.Body != null)
            {
                errorReport.AppendLine("Error Code: {0}"
                    .FormatInvariant(ex.Body.Code));
                errorReport.AppendLine("Error Message: {0}"
                    .FormatInvariant(ex.Body.Message));

                if (ex.Response != null && ex.Response.Headers != null)
                {
                    string requestId;
                    // Try to obtain the request id from the HTTP response associated with the exception
                    IEnumerable<string> headerValues = Enumerable.Empty<string>();
                    if (ex.Response.Headers.TryGetValue("x-ms-request-id", out headerValues))
                    {
                        requestId = headerValues.First();
                        errorReport.AppendLine("Request Id: {0}".FormatInvariant(requestId));
                    }
                }

                if (ex.Body.Details != null && 
                    ex.Body.Details.Any())
                {
                    errorReport.AppendLine("Error Details:");
                    foreach (var errorDetail in ex.Body.Details)
                    {
                        errorReport.AppendLine("\t[Code= {0}, Message= {1}, Target= {2}]"
                            .FormatInvariant(errorDetail.Code, errorDetail.Message, errorDetail.Target));
                    }
                }
            }
            else
            {
                errorReport.AppendLine("Error message: {0}".FormatInvariant(ex));
            }

            var returnedError = new Exception(errorReport.ToString());
                        
            var errorRecord = new ErrorRecord(
                        returnedError,
                        ex.Message,
                        ErrorCategory.CloseError,
                        ex);
            this.WriteError(errorRecord);
        }

        protected void HandleException(CloudException cloudException)
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
            if (cloudException.Body != null)
            {
                errorReport.AppendLine("Error Code: {0}".FormatInvariant(cloudException.Body.Code));
                errorReport.AppendLine("Error Message: {0}".FormatInvariant(cloudException.Body.Message));
                errorReport.AppendLine("Error Target: {0}".FormatInvariant(cloudException.Body.Target));
                if (cloudException.Body.Details.Any())
                {
                    errorReport.AppendLine("Error Details:");
                    foreach (var errorDetail in cloudException.Body.Details)
                    {
                        errorReport.AppendLine(
                                        "\t[Code={0}, Message={1}]".FormatInvariant(
                                                                        errorDetail.Code,
                                                                        errorDetail.Message));
                    }
                }
            }
            else
            {
                if (cloudException.Response != null)
                {
                    errorReport.AppendLine("Error Content: {0}".FormatInvariant(cloudException.Response.Content));
                }
            }

            var returnedError = new Exception(errorReport.ToString(), cloudException);
            var errorRecord = new ErrorRecord(returnedError, cloudException.Message, ErrorCategory.CloseError, null);
            this.WriteError(errorRecord);
        }
    }
}