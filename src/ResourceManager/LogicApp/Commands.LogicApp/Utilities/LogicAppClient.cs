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
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Models;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using System;
    using System.Globalization;
    using System.Management.Automation;

    /// <summary>
    /// LogicApp client class
    /// </summary>
    public partial class LogicAppClient
    {
        /// <summary>
        /// Gets or sets the Verbose Logger
        /// </summary>
        public Action<string> VerboseLogger { get; set; }

        /// <summary>
        /// Gets or sets the Error Logger
        /// </summary>
        public Action<string> ErrorLogger { get; set; }

        /// <summary>
        /// Creates new LogicManagement client instance.
        /// </summary>
        /// <param name="context">The Azure context instance</param>
        public LogicAppClient(AzureContext context)
        {
            this.LogicManagementClient = AzureSession.ClientFactory.CreateArmClient<LogicManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);            
            this.LogicManagementClient.SubscriptionId = context.Subscription.Id.ToString();
        }

        /// <summary>
        /// Creates new LogicManagement client instance.
        /// </summary>
        public LogicAppClient()
        {
        }

        /// <summary>
        /// Creates new LogicManagement client instance.
        /// </summary>
        /// <param name="client">client reference</param>
        public LogicAppClient(ILogicManagementClient client)
        {
            this.LogicManagementClient = client;        }

        /// <summary>
        /// Gets or sets the Logic client instance
        /// </summary>
        public ILogicManagementClient LogicManagementClient { get; set; }

        /// <summary>
        /// Updates workflow in the azure resource group
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Workflow name</param>
        /// <param name="workflow">Workflow object</param>
        /// <returns>Newly created workflow object</returns>
        public Workflow UpdateWorkflow(string resourceGroupName, string workflowName, Workflow workflow)
        {
            return this.LogicManagementClient.Workflows.CreateOrUpdate(resourceGroupName, workflowName, workflow);
        }

        /// <summary>
        /// Creates workflow in the azure resource group
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Workflow name</param>
        /// <param name="workflow">Workflow object</param>
        /// <returns>Newly created workflow object</returns>
        public Workflow CreateWorkflow(string resourceGroupName, string workflowName, Workflow workflow)
        {
            if (!this.DoesLogicAppExist(resourceGroupName, workflowName))
            {
                return this.LogicManagementClient.Workflows.CreateOrUpdate(resourceGroupName, workflowName, workflow);
            }
            else
            {
                throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                    Properties.Resource.ResourceAlreadyExists, workflowName, resourceGroupName));
            }
        }

        /// <summary>
        /// Gets the workflow by name from given resource group.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Workflow name</param>
        /// <returns>Workflow object</returns>
        public Workflow GetWorkflow(string resourceGroupName, string workflowName)
        {
            return this.LogicManagementClient.Workflows.Get(resourceGroupName, workflowName);
        }

        /// <summary>
        /// Gets the given version of a workflow by name from given resource group.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Workflow name</param>
        /// <param name="versionId">Version of the workflow</param>
        /// <returns>Workflow object</returns>
        public WorkflowVersion GetWorkflowVersion(string resourceGroupName, string workflowName, string versionId)
        {
            return this.LogicManagementClient.WorkflowVersions.Get(resourceGroupName, workflowName, versionId);
        }

        /// <summary>
        /// Gets the upgraded definition for a workflow.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Workflow name</param>
        /// <param name="targetSchemaVersion">Target schema version of the definition</param>
        /// <returns>Workflow object</returns>
        public object GetWorkflowUpgradedDefinition(string resourceGroupName, string workflowName, string targetSchemaVersion)
        {
            return this.LogicManagementClient.Workflows.GenerateUpgradedDefinition(
                resourceGroupName,
                workflowName,
                targetSchemaVersion);
        }

        /// <summary>
        /// Removes the specified workflow from the given resource group.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Workflow name</param>
        public void RemoveWorkflow(string resourceGroupName, string workflowName)
        {
            this.LogicManagementClient.Workflows.Delete(resourceGroupName, workflowName);
        }

        /// <summary>
        /// Validates the specified workflow from the given resource group.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="location">The workflow location.</param>
        /// <param name="workflowName">Workflow name</param>
        /// <param name="workflow">The Workflow object.</param>
        public void ValidateWorkflow(string resourceGroupName, string location, string workflowName, Workflow workflow)
        {
            this.LogicManagementClient.Workflows.Validate(resourceGroupName, location, workflowName, workflow);
        }

        /// <summary>
        /// Checks whether logic app exists or not 
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="workflowName">Name of the workflow</param>
        /// <returns>Boolean result</returns>
        private bool DoesLogicAppExist(string resourceGroupName, string workflowName)
        {
            bool result = false;
            try
            {
                var workflow = this.LogicManagementClient.Workflows.GetAsync(resourceGroupName, workflowName).Result;
                result = workflow != null;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}