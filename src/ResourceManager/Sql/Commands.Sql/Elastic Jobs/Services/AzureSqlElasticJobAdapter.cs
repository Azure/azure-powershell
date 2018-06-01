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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.ElasticJobs.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Text.RegularExpressions;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Services
{
    /// <summary>
    /// Adapter for Elastic Jobs operations
    /// </summary>
    public class AzureSqlElasticJobAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlElasticJobCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        public AzureSqlElasticJobAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlElasticJobCommunicator(Context);
        }

        #region Agent

        /// <summary>
        /// Creates or updates an agent
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The upserted Azure SQL Database Agent</returns>
        public AzureSqlElasticJobAgentModel UpsertAgent(AzureSqlElasticJobAgentModel model)
        {
            // Construct database id
            string databaseId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/databases/{3}",
                AzureSqlElasticJobCommunicator.Subscription.Id,
                model.ResourceGroupName,
                model.ServerName,
                model.DatabaseName);

            // Set agent params
            var param = new JobAgent
            {
                Location = model.Location,
                Tags = model.Tags,
                DatabaseId = databaseId
            };

            // Send response
            var resp = Communicator.CreateOrUpdateAgent(model.ResourceGroupName, model.ServerName, model.AgentName, param);

            // Return formatted response
            return CreateAgentModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// Updates an existing agent
        /// </summary>
        /// <param name="model">The existing agent entity</param>
        /// <returns>The updated agent entity</returns>
        public AzureSqlElasticJobAgentModel UpdateAgent(AzureSqlElasticJobAgentModel model)
        {
            var param = new JobAgentUpdate
            {
                Tags = model.Tags
            };

            var resp = Communicator.UpdateAgent(model.ResourceGroupName, model.ServerName, model.AgentName, param);
            return CreateAgentModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// Gets an agent
        /// </summary>
        /// <param name="resourceGroupName">The resource group</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="agentName">The agent name</param>
        /// <returns>The converted agent model</returns>
        public AzureSqlElasticJobAgentModel GetAgent(string resourceGroupName, string serverName, string agentName)
        {
            var resp = Communicator.GetAgent(resourceGroupName, serverName, agentName);
            return CreateAgentModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Get a list of existing agents belong to server
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server the agents are in</param>
        /// <returns>The converted agent model(s)</returns>
        public List<AzureSqlElasticJobAgentModel> ListAgents(string resourceGroupName, string serverName)
        {
            var resp = Communicator.ListAgentsByServer(resourceGroupName, serverName);
            return resp.Select(agent => CreateAgentModelFromResponse(resourceGroupName, serverName, agent)).ToList();
        }

        /// <summary>
        /// Deletes an agent
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="agentName">The agent name</param>
        public void RemoveAgent(string resourceGroupName, string serverName, string agentName)
        {
            Communicator.RemoveAgent(resourceGroupName, serverName, agentName);
        }

        /// <summary>
        /// Convert JobAgent model to AzureSqlDatabaseAgentModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted agent model</returns>
        private static AzureSqlElasticJobAgentModel CreateAgentModelFromResponse(string resourceGroupName, string serverName, JobAgent resp)
        {
            // Parse database name from database id
            // This is not expected to ever fail, but in case we have a bug here it's better to provide a more detailed error message
            int lastSlashIndex = resp.DatabaseId.LastIndexOf('/');
            string databaseName = resp.DatabaseId.Substring(lastSlashIndex + 1);
            int? workerCount = resp.Sku.Capacity;

            AzureSqlElasticJobAgentModel agent = new AzureSqlElasticJobAgentModel
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                AgentName = resp.Name,
                Location = resp.Location,
                DatabaseName = databaseName,
                WorkerCount = workerCount,
                ResourceId = resp.Id,
                Tags = TagsConversionHelper.CreateTagDictionary(TagsConversionHelper.CreateTagHashtable(resp.Tags), false),
                DatabaseId = resp.DatabaseId,
                State = resp.State,
                Type = resp.Type
            };

            return agent;
        }

        /// <summary>
        /// Gets the Location of the server. Throws an exception if the server does not support Azure SQL Database Agents.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        /// <remarks>
        /// These 2 operations (get location, throw if not supported) are combined in order to minimize round trips.
        /// </remarks>
        public string GetServerLocationAndThrowIfAgentNotSupportedByServer(string resourceGroupName, string serverName)
        {
            AzureSqlServerCommunicator serverCommunicator = new AzureSqlServerCommunicator(Context);
            var server = serverCommunicator.Get(resourceGroupName, serverName);
            return server.Location;
        }

        #endregion

        #region Job Credential

        /// <summary>
        /// Upserts an elastic job credential to the control database
        /// </summary>
        /// <param name="model">The job credential object</param>
        /// <returns>The job credential object</returns>
        public AzureSqlElasticJobCredentialModel UpsertJobCredential(AzureSqlElasticJobCredentialModel model)
        {
            var param = new JobCredential
            {
                Username = model.UserName,
                Password = model.Password != null ? ConversionUtilities.SecureStringToString(model.Password) : null
            };

            var resp = Communicator.CreateOrUpdateJobCredential(model.ResourceGroupName, model.ServerName, model.AgentName, model.CredentialName, param);
            return CreateAgentCredentialModelFromResponse(model.ResourceGroupName, model.ServerName, model.AgentName, resp);
        }

        /// <summary>
        /// Gets an elastic job credential
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="credentialName">The job credential name</param>
        /// <returns>The job credential object</returns>
        public AzureSqlElasticJobCredentialModel GetJobCredential(string resourceGroupName, string serverName, string agentName, string credentialName)
        {
            var resp = Communicator.GetJobCredential(resourceGroupName, serverName, agentName, credentialName);
            return CreateAgentCredentialModelFromResponse(resourceGroupName, serverName, agentName, resp);
        }

        /// <summary>
        /// Gets a list of job credentials from the control database
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <returns>A list of job credentials</returns>
        public List<AzureSqlElasticJobCredentialModel> ListJobCredentials(string resourceGroupName, string serverName, string agentName)
        {
            var resp = Communicator.GetJobCredential(resourceGroupName, serverName, agentName);
            return resp.Select(credentialName => CreateAgentCredentialModelFromResponse(resourceGroupName, serverName, agentName, credentialName)).ToList();
        }

        /// <summary>
        /// Deletes a job credential from the control database
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="credentialName">The job credential name</param>
        public void RemoveJobCredential(string resourceGroupName, string serverName, string agentName, string credentialName)
        {
            Communicator.RemoveJobCredential(resourceGroupName, serverName, agentName, credentialName);
        }

        /// <summary>
        /// Converts a job credential response to a AzureSqlElasticJobCredentialModel object
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="resp">The job credential response</param>
        /// <returns></returns>
        private static AzureSqlElasticJobCredentialModel CreateAgentCredentialModelFromResponse(string resourceGroupName, string serverName, string agentName, JobCredential resp)
        {
            // Parse credential name from id
            // This is not expected to ever fail, but in case we have a bug here it's better to provide a more detailed error message
            int lastSlashIndex = resp.Id.LastIndexOf('/');
            string credentialName = resp.Id.Substring(lastSlashIndex + 1);

            AzureSqlElasticJobCredentialModel credential = new AzureSqlElasticJobCredentialModel
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                AgentName = agentName,
                CredentialName = resp.Name,
                UserName = resp.Username,
                ResourceId = resp.Id,
                Type = resp.Type
            };

            return credential;
        }

        #endregion

        #region Target Group

        /// <summary>
        /// Uperts a target group to the control database
        /// </summary>
        /// <param name="model">The target group model</param>
        /// <returns>The upserted target group model</returns>
        public AzureSqlElasticJobTargetGroupModel UpsertTargetGroup(AzureSqlElasticJobTargetGroupModel model)
        {
            var param = new JobTargetGroup
            {
                Members = model.Targets.Select((target) => CreateJobTargetModel(target)).ToList()
            };

            var resp = Communicator.CreateOrUpdateTargetGroup(model.ResourceGroupName, model.ServerName, model.AgentName, model.TargetGroupName, param);
            return CreateTargetGroupModelFromResponse(model.ResourceGroupName, model.ServerName, model.AgentName, resp);
        }

        /// <summary>
        /// Converts an AzureSqlElasticJobTargetModel to a JobTarget model
        /// </summary>
        /// <param name="target">The AzureSqlElasticJobTargetModel</param>
        /// <returns>The JobTarget model</returns>
        public JobTarget CreateJobTargetModel(AzureSqlElasticJobTargetModel target)
        {
            return new JobTarget
            {
                MembershipType = target.MembershipType,
                DatabaseName = target.TargetDatabaseName,
                ServerName = target.TargetServerName,
                ElasticPoolName = target.TargetElasticPoolName,
                RefreshCredential = target.RefreshCredentialName,
                ShardMapName = target.TargetShardMapName,
                Type = target.TargetType
            };
        }

        /// <summary>
        /// Converts a Job Target model to an AzureSqlElasticJobTargetModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="targetGroupName">The target group name</param>
        /// <param name="target">The JobTarget model</param>
        /// <returns></returns>
        protected AzureSqlElasticJobTargetModel CreateAzureSqlElasticJobTargetModel(
            string resourceGroupName,
            string serverName,
            string agentName,
            string targetGroupName,
            JobTarget target)
        {
            return new AzureSqlElasticJobTargetModel
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                AgentName = agentName,
                TargetGroupName = targetGroupName,
                MembershipType = target.MembershipType,
                TargetType = target.Type,
                RefreshCredentialName = new ResourceIdentifier(target.RefreshCredential).ResourceName,
                TargetServerName = target.ServerName,
                TargetDatabaseName = target.DatabaseName,
                TargetElasticPoolName = target.ElasticPoolName,
                TargetShardMapName = target.ShardMapName,
            };
        }

        /// <summary>
        /// Gets a target group from the control database
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="targetGroupName">The target group name</param>
        /// <returns>The target group model</returns>
        public AzureSqlElasticJobTargetGroupModel GetTargetGroup(string resourceGroupName, string serverName, string agentName, string targetGroupName)
        {
            var resp = Communicator.GetTargetGroup(resourceGroupName, serverName, agentName, targetGroupName);
            return CreateTargetGroupModelFromResponse(resourceGroupName, serverName, agentName, resp);
        }

        /// <summary>
        /// Gets a list of target groups stored in the control database
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <returns>A list of target group model</returns>
        public List<AzureSqlElasticJobTargetGroupModel> ListTargetGroups(string resourceGroupName, string serverName, string agentName)
        {
            var resp = Communicator.GetTargetGroup(resourceGroupName, serverName, agentName);
            return resp.Select(targetGroup => CreateTargetGroupModelFromResponse(resourceGroupName, serverName, agentName, targetGroup)).ToList();
        }

        /// <summary>
        /// Removes a target group from the control database
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="targetGroupName">The target group name</param>
        public void RemoveTargetGroup(string resourceGroupName, string serverName, string agentName, string targetGroupName)
        {
            Communicator.RemoveTargetGroup(resourceGroupName, serverName, agentName, targetGroupName);
        }

        /// <summary>
        /// Converts a JobTargetGroup model to an AzureSqlElasticJobTargetGroupModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="resp">The JobTargetGroup model</param>
        /// <returns></returns>
        private AzureSqlElasticJobTargetGroupModel CreateTargetGroupModelFromResponse(string resourceGroupName, string serverName, string agentName, JobTargetGroup resp)
        {
            AzureSqlElasticJobTargetGroupModel targetGroup = new AzureSqlElasticJobTargetGroupModel
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                AgentName = agentName,
                TargetGroupName = resp.Name,
                Targets = resp.Members.Select((target) => CreateAzureSqlElasticJobTargetModel(resourceGroupName, serverName, agentName, resp.Name, target)).ToList(),
                ResourceId = resp.Id,
                Type = resp.Type
            };

            return targetGroup;
        }

        #endregion

        #region Job

        /// <summary>
        /// Upserts a job
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="agentServerName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="model">The job parameters</param>
        /// <returns></returns>
        public AzureSqlElasticJobModel UpsertJob(AzureSqlElasticJobModel model)
        {
            var param = new Job
            {
                Description = model.Description,
                Schedule = new JobSchedule
                {
                    Enabled = model.Enabled,
                    EndTime = model.EndTime,
                    Interval = model.Interval,
                    StartTime = model.StartTime,
                    Type = model.ScheduleType
                }
            };

            var resp = Communicator.CreateOrUpdateJob(model.ResourceGroupName, model.ServerName, model.AgentName, model.JobName, param);
            return CreateJobModelFromResponse(model.ResourceGroupName, model.ServerName, model.AgentName, resp);
        }

        /// <summary>
        /// Gets a job from agent
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The agent server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <returns>A job</returns>
        public AzureSqlElasticJobModel GetJob(string resourceGroupName, string serverName, string agentName, string jobName)
        {
            var resp = Communicator.GetJob(resourceGroupName, serverName, agentName, jobName);
            return CreateJobModelFromResponse(resourceGroupName, serverName, agentName, resp);
        }

        /// <summary>
        /// Gets a list of jobs owned by agent
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The agent server name</param>
        /// <param name="agentName">The agent name</param>
        /// <returns>A list of jobs</returns>
        public List<AzureSqlElasticJobModel> GetJob(string resourceGroupName, string serverName, string agentName)
        {
            var resp = Communicator.ListJobsByAgent(resourceGroupName, serverName, agentName);
            return resp.Select(job => CreateJobModelFromResponse(resourceGroupName, serverName, agentName, job)).ToList();
        }

        /// <summary>
        /// Deletes a job owned by agent
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="agentServerName">The agent server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        public void RemoveJob(string resourceGroupName, string agentServerName, string agentName, string jobName)
        {
            Communicator.RemoveJob(resourceGroupName, agentServerName, agentName, jobName);
        }

        /// <summary>
        /// Converts a Job model to an AzureSqlElasticJobModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="resp">The Job model</param>
        /// <returns>An AzureSqlElasticJobModel</returns>
        public AzureSqlElasticJobModel CreateJobModelFromResponse(
            string resourceGroupName,
            string serverName,
            string agentName,
            Job resp)
        {
            return new AzureSqlElasticJobModel
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                AgentName = agentName,
                JobName = resp.Name,
                Description = resp.Description,
                ResourceId = resp.Id,

                StartTime = resp.Schedule.StartTime,
                EndTime = resp.Schedule.EndTime,
                ScheduleType = resp.Schedule.Type,
                Enabled = resp.Schedule.Enabled,
                Interval = resp.Schedule.Interval,
                Type = resp.Type,
                Version = resp.Version
            };
        }

        #endregion

        #region Job Step

        /// <summary>
        /// Upserts a job step
        /// </summary>
        /// <param name="model">The AzureSqlElasticJobStep model</param>
        /// <returns>The upserted job step</returns>
        public AzureSqlElasticJobStepModel UpsertJobStep(AzureSqlElasticJobStepModel model)
        {
            var param = new JobStep
            {
                TargetGroup = model.TargetGroupName,
                Credential = model.CredentialName,
                Action = new JobStepAction
                {
                    Value = model.CommandText
                },
                ExecutionOptions = model.ExecutionOptions,
                Output = model.Output,
                StepId = model.StepId,
            };

            var resp = Communicator.CreateOrUpdateJobStep(model.ResourceGroupName, model.ServerName, model.AgentName, model.JobName, model.StepName, param);
            return CreateJobStepModelFromResponse(model.ResourceGroupName, model.ServerName, model.AgentName, model.JobName, model.StepName, resp);
        }

        /// <summary>
        /// Gets a job step by version
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="jobVersion">The job version</param>
        /// <param name="stepName">The job step name</param>
        /// <returns></returns>
        public AzureSqlElasticJobStepVersionModel GetJobStepByVersion(string resourceGroupName, string serverName, string agentName, string jobName, int jobVersion, string stepName)
        {
            var resp = Communicator.GetJobStepByVersion(resourceGroupName, serverName, agentName, jobName, jobVersion, stepName);
            return CreateJobStepVersionModelFromResponse(resourceGroupName, serverName, agentName, jobName, jobVersion, stepName, resp);
        }

        /// <summary>
        /// Gets a job step
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="stepName">The step name</param>
        /// <returns>The job step model</returns>
        public AzureSqlElasticJobStepModel GetJobStep(string resourceGroupName, string serverName, string agentName, string jobName, string stepName)
        {
            var resp = Communicator.GetJobStep(resourceGroupName, serverName, agentName, jobName, stepName);
            return CreateJobStepModelFromResponse(resourceGroupName, serverName, agentName, jobName, stepName, resp);
        }

        /// <summary>
        /// Gets a list of job steps associated to a job
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <returns>A list of job steps associated to a job</returns>
        public List<AzureSqlElasticJobStepModel> ListJobSteps(string resourceGroupName, string serverName, string agentName, string jobName)
        {
            var resp = Communicator.ListJobStepsByJob(resourceGroupName, serverName, agentName, jobName);
            return resp.Select((step) => CreateJobStepModelFromResponse(resourceGroupName, serverName, agentName, jobName, step.Name, step)).ToList();
        }

        /// <summary>
        /// Deletes a job step from a job
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="stepName">The job step name</param>
        public void RemoveJobStep(string resourceGroupName, string serverName, string agentName, string jobName, string stepName)
        {
            Communicator.RemoveJobStep(resourceGroupName, serverName, agentName, jobName, stepName);
        }

        /// <summary>
        /// Converts a JobStep model to an AzureSqlElasticJobStepVersionModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="jobVersion">The job version</param>
        /// <param name="stepName">The job step name</param>
        /// <param name="resp">The JobStep model</param>
        /// <returns>The AzureSqlElasticJobStepVersionModel</returns>
        private static AzureSqlElasticJobStepVersionModel CreateJobStepVersionModelFromResponse(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            int jobVersion,
            string stepName,
            JobStep resp)
        {
            AzureSqlElasticJobStepModel jobStep = CreateJobStepModelFromResponse(resourceGroupName, serverName, agentName, jobName, stepName, resp);
            AzureSqlElasticJobStepVersionModel jobStepVersion = (AzureSqlElasticJobStepVersionModel)jobStep;
            jobStepVersion.Version = jobVersion;
            return jobStepVersion;
        }

        /// <summary>
        /// Converts a JobStep model to an AzureSqlElasticJobStepModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="stepName">The job step name</param>
        /// <param name="resp">The JobStep model</param>
        /// <returns>An AzureSqlElasticJobStepModel</returns>
        private static AzureSqlElasticJobStepModel CreateJobStepModelFromResponse(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            string stepName,
            JobStep resp)
        {
            AzureSqlElasticJobStepModel jobStep = new AzureSqlElasticJobStepModel
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                AgentName = agentName,
                JobName = jobName,
                StepName = stepName,
                TargetGroupName = new ResourceIdentifier(resp.TargetGroup).ResourceName,
                CredentialName = new ResourceIdentifier(resp.Credential).ResourceName,
                CommandText = resp.Action.Value,
                ExecutionOptions = resp.ExecutionOptions,
                Output = resp.Output != null ? new JobStepOutput
                {
                    ResourceGroupName = resp.Output.ResourceGroupName,
                    SubscriptionId = resp.Output.SubscriptionId,
                    Credential = new ResourceIdentifier(resp.Output.Credential).ResourceName,
                    DatabaseName = resp.Output.DatabaseName,
                    SchemaName = resp.Output.SchemaName,
                    ServerName = resp.Output.ServerName,
                    TableName = resp.Output.TableName,
                    Type = resp.Output.Type
                } : null,
                ResourceId = resp.Id,
                StepId = resp.StepId,
                Type = resp.Type
            };

            return jobStep;
        }

        #endregion

        #region Job Execution

        /// <summary>
        /// Creates a root job execution and polls until execution completes.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The created root job execution</returns>
        public AzureSqlElasticJobExecutionModel CreateJobExecution(AzureSqlElasticJobExecutionModel model)
        {
            var resp = Communicator.CreateJobExecution(model.ResourceGroupName, model.ServerName, model.AgentName, model.JobName);
            return CreateJobExecutionModelFromResponse(model.ResourceGroupName, model.ServerName, model.AgentName, model.JobName, resp);
        }

        /// <summary>
        /// Creates a root job execution
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The created root job execution</returns>
        public AzureSqlElasticJobExecutionModel BeginCreateJobExecution(AzureSqlElasticJobExecutionModel model)
        {
            var resp = Communicator.BeginCreate(model.ResourceGroupName, model.ServerName, model.AgentName, model.JobName);
            return CreateJobExecutionModelFromResponse(model.ResourceGroupName, model.ServerName, model.AgentName, model.JobName, resp);
        }

        /// <summary>
        /// Gets a root job execution
        /// </summary>
        /// <param name="resourceGroupName">The resource group</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="agentName">The agent name</param>
        /// <returns>The converted agent model</returns>
        public AzureSqlElasticJobExecutionModel GetJobExecution(string resourceGroupName, string serverName, string agentName, string jobName, Guid jobExecutionId)
        {
            var resp = Communicator.GetJobExecution(resourceGroupName, serverName, agentName, jobName, jobExecutionId);
            return CreateJobExecutionModelFromResponse(resourceGroupName, serverName, agentName, jobName, resp);
        }

        /// <summary>
        /// Cancels a job execution
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server the agents are in</param>
        /// <returns>The converted agent model(s)</returns>
        public void CancelJobExecution(AzureSqlElasticJobExecutionModel model)
        {
            Communicator.CancelJobExecution(model.ResourceGroupName, model.ServerName, model.AgentName, model.JobName, model.JobExecutionId.Value);
        }

        /// <summary>
        /// Deletes an Azure SQL Database Agent associated to a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="agentName">The agent name</param>
        public List<AzureSqlElasticJobExecutionModel> ListByAgent(
            string resourceGroupName,
            string serverName,
            string agentName,
            DateTime? createTimeMin = null,
            DateTime? createTimeMax = null,
            DateTime? endTimeMin = null,
            DateTime? endTimeMax = null,
            bool? isActive = null,
            int? skip = null,
            int? top = null)
        {
            IPage<JobExecution> resp = Communicator.ListJobExecutionsByAgent(
                resourceGroupName,
                serverName,
                agentName,
                createTimeMin,
                createTimeMax,
                endTimeMin,
                endTimeMax,
                isActive,
                skip,
                top);

            List<AzureSqlElasticJobExecutionModel> executions = resp.Select((jobExecution) =>
                CreateJobExecutionModelFromResponse(resourceGroupName, serverName, agentName,
                new ResourceIdentifier(jobExecution.Id).ParentResourceBuilder[5], jobExecution)).ToList();

            if (resp.NextPageLink != null)
            {
                Match match = Regex.Match(resp.NextPageLink, @"skip=(\d*)");
                int toSkip = int.Parse(match.Groups[1].Value);

                while (top > toSkip)
                {
                    resp = Communicator.ListJobExecutionsByAgent(
                        resourceGroupName,
                        serverName,
                        agentName,
                        createTimeMin,
                        createTimeMax,
                        endTimeMin,
                        endTimeMax,
                        isActive,
                        toSkip,
                        top);

                    executions.AddRange(resp.Select((jobExecution) => CreateJobExecutionModelFromResponse(resourceGroupName, serverName, agentName, new ResourceIdentifier(jobExecution.Id).ParentResourceBuilder[5], jobExecution)));

                    match = Regex.Match(resp.NextPageLink, @"skip=(\d*)");
                    toSkip = int.Parse(match.Groups[1].Value);
                }
            }

            return executions;
        }

        /// <summary>
        /// Deletes an Azure SQL Database Agent associated to a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="agentName">The agent name</param>
        public List<AzureSqlElasticJobExecutionModel> ListByJob(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            DateTime? createTimeMin = null,
            DateTime? createTimeMax = null,
            DateTime? endTimeMin = null,
            DateTime? endTimeMax = null,
            bool? isActive = null,
            int? skip = null,
            int? top = null)
        {
            var resp = Communicator.ListJobExecutionsByJob(
                resourceGroupName, serverName, agentName,
                jobName,
                createTimeMin, createTimeMax,
                endTimeMin, endTimeMax,
                isActive,
                skip,
                top);

            List<AzureSqlElasticJobExecutionModel> executions = resp.Select((rootExecution) => CreateJobExecutionModelFromResponse(resourceGroupName, serverName, agentName, jobName, rootExecution)).ToList();

            if (resp.NextPageLink != null)
            {
                Match match = Regex.Match(resp.NextPageLink, @"skip=(\d*)");
                int toSkip = int.Parse(match.Groups[1].Value);

                while (top > toSkip)
                {
                    resp = Communicator.ListJobExecutionsByJob(
                        resourceGroupName, serverName, agentName,
                        jobName,
                        createTimeMin, createTimeMax,
                        endTimeMin, endTimeMax,
                        isActive,
                        toSkip,
                        top);

                    executions.AddRange(resp.Select((rootExecution) => CreateJobExecutionModelFromResponse(resourceGroupName, serverName, agentName, jobName, rootExecution)).ToList());

                    match = Regex.Match(resp.NextPageLink, @"skip=(\d*)");
                    toSkip = int.Parse(match.Groups[1].Value);
                }
            }

            return executions;
        }

        #endregion

        #region Step Execution

        /// <summary>
        /// Gets a job step execution
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="serverName"></param>
        /// <param name="agentName"></param>
        /// <param name="jobName"></param>
        /// <param name="jobExecutionId"></param>
        /// <param name="stepName"></param>
        /// <returns></returns>
        public AzureSqlElasticJobStepExecutionModel GetJobStepExecution(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            Guid jobExecutionId,
            string stepName)
        {
            var resp = Communicator.GetJobStepExecution(resourceGroupName, serverName, agentName, jobName, jobExecutionId, stepName);
            return CreateJobStepExecutionModelFromResponse(resourceGroupName, serverName, agentName, jobName, resp);
        }

        /// <summary>
        /// Gets a list of job step executions by step name
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="serverName"></param>
        /// <param name="agentName"></param>
        /// <param name="jobName"></param>
        /// <param name="jobExecutionId"></param>
        /// <param name="stepName"></param>
        /// <returns></returns>
        public List<AzureSqlElasticJobStepExecutionModel> ListJobExecutionSteps(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            Guid jobExecutionId,
            DateTime? createTimeMin = null,
            DateTime? createTimeMax = null,
            DateTime? endTimeMin = null,
            DateTime? endTimeMax = null,
            bool? isActive = null,
            int? skip = null,
            int? top = null)
        {
            var resp = Communicator.ListJobExecutionSteps(
                resourceGroupName, serverName, agentName,
                jobName, jobExecutionId,
                createTimeMin, createTimeMax,
                endTimeMin, endTimeMax,
                isActive,
                skip, top);

            return resp.Select((stepExecution) => CreateJobStepExecutionModelFromResponse(resourceGroupName, serverName, agentName, jobName, stepExecution)).ToList();
        }

        #endregion

        #region Target Execution

        /// <summary>
        /// Gets a job target execution
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="serverName"></param>
        /// <param name="agentName"></param>
        /// <param name="jobName"></param>
        /// <param name="jobExecutionId"></param>
        /// <param name="stepName"></param>
        /// <param name="targetId"></param>
        /// <returns></returns>
        public AzureSqlElasticJobTargetExecutionModel GetJobTargetExecution(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            Guid jobExecutionId,
            string stepName,
            Guid targetId)
        {
            var resp = Communicator.GetJobTargetExecution(resourceGroupName, serverName, agentName, jobName, jobExecutionId, stepName, targetId);
            return CreateJobTargetExecutionModelFromResponse(resourceGroupName, serverName, agentName, jobName, resp);
        }

        /// <summary>
        /// Gets a list of job target executions by step name
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="serverName"></param>
        /// <param name="agentName"></param>
        /// <param name="jobName"></param>
        /// <param name="jobExecutionId"></param>
        /// <param name="stepName"></param>
        /// <returns></returns>
        public List<AzureSqlElasticJobTargetExecutionModel> ListJobTargetExecutionsByStep(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            Guid jobExecutionId,
            string stepName,
            DateTime? createTimeMin = null,
            DateTime? createTimeMax = null,
            DateTime? endTimeMin = null,
            DateTime? endTimeMax = null,
            bool? isActive = null,
            int? skip = null,
            int? top = null)
        {
            var resp = Communicator.ListJobTargetExecutionsByStep(
                resourceGroupName, serverName, agentName,
                jobName, jobExecutionId, stepName,
                createTimeMin, createTimeMax,
                endTimeMin, endTimeMax,
                isActive,
                skip, top);

            List<AzureSqlElasticJobTargetExecutionModel> executions = resp.Select((jobTargetExecution) =>
                CreateJobTargetExecutionModelFromResponse(resourceGroupName, serverName, agentName, jobName, jobTargetExecution)).ToList();

            if (resp.NextPageLink != null)
            {
                Match match = Regex.Match(resp.NextPageLink, @"skip=(\d*)");
                int toSkip = int.Parse(match.Groups[1].Value);

                while (top > toSkip)
                {
                    resp = Communicator.ListJobTargetExecutionsByStep(
                        resourceGroupName, serverName, agentName,
                        jobName, jobExecutionId, stepName,
                        createTimeMin, createTimeMax,
                        endTimeMin, endTimeMax,
                        isActive,
                        toSkip, top);

                    executions.AddRange(resp.Select((jobTargetExecution) => CreateJobTargetExecutionModelFromResponse(resourceGroupName, serverName, agentName, jobName, jobTargetExecution)));

                    match = Regex.Match(resp.NextPageLink, @"skip=(\d*)");
                    toSkip = int.Parse(match.Groups[1].Value);
                }
            }

            return executions;
        }

        /// <summary>
        /// Gets a list of job target executions by target id
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="serverName"></param>
        /// <param name="agentName"></param>
        /// <param name="jobName"></param>
        /// <param name="jobExecutionId"></param>
        /// <param name="stepName"></param>
        /// <returns></returns>
        public List<AzureSqlElasticJobTargetExecutionModel> ListJobTargetExecutions(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            Guid jobExecutionId,
            DateTime? createTimeMin = null,
            DateTime? createTimeMax = null,
            DateTime? endTimeMin = null,
            DateTime? endTimeMax = null,
            bool? isActive = null,
            int? skip = null,
            int? top = null)
        {
            var resp = Communicator.ListJobTargetExecutions(
                resourceGroupName, serverName, agentName,
                jobName, jobExecutionId,
                createTimeMin, createTimeMax,
                endTimeMin, endTimeMax,
                isActive,
                skip, top);

            List<AzureSqlElasticJobTargetExecutionModel> executions = resp.Select((targetExecution) => CreateJobTargetExecutionModelFromResponse(resourceGroupName, serverName, agentName, jobName, targetExecution)).ToList();

            if (resp.NextPageLink != null)
            {
                Match match = Regex.Match(resp.NextPageLink, @"skip=(\d*)");
                int toSkip = int.Parse(match.Groups[1].Value);

                while (top > toSkip)
                {
                    resp = Communicator.ListJobTargetExecutions(
                        resourceGroupName, serverName, agentName,
                        jobName, jobExecutionId,
                        createTimeMin, createTimeMax,
                        endTimeMin, endTimeMax,
                        isActive,
                        toSkip, top);

                    executions.AddRange(resp.Select((targetExecution) => CreateJobTargetExecutionModelFromResponse(resourceGroupName, serverName, agentName, jobName, targetExecution)).ToList());

                    match = Regex.Match(resp.NextPageLink, @"skip=(\d*)");
                    toSkip = int.Parse(match.Groups[1].Value);
                }
            }

            return executions;
        }

        /// <summary>
        /// Convert a JobAgent to AzureSqlDatabaseAgentJobExecutionModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The server the agent is in</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted agent model</returns>
        private static AzureSqlElasticJobExecutionModel CreateJobExecutionModelFromResponse(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            JobExecution resp)
        {
            AzureSqlElasticJobExecutionModel jobExecution = new AzureSqlElasticJobExecutionModel
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                AgentName = agentName,
                JobName = jobName,
                JobExecutionId = resp.JobExecutionId,
                CreateTime = resp.CreateTime,
                CurrentAttempts = resp.CurrentAttempts,
                CurrentAttemptStartTime = resp.CurrentAttemptStartTime,
                EndTime = resp.EndTime,
                JobVersion = resp.JobVersion,
                LastMessage = resp.LastMessage,
                Lifecycle = resp.Lifecycle,
                ProvisioningState = resp.ProvisioningState,
                ResourceId = resp.Id,
                StartTime = resp.StartTime,
                Type = resp.Type,
            };

            return jobExecution;
        }

        private static AzureSqlElasticJobStepExecutionModel CreateJobStepExecutionModelFromResponse(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            JobExecution resp)
        {
            AzureSqlElasticJobStepExecutionModel jobStepExecution = new AzureSqlElasticJobStepExecutionModel
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                AgentName = agentName,
                JobName = jobName,
                JobExecutionId = resp.JobExecutionId,
                CreateTime = resp.CreateTime,
                CurrentAttempts = resp.CurrentAttempts,
                CurrentAttemptStartTime = resp.CurrentAttemptStartTime,
                EndTime = resp.EndTime,
                JobVersion = resp.JobVersion,
                LastMessage = resp.LastMessage,
                Lifecycle = resp.Lifecycle,
                ProvisioningState = resp.ProvisioningState,
                ResourceId = resp.Id,
                StartTime = resp.StartTime,
                Type = resp.Type,
                StepId = resp.StepId,
                StepName = resp.StepName,
            };

            return jobStepExecution;
        }

        private static AzureSqlElasticJobTargetExecutionModel CreateJobTargetExecutionModelFromResponse(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            JobExecution resp)
        {
            AzureSqlElasticJobTargetExecutionModel jobTargetExecution = new AzureSqlElasticJobTargetExecutionModel
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                AgentName = agentName,
                JobName = jobName,
                JobExecutionId = resp.JobExecutionId,
                CreateTime = resp.CreateTime,
                CurrentAttempts = resp.CurrentAttempts,
                CurrentAttemptStartTime = resp.CurrentAttemptStartTime,
                EndTime = resp.EndTime,
                JobVersion = resp.JobVersion,
                LastMessage = resp.LastMessage,
                Lifecycle = resp.Lifecycle,
                ProvisioningState = resp.ProvisioningState,
                ResourceId = resp.Id,
                StartTime = resp.StartTime,
                Type = resp.Type,
                StepId = resp.StepId,
                StepName = resp.StepName,
                TargetDatabaseName = resp.Target.DatabaseName,
                TargetServerName = resp.Target.ServerName
            };

            return jobTargetExecution;
        }

        #endregion
    }
}