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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Backup.Model;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.Database_Backup.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlDatabaseLongTermRetentionBackup", DefaultParameterSetName = LocationNameSet, SupportsShouldProcess = true)]
    public class GetAzureRmSqlDatabaseLongTermRetentionBackup : AzureSqlDatabaseLongTermRetentionBackupCmdletBase
    {
        /// <summary>
        /// Parameter set name for backup name.
        /// </summary>
        private const string BackupNameSet = "BackupName";

        /// <summary>
        /// Parameter set name for database name.
        /// </summary>
        private const string DatabaseNameSet = "DatabaseName";

        /// <summary>
        /// Parameter set name for server name.
        /// </summary>
        private const string ServerNameSet = "ServerName";

        /// <summary>
        /// Parameter set name for location name.
        /// </summary>
        private const string LocationNameSet = "LocationName";

        /// <summary>
        /// Parameter set for using a Database Input Object when getting a single backup.
        /// </summary>
        private const string GetBackupByInputObjectSet = "GetBackupByInputObject";

        /// <summary>
        /// Parameter set for using a Database Input Object when getting multiple backups.
        /// </summary>
        private const string GetBackupsByInputObjectSet = "GetBackupsByInputObject";

        /// <summary>
        /// Parameter set for using a Database Resource ID when getting a single backup.
        /// </summary>
        private const string GetBackupByResourceIdSet = "GetBackupByResourceId";

        /// <summary>
        /// Parameter set for using a Database Resource ID when getting multiple backups.
        /// </summary>
        private const string GetBackupsByResourceIdSet = "GetBackupsByResourceId";

        /// <summary>
        /// The index of ServerName in the LTR Backup Resource ID.
        /// </summary>
        private const int ServerNameIndex = 7;

        /// <summary>
        /// The index of DatabaseName in the LTR Backup Resource ID.
        /// </summary>
        private const int DatabaseNameIndex = 9;

        /// <summary>
        /// The location the backups are in.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = LocationNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The location the backups are in.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ServerNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The location the backups are in.")]
        [Parameter(Mandatory = true,
            ParameterSetName = DatabaseNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The location the backups are in.")]
        [Parameter(Mandatory = true,
            ParameterSetName = BackupNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The location the backups are in.")]
        [Parameter(Mandatory = true,
            ParameterSetName = GetBackupByResourceIdSet,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The location the backups are in.")]
        [Parameter(Mandatory = true,
            ParameterSetName = GetBackupsByResourceIdSet,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The location the backups are in.")]
        [LocationCompleter("Microsoft.Sql/locations/longTermRetentionServers/longTermRetentionDatabases/longTermRetentonBackups")]
        public string LocationName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ServerNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server the backups are under.")]
        [Parameter(Mandatory = true,
            ParameterSetName = DatabaseNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server the backups are under.")]
        [Parameter(Mandatory = true,
            ParameterSetName = BackupNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server the backups are under.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = DatabaseNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database the backup is from.")]
        [Parameter(Mandatory = true,
            ParameterSetName = BackupNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database the backup is from.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the backup name.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = BackupNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The name of the backup.")]
        [Parameter(Mandatory = true,
            ParameterSetName = GetBackupByInputObjectSet,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the backup.")]
        [Parameter(Mandatory = true,
            ParameterSetName = GetBackupByResourceIdSet,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the backup.")]
        [ValidateNotNullOrEmpty]
        public string BackupName { get; set; }

        /// <summary>
        /// Gets or sets whether or not to only get the latest backup per database.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ServerNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Whether or not to only get the latest backup per database. Defaults to false.")]
        [Parameter(Mandatory = false,
            ParameterSetName = DatabaseNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Whether or not to only get the latest backup per database. Defaults to false.")]
        [Parameter(Mandatory = false,
            ParameterSetName = LocationNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Whether or not to only get the latest backup per database. Defaults to false.")]
        [Parameter(Mandatory = false,
            ParameterSetName = GetBackupsByInputObjectSet,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Whether or not to only get the latest backup per database. Defaults to false.")]
        [Parameter(Mandatory = false,
            ParameterSetName = GetBackupsByResourceIdSet,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Whether or not to only get the latest backup per database. Defaults to false.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter OnlyLatestPerDatabase { get; set; }

        /// <summary>
        /// Gets or sets the database state to look for (Alive or Deleted).
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ServerNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            HelpMessage = "The state of the database whose backups you want to find, Alive, Deleted, or All. Defaults to All")]
        [Parameter(Mandatory = false,
            ParameterSetName = DatabaseNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            HelpMessage = "The state of the database whose backups you want to find, Alive, Deleted, or All. Defaults to All")]
        [Parameter(Mandatory = false,
            ParameterSetName = LocationNameSet,
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            HelpMessage = "The state of the database whose backups you want to find, Alive, Deleted, or All. Defaults to All")]
        [Parameter(Mandatory = false,
            ParameterSetName = GetBackupsByInputObjectSet,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The state of the database whose backups you want to find, Alive, Deleted, or All. Defaults to All")]
        [Parameter(Mandatory = false,
            ParameterSetName = GetBackupsByResourceIdSet,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The state of the database whose backups you want to find, Alive, Deleted, or All. Defaults to All")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(new[] { Management.Sql.Models.DatabaseState.All, Management.Sql.Models.DatabaseState.Deleted, Management.Sql.Models.DatabaseState.Live },
            IgnoreCase = true)]
        public string DatabaseState { get; set; }

        /// <summary>
        /// Gets or sets the Database object to get backups for.
        /// </summary>
        [Parameter(ParameterSetName = GetBackupByInputObjectSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The Database object to get backups for.")]
        [Parameter(ParameterSetName = GetBackupsByInputObjectSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The Database object to get backups for.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlDatabaseModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the Database Resource ID to get backups for.
        /// </summary>
        [Parameter(ParameterSetName = GetBackupByResourceIdSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The Database Resource ID to get backups for.")]
        [Parameter(ParameterSetName = GetBackupsByResourceIdSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The Database Resource ID to get backups for.")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseLongTermRetentionBackupModel> GetEntity()
        {
            if (InputObject != null)
            {
                LocationName = InputObject.Location;
                ServerName = InputObject.ServerName;
                DatabaseName = InputObject.DatabaseName;
            }
            else if (!string.IsNullOrWhiteSpace(ResourceId))
            {
                string[] tokens = ResourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                ServerName = tokens[ServerNameIndex];
                DatabaseName = tokens[DatabaseNameIndex];
            }

            return ModelAdapter.GetDatabaseLongTermRetentionBackups(
                    LocationName,
                    ServerName,
                    DatabaseName,
                    BackupName,
                    OnlyLatestPerDatabase.IsPresent,
                    DatabaseState);
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
            return entity;
        }
    }
}
