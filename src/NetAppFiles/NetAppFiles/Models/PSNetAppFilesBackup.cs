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
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    /// <summary>
    /// ARM tracked resource
    /// </summary>
    public class PSNetAppFilesBackup
    {
        /// <summary>
        /// Gets or sets the Resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Resource location
        /// </summary>
        public string Location { get; set; }
        
        /// <summary>
        /// Gets resource Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets resource name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets resource type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets snapshotId
        /// </summary>
        /// <remarks>
        /// UUID v4 used to identify the Backup
        /// </remarks>
        public string BackupId { get; set; }

        /// <summary>
        /// Gets or sets CreationDate
        /// </summary>
        /// <remarks>
        /// The creation date of the backup
        /// </remarks>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets Size
        /// </summary>
        /// <remarks>
        /// Size of backup
        /// </remarks>
        public long? Size { get; set; }

        /// <summary>
        /// Gets or sets Label
        /// </summary>
        /// <remarks>
        ///  Label for backup
        /// </remarks>        
        public string Label { get; set; }


        /// <summary>
        /// Gets or sets backupType
        /// </summary>
        ///<remarks>
        /// Type of backup adhoc or scheduled
        ///</remarks>
        public string BackupType { get; set; }

        /// <summary>
        /// Gets azure lifecycle management
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets Volume name
        /// </summary>
        public string VolumeResourceId { get; set; }

        /// <summary>
        /// Gets or sets UseExistingSnapshot
        /// </summary>
        /// <remarks>
        /// Manual backup an already existing snapshot. This will always be
        /// false for scheduled backups and true/false for manual backups
        /// </remarks>
        public bool? UseExistingSnapshot { get; set; }

        /// <summary>
        /// Gets or sets SnapshotName
        /// </summary>
        /// <remarks>
        ///  The name of the snapshot
        /// </remarks>        
        public string SnapshotName { get; set; }
    }
}