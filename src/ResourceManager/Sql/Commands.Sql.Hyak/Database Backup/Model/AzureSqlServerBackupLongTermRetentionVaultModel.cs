using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.Backup.Model
{
    public class AzureSqlServerBackupLongTermRetentionVaultModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the backup archival vault resource ID
        /// </summary>
        public string RecoveryServicesVaultResourceId { get; set; }

        /// <summary>
        /// Gets or sets the location
        /// </summary>
        public string Location { get; set; }
    }
}
