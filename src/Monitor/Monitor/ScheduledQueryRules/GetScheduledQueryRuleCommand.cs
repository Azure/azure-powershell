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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Insights.ScheduledQueryRules
{
    /// <summary>
    /// Get all ScheduledQueryRule objects in a subscription, resource group or by rule name
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledQueryRule", DefaultParameterSetName = ByRuleName), OutputType(typeof(PSScheduledQueryRuleResource))]
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
        public string RuleName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceId, HelpMessage = "The resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            //List<PSScheduledQueryRuleResource> output = null;

            try
            {
            //    if (ParameterSetName.Equals(BySubscriptionOrResourceGroup))
            //    {

            //        if (string.IsNullOrWhiteSpace(this.ResourceGroupName))
            //        {

            //            // Retrieve all log alerts by subscription
            //            output = this.MonitorManagementClient.ScheduledQueryRules.ListBySubscription()
            //                .Select(e => new PSScheduledQueryRuleResource(e))
            //                .ToList();

            //        }
            //        else
            //        {
            //            // Retrieve all log alerts for the resource groups
            //            output = this.MonitorManagementClient.ScheduledQueryRules
            //                .ListByResourceGroup(resourceGroupName: this.ResourceGroupName)
            //                .Select(e => new PSScheduledQueryRuleResource(e))
            //                .ToList();
            //        }
            //    }
            //    else
            //    {
            //        if (ParameterSetName.Equals(ByResourceId))
            //        {
            //            // Resource Id provided, retrieve that alert by name
            //            string resourceGroupName = null;
            //            string ruleName = null;

            //            ScheduledQueryRuleUtilities.ProcessPipeObject(ResourceId, out resourceGroupName, out ruleName);

            //            this.ResourceGroupName = resourceGroupName;
            //            this.RuleName = ruleName;
            //        }

            //        // Retrieve a log alert by name, ParameterSetName = ByRuleName
            //        output = new List<PSScheduledQueryRuleResource>
            //        {
            //            new PSScheduledQueryRuleResource(
            //                this.MonitorManagementClient.ScheduledQueryRules.Get(
            //                    resourceGroupName: this.ResourceGroupName, ruleName: this.RuleName))
            //        };
            //    }


                if (this.IsParameterBound(c => c.ResourceId))
                {
                    var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                    this.RuleName = resourceIdentifier.ResourceName;
                }

                if (!string.IsNullOrEmpty(this.RuleName))
                {
                    var result = new PSScheduledQueryRuleResource(this.MonitorManagementClient.ScheduledQueryRules.GetWithHttpMessagesAsync(this.ResourceGroupName, this.RuleName).Result.Body);
                    WriteObject(result);
                }
                else if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    var result = this.MonitorManagementClient.ScheduledQueryRules.ListByResourceGroupWithHttpMessagesAsync(this.ResourceGroupName).Result.Body.Select(f => new PSScheduledQueryRuleResource(f));
                    WriteObject(result, true);
                }
                else
                {
                    var result = this.MonitorManagementClient.ScheduledQueryRules.ListBySubscriptionWithHttpMessagesAsync().Result.Body.Select(f => new PSScheduledQueryRuleResource(f));
                    WriteObject(result, true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting Log Alert rules", ex);
            }
        }
    }
}
