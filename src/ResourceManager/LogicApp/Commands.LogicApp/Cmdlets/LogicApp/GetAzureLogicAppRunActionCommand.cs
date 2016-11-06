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
    using System.Management.Automation;

    /// <summary>
    /// Gets the action in the workflow run
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmLogicAppRunAction"), OutputType(typeof(object))]
    public class GetAzureLogicAppRunActionCommand : LogicAppBaseCmdlet
    {
        #region Input Parameters

        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group for the workflow.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the workflow.",
            ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the workflow run.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string RunName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the action in the workflow run.")]
        [ValidateNotNullOrEmpty]
        public string ActionName { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the get workflow run action command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.IsNullOrEmpty(this.ActionName))
            {
                var enumerator = LogicAppClient.GetWorkflowRunActions(this.ResourceGroupName, this.Name, this.RunName).GetEnumerator();
                this.WriteObject(enumerator.ToIEnumerable<WorkflowRunAction>(), true);
            }
            else
            {
                this.WriteObject(
                    LogicAppClient.GetWorkflowRunAction(this.ResourceGroupName, this.Name, this.RunName, this.ActionName),
                    true);
            }
        }
    }
}