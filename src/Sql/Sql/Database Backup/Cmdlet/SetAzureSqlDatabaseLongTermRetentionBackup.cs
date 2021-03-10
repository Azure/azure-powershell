﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Sql.Database_Backup.Cmdlet
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseLongTermRetentionBackup", DefaultParameterSetName = UpdateBackupDefaultSet, SupportsShouldProcess = true), OutputType(typeof(AzureSqlDatabaseLongTermRetentionBackupModel))]
    public class SetAzureSqlDatabaseLongTermRetentionBackup : AzureSqlDatabaseLongTermRetentionBackupCmdletBase<AzureSqlDatabaseLongTermRetentionBackupModel>
    {
        /// <summary>
        /// Parameter set name for remove with an input object.
        /// </summary>
        private const string UpdateBackupDefaultSet = "UpdateBackupDefault";

        /// <summary>
        /// Parameter set name for remove with a resource ID.
        /// </summary>
        private const string UpdateBackupByResourceIdSet = "UpdateBackupByResourceId";

        /// <summary>
        /// Gets or sets the name of the location the backup is in.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = UpdateBackupDefaultSet,
            Position = 0,
            HelpMessage = "The location of the backups' source server.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Sql/locations/longTermRetentionServers")]
        public virtual string Location { get; set; }

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = UpdateBackupDefaultSet,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server the backup is under.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = UpdateBackupDefaultSet,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database the backup is from.")]
        [ResourceNameCompleter("Microsoft.Sql/servers/databases", "ResourceGroupName", "ServerName")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the LTR Backup to update.
        /// </summary>
        [Parameter(ParameterSetName = UpdateBackupByResourceIdSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Resource ID of the Database Long Term Retention Backup to remove.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the backup name.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = UpdateBackupDefaultSet,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The name of the backup.")]
        [ValidateNotNullOrEmpty]
        public string BackupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = UpdateBackupDefaultSet,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the backup storage redundancy to assign to the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the service objective to assign to the Azure SQL Database.",
            ParameterSetName = UpdateBackupDefaultSet)]
        [ValidateNotNullOrEmpty]
        public string BackupStorageRedundancy { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseLongTermRetentionBackupModel> GetEntity()
        {
            return ModelAdapter.GetDatabaseLongTermRetentionBackups(
                Location,
                ServerName,
                DatabaseName,
                BackupName,
                ResourceGroupName,
                null,
                null);
        }

        /// <summary>
        /// User input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseLongTermRetentionBackupModel> ApplyUserInputToModel(
            IEnumerable<AzureSqlDatabaseLongTermRetentionBackupModel> model)
        {
            model.First().RequestedBackupStorageRedundancy = BackupStorageRedundancy;
            return model;
        }

        /// <summary>
        /// Persist changes to ser
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseLongTermRetentionBackupModel> PersistChanges(
            IEnumerable<AzureSqlDatabaseLongTermRetentionBackupModel> entity)
        {
            if (ShouldProcess(DatabaseName))
            {
                return new List<AzureSqlDatabaseLongTermRetentionBackupModel>()
                {
                    ModelAdapter.SetDatabaseLongTermRetentionBackup(entity.First())
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(ResourceId))
            {
                ParseLongTermRentionBackupResourceId(ResourceId);
            }

            if (ShouldProcess(this.BackupName))
            {
                base.ExecuteCmdlet();
            }
        }

        /// <summary>
        /// Parse the longTermRetentionBackup resource Id
        /// </summary>
        /// <param name="resourceId"></param>
        private void ParseLongTermRentionBackupResourceId(string resourceId)
        {
            int offset = 0;
            string[] tokens = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 14 || tokens.Length == 12)
            {
                if (tokens.Length == 14)
                {
                    ResourceGroupName = tokens[3];
                    offset = 2;
                }
                else
                {
                    ResourceGroupName = null;
                }

                Location = tokens[5 + offset];
                ServerName = tokens[7 + offset];
                DatabaseName = tokens[9 + offset];
                BackupName = tokens[11 + offset];
            }
            else
            {
                throw new ArgumentException("Invalid parameter", "ResourceId");

            }
        }
    }
}
