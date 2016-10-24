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

using System.Collections.Generic;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.HDInsight.Models.Management;

namespace Microsoft.Azure.Commands.HDInsight.Models
{

    /// <summary>
    /// Represents and AzureHDInsightSecurityProfile which contans the parameters to create secure cluster.
    /// </summary>
    public class AzureHDInsightSecurityProfile
    {
        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        /// <value>
        /// The domain.
        /// </value>
        public string Domain { get; set; }
        
        /// <summary>
        /// Gets or sets the domain user credential.
        /// </summary>
        /// <value>
        /// The domain user credential.
        /// </value>
        public PSCredential DomainUserCredential { get;set;}

        /// <summary>
        /// Gets or sets the organizational unit DN.
        /// </summary>
        /// <value>
        /// The organizational unit dn.
        /// </value>
        public string OrganizationalUnitDN { get; set; }

        /// <summary>
        /// Gets or sets the ldaps urls.
        /// </summary>
        /// <value>
        /// The ldaps urls.
        /// </value>
        public string[] LdapsUrls { get; set; }

        /// <summary>
        /// Gets or sets the cluster users group DNs.
        /// </summary>
        /// <value>
        /// The cluster users group DNs.
        /// </value>
        public string[] ClusterUsersGroupDNs { get; set; }
    }
}
