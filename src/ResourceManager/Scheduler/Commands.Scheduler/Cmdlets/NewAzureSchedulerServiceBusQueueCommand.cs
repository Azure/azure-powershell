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
    using SchedulerModels = Microsoft.Azure.Management.Scheduler.Models;

    /// <summary>
    /// Creates new service bus queue job.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSchedulerServiceBusQueueJob", SupportsShouldProcess = true), OutputType(typeof(PSSchedulerJobDefinition))]
    public class NewAzureSchedulerServiceBusQueueCommand : JobBaseCmdlet, IDynamicParameters
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

        [Parameter(Mandatory = true, HelpMessage = "Service bus queue name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceBusQueueName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Service bus namespace.")]
        [ValidateNotNullOrEmpty]
        public string ServiceBusNamespace { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Service bus transport type.")]
        [ValidateSet(Constants.NetMessaging, Constants.AMQP, IgnoreCase = true)]
        public string ServiceBusTransportType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Service bus queue message.")]
        [ValidateNotNullOrEmpty]
        public string ServiceBusMessage { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Shared access signature key name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceBusSasKeyName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Shared access signature key value.")]
        [ValidateNotNullOrEmpty]
        public string ServiceBusSasKeyValue { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The Start Time")]
        [ValidateNotNullOrEmpty]
        public DateTime? StartTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Interval of the recurrence at the given frequency")]
        [ValidateNotNullOrEmpty]
        public int? Interval { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The frequency of recurrence")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.FrequencyTypeMinute, Constants.FrequencyTypeHour, Constants.FrequencyTypeDay, Constants.FrequencyTypeWeek, Constants.FrequencyTypeMonth, IgnoreCase = true)]
        public string Frequency { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The End Time")]
        [ValidateNotNullOrEmpty]
        public DateTime? EndTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Count of occurrences that will execute. Optional. Default will recur infinitely")]
        [ValidateNotNullOrEmpty]
        public int? ExecutionCount { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The job state.")]
        [ValidateSet(Constants.JobStateEnabled, Constants.JobStateDisabled, IgnoreCase = true)]
        public string JobState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Error action settings")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.HttpAction, Constants.HttpsAction, Constants.StorageQueueAction, Constants.ServiceBusQueueAction, Constants.ServiceBusTopicAction, IgnoreCase = true)]
        public string ErrorActionType { get; set; }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var serviceBusAuthentication = new PSServiceBusAuthenticationParams()
            {
                SasKey = this.ServiceBusSasKeyValue,
                SasKeyName = this.ServiceBusSasKeyName,
                Type = Constants.SharedAccessKey
            };

            var servicBusQueue = new PSServiceBusParams()
            {
                Authentication = serviceBusAuthentication,
                Message = this.ServiceBusMessage,
                NamespaceProperty = this.ServiceBusNamespace,
                QueueName = this.ServiceBusQueueName,
                TransportType = this.ServiceBusTransportType
            };

            var jobAction = new PSJobActionParams()
            {
                JobActionType = SchedulerModels.JobActionType.ServiceBusQueue,
                ServiceBusAction = servicBusQueue
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
                processMessage: string.Format(Resources.NewServiceBusQueueJobResourceDescription, this.JobName),
                target: this.JobCollectionName,
                action: () =>
                {
                    this.WriteObject(this.SchedulerClient.CreateJob(jobParams));
                }
            );
        }

        /// <summary>
        /// Get conditional parameters depending on specified ErrorAction.
        /// </summary>
        /// <returns>List of Powershell dynamic parameters.</returns>
        public object GetDynamicParameters()
        {
            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();

            if (!string.IsNullOrWhiteSpace(this.ErrorActionType))
            {
                runtimeDefinedParameterDictionary = this.AddErrorActionParameters(this.ErrorActionType, create: true);
            }

            return runtimeDefinedParameterDictionary;
        }
    }
}
