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
using System.Globalization;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet.PrivateEndpoint
{
    /// <summary>
    /// Defines the Remove-AzSqlElasticJobPrivateEndpoint Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlElasticJobPrivateEndpoint",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlElasticJobPrivateEndpointModel))]
    public class RemoveAzureSqlElasticJobPrivateEndpoint : AzureSqlElasticJobPrivateEndpointCmdletBase<AzureSqlElasticJobAgentModel>
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
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Execution starts here
        /// </summary>
        public override void ExecuteCmdlet()
        {
            InitializeInputObjectProperties(this.ElasticJobAgentObject);
            InitializeResourceIdProperties(this.ElasticJobAgentResourceId);
            this.Name = this.Name ?? this.PrivateEndpointName;

            // Warning confirmation when deleting job private endpoint 
            if (!Force.IsPresent &&
                !ShouldContinue(string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveElasticJobPrivateEndpointWarning, this.Name, this.AgentName),
                               Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ExecuteCmdlet();
            ClearProperties();
        }

        /// <summary>
        /// Gets job private endpoint to see if it exists before removing
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<AzureSqlElasticJobPrivateEndpointModel> GetEntity()
        {
            try
            {
                return new List<AzureSqlElasticJobPrivateEndpointModel>
                {
                    ModelAdapter.GetJobPrivateEndpoint(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name)
                };
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // The job private endpoint doesn't exists
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureElasticJobPrivateEndpointNotExists, this.Name, this.AgentName),
                        "PrivateEndpointName");
                }

                // Unexpected exception encountered
                throw;
            }
        }

        /// <summary>
        /// Apply user input.
        /// </summary>
        /// <param name="model">The result of GetEntity</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlElasticJobPrivateEndpointModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticJobPrivateEndpointModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the job private endpoint.
        /// </summary>
        /// <param name="entity">The job private endpoint being deleted</param>
        /// <returns>The job private endpoint that was deleted</returns>
        protected override IEnumerable<AzureSqlElasticJobPrivateEndpointModel> PersistChanges(IEnumerable<AzureSqlElasticJobPrivateEndpointModel> entity)
        {
            var existingEntity = entity.First();
            ModelAdapter.RemoveJobPrivateEndpoint(existingEntity.ResourceGroupName, existingEntity.ServerName, existingEntity.AgentName, existingEntity.PrivateEndpointName);
            return entity;
        }
    }
}
