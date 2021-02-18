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
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Model;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Cmdlet
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseLongTermRetentionBackup", DefaultParameterSetName = RemoveBackupDefaultSet, SupportsShouldProcess = true), OutputType(typeof(AzureSqlManagedDatabaseLongTermRetentionBackupModel))]
    public class RemoveAzureSqlManagedDatabaseLongTermRetentionBackup : AzureSqlManagedDatabaseLongTermRetentionBackupCmdletBase
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
        /// Gets or sets the name of the location the backup is in.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveBackupDefaultSet,
            Position = 0,
            HelpMessage = "The location of the backups' source Managed Instance.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Sql/locations/longTermRetentionManagedInstances")]
        public virtual string Location { get; set; }

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveBackupDefaultSet,
            Position = 1,
            HelpMessage = "The name of the Managed Instance the backup is under.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveBackupDefaultSet,
            Position = 2,
            HelpMessage = "The name of the Managed Database the backup is from.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/databases", "ResourceGroupName", "ManagedInstanceName")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the LTR Backup object to remove.
        /// </summary>
        [Parameter(ParameterSetName = RemoveBackupByInputObjectSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The Database Long Term Retention Backup object to remove.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedDatabaseLongTermRetentionBackupModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the LTR Backup to remove.
        /// </summary>
        [Parameter(ParameterSetName = RemoveBackupByResourceIdSet,
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
            ParameterSetName = RemoveBackupDefaultSet,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The name of the backup.")]
        [ValidateNotNullOrEmpty]
        public string BackupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = RemoveBackupDefaultSet,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        protected override bool WriteResult() { return PassThru; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> GetEntity()
        {
            return ModelAdapter.GetManagedDatabaseLongTermRetentionBackups(
                Location,
                InstanceName,
                DatabaseName,
                BackupName,
                ResourceGroupName,
                null,
                null);
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
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> PersistChanges(
            IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> entity)
        {
            ModelAdapter.RemoveManagedDatabaseLongTermRetentionBackup(Location, InstanceName, DatabaseName, BackupName, ResourceGroupName);
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                Location = InputObject.Location;
                InstanceName = InputObject.ManagedInstanceName;
                DatabaseName = InputObject.DatabaseName;
                BackupName = InputObject.BackupName;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (!string.IsNullOrWhiteSpace(ResourceId))
            {
                ParseLongTermRentionBackupResourceId(ResourceId);
            }

            if (ShouldProcess(this.BackupName))
            {
                if (Force.IsPresent || ShouldContinue(
                    string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceDatabaseLongTermRetentionBackupDescription, this.BackupName, this.DatabaseName, this.InstanceName, this.Location),
                    string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceDatabaseLongTermRetentionBackupWarning, this.BackupName, this.DatabaseName, this.InstanceName, this.Location)))
                {
                    base.ExecuteCmdlet();
                }
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
                InstanceName = tokens[7 + offset];
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
