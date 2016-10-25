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
<<<<<<< HEAD
=======
using System.Management.Automation;
>>>>>>> [Secure Hadoop] Powershell changes to support secure cluster creation
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
        /// Gets or sets Active Directory domain for the cluster.
        /// </summary>
        /// <value>
        /// The domain.
        /// </value>
        public string Domain { get; set; }
        
        /// <summary>
        /// Gets or sets the domain user account credential with sufficient permissions for 
        /// creating the cluster. Username should be in user@domain format.
        /// </summary>
        /// <value>
        /// The domain user credential.
        /// </value>
        public PSCredential DomainUserCredential { get;set;}

        /// <summary>
        /// Gets or sets distinguished name of the organizational unit in 
        /// the Active directory where user and computer accounts will be created.
        /// </summary>
        /// <value>
        /// The organizational unit dn.
        /// </value>
        public string OrganizationalUnitDN { get; set; }

        /// <summary>
        /// Gets or sets the Urls of one or multiple LDAPS 
        /// servers for the Active Directory.
        /// </summary>
        /// <value>
        /// The ldaps urls.
        /// </value>
        public string[] LdapsUrls { get; set; }

        /// <summary>
        /// Gets or sets the distinguished names of the Active Directory groups that will be available in Ambari and Ranger.
        /// </summary>
        /// <value>
        /// The cluster users group DNs.
        /// </value>
        public string[] ClusterUsersGroupDNs { get; set; }
    }
}
