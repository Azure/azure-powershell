using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    class PSRestorePointCollection
    {
        public RestorePointCollectionSourceProperties Source { get; set; }
        //
        // Summary:
        //     Gets the provisioning state of the restore point collection.
        public string ProvisioningState { get; set; }
        //
        // Summary:
        //     Gets the unique id of the restore point collection.
        public string RestorePointCollectionId { get; set; }
        //
        // Summary:
        //     Gets a list containing all restore points created under this restore point collection.
        public IList<RestorePoint> RestorePoints { get; set; }
    }
}
