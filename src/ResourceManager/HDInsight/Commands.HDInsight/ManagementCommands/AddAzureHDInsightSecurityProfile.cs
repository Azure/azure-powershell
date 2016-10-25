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
        HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster.")]
        public AzureHDInsightConfig Config { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Domain of the secure cluster.")]
        public string Domain
        {
            get { return _securityProfile.Domain; }
            set { _securityProfile.Domain = value; } 
        }

        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "Credential of the domain user. Username should be in user principal format. Eg. sampleuser@contoso.com")]
        public PSCredential DomainUserCredential 
        {
            get { return _securityProfile.DomainUserCredential; }
            set { _securityProfile.DomainUserCredential = value; } 
        }

        [Parameter(Position = 3,
            Mandatory = true,
            HelpMessage = "The OrganizationalUnit DN.")]
        public string OrganizationalUnitDN
        {
            get { return _securityProfile.OrganizationalUnitDN; }
            set { _securityProfile.OrganizationalUnitDN = value; }
        }

        [Parameter(Position = 4,
            Mandatory = true,
            HelpMessage = "The list of urls of the LDAPS server.")]
        public string[] LdapsUrls
        {
            get { return _securityProfile.LdapsUrls.ToArray(); }
            set { _securityProfile.LdapsUrls = value; }
        }

        [Parameter(Position = 5,
            HelpMessage = "The list of DNs of the user group which should have access to use the cluster.")]
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
