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
    /// Defines the Set-AzureRmSqlElasticJob Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlElasticJob",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    public class SetAzureSqlElasticJob : AzureSqlElasticJobCmdletBase<AzureSqlElasticJobModel>
    {
        /// <summary>
        /// The parameter sets
        /// </summary>
        protected const string JobDefaultRunOnceParameterSet = "Set Job Run Once Parameter Set";
        protected const string JobDefaultRecurringParameterSet = "Set Job Recurring Parameter Set";
        protected const string JobObjectRunOnceParameterSet = "Set Job Run Once Parameter Set Using Job Object";
        protected const string JobObjectRecurringParameterSet = "Set Job Recurring Parameter Set Using Job Object";
        protected const string JobResourceIdRunOnceParameterSet = "Set Job Run Once Parameter Set Using Job Resource Id";
        protected const string JobResourceIdRecurringParameterSet = "Set Job Recurring Parameter Set Using Job Resource Id";

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 0,
            HelpMessage = "The resource group name")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobDefaultRunOnceParameterSet,
            Position = 0,
            HelpMessage = "The resource group name")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobDefaultRecurringParameterSet,
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
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobDefaultRunOnceParameterSet,
            Position = 1,
            HelpMessage = "The server name")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobDefaultRecurringParameterSet,
            Position = 1,
            HelpMessage = "The server name")]
        [ValidateNotNullOrEmpty]
        public override string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the agent name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 2,
            HelpMessage = "The agent name")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobDefaultRunOnceParameterSet,
            Position = 2,
            HelpMessage = "The agent name")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobDefaultRecurringParameterSet,
            Position = 2,
            HelpMessage = "The agent name")]
        [ValidateNotNullOrEmpty]
        public override string AgentName { get; set; }

        /// <summary>
        /// Gets or sets the job name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 3,
            HelpMessage = "The job name")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobDefaultRunOnceParameterSet,
            Position = 3,
            HelpMessage = "The job name")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobDefaultRecurringParameterSet,
            Position = 3,
            HelpMessage = "The job name")]
        [ValidateNotNullOrEmpty]
        [Alias("JobName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter run once
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobDefaultRunOnceParameterSet,
            Position = 4,
            HelpMessage = "The flag to indicate job will be run once")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobObjectRunOnceParameterSet,
            Position = 1,
            HelpMessage = "The flag to indicate job will be run once")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobResourceIdRunOnceParameterSet,
            Position = 1,
            HelpMessage = "The flag to indicate job will be run once")]
        public SwitchParameter RunOnce { get; set; }

        /// <summary>
        /// Get or sets the job schedule interval type
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobDefaultRecurringParameterSet,
            Position = 4,
            HelpMessage = "The recurring schedule interval type - Can be Minute, Hour, Day, Week, Month")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobObjectRecurringParameterSet,
            Position = 1,
            HelpMessage = "The recurring schedule interval type - Can be Minute, Hour, Day, Week, Month")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobResourceIdRecurringParameterSet,
            Position = 1,
            HelpMessage = "The recurring schedule interval type - Can be Minute, Hour, Day, Week, Month")]
        [ValidateNotNullOrEmpty]
        public JobScheduleReccuringScheduleTypes? IntervalType { get; set; }

        /// <summary>
        /// Gets or sets the job schedule interval count
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobDefaultRecurringParameterSet,
            Position = 5,
            HelpMessage = "The recurring schedule interval count")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobObjectRecurringParameterSet,
            Position = 2,
            HelpMessage = "The recurring schedule interval count")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobResourceIdRecurringParameterSet,
            Position = 2,
            HelpMessage = "The recurring schedule interval count")]
        public uint? IntervalCount { get; set; }

        /// <summary>
        /// Gets or sets the job schedule start time
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The job schedule start time")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the job schedule end time
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The job schedule end time")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the agent input object
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The job input object")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobObjectRunOnceParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The job input object")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobObjectRecurringParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The job input object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlElasticJobModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the agent resource id
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The job resource id")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobResourceIdRunOnceParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The job resource id")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = JobResourceIdRecurringParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The job resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the enable switch flag.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The flag to indicate customer wants this job to be enabled.")]
        public SwitchParameter Enable { get; set; }

        /// <summary>
        /// Gets or sets the job description
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The job description")]
        public string Description { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            InitializeInputObjectProperties(this.InputObject);
            InitializeResourceIdProperties(this.ResourceId);
            this.Name = this.Name ?? this.JobName;
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Check to see if the agent already exists in this resource group.
        /// </summary>
        /// <returns>Null if the agent doesn't exist. Otherwise throws exception</returns>
        protected override IEnumerable<AzureSqlElasticJobModel> GetEntity()
        {
            try
            {
                return new List<AzureSqlElasticJobModel> {
                    ModelAdapter.GetJob(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name)
                };
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // The job does not exist
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureElasticJobNotExists, this.Name, this.AgentName),
                        "JobName");
                }

                // Unexpected exception encountered
                throw;
            }
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the server doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlElasticJobModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticJobModel> model)
        {
            var existingEntity = model.First();

            AzureSqlElasticJobModel updatedEntity = new AzureSqlElasticJobModel
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                AgentName = this.AgentName,
                JobName = this.Name,
                Description = this.Description != null ? this.Description : existingEntity.Description,
                StartTime = this.StartTime != null ? this.StartTime : existingEntity.StartTime,
                EndTime = this.EndTime != null ? this.EndTime : existingEntity.EndTime,
                ScheduleType = this.RunOnce.IsPresent ? JobScheduleType.Once :
                               this.IntervalType.HasValue ? JobScheduleType.Recurring : (JobScheduleType?) existingEntity.ScheduleType,
                Enabled = this.Enable.IsPresent
            };

            if (updatedEntity.ScheduleType != null && updatedEntity.ScheduleType == JobScheduleType.Recurring)
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

                updatedEntity.Interval = interval;
            }

            return new List<AzureSqlElasticJobModel> { updatedEntity };
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