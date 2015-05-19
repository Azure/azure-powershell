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
using System.Management.Automation;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsSecurity.Grant,
        Constants.CommandNames.AzureHDInsightRdpServicesAccess),
    OutputType(
        typeof(ClusterGetResponse))]
    public class GrantAzureHDInsightRdpServicesAccessCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            HelpMessage = "Gets or sets the name of the resource group.")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public string ClusterName { get; set; }

        [Parameter(Position = 2,
            HelpMessage = "Whether or not RDP should be enabled.")]
        public bool Enable { get; set; }

        [Parameter(Position = 3,
            HelpMessage = "Gets or sets the username for RDP access to the cluster.")]
        public PSCredential RdpUser { get; set; }

        [Parameter(Position = 4,
            HelpMessage = "Gets or sets the expiry DateTime for RDP access on the cluster.")]
        public DateTime RdpAccessExpiry { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (this.Enable && this.RdpUser == null)
            {
                return;
            }
            var rdpSettings = new RdpSettings();
            if (RdpUser != null)
            {
                rdpSettings = new RdpSettings
                {
                    UserName = this.RdpUser.UserName,
                    Password = this.RdpUser.Password.ToString(),
                    ExpiryDate = this.RdpAccessExpiry
                };
            }

            var osProfile = new OsProfile
            {
                WindowsOperatingSystemProfile = new WindowsOperatingSystemProfile
                {
                    RdpSettings = rdpSettings
                }
            };

            var rdpParams = new RDPSettingsParameters
            {
                OsProfile = osProfile
            };

            var result = HDInsightManagementClient.EnableRDP(ResourceGroupName, ClusterName, rdpParams);
        }
    }
}
