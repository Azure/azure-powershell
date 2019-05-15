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
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Insights.ScheduledQueryRules
{
    /// <summary>
    /// Updates a ScheduledQueryRule object
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledQueryRule", SupportsShouldProcess = true, DefaultParameterSetName = ByRuleName), OutputType(typeof(bool))]
    public class RemoveScheduledQueryRuleCommand : ManagementCmdletBase
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
        /// Gets or sets the PassThru switch parameter.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return a value indicating success or failure")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            if (this.IsParameterBound(c => c.InputObject) || this.InputObject != null)
            {
                var resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else if (this.IsParameterBound(c => c.ResourceId) || !string.IsNullOrWhiteSpace(this.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.ShouldProcess(this.Name,
                string.Format("Deleting Log Alert Rule '{0}' in resource group {0}", this.Name,
                    this.ResourceGroupName)))
            {
                try
                {
                    this.MonitorManagementClient.ScheduledQueryRules.DeleteWithHttpMessagesAsync(this.ResourceGroupName,
                        this.Name);
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error occured while removing the Log ALert Rule", ex);
                }
            }

        }
    }
}
