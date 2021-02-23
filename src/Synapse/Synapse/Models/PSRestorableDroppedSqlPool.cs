using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSRestorableDroppedSqlPool : PSSynapseProxyResource
    {
        public PSRestorableDroppedSqlPool(RestorableDroppedSqlPool restorableDroppedSqlPool)
            : base(restorableDroppedSqlPool?.Id, restorableDroppedSqlPool?.Name, restorableDroppedSqlPool?.Type)
        {
            this.Location = restorableDroppedSqlPool.Location;
            this.SqlpoolName = restorableDroppedSqlPool.DatabaseName;
            this.Edition = restorableDroppedSqlPool.Edition;
            this.MaxSizeBytes = restorableDroppedSqlPool.MaxSizeBytes;
            this.ServiceLevelObjective = restorableDroppedSqlPool.ServiceLevelObjective;
            this.ElasticPoolName = restorableDroppedSqlPool.ElasticPoolName;
            this.CreationDate = restorableDroppedSqlPool.CreationDate;
            this.DeletionDate = restorableDroppedSqlPool.DeletionDate;
            this.EarliestRestoreDate = restorableDroppedSqlPool.EarliestRestoreDate;
        }

        //
        // Summary:
        //     Gets the geo-location where the resource lives
        public string Location { get; }

        //
        // Summary:
        //     Gets the name of the database
        public string SqlpoolName { get; }

        //
        // Summary:
        //     Gets the edition of the database
        public string Edition { get; }

        //
        // Summary:
        //     Gets the max size in bytes of the database
        public string MaxSizeBytes { get; }

        //
        // Summary:
        //     Gets the service level objective name of the database
        public string ServiceLevelObjective { get; }

        //
        // Summary:
        //     Gets the elastic pool name of the database
        public string ElasticPoolName { get; }

        //
        // Summary:
        //     Gets the creation date of the database (ISO8601 format)
        public DateTime? CreationDate { get; }

        //
        // Summary:
        //     Gets the deletion date of the database (ISO8601 format)
        public DateTime? DeletionDate { get; }

        //
        // Summary:
        //     Gets the earliest restore date of the database (ISO8601 format)
        public DateTime? EarliestRestoreDate { get; }
    }
}