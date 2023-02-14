﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Management.Logic.Models;

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using ResourceManager.Common.ArgumentCompleters;
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Creates a new LogicApp workflow 
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LogicAppRunHistory"), OutputType(typeof(WorkflowRun))]
    public class AzureLogicAppRunHistoryCommand : LogicAppBaseCmdlet
    {

        #region Input Parameters

        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group for the workflow.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the workflow.")]
        [Alias("ResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the workflow run.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string RunName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates the cmdlet should follow next page links.")]
        [Alias("FL")]
        public SwitchParameter FollowNextPageLink { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies how many times to follow next page links if FollowNextPageLink is used.")]
        [Alias("ML")]
        [ValidateRange(1, Int32.MaxValue)]
        public int MaximumFollowNextPageLink { get; set; } = int.MaxValue;

        #endregion Input Parameters

        /// <summary>
        /// Executes the get workflow run history command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (string.IsNullOrEmpty(this.RunName))
            {
                var page = new Page<WorkflowRun>();
                int i = 0;
                do
                {
                    page = this.LogicAppClient.GetWorkflowRuns(this.ResourceGroupName, this.Name, page.NextPageLink);
                    this.WriteObject(page.GetEnumerator().ToIEnumerable<WorkflowRun>(), true);
                    i++;
                }
                while (this.FollowNextPageLink && !string.IsNullOrWhiteSpace(page.NextPageLink) && i <= this.MaximumFollowNextPageLink);
            }
            else
            {
                this.WriteObject(this.LogicAppClient.GetWorkflowRun(this.ResourceGroupName, this.Name, this.RunName), true);
            }
        }
    }
}
