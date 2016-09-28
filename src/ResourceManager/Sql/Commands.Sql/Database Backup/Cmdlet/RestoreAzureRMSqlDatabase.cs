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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Backup.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    [Cmdlet(VerbsData.Restore, "AzureRmSqlDatabase",
        ConfirmImpact = ConfirmImpact.None)]
    public class RestoreAzureRmSqlDatabase
        : AzureSqlCmdletBase<Database.Model.AzureSqlDatabaseModel, AzureSqlDatabaseBackupAdapter>
    {

        private const string FromPointInTimeBackupSetName = "FromPointInTimeBackup";
        private const string FromDeletedDatabaseBackupSetName = "FromDeletedDatabaseBackup";
        private const string FromGeoBackupSetName = "FromGeoBackup";
        private const string FromLongTermRetentionBackupSetName = "FromLongTermRetentionBackup";

        /// <summary>
        /// Gets or sets flag indicating a restore from a point-in-time backup.
        /// </summary>
        [Parameter(
            ParameterSetName = FromPointInTimeBackupSetName,
            Mandatory = true,
            HelpMessage = "Restore from a point-in-time backup.")]
        public SwitchParameter FromPointInTimeBackup { get; set; }

        /// <summary>
        /// Gets or sets flag indicating a restore of a deleted database.
        /// </summary>
        [Parameter(
            ParameterSetName = FromDeletedDatabaseBackupSetName,
            Mandatory = true,
            HelpMessage = "Restore a deleted database.")]
        public SwitchParameter FromDeletedDatabaseBackup { get; set; }

        /// <summary>
        /// Gets or sets flag indicating a geo-restore (recover) request
        /// </summary>
        [Parameter(
            ParameterSetName = FromGeoBackupSetName,
            Mandatory = true,
            HelpMessage = "Restore from a geo backup.")]
        public SwitchParameter FromGeoBackup { get; set; }

        /// <summary>
        /// Gets or sets flag indicating a restore from a long term retention backup
        /// </summary>
        [Parameter(
            ParameterSetName = FromLongTermRetentionBackupSetName,
            Mandatory = true,
            HelpMessage = "Restore from a long term retention backup backup.")]
        public SwitchParameter FromLongTermRetentionBackup { get; set; }

        /// <summary>
        /// Gets or sets the point in time to restore the database to
        /// </summary>
        [Parameter(
            ParameterSetName = FromPointInTimeBackupSetName,
            Mandatory = true,
            HelpMessage = "The point in time to restore the database to.")]
        [Parameter(
            ParameterSetName = FromDeletedDatabaseBackupSetName,
            Mandatory = false,
            HelpMessage = "The point in time to restore the database to.")]
        public DateTime PointInTime { get; set; }

        /// <summary>
        /// Gets or sets the deletion DateTime of the deleted database to restore.
        /// </summary>
        [Parameter(
            ParameterSetName = FromDeletedDatabaseBackupSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The deletion DateTime of the deleted database to restore.")]
        public DateTime DeletionDate { get; set; }

        /// <summary> 
        /// The resource ID of the database to restore (deleted DB, geo backup DB, live DB, long term retention backup, etc.)
        /// </summary>
        [Alias("Id")]
        [Parameter(Mandatory = true,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The resource ID of the database to restore.")]
        public string ResourceId { get; set; }

        /// <summary> 
        /// Gets or sets the name of the database server to use. 
        /// </summary> 
        [Parameter(Mandatory = true, 
            ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The name of the Azure SQL Server to restore the database to.")] 
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the target database to restore to
        /// </summary>
        [Parameter(Mandatory = true,
                    HelpMessage = "The name of the target database to restore to.")]
        public string TargetDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the target edition of the database to restore
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The database edition to use for the restored database.")]
        public DatabaseEdition Edition { get; set; }

        /// <summary>
        /// Gets or sets the SLO of the database to restore
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The service level objective to use for the restored database.")]
        public string ServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the target elastic pool name
        /// </summary>
        [Parameter(Mandatory = false,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The name of the elastic pool into which the database should be restored.")]
        public string ElasticPoolName { get; set; }
        
        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <param name="subscription">The subscription ID to operate on</param>
        /// <returns></returns>
        protected override AzureSqlDatabaseBackupAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new AzureSqlDatabaseBackupAdapter(DefaultProfile.Context);
        }

        /// <summary>
        /// Send the restore request
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override AzureSqlDatabaseModel GetEntity()
        {
            AzureSqlDatabaseModel model;
            DateTime restorePointInTime = DateTime.MinValue;
            string createMode;
            string location = ModelAdapter.GetServerLocation(ResourceGroupName, ServerName);
            switch (ParameterSetName)
            {
                case FromPointInTimeBackupSetName:
                    createMode = "PointInTimeRestore";
                    restorePointInTime = PointInTime;
                    break;
                case FromDeletedDatabaseBackupSetName:
                    createMode = "Restore";
                    restorePointInTime = PointInTime == DateTime.MinValue ? DeletionDate : PointInTime;
                    break;
                case FromGeoBackupSetName:
                    createMode = "Recovery";
                    break;
                case FromLongTermRetentionBackupSetName:
                    createMode = "RestoreLongTermRetentionBackup";
                    break;
                default:
                    throw new ArgumentException("No ParameterSet name");
            }

            model = new AzureSqlDatabaseModel()
            {
                Location = location,
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                DatabaseName = TargetDatabaseName,
                Edition = Edition,
                RequestedServiceObjectiveName = ServiceObjectiveName,
                ElasticPoolName = ElasticPoolName,
                CreateMode = createMode
            };

            return ModelAdapter.RestoreDatabase(this.ResourceGroupName, restorePointInTime, ResourceId, model);
        }
    }
}
