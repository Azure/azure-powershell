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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Monitor;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Insights.ScheduledQueryRules
{
    /// <summary>
    /// Updates a ScheduledQueryRule object
    /// </summary>
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledQueryRule",
         SupportsShouldProcess = true, DefaultParameterSetName = ByRuleName), OutputType(typeof(PSScheduledQueryRuleResource))]
    public class UpdateScheduledQueryRuleCommand : ManagementCmdletBase
    {

        private const string ByInputObject = "ByInputObject";
        private const string ByRuleName = "ByRuleName";
        private const string ByResourceId = "ByResourceId";

        #region Cmdlet parameters

        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The Scheduled Query Rule resource")]
        [ValidateNotNull]
        public PSScheduledQueryRuleResource InputObject { get; set; }

        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Alert name
        /// </summary>
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, HelpMessage = "The alert name")]
        [ResourceNameCompleter("Microsoft.insights/scheduledqueryrules", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The resource group name
        /// </summary>
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Alert status - enabled or not, supported values - "true", "false"
        /// </summary>
        [Parameter(ParameterSetName = ByRuleName, Mandatory = true,
            HelpMessage = "The azure alert state - valid values - true, false")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = true,
            HelpMessage = "The azure alert state - valid values - true, false")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true,
            HelpMessage = "The azure alert state - valid values - true, false")]
        public bool Enabled { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            ResourceIdentifier resourceIdentifier = null;
            ScheduledQueryRuleResource resource = null;

            // ByInputObject parameter set
            if (this.IsParameterBound(c => c.InputObject) || this.InputObject != null)
            {
                resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;

            }
            else if (this.IsParameterBound(c => c.ResourceId) || !string.IsNullOrWhiteSpace(this.ResourceId))
            {
                resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            try
            {
                resource = new ScheduledQueryRuleResource(
                    this.MonitorManagementClient.ScheduledQueryRules.GetWithHttpMessagesAsync(this.ResourceGroupName, this.Name).Result.Body);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting Log Alert Rule", ex);
            }

            // Update of only Enabled field is supported
            LogSearchRuleResourcePatch parameters = new LogSearchRuleResourcePatch(resource.Tags, this.Enabled ? "true" : "false");

            if (ShouldProcess(this.Name,
                string.Format("Updating Log Alert Rule '{0}' in resource group '{1}'.", this.Name,
                    this.ResourceGroupName)))
            {
                try
                {
                    WriteObject(new PSScheduledQueryRuleResource(
                        this.MonitorManagementClient.ScheduledQueryRules.UpdateWithHttpMessagesAsync(this.ResourceGroupName,
                            this.Name,
                            parameters).Result.Body));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in updating Log Alert Rule", ex);
                }

            }
        }
    }
}
