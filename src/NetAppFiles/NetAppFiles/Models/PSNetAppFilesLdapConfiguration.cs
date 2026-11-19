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
    public class PSNetAppFilesLdapConfiguration
    {
        public string Domain { get; set; }
        public string[] LdapServers { get; set; }
        public string SecureLdapType { get; set; }
        public string ServerCACertificate { get; set; }
        public string CertificateCNHost { get; set; }
        public string[] DnsServers { get; set; }
        public int? LdapPort { get; set; }
        public string UserDN { get; set; }
        public string GroupDN { get; set; }
        public string NetGroupDN { get; set; }
        public string BindAuthenticationLevel { get; set; }
        public string BindDN { get; set; }
        public PSNetAppFilesBindPasswordAkvConfig BindPasswordAkvConfig { get; set; }
    }
}
