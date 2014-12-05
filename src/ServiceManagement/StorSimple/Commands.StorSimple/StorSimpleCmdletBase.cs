using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Net;
using System.Management.Automation;
using Microsoft.WindowsAzure;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    using Properties;

    public class StorSimpleCmdletBase : AzurePSCmdlet
    {
        private PSStorSimpleClient storSimpleClient;

        internal PSStorSimpleClient StorSimpleClient
        {
            get
            {
                if (this.storSimpleClient == null)
                {
                    this.storSimpleClient = new PSStorSimpleClient(CurrentContext.Subscription);
                }

                return this.storSimpleClient;
            }
        }

        internal virtual void HandleAsyncJobResponse(OperationResponse opResponse, string operationName)
        {
            string msg = string.Empty;

            if (opResponse.StatusCode != HttpStatusCode.Accepted && opResponse.StatusCode != HttpStatusCode.OK)
            {
                msg = string.Format(Resources.FailureMessageSubmitJob, operationName);
            }

            else
            {
                if (opResponse.GetType().Equals(typeof(JobResponse)))
                {
                    var jobResponse = opResponse as JobResponse;
                    msg = string.Format(Resources.SuccessMessageSubmitJob, operationName, jobResponse.JobId);
                    WriteObject(jobResponse.JobId);
                }

                else if (opResponse.GetType().Equals(typeof(GuidJobResponse)))
                {
                    var guidJobResponse = opResponse as GuidJobResponse;
                    msg = string.Format(Resources.SuccessMessageSubmitJob, operationName, guidJobResponse.JobId);
                    WriteObject(guidJobResponse.JobId);
                }
            }

            WriteVerbose(msg);
        }

        internal virtual void HandleSyncJobResponse(JobStatusInfo jobStatus, string operationName)
        {
            string msg = string.Empty;

            if (jobStatus.TaskResult != TaskResult.Succeeded)
            {
                msg = string.Format(Resources.FailureMessageCompleteJob, operationName);
                WriteObject(jobStatus);
            }

            else
            {
                msg = string.Format(Resources.SuccessMessageCompleteJob, operationName);
            }

            WriteVerbose(msg);
        }

        internal virtual void HandleException(Exception exception)
        {
            ErrorRecord errorRecord = null;
            var ex = exception;
            do
            {
                Type exType = ex.GetType();
                if(exType == typeof(CloudException))
                {
                    var cloudEx = ex as CloudException;
                    if (cloudEx == null)
                        break;
                    var response = cloudEx.Response;
                    string requestId = string.Empty;
                    if (response.Headers != null && response.Headers.ContainsKey(Constants.RequestIdHeaderName))
                    {
                        requestId = response.Headers[Constants.RequestIdHeaderName].FirstOrDefault();
                        WriteWarning(String.Format(Resources.CloudExceptionMessage, requestId));
                    } 
                    errorRecord = new ErrorRecord(cloudEx, string.Empty, ErrorCategory.InvalidOperation, null);
                    break;
                }
                else if(exType == typeof(WebException))
                {
                    var webEx = ex as WebException;
                    if (webEx == null)
                        break;
                    var response = webEx.Response;
                    string requestId = string.Empty;
                    if (response.Headers != null)
                    {
                        requestId = response.Headers[Constants.RequestIdHeaderName];
                        WriteWarning(String.Format(Resources.WebExceptionMessage, requestId));
                    }
                    errorRecord = new ErrorRecord(webEx, string.Empty, ErrorCategory.ConnectionError, null);
                    break;
                }
                else if (exType == typeof(NullReferenceException))
                {
                    var nullEx = ex as NullReferenceException;
                    if (nullEx == null)
                        break;
                    errorRecord = new ErrorRecord(nullEx, string.Empty, ErrorCategory.InvalidData, null);
                    break;
                }
                else if (exType == typeof(ArgumentNullException))
                {
                    var argEx = ex as ArgumentNullException;
                    if (argEx == null)
                        break;
                    errorRecord = new ErrorRecord(argEx, string.Empty, ErrorCategory.InvalidArgument, null);
                    break;
                }

                ex = ex.InnerException;
            } while (ex != null);

            if(errorRecord == null)
            {
                errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.NotSpecified, null);
            }

            WriteError(errorRecord);
        }
    }
}