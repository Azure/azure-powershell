using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSqlDatabase : PSSynapseTrackedResource
    {
        public PSSynapseSqlDatabase(SqlDatabase sqlDatabase)
            : base(sqlDatabase?.Location, sqlDatabase?.Id, sqlDatabase?.Name, sqlDatabase?.Type, sqlDatabase?.Tags)
        {
            this.MaxSizeBytes = sqlDatabase?.MaxSizeBytes;
            this.Collation = sqlDatabase?.Collation;
            this.SystemData = sqlDatabase?.SystemData != null ? new PSSystemData(sqlDatabase.SystemData) : null;
        }

        /// <summary>
        /// Gets System Data
        /// </summary>
        public PSSystemData SystemData { get; private set; }

        /// <summary>
        /// Gets maximum size in bytes
        /// </summary>
        public long? MaxSizeBytes { get; private set; }

        /// <summary>
        /// Gets collation mode
        /// </summary>
        public string Collation { get; private set; }
    }
}