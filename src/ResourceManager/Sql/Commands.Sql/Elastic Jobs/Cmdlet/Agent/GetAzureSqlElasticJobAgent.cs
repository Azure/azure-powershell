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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Server.Model;
using Microsoft.Azure.Commands.Sql.ElasticJobs.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlElasticJobAgent cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlElasticJobAgent",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(IEnumerable<AzureSqlElasticJobAgentModel>))]
    public class GetAzureSqlElasticJobAgent : AzureSqlElasticJobAgentCmdletBase<AzureSqlServerModel>
    {
        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 0,
            HelpMessage = "The resource group name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 1,
            HelpMessage = "The server name")]
        [ValidateNotNullOrEmpty]
        public override string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the agent name
        /// </summary>
        [Parameter(
            Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "The agent name")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "The agent name")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The agent name")]
        [Alias("AgentName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Agent Server Object
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The server input object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlServerModel ServerObject { get; set; }

        /// <summary>
        /// Gets or sets the Agent Server Resource Id
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The server resource id")]
        public string ServerResourceId { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            InitializeInputObjectProperties(this.ServerObject);
            InitializeResourceIdProperties(this.ServerResourceId);
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Gets one or more elastic job agents from the service.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<AzureSqlElasticJobAgentModel> GetEntity()
        {
            ICollection<AzureSqlElasticJobAgentModel> results = null;

            // Returns a list of agents
            if (this.Name == null)
            {
                results = ModelAdapter.ListAgents(this.ResourceGroupName, this.ServerName);
            }
            // Returns an agent
            else
            {
                results = new List<AzureSqlElasticJobAgentModel>();
                results.Add(ModelAdapter.GetAgent(this.ResourceGroupName, this.ServerName, this.Name));
            }

            return results;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlElasticJobAgentModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticJobAgentModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlElasticJobAgentModel> PersistChanges(IEnumerable<AzureSqlElasticJobAgentModel> entity)
        {
            return entity;
        }
    }
}