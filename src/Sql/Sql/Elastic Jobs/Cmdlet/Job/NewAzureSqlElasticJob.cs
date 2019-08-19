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
using System;
using Microsoft.Azure.Management.Sql.Models;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using static Microsoft.Azure.Commands.Sql.Common.Iso8601DurationHelper;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet
{
    /// <summary>
    /// Defines the New-AzureRmSqlElasticJob Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlElasticJob",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlElasticJobModel))]
    public class NewAzureSqlElasticJob : AzureSqlElasticJobCmdletBase<AzureSqlElasticJobAgentModel>
    {
        /// <summary>
        /// The Parameter Set
        /// </summary>
        protected const string AgentDefaultRunOnceParameterSet = "RunOnce";
        protected const string AgentDefaultRecurringParameterSet = "Recurring";
        protected const string ParentObjectRunOnceParameterSet = "RunOnceUsingParentObject";
        protected const string ParentObjectRecurringParameterSet = "RecurringUsingParentObject";
        protected const string ParentResourceIdRunOnceParameterSet = "RunOnceUsingParentResourceId";
        protected const string ParentResourceIdRecurringParameterSet = "RecurringUsingParentResourceId";

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, Position = 0, HelpMessage = "The resource group name")]
        [Parameter(Mandatory = true, ParameterSetName = AgentDefaultRunOnceParameterSet, Position = 0, HelpMessage = "The resource group name")]
        [Parameter(Mandatory = true, ParameterSetName = AgentDefaultRecurringParameterSet, Position = 0, HelpMessage = "The resource group name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the agent input object
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent input object")]
        [Parameter(Mandatory = true,
            ParameterSetName = ParentObjectRunOnceParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent input object")]
        [Parameter(Mandatory = true,
            ParameterSetName = ParentObjectRecurringParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent input object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlElasticJobAgentModel ParentObject { get; set; }

        /// <summary>
        /// Gets or sets the agent resource id
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The agent resource id")]
        [Parameter(Mandatory = true,
            ParameterSetName = ParentResourceIdRunOnceParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The agent resource id")]
        [Parameter(Mandatory = true,
            ParameterSetName = ParentResourceIdRecurringParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The agent resource id")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceId { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, Position = 1, HelpMessage = "The server name")]
        [Parameter(Mandatory = true, ParameterSetName = AgentDefaultRunOnceParameterSet, Position = 1, HelpMessage = "The server name")]
        [Parameter(Mandatory = true, ParameterSetName = AgentDefaultRecurringParameterSet, Position = 1, HelpMessage = "The server name")]
        [ValidateNotNullOrEmpty]
        public override string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the agent name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, Position = 2, HelpMessage = "The agent name")]
        [Parameter(Mandatory = true, ParameterSetName = AgentDefaultRunOnceParameterSet, Position = 2, HelpMessage = "The agent name")]
        [Parameter(Mandatory = true, ParameterSetName = AgentDefaultRecurringParameterSet, Position = 2, HelpMessage = "The agent name")]
        [ValidateNotNullOrEmpty]
        public override string AgentName { get; set; }

        /// <summary>
        /// Gets or sets the job name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, Position = 3, HelpMessage = "The job name")]
        [Parameter(Mandatory = true, ParameterSetName = AgentDefaultRunOnceParameterSet, Position = 3, HelpMessage = "The job name")]
        [Parameter(Mandatory = true, ParameterSetName = AgentDefaultRecurringParameterSet, Position = 3, HelpMessage = "The job name")]
        [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, Position = 1, HelpMessage = "The job name")]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectRunOnceParameterSet, Position = 1, HelpMessage = "The job name")]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectRecurringParameterSet, Position = 1, HelpMessage = "The job name")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, Position = 1, HelpMessage = "The job name")]
        [Parameter(Mandatory = true, ParameterSetName = ParentResourceIdRunOnceParameterSet, Position = 1, HelpMessage = "The job name")]
        [Parameter(Mandatory = true, ParameterSetName = ParentResourceIdRecurringParameterSet, Position = 1, HelpMessage = "The job name")]
        [ValidateNotNullOrEmpty]
        [Alias("JobName")]
        public override string Name { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter run once
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AgentDefaultRunOnceParameterSet, HelpMessage = "The flag to indicate job will be run once")]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectRunOnceParameterSet, Position = 2, HelpMessage = "The flag to indicate job will be run once")]
        [Parameter(Mandatory = true, ParameterSetName = ParentResourceIdRunOnceParameterSet, Position = 2, HelpMessage = "The flag to indicate job will be run once")]
        public SwitchParameter RunOnce { get; set; }

        /// <summary>
        /// Get or sets the job schedule interval type
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AgentDefaultRecurringParameterSet,
            HelpMessage = "The recurring schedule interval type - Can be Minute, Hour, Day, Week, Month")]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectRecurringParameterSet, Position = 2,
            HelpMessage = "The recurring schedule interval type - Can be Minute, Hour, Day, Week, Month")]
        [Parameter(Mandatory = true, ParameterSetName = ParentResourceIdRecurringParameterSet, Position = 2,
            HelpMessage = "The recurring schedule interval type - Can be Minute, Hour, Day, Week, Month")]
        [PSArgumentCompleter("Minute", "Hour", "Day", "Week", "Month")]
        public string IntervalType { get; set; }

        /// <summary>
        /// Gets or sets the job schedule interval count
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AgentDefaultRecurringParameterSet, HelpMessage = "The recurring schedule interval count")]
        [Parameter(Mandatory = true, ParameterSetName = ParentObjectRecurringParameterSet, Position = 3, HelpMessage = "The recurring schedule interval count")]
        [Parameter(Mandatory = true, ParameterSetName = ParentResourceIdRecurringParameterSet, Position = 3, HelpMessage = "The recurring schedule interval count")]
        public uint? IntervalCount { get; set; }

        /// <summary>
        /// Gets or sets the job schedule start time
        /// </summary>
        [Parameter(ParameterSetName = AgentDefaultRunOnceParameterSet, HelpMessage = "The job schedule start time")]
        [Parameter(ParameterSetName = AgentDefaultRecurringParameterSet, HelpMessage = "The job schedule start time")]
        [Parameter(ParameterSetName = ParentObjectRunOnceParameterSet, HelpMessage = "The job schedule start time")]
        [Parameter(ParameterSetName = ParentObjectRecurringParameterSet, HelpMessage = "The job schedule start time")]
        [Parameter(ParameterSetName = ParentResourceIdRunOnceParameterSet, HelpMessage = "The job schedule start time")]
        [Parameter(ParameterSetName = ParentResourceIdRecurringParameterSet, HelpMessage = "The job schedule start time")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the job schedule end time
        /// </summary>
        [Parameter(ParameterSetName = AgentDefaultRecurringParameterSet, HelpMessage = "The job schedule end time")]
        [Parameter(ParameterSetName = ParentObjectRecurringParameterSet, HelpMessage = "The job schedule end time")]
        [Parameter(ParameterSetName = ParentResourceIdRecurringParameterSet, HelpMessage = "The job schedule end time")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the job description
        /// </summary>
        [Parameter(HelpMessage = "The job description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the enable switch flag.
        /// </summary>
        [Parameter(HelpMessage = "The flag to indicate customer wants this job to be enabled.")]
        public SwitchParameter Enable { get; set; }

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
        /// Check to see if the job already exists in this agent.
        /// </summary>
        /// <returns>Null if the job doesn't exist. Otherwise throws exception</returns>
        protected override IEnumerable<AzureSqlElasticJobModel> GetEntity()
        {
            try
            {
                ModelAdapter.GetJob(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no agent with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The job already exists
            throw new PSArgumentException(
                string.Format(Properties.Resources.AzureElasticJobExists, this.Name, this.AgentName),
                "JobName");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the job doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlElasticJobModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticJobModel> model)
        {
            AzureSqlElasticJobModel newEntity = new AzureSqlElasticJobModel
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                AgentName = this.AgentName,
                JobName = this.Name,
                Description = this.Description,
                StartTime = this.StartTime != null ? this.StartTime : DateTime.Now, // defaults to current date time
                EndTime = this.EndTime != null ? this.EndTime : null,
                ScheduleType = this.RunOnce.IsPresent ? JobScheduleType.Once :
                               this.IntervalType != null ? JobScheduleType.Recurring : (JobScheduleType?) null,
                Interval = this.IntervalCount.HasValue ? CreateIso8601Duration(this.IntervalType, this.IntervalCount.Value) : null,
                Enabled = this.Enable.IsPresent
            };

            return new List<AzureSqlElasticJobModel> { newEntity };
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the agent
        /// </summary>
        /// <param name="entity">The agent to create</param>
        /// <returns>The created agent</returns>
        protected override IEnumerable<AzureSqlElasticJobModel> PersistChanges(IEnumerable<AzureSqlElasticJobModel> entity)
        {
            return new List<AzureSqlElasticJobModel> {
                ModelAdapter.UpsertJob(entity.First())
            };
        }
    }
}