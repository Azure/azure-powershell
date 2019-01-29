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
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledQueryRule", SupportsShouldProcess = true), OutputType(typeof(PSScheduledQueryRuleResource))]
    public class UpdateScheduledQueryRuleCommand : MonitorCmdletBase
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

        /// <summary>
        /// Alert name
        /// </summary>
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The alert name")]
        [ValidateNotNullOrEmpty]
        public string RuleName { get; set; }

        /// <summary>
        /// The resource group name
        /// </summary>
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Alert status - enabled or not, supported values - "true", "false"
        /// </summary>
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, HelpMessage = "The azure alert state - valid values - true, false")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, HelpMessage = "The azure alert state - valid values - true, false")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, HelpMessage = "The azure alert state - valid values - true, false")]
        [ValidateSet("true", "false")]
        public string Enabled { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
        }
    }
}
