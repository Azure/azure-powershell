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
    }
}