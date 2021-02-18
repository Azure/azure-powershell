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
using Microsoft.Azure.Commands.Sql.ElasticJobs.Model;
using Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet.JobExecution;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet
{
    /// <summary>
    /// Defines the Stop-AzureRmSqlElasticJob Cmdlet
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlElasticJob",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlElasticJobExecutionModel))]
    public class StopAzureSqlElasticJob : AzureSqlElasticJobExecutionCmdletBase<AzureSqlElasticJobExecutionModel>
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
        /// Gets or sets the Agent's Control Database Object
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The Agent Control Database Object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlElasticJobExecutionModel ParentObject { get; set; }

        /// <summary>
        /// Gets or sets the Agent's Control Database Object
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The job execution resource id")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceId { get; set; }

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
        /// Gets or sets the job name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 3,
            HelpMessage = "The job name")]
        public override string JobName { get; set; }

        /// <summary>
        /// Gets or sets the job execution id to cancel
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "The job execution id.")]
        [ValidateNotNullOrEmpty]
        public override string JobExecutionId { get; set; }

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
        /// Gets the existing job execution to cancel
        /// </summary>
        /// <returns>The existing job execution</returns>
        protected override IEnumerable<AzureSqlElasticJobExecutionModel> GetEntity()
        {
            try
            {
                var resp = ModelAdapter.GetJobExecution(this.ResourceGroupName, this.ServerName, this.AgentName, this.JobName, Guid.Parse(this.JobExecutionId));
                return new List<AzureSqlElasticJobExecutionModel> { resp };
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // The job execution does not exist
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureElasticJobExecutionNotExists, this.JobExecutionId, this.JobName),
                        "JobExecution");
                }

                // Unexpected exception encountered
                throw;
            }
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">The job execution</param>
        /// <returns>The job execution</returns>
        protected override IEnumerable<AzureSqlElasticJobExecutionModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticJobExecutionModel> model)
        {
            return model;
        }

        /// <summary>
        /// Sends the changes to the service -> Cancels the job execution belonging to job
        /// </summary>
        /// <param name="entity">The job execution to cancel</param>
        /// <returns>The job execution that was cancelled</returns>
        protected override IEnumerable<AzureSqlElasticJobExecutionModel> PersistChanges(IEnumerable<AzureSqlElasticJobExecutionModel> entity)
        {
            ModelAdapter.CancelJobExecution(entity.First());
            return entity;
        }
    }
}