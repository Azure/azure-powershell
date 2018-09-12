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
    /// Defines the Start-AzureRmSqlElasticJob Cmdlet
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlElasticJob",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlElasticJobExecutionModel))]
    public class StartAzureSqlElasticJob : AzureSqlElasticJobExecutionCmdletBase<AzureSqlElasticJobModel>
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
        /// Gets or sets the job model input object
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The job object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlElasticJobModel ParentObject { get; set; }

        /// <summary>
        /// Gets or sets the job resource id
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The job resource id")]
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
        [ValidateNotNullOrEmpty]
        public override string JobName { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter to indicate whether customer wants to poll completion of job
        /// or if not set, to return job execution id immediately upon creation.
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, HelpMessage = "The wait flag to indicate to wait until the job's execution is done")]
        [Parameter(ParameterSetName = InputObjectParameterSet, HelpMessage = "The wait flag to indicate to wait until the job's execution is done")]
        [Parameter(ParameterSetName = ResourceIdParameterSet, HelpMessage = "The wait flag to indicate to wait until the job's execution is done")]
        public SwitchParameter Wait { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

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
        /// Checks if job exists, if it doesn't we can't start an execution of this job.
        /// </summary>
        /// <returns>Nothing since execution doesn't yet exist</returns>
        protected override IEnumerable<AzureSqlElasticJobExecutionModel> GetEntity()
        {
            try
            {
                ModelAdapter.GetJob(this.ResourceGroupName, this.ServerName, this.AgentName, this.JobName);
                return new List<AzureSqlElasticJobExecutionModel> { };
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // The job does not exist
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureElasticJobNotExists, this.JobName, this.AgentName),
                        "JobName");
                }

                // Unexpected exception encountered
                throw;
            }
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the job execuution doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlElasticJobExecutionModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticJobExecutionModel> model)
        {
            AzureSqlElasticJobExecutionModel updatedModel = new AzureSqlElasticJobExecutionModel
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                AgentName = this.AgentName,
                JobName = this.JobName
            };

            return new List<AzureSqlElasticJobExecutionModel> { updatedModel };
        }

        /// <summary>
        /// Sends the changes to the service -> Creates a job execution for the job
        /// </summary>
        /// <param name="entity">The job execution entity</param>
        /// <returns>A job execution</returns>
        protected override IEnumerable<AzureSqlElasticJobExecutionModel> PersistChanges(IEnumerable<AzureSqlElasticJobExecutionModel> entity)
        {
            AzureSqlElasticJobExecutionModel resp;

            if (this.Wait.IsPresent)
            {
                resp = ModelAdapter.CreateJobExecution(entity.First());
            }
            else
            {
                resp = ModelAdapter.BeginCreateJobExecution(entity.First());
            }

            return new List<AzureSqlElasticJobExecutionModel> { resp }; ;
        }
    }
}