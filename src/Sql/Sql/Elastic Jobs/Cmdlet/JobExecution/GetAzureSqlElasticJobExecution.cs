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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlElasticJobExecution",
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlElasticJobExecutionModel))]
    public class GetAzureSqlElasticJobExecution : AzureSqlElasticJobExecutionCmdletBase<AzureSqlElasticJobAgentModel>
    {
        /// <summary>
        /// The parameter sets
        /// </summary>
        protected const string GetRootJobExecution = "WithJobExecutionId";
        protected const string GetRootJobExecutionByParentObject = "WithJobExecutionIdUsingParentObject";
        protected const string GetRootJobExecutionByParentResourceId = "WithJobExecutionIdUsingParentResourceId";

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The resource group name.")]
        [Parameter(ParameterSetName = GetRootJobExecution,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the agent object input model
        /// </summary>
        [Parameter(
            ParameterSetName = InputObjectParameterSet,
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The job execution id.")]
        [Parameter(
            ParameterSetName = GetRootJobExecutionByParentObject,
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The job execution id.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlElasticJobAgentModel ParentObject { get; set; }

        /// <summary>
        /// Gets or sets the agent resource id
        /// </summary>
        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The agent resource id.")]
        [Parameter(
            ParameterSetName = GetRootJobExecutionByParentResourceId,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The agent resource id.")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceId { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The server name.")]
        [Parameter(ParameterSetName = GetRootJobExecution,
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
        [Parameter(ParameterSetName = GetRootJobExecution,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The agent name.")]
        [ValidateNotNullOrEmpty]
        public override string AgentName { get; set; }

        /// <summary>
        /// Gets or sets the job name
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet,
            HelpMessage = "The job name.")]
        [Parameter(ParameterSetName = InputObjectParameterSet,

            HelpMessage = "The job name.")]
        [Parameter(ParameterSetName = ResourceIdParameterSet,

            HelpMessage = "The job name.")]
        [Parameter(ParameterSetName = GetRootJobExecution,
            Mandatory = true,
            Position = 3,
            HelpMessage = "The job name.")]
        [Parameter(
            ParameterSetName = GetRootJobExecutionByParentObject,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The job name.")]
        [Parameter(
            ParameterSetName = GetRootJobExecutionByParentResourceId,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The job name.")]
        [ValidateNotNullOrEmpty]
        public override string JobName { get; set; }

        /// <summary>
        /// Gets or sets the top executions to return in the response
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, Position = 3, HelpMessage = "Count returns the top number of executions.")]
        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = true, Position = 2, HelpMessage = "Count returns the top number of executions.")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = true, Position = 2, HelpMessage = "Count returns the top number of executions.")]
        public int? Count { get; set; }

        /// <summary>
        /// Gets or sets the job execution id
        /// </summary>
        [Parameter(ParameterSetName = GetRootJobExecution,
            Mandatory = true,
            HelpMessage = "The job execution id.")]
        [Parameter(ParameterSetName = GetRootJobExecutionByParentObject,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The job execution id.")]
        [Parameter(ParameterSetName = GetRootJobExecutionByParentResourceId,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The job execution id.")]
        [ValidateNotNullOrEmpty]
        public override string JobExecutionId { get; set; }

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
        [Parameter(ParameterSetName = DefaultParameterSet, HelpMessage = "Filter by create time min")]
        [Parameter(ParameterSetName = InputObjectParameterSet, HelpMessage = "Filter by create time min")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, HelpMessage = "Filter by create time min")]
        public DateTime? CreateTimeMax { get; set; }

        /// <summary>
        /// Gets or sets the min end time
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, HelpMessage = "Filter by create time min")]
        [Parameter(ParameterSetName = InputObjectParameterSet, HelpMessage = "Filter by create time min")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, HelpMessage = "Filter by create time min")]
        public DateTime? EndTimeMin { get; set; }

        /// <summary>
        /// Gets or sets the max end time
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, HelpMessage = "Filter by create time min")]
        [Parameter(ParameterSetName = InputObjectParameterSet, HelpMessage = "Filter by create time min")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, HelpMessage = "Filter by create time min")]
        public DateTime? EndTimeMax { get; set; }

        /// <summary>
        /// Gets or sets the active switch parameter. Filters by active/in progress executions
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, HelpMessage = "Filter by create time min")]
        [Parameter(ParameterSetName = InputObjectParameterSet, HelpMessage = "Filter by create time min")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, HelpMessage = "Filter by create time min")]
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
            if (this.JobExecutionId != null)
            {
                var jobExecution = ModelAdapter.GetJobExecution(
                    resourceGroupName: this.ResourceGroupName,
                    serverName: this.ServerName,
                    agentName: this.AgentName,
                    jobName: this.JobName,
                    jobExecutionId: Guid.Parse(this.JobExecutionId));

                return new List<AzureSqlElasticJobExecutionModel> { jobExecution };
            }
            else if (this.JobName != null)
            {
                var jobExecutions = ModelAdapter.ListByJob(
                    resourceGroupName: this.ResourceGroupName,
                    serverName: this.ServerName,
                    agentName: this.AgentName,
                    jobName: this.JobName,
                    createTimeMin: this.CreateTimeMin,
                    createTimeMax: this.CreateTimeMax,
                    endTimeMin: this.EndTimeMin,
                    endTimeMax: this.EndTimeMax,
                    isActive: this.Active.IsPresent ? this.Active : (bool?)null,
                    top: this.Count);

                return jobExecutions;
            }

            var allExecutions = ModelAdapter.ListByAgent(
                resourceGroupName: this.ResourceGroupName,
                serverName: this.ServerName,
                agentName: this.AgentName,
                createTimeMin: this.CreateTimeMin,
                createTimeMax: this.CreateTimeMax,
                endTimeMin: this.EndTimeMin,
                endTimeMax: this.EndTimeMax,
                isActive: this.Active.IsPresent ? this.Active : (bool?)null,
                top: this.Count);

            return allExecutions;
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