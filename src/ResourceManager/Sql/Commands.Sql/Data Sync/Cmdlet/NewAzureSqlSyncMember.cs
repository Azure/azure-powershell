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

using System.Security;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Hyak.Common;
using Microsoft.Azure.Commands.Sql.DataSync.Model;
using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System;

namespace Microsoft.Azure.Commands.Sql.DataSync.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new sync member
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlSyncMember", SupportsShouldProcess = true,
        DefaultParameterSetName = AzureSqlSet,
        ConfirmImpact = ConfirmImpact.Low)]
    public class NewAzureSqlSyncMember : AzureSqlSyncMemberCmdletBase
    {
        /// <summary>
        /// Parameter set name for Azure Sql Database
        /// </summary>
        private const string AzureSqlSet = "AzureSql";

        /// <summary>
        /// Parameter set name for On Premise Database
        /// </summary>
        private const string OnPremiseSet = "OnPremise";

        /// <summary>
        /// Gets or sets the sync member name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The sync member name.")]
        [ValidateNotNullOrEmpty]
        public string SyncMemberName { get; set; }

        /// <summary>
        /// Gets or sets the database type of the member database
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The database type.")]
        [ValidateSet("SqlServerDatabase", "AzureSqlDatabase", IgnoreCase = true)]
        public string DatabaseType { get; set; }

        /// <summary>
        /// Gets or sets the sync direction of this sync member
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The sync direction of this sync member.")]
        [ValidateSet("Bidirectional", "OneWayMemberToHub", "OneWayHubToMember", IgnoreCase = true)]
        public string SyncDirection { get; set; }

        /// <summary>
        /// Gets or sets the Azure SQL Server Name of the member database. 
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = AzureSqlSet,
            HelpMessage = "The Azure SQL Server Name of the member database.")]
        public string MemberServerName { get; set; }

        /// <summary>
        /// Gets or sets the Azure SQL database name of the member database. 
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = AzureSqlSet,
            HelpMessage = "The Azure SQL database name of the member database.")]
        public string MemberDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the credential (username and password) of Azure SQL database. 
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = AzureSqlSet,
            HelpMessage = "The credential (username and password) of Azure SQL database.")]
        public PSCredential Credential { get; set; }

        /// <summary>
        /// Gets or sets the resource group name of the sync agent.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = OnPremiseSet,
            HelpMessage = "The name of the resource group where the sync agent is under.")]
        [ValidateNotNullOrEmpty]
        public string SyncAgentResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the server name of the sync agent.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = OnPremiseSet,
            HelpMessage = "The name of server where the sync agent is under.")]
        [ValidateNotNullOrEmpty]
        public string SyncAgentServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of sync agent.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = OnPremiseSet,
            HelpMessage = "The name of the sync agent.")]
        [ValidateNotNullOrEmpty]
        public string SyncAgentName { get; set; }

        /// <summary>
        /// Gets or sets the id of the SQL server database which is connected by the sync agent. 
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = OnPremiseSet,
            HelpMessage = "The id of the SQL server database which is connected by the sync agent.")]
        [ValidateNotNullOrEmpty]
        public string SqlServerDatabaseId { get; set; }

        /// <summary>
        /// The id of the sync agent which is connected by the on-premises SQL server.
        /// </summary>
        private string syncAgentId = null;

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlSyncMemberModel> GetEntity()
        {
            // We try to get the sync member.  Since this is a create, we don't want the sync member to exist
            try
            {
                ModelAdapter.GetSyncMember(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.SyncGroupName, this.SyncMemberName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no sync member with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The sync member already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.SyncMemberNameExists, this.SyncMemberName, this.SyncGroupName),
                "SyncMemberName");
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlSyncMemberModel> ApplyUserInputToModel(IEnumerable<AzureSqlSyncMemberModel> model)
        {
            List<AzureSqlSyncMemberModel> newEntity = new List<AzureSqlSyncMemberModel>();
            AzureSqlSyncMemberModel newModel = new AzureSqlSyncMemberModel()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                DatabaseName = this.DatabaseName,
                SyncGroupName = this.SyncGroupName,
                SyncMemberName = this.SyncMemberName,
                SyncDirection = this.SyncDirection
            };

            DatabaseTypeEnum dbType = (DatabaseTypeEnum)Enum.Parse(typeof(DatabaseTypeEnum), DatabaseType, true);
            if(dbType == DatabaseTypeEnum.AzureSqlDatabase) 
            {
                newModel.MemberDatabaseName = this.MemberDatabaseName;
                newModel.MemberServerName = this.MemberServerName;
                newModel.UserName = this.Credential.UserName;
                newModel.Password = this.Credential.Password;
                newModel.DatabaseType = DatabaseTypeEnum.AzureSqlDatabase.ToString();
            } 
            else
            {
                this.syncAgentId = string.Format("resourceGroups/{0}/providers/Microsoft.Sql/servers/{1}/syncAgents/{2}", this.SyncAgentResourceGroupName, this.SyncAgentServerName, this.SyncAgentName);
                newModel.SyncAgentId = this.syncAgentId;
                newModel.SqlServerDatabaseId = this.SqlServerDatabaseId;
                newModel.DatabaseType = DatabaseTypeEnum.SqlServerDatabase.ToString();
            }
            newEntity.Add(newModel);
            return newEntity;
        }

        /// <summary>
        /// Create the new sync member
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncMemberModel> PersistChanges(IEnumerable<AzureSqlSyncMemberModel> entity)
        {
            return new List<AzureSqlSyncMemberModel>() {
                ModelAdapter.CreateSyncMember(entity.First(), this.syncAgentId)
            };
        }
    }
}
