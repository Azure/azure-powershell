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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ElasticJobs.Model;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet.JobExecution
{
    /// <summary>
    /// Defines the Get-AzureRmSqlElasticJobTargetExecution Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlElasticJobTargetExecution",
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlElasticJobExecutionModel))]
    public class GetAzureSqlElasticJobTargetExecution : AzureSqlElasticJobExecutionCmdletBase<AzureSqlElasticJobExecutionModel>
    {
        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the job execution object input model
        /// </summary>
        [Parameter(
            ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The job execution object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlElasticJobExecutionModel ParentObject { get; set; }

        /// <summary>
        /// Gets or sets the job execution resource id
        /// </summary>
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The job execution resource id.")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceId { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The server name.")]
        [ValidateNotNullOrEmpty]
        public override string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the agent name
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The agent name.")]
        [ValidateNotNullOrEmpty]
        public override string AgentName { get; set; }

        /// <summary>
        /// Gets or sets the job name
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 3,
            HelpMessage = "The job name.")]
        public override string JobName { get; set; }

        /// <summary>
        /// Gets or sets the job execution id
        /// </summary>
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            HelpMessage = "The job execution id.")]
        public override string JobExecutionId { get; set; }

        /// <summary>
        /// Gets or sets the top executions to return in the response
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "Count returns the top number of executions.")]
        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = true, Position = 1, HelpMessage = "Count returns the top number of executions.")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = true, Position = 1, HelpMessage = "Count returns the top number of executions.")]
        public int? Count { get; set; }

        /// <summary>
        /// Gets or sets the job step name
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, HelpMessage = "The job step name.")]
        [Parameter(ParameterSetName = InputObjectParameterSet, HelpMessage = "The job step name.")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, HelpMessage = "The job step name.")]
        public override string StepName { get; set; }

        /// <summary>
        /// Gets or sets the min create time
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, HelpMessage = "Filter by create time min")]
        [Parameter(ParameterSetName = InputObjectParameterSet, HelpMessage = "Filter by create time min")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, HelpMessage = "Filter by create time min")]
        public DateTime? CreateTimeMin { get; set; }

        /// <summary>
        /// Gets or sets the max create time
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, HelpMessage = "Filter by create time max")]
        [Parameter(ParameterSetName = InputObjectParameterSet, HelpMessage = "Filter by create time max")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, HelpMessage = "Filter by create time max")]
        public DateTime? CreateTimeMax { get; set; }

        /// <summary>
        /// Gets or sets the min end time
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, HelpMessage = "Filter by end time min.")]
        [Parameter(ParameterSetName = InputObjectParameterSet, HelpMessage = "Filter by end time min.")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, HelpMessage = "Filter by end time min.")]
        public DateTime? EndTimeMin { get; set; }

        /// <summary>
        /// Gets or sets the max end time
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, HelpMessage = "Filter by end time max.")]
        [Parameter(ParameterSetName = InputObjectParameterSet, HelpMessage = "Filter by end time max.")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, HelpMessage = "Filter by end time max.")]
        public DateTime? EndTimeMax { get; set; }

        /// <summary>
        /// Gets or sets the active switch parameter. Filters by active/in progress executions
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, HelpMessage = "Flag to filter by active executions.")]
        [Parameter(ParameterSetName = InputObjectParameterSet, HelpMessage = "Flag to filter by active executions.")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, HelpMessage = "Flag to filter by active executions.")]
        public SwitchParameter Active { get; set; }

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
        /// Gets job execution(s) from the service.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<AzureSqlElasticJobExecutionModel> GetEntity()
        {
            if (this.StepName != null)
            {
                var targetStepExecutions = ModelAdapter.ListJobTargetExecutionsByStep(
                    resourceGroupName: this.ResourceGroupName,
                    serverName: this.ServerName,
                    agentName: this.AgentName,
                    jobName: this.JobName,
                    jobExecutionId: Guid.Parse(this.JobExecutionId),
                    stepName: this.StepName,
                    createTimeMin: this.CreateTimeMin,
                    createTimeMax: this.CreateTimeMax,
                    isActive: this.Active.IsPresent ? this.Active : (bool?)null,
                    endTimeMin: this.EndTimeMin,
                    endTimeMax: this.EndTimeMax,
                    top: this.Count);

                return targetStepExecutions;
            }

            var allTargetExecutions = ModelAdapter.ListJobTargetExecutions(
                resourceGroupName: this.ResourceGroupName,
                serverName: this.ServerName,
                agentName: this.AgentName,
                jobName: this.JobName,
                jobExecutionId: Guid.Parse(this.JobExecutionId),
                createTimeMin: this.CreateTimeMin,
                createTimeMax: this.CreateTimeMax,
                isActive: this.Active.IsPresent ? this.Active : (bool?)null,
                endTimeMin: this.EndTimeMin,
                endTimeMax: this.EndTimeMax,
                top: this.Count);

            return allTargetExecutions;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlElasticJobExecutionModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticJobExecutionModel> model)
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
        protected override IEnumerable<AzureSqlElasticJobExecutionModel> PersistChanges(IEnumerable<AzureSqlElasticJobExecutionModel> entity)
        {
            return entity;
        }
    }
}