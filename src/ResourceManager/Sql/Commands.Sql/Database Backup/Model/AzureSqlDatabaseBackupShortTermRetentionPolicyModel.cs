namespace Microsoft.Azure.Commands.Sql.Database_Backup.Model
{
    public class AzureSqlDatabaseBackupShortTermRetentionPolicyModel
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
        /// Gets or sets the name of the database
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the retention days of this policy.
        /// </summary>
        public int RetentionDays { get; set; }

        /// <summary>
        /// Construct AzureSqlDatabaseBackupShortTermRetentionPolicyModel from Management.Sql.BackupShortTermRetentionPolicy object
        /// </summary>
        /// <param name="resourceGroup"></param>
        /// <param name="serverName"></param>
        /// <param name="policy"></param>
        public AzureSqlDatabaseBackupShortTermRetentionPolicyModel(string resourceGroup, string serverName, string databaseName, Management.Sql.Models.BackupShortTermRetentionPolicy policy)
        {
            ResourceGroupName = resourceGroup;
            ServerName = serverName;
            DatabaseName = databaseName;
            RetentionDays = policy.RetentionDays.Value;
        }
    }
}