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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.Sql.Elastic_Jobs.Model;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet
{
    /// <summary>
    /// Defines the Set-AzureRmSqlElasticJobStep Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlElasticJobStep",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlElasticJobStepModel))]
    public class SetAzureSqlElasticJobStep : AzureSqlElasticJobStepCmdletBase<AzureSqlElasticJobStepModel>
    {
        /// <summary>
        /// The parameter sets
        /// </summary>
        protected const string DefaultRemoveOutputParameterSet = "WithRemoveOutput";
        protected const string DefaultAddParentResourceIdParameterSet = "WithAddOutput";
        protected const string ParentObjectRemoveOutputParameterSet = "WithRemoveOutputUsingParentObject";
        protected const string ParentObjectAddParentResourceIdParameterSet = "WithAddOutputUsingParentObject";
        protected const string ParentResourceIdRemoveOutputParameterSet = "WithRemoveOutputUsingParentResourceId";
        protected const string ParentResourceIdAddParentResourceIdParameterSet = "WithAddOutputUsingParentResourceId";

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
            ParameterSetName = DefaultRemoveOutputParameterSet,
            Position = 0,
            HelpMessage = "The resource group name")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultAddParentResourceIdParameterSet,
            Position = 0,
            HelpMessage = "The resource group name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the job object
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The job step object")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = ParentObjectRemoveOutputParameterSet,
            HelpMessage = "The job step object")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = ParentObjectAddParentResourceIdParameterSet,
            HelpMessage = "The job step object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlElasticJobStepModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the job resource id
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The job step resource id")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParentResourceIdRemoveOutputParameterSet,
            HelpMessage = "The job step resource id")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParentResourceIdAddParentResourceIdParameterSet,
            HelpMessage = "The job step resource id")]
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
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultRemoveOutputParameterSet,
            Position = 1,
            HelpMessage = "The server name")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultAddParentResourceIdParameterSet,
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
            ParameterSetName = DefaultRemoveOutputParameterSet,
            Position = 2,
            HelpMessage = "The agent name")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultAddParentResourceIdParameterSet,
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
            ParameterSetName = DefaultRemoveOutputParameterSet,
            Position = 3,
            HelpMessage = "The job name")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultAddParentResourceIdParameterSet,
            Position = 3,
            HelpMessage = "The job name")]
        [ValidateNotNullOrEmpty]
        public override string JobName { get; set; }

        /// <summary>
        /// Gets or sets the job step name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "The step name")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultRemoveOutputParameterSet,
            HelpMessage = "The step name")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultAddParentResourceIdParameterSet,
            HelpMessage = "The step name")]
        [Alias("StepName")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultRemoveOutputParameterSet,
            HelpMessage = "The flag to indicate whether to remove output")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParentObjectRemoveOutputParameterSet,
            Position = 1,
            HelpMessage = "The flag to indicate whether to remove output")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParentResourceIdRemoveOutputParameterSet,
            Position = 1,
            HelpMessage = "The flag to indicate whether to remove output")]
        public SwitchParameter RemoveOutput { get; set; }

        /// <summary>
        /// Gets or sets the output database object
        /// </summary>
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "The output database object")]
        [Parameter(
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "The output database object")]
        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The output database object")]
        public AzureSqlDatabaseModel OutputDatabaseObject { get; set; }

        /// <summary>
        /// Gets or sets the output database resource id
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultAddParentResourceIdParameterSet,
            HelpMessage = "The output database resource id")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParentObjectAddParentResourceIdParameterSet,
            Position = 1,
            HelpMessage = "The output database resource id")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParentResourceIdAddParentResourceIdParameterSet,
            Position = 1,
            HelpMessage = "The output database resource id")]
        public string OutputDatabaseResourceId { get; set; }

        /// <summary>
        /// Gets or sets the output credential name
        /// </summary>
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "The output credential name")]
        [Parameter(
            ParameterSetName = DefaultAddParentResourceIdParameterSet,
            HelpMessage = "The output credential name")]
        [Parameter(
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "The output credential name")]
        [Parameter(
            ParameterSetName = ParentObjectAddParentResourceIdParameterSet,
            HelpMessage = "The output credential name")]
        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The output credential name")]
        [Parameter(
            ParameterSetName = ParentResourceIdAddParentResourceIdParameterSet,
            HelpMessage = "The output credential name")]
        public string OutputCredentialName { get; set; }

        /// <summary>
        /// Gets or sets the output table name
        /// </summary>
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "The output table name")]
        [Parameter(
            ParameterSetName = DefaultAddParentResourceIdParameterSet,
            HelpMessage = "The output table name")]
        [Parameter(
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "The output table name")]
        [Parameter(
            ParameterSetName = ParentObjectAddParentResourceIdParameterSet,
            HelpMessage = "The output table name")]
        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The output table name")]
        [Parameter(
            ParameterSetName = ParentResourceIdAddParentResourceIdParameterSet,
            HelpMessage = "The output schema name")]
        public string OutputTableName { get; set; }

        /// <summary>
        /// Gets or sets the output schema name
        /// </summary>
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "The output schema name")]
        [Parameter(
            ParameterSetName = DefaultAddParentResourceIdParameterSet,
            HelpMessage = "The output schema name")]
        [Parameter(
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "The output schema name")]
        [Parameter(
            ParameterSetName = ParentObjectAddParentResourceIdParameterSet,
            HelpMessage = "The output schema name")]
        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The output schema name")]
        [Parameter(
            ParameterSetName = ParentResourceIdAddParentResourceIdParameterSet,
            HelpMessage = "The output schema name")]
        public string OutputSchemaName { get; set; }

        /// <summary>
        /// Gets or sets the target group name
        /// </summary>
        [Parameter(HelpMessage = "The target group name")]
        public override string TargetGroupName { get; set; }

        /// <summary>
        /// Gets or sets the credential name
        /// </summary>
        [Parameter(HelpMessage = "The credential name")]
        public override string CredentialName { get; set; }

        /// <summary>
        /// Gets or sets the command text
        /// </summary>
        [Parameter(HelpMessage = "The command text")]
        public string CommandText { get; set; }

        /// <summary>
        /// Gets or sets the step id
        /// </summary>
        [Parameter(HelpMessage = "The step id")]
        public int? StepId { get; set; }

        /// <summary>
        /// Gets or sets the timeout seconds
        /// </summary>
        [Parameter(HelpMessage = "The timeout seconds")]
        public int? TimeoutSeconds { get; set; }

        /// <summary>
        /// Gets or sets the retry attempts
        /// </summary>
        [Parameter(HelpMessage = "The retry attemps")]
        public int? RetryAttempts { get; set; }

        /// <summary>
        /// Gets or sets the initial retry interval seconds
        /// </summary>
        [Parameter(HelpMessage = "The initial retry interval seconds")]
        public int? InitialRetryIntervalSeconds { get; set; }

        /// <summary>
        /// Gets or sets the maximum retry interval seconds
        /// </summary>
        [Parameter(HelpMessage = "The maximum retry interval seconds")]
        public int? MaximumRetryIntervalSeconds { get; set; }

        /// <summary>
        /// Gets or sets the retry interval backoff multiplier
        /// </summary>
        [Parameter(HelpMessage = "The retry interval backoff multiplier")]
        public double? RetryIntervalBackoffMultiplier { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            InitializeInputObjectProperties(this.InputObject);
            InitializeResourceIdProperties(this.ResourceId);
            this.Name = this.Name ?? this.StepName;
            base.ExecuteCmdlet();
            ClearProperties();
        }

        /// <summary>
        /// Check to see if the job step already exists in job.
        /// </summary>
        /// <returns>Null if the job step doesn't exist. Otherwise throws exception</returns>
        protected override IEnumerable<AzureSqlElasticJobStepModel> GetEntity()
        {
            try
            {
                WriteDebugWithTimestamp("StepName: {0}", Name);
                return new List<AzureSqlElasticJobStepModel>
                {
                    ModelAdapter.GetJobStep(this.ResourceGroupName, this.ServerName, this.AgentName, this.JobName, this.Name)
                };
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // We looked for the existing job step and it wasn't found. We should throw error.
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureElasticJobStepNotExists, this.Name, this.JobName),
                        "JobStep");
                }

                // Unexpected exception encountered
                throw;
            }
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">The existing job step model</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlElasticJobStepModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticJobStepModel> model)
        {
            var existingEntity = model.First();

            AzureSqlElasticJobStepModel updatedModel = new AzureSqlElasticJobStepModel
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                AgentName = this.AgentName,
                JobName = this.JobName,
                StepName = this.Name,
                TargetGroupName = this.TargetGroupName != null ?
                    CreateTargetGroupId(this.ResourceGroupName, this.ServerName, this.AgentName, this.TargetGroupName) :
                    CreateTargetGroupId(this.ResourceGroupName, this.ServerName, this.AgentName, existingEntity.TargetGroupName),
                CredentialName = this.CredentialName != null ?
                    CreateCredentialId(this.ResourceGroupName, this.ServerName, this.AgentName, this.CredentialName) :
                    CreateCredentialId(this.ResourceGroupName, this.ServerName, this.AgentName, existingEntity.CredentialName),
                InitialRetryIntervalSeconds = this.InitialRetryIntervalSeconds ?? existingEntity.InitialRetryIntervalSeconds,
                MaximumRetryIntervalSeconds = this.MaximumRetryIntervalSeconds ?? existingEntity.MaximumRetryIntervalSeconds,
                RetryAttempts = this.RetryAttempts ?? existingEntity.RetryAttempts,
                RetryIntervalBackoffMultiplier = this.RetryIntervalBackoffMultiplier ?? existingEntity.RetryIntervalBackoffMultiplier,
                TimeoutSeconds = this.TimeoutSeconds ?? existingEntity.TimeoutSeconds,
                CommandText = this.CommandText ?? existingEntity.CommandText,
                StepId = this.StepId ?? existingEntity.StepId
            };

            // If there was an existing output in the step, update it and make sure Remove Output wasn't present.
            if (existingEntity.Output != null && !this.RemoveOutput.IsPresent)
            {
                // Initialize to existing output first
                updatedModel.Output = existingEntity.Output;

                // Output database object was given
                if (this.OutputDatabaseObject != null)
                {
                    updatedModel.Output = new AzureSqlElasticJobStepOutputModel
                    {
                        SubscriptionId = this.OutputDatabaseObject != null ? Guid.Parse(new ResourceIdentifier(this.OutputDatabaseObject.ResourceId).Subscription) : existingEntity.Output.SubscriptionId,
                        ResourceGroupName = this.OutputDatabaseObject != null ? this.OutputDatabaseObject.ResourceGroupName : existingEntity.Output.ResourceGroupName,
                        ServerName = this.OutputDatabaseObject != null ? this.OutputDatabaseObject.ServerName : existingEntity.Output.ServerName,
                        DatabaseName = this.OutputDatabaseObject != null ? this.OutputDatabaseObject.DatabaseName : existingEntity.Output.DatabaseName,
                    };
                }
                // Output database resource id was given
                else if (this.OutputDatabaseResourceId != null)
                {
                    var databaseIdentifier = new ResourceIdentifier(this.OutputDatabaseResourceId);
                    updatedModel.Output = new AzureSqlElasticJobStepOutputModel
                    {
                        SubscriptionId = Guid.Parse(databaseIdentifier.Subscription),
                        ResourceGroupName = databaseIdentifier.ResourceGroupName,
                        ServerName = databaseIdentifier.ParentResource.Split('/')[1],
                        DatabaseName = databaseIdentifier.ResourceName,
                    };
                }

                updatedModel.Output.Credential = this.OutputCredentialName != null ?
                    CreateCredentialId(this.ResourceGroupName, this.ServerName, this.AgentName, this.OutputCredentialName) :
                    CreateCredentialId(this.ResourceGroupName, this.ServerName, this.AgentName, existingEntity.Output.Credential);

                updatedModel.Output.SchemaName = this.OutputSchemaName != null ? this.OutputSchemaName : existingEntity.Output.SchemaName;
                updatedModel.Output.TableName = this.OutputTableName != null ? this.OutputTableName : existingEntity.Output.TableName;
            }
            // At this point, we know existing job step has no output object and params don't include remove output.
            // So let's add new output
            else if (existingEntity.Output == null && !this.RemoveOutput.IsPresent)
            {
                if (this.OutputDatabaseObject != null)
                {
                    updatedModel.Output = new AzureSqlElasticJobStepOutputModel
                    {
                        SubscriptionId = this.OutputDatabaseObject != null ? Guid.Parse(new ResourceIdentifier(this.OutputDatabaseObject.ResourceId).Subscription) : (Guid?)null,
                        ResourceGroupName = this.OutputDatabaseObject != null ? this.OutputDatabaseObject.ResourceGroupName : null,
                        ServerName = this.OutputDatabaseObject != null ? this.OutputDatabaseObject.ServerName : null,
                        DatabaseName = this.OutputDatabaseObject != null ? this.OutputDatabaseObject.DatabaseName : null,
                        Credential = this.OutputCredentialName != null ? CreateCredentialId(this.ResourceGroupName, this.ServerName, this.AgentName, this.OutputCredentialName) : null,
                        SchemaName = this.OutputSchemaName != null ? this.OutputSchemaName : null,
                        TableName = this.OutputTableName != null ? this.OutputTableName : null
                    };
                }

                if (this.OutputDatabaseResourceId != null)
                {
                    var databaseIdentifier = new ResourceIdentifier(this.OutputDatabaseResourceId);

                    updatedModel.Output = new AzureSqlElasticJobStepOutputModel
                    {
                        SubscriptionId = Guid.Parse(databaseIdentifier.Subscription),
                        ResourceGroupName = databaseIdentifier.ResourceGroupName,
                        ServerName = databaseIdentifier.ParentResource.Split('/')[1],
                        DatabaseName = databaseIdentifier.ResourceName,
                        Credential = this.OutputCredentialName != null ? CreateCredentialId(this.ResourceGroupName, this.ServerName, this.AgentName, this.OutputCredentialName) : null,
                        SchemaName = this.OutputSchemaName != null ? this.OutputSchemaName : null,
                        TableName = this.OutputTableName != null ? this.OutputTableName : null
                    };
                }
            }
            // At this point, we know RemoveOutput was present. If so, then just do nothing since we just exclude the step's existing output from the updated model.

            return new List<AzureSqlElasticJobStepModel> { updatedModel };
        }

        /// <summary>
        /// Sends the changes to the service -> Updates the job step
        /// </summary>
        /// <param name="entity">The job step to update</param>
        /// <returns>The updated job step</returns>
        protected override IEnumerable<AzureSqlElasticJobStepModel> PersistChanges(IEnumerable<AzureSqlElasticJobStepModel> entity)
        {
            return new List<AzureSqlElasticJobStepModel>
            {
                ModelAdapter.UpsertJobStep(entity.First())
            };
        }
    }
}