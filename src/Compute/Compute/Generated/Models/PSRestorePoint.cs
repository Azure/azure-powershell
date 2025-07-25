// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------


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
        //     Gets or sets list of disk resource ids that the customer wishes to exclude from
        //     the restore point. If no disks are specified, all disks will be included.
        public IList<ApiEntityReference> ExcludeDisks { get; set; }

        public RestorePointInstanceView InstanceView { get; set; }

        public DateTime? TimeCreated { get; set; }

        public ApiEntityReference SourceRestorePoint { get; set; }

    }
}
