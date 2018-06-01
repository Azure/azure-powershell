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
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Sql.ElasticJobs.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet
{
    /// <summary>
    /// Defines the New-AzureRmSqlElasticJobTargetGroup Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlElasticJobTargetGroup",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(IEnumerable<AzureSqlElasticJobTargetGroupModel>))]
    public class NewAzureSqlElasticJobTargetGroup : AzureSqlElasticJobTargetGroupCmdletBase<AzureSqlElasticJobAgentModel>
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
        /// Gets or sets the target group name
        /// </summary>
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 3,
            HelpMessage = "The target group name")]
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The target group name")]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The target group name")]
        [ValidateNotNullOrEmpty]
        [Alias("TargetGroupName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the agent input object
        /// </summary>
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent input object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlElasticJobAgentModel AgentObject { get; set; }

        /// <summary>
        /// Gets or sets the agent resource id
        /// </summary>
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The agent resource id")]
        [ValidateNotNullOrEmpty]
        public string AgentResourceId { get; set; }

        /// <summary>
        /// Execution starts here
        /// </summary>
        public override void ExecuteCmdlet()
        {
            InitializeInputObjectProperties(this.AgentObject);
            InitializeResourceIdProperties(this.AgentResourceId);
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Check to see if the target group already exists for the agent.
        /// </summary>
        /// <returns>Null if the target group doesn't exist. Otherwise throws exception</returns>
        protected override IEnumerable<AzureSqlElasticJobTargetGroupModel> GetEntity()
        {
            try
            {
                WriteDebugWithTimestamp("TargetGroupName: {0}", Name);
                ModelAdapter.GetTargetGroup(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name);
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
                string.Format(Properties.Resources.AzureElasticJobTargetGroupExists, this.Name, this.AgentName),
                "TargetGroupName");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the target group doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlElasticJobTargetGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticJobTargetGroupModel> model)
        {
            AzureSqlElasticJobTargetGroupModel targetGroup = new AzureSqlElasticJobTargetGroupModel
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                AgentName = this.AgentName,
                TargetGroupName = this.Name,
                Targets = new List<AzureSqlElasticJobTargetModel> { }, // We create an empty list of targets on creation of new target group
            };

            return new List<AzureSqlElasticJobTargetGroupModel> { targetGroup };
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the target group
        /// </summary>
        /// <param name="entity">The target group to create</param>
        /// <returns>The created target group</returns>
        protected override IEnumerable<AzureSqlElasticJobTargetGroupModel> PersistChanges(IEnumerable<AzureSqlElasticJobTargetGroupModel> entity)
        {
            return new List<AzureSqlElasticJobTargetGroupModel>
            {
                ModelAdapter.UpsertTargetGroup(entity.First())
            };
        }
    }
}