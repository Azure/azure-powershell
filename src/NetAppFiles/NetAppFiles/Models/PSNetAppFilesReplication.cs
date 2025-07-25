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
    public class PSNetAppFilesReplication
    {
        /// <summary>
        /// Gets uUID v4 used to identify the replication.        
        /// </summary>
        public string ReplicationId { get; set; }

        /// <summary>
        /// Gets or sets indicates whether the local volume is the source or destination
        /// for the Volume Replication. Possible values include: 'src', 'dst'
        /// </summary>
        public string EndpointType { get; set; }

        /// <summary>
        /// Gets or sets schedule. Possible values include: '_10minutely', 'hourly', 'daily',
        /// 'weekly', 'monthly'
        /// </summary>
        public string ReplicationSchedule { get; set; }

        /// <summary>
        ///  Gets or sets the resource ID of the remote volume.
        /// </summary>
        public string RemoteVolumeResourceId { get; set; }

        /// <summary>
        /// Gets or sets the remote region for the other end of the Volume Replication.
        /// </summary>
        public string RemoteVolumeRegion { get; set; }
    }
}