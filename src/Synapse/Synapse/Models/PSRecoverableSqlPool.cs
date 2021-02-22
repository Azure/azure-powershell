using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSRecoverableSqlPool : PSSynapseProxyResource
    {
        public PSRecoverableSqlPool(RecoverableSqlPool recoverableSqlPool)
            : base(recoverableSqlPool?.Id, recoverableSqlPool?.Name, recoverableSqlPool?.Type)
        {
            this.Edition = recoverableSqlPool.Edition;
            this.ServiceLevelObjective = recoverableSqlPool.ServiceLevelObjective;
            this.ElasticPoolName = recoverableSqlPool.ElasticPoolName;
            this.LastAvailableBackupDate = recoverableSqlPool.LastAvailableBackupDate;
        }

        public string Edition { get; set; }

        //
        // Summary:
        //     Gets the service level objective name of the database
        public string ServiceLevelObjective { get; set; }

        //
        // Summary:
        //     Gets the elastic pool name of the database
        public string ElasticPoolName { get; set; }

        //
        // Summary:
        //     Gets the last available backup date of the database (ISO8601 format)
        public DateTime? LastAvailableBackupDate { get; set; }
    }
}

