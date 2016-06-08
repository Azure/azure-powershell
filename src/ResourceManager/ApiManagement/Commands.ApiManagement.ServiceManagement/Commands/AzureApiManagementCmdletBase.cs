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
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using ResourceManager.Common;
    using System;
    using System.Management.Automation;

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
                WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.InvalidArgument, null));
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

        protected void WriteProgress(TenantConfigurationLongRunningOperation operation)
        {
            WriteProgress(new ProgressRecord(0, operation.OperationName, operation.Status.ToString()));
        }

        /// <summary>
        /// TODO: Revert to standard long running operation once /operationResults endpoint start returning 
        /// 202 Code for not Completed Operation.
        /// </summary>
        /// <see cref="https://msdn.microsoft.com/en-us/library/azure/dn781420.aspx#GetOperation"/>
        protected TenantConfigurationLongRunningOperation WaitForOperationToComplete(TenantConfigurationLongRunningOperation longRunningOperation)
        {
            do
            {
                var retryAfter = longRunningOperation.RetryAfter == null || longRunningOperation.RetryAfter.Value < LongRunningOperationDefaultTimeout ?
                    LongRunningOperationDefaultTimeout : longRunningOperation.RetryAfter.Value;

                WriteProgress(longRunningOperation);

                TestMockSupport.Delay(retryAfter);

                // the operation link is present in the first call to Operation. 
                // The next calls to /operationResults do not return Location header, hence preserving this value across calls
                // this is the service side bug.
                var operationStatusLink = longRunningOperation.OperationLink;

                longRunningOperation = Client.GetLongRunningOperationStatus(longRunningOperation);
                longRunningOperation.OperationLink = operationStatusLink;

                WriteVerboseWithTimestamp(Resources.VerboseGetOperationStateTimeoutMessage,
                   longRunningOperation.OperationResult.State);
            } while (longRunningOperation.OperationResult.State == TenantConfigurationState.InProgress);

            return longRunningOperation;
        }

        protected void ExecuteTenantConfigurationLongRunningCmdletWrap(
            Func<TenantConfigurationLongRunningOperation> func,
            bool passThru = false)
        {
            try
            {
                var longRunningOperation = func();

                longRunningOperation = WaitForOperationToComplete(longRunningOperation);
                if (longRunningOperation.OperationResult.State != TenantConfigurationState.Succeeded)
                {
                    var errorMessage = longRunningOperation.OperationResult.Error != null ?
                        longRunningOperation.OperationResult.Error.Message
                        : longRunningOperation.OperationName;

                    WriteObject(longRunningOperation.OperationResult);
                    if (longRunningOperation.OperationResult.Error != null)
                    {
                        WriteObject(longRunningOperation.OperationResult.Error);
                        if (longRunningOperation.OperationResult.Error.Details != null)
                        {
                            WriteObject(longRunningOperation.OperationResult.Error.Details, true);
                        }
                    }

                    WriteErrorWithTimestamp(errorMessage);
                }
                else if (passThru)
                {
                    WriteObject(longRunningOperation.OperationResult);
                }
            }
            catch (ArgumentException ex)
            {
                WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.InvalidArgument, null));
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }
    }
}