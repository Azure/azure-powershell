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
using System.Linq;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class LdapConfigurationExtensions
    {
        public static PSNetAppFilesLdapConfiguration ConvertToPs(this LdapConfiguration configuration)
        {
            return new PSNetAppFilesLdapConfiguration
            {
                Domain = configuration.Domain,
                LdapServers = configuration.LdapServers?.ToArray(),
                SecureLdapType = configuration.SecureLdapType,
                ServerCACertificate = configuration.ServerCaCertificate,
                CertificateCNHost = configuration.CertificateCnHost,
                DnsServers = configuration.DnsServers?.ToArray(),
                LdapPort = configuration.LdapPort,
                UserDN = configuration.UserDn,
                GroupDN = configuration.GroupDn,
                NetGroupDN = configuration.NetGroupDn,
                BindAuthenticationLevel = configuration.BindAuthenticationLevel,
                BindDN = configuration.BindDn,
                BindPasswordAkvConfig = configuration.BindPasswordAkvConfig?.ConvertToPs()
            };
        }

        public static LdapConfiguration ConvertFromPs(this PSNetAppFilesLdapConfiguration configuration)
        {
            return new LdapConfiguration
            {
                Domain = configuration.Domain,
                LdapServers = configuration.LdapServers,
                SecureLdapType = configuration.SecureLdapType,
                ServerCaCertificate = configuration.ServerCACertificate,
                CertificateCnHost = configuration.CertificateCNHost,
                DnsServers = configuration.DnsServers,
                LdapPort = configuration.LdapPort,
                UserDn = configuration.UserDN,
                GroupDn = configuration.GroupDN,
                NetGroupDn = configuration.NetGroupDN,
                BindAuthenticationLevel = configuration.BindAuthenticationLevel,
                BindDn = configuration.BindDN,
                BindPasswordAkvConfig = configuration.BindPasswordAkvConfig?.ConvertFromPs()
            };
        }

        public static LdapConfigurationPatch ConvertToPatch(this PSNetAppFilesLdapConfiguration configuration)
        {
            return new LdapConfigurationPatch
            {
                Domain = configuration.Domain,
                LdapServers = configuration.LdapServers,
                SecureLdapType = configuration.SecureLdapType,
                ServerCaCertificate = configuration.ServerCACertificate,
                CertificateCnHost = configuration.CertificateCNHost,
                DnsServers = configuration.DnsServers,
                LdapPort = configuration.LdapPort,
                UserDn = configuration.UserDN,
                GroupDn = configuration.GroupDN,
                NetGroupDn = configuration.NetGroupDN,
                BindAuthenticationLevel = configuration.BindAuthenticationLevel,
                BindDn = configuration.BindDN,
                BindPasswordAkvConfig = configuration.BindPasswordAkvConfig?.ConvertToPatch()
            };
        }

        public static PSNetAppFilesBindPasswordAkvConfig ConvertToPs(this BindPasswordAkvConfig configuration)
        {
            return new PSNetAppFilesBindPasswordAkvConfig
            {
                AzureKeyVaultUri = configuration.AzureKeyVaultUri,
                SecretName = configuration.SecretName,
                UserAssignedIdentity = configuration.UserAssignedIdentity
            };
        }

        public static BindPasswordAkvConfig ConvertFromPs(this PSNetAppFilesBindPasswordAkvConfig configuration)
        {
            return new BindPasswordAkvConfig
            {
                AzureKeyVaultUri = configuration.AzureKeyVaultUri,
                SecretName = configuration.SecretName,
                UserAssignedIdentity = configuration.UserAssignedIdentity
            };
        }

        public static BindPasswordAkvConfigPatch ConvertToPatch(this PSNetAppFilesBindPasswordAkvConfig configuration)
        {
            return new BindPasswordAkvConfigPatch
            {
                AzureKeyVaultUri = configuration.AzureKeyVaultUri,
                SecretName = configuration.SecretName,
                UserAssignedIdentity = configuration.UserAssignedIdentity
            };
        }
    }
}
