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

using System.Management.Automation;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Sql.ElasticJobs.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet.PrivateEndpoint
{
    /// <summary>
    /// Defines the New-AzSqlElasticJobPrivateEndpoint Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlElasticJobPrivateEndpoint",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlElasticJobPrivateEndpointModel))]
    public class NewAzureSqlElasticJobPrivateEndpoint : AzureSqlElasticJobPrivateEndpointCmdletBase<AzureSqlElasticJobAgentModel>
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
            Mandatory = true,
            Position = 3,
            HelpMessage = "The private endpoint name")]
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The private endpoint name")]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The private endpoint name")]
        [ValidateNotNullOrEmpty]
        [Alias("PrivateEndpointName")]
        public override string Name { get; set; }

        /// <summary>
        /// Gets or sets the TargetServerAzureResourceId
        /// </summary>
        /// <value>
        /// The target server resource id e.g. "subscriptions/{subscriptionId}/resourceGroups/{rgName}/providers/Microsoft.Sql/servers/{serverName}"
        /// </value>
        /// <remarks>
        /// This needs to be a target server sql azure resource id (i.e. full arm uri) so that we can validate calling user's R/W access to this server via RBAC.
        /// </remarks>
        [Parameter(Mandatory = true, HelpMessage = "The resource ID for the server the private endpoint will target.")]
        public string TargetServerAzureResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Execution starts here
        /// </summary>
        public override void ExecuteCmdlet()
        {
            InitializeInputObjectProperties(this.ElasticJobAgentObject);
            InitializeResourceIdProperties(this.ElasticJobAgentResourceId);
            base.ExecuteCmdlet();
            ClearProperties();
        }

        /// <summary>
        /// Check to see if the private endpoint already exists for the agent.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override IEnumerable<AzureSqlElasticJobPrivateEndpointModel> GetEntity()
        {
            try
            {
                WriteDebugWithTimestamp("PrivateEndpointName: {0}", Name);
                ModelAdapter.GetJobPrivateEndpoint(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no job private endpoint with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The private endpoint already exists
            throw new PSArgumentException(
                string.Format(Properties.Resources.AzureElasticJobPrivateEndpointExists, this.Name, this.AgentName),
                "PrivateEndpointName");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the job private endpoint doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlElasticJobPrivateEndpointModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticJobPrivateEndpointModel> model)
        {
            AzureSqlElasticJobPrivateEndpointModel newPrivateEndpoint = new AzureSqlElasticJobPrivateEndpointModel
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                AgentName = this.AgentName,
                PrivateEndpointName = this.Name,
                TargetServerAzureResourceId = this.TargetServerAzureResourceId
            };

            return new List<AzureSqlElasticJobPrivateEndpointModel> { newPrivateEndpoint };
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the job private endpoint 
        /// </summary>
        /// <param name="entity">The private endpoint to create</param>
        /// <returns>The created private endpoint</returns>
        protected override IEnumerable<AzureSqlElasticJobPrivateEndpointModel> PersistChanges(IEnumerable<AzureSqlElasticJobPrivateEndpointModel> entity)
        {
            return new List<AzureSqlElasticJobPrivateEndpointModel> {
                ModelAdapter.UpsertJobPrivateEndpoint(entity.First())
            };
        }
    }
}
