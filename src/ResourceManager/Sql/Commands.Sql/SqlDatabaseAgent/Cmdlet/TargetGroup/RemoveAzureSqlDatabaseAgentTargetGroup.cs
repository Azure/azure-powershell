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
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Cmdlet
{
    /// <summary>
    /// Defines the Remove-AzureRmSqlDatabaseAgentTargetGroup Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlDatabaseAgentTargetGroup",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlDatabaseAgentTargetGroupModel))]
    public class RemoveAzureSqlDatabaseAgentTargetGroup: AzureSqlDatabaseAgentTargetGroupCmdletBase
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
        public AzureSqlDatabaseAgentTargetGroupModel InputObject { get; set; }

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
        [Parameter(ParameterSetName = DefaultParameterSet, 
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The target group name")]
        [Alias("TargetGroupName")]
        public string Name { get; set; }

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
            switch (ParameterSetName)
            {
                case InputObjectParameterSet:
                    this.ResourceGroupName = InputObject.ResourceGroupName;
                    this.ServerName = InputObject.ServerName;
                    this.AgentName = InputObject.AgentName;
                    this.Name = InputObject.TargetGroupName;
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

            // Warning confirmation for deletion for target group
            if (!Force.IsPresent && !ShouldProcess(string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveSqlDatabaseAgentTargetGroupDescription, this.Name, this.AgentName),
                   string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveSqlDatabaseAgentTargetGroupWarning, this.Name, this.AgentName),
                   Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Check to see if the target group already exists.
        /// </summary>
        /// <returns>Throws error if the target group doesn't exist. Otherwise returns the target group</returns>
        protected override AzureSqlDatabaseAgentTargetGroupModel GetEntity()
        {
            try
            {
                return ModelAdapter.GetTargetGroup(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // The target group does not exist
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureSqlDatabaseAgentTargetGroupNotExists, this.Name, this.AgentName),
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
        protected override AzureSqlDatabaseAgentTargetGroupModel ApplyUserInputToModel(AzureSqlDatabaseAgentTargetGroupModel model)
        {
            return model;
        }

        /// <summary>
        /// Sends the changes to the service -> Removes the target group
        /// </summary>
        /// <param name="entity">The target group to remove</param>
        /// <returns>The removed target group</returns>
        protected override AzureSqlDatabaseAgentTargetGroupModel PersistChanges(AzureSqlDatabaseAgentTargetGroupModel entity)
        {
            ModelAdapter.RemoveTargetGroup(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name);
            return entity;
        }
    }
}