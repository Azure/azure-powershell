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
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Cmdlet
{
    /// <summary>
    /// Defines the New-AzureRmSqlDatabaseAgentJobCredential Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlDatabaseAgentJobCredential", 
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlDatabaseAgentJobCredentialModel))]
    public class NewAzureSqlDatabaseAgentJobCredential : AzureSqlDatabaseAgentJobCredentialCmdletBase
    {
        /// <summary>
        /// Gets or sets the agent model input object
        /// </summary>
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent model input object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlDatabaseAgentModel InputObject { get; set; }

        /// <summary>
		/// Gets or sets the agent resource id
		/// </summary>
		[Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The agent resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the job credential name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The job credential name")]
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The job credential name")]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The job credential name")]
        [Alias("CredentialName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the job's credential
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            HelpMessage = "The credential")]
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The credential")]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The credential")]
        [ValidateNotNullOrEmpty]
        public PSCredential Credential { get; set; }

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
                    this.AgentName = InputObject.AgentName;
                    break;
                case ResourceIdParameterSet:
                    var resourceInfo = new ResourceIdentifier(ResourceId);
                    this.ResourceGroupName = resourceInfo.ResourceGroupName;
                    this.ServerName = ResourceIdentifier.GetTypeFromResourceType(resourceInfo.ParentResource);
                    this.AgentName = resourceInfo.ResourceName;
                    break;
                default:
                    break;
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Check to see if the credential already exists for the agent.
        /// </summary>
        /// <returns>Null if the credential doesn't exist. Otherwise throws exception</returns>
        protected override AzureSqlDatabaseAgentJobCredentialModel GetEntity()
        {
            try
            {
                WriteDebugWithTimestamp("CredentialName: {0}", Name);
                ModelAdapter.GetJobCredential(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no credential with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The credential already exists
            throw new PSArgumentException(
                string.Format(Properties.Resources.AzureSqlDatabaseAgentJobCredentialExists, this.Name, this.AgentName),
                "CredentialName");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the server doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override AzureSqlDatabaseAgentJobCredentialModel ApplyUserInputToModel(AzureSqlDatabaseAgentJobCredentialModel model)
        {
            AzureSqlDatabaseAgentJobCredentialModel newCredential = new AzureSqlDatabaseAgentJobCredentialModel
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                AgentName = this.AgentName,
                CredentialName = this.Name,
                UserName = this.Credential.UserName,
                Password = this.Credential.Password,
            };

            return newCredential;
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the job credential
        /// </summary>
        /// <param name="entity">The credential to create</param>
        /// <returns>The created job credential</returns>
        protected override AzureSqlDatabaseAgentJobCredentialModel PersistChanges(AzureSqlDatabaseAgentJobCredentialModel entity)
        {
            return ModelAdapter.UpsertJobCredential(entity);
        }
    }
}