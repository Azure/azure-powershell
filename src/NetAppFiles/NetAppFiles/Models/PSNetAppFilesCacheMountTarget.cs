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
    /// <summary>
    /// PowerShell representation of a mount target associated with an Azure NetApp Files Cache.
    /// </summary>
    public class PSNetAppFilesCacheMountTarget
    {
        /// <summary>
        /// Gets or sets the UUID v4 used to identify the mount target.
        /// </summary>
        public string MountTargetId { get; set; }

        /// <summary>
        /// Gets or sets the mount target's IPv4 address, used to mount the cache.
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// Gets or sets the SMB server's Fully Qualified Domain Name (FQDN).
        /// </summary>
        public string SmbServerFqdn { get; set; }
    }
}
