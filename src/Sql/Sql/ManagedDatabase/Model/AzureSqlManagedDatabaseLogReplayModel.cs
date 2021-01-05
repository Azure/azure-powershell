using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Model
{
    class AzureSqlManagedDatabaseLogReplayModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed instance
        /// </summary>
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the managed database
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed database
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets last availabe backup of the managed database
        /// </summary>
        public string LastBackupName { get; set; }

        /// <summary>
        /// Construct AzureSqlManagedDatabaseLogReplayModel
        /// </summary>
        public AzureSqlManagedDatabaseLogReplayModel()
        {
        }

        /// <summary>
        /// Construct AzureSqlManagedDatabaseLogReplayModel object
        /// </summary>
        /// <param name="resourceGroup">Resource group</param>
        /// <param name="managedInstanceName">Managed Instance name</param>
        /// <param name="database">Recoverable Managed Database object</param>
        public AzureSqlManagedDatabaseLogReplayModel(string resourceGroup, string managedInstanceName, Management.Sql.Models.RecoverableManagedDatabase database)
        {
            ResourceGroupName = resourceGroup;
            ManagedInstanceName = managedInstanceName;
            Id = database.Id;
            RecoverableDatabaseId = database.Id;
            Name = database.Name;
            LastAvailableBackupDate = database.LastAvailableBackupDate;
        }
    }
}
