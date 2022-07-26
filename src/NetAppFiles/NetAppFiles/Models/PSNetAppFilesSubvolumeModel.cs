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
    using System;

    public class PSNetAppFilesSubvolumeModel
    {
        /// <summary>
        /// Gets or sets the Resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

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
        /// Gets or sets path
        /// </summary>
        /// <remarks>
        /// Path to the subvolume
        /// </remarks>        
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets parentpath
        /// </summary>
        /// <remarks>
        /// Path to the parent subvolume
        /// </remarks>        
        public string ParentPath { get; set; }

        /// <summary>
        /// Gets or sets size
        /// </summary>
        /// <remarks>
        /// Size of subvolume
        /// </remarks>        
        public long? Size { get; set; }

        /// <summary>
        /// Gets or sets bytesUsed
        /// </summary>
        /// <remarks>
        /// Bytes used
        /// </remarks>        
        public long? BytesUsed { get; set; }

        /// <summary>
        /// Gets or sets permissions
        /// </summary>
        /// <remarks>
        /// Permissions of the subvolume
        /// </remarks>        
        public string Permissions { get; set; }

        /// <summary>
        /// Gets or sets creationTimeStamp
        /// </summary>
        /// <remarks>
        /// Creation time and date
        /// </remarks>        
        public DateTime? CreationTimeStamp { get; set; }

        /// <summary>
        /// Gets or sets accessedTimeStamp
        /// </summary>
        /// <remarks>
        /// Most recent access time and date
        /// </remarks>        
        public DateTime? AccessedTimeStamp { get; set; }

        /// <summary>
        /// Gets or sets modifiedTimeStamp
        /// </summary>
        /// <remarks>
        /// Most recent modification time and date
        /// </remarks>        
        public DateTime? ModifiedTimeStamp { get; set; }

        /// <summary>
        /// Gets or sets changedTimeStamp
        /// </summary>
        /// <remarks>
        /// Most recent change time and date
        /// </remarks>        
        public DateTime? ChangedTimeStamp { get; set; }

        /// <summary>
        /// Gets or sets azure lifecycle management
        /// </summary>        
        public string ProvisioningState { get; set; }

    }
}
