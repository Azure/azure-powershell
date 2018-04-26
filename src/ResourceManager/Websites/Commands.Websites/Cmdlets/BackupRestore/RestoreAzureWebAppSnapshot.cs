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
    [Cmdlet(VerbsData.Restore, "AzureRmWebAppSnapshot", SupportsShouldProcess = true)]
    public class RestoreAzureWebAppSnapshot : WebAppOptionalSlotBaseCmdlet
    {
        protected const string SnapshotParameterSetName = "FromWebAppSnapshot";

        [Parameter(ParameterSetName = SnapshotParameterSetName, Position = 0, Mandatory = true,
            HelpMessage = "The Azure Web App snapshot.", ValueFromPipeline = true)]
        public AzureWebAppSnapshot WebAppSnapshot;

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The timestamp of the snapshot.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public DateTime SnapshotTime;

        [Parameter(Mandatory = false, HelpMessage = "Recover the web app's configuration in addition to files.", ValueFromPipelineByPropertyName = true)]
        public SwitchParameter RecoverConfiguration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The app that the snapshot contents will be restored to. Must be a slot of the original app. If unspecified, the original app is overwritten.", ValueFromPipelineByPropertyName = true)]
        public Site TargetApp { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Allows the original web app to be overwritten without displaying a warning.", ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            switch (ParameterSetName)
            {
                case SnapshotParameterSetName:
                    ResourceGroupName = WebAppSnapshot.ResourceGroupName;
                    Name = WebAppSnapshot.Name;
                    Slot = WebAppSnapshot.Slot;
                    SnapshotTime = WebAppSnapshot.SnapshotTime;
                    break;
            }
            SnapshotRecoveryTarget target = null;
            if (this.TargetApp != null)
            {
                string webAppName, slotName;
                CmdletHelpers.TryParseAppAndSlotNames(Name, out webAppName, out slotName);
                if (!string.Equals(this.TargetApp.ResourceGroup, this.ResourceGroupName, StringComparison.InvariantCultureIgnoreCase) ||
                    !string.Equals(webAppName, this.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new PSArgumentException("Target app must be a slot of the source web app");
                }
                target = new SnapshotRecoveryTarget()
                {
                    Location = TargetApp.Location,
                    Id = TargetApp.Id
                };
            }
            SnapshotRecoveryRequest recoveryReq = new SnapshotRecoveryRequest()
            {
                Overwrite = true,
                SnapshotTime = this.SnapshotTime.ToString("o"),
                RecoverConfiguration = this.RecoverConfiguration,
                IgnoreConflictingHostNames = true,
                RecoveryTarget = target
            };
            Action recoverAction = () => WebsitesClient.RecoverSite(ResourceGroupName, Name, Slot, recoveryReq);
            ConfirmAction(TargetApp != null || this.Force.IsPresent, "Original web app contents will be overwritten with the contents of the snapshot.",
                "The snapshot has been restored.", Name, recoverAction);
        }
    }
}
