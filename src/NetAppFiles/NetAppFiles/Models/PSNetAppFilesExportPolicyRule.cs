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
        /// Gets or sets allows NFSv4 protocol
        /// </summary>
        public bool? Nfsv4 { get; set; }

        /// <summary>
        /// Gets or sets client ingress specification as comma separated string
        /// with IPv4 CIDRs, IPv4 host addresses and host names
        /// </summary>
        public string AllowedClients { get; set; }
    }
}