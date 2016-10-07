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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using ResourcesNS = Microsoft.Azure.Management.Resources;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Base class for Recovery Services Backup cmdlets
    /// </summary>
    public abstract class RecoveryServicesBackupCmdletBase : AzureRMCmdlet
    {
        /// <summary>
        /// Service client adapter is used to make calls to the backend service
        /// </summary>
        protected ServiceClientAdapter ServiceClientAdapter { get; set; }

        /// <summary>
        /// Resource management client is used to make calls to the Compute service
        /// </summary>
        protected ResourcesNS.ResourceManagementClient RmClient { get; set; }

        /// <summary>
        /// Initializes the service clients and the logging utility
        /// </summary>
        protected void InitializeAzureBackupCmdlet()
        {
            ServiceClientAdapter = new ServiceClientAdapter(DefaultContext);

            WriteDebug("InsideRestore. going to create ResourceManager Client");
            RmClient = AzureSession.ClientFactory.CreateClient<ResourcesNS.ResourceManagementClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager);

            WriteDebug("Client Created successfully");

            Logger.Instance = new Logger(WriteWarning, WriteDebug, WriteVerbose, ThrowTerminatingError);
        }

        protected override void SetupHttpClientPipeline()
        {
            base.SetupHttpClientPipeline();
            AzureSession.ClientFactory.AddHandler(new RpNamespaceHandler(ServiceClientAdapter.ResourceProviderNamespace));
            AzureSession.ClientFactory.AddHandler(new ClientRequestIdHandler());
            //AzureSession.ClientFactory.AddHandler(new CultureHandler());
        }

        /// <summary>
        /// Wrapper method which executes the cmdlet processing blocks. 
        /// Catches and logs any exception occuring during the execution.
        /// </summary>
        /// <param name="action">Delegate representing the cmdlet processing block</param>
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
        /// <param name="ex">Exception thrown by the client</param>
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
                    if (cloudEx.Response != null && cloudEx.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        WriteDebug(String.Format(Resources.CloudExceptionCodeNotFound, cloudEx.Response.StatusCode));

                        targetEx = new Exception(Resources.ResourceNotFoundMessage);
                        targetErrorCategory = ErrorCategory.InvalidArgument;
                    }
                    else if (cloudEx.Body != null)
                    {
                        WriteDebug(String.Format(Resources.CloudException, cloudEx.Body.Code, cloudEx.Body.Message));

                        targetErrorId = cloudEx.Body.Code;
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

        /// <summary>
        /// Get the job PS model after fetching the job object from the service given the job ID.
        /// </summary>
        /// <param name="jobId">ID of the job to be fetched</param>
        /// <returns></returns>
        public CmdletModel.JobBase GetJobObject(string jobId)
        {
            return JobConversions.GetPSJob(ServiceClientAdapter.GetJob(jobId));
        }

        /// <summary>
        /// Gets list of job PS models after fetching the job objects from the service given the list of job IDs.
        /// </summary>
        /// <param name="jobIds">List of IDs of jobs to be fetched</param>
        /// <returns></returns>
        public List<CmdletModel.JobBase> GetJobObject(IList<string> jobIds)
        {
            List<CmdletModel.JobBase> result = new List<CmdletModel.JobBase>();
            foreach (string jobId in jobIds)
            {
                result.Add(GetJobObject(jobId));
            }
            return result;
        }

        /// <summary>
        /// Based on the response from the service, handles the job created in the service appropriately.
        /// </summary>
        /// <param name="jobResponse">Response from service</param>
        /// <param name="operationName">Name of the operation</param>
        protected void HandleCreatedJob(Microsoft.Rest.Azure.AzureOperationResponse response, string operationName)
        {
            WriteDebug(Resources.TrackingOperationStatusURLForCompletion +
                            response.Response.Headers.GetAzureAsyncOperationHeader());

            var operationStatus = TrackingHelpers.GetOperationStatus(
                response,
                operationId => ServiceClientAdapter.GetProtectedItemOperationStatus(operationId));

            if (response != null && operationStatus != null)
            {
                WriteDebug(Resources.FinalOperationStatus + operationStatus.Status);

                if (operationStatus.Properties != null)
                {
                    var jobExtendedInfo =
                        (OperationStatusJobExtendedInfo)operationStatus.Properties;

                    if (jobExtendedInfo.JobId != null)
                    {
                        var jobStatusResponse =
                            (OperationStatusJobExtendedInfo)operationStatus.Properties;
                        WriteObject(GetJobObject(jobStatusResponse.JobId));
                    }
                }

                if (operationStatus.Status == OperationStatusValues.Failed &&
                    operationStatus.Error != null)
                {
                    var errorMessage = string.Format(
                        Resources.OperationFailed,
                        operationName,
                        operationStatus.Error.Code,
                        operationStatus.Error.Message);
                    throw new Exception(errorMessage);
                }
            }
        }
    }
}
