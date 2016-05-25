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
using System.Runtime.ExceptionServices;
using System.Threading;
using Microsoft.Azure.Commands.MachineLearning.Extensions;
using Microsoft.Azure.Commands.MachineLearning.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ErrorResponses;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Rest.Azure;
using PSResourceManagerModels = Microsoft.Azure.Commands.Resources.Models;

namespace Microsoft.Azure.Commands.MachineLearning
{
    public abstract class WebServicesCmdletBase : AzureRMCmdlet
    {
        public const string CommandletSuffix = "AzureRmMlWebService";

        private PSResourceManagerModels.ResourcesClient resourcesClient;

        private WebServicesClient webServicesClient;

        /// <summary>
        /// The cancellation source.
        /// </summary>
        private CancellationTokenSource cancellationSource;
        
        protected CancellationToken? CancellationToken
        {
            get
            {
                return this.cancellationSource == null ? null : (CancellationToken?)this.cancellationSource.Token;
            }
        }

        protected string SubscriptionId { get; set; }

        public PSResourceManagerModels.ResourcesClient ResourceClient
        {
            get
            {
                if (this.resourcesClient == null)
                {
                    this.resourcesClient = new PSResourceManagerModels.ResourcesClient(DefaultProfile.Context)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return this.resourcesClient;
            }
            set { this.resourcesClient = value; }
        }
        
        public WebServicesClient WebServicesClient
        {
            get
            {
                if (this.webServicesClient == null)
                {
                    this.webServicesClient = new WebServicesClient(DefaultProfile.Context)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return this.webServicesClient;
            }
            set { this.webServicesClient = value; }
        }

        #region Processing life cycle

        protected override void BeginProcessing()
        {
            try
            {
                if (this.cancellationSource == null)
                {
                    this.cancellationSource = new CancellationTokenSource();
                }

                this.SubscriptionId = this.DefaultProfile.Context.Subscription.Id.ToString();
                base.BeginProcessing();
            }
            catch (Exception ex)
            {
                if (ex.IsFatal())
                {
                    ThrowTerminatingError(new ErrorRecord(ex, string.Empty, ErrorCategory.InvalidOperation, this.SubscriptionId));
                }
                
                var capturedException = ExceptionDispatchInfo.Capture(ex);
                this.HandleException(capturedException: capturedException);
            }
        }

        protected override void EndProcessing()
        {
            try
            {
                base.EndProcessing();
            }
            catch (Exception ex)
            {
                if (ex.IsFatal())
                {
                    ThrowTerminatingError(new ErrorRecord(ex, string.Empty, ErrorCategory.InvalidOperation, this));
                }

                var capturedException = ExceptionDispatchInfo.Capture(ex);
                this.HandleException(capturedException: capturedException);
            }
            finally
            {
                this.DisposeOfCancellationSource();
            }
        }

        protected override void StopProcessing()
        {
            try
            {
                if (this.cancellationSource != null && 
                    !this.cancellationSource.IsCancellationRequested)
                {
                    this.cancellationSource.Cancel();
                }

                base.StopProcessing();
            }
            catch (Exception ex)
            {
                if (ex.IsFatal())
                {
                    throw;
                }

                var capturedException = ExceptionDispatchInfo.Capture(ex);
                this.HandleException(capturedException: capturedException);
            }
            finally
            {
                this.DisposeOfCancellationSource();
            }
        }

        /// <summary>
        /// Actual cmdlet logic goes here in child classes
        /// </summary>
        protected virtual void RunCmdlet()
        {
            // No op
        }

        public override void ExecuteCmdlet()
        {
            try
            {
                base.ExecuteCmdlet();
                this.RunCmdlet();
            }
            catch (Exception ex)
            {
                if (ex.IsFatal())
                {
                    throw;
                }

                var capturedException = ExceptionDispatchInfo.Capture(ex);
                this.HandleException(capturedException: capturedException);
            }
        }

        #endregion

        private void DisposeOfCancellationSource()
        {
            if (this.cancellationSource != null)
            {
                if (!this.cancellationSource.IsCancellationRequested)
                {
                    this.cancellationSource.Cancel();
                }

                this.cancellationSource.Dispose();
                this.cancellationSource = null;
            }
        }

        /// <summary>
        /// Provides specialized exception handling.
        /// </summary>
        /// <param name="capturedException">The captured exception</param>
        private void HandleException(ExceptionDispatchInfo capturedException)
        {
            try
            {
                ErrorRecord errorRecord;
                var cloudException = capturedException.SourceException as CloudException;
                if (cloudException != null)
                {
                    errorRecord = cloudException.ToErrorRecord();
                }
                else
                {
                    var errorResponseException = 
                            capturedException.SourceException as ErrorResponseMessageException;
                    if (errorResponseException != null)
                    {
                        errorRecord = errorResponseException.ToErrorRecord();
                    }
                    else
                    {
                        var aggregateException = 
                                capturedException.SourceException as AggregateException;
                        if (aggregateException != null)
                        {
                            errorResponseException = 
                                aggregateException.InnerException as ErrorResponseMessageException;
                            if (errorResponseException != null)
                            {
                                errorRecord = errorResponseException.ToErrorRecord();
                            }
                            else
                            {
                                errorRecord = aggregateException.InnerException.ToErrorRecord();
                            }
                        }
                        else
                        {
                            errorRecord = capturedException.SourceException.ToErrorRecord();
                        }
                    }
                }
                
                this.WriteError(errorRecord);
            }
            finally
            {
                this.DisposeOfCancellationSource();
            }
        }
    }
}
