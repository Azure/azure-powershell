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
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Azure.Management.Logic;
    using System;

    /// <summary>
    /// LogicApp client partial class for access key operations
    /// </summary>
    public partial class LogicAppClient
    {
        /// <summary>
        /// Gets the workflow access key by name
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <param name="accessKeyName">Name of the access key</param>
        /// <returns>Workflow accesskey object </returns>
        public WorkflowSecretKeys GetWorkflowAccessKey(string resourceGroupName, string workflowName,
            string accessKeyName)
        {
            return this.LogicManagementClient.WorkflowAccessKeys.ListSecretKeys(resourceGroupName, workflowName, accessKeyName);
        }

        /// <summary>
        /// Gets the list of access keys of specified workflow
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <returns>List of the access keys</returns>
        public Page<WorkflowAccessKey> GetWorkflowAccessKeys(string resourceGroupName, string workflowName)
        {
            return
                (Page<WorkflowAccessKey>)
                    this.LogicManagementClient.WorkflowAccessKeys.List(resourceGroupName, workflowName);
        }

        /// <summary>
        /// Regenerate secrets for the AccessKeys of the workflow
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <param name="accessKeyName">Name of the access key</param>
        /// <param name="keyType">Type of key 'NotSpecified', 'Primary', 'Secondary'</param>
        /// <returns>Workflow secret key object</returns>
        public WorkflowSecretKeys RegenerateWorkflowAccessKey(string resourceGroupName, string workflowName,
            string accessKeyName, string keyType)
        {
            return this.LogicManagementClient.WorkflowAccessKeys.RegenerateSecretKey(
                resourceGroupName,
                workflowName,
                accessKeyName,
                new RegenerateSecretKeyParameters
                {
                    KeyType = (KeyType) Enum.Parse(typeof (KeyType), keyType)
                });
        }
    }
}