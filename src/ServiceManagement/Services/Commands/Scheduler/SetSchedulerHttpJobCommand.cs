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
using System.Collections;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Scheduler;
using Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Model;

namespace Microsoft.WindowsAzure.Commands.Scheduler
{
    /// <summary>
    /// Cmdlet to patch HttpJob
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSchedulerHttpJob"), OutputType(typeof(string))]
    public class SetSchedulerHttpJobCommand : SchedulerBaseCmdlet
    {
        const string RequiredParamSet = "Required";
        const string PutPostParamSet = "PutPost";
        const string RecurringParamSet = "Recurring";
        const string AuthParamSet = "Authentication";

        [Parameter(Mandatory = true, ParameterSetName = RequiredParamSet, HelpMessage = "The location name.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RequiredParamSet, HelpMessage = "The job collection name.")]
        [ValidateNotNullOrEmpty]
        public string JobCollectionName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RequiredParamSet, HelpMessage = "The job name.")]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "The Method for Http and Https Action types (GET, PUT, POST, HEAD or DELETE).")]
        [ValidateSet("GET", "PUT", "POST", "HEAD", "DELETE", IgnoreCase = true)]
        public string Method { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "The Uri for job action.")]
        public Uri URI { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = PutPostParamSet, HelpMessage = "The Body for PUT and POST job actions.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "The Body for PUT and POST job actions.")]
        [ValidateNotNullOrEmpty]
        public string RequestBody { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "The Start Time")]
        [ValidateNotNullOrEmpty]
        public DateTime? StartTime { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RecurringParamSet, HelpMessage = "Interval of the recurrence at the given frequency")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "Interval of the recurrence at the given frequency")]
        [ValidateNotNullOrEmpty]
        public int? Interval { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RecurringParamSet, HelpMessage = "The frequency of recurrence")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "The frequency of recurrence")]
        [ValidateSet("Minute", "Hour", "Day", "Week", "Month", "Year", IgnoreCase = true)]
        public string Frequency { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RecurringParamSet, HelpMessage = "Count of occurrences that will execute. Optional. Default will recur infinitely")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "Count of occurrences that will execute. Optional. Default will recur infinitely")]
        public int? ExecutionCount { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RecurringParamSet, HelpMessage = "The End Time")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "The End Time")]
        [ValidateNotNullOrEmpty]
        public DateTime? EndTime { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The job state.")]
        [ValidateSet("Enabled", "Disabled", IgnoreCase = true)]
        public string JobState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The header collection.")]
        public Hashtable Headers { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "The Method for Http and Https Action types (GET, PUT, POST, HEAD or DELETE).")]
        [ValidateSet("GET", "PUT", "POST", "HEAD", "DELETE", IgnoreCase = true)]
        public string ErrorActionMethod { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "The Uri for error job action.")]
        public Uri ErrorActionURI { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "The Body for PUT and POST job actions.")]
        [ValidateNotNullOrEmpty]
        public string ErrorActionRequestBody { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The header collection.")]
        public Hashtable ErrorActionHeaders { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = RequiredParamSet, HelpMessage = "The Storage account name.")]
        [ValidateNotNullOrEmpty]
        public string ErrorActionStorageAccount { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = RequiredParamSet, HelpMessage = "The Storage Queue name.")]
        [ValidateNotNullOrEmpty]
        public string ErrorActionStorageQueue { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = RequiredParamSet, HelpMessage = "The SAS token for storage queue.")]
        [ValidateNotNullOrEmpty]
        public string ErrorActionSASToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "The Body for Storage job actions.")]
        [ValidateNotNullOrEmpty]
        public string ErrorActionQueueMessageBody { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false, ParameterSetName = AuthParamSet, HelpMessage = "The Http Authentication type (None or ClientCertificate).")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "The Http Authentication type (None or ClientCertificate).")]
        [ValidateSet("None", "ClientCertificate", "ActiveDirectoryOAuth", "Basic", IgnoreCase = true)]
        public string HttpAuthenticationType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = AuthParamSet, HelpMessage = "The pfx of client certificate.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "The pfx of client certificate.")]
        [ValidateNotNullOrEmpty]
        public object ClientCertificatePfx { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = AuthParamSet, HelpMessage = "The password for the pfx.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ParameterSetName = RequiredParamSet, HelpMessage = "The password for the pfx.")]
        [ValidateNotNullOrEmpty]
        public string ClientCertificatePassword { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            string status = string.Empty;
            if (PassThru.IsPresent)
            {
                WriteObject(SMClient.PatchHttpJob(new PSCreateJobParams
                {
                    Region = Location,
                    JobCollectionName = JobCollectionName,
                    JobName = JobName,
                    Method = Method,
                    Headers = Headers,
                    Uri = URI,
                    Body = RequestBody,
                    StartTime = StartTime,
                    Interval = Interval,
                    Frequency = Frequency,
                    EndTime = EndTime,
                    ExecutionCount = ExecutionCount,
                    JobState = JobState,
                    ErrorActionMethod = ErrorActionMethod,
                    ErrorActionBody = ErrorActionRequestBody,
                    ErrorActionHeaders = ErrorActionHeaders,
                    ErrorActionUri = ErrorActionURI,
                    ErrorActionStorageAccount = ErrorActionStorageAccount,
                    ErrorActionQueueName = ErrorActionStorageQueue,
                    ErrorActionQueueBody = ErrorActionQueueMessageBody,
                    ErrorActionSasToken = ErrorActionSASToken,
                    HttpAuthType = HttpAuthenticationType ?? string.Empty,
                    ClientCertPfx = ClientCertificatePfx == null ? null : SchedulerUtils.GetCertData(this.ResolvePath(ClientCertificatePfx.ToString()), ClientCertificatePassword),
                    ClientCertPassword = ClientCertificatePassword
                }, out status), true);
                WriteObject(status);
            }
            else
            {
                SMClient.PatchHttpJob(new PSCreateJobParams
                {
                    Region = Location,
                    JobCollectionName = JobCollectionName,
                    JobName = JobName,
                    Method = Method,
                    Headers = Headers,
                    Uri = URI,
                    Body = RequestBody,
                    StartTime = StartTime,
                    Interval = Interval,
                    Frequency = Frequency,
                    EndTime = EndTime,
                    ExecutionCount = ExecutionCount,
                    JobState = JobState,
                    ErrorActionMethod = ErrorActionMethod,
                    ErrorActionBody = ErrorActionRequestBody,
                    ErrorActionHeaders = ErrorActionHeaders,
                    ErrorActionUri = ErrorActionURI,
                    ErrorActionStorageAccount = ErrorActionStorageAccount,
                    ErrorActionQueueName = ErrorActionStorageQueue,
                    ErrorActionQueueBody = ErrorActionQueueMessageBody,
                    ErrorActionSasToken = ErrorActionSASToken,
                    HttpAuthType = HttpAuthenticationType ?? string.Empty,
                    ClientCertPfx = ClientCertificatePfx == null ? null : SchedulerUtils.GetCertData(this.ResolvePath(ClientCertificatePfx.ToString()), ClientCertificatePassword),
                    ClientCertPassword = ClientCertificatePassword
                }, out status);
                WriteDebug(status);
            }
        }
    }
}
