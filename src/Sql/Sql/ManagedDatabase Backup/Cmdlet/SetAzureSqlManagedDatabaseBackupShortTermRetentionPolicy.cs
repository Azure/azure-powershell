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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Cmdlet;
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Model;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    /// <summary>
    /// Cmdlet to create or update a new Azure Sql Database backup archival policy
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseBackupShortTermRetentionPolicy",
        SupportsShouldProcess = true,
        DefaultParameterSetName = PolicyByResourceServerDatabaseSet),
        OutputType(typeof(AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel))]
    public class SetAzureSqlManagedDatabaseBackupShortTermRetentionPolicy : AzureSqlManagedDatabaseBackupCmdletBase<AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel>
    {
        private bool _operationCancelled;

        /// <summary>
        /// Gets or sets the Database object to get the policy for.
        /// </summary>
        [Parameter(
            ParameterSetName = PolicyByInputObjectSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The live or deleted database object to get/set the policy for.")]
        [ValidateNotNullOrEmpty]
        [Alias("AzureSqlInstanceDatabase", "AzureInstanceDatabaseObject")]
        public override AzureSqlManagedDatabaseBaseModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the Database object to get the policy for.
        /// </summary>
        [Parameter(
            ParameterSetName = PolicyByResourceIdSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The short term retention policy resource Id.")]
        [ValidateNotNullOrEmpty]
        public override string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(
            ParameterSetName = PolicyByResourceServerDatabaseSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(ParameterSetName = PolicyByResourceServerDatabaseSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Managed Instance the database is in.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(ParameterSetName = PolicyByResourceServerDatabaseSet,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Instance Database to retrieve backups for.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/databases", "ResourceGroupName", "InstanceName")]
        [ValidateNotNullOrEmpty]
        public override string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the deletion date of the database to use.
        /// </summary>
        [Parameter(ParameterSetName = PolicyByResourceServerDatabaseSet,
            Mandatory = false,
            HelpMessage = "The deletion date of the Azure SQL Instance Database to retrieve backups for, with millisecond precision (e.g. 2016-02-23T00:21:22.847Z)")]
        [ValidateNotNullOrEmpty]
        public override DateTime? DeletionDate { get; set; }
        
        /// <summary>
        /// Gets or sets the Week of Year for the Yearly Retention.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 3,
            HelpMessage = "Days of backup retention.")]
        [ValidateNotNullOrEmpty]
        public int RetentionDays { get; set; }

        /// <summary>
        /// Gets or sets whether to lock backup immutability.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Whether to lock the immutability of backups governed by this policy. This parameter is supported only for live managed databases.")]
        public bool? LockImmutability { get; set; }

        /// <summary>
        /// Gets or sets whether to skip confirmation when locking backup immutability.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Skip confirmation when locking backup immutability.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel GetEntity()
        {
            if (this.DeletionDate.HasValue && this.IsParameterBound(c => c.LockImmutability))
            {
                throw new PSArgumentException(
                    "LockImmutability is not supported for restorable dropped managed databases.",
                    nameof(LockImmutability));
            }

            if (this.DeletionDate.HasValue)
            {
                return ModelAdapter.ManagedBackupShortTermRetentionPoliciesDropped(
                this.ResourceGroupName,
                this.InstanceName,
                this.DatabaseName,
                this.DeletionDate.Value);
            }
            else
            {
                return ModelAdapter.ManagedBackupShortTermRetentionPolicies(
                this.ResourceGroupName,
                this.InstanceName,
                this.DatabaseName);
            }
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel ApplyUserInputToModel(AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel model)
        {
            _operationCancelled = false;
            model.RetentionDays = RetentionDays;
            model.LockImmutability = this.IsParameterBound(c => c.LockImmutability) ? LockImmutability : null;
            return model;
        }

        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel PersistChanges(AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel entity)
        {
            if (LockImmutability == true && !Force.IsPresent && !ShouldContinue(
                "Locking backup immutability cannot be reverted.",
                "Confirm locking backup immutability"))
            {
                _operationCancelled = true;
                return null;
            }

            if (this.DeletionDate.HasValue)
            {
                return ModelAdapter.UpsertDeletedManagedDatabaseRetentionPolicy(this.ResourceGroupName, this.InstanceName, this.DatabaseName + "," + this.DeletionDate.Value.ToFileTimeUtc(), entity);
            }

            return ModelAdapter.UpsertManagedDatabaseRetentionPolicy(this.ResourceGroupName, this.InstanceName, this.DatabaseName, entity);
        }

        /// <summary>
        /// Returns whether the updated policy should be written to the pipeline.
        /// </summary>
        protected override bool WriteResult()
        {
            return base.WriteResult() && !_operationCancelled;
        }
    }
}
