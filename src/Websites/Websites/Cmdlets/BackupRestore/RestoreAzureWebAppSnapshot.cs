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

using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.BackupRestore
{
    /// <summary>
    ///     Restores an Azure Web App snapshot
    /// </summary>
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppSnapshot", SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RestoreAzureWebAppSnapshot : WebAppOptionalSlotBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSet1Name, Position = 3, Mandatory = true,
            HelpMessage = "The Azure Web App snapshot.", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ParameterSet2Name, Position = 1, Mandatory = true,
            HelpMessage = "The Azure Web App snapshot.", ValueFromPipeline = true)]
        public AzureWebAppSnapshot InputObject;

        [Parameter(Mandatory = false, HelpMessage = "Recover the web app's configuration in addition to files.", ValueFromPipelineByPropertyName = true)]
        public SwitchParameter RecoverConfiguration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Use to recover a snapshot from a scale unit that is offline.")]
        public SwitchParameter UseDisasterRecovery { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Allows the original web app to be overwritten without displaying a warning.", ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var sourceApp = new PSSite(WebsitesClient.GetWebApp(InputObject.ResourceGroupName, InputObject.Name, InputObject.Slot));
            SnapshotRecoverySource source = new SnapshotRecoverySource()
            {
                Location = sourceApp.Location,
                Id = sourceApp.Id
            };
            SnapshotRestoreRequest recoveryReq = new SnapshotRestoreRequest()
            {
                Overwrite = true,
                SnapshotTime = this.InputObject.SnapshotTime.ToString("o"),
                RecoverConfiguration = this.RecoverConfiguration,
                IgnoreConflictingHostNames = true,
                RecoverySource = source,
                UseDRSecondary = UseDisasterRecovery
            };
            Action recoverAction = () => WebsitesClient.RestoreSnapshot(ResourceGroupName, Name, Slot, recoveryReq);
            ConfirmAction(this.Force.IsPresent, "Web app contents will be overwritten with the contents of the snapshot.",
                "The snapshot has been restored.", Name, recoverAction);
        }
    }
}
