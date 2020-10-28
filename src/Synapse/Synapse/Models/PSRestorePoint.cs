using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSRestorePoint
    {
        public PSRestorePoint(RestorePoint restorePoint)
        {
            this.Location = restorePoint.Location;
            this.RestorePointType = restorePoint.RestorePointType;
            this.EarliestRestoreDate = restorePoint.EarliestRestoreDate;
            this.RestorePointCreationDate = restorePoint.RestorePointCreationDate;
            this.RestorePointLabel = restorePoint.RestorePointLabel;
        }

        public string Location { get; }

        public RestorePointType? RestorePointType { get; }
        
        public DateTime? EarliestRestoreDate { get; }

        public DateTime? RestorePointCreationDate { get; }

        public string RestorePointLabel { get; }
    }
}
