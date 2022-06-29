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

using System;
using System.Linq;
using System.Collections.Generic;
using System.Management.Automation;
using System.Globalization;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Backup.Model;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models;

namespace Microsoft.Azure.Commands.Sql.Database_Backup.Cmdlet
{
    [Cmdlet("Copy", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseLongTermRetentionBackup", DefaultParameterSetName = CopyBackupDefaultSet, SupportsShouldProcess = true), OutputType(typeof(AzureSqlDatabaseLongTermRetentionBackupModel))]
    public class CopyAzureSqlDatabaseLongTermRetentionBackup : AzureSqlDatabaseLongTermRetentionBackupCmdletBase<AzureSqlDatabaseLongTermRetentionBackupCopyModel>
    {
        /// <summary>
        /// Parameter set name for default copy 
        /// </summary>
        private const string CopyBackupDefaultSet = "CopyBackupDefault";

        /// <summary>
        /// Parameter set name for copy backup by resource ID 
        /// </summary>
        private const string CopyBackupByResourceIdSet = "CopyBackupByResourceId";

        /// <summary>
        /// Parameter set name for copy with an input object.
        /// </summary>
        private const string CopyBackupByInputObjectSet = "CopyBackupByInputObject";


        /// <summary>
        /// Gets or sets the name of the location the backup is in.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = CopyBackupDefaultSet,
            Position = 0,
            HelpMessage = "The location of the backups' source server.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Sql/locations/longTermRetentionServers")]
        public virtual string Location { get; set; }

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = CopyBackupDefaultSet,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server the backup is under.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = CopyBackupDefaultSet,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database the backup is from.")]
        [ResourceNameCompleter("Microsoft.Sql/servers/databases", "ResourceGroupName", "ServerName")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the backup name.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = CopyBackupDefaultSet,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The name of the backup.")]
        [ValidateNotNullOrEmpty]
        public string BackupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = CopyBackupDefaultSet,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the LTR Backup to update.
        /// </summary>
        [Parameter(ParameterSetName = CopyBackupByResourceIdSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Resource ID of the Database Long Term Retention Backup to remove.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the LTR Backup object to copy.
        /// </summary>
        [Parameter(ParameterSetName = CopyBackupByInputObjectSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The Database Long Term Retention Backup object to copy.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlDatabaseLongTermRetentionBackupModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the name of the target database.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the target database.")]
        [ValidateNotNullOrEmpty]
        public string TargetDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the fully qualified domain name of the target server.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The fully qualified domain name of the target server.")]
        public string TargetServerFullyQualifiedDomainName { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the target server (target subscription ID &amp; target resource group name can be derived).
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the target server.")]
        public string TargetServerName { get; set; }

        /// <summary>
        /// Gets or sets the target subscription ID.  
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The resource ID of the target subscription.")]
        public string TargetSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the target resource group name.  
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The resource ID of the target subscription.")]
        public string TargetResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseLongTermRetentionBackupCopyModel> GetEntity()
        {
            string targetServerResourceId = "";

            if (!String.IsNullOrEmpty(TargetServerName))
            {
                if (!String.IsNullOrEmpty(TargetServerFullyQualifiedDomainName))
                {
                    string[] tokens = TargetServerFullyQualifiedDomainName.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    string targetServerNameFromFQDN = tokens[0];

                    if (!TargetServerName.Equals(targetServerNameFromFQDN, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new Exception("TargetServerName and TargetServerFullyQualifiedDomainName specify different target servers.");
                    }
                }

                targetServerResourceId = ToServerResourceId(TargetSubscriptionId, TargetResourceGroupName, TargetServerName);
            }

            return new List<AzureSqlDatabaseLongTermRetentionBackupCopyModel>()
            {
                new AzureSqlDatabaseLongTermRetentionBackupCopyModel()
                {
                    SourceLocation = Location,
                    SourceResourceGroupName = ResourceGroupName,
                    SourceServerName = ServerName,
                    SourceDatabaseName = DatabaseName,
                    SourceBackupName = BackupName,
                    TargetServerFullyQualifiedDomainName = TargetServerFullyQualifiedDomainName,
                    TargetServerResourceId = targetServerResourceId,
                    TargetDatabaseName = TargetDatabaseName,
                    TargetSubscriptionId = TargetSubscriptionId,
                    TargetResourceGroupName = TargetResourceGroupName
                }
            };
        }

        /// <summary>
        /// User input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseLongTermRetentionBackupCopyModel> ApplyUserInputToModel(
            IEnumerable<AzureSqlDatabaseLongTermRetentionBackupCopyModel> model)
        {
            List<AzureSqlDatabaseLongTermRetentionBackupCopyModel> newEntity = new List<AzureSqlDatabaseLongTermRetentionBackupCopyModel>();
            newEntity.Add(model.First());

            return newEntity;
        }
        /// <summary>
        /// Persist changes to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseLongTermRetentionBackupCopyModel> PersistChanges(
            IEnumerable<AzureSqlDatabaseLongTermRetentionBackupCopyModel> entity)
        {
            if (ShouldProcess(DatabaseName))
            {
                return new List<AzureSqlDatabaseLongTermRetentionBackupCopyModel>()
                {
                    ModelAdapter.CopyDatabaseLongTermRetentionBackup(entity.First())
                };
            }
            return null;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                Location = InputObject.Location;
                ServerName = InputObject.ServerName;
                DatabaseName = InputObject.DatabaseName;
                BackupName = InputObject.BackupName;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (!string.IsNullOrWhiteSpace(ResourceId))
            {
                Dictionary<string, string> resourceIdSegments = ParseLongTermRetentionBackupResourceId(ResourceId);
                Location = resourceIdSegments["locations"];
                ServerName = resourceIdSegments["longTermRetentionServers"];
                DatabaseName = resourceIdSegments["longTermRetentionDatabases"];
                BackupName = resourceIdSegments["longTermRetentionBackups"];
                ResourceGroupName = resourceIdSegments.ContainsKey("resourceGroupname") ? resourceIdSegments["resourceGroups"] : null;
            }

            if (ShouldProcess(this.BackupName))
            {
                base.ExecuteCmdlet();
            }
        }

        /// <summary>
        /// Create a server resource ID from target subscription, resource group, and server
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="serverName"></param>
        /// <returns></returns>
        private string ToServerResourceId(string subscriptionId, string resourceGroupName, string serverName)
        {
            string resourceId = String.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}", subscriptionId, resourceGroupName, serverName);
            return resourceId;
        }
    }
}
