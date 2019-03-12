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
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledQueryRule", SupportsShouldProcess = true), OutputType(typeof(bool))]
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
        /// Gets or sets the PassThru switch parameter.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return a value indicating success or failure")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {

                    //string resourceGroupName = this.ResourceGroupName;
                    //string ruleName = this.RuleName;

                    //// Using value from the pipe
                    //if (this.MyInvocation.BoundParameters.ContainsKey("InputObject") || this.InputObject != null)
                    //{
                    //    ScheduledQueryRuleUtilities.ProcessPipeObject(
                    //        inputObject: this.InputObject,
                    //        resourceGroupName: out resourceGroupName,
                    //        ruleName: out ruleName);
                    //}
                    //else if (this.MyInvocation.BoundParameters.ContainsKey("ResourceId") ||
                    //         !string.IsNullOrWhiteSpace(this.ResourceId))
                    //{
                    //    ScheduledQueryRuleUtilities.ProcessPipeObject(
                    //        resourceId: this.ResourceId,
                    //        resourceGroupName: out resourceGroupName,
                    //        ruleName: out ruleName);
                    //}

                    //this.MonitorManagementClient.ScheduledQueryRules.DeleteWithHttpMessagesAsync(
                    //    resourceGroupName: resourceGroupName, ruleName: ruleName);

                   

                    if (this.IsParameterBound(c => c.InputObject))
                    {
                        var resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                        this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                        this.RuleName = this.InputObject.Name;
                    }

                    if (this.IsParameterBound(c => c.ResourceId))
                    {
                        var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                        this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                        this.RuleName = resourceIdentifier.ResourceName;
                    }

            if (this.ShouldProcess(this.RuleName,
                string.Format("Deleting Log Alert Rule '{0}' in resource group {0}", this.RuleName,
                    this.ResourceGroupName)))
            {
                try
                {
                    this.MonitorManagementClient.ScheduledQueryRules.DeleteWithHttpMessagesAsync(this.ResourceGroupName,
                        this.RuleName);
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
