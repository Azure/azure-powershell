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

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    public class PSNetAppFilesVolumeDataProtection
    {
        /// <summary>
        /// Gets or sets replication
        /// </summary>
        /// <remark>
        /// Replication properties
        /// </remark>
        public PSNetAppFilesReplicationObject Replication { get; set; }

        /// <summary>
        /// Gets or sets snapshot
        /// </summary>
        /// <remark>
        /// Snapshot properties
        /// </remark>        
        public PSNetAppFilesVolumeSnapshot Snapshot { get; set; }


        /// <summary>
        /// Gets or sets VolumeBackupProperties 
        /// </summary>
        /// <remark>
        /// Volume Backup properties
        /// </remark>                
        public PSNetAppFilesVolumeBackupProperties Backup { get; set; }
    }
}
