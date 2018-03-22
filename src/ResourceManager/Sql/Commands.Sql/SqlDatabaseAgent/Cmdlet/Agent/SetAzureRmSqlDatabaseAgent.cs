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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Cmdlet
{
    /// <summary>
    /// Defines the Set-AzureRmSqlDatabaseAgent Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlDatabaseAgent", 
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlDatabaseAgentModel))]
    public class SetAzureSqlDatabaseAgent : AzureSqlDatabaseAgentCmdletBase
    {
        /// <summary>
        /// Gets or sets the agent input object
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent input object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlDatabaseAgentModel InputObject { get; set; }

        /// <summary>
		/// Gets or sets the agent resource id
		/// </summary>
		[Parameter(
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The agent resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the agent name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DefaultParameterSet,
            Position = 2,
            HelpMessage = "The agent name")]
        [ValidateNotNullOrEmpty]
        [Alias("AgentName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Agent tags
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "The tags to associate with the Azure SQL Database Agent",
            Position = 3,
            ParameterSetName = DefaultParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The tags to associate with the Azure SQL Database Agent",
            Position = 1,
            ParameterSetName = InputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The tags to associate with the Azure SQL Database Agent",
            Position = 1,
            ParameterSetName = ResourceIdParameterSet)]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case InputObjectParameterSet:
                    this.ResourceGroupName = InputObject.ResourceGroupName;
                    this.ServerName = InputObject.ServerName;
                    this.Name = InputObject.AgentName;
                    break;
                case ResourceIdParameterSet:
                    var resourceInfo = new ResourceIdentifier(ResourceId);
                    this.ResourceGroupName = resourceInfo.ResourceGroupName;
                    this.ServerName = ResourceIdentifier.GetTypeFromResourceType(resourceInfo.ParentResource);
                    this.Name = resourceInfo.ResourceName;
                    break;
                default:
                    break;
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Check to see if the agent already exists in this resource group.
        /// </summary>
        /// <returns>Null if the agent doesn't exist. Otherwise throws exception</returns>
        protected override AzureSqlDatabaseAgentModel GetEntity()
        {
            try
            {
                WriteDebugWithTimestamp("AgentName: {0}", Name);
                return ModelAdapter.GetSqlDatabaseAgent(this.ResourceGroupName, this.ServerName, this.Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // The agent does not exist
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureSqlDatabaseAgentNotExists, this.Name, this.ServerName),
                        "AgentName");
                }

                // Unexpected exception encountered
                throw;
            }
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the server doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override AzureSqlDatabaseAgentModel ApplyUserInputToModel(AzureSqlDatabaseAgentModel model)
        {
            string location = ModelAdapter.GetServerLocationAndThrowIfAgentNotSupportedByServer(this.ResourceGroupName, this.ServerName);

            AzureSqlDatabaseAgentModel newEntity = new AzureSqlDatabaseAgentModel
            {
                Location = location,
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                AgentName = this.Name,
                DatabaseName = model.DatabaseName,
                Tags = TagsConversionHelper.ReadOrFetchTags(this, model.Tags),
            };

            return newEntity;
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the agent
        /// </summary>
        /// <param name="entity">The agent to create</param>
        /// <returns>The created agent</returns>
        protected override AzureSqlDatabaseAgentModel PersistChanges(AzureSqlDatabaseAgentModel entity)
        {
            // Note: We are currently using PATCH, but in the future we plan on exposing worker count for public preview.
            // Hence the reason we are using Set instead of Update as we will call a PUT in the future instead of current PATCH request.
            return ModelAdapter.UpdateSqlDatabaseAgent(entity);
        }
    }
}