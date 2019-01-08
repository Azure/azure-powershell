using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.Backup.Model
{
    public class AzureSqlDatabaseLongTermRetentionBackupModel
    {
        /// <summary>
        /// Gets or sets the backup expiration time.
        /// </summary>
        public DateTime? BackupExpirationTime { get; set; }

        /// <summary>
        /// Gets or sets the backup name.
        /// </summary>
        public string BackupName { get; set; }

        /// <summary>
        /// Gets or sets the backup time.
        /// </summary>
        public DateTime? BackupTime { get; set; }

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the database deletion time.
        /// </summary>
        public DateTime? DatabaseDeletionTime { get; set; }

        /// <summary>
        /// Gets or sets the location name.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the resource ID.
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the server name.
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the server create time.
        /// </summary>
        public DateTime? ServerCreateTime { get; set; }
    }
}
