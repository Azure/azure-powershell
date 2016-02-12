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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Backup.Model;
using Microsoft.Azure.Commands.Sql.Backup.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    [Cmdlet(VerbsData.Restore, "AzureRmSqlDatabase",
        ConfirmImpact = ConfirmImpact.None)]
    public class RestoreAzureRmSqlDatabase
        : AzureSqlCmdletBase<Database.Model.AzureSqlDatabaseModel, AzureSqlDatabaseBackupAdapter>
    {
        /// <summary>
        /// Gets or sets flag indicating a restore from a point-in-time backup.
        /// </summary>
        [Parameter(
            ParameterSetName = "FromPointInTimeBackup",
            Mandatory = true,
            HelpMessage = "Restore from a point-in-time backup.")]
        public bool FromPointInTimeBackup { get; set; }

        /// <summary>
        /// Gets or sets the point in time to restore the database to
        /// </summary>
        [Parameter(
            ParameterSetName = "FromPointInTimeBackup",
            Mandatory = true,
            HelpMessage = "The point in time to restore the database to.")]
        public DateTime PointInTime { get; set; }

        /// <summary>
        /// Gets or sets flag indicating a restore of a dropped database.
        /// </summary>
        [Parameter(
            ParameterSetName = "FromDeletedDatabaseBackup",
            Mandatory = true,
            HelpMessage = "Restore a dropped database.")]
        public bool FromDeletedDatabaseBackup { get; set; }

        /// <summary>
        /// Gets or sets the deletion time of the dropped database to restore.
        /// </summary>
        [Parameter(
            ParameterSetName = "FromDeletedDatabaseBackup",
            Mandatory = true,
            HelpMessage = "The deletion time of the dropped database to restore.")]
        public DateTime DeletionDate { get; set; }

        /// <summary>
        /// Gets or sets flag indicating a geo-restore (recover) request
        /// </summary>
        [Parameter(
            ParameterSetName = "FromGeoBackup",
            Mandatory = true,
            HelpMessage = "Restore from a geo backup.")]
        public bool FromGeoBackup { get; set; }

        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Azure SQL Database Server the database is in.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Azure SQL Database to restore from.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the target edition of the database to restore
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The edition of the database to restore to.")]
        public DatabaseEdition Edition { get; set; }

        /// <summary>
        /// Gets or sets the SLO of the database to restore
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The service level objective of the database to restore to.")]
        public string ServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the target elastic pool name
        /// </summary>
        [Parameter(Mandatory = false,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The name of the elastic pool to restore to.")]
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the name of the target database to restore to
        /// </summary>
        [Parameter(Mandatory = true,
                    HelpMessage = "The name of the target database to restore to.")]
        public string TargetDatabaseName { get; set; }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        protected override AzureSqlDatabaseBackupAdapter InitModelAdapter(Azure.Common.Authentication.Models.AzureSubscription subscription)
        {
            return new AzureSqlDatabaseBackupAdapter(DefaultProfile.Context);
        }

        /// <summary>
        /// Send the restore request
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override AzureSqlDatabaseModel ExecuteCmdlet()
        {
            AzureSqlDatabaseModel model;
            DateTime restorePointInTime = PointInTime;
            string createMode;
            string location = ModelAdapter.GetServerLocation(ResourceGroupName, ServerName);
            switch (ParameterSetName)
            {
                case "FromPointInTimeBackup":
                    createMode = "PointInTimeRestore";
                    break;
                case "FromDeletedDatabaseBackup":
                    createMode = "Restore";
                    break;
                case "FromGeoBackup":
                    createMode = "Recovery";
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

            return ModelAdapter.RestoreDatabase(this.ResourceGroupName, this.ServerName, this.DatabaseName, restorePointInTime, model);
        }
    }
}
