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
    public class PSNetAppFilesExportPolicyRule
    {    /// <summary>
         /// Gets or sets order index
         /// </summary>
        public int? RuleIndex { get; set; }

        /// <summary>
        /// Gets or sets read only access
        /// </summary>
        public bool? UnixReadOnly { get; set; }

        /// <summary>
        /// Gets or sets read and write access
        /// </summary>
        public bool? UnixReadWrite { get; set; }

        /// <summary>
        /// Gets or sets allows CIFS protocol
        /// </summary>
        public bool? Cifs { get; set; }

        /// <summary>
        /// Gets or sets allows NFSv3 protocol
        /// </summary>
        public bool? Nfsv3 { get; set; }

        /// <summary>
        /// Gets or sets allows NFSv41 protocol
        /// </summary>
        public bool? Nfsv41 { get; set; }

        /// <summary>
        /// Gets or sets client ingress specification as comma separated string
        /// with IPv4 CIDRs, IPv4 host addresses and host names
        /// </summary>
        public string AllowedClients { get; set; }

        /// <summary>
        /// Gets or sets kerberos5 Read only access. 
        /// </summary>
        public bool? Kerberos5ReadOnly { get; set; }

        /// <summary>
        /// Gets or sets kerberos5 Read and write access.
        /// </summary>
        public bool? Kerberos5ReadWrite { get; set; }

        /// <summary>
        /// Gets or sets kerberos5i Readonly access.
        /// </summary>
        public bool? Kerberos5iReadOnly { get; set; }

        /// <summary>
        /// Gets or sets kerberos5i Read and write access.
        /// </summary>
        public bool? Kerberos5iReadWrite { get; set; }

        /// <summary>
        /// Gets or sets kerberos5p Read only access.
        /// </summary>
        public bool? Kerberos5pReadOnly { get; set; }

        /// <summary>
        /// Gets or sets kerberos5p Read and write access.
        /// </summary>        
        public bool? Kerberos5pReadWrite { get; set; }

        /// <summary>
        /// Gets or sets has root access to volume
        /// </summary>
        public bool? HasRootAccess { get; set; }

        /// <summary>
        /// Gets or sets has root access to volume
        /// </summary>
        /// <value>
        /// This parameter specifies who is authorized to change the ownership of a file. restricted - Only root user can change the ownership of the file. unrestricted - Non-root users can change ownership of files that they own. (Restricted, Unrestricted)
        /// </value>
        /// 
        public string ChownMode { get; set; }
    }
}