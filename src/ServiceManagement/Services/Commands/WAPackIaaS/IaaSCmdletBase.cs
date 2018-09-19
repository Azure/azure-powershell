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
using System.Collections.Generic;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS
{
    public abstract class IaaSCmdletBase : AzureSMCmdlet, ILogger
    {
        private IRequestChannel requestChannel;

        private WebClientFactory webClientFactory;

        private Subscription subscription;

        internal WebClientFactory WebClientFactory
        {
            get
            {
                if (this.webClientFactory == null)
                {
                    this.webClientFactory = new WebClientFactory(this.Subscription, this.RequestChannel);
                }

                return this.webClientFactory;
            }
        }

        internal IRequestChannel RequestChannel
        {
            get
            {
                if (this.requestChannel == null)
                {
                    this.requestChannel = new WAPackIaaSRequestChannel(this);
                }

                return this.requestChannel;
            }
        }

        internal Subscription Subscription
        {
            get
            {
                if (subscription == null)
                {
                    if (Profile.Context.Subscription != null)
                    {
                        subscription = new Subscription(Profile.Context.Subscription);
                    }
                }
                
                return subscription;
            }
        }

        protected virtual void WriteErrorDetails(Exception exception)
        {
            WriteError(new ErrorRecord(exception, string.Empty, ErrorCategory.CloseError, null));
        }

        protected virtual bool GenerateCmdletOutput(IEnumerable<object> results)
        {
            var ret = true;
            foreach (var result in results)
            {
                try
                {
                    WriteObject(result);
                }
                catch (PipelineStoppedException)
                {
                    ret = false;
                }
            }

            return ret;
        }

        public void Log(LogLevel logLevel, string message)
        {
            switch (logLevel)
            {
                case LogLevel.Verbose:
                    WriteVerbose(message);
                    break;

                case LogLevel.Debug:
                    WriteDebug(message);
                    break;

                default:
                    WriteDebug(String.Format("Logging level {0} not supported.", logLevel));
                    break;
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected static String ExtractSecureString(SecureString secureString)
        {
            var pointer = IntPtr.Zero;
            try
            {
                pointer = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(pointer);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(pointer);
            }
        }

        internal JobInfo WaitForJobCompletion(Guid? job)
        {
            JobInfo jobInfo = new JobOperations(this.WebClientFactory).WaitOnJob(job.Value);
            if (jobInfo.jobStatus != JobStatusEnum.CompletedSuccessfully)
            {
                this.WriteErrorDetails(new Exception(jobInfo.errorMessage));
            }
            return jobInfo;
        }
    }
}
