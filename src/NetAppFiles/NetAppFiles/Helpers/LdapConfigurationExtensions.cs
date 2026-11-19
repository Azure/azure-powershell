// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp.Models;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class LdapConfigurationExtensions
    {
        public static PSNetAppFilesLdapConfiguration ConvertToPs(this LdapConfiguration configuration)
        {
            return new PSNetAppFilesLdapConfiguration
            {
                Domain = configuration.Domain,
                LdapServers = configuration.LdapServers,
                SecureLdapType = configuration.SecureLdapType,
                ServerCaCertificate = configuration.ServerCaCertificate,
                CertificateCnHost = configuration.CertificateCnHost,
                DnsServers = configuration.DnsServers,
                LdapPort = configuration.LdapPort,
                UserDn = configuration.UserDn,
                GroupDn = configuration.GroupDn,
                NetGroupDn = configuration.NetGroupDn,
                BindAuthenticationLevel = configuration.BindAuthenticationLevel,
                BindDn = configuration.BindDn,
                BindPasswordAkvConfig = configuration.BindPasswordAkvConfig == null ? null : new PSNetAppFilesBindPasswordAkvConfig
                {
                    AzureKeyVaultUri = configuration.BindPasswordAkvConfig.AzureKeyVaultUri,
                    SecretName = configuration.BindPasswordAkvConfig.SecretName,
                    UserAssignedIdentity = configuration.BindPasswordAkvConfig.UserAssignedIdentity
                }
            };
        }

        public static LdapConfiguration ConvertFromPs(this PSNetAppFilesLdapConfiguration configuration)
        {
            return new LdapConfiguration
            {
                Domain = configuration.Domain,
                LdapServers = configuration.LdapServers,
                SecureLdapType = configuration.SecureLdapType,
                ServerCaCertificate = configuration.ServerCaCertificate,
                CertificateCnHost = configuration.CertificateCnHost,
                DnsServers = configuration.DnsServers,
                LdapPort = configuration.LdapPort,
                UserDn = configuration.UserDn,
                GroupDn = configuration.GroupDn,
                NetGroupDn = configuration.NetGroupDn,
                BindAuthenticationLevel = configuration.BindAuthenticationLevel,
                BindDn = configuration.BindDn,
                BindPasswordAkvConfig = configuration.BindPasswordAkvConfig == null ? null : new BindPasswordAkvConfig
                {
                    AzureKeyVaultUri = configuration.BindPasswordAkvConfig.AzureKeyVaultUri,
                    SecretName = configuration.BindPasswordAkvConfig.SecretName,
                    UserAssignedIdentity = configuration.BindPasswordAkvConfig.UserAssignedIdentity
                }
            };
        }

        public static LdapConfigurationPatch ConvertToPatchFromPs(this PSNetAppFilesLdapConfiguration configuration)
        {
            return new LdapConfigurationPatch
            {
                Domain = configuration.Domain,
                LdapServers = configuration.LdapServers,
                SecureLdapType = configuration.SecureLdapType,
                ServerCaCertificate = configuration.ServerCaCertificate,
                CertificateCnHost = configuration.CertificateCnHost,
                DnsServers = configuration.DnsServers,
                LdapPort = configuration.LdapPort,
                UserDn = configuration.UserDn,
                GroupDn = configuration.GroupDn,
                NetGroupDn = configuration.NetGroupDn,
                BindAuthenticationLevel = configuration.BindAuthenticationLevel,
                BindDn = configuration.BindDn,
                BindPasswordAkvConfig = configuration.BindPasswordAkvConfig == null ? null : new BindPasswordAkvConfigPatch
                {
                    AzureKeyVaultUri = configuration.BindPasswordAkvConfig.AzureKeyVaultUri,
                    SecretName = configuration.BindPasswordAkvConfig.SecretName,
                    UserAssignedIdentity = configuration.BindPasswordAkvConfig.UserAssignedIdentity
                }
            };
        }
    }
}
