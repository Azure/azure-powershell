using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.Backup.Model
{
    public class AzureSqlDatabaseGeoBackupPolicyModel
    {
        public enum GeoBackupPolicyState
        {
            Disabled,
            Enabled
        };

        /// <summary>
        /// Gets or sets the location
        /// </summary>
        public string Location { get; set; }

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
        /// Gets or sets the geo backup policy state
        /// </summary>
        public GeoBackupPolicyState State { get; set; }
    }
}
