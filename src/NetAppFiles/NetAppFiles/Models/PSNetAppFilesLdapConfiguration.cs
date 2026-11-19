// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    public class PSNetAppFilesLdapConfiguration
    {
        public string Domain { get; set; }
        public IList<string> LdapServers { get; set; }
        public string SecureLdapType { get; set; }
        public string ServerCaCertificate { get; set; }
        public string CertificateCnHost { get; set; }
        public IList<string> DnsServers { get; set; }
        public int? LdapPort { get; set; }
        public string UserDn { get; set; }
        public string GroupDn { get; set; }
        public string NetGroupDn { get; set; }
        public string BindAuthenticationLevel { get; set; }
        public string BindDn { get; set; }
        public PSNetAppFilesBindPasswordAkvConfig BindPasswordAkvConfig { get; set; }
    }
}
