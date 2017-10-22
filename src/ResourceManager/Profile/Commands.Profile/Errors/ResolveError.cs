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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Common;

namespace Microsoft.Azure.Commands.Profile.Errors
{
    [Alias("Resolve-Error")]
    [Cmdlet(VerbsDiagnostic.Resolve, "AzureRmError", DefaultParameterSetName = ResolveError.AnyErrorParameterSet)]
    [OutputType(typeof(AzureErrorRecord))]
    [OutputType(typeof(AzureExceptionRecord))]
    [OutputType(typeof(AzureRestExceptionRecord))]
    public class ResolveError : AzureRMCmdlet
    {
        public const string AnyErrorParameterSet = "AnyErrorParameterSet";
        public const string LastErrorParameterSet = "LastErrorParameterSet";

        [Parameter(Mandatory =false, Position =0, HelpMessage ="The error records to resolve", ValueFromPipeline =true, ParameterSetName = AnyErrorParameterSet)]
        public ErrorRecord[] Error { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The last error", ParameterSetName = LastErrorParameterSet)]
        public SwitchParameter Last { get; set; }

        protected override IAzureContext DefaultContext
        {
            get
            {
                return null;
            }
        }


        public override void ExecuteCmdlet()
        {
            IEnumerable<ErrorRecord> records = null;
            base.ExecuteCmdlet();
            switch(ParameterSetName)
            {
                case LastErrorParameterSet:
                    var errors = GetErrorVariable();
                    if (errors != null)
                    {
                        var error = errors.FirstOrDefault();
                        if (error != null)
                        {
                            records = new ErrorRecord[] { error };
                        }
                    }
                    break;
                default:
                    records = Error ?? GetErrorVariable();
                    break;
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

        private IEnumerable<ErrorRecord> GetErrorVariable()
        {
            IEnumerable<ErrorRecord> result = null;
            var errors = GetVariableValue("global:Error", null) as IEnumerable;
            if (errors != null)
            {
                result = errors.OfType<ErrorRecord>();
            }

            return result;
        }

        private void HandleError(ErrorRecord record)
        {
            if (record != null)
            {
                if (record.Exception != null)
                {
                    HandleException(record.Exception, record);
                }
                else
                {
                    WriteObject(new AzureErrorRecord(record));
                }
            }
        }

        private void HandleException(Exception exception, ErrorRecord record, bool inner = false)
        {
            var aggregate = exception as AggregateException;
            var hyakException = exception as Hyak.Common.CloudException;
            var restException = exception as Microsoft.Rest.Azure.CloudException;
            if (aggregate != null)
            {
                foreach (var innerException in aggregate.InnerExceptions.Where(e => e!=null))
                {
                    HandleException(innerException, record, true);
                }
            }
            else if (hyakException != null)
            {
                WriteObject(new AzureRestExceptionRecord(hyakException, record, inner));
            }
            else if (restException != null)
            {
                WriteObject(new AzureRestExceptionRecord(restException, record, inner));
            }
            else
            {
                WriteObject(new AzureExceptionRecord(exception, record, inner));
                if (exception.InnerException != null)
                {
                    HandleException(exception.InnerException, record, true);
                }
            }
        }
    }
}
