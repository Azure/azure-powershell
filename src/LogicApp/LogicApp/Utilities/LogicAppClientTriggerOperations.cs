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

namespace Microsoft.Azure.Commands.LogicApp.Utilities
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;

    /// <summary>
    /// LogicApp client partial class for trigger operations
    /// </summary>
    public partial class LogicAppClient
    {
        /// <summary>
        /// Gets the list of triggers in the workflow
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <returns>List of triggers in the workflow</returns>
        public Page<WorkflowTrigger> GetWorkflowTriggers(string resourceGroupName, string workflowName)
        {
            return (Page<WorkflowTrigger>)
                    this.LogicManagementClient.WorkflowTriggers.List(resourceGroupName, workflowName);
        }

        /// <summary>
        /// Gets the specified trigger from the workflow
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <param name="triggerName">Name of the trigger</param>
        /// <returns>Workflow trigger</returns>
        public WorkflowTrigger GetWorkflowTrigger(string resourceGroupName, string workflowName, string triggerName)
        {
            return this.LogicManagementClient.WorkflowTriggers.Get(resourceGroupName, workflowName, triggerName);
        }

        /// <summary>
        /// Gets the specified trigger callback URL from the workflow
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <param name="triggerName">Name of the trigger</param>
        /// <returns>Workflow trigger</returns>
        public WorkflowTriggerCallbackUrl GetWorkflowTriggerCallbackUrl(string resourceGroupName, string workflowName, string triggerName)
        {
            return this.LogicManagementClient.WorkflowTriggers.ListCallbackUrl(resourceGroupName, workflowName, triggerName);
        }

        /// <summary>
        /// Gets the workflow trigger histories.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <param name="triggerName">Name of the trigger</param>
        /// <returns>List of trigger histories</returns>
        public Page<WorkflowTriggerHistory> GetWorkflowTriggerHistories(string resourceGroupName, string workflowName,
            string triggerName)
        {
            return
                (Page<WorkflowTriggerHistory>)
                    this.LogicManagementClient.WorkflowTriggerHistories.List(resourceGroupName, workflowName,
                        triggerName);
        }

        /// <summary>
        /// Gets the workflow history by name
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <param name="triggerName">Name of the trigger</param>
        /// <param name="historyName">Name of the trigger history</param>
        /// <returns>Workflow history</returns>
        public WorkflowTriggerHistory GetWorkflowTriggerHistory(string resourceGroupName, string workflowName,
            string triggerName, string historyName)
        {
            return this.LogicManagementClient.WorkflowTriggerHistories.Get(resourceGroupName, workflowName, triggerName, historyName);
        }

        /// <summary>
        /// Runs the workflow trigger
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <param name="triggerName">Name of the trigger</param>
        public void RunWorkflowTrigger(string resourceGroupName, string workflowName,
            string triggerName)
        {
            this.LogicManagementClient.WorkflowTriggers.Run(resourceGroupName, workflowName, triggerName);
        }
    }
}