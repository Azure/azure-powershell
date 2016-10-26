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
using System.Linq;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.Add,
        Constants.CommandNames.AzureHDInsightSecurityProfile),
    OutputType(
        typeof(AzureHDInsightSecurityProfile))]
    public class AddAzureHDInsightSecurityProfile : HDInsightCmdletBase
    {
        private readonly AzureHDInsightSecurityProfile _securityProfile;

        #region Input Parameter Definitions

        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster.")]
        public AzureHDInsightConfig Config { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Active Directory domain for the cluster.")]
        public string Domain
        {
            get { return _securityProfile.Domain; }
            set { _securityProfile.Domain = value; } 
        }

        [Parameter(Mandatory = true,
            HelpMessage = "A domain user account credential with sufficient permissions for creating the cluster. Username should be in user@domain format.")]
        public PSCredential DomainUserCredential 
        {
            get { return _securityProfile.DomainUserCredential; }
            set { _securityProfile.DomainUserCredential = value; } 
        }

        [Parameter(Mandatory = true,
            HelpMessage = "Distinguished name of the organizational unit in the Active directory where user and computer accounts will be created.")]
        public string OrganizationalUnitDN
        {
            get { return _securityProfile.OrganizationalUnitDN; }
            set { _securityProfile.OrganizationalUnitDN = value; }
        }

        [Parameter(Mandatory = true,
            HelpMessage = "Urls of one or multiple LDAPS servers for the Active Directory.")]
        public string[] LdapsUrls
        {
            get { return _securityProfile.LdapsUrls.ToArray(); }
            set { _securityProfile.LdapsUrls = value; }
        }

        [Parameter(HelpMessage = "Distinguished names of the Active Directory groups that will be available in Ambari and Ranger.")]
        public string[] ClusterUsersGroupDNs
        {
            get { return _securityProfile.ClusterUsersGroupDNs.ToArray(); }
            set { _securityProfile.ClusterUsersGroupDNs = value; }
        }

        #endregion

        public AddAzureHDInsightSecurityProfile()
        {
            _securityProfile = new AzureHDInsightSecurityProfile();
        }

        public override void ExecuteCmdlet()
        {
            Config.SecurityProfile = _securityProfile;

            WriteObject(Config);
        }
    }
}
