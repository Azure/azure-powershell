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
using System.Reflection;

namespace Microsoft.Azure.Commands.Sql.Common
{
    /// <summary>
    /// Defines the azure sql elastic jobs cmdlet base
    /// </summary>
    /// <typeparam name="TInputObject">The input object</typeparam>
    /// <typeparam name="TModel">The model</typeparam>
    /// <typeparam name="TAdapter">The adapter</typeparam>
    public abstract class AzureSqlElasticJobsCmdletBase<TInputObject, TModel, TAdapter> : AzureSqlCmdletBase<TModel, TAdapter>
    {
        /// <summary>
        /// Common parameter sets
        /// </summary>
        protected const string DefaultParameterSet = "DefaultSet";
        protected const string InputObjectParameterSet = "ObjectSet";
        protected const string ResourceIdParameterSet = "ResourceIdSet";

        /// <summary>
        /// Common properties
        /// </summary>
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
        public virtual string Name { get; set; }

        /// <summary>
        /// Elastic Jobs Resource Id Templates
        /// </summary>
        private const string ParentResourceIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/jobAgents/{3}/targetGroups/{4}";
        private const string credentialResourceIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/jobAgents/{3}/credentials/{4}";

        /// <summary>
        /// Initializes the input from model object
        /// </summary>
        /// <param name="model">The given input object</param>
        public void InitializeInputObjectProperties(TInputObject model)
        {
            // Return if null
            if (model == null)
            {
                return;
            }

            // Initialize properties
            this.ResourceGroupName = this.ResourceGroupName ?? GetPropertyValue(model, "ResourceGroupName");
            this.ServerName = this.ServerName ?? GetPropertyValue(model, "ServerName");
            this.AgentServerName = GetPropertyValue(model, "ServerName");
            this.DatabaseName = this.DatabaseName ?? GetPropertyValue(model, "DatabaseName");
            this.AgentName = this.AgentName ?? GetPropertyValue(model, "AgentName");
            this.JobName = this.JobName ?? GetPropertyValue(model, "JobName");
            this.StepName = this.StepName ?? GetPropertyValue(model, "StepName");
            this.TargetGroupName = this.TargetGroupName ?? GetPropertyValue(model, "TargetGroupName");
            this.CredentialName = this.CredentialName ?? GetPropertyValue(model, "CredentialName");
            this.JobExecutionId = this.JobExecutionId ?? GetPropertyValue(model, "JobExecutionId");
        }

        /// <summary>
        /// Initializes the input from resource id if necessary
        /// </summary>
        /// <param name="resourceId">The given resource id</param>
        public void InitializeResourceIdProperties(string resourceId)
        {
            // Return if null
            if (resourceId == null)
            {
                return;
            }

            // Initialize properties
            string[] tokens = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            this.ResourceGroupName = this.ResourceGroupName ?? GetPropertyValue(tokens, "resourceGroups", 2);
            this.ServerName = this.ServerName ?? GetPropertyValue(tokens, "servers", 6);
            this.AgentServerName = GetPropertyValue(tokens, "servers", 6);
            this.DatabaseName = this.DatabaseName ?? GetPropertyValue(tokens, "databases", 8);
            this.AgentName = this.AgentName ?? GetPropertyValue(tokens, "jobAgents", 8);
            this.JobName = this.JobName ?? GetPropertyValue(tokens, "jobs", 10);
            this.CredentialName = this.CredentialName ?? GetPropertyValue(tokens, "credentials", 10);
            this.TargetGroupName = this.TargetGroupName ?? GetPropertyValue(tokens, "targetGroups", 10);
            this.StepName = this.StepName ?? GetPropertyValue(tokens, "steps", 12);
            this.JobExecutionId = this.JobExecutionId ?? GetPropertyValue(tokens, "executions", 12);
        }

        /// <summary>
        /// Helper method to return model property from input object model
        /// </summary>
        /// <param name="inputObject">The input object model</param>
        /// <param name="propertyName">The property name</param>
        /// <returns></returns>
        public string GetPropertyValue(TInputObject inputObject, string propertyName)
        {
            PropertyInfo info = inputObject.GetType().GetProperty(propertyName);
            if (info == null)
            {
                return null;
            }

            return info.GetValue(inputObject).ToString();
        }

        /// <summary>
        /// Helper method to return model property value from resource id
        /// </summary>
        /// <param name="resourceIdSegments"></param>
        /// <param name="typeSegmentName"></param>
        /// <param name="typeSegmentIndex"></param>
        /// <returns></returns>
        public string GetPropertyValue(
            string[] resourceIdSegments,
            string typeSegmentName,
            int typeSegmentIndex)
        {
            if (resourceIdSegments.Length >= typeSegmentIndex + 1 &&
                resourceIdSegments[typeSegmentIndex] == typeSegmentName)
            {
                return resourceIdSegments[typeSegmentIndex + 1];
            }

            return null;
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

            return string.Format(ParentResourceIdTemplate,
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