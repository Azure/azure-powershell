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
    /// Defines the Get-AzureRmSqlElasticJobExecution Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlElasticJobStepExecution",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(IEnumerable<AzureSqlElasticJobExecutionModel>))]
    public class GetAzureSqlElasticJobStepExecution : AzureSqlElasticJobExecutionCmdletBase<AzureSqlElasticJobExecutionModel>
    {
        /// <summary>
        /// The parameter sets
        /// </summary>
        protected const string GetJobStepExecutionDefaultParam = "Get Job Step Execution Parameter Set";
        protected const string GetJobStepExecutionJobExecutionModel = "Get Job Step Execution Parameter Set Using Job Execution Object";
        protected const string GetJobStepExecutionJobExecutionResourceId = "Get Job Step Execution Parameter Set Using Job Execution Resource Id";

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The resource group name.")]
        [Parameter(ParameterSetName = GetJobStepExecutionDefaultParam,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The server name.")]
        [Parameter(ParameterSetName = GetJobStepExecutionDefaultParam,
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
        [Parameter(ParameterSetName = GetJobStepExecutionDefaultParam,
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
        [Parameter(ParameterSetName = GetJobStepExecutionDefaultParam,
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
            Position = 4,
            HelpMessage = "The job execution id.")]
        [Parameter(
            ParameterSetName = GetJobStepExecutionDefaultParam,
            Mandatory = true,
            Position = 4,
            HelpMessage = "The job execution id.")]
        public override string JobExecutionId { get; set; }

        /// <summary>
        /// Gets or sets the job step name
        /// </summary>
        [Parameter(
            ParameterSetName = GetJobStepExecutionDefaultParam,
            Mandatory = true,
            Position = 5,
            HelpMessage = "The job step name.")]
        [Parameter(
            ParameterSetName = GetJobStepExecutionJobExecutionModel,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The job step name.")]
        [Parameter(
            ParameterSetName = GetJobStepExecutionJobExecutionResourceId,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The job step name.")]
        public override string StepName { get; set; }

        /// <summary>
        /// Gets or sets the min create time
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "Filter by create time min")]
        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = false, HelpMessage = "Filter by create time min")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = false, HelpMessage = "Filter by create time min")]
        public DateTime? CreateTimeMin { get; set; }

        /// <summary>
        /// Gets or sets the max create time
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "Filter by create time max")]
        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = false, HelpMessage = "Filter by create time max")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = false, HelpMessage = "Filter by create time max")]
        public DateTime? CreateTimeMax { get; set; }

        /// <summary>
        /// Gets or sets the min end time
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "Filter by end time min.")]
        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = false, HelpMessage = "Filter by end time min.")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = false, HelpMessage = "Filter by end time min.")]
        public DateTime? EndTimeMin { get; set; }

        /// <summary>
        /// Gets or sets the max end time
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "Filter by end time max.")]
        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = false, HelpMessage = "Filter by end time max.")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = false, HelpMessage = "Filter by end time max.")]
        public DateTime? EndTimeMax { get; set; }

        /// <summary>
        /// Gets or sets the active switch parameter. Filters by active/in progress executions
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "Flag to filter by active executions.")]
        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = false, HelpMessage = "Flag to filter by active executions.")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = false, HelpMessage = "Flag to filter by active executions.")]
        public SwitchParameter Active { get; set; }

        /// <summary>
        /// Gets or sets the job execution object input model
        /// </summary>
        [Parameter(
            ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent object.")]
        [Parameter(
            ParameterSetName = GetJobStepExecutionJobExecutionModel,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlElasticJobExecutionModel JobExecutionObject { get; set; }

        /// <summary>
        /// Gets or sets the job execution resource id
        /// </summary>
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The job execution resource id.")]
        [Parameter(ParameterSetName = GetJobStepExecutionJobExecutionResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The job execution resource id.")]
        [ValidateNotNullOrEmpty]
        public string JobExecutionResourceId { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            InitializeInputObjectProperties(this.JobExecutionObject);
            InitializeResourceIdProperties(this.JobExecutionResourceId);
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Gets job step execution(s) from the service.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<AzureSqlElasticJobExecutionModel> GetEntity()
        {
            if (this.StepName != null)
            {
                var stepExecution = ModelAdapter.GetJobStepExecution(
                    resourceGroupName: this.ResourceGroupName,
                    serverName: this.ServerName,
                    agentName: this.AgentName,
                    jobName: this.JobName,
                    jobExecutionId: Guid.Parse(this.JobExecutionId),
                    stepName: this.StepName);
                return new List<AzureSqlElasticJobExecutionModel> { stepExecution };
            }

            var allStepExecutions = ModelAdapter.ListJobExecutionSteps(
                resourceGroupName: this.ResourceGroupName,
                serverName: this.ServerName,
                agentName: this.AgentName,
                jobName: this.JobName,
                jobExecutionId: Guid.Parse(this.JobExecutionId),
                createTimeMin: this.CreateTimeMin,
                createTimeMax: this.CreateTimeMax,
                endTimeMin: this.EndTimeMin,
                endTimeMax: this.EndTimeMax,
                isActive: this.Active.IsPresent ? this.Active : (bool?)null);

            return allStepExecutions;
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