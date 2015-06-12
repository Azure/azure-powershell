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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// AcsNamespace is where the certificate is uploaded into
    /// </summary>
    public class AcsNamespace
    {
        /// <summary>
        /// Gets or sets the key name for HostName entry
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the key name for Namespace entry
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the value for ResourceProviderRealm entry
        /// </summary>
        public string ResourceProviderRealm { get; set; }

        /// <summary>
        /// Initializes a new instance of the AcsNamespace class
        /// </summary>
        public AcsNamespace() { }

        /// <summary>
        /// Initializes a new instance of the AcsNamespace class.
        /// </summary>
        /// <param name="hostName">host name</param>
        /// <param name="acsNmespace">acs namespace</param>
        /// <param name="resourceProviderRealm">rp realm</param>
        public AcsNamespace(string hostName, string acsNmespace, string resourceProviderRealm)
        {
            this.HostName = hostName;
            this.Namespace = acsNmespace;
            this.ResourceProviderRealm = resourceProviderRealm;
        }
    }
}
