using Microsoft.Azure.Management.Synapse.Models;
using System;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSqlPool : PSSynapseTrackedResource
    {
        public PSSynapseSqlPool(SqlPool sqlPool)
            : base(sqlPool?.Location, sqlPool?.Id, sqlPool?.Name, sqlPool?.Type, sqlPool?.Tags)
        {
            this.Sku = sqlPool?.Sku != null ? new PSSynapseSku(sqlPool.Sku) : null;
            this.MaxSizeBytes = sqlPool?.MaxSizeBytes;
            this.Collation = sqlPool?.Collation;
            this.SourceDatabaseId = sqlPool?.SourceDatabaseId;
            this.RecoverableDatabaseId = sqlPool?.RecoverableDatabaseId;
            this.ProvisioningState = sqlPool?.ProvisioningState;
            this.Status = sqlPool?.Status;
            this.CreateMode = sqlPool?.CreateMode;
            this.CreationDate = sqlPool?.CreationDate;

            if (sqlPool?.RestorePointInTime != null)
            {
                this.RestorePointInTime = DateTime.Parse(sqlPool.RestorePointInTime);
            }
        }

        /// <summary>
        /// Gets SQL pool SKU
        /// </summary>
        public PSSynapseSku Sku { get; private set; }

        /// <summary>
        /// Gets maximum size in bytes
        /// </summary>
        public long? MaxSizeBytes { get; private set; }

        /// <summary>
        /// Gets collation mode
        /// </summary>
        public string Collation { get; private set; }

        /// <summary>
        /// Gets source database to create from
        /// </summary>
        public string SourceDatabaseId { get; private set; }

        /// <summary>
        /// Gets backup database to restore from
        /// </summary>
        public string RecoverableDatabaseId { get; private set; }

        /// <summary>
        /// Gets resource state
        /// </summary>
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets resource status
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// Gets snapshot time to restore
        /// </summary>
        public System.DateTime? RestorePointInTime { get; private set; }

        /// <summary>
        /// Gets what is this?
        /// </summary>
        public string CreateMode { get; private set; }

        /// <summary>
        /// Gets date the SQL pool was created
        /// </summary>
        public System.DateTime? CreationDate { get; private set; }
    }
}