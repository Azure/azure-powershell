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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ElasticJobs.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet
{
    /// <summary>
    /// Defines the Remove-AzureRmSqlElasticJobTargetGroup Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlElasticJobTargetGroup",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlElasticJobTargetGroupModel))]
    public class RemoveAzureSqlElasticJobTargetGroup: AzureSqlElasticJobTargetGroupCmdletBase<AzureSqlElasticJobTargetGroupModel>
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
        /// Gets or sets the agent input object
        /// </summary>
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The target group object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlElasticJobTargetGroupModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the agent resource id
        /// </summary>
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The target group resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

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
        [Parameter(ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 3,
            HelpMessage = "The target group name")]
        [Alias("TargetGroupName")]
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
            InitializeInputObjectProperties(this.InputObject);
            InitializeResourceIdProperties(this.ResourceId);
            this.Name = this.Name ?? this.TargetGroupName;
            base.ExecuteCmdlet();
            ClearProperties();
        }

        /// <summary>
        /// Check to see if the target group already exists.
        /// </summary>
        /// <returns>Throws error if the target group doesn't exist. Otherwise returns the target group</returns>
        protected override IEnumerable<AzureSqlElasticJobTargetGroupModel> GetEntity()
        {
            try
            {
                AzureSqlElasticJobTargetGroupModel targetGroup = ModelAdapter.GetTargetGroup(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name);

                // We should only delete target group under these conditions.
                // 1. Force is given
                // 2. Force is not given, but Target group has no targets
                // 3. Force is not given, Target group has targets and confirmation is accepted

                // If force is present, remove the target group
                if (Force.IsPresent)
                {
                    return new List<AzureSqlElasticJobTargetGroupModel> { targetGroup };
                }
                else
                {
                    // Force is not present
                    bool hasTargets = targetGroup.Targets.Count > 0;

                    // There were no targets in target group, so we can just remove the target group
                    if (!hasTargets)
                    {
                        return new List<AzureSqlElasticJobTargetGroupModel> { targetGroup };
                    }
                    // There are targets in the target group - Give confirmation message
                    else
                    {
                        if (ShouldContinue(
                            string.Format(CultureInfo.InvariantCulture,
                            Properties.Resources.RemoveElasticJobTargetGroupWarning, this.Name, this.AgentName),
                            Properties.Resources.ShouldProcessCaption))
                        {
                            // Since confirmation succeeded, we can return the target group to delete
                            return new List<AzureSqlElasticJobTargetGroupModel> { targetGroup };
                        }
                        else
                        {
                            // Otherwise, return empty list to do nothing
                            return new List<AzureSqlElasticJobTargetGroupModel> { };
                        }
                    }
                }
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // The target group does not exist
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureElasticJobTargetGroupNotExists, this.Name, this.AgentName),
                        "TargetGroupName");
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
        protected override IEnumerable<AzureSqlElasticJobTargetGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticJobTargetGroupModel> model)
        {
            return model;
        }

        /// <summary>
        /// Sends the changes to the service -> Removes the target group
        /// </summary>
        /// <param name="entity">The target group to remove</param>
        /// <returns>The removed target group</returns>
        protected override IEnumerable<AzureSqlElasticJobTargetGroupModel> PersistChanges(IEnumerable<AzureSqlElasticJobTargetGroupModel> entity)
        {
            // If passed entity had no target group to remove, just return empty list.
            var existingEntity = entity.FirstOrDefault();
            if (existingEntity == null)
            {
                return new List<AzureSqlElasticJobTargetGroupModel> { };
            }

            // If we had a target group to remove, then we remove here.
            ModelAdapter.RemoveTargetGroup(existingEntity.ResourceGroupName, existingEntity.ServerName, existingEntity.AgentName, existingEntity.TargetGroupName);
            return entity;
        }
    }
}