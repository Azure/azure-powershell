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
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement;
    using ResourceManager.Common;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    abstract public class AzureApiManagementCmdletBase : AzureRMCmdlet
    {
        protected static TimeSpan LongRunningOperationDefaultTimeout = TimeSpan.FromMinutes(1);

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

        protected override void ProcessRecord()
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
    }
}