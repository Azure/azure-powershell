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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Collections;

namespace Microsoft.Azure.Commands.Profile.Errors
{
    [Cmdlet(VerbsDiagnostic.Resolve, "AzureRmError")]
    [OutputType(typeof(AzureErrorRecord))]
    [OutputType(typeof(AzureExceptionRecord))]
    [OutputType(typeof(AzureRestExceptionRecord))]
    public class ResolveError : AzurePSCmdlet
    {
        [Parameter(Mandatory =false, Position =0, HelpMessage ="The error records to resolve")]
        public ErrorRecord[] Error { get; set; }
        protected override IAzureContext DefaultContext
        {
            get
            {
                return null;
            }
        }

        protected override void InitializeQosEvent()
        {
            
        }

        protected override void PromptForDataCollectionProfileIfNotExists()
        {
            
        }

        protected override void SaveDataCollectionProfile()
        {
           
        }


        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            IEnumerable<ErrorRecord> records = Error;
            if (records == null)
            {
                var errors = GetVariableValue("global:Error") as IEnumerable;
                records = errors?.OfType<ErrorRecord>();

            }
            if (records != null)
            {
                foreach (var error in records)
                {
                    ErrorRecord record = error as ErrorRecord;
                    HandleError(record);
                }
            }
        }

        void HandleError(ErrorRecord record)
        {
            if (record.Exception != null)
            {
                HandleException(record.Exception);
            }
            else
            {
                WriteObject(new AzureErrorRecord(record));
            }
        }

        void HandleException(Exception exception, bool inner = false)
        {
            var aggregate = exception as AggregateException;
            var hyakException = exception as Hyak.Common.CloudException;
            var restException = exception as Microsoft.Rest.Azure.CloudException;
            if (aggregate != null)
            {
                foreach (var innerException in aggregate.InnerExceptions)
                {
                    HandleException(innerException, true);
                }
            }
            else if (hyakException != null)
            {
                WriteObject(new AzureRestExceptionRecord(hyakException, inner));
            }
            else if (restException != null)
            {
                WriteObject(new AzureRestExceptionRecord(restException, inner));
            }
            else
            {
                WriteObject(new AzureExceptionRecord(exception, inner));
                if (exception.InnerException != null)
                {
                    HandleException(exception.InnerException, true);
                }
            }
        }
    }
}
