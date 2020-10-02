using Microsoft.Azure.Management.Synapse.Models;
using System;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSqlPoolV3 : PSSynapseTrackedResource
    {
        public PSSynapseSqlPoolV3(SqlPoolV3 sqlPool)
            : base(sqlPool?.Location, sqlPool?.Id, sqlPool?.Name, sqlPool?.Type, sqlPool?.Tags)
        {
            this.Sku = sqlPool?.Sku != null ? new PSSynapseSku(sqlPool.Sku) : null;
            this.Kind = sqlPool?.Kind;
            this.CurrentServiceObjectiveName = sqlPool?.CurrentServiceObjectiveName;
            this.RequestedServiceObjectiveName = sqlPool?.RequestedServiceObjectiveName;
            this.SqlPoolGuid = sqlPool?.SqlPoolGuid;
            this.SystemData = sqlPool?.SystemData != null ? new PSSystemData(sqlPool.SystemData) : null;
            this.Status = sqlPool?.Status;
        }

        /// <summary>
        /// Gets SQL pool SKU
        /// </summary>
        public PSSynapseSku Sku { get; private set; }

        /// <summary>
        /// Gets Kind of Sql Pool
        /// </summary>
        public string Kind { get; private set; }

        /// <summary>
        /// Gets current service objective name
        /// </summary>
        public string CurrentServiceObjectiveName { get; private set; }

        /// <summary>
        /// Gets requested service objective name
        /// </summary>
        public string RequestedServiceObjectiveName { get; private set; }

        /// <summary>
        /// Gets Sql Pool Guid
        /// </summary>
        public Guid? SqlPoolGuid { get; private set; }

        /// <summary>
        /// Gets System Data
        /// </summary>
        public PSSystemData SystemData { get; private set; }

        /// <summary>
        /// Gets resource status
        /// </summary>
        public string Status { get; private set; }
    }
}