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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    /// <summary>
    /// ARM tracked resource
    /// </summary>
    public class PSNetAppFilesBackupPolicy
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
        /// Gets or sets resource tags
        /// </summary>
        public object Tags { get; set; }

        /// <summary>
        /// Gets or sets resource etag
        /// </summary>
        /// <remarks>
        /// A unique read-only string that changes whenever the resource is updated.
        /// </remarks>
        public string Etag { get; set; }

        /// <summary>
        /// Gets snapshotId
        /// </summary>
        /// <remarks>
        /// UUID v4 used to identify the Backup Policy
        /// </remarks>
        public string BackupPolicyId { get; set; }

        /// <summary>
        /// Gets or sets VolumesAssigned using current backup policy
        /// </summary>
        /// <remarks>
        ///  Number of volumes using current backup policy
        /// </remarks>
        public int? VolumesAssigned { get; set; }

        /// <summary>
        /// Gets or sets MonthlyBackupsToKeep
        /// </summary>
        ///<remarks>
        /// Monthly backups count to keep
        ///</remarks>
        public int? MonthlyBackupsToKeep { get; set; }

        /// <summary>
        /// Gets or sets WeeklyBackupsToKeep
        /// </summary>
        ///<remarks>
        /// Weekly backups count to keep
        ///</remarks>
        public int? WeeklyBackupsToKeep { get; set; }

        /// <summary>
        /// Gets or sets DailyBackupsToKeep
        /// </summary>
        ///<remarks>
        /// Daily backups count to keep
        ///</remarks>
        public int? DailyBackupsToKeep { get; set; }

        /// <summary>
        /// Gets VolumeBackups
        /// </summary>
        /// <remarks>
        /// A list of volumes assigned to this policy
        /// </remarks>
        public IList<PSNetAppFilesVolumeBackup> VolumeBackups { get; set; }

        ///
        /// <summary>
        ///     Gets or sets the property to decide policy is enabled or not
        /// </summary>
        /// <remarks>
        /// The property to decide policy is enabled or not
        /// </remarks>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets azure lifecycle management
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets System Data
        /// </summary>
        public PSSystemData SystemData { get; set; }
    }
}