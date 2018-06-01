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
using static Microsoft.Azure.Commands.Sql.ElasticJobs.Model.AzureSqlElasticJobModel;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet
{
    /// <summary>
    /// Defines the New-AzureRmSqlElasticJob Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlElasticJob",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    public class NewAzureSqlElasticJob : AzureSqlElasticJobCmdletBase<AzureSqlElasticJobAgentModel>
    {
        /// <summary>
        /// The Parameter Set
        /// </summary>
        protected const string AgentDefaultRunOnceParameterSet = "New Job Run Once Parameter Set";
        protected const string AgentDefaultRecurringParameterSet = "New Job Recurring Set";
        protected const string AgentObjectRunOnceParameterSet = "New Job Run Once Parameter Set Using Agent Object";
        protected const string AgentObjectRecurringParameterSet = "New Job Recurring Parameter Set Using Agent Object";
        protected const string AgentResourceIdRunOnceParameterSet = "New Job Run Once Parameter Set Using Agent Resource Id";
        protected const string AgentResourceIdRecurringParameterSet = "New Job Recurring Parameter Set Using Agent Resource Id";

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
        [Parameter(Mandatory = true, ParameterSetName = AgentObjectRunOnceParameterSet, Position = 1, HelpMessage = "The job name")]
        [Parameter(Mandatory = true, ParameterSetName = AgentObjectRecurringParameterSet, Position = 1, HelpMessage = "The job name")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, Position = 1, HelpMessage = "The job name")]
        [Parameter(Mandatory = true, ParameterSetName = AgentResourceIdRunOnceParameterSet, Position = 1, HelpMessage = "The job name")]
        [Parameter(Mandatory = true, ParameterSetName = AgentResourceIdRecurringParameterSet, Position = 1, HelpMessage = "The job name")]
        [ValidateNotNullOrEmpty]
        [Alias("JobName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter run once
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AgentDefaultRunOnceParameterSet, Position = 4, HelpMessage = "The flag to indicate job will be run once")]
        [Parameter(Mandatory = true, ParameterSetName = AgentObjectRunOnceParameterSet, Position = 2, HelpMessage = "The flag to indicate job will be run once")]
        [Parameter(Mandatory = true, ParameterSetName = AgentResourceIdRunOnceParameterSet, Position = 2, HelpMessage = "The flag to indicate job will be run once")]
        public SwitchParameter RunOnce { get; set; }

        /// <summary>
        /// Get or sets the job schedule interval type
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AgentDefaultRecurringParameterSet, Position = 4,
            HelpMessage = "The recurring schedule interval type - Can be Minute, Hour, Day, Week, Month")]
        [Parameter(Mandatory = true, ParameterSetName = AgentObjectRecurringParameterSet, Position = 2,
            HelpMessage = "The recurring schedule interval type - Can be Minute, Hour, Day, Week, Month")]
        [Parameter(Mandatory = true, ParameterSetName = AgentResourceIdRecurringParameterSet, Position = 2,
            HelpMessage = "The recurring schedule interval type - Can be Minute, Hour, Day, Week, Month")]
        public JobScheduleReccuringScheduleTypes? IntervalType { get; set; }

        /// <summary>
        /// Gets or sets the job schedule interval count
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AgentDefaultRecurringParameterSet, Position = 5, HelpMessage = "The recurring schedule interval count")]
        [Parameter(Mandatory = true, ParameterSetName = AgentObjectRecurringParameterSet, Position = 3, HelpMessage = "The recurring schedule interval count")]
        [Parameter(Mandatory = true, ParameterSetName = AgentResourceIdRecurringParameterSet, Position = 3, HelpMessage = "The recurring schedule interval count")]
        public uint? IntervalCount { get; set; }

        /// <summary>
        /// Gets or sets the job schedule start time
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AgentDefaultRunOnceParameterSet, HelpMessage = "The job schedule start time")]
        [Parameter(Mandatory = false, ParameterSetName = AgentDefaultRecurringParameterSet, HelpMessage = "The job schedule start time")]
        [Parameter(Mandatory = false, ParameterSetName = AgentObjectRunOnceParameterSet, HelpMessage = "The job schedule start time")]
        [Parameter(Mandatory = false, ParameterSetName = AgentObjectRecurringParameterSet, HelpMessage = "The job schedule start time")]
        [Parameter(Mandatory = false, ParameterSetName = AgentResourceIdRunOnceParameterSet, HelpMessage = "The job schedule start time")]
        [Parameter(Mandatory = false, ParameterSetName = AgentResourceIdRecurringParameterSet, HelpMessage = "The job schedule start time")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the job schedule end time
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AgentDefaultRecurringParameterSet, HelpMessage = "The job schedule end time")]
        [Parameter(Mandatory = false, ParameterSetName = AgentObjectRecurringParameterSet, HelpMessage = "The job schedule end time")]
        [Parameter(Mandatory = false, ParameterSetName = AgentResourceIdRecurringParameterSet, HelpMessage = "The job schedule end time")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the job description
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The job description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the agent input object
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent input object")]
        [Parameter(Mandatory = true,
            ParameterSetName = AgentObjectRunOnceParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent input object")]
        [Parameter(Mandatory = true,
            ParameterSetName = AgentObjectRecurringParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent input object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlElasticJobAgentModel AgentObject { get; set; }

        /// <summary>
        /// Gets or sets the agent resource id
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The agent resource id")]
        [Parameter(Mandatory = true,
            ParameterSetName = AgentResourceIdRunOnceParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The agent resource id")]
        [Parameter(Mandatory = true,
            ParameterSetName = AgentResourceIdRecurringParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The agent resource id")]
        [ValidateNotNullOrEmpty]
        public string AgentResourceId { get; set; }

        /// <summary>
        /// Gets or sets the enable switch flag.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The flag to indicate customer wants this job to be enabled.")]
        public SwitchParameter Enable { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            InitializeInputObjectProperties(this.AgentObject);
            InitializeResourceIdProperties(this.AgentResourceId);
            base.ExecuteCmdlet();
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
                               this.IntervalType.HasValue ? JobScheduleType.Recurring : (JobScheduleType?) null,
                Enabled = this.Enable.IsPresent
            };

            if (newEntity.ScheduleType != null && newEntity.ScheduleType == JobScheduleType.Recurring)
            {
                StringBuilder stringBuilder = new StringBuilder();

                // Create basic ISO 8601 duration - Basic string builder implementation
                // XmlConvert.ToString(timeSpan) only supports up to days. Weeks and months need to be supported
                stringBuilder.Append("P");

                if (this.IntervalType.Value == JobScheduleReccuringScheduleTypes.Hour ||
                    this.IntervalType.Value == JobScheduleReccuringScheduleTypes.Minute)
                {
                    stringBuilder.Append("T");
                }

                if (this.IntervalType.Value == JobScheduleReccuringScheduleTypes.Month ||
                    this.IntervalType.Value == JobScheduleReccuringScheduleTypes.Minute)
                {
                    stringBuilder.Append(this.IntervalCount + "M");
                }

                if (this.IntervalType.Value == JobScheduleReccuringScheduleTypes.Week)
                {
                    stringBuilder.Append(this.IntervalCount + "W");
                }

                if (this.IntervalType.Value == JobScheduleReccuringScheduleTypes.Day)
                {
                    stringBuilder.Append(this.IntervalCount + "D");
                }

                if (this.IntervalType.Value == JobScheduleReccuringScheduleTypes.Hour)
                {
                    stringBuilder.Append(this.IntervalCount + "H");
                }

                string interval = stringBuilder.ToString();

                newEntity.Interval = interval;
            }

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