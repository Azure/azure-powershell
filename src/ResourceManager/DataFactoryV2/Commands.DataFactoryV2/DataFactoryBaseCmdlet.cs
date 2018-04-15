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
using System.Runtime.InteropServices;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    public abstract class DataFactoryBaseCmdlet : AzureRMCmdlet
    {
        private DataFactoryClient dataFactoryClient;

        internal DataFactoryClient DataFactoryClient
        {
            get
            {
                if (this.dataFactoryClient == null)
                {
                    this.dataFactoryClient = new DataFactoryClient(DefaultContext);
                }
                return this.dataFactoryClient;
            }
            set
            {
                this.dataFactoryClient = value;
            }
        }

        protected override void WriteExceptionError(Exception exception)
        {
            var castErrorException = exception as ErrorResponseException;
            if (castErrorException != null)
            {
                if (castErrorException.Body == null && !string.IsNullOrWhiteSpace(castErrorException.Response.Content))
                {
                    castErrorException.Body = new ErrorResponse(string.Empty, castErrorException.Response.Content);
                }

                // Override the default error message into a formatted message which contains Request Id
                exception = castErrorException.CreateFormattedException();
            }
            else 
            {
                var castArgException = exception as ArgumentOutOfRangeException;
                if (castArgException != null)
                {
                    // Add resource naming rules page link into a formatted message
                    exception = castArgException.CreateFormattedException();
                }
                else if (exception is CloudException)
                {
                    var castCloudException = exception as CloudException;
                    exception = castCloudException.CreateFormattedException();
                }
                else
                {
                    var castAggrException = exception as AggregateException;
                    if (castAggrException != null && castAggrException.InnerExceptions != null)
                    {
                        foreach (Exception innerEx in castAggrException.InnerExceptions)
                        {
                            this.WriteExceptionError(innerEx);
                        }

                        return;
                    }
                }
            }

            base.WriteExceptionError(exception);
        }

        protected string ConvertToUnsecureString(System.Security.SecureString securePassword)
        {
            var unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
