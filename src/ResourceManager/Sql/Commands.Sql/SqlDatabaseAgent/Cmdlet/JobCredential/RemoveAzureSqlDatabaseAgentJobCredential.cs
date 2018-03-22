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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Cmdlet
{
    /// <summary>
    /// Defines the Remove-AzureRmSqlDatabaseAgentJobCredential Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlDatabaseAgentJobCredential", 
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlDatabaseAgentJobCredentialModel))]
    public class RemoveAzureSqlDatabaseAgentJobCredential : AzureSqlDatabaseAgentJobCredentialCmdletBase
    {
        /// <summary>
        /// Gets or sets the job credential input object to remove
        /// </summary>
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The job credential object to remove")]
        [ValidateNotNullOrEmpty]
        public AzureSqlDatabaseAgentJobCredentialModel InputObject { get; set; }

        /// <summary>
		/// Gets or sets the job credential resource id to remove
		/// </summary>
		[Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The job credential resource id of the credential to remove")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the job credential's name.
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, 
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The job credential name")]
        [Alias("CredentialName")]
        public string Name { get; set; }

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
                    this.Name = InputObject.CredentialName;
                    break;
                case ResourceIdParameterSet:
                    string[] tokens = ResourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    this.ResourceGroupName = tokens[3];
                    this.ServerName = tokens[7];
                    this.AgentName = tokens[9];
                    this.Name = tokens[tokens.Length - 1];
                    break;
                default:
                    break;
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Check to see if the credential already exists for the agent.
        /// </summary>
        /// <returns>Throws exception if the credential doesn't exist.<returns>
        protected override AzureSqlDatabaseAgentJobCredentialModel GetEntity()
        {
            try
            {
                return ModelAdapter.GetJobCredential(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // The credential does not exist
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureSqlDatabaseAgentJobCredentialNotExists, this.Name, this.AgentName),
                        "CredentialName");
                }

                // Unexpected exception encountered
                throw;
            }
        }

        /// <summary>
        /// No user input to apply to the model.
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override AzureSqlDatabaseAgentJobCredentialModel ApplyUserInputToModel(AzureSqlDatabaseAgentJobCredentialModel model)
        {
            return model;
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the job credential
        /// </summary>
        /// <param name="entity">The credential to create</param>
        /// <returns>The created job credential</returns>
        protected override AzureSqlDatabaseAgentJobCredentialModel PersistChanges(AzureSqlDatabaseAgentJobCredentialModel entity)
        {
            ModelAdapter.RemoveJobCredential(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name);
            return entity;
        }
    }
}