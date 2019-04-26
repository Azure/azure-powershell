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
using System;
using System.Net;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Insights.ScheduledQueryRules
{
    /// <summary>
    /// Get all ScheduledQueryRule objects in a subscription, resource group or by rule name
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledQueryRule", DefaultParameterSetName = BySubscriptionOrResourceGroup), OutputType(typeof(PSScheduledQueryRuleResource))]
    public class GetScheduledQueryRuleCommand : ManagementCmdletBase
    {
        private const string BySubscriptionOrResourceGroup = "BySubscriptionOrResourceGroup";
        private const string ByRuleName = "ByRuleName";
        private const string ByResourceId = "ByResourceId";

        #region Cmdlet parameters

        [Parameter(Mandatory = false, ParameterSetName = BySubscriptionOrResourceGroup, HelpMessage = "The resource group name")]
        [Parameter(Mandatory = true, ParameterSetName = ByRuleName, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByRuleName, HelpMessage = "The alert rule name")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.insights/scheduledqueryrules", nameof(ResourceGroupName))]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceId, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            try
            {
                if (this.IsParameterBound(c => c.ResourceId))
                {
                    var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                    this.Name = resourceIdentifier.ResourceName;
                }

                if (!string.IsNullOrEmpty(this.Name))
                {
                    var result = new PSScheduledQueryRuleResource(this.MonitorManagementClient.ScheduledQueryRules
                        .GetWithHttpMessagesAsync(this.ResourceGroupName, this.Name).Result.Body);
                    WriteObject(result);
                }
                else if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    var result = this.MonitorManagementClient.ScheduledQueryRules
                        .ListByResourceGroupWithHttpMessagesAsync(this.ResourceGroupName).Result.Body
                        .Select(f => new PSScheduledQueryRuleResource(f));
                    WriteObject(result, true);
                }
                else
                {
                    var result = this.MonitorManagementClient.ScheduledQueryRules
                        .ListBySubscriptionWithHttpMessagesAsync().Result.Body
                        .Select(f => new PSScheduledQueryRuleResource(f));
                    WriteObject(result, true);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("NotFound"))
                {
                    WriteObject(null);
                    return;
                }

                throw new Exception("Error occured while getting Log Alert rules", ex.InnerException);
            }
        }
    }
}
