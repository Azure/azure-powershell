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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Management.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System.Threading;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using ResourcesNS = Microsoft.Azure.Management.Resources;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Base class for Recovery Services Backup cmdlets
    /// </summary>
    public abstract class RecoveryServicesBackupCmdletBase : AzureRMCmdlet
    {
        // in seconds
        private int _defaultSleepForOperationTracking = 5;

        protected ServiceClientAdapter ServiceClientAdapter { get; set; }

        protected ResourcesNS.ResourceManagementClient RmClient { get; set; }

        protected void InitializeAzureBackupCmdlet()
        {
            var cloudServicesClient = AzureSession.ClientFactory.CreateClient<CloudServiceManagementClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
            ServiceClientAdapter = new ServiceClientAdapter(cloudServicesClient.Credentials, cloudServicesClient.BaseUri);

            WriteDebug("InsideRestore. going to create ResourceManager Client");
            RmClient = AzureSession.ClientFactory.CreateClient<ResourcesNS.ResourceManagementClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
            WriteDebug("Client Created successfully");

            Logger.Instance = new Logger(WriteWarning, WriteDebug, WriteVerbose, ThrowTerminatingError);
        }

        protected void ExecutionBlock(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                WriteDebug(String.Format(Resources.ExceptionInExecution, exception.GetType()));
                HandleException(exception);
            }
        }

        /// <summary>
        /// Handles set of exceptions thrown by client
        /// </summary>
        /// <param name="ex"></param>
        private void HandleException(Exception exception)
        {
            if (exception is AggregateException && ((AggregateException)exception).InnerExceptions != null
                && ((AggregateException)exception).InnerExceptions.Count != 0)
            {
                WriteDebug(Resources.AggregateException);
                foreach (var innerEx in ((AggregateException)exception).InnerExceptions)
                {
                    HandleException(innerEx);
                }
            }
            else
            {
                Exception targetEx = exception;
                string targetErrorId = String.Empty;
                ErrorCategory targetErrorCategory = ErrorCategory.NotSpecified;

                if (exception is CloudException)
                {
                    var cloudEx = exception as CloudException;
                    if (cloudEx.Response != null && cloudEx.Response.StatusCode == HttpStatusCode.NotFound)
                    {
                        WriteDebug(String.Format(Resources.CloudExceptionCodeNotFound, cloudEx.Response.StatusCode));

                        targetEx = new Exception(Resources.ResourceNotFoundMessage);
                        targetErrorCategory = ErrorCategory.InvalidArgument;
                    }
                    else if (cloudEx.Error != null)
                    {
                        WriteDebug(String.Format(Resources.CloudException, cloudEx.Error.Code, cloudEx.Error.Message));

                        targetErrorId = cloudEx.Error.Code;
                        targetErrorCategory = ErrorCategory.InvalidOperation;
                    }
                }
                else if (exception is WebException)
                {
                    var webEx = exception as WebException;
                    WriteDebug(string.Format(Resources.WebException, webEx.Response, webEx.Status));

                    targetErrorCategory = ErrorCategory.ConnectionError;
                }
                else if (exception is ArgumentException || exception is ArgumentNullException)
                {
                    WriteDebug(string.Format(Resources.ArgumentException));
                    targetErrorCategory = ErrorCategory.InvalidArgument;
                }

                var errorRecord = new ErrorRecord(targetEx, targetErrorId, targetErrorCategory, null);
                WriteError(errorRecord);
            }
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            InitializeAzureBackupCmdlet();
        }

        public CmdletModel.JobBase GetJobObject(string jobId)
        {
            return JobConversions.GetPSJob(ServiceClientAdapter.GetJob(jobId));
        }

        public List<CmdletModel.JobBase> GetJobObject(IList<string> jobIds)
        {
            List<CmdletModel.JobBase> result = new List<CmdletModel.JobBase>();
            foreach (string jobId in jobIds)
            {
                result.Add(GetJobObject(jobId));
            }
            return result;
        }

        public BackUpOperationStatusResponse WaitForOperationCompletionUsingStatusLink(
                                              string statusUrlLink,
                                              Func<string, BackUpOperationStatusResponse> serviceClientMethod)
        {
            // using this directly because it doesn't matter which function we use.
            // return type is same and currently we are using it in only two places.
            // protected item and policy.
            BackUpOperationStatusResponse response = serviceClientMethod(statusUrlLink);

            while (
                response != null &&
                response.OperationStatus != null &&
                response.OperationStatus.Status == OperationStatusValues.InProgress.ToString())
            {
                WriteDebug("Tracking operation completion using status link: " + statusUrlLink);
                TestMockSupport.Delay(_defaultSleepForOperationTracking * 1000);
                response = serviceClientMethod(statusUrlLink);
            }

            return response;
        }

        protected void HandleCreatedJob(BaseRecoveryServicesJobResponse itemResponse, string operationName)
        {
            WriteDebug(Resources.TrackingOperationStatusURLForCompletion +
                            itemResponse.AzureAsyncOperation);

            var response = WaitForOperationCompletionUsingStatusLink(
                                            itemResponse.AzureAsyncOperation,
                                            ServiceClientAdapter.GetProtectedItemOperationStatusByURL);

            if (response != null && response.OperationStatus != null)
            {
            WriteDebug(Resources.FinalOperationStatus + response.OperationStatus.Status);

            if (response.OperationStatus.Properties != null &&
                   ((OperationStatusJobExtendedInfo)response.OperationStatus.Properties).JobId != null)
            {
                var jobStatusResponse = (OperationStatusJobExtendedInfo)response.OperationStatus.Properties;
                WriteObject(GetJobObject(jobStatusResponse.JobId));
            }

                if (response.OperationStatus.Status == OperationStatusValues.Failed &&
                    response.OperationStatus.OperationStatusError != null)
            {
                var errorMessage = string.Format(
                    Resources.OperationFailed,
                    operationName,
                    response.OperationStatus.OperationStatusError.Code,
                    response.OperationStatus.OperationStatusError.Message);
                throw new Exception(errorMessage);
            }
        }
    }
}
}
