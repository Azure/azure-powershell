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

namespace Microsoft.Azure.Commands.Scheduler.Cmdlets
{
    using System;
    using System.Collections;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Scheduler.Models;
    using Microsoft.Azure.Commands.Scheduler.Properties;
    using Microsoft.Azure.Commands.Scheduler.Utilities;
    using Microsoft.Azure.Management.Scheduler.Models;

    /// <summary>
    /// Creates new http job.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSchedulerHttpJob", SupportsShouldProcess = true), OutputType(typeof(PSSchedulerJobDefinition))]
    public class NewAzureSchedulerHttpJobCommand : JobBaseCmdlet, IDynamicParameters
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The targeted resource group for job.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the job collection.")]
        [Alias("Name", "ResourceName")]
        [ValidateNotNullOrEmpty]
        public string JobCollectionName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the job")]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Method for Http and Https Action types (GET, PUT, POST, HEAD or DELETE).")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.HttpMethodGET, Constants.HttpMethodPUT, Constants.HttpMethodPOST, Constants.HttpMethodDELETE, IgnoreCase = true)]
        public string Method { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Uri for job action.")]
        [ValidateNotNullOrEmpty]
        public Uri Uri { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The Body for PUT and POST job actions.")]
        [ValidateNotNullOrEmpty]
        public string RequestBody { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The header collection.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Headers { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The Http Authentication type (None, Basic, ClientCertificate, or OAuth).")]
        [ValidateSet(Constants.HttpAuthenticationNone, Constants.HttpAuthenticationClientCertificate, Constants.HttpAuthenticationActiveDirectoryOAuth, Constants.HttpAuthenticationBasic, IgnoreCase = true)]
        public string HttpAuthenticationType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The start Time.")]
        [ValidateNotNullOrEmpty]
        public DateTime? StartTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Interval of the recurrence at the given frequency.")]
        [ValidateNotNullOrEmpty]
        public int? Interval { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The frequency of recurrence.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.FrequencyTypeMinute, Constants.FrequencyTypeHour, Constants.FrequencyTypeDay, Constants.FrequencyTypeWeek, Constants.FrequencyTypeMonth, IgnoreCase = true)]
        public string Frequency { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The end Time")]
        [ValidateNotNullOrEmpty]
        public DateTime? EndTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Count of occurrences that will execute. Optional. Default will recur infinitely.")]
        [ValidateNotNullOrEmpty]
        public int? ExecutionCount { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The job state.")]
        [ValidateSet(Constants.JobStateEnabled, Constants.JobStateDisabled, IgnoreCase = true)]
        public string JobState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Error action job settings.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.HttpAction, Constants.HttpsAction, Constants.StorageQueueAction, Constants.ServiceBusQueueAction, Constants.ServiceBusTopicAction, IgnoreCase = true)]
        public string ErrorActionType { get; set; }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var httpJobAction = new PSHttpJobActionParams()
            {
                RequestMethod = this.Method,
                Uri = this.Uri,
                RequestBody = this.RequestBody,
                RequestHeaders = this.Headers,
                RequestAuthentication = GetAuthenticationParams(),
            };

            JobActionType jobActionType;

            if (this.Uri.Scheme.Equals(Constants.HttpScheme, StringComparison.InvariantCultureIgnoreCase) ||
                this.Uri.Scheme.Equals(Constants.HttpsScheme, StringComparison.InvariantCultureIgnoreCase))
            {
                jobActionType = (JobActionType)Enum.Parse(typeof(JobActionType), this.Uri.Scheme, ignoreCase: true);
            }
            else
            {
                throw new PSArgumentException(string.Format(Resources.SchedulerInvalidUriScheme, this.Uri.Scheme));
            }

            var jobAction = new PSJobActionParams()
            {
                JobActionType = jobActionType,
                HttpJobAction = httpJobAction
            };

            var jobRecurrence = new PSJobRecurrenceParams()
            {
                Interval = this.Interval,
                Frequency = this.Frequency,
                EndTime = this.EndTime,
                ExecutionCount = this.ExecutionCount
            };

            var jobParams = new PSJobParams()
            {
                ResourceGroupName = this.ResourceGroupName,
                JobCollectionName = this.JobCollectionName,
                JobName = this.JobName,
                JobState = this.JobState,
                StartTime = this.StartTime,
                JobAction = jobAction,
                JobRecurrence = jobRecurrence,
                JobErrorAction = this.GetErrorActionParamsValue(this.ErrorActionType)
            };

            this.ConfirmAction(
                processMessage: string.Format(Resources.NewHttpJobResourceDescription, this.JobName),
                target: this.JobCollectionName,
                action: () =>
                    {
                        this.WriteObject(this.SchedulerClient.CreateJob(jobParams));
                    }
            );
        }

        /// <summary>
        /// Get conditional parameters depending on specified ErrorAction and/or type of http authentication.
        /// </summary>
        /// <returns>List of Powershell dynamic parameters.</returns>
        public object GetDynamicParameters()
        {
            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();

            if (!string.IsNullOrWhiteSpace(this.HttpAuthenticationType))
            {
                if (this.HttpAuthenticationType.Equals(Constants.HttpAuthenticationClientCertificate, StringComparison.InvariantCultureIgnoreCase))
                {
                    runtimeDefinedParameterDictionary.AddRange(this.JobDynamicParameters.AddHttpClientCertificateAuthenticationTypeParameters());
                }
                else if (this.HttpAuthenticationType.Equals(Constants.HttpAuthenticationBasic, StringComparison.InvariantCultureIgnoreCase))
                {
                    runtimeDefinedParameterDictionary.AddRange(this.JobDynamicParameters.AddHttpBasicAuthenticationTypeParameters());
                }
                else if (this.HttpAuthenticationType.Equals(Constants.HttpAuthenticationActiveDirectoryOAuth, StringComparison.InvariantCultureIgnoreCase))
                {
                    runtimeDefinedParameterDictionary.AddRange(this.JobDynamicParameters.AddHttpActiveDirectoryOAuthAuthenticationTypeParameters());
                }
            }

            if (!string.IsNullOrWhiteSpace(this.ErrorActionType))
            {
                runtimeDefinedParameterDictionary.AddRange(this.AddErrorActionParameters(this.ErrorActionType, create: true));
            }

            return runtimeDefinedParameterDictionary;
        }

        /// <summary>
        /// Gets http authentication.
        /// </summary>
        /// <returns>PSHttpJobAuthenticationParams instance.</returns>
        private PSHttpJobAuthenticationParams GetAuthenticationParams()
        {
            if (!string.IsNullOrWhiteSpace(this.HttpAuthenticationType))
            {
                var jobAuthentication = new PSHttpJobAuthenticationParams()
                {
                    HttpAuthType = this.HttpAuthenticationType,
                    ClientCertPfx = string.IsNullOrWhiteSpace(JobDynamicParameters.ClientCertificatePfx) ? null : SchedulerUtility.GetCertData(this.ResolvePath(JobDynamicParameters.ClientCertificatePfx), JobDynamicParameters.ClientCertificatePassword),
                    ClientCertPassword = this.JobDynamicParameters.ClientCertificatePassword,
                    Username = this.JobDynamicParameters.BasicUsername,
                    Password = this.JobDynamicParameters.BasicPassword,
                    Secret = this.JobDynamicParameters.OAuthSecret,
                    Tenant = this.JobDynamicParameters.OAuthTenant,
                    Audience = this.JobDynamicParameters.OAuthAudience,
                    ClientId = this.JobDynamicParameters.OAuthClientId
                };

                return jobAuthentication;
            }

            return null;
        }
    }
}
