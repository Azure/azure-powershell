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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet
{
    /// <summary>
    /// Defines the New-AzureRmSqlElasticJobCredential Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlElasticJobCredential",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(IEnumerable<AzureSqlElasticJobCredentialModel>))]
    public class NewAzureSqlElasticJobCredential : AzureSqlElasticJobCredentialCmdletBase<AzureSqlElasticJobAgentModel>
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
        /// Gets or sets the job credential name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 3,
            HelpMessage = "The job credential name")]
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The job credential name")]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The job credential name")]
        [Alias("CredentialName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the job's credential
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 4,
            HelpMessage = "The credential")]
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The credential")]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The credential")]
        [ValidateNotNullOrEmpty]
        public PSCredential Credential { get; set; }

        /// <summary>
        /// Gets or sets the agent model input object
        /// </summary>
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlElasticJobAgentModel AgentObject { get; set; }

        /// <summary>
        /// Gets or sets the agent resource id
        /// </summary>
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The agent resource id")]
        [ValidateNotNullOrEmpty]
        public string AgentResourceId { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            InitializeInputObjectProperties(this.AgentObject);
            InitializeResourceIdProperties(this.AgentResourceId);
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Check to see if the credential already exists for the agent.
        /// </summary>
        /// <returns>Null if the credential doesn't exist. Otherwise throws exception</returns>
        protected override IEnumerable<AzureSqlElasticJobCredentialModel> GetEntity()
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
                string.Format(Properties.Resources.AzureElasticJobCredentialExists, this.Name, this.AgentName),
                "CredentialName");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the server doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlElasticJobCredentialModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticJobCredentialModel> model)
        {
            AzureSqlElasticJobCredentialModel newCredential = new AzureSqlElasticJobCredentialModel
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                AgentName = this.AgentName,
                CredentialName = this.Name,
                UserName = this.Credential.UserName,
                Password = this.Credential.Password,
            };

            return new List<AzureSqlElasticJobCredentialModel> { newCredential };
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the job credential
        /// </summary>
        /// <param name="entity">The credential to create</param>
        /// <returns>The created job credential</returns>
        protected override IEnumerable<AzureSqlElasticJobCredentialModel> PersistChanges(IEnumerable<AzureSqlElasticJobCredentialModel> entity)
        {
            return new List<AzureSqlElasticJobCredentialModel>
            {
                ModelAdapter.UpsertJobCredential(entity.First())
            };
        }
    }
}