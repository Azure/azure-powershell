using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Model
{
    public class AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets deletion Date
        /// </summary>
        public DateTime? DeletionDate { get; set; }

        /// <summary>
        /// Gets or sets the retention value
        /// </summary>
        public int RetentionDays { get; set; }

        /// <summary>
        /// Construct AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel object
        /// </summary>
        /// <param name="resourceGroup">Resource group</param>
        /// <param name="managedInstanceName">Managed Instance name</param>
        /// <param name="managedDatabaseName">Managed Instance name</param>
        /// <param name="managedBackupRetentionPolicy">Managed Database object</param>
        /// <param name="deletionDate">Deletion date of the database, if it is deleted</param>
        public AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel(string resourceGroup, string managedInstanceName, string managedDatabaseName, ManagedBackupShortTermRetentionPolicy managedBackupRetentionPolicy, DateTime? deletionDate = null)
        {
            ResourceGroupName = resourceGroup;
            InstanceName = managedInstanceName;
            DatabaseName = managedDatabaseName;
            DeletionDate = deletionDate;
            RetentionDays = managedBackupRetentionPolicy.RetentionDays.Value;
        }
    }
}
