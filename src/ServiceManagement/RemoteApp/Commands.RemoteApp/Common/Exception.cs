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

using Hyak.Common;
using Microsoft.WindowsAzure;
using System;
using System.Management.Automation;
using System.Net;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{

    public enum ExceptionType
    {
        NonTerminating = 0,
        Terminating = 1 
    }

    public class ErrorRecordState
    {
        public HttpStatusCode Status;
        public string ExceptionMessage;
        public ErrorCategory Category;
        public ExceptionType type;
    }

    public class CloudRecordState
    {
        public ErrorRecordState state;
        public ErrorRecord er;
    }

    public class RemoteAppServiceException : Exception
    {
        internal ErrorCategory category { get; private set; }

        public RemoteAppServiceException(String message, ErrorCategory cat)
            : base(message)
        {
            category = cat;
        }
    }


    public class RemoteAppCollectionErrorState
    {
        internal static readonly ErrorRecordState[] ErrorRecordStateTable = new ErrorRecordState[]
        {
            new ErrorRecordState()
            {
                Status = HttpStatusCode.BadRequest,
                ExceptionMessage = "Invalid argument",
                Category = ErrorCategory.InvalidArgument,
            },
            new ErrorRecordState()
            {
                Status = HttpStatusCode.Unauthorized,
                ExceptionMessage = "Authentication error",
                Category = ErrorCategory.AuthenticationError,
            },
            new ErrorRecordState()
            {
                Status = HttpStatusCode.Forbidden,
                ExceptionMessage = "Security error",
                Category = ErrorCategory.SecurityError,
            },
            new ErrorRecordState()
            {
                Status = HttpStatusCode.RequestTimeout,
                ExceptionMessage = "Timeout error",
                Category = ErrorCategory.OperationTimeout,
            },
            new ErrorRecordState()
            {
                Status = HttpStatusCode.ProxyAuthenticationRequired,
                ExceptionMessage = "Proxy authentication error",
                Category = ErrorCategory.AuthenticationError,
            },
            new ErrorRecordState()
            {
                Status =  HttpStatusCode.NotFound,
                ExceptionMessage = "Resource not found",
                Category = ErrorCategory.ObjectNotFound,
            },
            new ErrorRecordState()
            {
                Status =  HttpStatusCode.Gone,
                ExceptionMessage = "Resource not found",
                Category = ErrorCategory.ObjectNotFound,
            },
            new ErrorRecordState()
            {
                Status =  HttpStatusCode.InternalServerError,
                ExceptionMessage = "Server error",
                Category = ErrorCategory.InvalidOperation,
            },
            new ErrorRecordState()
            {
                Status =  HttpStatusCode.BadGateway,
                ExceptionMessage = "Gateway error",
                Category = ErrorCategory.InvalidOperation,
            },
            new ErrorRecordState()
            {
                Status =  HttpStatusCode.ServiceUnavailable,
                ExceptionMessage = "Service Unavailable",
                Category = ErrorCategory.OperationStopped,
            },
            new ErrorRecordState()
            {
                Status =  HttpStatusCode.GatewayTimeout,
                ExceptionMessage = "Timeout error",
                Category = ErrorCategory.OperationTimeout,
            }
        };

        internal static readonly ErrorRecordState erDefault = new ErrorRecordState()
        {
            Status = HttpStatusCode.Unused,
            ExceptionMessage = "Unknown error",
            Category = ErrorCategory.NotSpecified,
        };

        internal static CloudRecordState CreateErrorStateFromCloudException(CloudException e, string errorId, object targetObject)
        {
            ErrorRecordState state = CreateErrorStateFromHttpStatusCode(e.Response.StatusCode);
            ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromException(e, errorId, targetObject, state.Category);
            CloudRecordState cloudRecord = new CloudRecordState()
            {
                state = state,
                er = er
            };

            return cloudRecord;
        }

        internal static ErrorRecord CreateErrorRecordFromException(Exception e, string errorId, object targetObject, ErrorCategory category)
        {
            ErrorRecord er = new ErrorRecord(e, errorId, category, targetObject.GetType().Name);
            return er;
        }

        internal static ErrorRecord CreateErrorRecordFromString(string errorMessage, string errorId, object targetObject, ErrorCategory category)
        {
            string ExceptionMessage = String.Format("{0:T} - {1}",
                        DateTime.Now,
                        errorMessage);

            Exception ex = new Exception(ExceptionMessage);

            ErrorRecord er = CreateErrorRecordFromException(ex, errorId, targetObject, category);

            return er;
        }

        internal static ErrorRecordState CreateErrorStateFromHttpStatusCode(HttpStatusCode status)
        {
            ErrorRecordState erStateToUse = erDefault;

            foreach (ErrorRecordState recordState in ErrorRecordStateTable)
            {
                if (status == recordState.Status)
                {
                    erStateToUse = recordState;
                    break;
                }
            }

            string exceptionMessage = String.Format("{0:T} - {1} in call to server HTTP Status: {2}",
                        DateTime.Now,
                        erStateToUse.ExceptionMessage,
                        status);

            ErrorRecordState state = new ErrorRecordState()
            {
                Status = erStateToUse.Status,
                ExceptionMessage = exceptionMessage,
                Category = erStateToUse.Category
            };

            if (state.Status == HttpStatusCode.BadRequest ||
                state.Status == HttpStatusCode.RequestTimeout ||
                state.Status == HttpStatusCode.NotFound || 
                state.Status == HttpStatusCode.GatewayTimeout)
            {
                state.type = ExceptionType.NonTerminating;
            }
            else
            {
                state.type = ExceptionType.Terminating;
            }

            return state;
        }
    }
}

