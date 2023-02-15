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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Sql;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlElasticJobCommunicator
    {
        /// <summary>
        /// Gets or sets the Azure subscription
        /// </summary>
        internal static IAzureSubscription Subscription { get; private set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public static IAzureContext Context { get; set; }

        /// <summary>
        /// Creates an Azure SQL Database Agent Communicator
        /// </summary>
        /// <param name="context"></param>
        public AzureSqlElasticJobCommunicator(IAzureContext context)
        {
            Context = context;
            if (Context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
            }
        }

        #region Agent Methods

        /// <summary>
        /// PUT: Creates an Azure SQL Database Agent
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="parameters">The agent's create parameters</param>
        /// <returns>The newly created agent</returns>
        public JobAgent CreateOrUpdateAgent(string resourceGroupName, string serverName, string agentName, JobAgent parameters)
        {
            return GetCurrentSqlClient().JobAgents.CreateOrUpdate(resourceGroupName, serverName, agentName, parameters);
        }

        /// <summary>
        /// PATCH: Updates an Azure SQL Database Agent
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="parameters">The newly created agent</param>
        /// <returns></returns>
        public JobAgent UpdateAgent(string resourceGroupName, string serverName, string agentName, JobAgentUpdate parameters)
        {
            return GetCurrentSqlClient().JobAgents.Update(resourceGroupName, serverName, agentName, parameters);
        }

        /// <summary>
        /// Gets the agent associated to resourceGroup
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="serverName"></param>
        /// <param name="agentName"></param>
        /// <returns>The agent belonging to specified server</returns>
        public JobAgent GetAgent(string resourceGroupName, string serverName, string agentName)
        {
            return GetCurrentSqlClient().JobAgents.Get(resourceGroupName, serverName, agentName);
        }

        /// <summary>
        /// Lists the agents associated to resource group and server
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <returns>A list of agents belonging to specified server</returns>
        public IPage<JobAgent> ListAgentsByServer(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().JobAgents.ListByServer(resourceGroupName, serverName);
        }

        /// <summary>
        /// Deletes the agent associated to resource group name and server name.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        public void RemoveAgent(string resourceGroupName, string serverName, string agentName)
        {
            GetCurrentSqlClient().JobAgents.Delete(resourceGroupName, serverName, agentName);
        }

        #endregion

        #region Job Credential Methods

        /// <summary>
        /// Creates an Azure SQL Database Agent Job Credential
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="credentialName">The credential name</param>
        /// <param name="parameters">The agent's create parameters</param>
        /// <returns>The newly created agent</returns>
        public JobCredential CreateOrUpdateJobCredential(
            string resourceGroupName,
            string serverName,
            string agentName,
            string credentialName,
            JobCredential parameters)
        {
            return GetCurrentSqlClient().JobCredentials.CreateOrUpdate(resourceGroupName, serverName, agentName, credentialName, parameters);
        }

        /// <summary>
        /// Gets the associated Job Credential associated to the Azure SQL Database Agent
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="serverName"></param>
        /// <param name="agentName"></param>
        /// <param name="credentialName"></param>
        /// <returns>The agent belonging to specified server</returns>
        public JobCredential GetJobCredential(
            string resourceGroupName,
            string serverName,
            string agentName,
            string credentialName)
        {
            return GetCurrentSqlClient().JobCredentials.Get(resourceGroupName, serverName, agentName, credentialName);
        }

        /// <summary>
        /// Lists the credentials associated to the Azure SQL Database Agent.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <returns>A list of credentials belonging to specified agent</returns>
        public IPage<JobCredential> GetJobCredential(
            string resourceGroupName,
            string serverName,
            string agentName)
        {
            return GetCurrentSqlClient().JobCredentials.ListByAgent(resourceGroupName, serverName, agentName);
        }

        /// <summary>
        /// Deletes the credential associated to the agent.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="credentialName">The credential name</param>
        public void RemoveJobCredential(
            string resourceGroupName,
            string serverName,
            string agentName,
            string credentialName)
        {
            GetCurrentSqlClient().JobCredentials.Delete(resourceGroupName, serverName, agentName, credentialName);
        }

        #endregion

        #region Job Methods

        /// <summary>
        /// Creates a job
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="agentServerName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="parameters">The job' create parameters</param>
        /// <returns>A new job</returns>
        public Job CreateOrUpdateJob(string resourceGroupName, string agentServerName, string agentName, string jobName, Job parameters)
        {
            return GetCurrentSqlClient().Jobs.CreateOrUpdate(resourceGroupName, agentServerName, agentName, jobName, parameters);
        }

        /// <summary>
        /// Gets the job
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="agentServerName">The agent server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <returns>The job belonging to the agent</returns>
        public Job GetJob(string resourceGroupName, string agentServerName, string agentName, string jobName)
        {
            return GetCurrentSqlClient().Jobs.Get(resourceGroupName, agentServerName, agentName, jobName);
        }

        /// <summary>
        /// Gets a list of jobs that agentName owns.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="agentServerName">The agent server name</param>
        /// <param name="agentName">The agent name</param>
        /// <returns></returns>
        public IPage<Job> ListJobsByAgent(string resourceGroupName, string agentServerName, string agentName)
        {
            return GetCurrentSqlClient().Jobs.ListByAgent(resourceGroupName, agentServerName, agentName);
        }

        /// <summary>
        /// Deletes the job associated to the agent.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="agentServerName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        public void RemoveJob(string resourceGroupName, string agentServerName, string agentName, string jobName)
        {
            GetCurrentSqlClient().Jobs.Delete(resourceGroupName, agentServerName, agentName, jobName);
        }

        #endregion

        #region Job Execution Methods

        /// <summary>
        /// Creates a job execution in job and returns immediately with job execution id
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <returns>A new job execution</returns>
        public JobExecution BeginCreate(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName)
        {
            return GetCurrentSqlClient().JobExecutions.BeginCreate(resourceGroupName, serverName, agentName, jobName);
        }

        /// <summary>
        /// Creates a job execution for a job and polls until complete
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="serverName"></param>
        /// <param name="agentName"></param>
        /// <param name="jobName"></param>
        /// <returns></returns>
        public JobExecution CreateJobExecution(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName)
        {
            return GetCurrentSqlClient().JobExecutions.Create(resourceGroupName, serverName, agentName, jobName);
        }

        /// <summary>
        /// Gets the associated Job Credential associated to the Azure SQL Database Agent
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="jobExecutionId">The job execution id</param>
        /// <returns>The agent belonging to specified server</returns>
        public JobExecution GetJobExecution(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            Guid jobExecutionId)
        {
            return GetCurrentSqlClient().JobExecutions.Get(resourceGroupName, serverName, agentName, jobName, jobExecutionId);
        }

        /// <summary>
        /// Returns a list of job executions across the agent
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="createTimeMin">The create time min</param>
        /// <param name="createTimeMax">The create time max</param>
        /// <param name="endTimeMin">The end time min</param>
        /// <param name="endTimeMax">The end time max</param>
        /// <param name="isActive">The is active flag</param>
        /// <param name="skip">The skip count</param>
        /// <param name="top">The top count</param>
        /// <returns>The list of job executions across the agent</returns>
        public List<JobExecution> ListJobExecutionsByAgent(
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
            List<JobExecution> results = new List<JobExecution>();
            IPage<JobExecution> jobExecutions = GetCurrentSqlClient().JobExecutions.ListByAgent(
                resourceGroupName: resourceGroupName,
                serverName: serverName,
                jobAgentName: agentName,
                createTimeMin: createTimeMin,
                createTimeMax: createTimeMax,
                endTimeMin: endTimeMin,
                endTimeMax: endTimeMax,
                isActive: isActive,
                skip: skip,
                top: top);
            results.AddRange(jobExecutions);

            while (jobExecutions.NextPageLink != null)
            {
                jobExecutions = GetCurrentSqlClient().JobExecutions.ListByAgentNext(jobExecutions.NextPageLink);
                results.AddRange(jobExecutions);
            }

            return results;
        }

        /// <summary>
        /// Returns a list of job executions for a job
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="createTimeMin">The create time min</param>
        /// <param name="createTimeMax">The create time max</param>
        /// <param name="endTimeMin">The end time min</param>
        /// <param name="endTimeMax">The end time max</param>
        /// <param name="isActive">The is active flag</param>
        /// <param name="skip">The skip count</param>
        /// <param name="top">The top count</param>
        /// <returns>The list of job executions by job</returns>
        public List<JobExecution> ListJobExecutionsByJob(
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
            List<JobExecution> results = new List<JobExecution>();
            IPage<JobExecution> jobExecutions = GetCurrentSqlClient().JobExecutions.ListByJob(
                resourceGroupName: resourceGroupName,
                serverName: serverName,
                jobAgentName: agentName,
                jobName: jobName,
                createTimeMin: createTimeMin,
                createTimeMax: createTimeMax,
                endTimeMin: endTimeMin,
                endTimeMax: endTimeMax,
                isActive: isActive,
                skip: skip,
                top: top);
            results.AddRange(jobExecutions);

            while (jobExecutions.NextPageLink != null)
            {
                jobExecutions = GetCurrentSqlClient().JobExecutions.ListByJobNext(jobExecutions.NextPageLink);
                results.AddRange(jobExecutions);
            }

            return results;
        }

        /// <summary>
        /// Deletes the credential associated to the agent.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="jobExecutionId">The job execution id</param>
        public void CancelJobExecution(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            Guid jobExecutionId)
        {
            GetCurrentSqlClient().JobExecutions.Cancel(resourceGroupName, serverName, agentName, jobName, jobExecutionId);
        }

        #region Job Step Executions

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
        public JobExecution GetJobStepExecution(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            Guid jobExecutionId,
            string stepName)
        {
            return GetCurrentSqlClient().JobStepExecutions.Get(resourceGroupName, serverName, agentName, jobName, jobExecutionId, stepName);
        }

        /// <summary>
        /// Gets a list of job step executions
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="jobExecutionId">The job execution id</param>
        /// <param name="createTimeMin">The create time min</param>
        /// <param name="createTimeMax">The create time max</param>
        /// <param name="endTimeMin">The end time min</param>
        /// <param name="endTimeMax">The end time max</param>
        /// <param name="isActive">The is active filter</param>
        /// <param name="skip">The skip count</param>
        /// <param name="top">The top count</param>
        /// <returns>Returns a list of job step executions for a job execution</returns>
        public List<JobExecution> ListJobExecutionSteps(
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
            List<JobExecution> results = new List<JobExecution>();
            IPage<JobExecution> stepExecutions = GetCurrentSqlClient().JobStepExecutions.ListByJobExecution(
                resourceGroupName, serverName, agentName,
                jobName, jobExecutionId,
                createTimeMin, createTimeMax,
                endTimeMin, endTimeMax,
                isActive, skip, top);
            results.AddRange(stepExecutions);

            while (stepExecutions.NextPageLink != null)
            {
                stepExecutions = GetCurrentSqlClient().JobStepExecutions.ListByJobExecutionNext(stepExecutions.NextPageLink);
                results.AddRange(stepExecutions);
            }

            return results;
        }

        #endregion


        #region Job Target Executions

        /// <summary>
        /// Gets the job target execution
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="jobExecutionId">The job execution id</param>
        /// <param name="stepName">The step name</param>
        /// <param name="targetId">The target id</param>
        /// <returns></returns>
        public JobExecution GetJobTargetExecution(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            Guid jobExecutionId,
            string stepName,
            Guid targetId)
        {
            return GetCurrentSqlClient().JobTargetExecutions.Get(resourceGroupName, serverName, agentName, jobName, jobExecutionId, stepName, targetId);
        }

        /// <summary>
        /// Gets a list of job target executions
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="jobExecutionId">The job execution id</param>
        /// <param name="createTimeMin">The create time min</param>
        /// <param name="createTimeMax">The create time max</param>
        /// <param name="endTimeMin">The end time min</param>
        /// <param name="endTimeMax">The end time max</param>
        /// <param name="isActive">The is active flag</param>
        /// <param name="skip">The skip count</param>
        /// <param name="top">The top count</param>
        /// <returns></returns>
        public List<JobExecution> ListJobTargetExecutions(
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
            List<JobExecution> results = new List<JobExecution>();
            IPage<JobExecution> targetExecutions = GetCurrentSqlClient().JobTargetExecutions.ListByJobExecution(
                resourceGroupName, serverName, agentName,
                jobName, jobExecutionId,
                createTimeMin, createTimeMax,
                endTimeMin, endTimeMax,
                isActive, skip, top);
            results.AddRange(targetExecutions);

            while (targetExecutions.NextPageLink != null)
            {
                targetExecutions = GetCurrentSqlClient().JobTargetExecutions.ListByJobExecutionNext(targetExecutions.NextPageLink);
                results.AddRange(targetExecutions);
            }

            return results;
        }

        /// <summary>
        /// Gets a list of job target executions per step
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="jobExecutionId">The job execution id</param>
        /// <param name="stepName">The job step name</param>
        /// <param name="createTimeMin">The create time min</param>
        /// <param name="createTimeMax">The create time max</param>
        /// <param name="endTimeMin">The end time min</param>
        /// <param name="endTimeMax">The end time max</param>
        /// <param name="isActive">The is active flag</param>
        /// <param name="skip">The skip count</param>
        /// <param name="top">The top count</param>
        /// <returns></returns>
        public List<JobExecution> ListJobTargetExecutionsByStep(
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
            List<JobExecution> results = new List<JobExecution>();
            IPage<JobExecution> targetExecutionsByStep = GetCurrentSqlClient().JobTargetExecutions.ListByStep(
                resourceGroupName, serverName, agentName,
                jobName, jobExecutionId, stepName,
                createTimeMin, createTimeMax,
                endTimeMin, endTimeMax,
                isActive, skip, top);
            results.AddRange(targetExecutionsByStep);

            while (targetExecutionsByStep.NextPageLink != null)
            {
                targetExecutionsByStep = GetCurrentSqlClient().JobTargetExecutions.ListByStepNext(targetExecutionsByStep.NextPageLink);
                results.AddRange(targetExecutionsByStep);
            }

            return results;
        }

        #endregion

        #endregion

        #region Job Step Methods

        /// <summary>
        /// Creates a job step
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="stepName">The target groups name</param>
        /// <param name="parameters">The target group's create parameters</param>
        /// <returns>The created target group</returns>
        public JobStep CreateOrUpdateJobStep(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            string stepName,
            JobStep parameters)
        {
            return GetCurrentSqlClient().JobSteps.CreateOrUpdate(resourceGroupName, serverName, agentName, jobName, stepName, parameters);
        }

        /// <summary>
        /// Gets a job step
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="stepName">The step name</param>
        /// <returns>The job step belonging to the job</returns>
        public JobStep GetJobStep(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            string stepName)
        {
            return GetCurrentSqlClient().JobSteps.Get(resourceGroupName, serverName, agentName, jobName, stepName);
        }

        /// <summary>
        /// Gets all job steps by job version
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="jobVersion">The job version</param>
        /// <param name="stepName">The step name</param>
        /// <returns>A list of steps in a job for specific job version</returns>
        public JobStep GetJobStepByVersion(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            int jobVersion,
            string stepName)
        {
            return GetCurrentSqlClient().JobSteps.GetByVersion(resourceGroupName, serverName, agentName, jobName, jobVersion, stepName);
        }

        /// <summary>
        /// Gets all steps by job version
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="jobVersion">The job version</param>
        /// <returns>Pages of job steps for a job for a specific version</returns>
        public IPage<JobStep> ListJobStepsByVersion(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            int jobVersion)
        {
            return GetCurrentSqlClient().JobSteps.ListByVersion(resourceGroupName, serverName, agentName, jobName, jobVersion);
        }


        /// <summary>
        /// Gets all steps from a job
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <returns>Pages of job steps for a job</returns>
        public IPage<JobStep> ListJobStepsByJob(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName)
        {
            return GetCurrentSqlClient().JobSteps.ListByJob(resourceGroupName, serverName, agentName, jobName);
        }

        /// <summary>
        /// Deletes a job step belong to a job.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="jobName">The job name</param>
        /// <param name="stepName">The step name</param>
        public void RemoveJobStep(
            string resourceGroupName,
            string serverName,
            string agentName,
            string jobName,
            string stepName)
        {
            GetCurrentSqlClient().JobSteps.Delete(resourceGroupName, serverName, agentName, jobName, stepName);
        }

        #endregion

        #region Job Version Methods

        public JobVersion GetJobVersion(string resourceGroupName, string serverName, string agentName, string jobName, int jobVersion)
        {
            var resp = GetCurrentSqlClient().JobVersions.Get(resourceGroupName, serverName, agentName, jobName, jobVersion);
            return resp;
        }

        public IPage<JobVersion> GetJobVersion(string resourceGroupName, string serverName, string agentName, string jobName)
        {
            var resp = GetCurrentSqlClient().JobVersions.ListByJob(resourceGroupName, serverName, agentName, jobName);
            return resp;
        }

        #endregion

        #region Target Group Methods

        /// <summary>
        /// Creates an Azure SQL Database Agent Target Group
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="targetGroupName">The target groups name</param>
        /// <param name="parameters">The target group's create parameters</param>
        /// <returns>The created target group</returns>
        public JobTargetGroup CreateOrUpdateTargetGroup(
            string resourceGroupName,
            string serverName,
            string agentName,
            string targetGroupName,
            JobTargetGroup parameters)
        {
            return GetCurrentSqlClient().JobTargetGroups.CreateOrUpdate(resourceGroupName, serverName, agentName, targetGroupName, parameters);
        }

        /// <summary>
        /// Gets the associated Target group associated to the Azure SQL Database Agent
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="serverName"></param>
        /// <param name="agentName"></param>
        /// <param name="targetGroupName"></param>
        /// <returns>The target group belonging to specified agent</returns>
        public JobTargetGroup GetTargetGroup(
            string resourceGroupName,
            string serverName,
            string agentName,
            string targetGroupName)
        {
            return GetCurrentSqlClient().JobTargetGroups.Get(resourceGroupName, serverName, agentName, targetGroupName);
        }

        /// <summary>
        /// Lists the target groups associated to the Azure SQL Database Agent.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <returns>A list of target groups belonging to specified agent</returns>
        public IPage<JobTargetGroup> GetTargetGroup(
            string resourceGroupName,
            string serverName,
            string agentName)
        {
            return GetCurrentSqlClient().JobTargetGroups.ListByAgent(resourceGroupName, serverName, agentName);
        }

        /// <summary>
        /// Deletes the target groups associated to the agent.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="targetGroupName">The target group name</param>
        public void RemoveTargetGroup(
            string resourceGroupName,
            string serverName,
            string agentName,
            string targetGroupName)
        {
            GetCurrentSqlClient().JobTargetGroups.Delete(resourceGroupName, serverName, agentName, targetGroupName);
        }

        #endregion


        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        public static SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            // Note: client is not cached in static field because that causes ObjectDisposedException in functional tests.
            var sqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            return sqlClient;
        }
    }
}