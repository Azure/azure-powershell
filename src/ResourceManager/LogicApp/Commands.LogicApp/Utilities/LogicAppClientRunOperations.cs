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
    /// LogicApp client partial class for run operations
    /// </summary>
    public partial class LogicAppClient
    {
        /// <summary>
        /// Cancels the logic app run.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <param name="runName">Workflow run name</param>
        public void CancelWorkflowRun(string resourceGroupName, string workflowName,
            string runName)
        {
            this.LogicManagementClient.WorkflowRuns.Cancel(resourceGroupName, workflowName, runName);
        }

        /// <summary>
        /// Gets the workflow run history.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <returns>List of workflow runs</returns>
        public Page<WorkflowRun> GetWorkflowRuns(string resourceGroupName, string workflowName)
        {
            return (Page<WorkflowRun>)this.LogicManagementClient.WorkflowRuns.List(resourceGroupName, workflowName);
        }

        /// <summary>
        /// Gets the logic app run.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <param name="runName">Name of the workflow run</param>
        /// <returns>Workflow run</returns>       
        public WorkflowRun GetWorkflowRun(string resourceGroupName, string workflowName,
            string runName)
        {
            return this.LogicManagementClient.WorkflowRuns.Get(resourceGroupName, workflowName, runName);
        }

        /// <summary>
        /// Gets the workflow run action
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <param name="runName">Name of the workflow run</param>
        /// <param name="actionName">Name of the workflow run action</param>
        /// <returns>Workflow run action</returns>
        public WorkflowRunAction GetWorkflowRunAction(string resourceGroupName, string workflowName,
            string runName, string actionName)
        {
            return this.LogicManagementClient.WorkflowRunActions.Get(resourceGroupName, workflowName, runName,
                actionName);
        }

        /// <summary>
        /// Gets actions of the specified workflow run.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <param name="runName">Name of the workflow run</param>
        /// <returns>Actions of the specified workflow run</returns>
        public Page<WorkflowRunAction> GetWorkflowRunActions(string resourceGroupName, string workflowName, string runName)
        {
            return (Page<WorkflowRunAction>)this.LogicManagementClient.WorkflowRunActions.List(resourceGroupName, workflowName, runName);
        }
    }
}