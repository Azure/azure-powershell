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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ElasticJobs.Model;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet.PrivateEndpoint
{
    /// <summary>
    /// Defines the Get-AzSqlElasticJobPrivateEndpoint Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlElasticJobPrivateEndpoint",
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlElasticJobPrivateEndpointModel))]
    public class GetAzureSqlElasticJobPrivateEndpoint : AzureSqlElasticJobPrivateEndpointCmdletBase<AzureSqlElasticJobAgentModel>
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
        /// Gets or sets the agent model input object
        /// </summary>
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlElasticJobAgentModel ElasticJobAgentObject { get; set; }

        /// <summary>
        /// Gets or sets the agent resource id
        /// </summary>
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The agent resource id")]
        [ValidateNotNullOrEmpty]
        public string ElasticJobAgentResourceId { get; set; }

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
        /// Gets or sets the server name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 2,
            HelpMessage = "The agent name")]
        [ValidateNotNullOrEmpty]
        public override string AgentName { get; set; }

        /// <summary>
        /// Gets or sets The private endpoint name
        /// </summary>
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "The private endpoint name")]
        [Parameter(ParameterSetName = InputObjectParameterSet,
            HelpMessage = "The private endpoint name")]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The private endpoint name")]
        [ValidateNotNullOrEmpty]
        [Alias("PrivateEndpointName")]
        public override string Name { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            InitializeInputObjectProperties(this.ElasticJobAgentObject);
            InitializeResourceIdProperties(this.ElasticJobAgentResourceId);
            base.ExecuteCmdlet();
            ClearProperties();
        }

        /// <summary>
        /// Gets the elastic job private endpoint for the agent.
        /// </summary>
        /// <returns>Throws exception if the credential doesn't exist.</returns>
        protected override IEnumerable<AzureSqlElasticJobPrivateEndpointModel> GetEntity()
        {
            try
            {
                // Returns a list of job private endpoints
                if (this.Name == null)
                {
                    return ModelAdapter.ListJobPrivateEndpoints(this.ResourceGroupName, this.ServerName, this.AgentName);
                }
                else
                {
                    return new List<AzureSqlElasticJobPrivateEndpointModel>
                    {
                        ModelAdapter.GetJobPrivateEndpoint(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name)
                    };
                }
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // The job private endpoint does not exist
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureElasticJobPrivateEndpointNotExists, this.Name, this.AgentName),
                        "PrivateEndpointName");
                }

                // Unexpected exception encountered
                throw;
            }
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlElasticJobPrivateEndpointModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticJobPrivateEndpointModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// Note: even though we technically don't need to override this, we want to pass the entity forward so that we can take advantage of
        /// powershell's understanding of a list with one item defaulting to just the item itself.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlElasticJobPrivateEndpointModel> PersistChanges(IEnumerable<AzureSqlElasticJobPrivateEndpointModel> entity)
        {
            return entity;
        }
    }
}
