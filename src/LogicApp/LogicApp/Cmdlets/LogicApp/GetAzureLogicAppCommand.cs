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

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using Management.Logic.Models;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using ResourceManager.Common.ArgumentCompleters;
    using System;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// Creates a new LogicApp workflow 
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LogicApp", DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(Workflow), typeof(WorkflowVersion))]
    public class GetAzureLogicAppCommand : LogicAppBaseCmdlet
    {
        public const string VersionParameterSet = "GetByVersion";
        public const string DefaultParameterSet = "ListWorkflows";

        #region Input Parameters

        [Parameter(Mandatory = false, HelpMessage = "The targeted resource group for the workflow.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = DefaultParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group for the workflow.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = VersionParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the workflow.", ParameterSetName = DefaultParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "The name of the workflow.", ParameterSetName = VersionParameterSet)]
        [Alias("ResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The version of the workflow.", ParameterSetName = VersionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the get workflow command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (!string.IsNullOrWhiteSpace(Version))
            {
                this.WriteObject(LogicAppClient.GetWorkflowVersion(this.ResourceGroupName, this.Name, this.Version), true);
            }
            else if (string.IsNullOrEmpty(ResourceGroupName))
            {
                var allWorkflows = LogicAppClient.ListWorkFlowBySubscription();
                if (string.IsNullOrEmpty(Name))
                {
                    this.WriteObject(allWorkflows.ToArray(), true);
                }
                else
                {
                    this.WriteObject(allWorkflows.Where(a => a.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase)).ToArray(), true);
                }
            }
            else if (string.IsNullOrEmpty(Name))
            {
                this.WriteObject(LogicAppClient.ListWorkFlowByResourceGroupName(ResourceGroupName).ToArray());
            }
            else
            {
                this.WriteObject(LogicAppClient.GetWorkflow(this.ResourceGroupName, this.Name), true);
            }
        }
    }
}
