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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Insights.ActionGroups
{
    /// <summary>
    /// Gets an Azure Action Group.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmActionGroup", DefaultParameterSetName = BySubscriptionOrResourceGroup)]
    [OutputType(typeof(PSActionGroupResource))]
    public class GetAzureRmActionGroupCommand : ManagementCmdletBase
    {
        private const string ByName = "ByName";

        private const string BySubscriptionOrResourceGroup = "BySubscriptionOrResourceGroup";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the resource group parameter.
        /// </summary>
        [Parameter(ParameterSetName = BySubscriptionOrResourceGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }
        
        /// <summary>
        /// Gets or sets the action group name parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The action group name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        #endregion

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            IEnumerable<ActionGroupResource> apiResult;

            if (string.IsNullOrWhiteSpace(this.ResourceGroupName))
            {
                if (string.IsNullOrWhiteSpace(this.Name))
                {
                    apiResult = this.MonitorManagementClient.ActionGroups.ListBySubscriptionId();
                }
                else
                {
                    throw new PSArgumentException("Resource group name cannot be null or empty when name is not");
                }
            }
            else if (string.IsNullOrWhiteSpace(this.Name))
            {
                apiResult = this.MonitorManagementClient.ActionGroups.ListByResourceGroup(resourceGroupName: this.ResourceGroupName);
            }
            else
            {
                apiResult = new[]
                {
                    this.MonitorManagementClient.ActionGroups.Get(
                        resourceGroupName: this.ResourceGroupName,
                        actionGroupName: this.Name)
                };
            }

            var output = apiResult.Select(ag => new PSActionGroupResource(ag)).ToList();
            WriteObject(sendToPipeline: output, enumerateCollection: true);
        }
    }
}
