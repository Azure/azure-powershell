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

using Microsoft.Azure.Management.NetApp.Models;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    /// <summary>
    /// ARM tracked resource
    /// </summary>
    public class PSNetAppFilesActiveDirectory
    {
        /// <summary>
        /// Id of the active drectory.
        /// Value of this property can not be set by user.
        /// </summary>
        /// <value>Id of the active directory.</value>
        public string ActiveDirectoryId { get; set; }

        /// <summary>
        /// Username of a Active Directory domain administrator
        /// </summary>
        /// <value>Username of a Active Directory domain administrator</value>
        public string Username { get; set; }

        /// <summary>
        /// Password of a Active Directory domain administrator
        /// </summary>
        /// <value>Password of a Active Directory domain administrator</value>
        public string Password { get; set; }

        /// <summary>
        /// Name of the Active Directory domain
        /// </summary>
        /// <value>Name of the Active Directory domain</value>
        public string Domain { get; set; }

        /// <summary>
        /// Comma separated list of DNS server IP addresses for the Active Directory domain
        /// </summary>
        /// <value>Comma separated list of DNS server IP addresses for the Active Directory domain</value>
        public string Dns { get; set; }

        /// <summary>
        /// Status of the active drectory.
        /// Value of this property can not be set by user.
        /// </summary>
        /// <value>Status of the active directory on the storage server.</value>
        public string Status { get; set; }

        /// <summary>
        /// NetBIOS name of the SMB server.
        /// This name will be registered as a computer account in the AD.
        /// This name will be used to mount the volumes.
        /// </summary>
        /// <value>NetBIOS name of the SMB server</value>
        public string SmbServerName { get; set; }

        /// <summary>
        /// The Organizational Unit (OU) within the Windows Active Directory.
        /// </summary>
        public string OrganizationalUnit { get; set; }
    }
}