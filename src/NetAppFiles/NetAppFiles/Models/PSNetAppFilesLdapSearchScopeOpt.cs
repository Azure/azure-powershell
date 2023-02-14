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
    public class PSNetAppFilesLdapSearchScopeOpt
    {
        /// <summary>
        /// Gets or sets UserDN
        /// </summary>
        /// <remark>
        /// Gets or sets this specifies the user DN, which overrides the base DN for group lookups.
        /// </remark>
        public string UserDN { get; set; }

        /// <summary>
        /// Gets or sets GroupDN
        /// </summary>
        /// <remark>
        /// Gets or sets this specifies the group DN, which overrides the base DN for group lookups.
        /// </remark>
        public string GroupDN { get; set; }

        /// <summary>
        /// Gets or sets GroupMembershipFilter
        /// </summary>
        /// <remark>
        /// Gets or sets this specifies the custom LDAP search filter to be
        /// used when looking up group membership from LDAP server.
        /// </remark>
        public string GroupMembershipFilter { get; set; }
    }
}
