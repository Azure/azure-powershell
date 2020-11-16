using Microsoft.Azure.Management.Synapse.Models;
using System;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSRestorePoint : PSSynapseResource
    {
        public PSRestorePoint(RestorePoint restorePoint)
        {
            this.Location = restorePoint.Location;
            this.RestorePointType = restorePoint.RestorePointType;
            this.EarliestRestoreDate = restorePoint.EarliestRestoreDate;
            this.RestorePointCreationDate = restorePoint.RestorePointCreationDate;
            this.RestorePointLabel = restorePoint.RestorePointLabel;
            this.Id = restorePoint.Id;
            this.Name = restorePoint.Name;
            this.Type = restorePoint.Type;
        }

        public string Location { get; }

        public RestorePointType? RestorePointType { get; }
        
        public DateTime? EarliestRestoreDate { get; }

        public DateTime? RestorePointCreationDate { get; }

        public string RestorePointLabel { get; }

        public new string Id { get; set; }

        public new string Name { get; set; }

        public new string Type { get; set; }
    }
}
