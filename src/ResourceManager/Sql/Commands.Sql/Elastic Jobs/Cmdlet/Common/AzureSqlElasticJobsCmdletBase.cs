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
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Server.Model;
using Microsoft.Azure.Commands.Sql.ElasticJobs.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Common
{
    /// <summary>
    /// Defines the azure sql elastic jobs cmdlet base
    /// </summary>
    /// <typeparam name="IO">The input object</typeparam>
    /// <typeparam name="M">The model</typeparam>
    /// <typeparam name="A">The adapter</typeparam>
    public abstract class AzureSqlElasticJobsCmdletBase<IO, M, A> : AzureSqlCmdletBase<M, A>
    {
        /// <summary>
        /// The shared parameter sets
        /// </summary>
        protected const string DefaultParameterSet = "Default Parameter Set"; // used as (default) parameter set mostly
        protected const string InputObjectParameterSet = "Input Object Parameter Set";
        protected const string ResourceIdParameterSet = "Resource Id Parameter Set";

        public virtual string ServerName { get; set; }
        public virtual string AgentServerName { get; set; }
        public virtual string AgentName { get; set; }
        public virtual string JobName { get; set; }
        public virtual string StepName { get; set; }
        public virtual string JobExecutionId { get; set; }
        public virtual string TargetGroupName { get; set; }
        public virtual string CredentialName { get; set; }
        public virtual string ShardMapName { get; set; }
        public virtual string RefreshCredentialName { get; set; }
        public virtual string ElasticPoolName { get; set; }
        public virtual string DatabaseName { get; set; }

        /// <summary>
        /// Elastic Jobs Resource Id Templates
        /// </summary>
        private const string targetGroupResourceIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/jobAgents/{3}/targetGroups/{4}";
        private const string credentialResourceIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/jobAgents/{3}/credentials/{4}";

        /// <summary>
        /// Initializes the input from model object
        /// </summary>
        /// <param name="model">The given input object</param>
        public void InitializeInputObjectProperties(IO model)
        {
            if (model == null)
            {
                return;
            }

            var resourceGroupProperty = model.GetType().GetProperty("ResourceGroupName");
            this.ResourceGroupName = (resourceGroupProperty != null) ? resourceGroupProperty.GetValue(model).ToString() : this.ResourceGroupName;

            var serverProperty = model.GetType().GetProperty("ServerName");
            if (serverProperty != null)
            {
                string value = serverProperty.GetValue(model).ToString();
                this.AgentServerName = value;
                if (this.ServerName == null)
                {
                    this.ServerName = value;
                }
            }

            var databaseProperty = model.GetType().GetProperty("DatabaseName");
            this.DatabaseName = (databaseProperty != null) ? databaseProperty.GetValue(model).ToString() : this.DatabaseName;

            var agentProperty = model.GetType().GetProperty("AgentName");
            this.AgentName = (agentProperty != null) ? agentProperty.GetValue(model).ToString() : this.AgentName;

            var jobProperty = model.GetType().GetProperty("JobName");
            this.JobName = (jobProperty != null) ? jobProperty.GetValue(model).ToString() : this.JobName;

            var stepProperty = model.GetType().GetProperty("StepName");
            this.StepName = (stepProperty != null) ? stepProperty.GetValue(model).ToString() : this.StepName;

            var targetGroupProperty = model.GetType().GetProperty("TargetGroupName");
            if (targetGroupProperty != null)
            {
                string value = targetGroupProperty.GetValue(model).ToString();
                if (this.TargetGroupName == null)
                {
                    this.TargetGroupName = value;
                }
            }

            var jobCredentialProperty = model.GetType().GetProperty("CredentialName");
            if (jobCredentialProperty != null)
            {
                string value = jobCredentialProperty.GetValue(model).ToString();
                if (this.CredentialName == null)
                {
                    this.CredentialName = value;
                }
            }

            var jobExecutionProperty = model.GetType().GetProperty("JobExecutionId");
            this.JobExecutionId = (jobExecutionProperty != null) ? jobExecutionProperty.GetValue(model).ToString() : this.JobExecutionId;
        }

        /// <summary>
        /// Initializes the input from resource id if necessary
        /// </summary>
        /// <param name="resourceId">The given resource id</param>
        public void InitializeResourceIdProperties(string resourceId)
        {
            if (resourceId == null)
            {
                return;
            }

            string[] tokens = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            int length = tokens.Length;

            if (length >= 7)
            {
                this.ResourceGroupName = tokens[3];
                this.AgentServerName = tokens[7];
                if (this.ServerName == null)
                {
                    this.ServerName = tokens[7];
                }
            }

            if (length >= 9)
            {
                if (tokens[8] == "databases")
                {
                    this.DatabaseName = tokens[9];
                }
                else if (tokens[8] == "jobAgents")
                {
                    this.AgentName = tokens[9];
                }
            }

            if (length >= 11)
            {
                if (tokens[10] == "jobs")
                {
                    this.JobName = tokens[11];
                }
                else if (tokens[10] == "credentials")
                {
                    this.CredentialName = tokens[11];
                }
                else if (tokens[10] == "targetGroups")
                {
                    this.TargetGroupName = tokens[11];
                }
            }

            if (length >= 13)
            {
                if (tokens[12] == "steps")
                {
                    this.StepName = tokens[13];
                }
                else if (tokens[12] == "executions")
                {
                    this.JobExecutionId = tokens[13];
                }
            }
        }

        /// <summary>
        /// Clear properties amongst completing an execution
        /// We need to clear the properties because in piping scenario, existing property values carry over.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ClearProperties();
        }

        protected void ClearProperties()
        {
            this.ResourceGroupName = null;
            this.ServerName = null;
            this.AgentServerName = null;
            this.AgentName = null;
            this.JobName = null;
            this.StepName = null;
            this.JobExecutionId = null;
            this.TargetGroupName = null;
            this.CredentialName = null;
            this.DatabaseName = null;
            this.ShardMapName = null;
            this.ElasticPoolName = null;
            this.RefreshCredentialName = null;
        }

        /// <summary>
        /// Creates the target group id
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="targetGroupName">The target group name</param>
        /// <returns></returns>
        protected string CreateTargetGroupId(
            string resourceGroupName,
            string serverName,
            string agentName,
            string targetGroupName)
        {
            if (targetGroupName == null)
            {
                return null;
            }

            return string.Format(targetGroupResourceIdTemplate,
                            DefaultContext.Subscription.Id,
                            resourceGroupName,
                            serverName,
                            agentName,
                            targetGroupName);
        }

        /// <summary>
        /// Creates the credential id
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="agentName">The agent name</param>
        /// <param name="credentialName">The credential name</param>
        /// <returns></returns>
        protected string CreateCredentialId(
            string resourceGroupName,
            string serverName,
            string agentName,
            string credentialName)
        {
            if (credentialName == null)
            {
                return null;
            }

            return string.Format(credentialResourceIdTemplate,
                            DefaultContext.Subscription.Id,
                            resourceGroupName,
                            serverName,
                            agentName,
                            credentialName);
        }
    }
}