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

namespace Microsoft.Azure.Commands.Sql.Database_Backup.Cmdlet
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlDatabaseLongTermRetentionBackup", DefaultParameterSetName = RemoveBackupDefaultSet, SupportsShouldProcess = true)]
    public class RemoveAzureRmSqlDatabaseLongTermRetentionBackup : AzureSqlDatabaseLongTermRetentionBackupCmdletBase
    {
        /// <summary>
        /// Parameter set name for the default remove.
        /// </summary>
        private const string RemoveBackupDefaultSet = "RemoveBackupDefault";

        /// <summary>
        /// Parameter set name for remove with an input object.
        /// </summary>
        private const string RemoveBackupByInputObjectSet = "RemoveBackupByInputObject";

        /// <summary>
        /// Parameter set name for remove with a resource ID.
        /// </summary>
        private const string RemoveBackupByResourceIdSet = "RemoveBackupByResourceId";

        /// <summary>
        /// The index of LocationName in the LTR Backup Resource ID.
        /// </summary>
        private const int LocationNameIndex = 5;

        /// <summary>
        /// The index of ServerName in the LTR Backup Resource ID.
        /// </summary>
        private const int ServerNameIndex = 7;

        /// <summary>
        /// The index of DatabaseName in the LTR Backup Resource ID.
        /// </summary>
        private const int DatabaseNameIndex = 9;

        /// <summary>
        /// The index of BackupName in the LTR Backup Resource ID.
        /// </summary>
        private const int BackupNameIndex = 11;

        /// <summary>
        /// Gets or sets the name of the location the backup is in.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveBackupDefaultSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the Azure SQL Server the database is in.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Sql/locations/longTermRetentionServers")]
        public virtual string LocationName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveBackupDefaultSet,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server the backup is under.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveBackupDefaultSet,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database the backup is from.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the backup name.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveBackupDefaultSet,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The name of the backup.")]
        [ValidateNotNullOrEmpty]
        public string BackupName { get; set; }

        /// <summary>
        /// Gets or sets the LTR Backup object to remove.
        /// </summary>
        [Parameter(ParameterSetName = RemoveBackupByInputObjectSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The Database Long Term Retention Backup object to remove.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlDatabaseLongTermRetentionBackupModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the LTR Backup to remove.
        /// </summary>
        [Parameter(ParameterSetName = RemoveBackupByResourceIdSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The Resource ID of the Database Long Term Retention Backup to remove.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

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
                LocationName,
                ServerName,
                DatabaseName,
                BackupName,
                null,
                null);
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseLongTermRetentionBackupModel> ApplyUserInputToModel(
            IEnumerable<AzureSqlDatabaseLongTermRetentionBackupModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseLongTermRetentionBackupModel> PersistChanges(
            IEnumerable<AzureSqlDatabaseLongTermRetentionBackupModel> entity)
        {
            ModelAdapter.RemoveDatabaseLongTermRetentionBackup(LocationName, ServerName, DatabaseName, BackupName);
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                LocationName = InputObject.LocationName;
                ServerName = InputObject.ServerName;
                DatabaseName = InputObject.DatabaseName;
                BackupName = InputObject.BackupName;
            }
            else if (!string.IsNullOrWhiteSpace(ResourceId))
            {
                string[] tokens = ResourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                LocationName = tokens[LocationNameIndex];
                ServerName = tokens[ServerNameIndex];
                DatabaseName = tokens[DatabaseNameIndex];
                BackupName = tokens[BackupNameIndex];
            }

            if (!Force.IsPresent && !ShouldProcess(
                   string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlDatabaseLongTermRetentionBackupDescription, this.BackupName, this.DatabaseName, this.ServerName, this.LocationName),
                   string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlDatabaseLongTermRetentionBackupWarning, this.BackupName, this.DatabaseName, this.ServerName, this.LocationName),
                   Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ExecuteCmdlet();
        }
    }
}
