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
using System.Management.Automation;
using System.Collections.Generic;
using System.Xml;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using System.Threading;
using Hyak.Common;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using System.Net;
using Microsoft.WindowsAzure.Management.Scheduler;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    public abstract class AzureBackupCmdletBase : AzurePSCmdlet
    {
        /// <summary>
        /// ResourceGroup context for the operation
        /// </summary>
        private string resourceGroupName { get; set; }

        /// <summary>
        /// Resource context for the operation
        /// </summary>
        private string resourceName { get; set; }

        /// <summary>
        /// Resource context for the operation
        /// </summary>
        private string location { get; set; }

        /// <summary>
        /// Client request id.
        /// </summary>
        private string clientRequestId;

        /// <summary>
        /// Azure backup client.
        /// </summary>
        private BackupServicesManagementClient azureBackupClient;

        /// <summary>
        /// Cancellation Token Source
        /// </summary>
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        protected CancellationToken CmdletCancellationToken;

        /// <summary>
        /// Get Azure backup client.
        /// </summary>
        protected BackupServicesManagementClient AzureBackupClient
        {
            get
            {
                if (this.azureBackupClient == null)
                {
                    // Temp code to be able to test internal env.
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    var cloudServicesClient = AzureSession.ClientFactory.CreateClient<CloudServiceManagementClient>(Profile, Profile.Context.Subscription, AzureEnvironment.Endpoint.ResourceManager);
                    this.azureBackupClient = AzureSession.ClientFactory.CreateCustomClient<BackupServicesManagementClient>(resourceName, resourceGroupName, cloudServicesClient.Credentials, cloudServicesClient.BaseUri);
                }

                return this.azureBackupClient;
            }
        }

        protected void RefreshClientRequestId()
        {
            clientRequestId = Guid.NewGuid().ToString() + "-" + DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ssZ") + "-PS";
        }

        public void InitializeAzureBackupCmdlet(string rgName, string rName, string locationName)
        {
            resourceGroupName = rgName;
            resourceName = rName;
            location = locationName;

            RefreshClientRequestId();
            WriteDebug(string.Format("Initialized AzureBackup Cmdlet, ClientRequestId: {0}, ResourceGroupName: {1}, ResourceName : {2}", this.clientRequestId, resourceGroupName, resourceName));

            CmdletCancellationToken = cancellationTokenSource.Token;
            AzureBackupCmdletHelper cmdHelper = new AzureBackupCmdletHelper(this);
        }

        protected void ExecutionBlock(Action execAction)
        {
            try
            {
                execAction();
            }
            catch (Exception exception)
            {
                WriteDebug(String.Format("Caught exception, type: {0}", exception.GetType()));
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
                WriteDebug("Handling aggregate exception");
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
                        WriteDebug(String.Format("Received CloudException, StatusCode: {0}", cloudEx.Response.StatusCode));

                        targetEx = new Exception(Resources.ResourceNotFoundMessage);
                        targetErrorCategory = ErrorCategory.InvalidArgument;
                    }
                    else if (cloudEx.Error != null)
                    {
                        WriteDebug(String.Format("Received CloudException, ErrorCode: {0}, Message: {1}", cloudEx.Error.Code, cloudEx.Error.Message));

                        targetErrorId = cloudEx.Error.Code;
                        targetErrorCategory = ErrorCategory.InvalidOperation;
                    }
                }
                else if (exception is WebException)
                {
                    var webEx = exception as WebException;
                    WriteDebug(string.Format("Received WebException, Response: {0}, Status: {1}", webEx.Response, webEx.Status));

                    targetErrorCategory = ErrorCategory.ConnectionError;
                }
                else if (exception is ArgumentException || exception is ArgumentNullException)
                {
                    WriteDebug(string.Format("Received ArgumentException"));
                    targetErrorCategory = ErrorCategory.InvalidArgument;
                }

                var errorRecord = new ErrorRecord(targetEx, targetErrorId, targetErrorCategory, null);
                WriteError(errorRecord);
            }
        }

        protected CustomRequestHeaders GetCustomRequestHeaders()
        {
            var hdrs = new CustomRequestHeaders()
            {
                // ClientRequestId is a unique ID for every request to backend service.
                ClientRequestId = this.clientRequestId,
            };

            return hdrs;
        }
    }
}

