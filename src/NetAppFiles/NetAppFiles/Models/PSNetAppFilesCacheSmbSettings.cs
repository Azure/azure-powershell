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
    /// PowerShell representation of the SMB settings for an Azure NetApp Files Cache.
    /// </summary>
    public class PSNetAppFilesCacheSmbSettings
    {
        /// <summary>
        /// Gets or sets whether encryption for in-flight SMB3 data is enabled. Only applicable for
        /// SMB/DualProtocol caches. Possible values include: 'Disabled', 'Enabled'.
        /// </summary>
        public string SmbEncryption { get; set; }

        /// <summary>
        /// Gets or sets whether access-based enumeration is enabled for SMB shares. Only applicable
        /// for SMB/DualProtocol volumes. Possible values include: 'Disabled', 'Enabled'.
        /// </summary>
        public string SmbAccessBasedEnumeration { get; set; }

        /// <summary>
        /// Gets or sets whether the non-browsable property is enabled for SMB shares. Only applicable
        /// for SMB/DualProtocol volumes. Possible values include: 'Disabled', 'Enabled'.
        /// </summary>
        public string SmbNonBrowsable { get; set; }
    }
}
