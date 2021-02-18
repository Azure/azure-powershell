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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Model;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Cmdlet
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseLongTermRetentionBackup", DefaultParameterSetName = LocationSet, SupportsShouldProcess = true), OutputType(typeof(AzureSqlManagedDatabaseLongTermRetentionBackupModel))]
    public class GetAzureSqlManagedDatabaseLongTermRetentionBackup : AzureSqlManagedDatabaseLongTermRetentionBackupCmdletBase
    {
        /// <summary>
        /// Parameter set name for backup name.
        /// </summary>
        private const string BackupNameSet = "BackupName";

        /// <summary>
        /// Parameter set name for instance name.
        /// </summary>
        private const string InstanceNameSet = "InstanceName";

        /// <summary>
        /// Parameter set for database name.
        /// </summary>
        private const string DatabaseNameSet = "DatabaseName";

        /// <summary>
        /// Parameter set name for location name.
        /// </summary>
        private const string LocationSet = "Location";

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
        /// The location the backups are in.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = LocationSet,
            Position = 0,
            HelpMessage = "The location of the backups' source Managed Instance.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InstanceNameSet,
            Position = 0,
            HelpMessage = "The backups' source Managed Instance.")]
        [Parameter(Mandatory = true,
            ParameterSetName = DatabaseNameSet,
            Position = 0,
            HelpMessage = "The backups' source Managed Database.")]
        [Parameter(Mandatory = true,
            ParameterSetName = BackupNameSet,
            Position = 0,
            HelpMessage = "The backups' source Managed Instance.")]
        [Parameter(Mandatory = true,
            ParameterSetName = GetBackupByResourceIdSet,
            Position = 1,
            HelpMessage = "The location of the backup's source Managed Instance.")]
        [LocationCompleter("Microsoft.Sql/locations/longTermRetentionManagedInstances/longTermRetentionDatabases/longTermRetentionManagedInstanceBackups")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Database object to get backups for.
        /// </summary>
        [Parameter(ParameterSetName = GetBackupByInputObjectSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The database object to get backups for.")]
        [Parameter(ParameterSetName = GetBackupsByInputObjectSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The database object to get backups for.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedDatabaseModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the Database Resource ID to get backups for.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = GetBackupByResourceIdSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The database Resource ID to get backups for.")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = InstanceNameSet,
            Position = 1,
            HelpMessage = "The name of the Managed Instance the backups are under.")]
        [Parameter(Mandatory = true,
            ParameterSetName = DatabaseNameSet,
            Position = 1,
            HelpMessage = "The name of the Managed Database the backups are under.")]
        [Parameter(Mandatory = true,
            ParameterSetName = BackupNameSet,
            Position = 1,
            HelpMessage = "The name of the Managed Instance the backups are under.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = DatabaseNameSet,
            Position = 2,
            HelpMessage = "The name of the Managed Database the backups are under.")]
        [Parameter(Mandatory = true,
            ParameterSetName = BackupNameSet,
            Position = 2,
            HelpMessage = "The name of the Managed Instance the backup is from.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/databases", "ResourceGroupName", "ManagedInstanceName")]
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
            Position = 2,
            HelpMessage = "The name of the backup.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string BackupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = LocationSet,
            HelpMessage = "The name of the resource group.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InstanceNameSet,
            HelpMessage = "The name of the resource group.")]
        [Parameter(Mandatory = false,
            ParameterSetName = DatabaseNameSet,
            HelpMessage = "The name of the resource group.")]
        [Parameter(Mandatory = false,
            ParameterSetName = BackupNameSet,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets whether or not to only get the latest backup per database.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = InstanceNameSet,
            HelpMessage = "Whether or not to only get the latest backup per database. Defaults to false.")]
        [Parameter(Mandatory = false,
            ParameterSetName = LocationSet,
            HelpMessage = "Whether or not to only get the latest backup per database. Defaults to false.")]
        [Parameter(Mandatory = false,
            ParameterSetName = DatabaseNameSet,
            HelpMessage = "Whether or not to only get the latest backup per database. Defaults to false.")]
        [Parameter(Mandatory = false,
            ParameterSetName = GetBackupsByInputObjectSet,
            HelpMessage = "Whether or not to only get the latest backup per database. Defaults to false.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter OnlyLatestPerDatabase { get; set; }

        /// <summary>
        /// Gets or sets the database state to look for (Alive or Deleted).
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = InstanceNameSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The state of the database whose backups you want to find, Alive, Deleted, or All. Defaults to All")]
        [Parameter(Mandatory = false,
            ParameterSetName = LocationSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The state of the database whose backups you want to find, Alive, Deleted, or All. Defaults to All")]
        [Parameter(Mandatory = false,
            ParameterSetName = GetBackupsByInputObjectSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The state of the database whose backups you want to find, Alive, Deleted, or All. Defaults to All")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("All", "Deleted", "Live",
            IgnoreCase = true)]
        public string DatabaseState { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> GetEntity()
        {
            if (InputObject != null)
            {
                Location = InputObject.Location;
                InstanceName = InputObject.ManagedInstanceName;
                DatabaseName = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (!string.IsNullOrWhiteSpace(ResourceId))
            {
                ResourceIdentifier identifier = new ResourceIdentifier(ResourceId);
                DatabaseName = identifier.ResourceName;
                ResourceGroupName = identifier.ResourceGroupName;
                InstanceName = identifier.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            return SubResourceWildcardFilter(BackupName, ModelAdapter.GetManagedDatabaseLongTermRetentionBackups(
                    Location,
                    InstanceName,
                    DatabaseName,
                    BackupName,
                    ResourceGroupName,
                    OnlyLatestPerDatabase.IsPresent,
                    DatabaseState));
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> ApplyUserInputToModel(
            IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to managed instance
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> PersistChanges(
            IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> entity)
        {
            return entity;
        }
    }
}
