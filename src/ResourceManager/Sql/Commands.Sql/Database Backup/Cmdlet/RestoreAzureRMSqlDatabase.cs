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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Backup.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
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

        private const string FromPointInTimeBackupWithVcoreSetName = "FromPointInTimeBackupWithVcore";
        private const string FromDeletedDatabaseBackupWithVcoreSetName = "FromDeletedDatabaseBackupWithVcore";
        private const string FromGeoBackupWithVcoreSetName = "FromGeoBackupWithVcore";
        private const string FromLongTermRetentionBackupWithVcoreSetName = "FromLongTermRetentionBackupWithVcore";

        /// <summary>
        /// Gets or sets flag indicating a restore from a point-in-time backup.
        /// </summary>
        [Parameter(
            ParameterSetName = FromPointInTimeBackupSetName,
            Mandatory = true,
            HelpMessage = "Restore from a point-in-time backup.")]
        [Parameter(
            ParameterSetName = FromPointInTimeBackupWithVcoreSetName,
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
        [Parameter(
            ParameterSetName = FromDeletedDatabaseBackupWithVcoreSetName,
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
        [Parameter(
            ParameterSetName = FromGeoBackupWithVcoreSetName,
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
        [Parameter(
            ParameterSetName = FromLongTermRetentionBackupWithVcoreSetName,
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
            ParameterSetName = FromPointInTimeBackupWithVcoreSetName,
            Mandatory = true,
            HelpMessage = "The point in time to restore the database to.")]
        [Parameter(
            ParameterSetName = FromDeletedDatabaseBackupSetName,
            Mandatory = false,
            HelpMessage = "The point in time to restore the database to.")]
        [Parameter(
            ParameterSetName = FromDeletedDatabaseBackupWithVcoreSetName,
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
        [Parameter(
            ParameterSetName = FromDeletedDatabaseBackupWithVcoreSetName,
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
        [Parameter(ParameterSetName = FromPointInTimeBackupSetName, Mandatory = false,
            HelpMessage = "The database edition to use for the restored database.")]
        [Parameter(ParameterSetName = FromDeletedDatabaseBackupSetName, Mandatory = false,
            HelpMessage = "The database edition to use for the restored database.")]
        [Parameter(ParameterSetName = FromGeoBackupSetName, Mandatory = false,
            HelpMessage = "The database edition to use for the restored database.")]
        [Parameter(ParameterSetName = FromLongTermRetentionBackupSetName, Mandatory = false,
            HelpMessage = "The database edition to use for the restored database.")]
        [Parameter(ParameterSetName = FromPointInTimeBackupWithVcoreSetName, Mandatory = true,
            HelpMessage = "The database edition to use for the restored database.")]
        [Parameter(ParameterSetName = FromDeletedDatabaseBackupWithVcoreSetName, Mandatory = true,
            HelpMessage = "The database edition to use for the restored database.")]
        [Parameter(ParameterSetName = FromGeoBackupWithVcoreSetName, Mandatory = true,
            HelpMessage = "The database edition to use for the restored database.")]
        [Parameter(ParameterSetName = FromLongTermRetentionBackupWithVcoreSetName, Mandatory = true,
            HelpMessage = "The database edition to use for the restored database.")]
        [PSArgumentCompleter("None",
            Management.Sql.Models.DatabaseEdition.Basic,
            Management.Sql.Models.DatabaseEdition.Standard,
            Management.Sql.Models.DatabaseEdition.Premium,
            Management.Sql.Models.DatabaseEdition.DataWarehouse,
            Management.Sql.Models.DatabaseEdition.Free,
            Management.Sql.Models.DatabaseEdition.Stretch,
            "GeneralPurpose", "BusinessCritical")]
        public string Edition { get; set; }

        /// <summary>
        /// Gets or sets the SLO of the database to restore
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = FromPointInTimeBackupSetName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The service level objective to use for the restored database." +
            "Refer Get-AzureRmSqlCapability cmdlet to see what ServiceObjectiveNames are valid")]
        [Parameter(Mandatory = false,
            ParameterSetName = FromDeletedDatabaseBackupSetName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The service level objective to use for the restored database." +
            "Refer Get-AzureRmSqlCapability cmdlet to see what ServiceObjectiveNames are valid")]
        [Parameter(Mandatory = false,
            ParameterSetName = FromGeoBackupSetName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The service level objective to use for the restored database." +
            "Refer Get-AzureRmSqlCapability cmdlet to see what ServiceObjectiveNames are valid")]
        [Parameter(Mandatory = false,
            ParameterSetName = FromLongTermRetentionBackupSetName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The service level objective to use for the restored database." +
            "Refer Get-AzureRmSqlCapability cmdlet to see what ServiceObjectiveNames are valid")]
        public string ServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the target elastic pool name
        /// </summary>
        [Parameter(Mandatory = false,
                    ParameterSetName = FromPointInTimeBackupSetName,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The name of the elastic pool into which the database should be restored.")]
        [Parameter(Mandatory = false,
                    ParameterSetName = FromDeletedDatabaseBackupSetName,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The name of the elastic pool into which the database should be restored.")]
        [Parameter(Mandatory = false,
                    ParameterSetName = FromGeoBackupSetName,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The name of the elastic pool into which the database should be restored.")]
        [Parameter(Mandatory = false,
                    ParameterSetName = FromLongTermRetentionBackupSetName,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The name of the elastic pool into which the database should be restored.")]
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets or sets the compute generation of the database copy
        /// </summary>
        [Parameter(ParameterSetName = FromPointInTimeBackupWithVcoreSetName, Mandatory = true,
            HelpMessage = "The compute generation of the restored Azure Sql Database.")]
        [Parameter(ParameterSetName = FromDeletedDatabaseBackupWithVcoreSetName, Mandatory = true,
            HelpMessage = "The compute generation of the restored Azure Sql Database.")]
        [Parameter(ParameterSetName = FromGeoBackupWithVcoreSetName, Mandatory = true,
            HelpMessage = "The compute generation of the restored Azure Sql Database.")]
        [Parameter(ParameterSetName = FromLongTermRetentionBackupWithVcoreSetName, Mandatory = true,
            HelpMessage = "The compute generation of the restored Azure Sql Database.")]
        [Alias("Family")]
        [PSArgumentCompleter("Gen4", "Gen5")]
        [ValidateNotNullOrEmpty]
        public string ComputeGeneration { get; set; }

        /// <summary>
        /// Gets or sets the Vcore numbers of the database copy
        /// </summary>
        [Parameter(ParameterSetName = FromPointInTimeBackupWithVcoreSetName, Mandatory = true,
            HelpMessage = "The Vcore numbers of the restored Azure Sql Database.")]
        [Parameter(ParameterSetName = FromDeletedDatabaseBackupWithVcoreSetName, Mandatory = true,
            HelpMessage = "The Vcore numbers of the restored Azure Sql Database.")]
        [Parameter(ParameterSetName = FromGeoBackupWithVcoreSetName, Mandatory = true,
            HelpMessage = "The Vcore numbers of the restored Azure Sql Database.")]
        [Parameter(ParameterSetName = FromLongTermRetentionBackupWithVcoreSetName, Mandatory = true,
            HelpMessage = "The Vcore numbers of the restored Azure Sql Database.")]
        [Alias("Capacity")]
        [ValidateNotNullOrEmpty]
        public int VCore { get; set; }

        /// <summary>
        /// The start of the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <param name="subscription">The subscription ID to operate on</param>
        /// <returns></returns>
        protected override AzureSqlDatabaseBackupAdapter InitModelAdapter(IAzureSubscription subscription)
        {
            return new AzureSqlDatabaseBackupAdapter(DefaultProfile.DefaultContext);
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
                case FromPointInTimeBackupWithVcoreSetName:
                    createMode = "PointInTimeRestore";
                    restorePointInTime = PointInTime;
                    break;
                case FromDeletedDatabaseBackupSetName:
                case FromDeletedDatabaseBackupWithVcoreSetName:
                    createMode = "Restore";
                    restorePointInTime = PointInTime == DateTime.MinValue ? DeletionDate : PointInTime;
                    break;
                case FromGeoBackupSetName:
                case FromGeoBackupWithVcoreSetName:
                    createMode = "Recovery";
                    break;
                case FromLongTermRetentionBackupSetName:
                case FromLongTermRetentionBackupWithVcoreSetName:
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
                ElasticPoolName = ElasticPoolName,
                RequestedServiceObjectiveName = ServiceObjectiveName,
                Edition = Edition,
                CreateMode = createMode
            };

            if (ParameterSetName == FromPointInTimeBackupWithVcoreSetName || ParameterSetName == FromDeletedDatabaseBackupWithVcoreSetName ||
                ParameterSetName == FromGeoBackupWithVcoreSetName || ParameterSetName == FromLongTermRetentionBackupWithVcoreSetName)
            {
                string skuName = AzureSqlDatabaseAdapter.GetDatabaseSkuName(Edition);
                model.SkuName = skuName;
                model.Edition = Edition;
                model.Capacity = VCore;
                model.Family = ComputeGeneration;
            }
            else
            {
                model.SkuName = string.IsNullOrWhiteSpace(ServiceObjectiveName) ? AzureSqlDatabaseAdapter.GetDatabaseSkuName(Edition) : ServiceObjectiveName;
                model.Edition = Edition;
            }

            return ModelAdapter.RestoreDatabase(this.ResourceGroupName, restorePointInTime, ResourceId, model);
        }
    }
}
