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

using Hyak.Common;
using Microsoft.Azure.Management.Insights.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Add an Alert rule
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureRmLogAlertRule"), OutputType(typeof(List<PSObject>))]
    public class AddAzureRmLogAlertRuleCommand : AddAzureRmAlertRuleCommandBase
    {
        /// <summary>
        /// Gets or sets the TargetResourceGroup parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The target resource group")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the TargetResourceId parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The target resource id for rule")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceId { get; set; }

        /// <summary>
        /// Gets or sets the Level parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The level for rule")]
        public string Level { get; set; }

        /// <summary>
        /// Gets or sets the OperationName parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The operation name for rule")]
        public string OperationName { get; set; }

        /// <summary>
        /// Gets or sets the TargetResourceProvider parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The target resource provider for rule")]
        public string TargetResourceProvider { get; set; }

        /// <summary>
        /// Gets or sets the Status parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The status for rule")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the SubStatus parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The substatus for rule")]
        public string SubStatus { get; set; }

        private RuleCondition CreateRuleCondition()
        {
            WriteVerboseWithTimestamp(string.Format("CreateRuleCondition: Creating event rule condition (event-based rule)"));
            return new ManagementEventRuleCondition()
            {
                DataSource = new RuleManagementEventDataSource()
                {
                    Level = this.Level,
                    OperationName = this.OperationName,
                    ResourceGroupName = this.TargetResourceGroup,
                    ResourceProviderName = this.TargetResourceProvider,
                    ResourceUri = this.TargetResourceId,
                    Status = this.Status,
                    SubStatus = this.SubStatus,
                },
            };
        }

        protected override RuleCreateOrUpdateParameters CreateSdkCallParameters()
        {
            RuleCondition condition = this.CreateRuleCondition();

            WriteVerboseWithTimestamp(string.Format("CreateSdkCallParameters: Creating rule object"));
            var rule = new RuleCreateOrUpdateParameters()
            {
                Location = this.Location,
                Properties = new Rule()
                {
                    Name = this.Name,
                    IsEnabled = !this.DisableRule,
                    Description = this.Description ?? Utilities.GetDefaultDescription("log alert rule"),
                    LastUpdatedTime = DateTime.Now,
                    Condition = condition,
                    Actions = this.Actions,
                },

                // DO NOT REMOVE OR CHANGE the following. The two elements in the Tags are required by other services.
                Tags = new LazyDictionary<string, string>(),
            };

            if (!string.IsNullOrEmpty(this.TargetResourceId))
            {
                rule.Tags.Add("$type", "Microsoft.WindowsAzure.Management.Common.Storage.CasePreservedDictionary,Microsoft.WindowsAzure.Management.Common.Storage");
                rule.Tags.Add("hidden-link:" + this.TargetResourceId, "Resource");
            }

            return rule;
        }
    }
}

