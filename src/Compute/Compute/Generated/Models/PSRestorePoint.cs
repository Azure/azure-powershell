using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    class PSRestorePoint
    {
        // Summary:
        //     Gets the details of the VM captured at the time of the restore point creation.        
        public RestorePointSourceMetadata SourceMetadata { get; set; }
        //
        // Summary:
        //     Gets the provisioning state of the restore point.
        public string ProvisioningState { get; set; }
        //
        // Summary:
        //     Gets the consistency mode for the restore point. Please refer to https://aka.ms/RestorePoints
        //     for more details. Possible values include: 'CrashConsistent', 'FileSystemConsistent',
        //     'ApplicationConsistent'
        public string ConsistencyMode { get; set; }
        //
        // Summary:
        //     Gets the provisioning details set by the server during Create restore point operation.
        public RestorePointProvisioningDetails ProvisioningDetails { get; set; }
        //
        // Summary:
        //     Gets or sets list of disk resource ids that the customer wishes to exclude from
        //     the restore point. If no disks are specified, all disks will be included.
        public IList<ApiEntityReference> ExcludeDisks { get; set; }
    }
}
