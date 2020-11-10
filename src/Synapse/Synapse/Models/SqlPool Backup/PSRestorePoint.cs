using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSRestorePoint
    {
        public PSRestorePoint(RestorePoint restorePoint, [Optional] string ResourceGroupName, [Optional] string WorkspaceName, [Optional] string SqlPoolName)
        {
            this.Location = restorePoint.Location;
            this.RestorePointType = restorePoint.RestorePointType;
            this.EarliestRestoreDate = restorePoint.EarliestRestoreDate;
            this.RestorePointCreationDate = restorePoint.RestorePointCreationDate;
            this.RestorePointLabel = restorePoint.RestorePointLabel;
            this.ResourceGroupName = ResourceGroupName;
            this.WorkspaceName = WorkspaceName;
            this.SqlPoolName = SqlPoolName;
        }

        public string Location { get; }

        public RestorePointType? RestorePointType { get; }
        
        public DateTime? EarliestRestoreDate { get; }

        public DateTime? RestorePointCreationDate { get; }

        public string RestorePointLabel { get; }

        public string ResourceGroupName { get; set; }

        public string WorkspaceName { get; set; }

        public string SqlPoolName { get; set; }
    }
}
