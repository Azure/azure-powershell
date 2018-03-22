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
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Cmdlet
{
    /// <summary>
    /// Defines the New-AzureRmSqlDatabaseAgentTargetGroup Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlDatabaseAgentTargetGroup",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlDatabaseAgentTargetGroupModel))]
    public class NewAzureSqlDatabaseAgentTargetGroup : AzureSqlDatabaseAgentTargetGroupCmdletBase
    {
        /// <summary>
        /// Gets or sets the agent input object
        /// </summary>
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent input object")]
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
        /// Gets or sets the target group name
        /// </summary>
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The target group name")]
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The target group name")]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The target group name")]
        [ValidateNotNullOrEmpty]
        [Alias("TargetGroupName")]
        public string Name { get; set; }

        /// <summary>
        /// Writes a list of target groups if name is not given, otherwise returns the target group asked for.
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
        /// Check to see if the target group already exists for the agent.
        /// </summary>
        /// <returns>Null if the target group doesn't exist. Otherwise throws exception</returns>
        protected override AzureSqlDatabaseAgentTargetGroupModel GetEntity()
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
                string.Format(Properties.Resources.AzureSqlDatabaseAgentTargetGroupExists, this.Name, this.AgentName),
                "TargetGroupName");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the target group doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override AzureSqlDatabaseAgentTargetGroupModel ApplyUserInputToModel(AzureSqlDatabaseAgentTargetGroupModel model)
        {
            AzureSqlDatabaseAgentTargetGroupModel targetGroup = new AzureSqlDatabaseAgentTargetGroupModel
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                AgentName = this.AgentName,
                TargetGroupName = this.Name,
                Members = new List<Management.Sql.Models.JobTarget> { }, // We create an empty list of targets on creation of new target group
            };

            return targetGroup;
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the target group
        /// </summary>
        /// <param name="entity">The target group to create</param>
        /// <returns>The created target group</returns>
        protected override AzureSqlDatabaseAgentTargetGroupModel PersistChanges(AzureSqlDatabaseAgentTargetGroupModel entity)
        {
            return ModelAdapter.UpsertTargetGroup(entity);
        }
    }
}