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

using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class LdapSearchScopeOptExtensions
    {
        public static PSNetAppFilesLdapSearchScopeOpt ConvertToPs(this LdapSearchScopeOpt ldapSearchScope)
        {
            var psLdapSearchScope = new PSNetAppFilesLdapSearchScopeOpt
            {
                GroupDN = ldapSearchScope.GroupDN,
                GroupMembershipFilter = ldapSearchScope.GroupMembershipFilter,
                UserDN = ldapSearchScope.UserDN
            };
            return psLdapSearchScope;
        }

        public static LdapSearchScopeOpt ConvertFromPs(this PSNetAppFilesLdapSearchScopeOpt psLdapSearchScope)
        {
            var ldapSearchScope = new LdapSearchScopeOpt
            {
                GroupDN = psLdapSearchScope.GroupDN,
                GroupMembershipFilter = psLdapSearchScope.GroupMembershipFilter,
                UserDN = psLdapSearchScope.UserDN
            };
            return ldapSearchScope;
        }
    }
}
