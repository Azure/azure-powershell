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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Insights.ScheduledQueryRules
{
    /// <summary>
    /// Updates a ScheduledQueryRule object
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledQueryRule", SupportsShouldProcess = true), OutputType(typeof(PSScheduledQueryRuleResource))]
    public class SetScheduledQueryRuleCommand : MonitorCmdletBase
    {

        private const string ByInputObject = "ByInputObject";
        private const string ByRuleName = "ByRuleName";
        private const string ByResourceId = "ByResourceId";

        #region Cmdlet parameters

        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Scheduled Query Rule resource")]
        [ValidateNotNull]
        public PSScheduledQueryRuleResource InputObject { get; set; }

        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        //
        // Summary:
        //     Gets or sets source (Query, DataSourceId, etc.) for rule.
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scheduled query rule source")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The scheduled query rule source")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scheduled query rule source")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleSource Source { get; set; }

        //
        // Summary:
        //     Gets or sets schedule (Frequnecy, Time Window) for rule.
        [Parameter(ParameterSetName = ByRuleName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The scheduled query rule schedule")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The scheduled query rule schedule")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The scheduled query rule schedule")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleSchedule Schedule { get; set; }

        //
        // Summary:
        //     Gets or sets action needs to be taken on rule execution.
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scheduled query rule Alerting Action")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The scheduled query rule Alerting Action")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scheduled query rule Alerting Action")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleAlertingAction Action { get; set; }

        //
        // Summary:
        //     Region where alert is to be created
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location for this alert")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The location for this alert")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location for this alert")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        //
        // Summary:
        //     Alert description
        [Parameter(ParameterSetName = ByRuleName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The description for this alert")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The description for this alert")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The description for this alert")]
        public string Description { get; set; }

        //
        // Summary:
        //     Alert name
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The alert name")]
        public string RuleName { get; set; }

        /// <summary>
        /// Gets or sets the ResourceGroupName parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        //
        // Summary:
        //     Resource tags
        [Parameter(ParameterSetName = ByRuleName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource tags")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource tags")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource tags")]
        public string Tags { get; set; }

        //
        // Summary:
        //     Alert status - enabled or not, supported values - "true", "false"
        [Parameter(ParameterSetName = ByRuleName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The azure alert state - valid values - true, false")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The azure alert state - valid values - true, false")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The azure alert state - valid values - true, false")]
        [ValidateSet("true", "false")]
        public string Enabled { get; set; }


        #endregion

        protected override void ProcessRecordInternal()
        {
        }
    }
}
