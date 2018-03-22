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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Services;
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Cmdlet
{
    public abstract class AzureSqlDatabaseAgentTargetCmdletBase : AzureSqlCmdletBase<IEnumerable<JobTarget>, AzureSqlDatabaseAgentTargetGroupAdapter>
    {
        /// <summary>
        /// The target in question
        /// </summary>
        protected JobTarget Target;

        /// <summary>
        /// The existing targets
        /// </summary>
        protected List<JobTarget> ExistingTargets;

        /// <summary>
        /// Flag to determine whether an update to targets in target group is needed in this powershell session
        /// </summary>
        protected bool NeedsUpdate;

        /// <summary>
        /// Parameter set name for default sets
        /// </summary>
        protected const string SqlDatabaseSet = "Sql Database Target Type";
        protected const string SqlServerOrElasticPoolSet = "Sql Server or Elastic Pool Target Type";
        protected const string SqlShardMapSet = "Sql Shard Map Target Type";

        /// <summary>
        /// Parameter sets for input object
        /// </summary>
        protected const string InputObjectSqlDatabaseSet = "Sql Database Input Object Parameter Set";
        protected const string InputObjectSqlServerOrElasticPoolSet = "Sql Server or Elastic Pool Input Object Parameter Set";
        protected const string InputObjectSqlShardMapSet = "Sql Shard Map Input Object Parameter Set";

        /// <summary>
        /// Parameter sets for resource id
        /// </summary>
        protected const string ResourceIdSqlDatabaseSet = "Sql Database ResourceId Parameter Set";
        protected const string ResourceIdSqlServerOrElasticPoolSet = "Sql Server or Elastic Pool ResourceId Parameter Set";
        protected const string ResourceIdSqlShardMapSet = "Sql Shard Map ResourceId Parameter Set";

        /// <summary>
        /// Gets or sets the target group input object.
        /// </summary>
        [Parameter(ParameterSetName = InputObjectSqlDatabaseSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The SQL Database Agent Target Group Object")]
        [Parameter(ParameterSetName = InputObjectSqlServerOrElasticPoolSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The SQL Database Agent Target Group Object")]
        [Parameter(ParameterSetName = InputObjectSqlShardMapSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The SQL Database Agent Target Group Object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlDatabaseAgentTargetGroupModel InputObject { get; set; }

        /// <summary>
		/// Gets or sets the target group resource id.
		/// </summary>
		[Parameter(ParameterSetName = ResourceIdSqlDatabaseSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The resource id of the target group")]
        [Parameter(ParameterSetName = ResourceIdSqlServerOrElasticPoolSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The resource id of the target group")]
        [Parameter(ParameterSetName = ResourceIdSqlShardMapSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The resource id of the target group")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            ParameterSetName = SqlServerOrElasticPoolSet,
            HelpMessage = "Resource Group Name")]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            ParameterSetName = SqlDatabaseSet,
            HelpMessage = "Resource Group Name")]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            ParameterSetName = SqlShardMapSet,
            HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the agent's server name
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            ParameterSetName = SqlServerOrElasticPoolSet,
            HelpMessage = "SQL Database Agent Server Name.")]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            ParameterSetName = SqlDatabaseSet,
            HelpMessage = "SQL Database Agent Server Name.")]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            ParameterSetName = SqlShardMapSet,
            HelpMessage = "SQL Database Agent Server Name.")]
        [ValidateNotNullOrEmpty]
        public string AgentServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the agent
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            ParameterSetName = SqlServerOrElasticPoolSet,
            HelpMessage = "SQL Database Agent Name.")]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            ParameterSetName = SqlDatabaseSet,
            HelpMessage = "SQL Database Agent Name.")]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            ParameterSetName = SqlShardMapSet,
            HelpMessage = "SQL Database Agent Name.")]
        [ValidateNotNullOrEmpty]
        public string AgentName { get; set; }

        /// <summary>
        /// Gets or sets the target group name
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            ParameterSetName = SqlServerOrElasticPoolSet,
            HelpMessage = "SQL Database Agent Name.")]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            ParameterSetName = SqlDatabaseSet,
            HelpMessage = "SQL Database Agent Name.")]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            ParameterSetName = SqlShardMapSet,
            HelpMessage = "SQL Database Agent Name.")]
        public string TargetGroupName { get; set; }

        /// <summary>
        /// Gets or sets the Target Server Name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Server Target Name",
            ParameterSetName = SqlServerOrElasticPoolSet)]
        [Parameter(Mandatory = true,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Server Target Name",
            ParameterSetName = SqlDatabaseSet)]
        [Parameter(Mandatory = true,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Server Target Name",
            ParameterSetName = SqlShardMapSet)]
        [Parameter(ParameterSetName = InputObjectSqlDatabaseSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Server Target Name")]
        [Parameter(ParameterSetName = InputObjectSqlServerOrElasticPoolSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Server Target Name")]
        [Parameter(ParameterSetName = InputObjectSqlShardMapSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Server Target Name")]
        [Parameter(ParameterSetName = ResourceIdSqlDatabaseSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Server Target Name")]
        [Parameter(ParameterSetName = ResourceIdSqlServerOrElasticPoolSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Server Target Name")]
        [Parameter(ParameterSetName = ResourceIdSqlShardMapSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Server Target Name")]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the Target Elastic Pool Name
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Elastic Pool Target Name",
            ParameterSetName = SqlServerOrElasticPoolSet)]
        [Parameter(Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Elastic Pool Target Name",
            ParameterSetName = InputObjectSqlServerOrElasticPoolSet)]
        [Parameter(Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Elastic Pool Target Name",
            ParameterSetName = ResourceIdSqlServerOrElasticPoolSet)]
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the Shard Map Name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Shard Map Target Name",
            ParameterSetName = SqlShardMapSet)]
        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Shard Map Target Name",
            ParameterSetName = InputObjectSqlShardMapSet)]
        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Shard Map Target Name",
            ParameterSetName = ResourceIdSqlShardMapSet)]
        public string ShardMapName { get; set; }

        /// <summary>
        /// Gets or sets the Target Database Name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Database Target Name",
            ParameterSetName = SqlDatabaseSet)]
        [Parameter(
            Mandatory = true,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Shard Map Database Target Name",
            ParameterSetName = SqlShardMapSet)]
        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Database Target Name",
            ParameterSetName = InputObjectSqlDatabaseSet)]
        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Database Target Name",
            ParameterSetName = ResourceIdSqlDatabaseSet)]
        [Parameter(Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Database Target Name",
            ParameterSetName = InputObjectSqlShardMapSet)]
        [Parameter(Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Database Target Name",
            ParameterSetName = ResourceIdSqlShardMapSet)]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the Refresh Credential Name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Refresh Credential Name",
            ParameterSetName = SqlServerOrElasticPoolSet)]
        [Parameter(
            Mandatory = true,
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Refresh Credential Name",
            ParameterSetName = SqlShardMapSet)]
        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Refresh Credential Name",
            ParameterSetName = InputObjectSqlServerOrElasticPoolSet)]
        [Parameter(Mandatory = true,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Refresh Credential Name",
            ParameterSetName = InputObjectSqlShardMapSet)]
        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Refresh Credential Name",
            ParameterSetName = ResourceIdSqlServerOrElasticPoolSet)]
        [Parameter(Mandatory = true,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Refresh Credential Name",
            ParameterSetName = ResourceIdSqlShardMapSet)]
        public string RefreshCredentialName { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter for whether or not this target will be excluded.
        /// </summary>
        public virtual SwitchParameter Exclude { get; set; }

        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <param name="subscription">The subscription the cmdlets are operation under</param>
        /// <returns>The Azure SQL Database Agent Target Group adapter</returns>
        protected override AzureSqlDatabaseAgentTargetGroupAdapter InitModelAdapter(IAzureSubscription subscription)
        {
            return new AzureSqlDatabaseAgentTargetGroupAdapter(DefaultContext);
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case InputObjectSqlDatabaseSet:
                case InputObjectSqlServerOrElasticPoolSet:
                case InputObjectSqlShardMapSet:
                    this.ResourceGroupName = InputObject.ResourceGroupName;
                    this.AgentServerName = InputObject.ServerName;
                    this.AgentName = InputObject.AgentName;
                    this.TargetGroupName = InputObject.TargetGroupName;
                    break;
                case ResourceIdSqlDatabaseSet:
                case ResourceIdSqlServerOrElasticPoolSet:
                case ResourceIdSqlShardMapSet:
                    string[] tokens = ResourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    this.ResourceGroupName = tokens[3];
                    this.AgentServerName = tokens[7];
                    this.AgentName = tokens[9];
                    this.TargetGroupName = tokens[tokens.Length - 1];
                    break;
                default:
                    break;
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Updates the existing list of targets with the new target if it doesn't already exist in the list.
        /// </summary>
        /// <param name="existingTargets">The list of existing targets in the target group</param>
        /// <returns>An updated list of targets.</returns>
        protected override IEnumerable<JobTarget> ApplyUserInputToModel(IEnumerable<JobTarget> existingTargets)
        {
            this.Target = CreateJobTargetModel();
            this.ExistingTargets = existingTargets.ToList();
            this.NeedsUpdate = UpdateExistingTargets();

            // If we don't need to send an update, send back an empty list.
            if (!this.NeedsUpdate)
            {
                return new List<JobTarget>();
            }

            return this.ExistingTargets;
        }

        /// <summary>
        /// Sends the changes to the service -> Creates or updates the target if necessary
        /// </summary>
        /// <param name="updatedTargets">The list of updated targets</param>
        /// <returns>The target that was created/updated or null if nothing changed.</returns>
        protected override IEnumerable<JobTarget> PersistChanges(IEnumerable<JobTarget> updatedTargets)
        {
            // If we don't need to update the target group member's return null.
            if (!this.NeedsUpdate)
            {
                return null;
            }

            // Update list of targets
            AzureSqlDatabaseAgentTargetGroupModel model = new AzureSqlDatabaseAgentTargetGroupModel
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.AgentServerName,
                AgentName = this.AgentName,
                TargetGroupName = this.TargetGroupName,
                Members = updatedTargets.ToList()
            };

            var resp = ModelAdapter.UpsertTargetGroup(model).Members.ToList();

            return new List<JobTarget> { this.Target };
        }

        /// <summary>
        /// Helper to create a job target model from user input.
        /// </summary>
        /// <returns>Job target model</returns>
        protected JobTarget CreateJobTargetModel()
        {
            return new JobTarget
            {
                MembershipType = MyInvocation.BoundParameters.ContainsKey("Exclude") ?
                    JobTargetGroupMembershipType.Exclude :
                    JobTargetGroupMembershipType.Include,
                Type = GetTargetType(),
                ServerName = this.ServerName,
                DatabaseName = MyInvocation.BoundParameters.ContainsKey("DatabaseName") ? this.DatabaseName : null,
                ElasticPoolName = MyInvocation.BoundParameters.ContainsKey("ElasticPoolName") ? this.ElasticPoolName : null,
                ShardMapName = MyInvocation.BoundParameters.ContainsKey("ShardMapName") ? this.ShardMapName : null,
                RefreshCredential = MyInvocation.BoundParameters.ContainsKey("RefreshCredentialName") ? GetJobCredentialId(this.RefreshCredentialName) : null,
            };
        }

        /// <summary>
        /// Helper for determining based on parameter set what target type this target should be.
        /// </summary>
        /// <returns>The target type</returns>
        public string GetTargetType()
        {
            if (this.ShardMapName != null)
            {
                return JobTargetType.SqlShardMap;
            }

            if (this.ElasticPoolName != null)
            {
                return JobTargetType.SqlElasticPool;
            }

            if (this.DatabaseName != null)
            {
                return JobTargetType.SqlDatabase;
            }

            return JobTargetType.SqlServer;
        }

        /// <summary>
        /// Returns the job credential id
        /// </summary>
        /// <param name="refreshCredentialName"></param>
        /// <returns>The job credential id</returns>
        protected string GetJobCredentialId(
            string refreshCredentialName)
        {
            if (refreshCredentialName == null)
            {
                return null;
            }

            string credentialId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/jobAgents/{3}/credentials/{4}",
                AzureSqlDatabaseAgentTargetGroupCommunicator.Subscription.Id,
                this.ResourceGroupName,
                this.AgentServerName,
                this.AgentName,
                refreshCredentialName);

            return credentialId;
        }

        /// <summary>
        /// Gets the list of existing targets in the target group.
        /// </summary>
        /// <returns>The list of existing targets</returns>
        protected override IEnumerable<JobTarget> GetEntity()
        {
            IList<JobTarget> existingTargets = ModelAdapter.GetTargetGroup(this.ResourceGroupName, this.AgentServerName, this.AgentName, this.TargetGroupName).Members;
            return existingTargets;
        }

        /// <summary>
        /// Does a scan over the list of targets and finds the target's index in the list
        /// </summary>
        protected int? FindTarget()
        {
            for (int i = 0; i < this.ExistingTargets.Count; i++)
            {
                JobTarget t = this.ExistingTargets[i];

                if (t.ServerName == this.Target.ServerName &&
                    t.DatabaseName == this.Target.DatabaseName &&
                    t.ElasticPoolName == this.Target.ElasticPoolName &&
                    t.ShardMapName == this.Target.ShardMapName &&
                    t.Type == this.Target.Type &&
                    t.RefreshCredential == this.Target.RefreshCredential)
                {
                    return i;
                }
            }

            return null;
        }

        /// <summary>
        /// Abstract method when adding or removing targets
        /// </summary>
        /// <returns></returns>
        protected abstract bool UpdateExistingTargets();
    }
}