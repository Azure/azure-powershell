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
using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Management.Automation;


namespace Microsoft.Azure.Commands.EventHub.Commands.ApplicationGroups
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubThrottlingPolicyConfig"), OutputType(typeof(PSEventHubThrottlingPolicyConfigAttributes))]
    public class NewAzureEventHubsThrottlingPolicyConfig: AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, 
            Position = 0, 
            HelpMessage = "Name of Throttling Policy")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, 
            Position = 1, 
            HelpMessage = "Metric Id on which the throttle limit should be set, MetricId can be discovered by hovering over Metric in the Metrics section of Event Hub Namespace inside Azure Portal")]
        [ValidateSet(MetricIdValues.IncomingBytes, MetricIdValues.IncomingMessages, MetricIdValues.OutgoingBytes, MetricIdValues.OutgoingMessages, IgnoreCase = true)]
        public string MetricId { get; set; }

        [Parameter(Mandatory = true, 
            Position = 2, 
            HelpMessage = "The Threshold limit above which the application group will be throttled.Rate limit is always per second.")]
        public long RateLimitThreshold { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                PSEventHubThrottlingPolicyConfigAttributes throttlingPolicy = new PSEventHubThrottlingPolicyConfigAttributes();
                
                throttlingPolicy.Name = Name;
                throttlingPolicy.MetricId = MetricId;
                throttlingPolicy.RateLimitThreshold = RateLimitThreshold;

                WriteObject(throttlingPolicy);
            }
            catch (Exception ex)
            {
                WriteObject(new ErrorRecord(ex, ex.Message, ErrorCategory.OpenError, ex));
            }
        }
    }
}
