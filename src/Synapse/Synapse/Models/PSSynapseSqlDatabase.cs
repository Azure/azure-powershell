using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSqlDatabase : PSSynapseTrackedResource
    {
        public PSSynapseSqlDatabase(SqlDatabase sqlDatabase)
            : base(sqlDatabase?.Location, sqlDatabase?.Id, sqlDatabase?.Name, sqlDatabase?.Type, sqlDatabase?.Tags)
        {
            this.Collation = sqlDatabase?.Collation;
            this.SystemData = sqlDatabase?.SystemData != null ? new PSSystemData(sqlDatabase.SystemData) : null;
            this.StorageRedundancy = sqlDatabase?.StorageRedundancy;
        }

        /// <summary>
        /// Gets System Data
        /// </summary>
        public PSSystemData SystemData { get; set; }

        /// <summary>
        /// Gets maximum size in bytes
        /// </summary>
        public long? MaxSizeBytes { get; set; }

        /// <summary>
        /// Gets collation mode
        /// </summary>
        public string Collation { get; set; }

        /// <summary>
        /// Storage redundancy of the database.
        /// </summary>
        public string StorageRedundancy { get; set; }
    }
}