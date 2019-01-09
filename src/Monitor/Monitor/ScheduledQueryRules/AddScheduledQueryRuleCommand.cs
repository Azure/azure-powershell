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

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.ScheduledQueryRules
{
    /// <summary>
    /// Create a ScheduledQueryRule Source object
    /// </summary>
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledQueryRule"), OutputType(typeof(PSScheduledQueryRuleResource))]
    public class AddScheduledQueryRuleCommand : MonitorCmdletBase
    {

        #region Cmdlet parameters

        //
        // Summary:
        //     Gets or sets source (Query, DataSourceId, etc.) for rule.
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scheduled query rule source")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleSource Source { get; set; }

        //
        // Summary:
        //     Gets or sets schedule (Frequnecy, Time Window) for rule.
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scheduled query rule schedule")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleSchedule Schedule { get; set; }
        //
        // Summary:
        //     Gets or sets action needs to be taken on rule execution.
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scheduled query rule Alerting Action")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleAlertingAction Action { get; set; }

        //
        // Summary:
        //     Region where alert is to be created
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location for this alert")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        //
        // Summary:
        //     Alert description
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The description for this alert")]
        public string Description { get; set; }

        //
        // Summary:
        //     Alert name
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The alert name")]
        public string Name { get; set; }

        //
        // Summary:
        //     Azure resource type
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The azure resource type")]
        public string Type { get; set; }

        //
        // Summary:
        //     Resource tags
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The duration in minutes for which alert should be throttled")]
        public Dictionary<string, string> Tags { get; set; }

        //
        // Summary:
        //     Alert status - enabled or not
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The azure alert state - valid values - true, false")]
        public string Enabled { get; set; }

        #endregion
        protected override void ProcessRecordInternal()
        {
        }
    }
}
