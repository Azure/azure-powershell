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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlElasticJobCredential Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlElasticJobCredential",
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlElasticJobCredentialModel))]
    public class GetAzureSqlElasticJobCredential : AzureSqlElasticJobCredentialCmdletBase<AzureSqlElasticJobAgentModel>
    {
        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, Position = 0, HelpMessage = "The resource group name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the agent model input object
        /// </summary>
        [Parameter(
            ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlElasticJobAgentModel ParentObject { get; set; }

        /// <summary>
        /// Gets or sets the agent resource id
        /// </summary>
        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The agent resource id")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceId { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, Position = 1, HelpMessage = "The server name")]
        [ValidateNotNullOrEmpty]
        public override string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, Position = 2, HelpMessage = "The agent name")]
        [ValidateNotNullOrEmpty]
        public override string AgentName { get; set; }

        /// <summary>
        /// Gets or sets the credential name
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, HelpMessage = "The job credential name")]
        [Parameter(ParameterSetName = InputObjectParameterSet, HelpMessage = "The job credential name")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, HelpMessage = "The job credential name")]
        [ValidateNotNullOrEmpty]
        [Alias("CredentialName")]
        public override string Name { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            InitializeInputObjectProperties(this.ParentObject);
            InitializeResourceIdProperties(this.ParentResourceId);
            base.ExecuteCmdlet();
            ClearProperties();
        }

        /// <summary>
        /// Check to see if the credential already exists for the agent.
        /// </summary>
        /// <returns>Throws exception if the credential doesn't exist.</returns>
        protected override IEnumerable<AzureSqlElasticJobCredentialModel> GetEntity()
        {
            try
            {
                // Returns a list of credentials
                if (this.Name == null)
                {
                    return ModelAdapter.ListJobCredentials(this.ResourceGroupName, this.ServerName, this.AgentName);
                }
                else
                {
                    return new List<AzureSqlElasticJobCredentialModel>
                    {
                        ModelAdapter.GetJobCredential(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name)
                    };
                }
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // The credential does not exist
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureElasticJobCredentialNotExists, this.Name, this.AgentName),
                        "CredentialName");
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
        protected override IEnumerable<AzureSqlElasticJobCredentialModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticJobCredentialModel> model)
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
        protected override IEnumerable<AzureSqlElasticJobCredentialModel> PersistChanges(IEnumerable<AzureSqlElasticJobCredentialModel> entity)
        {
            return entity;
        }
    }
}