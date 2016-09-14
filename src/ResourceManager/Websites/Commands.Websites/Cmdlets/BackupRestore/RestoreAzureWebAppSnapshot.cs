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
using Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.BackupRestore
{
    /// <summary>
    /// Restores an Azure Web App from a snapshot
    /// </summary>
    [Cmdlet(VerbsData.Restore, "AzureRmWebAppSnapshot"), OutputType(typeof(RecoverResponse))]
    public class RestoreAzureWebAppSnapshot : WebAppOptionalSlotBaseCmdlet
    {
        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The web app's content will be reverted to this point in time.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public DateTime SnapshotTime;

        [Parameter(Mandatory = false, HelpMessage = "The name of the web app that will contain the restored data. The app will be created if it does not already exist. If this is left empty, the source web app will be overwritten with the restored data.")]
        public string TargetSiteName;

        [Parameter(Mandatory = false, HelpMessage = "The name of the slot that will contain the restored data. The slot will be created if it does not already exist.")]
        public string TargetSlotName;

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            CsmSiteRecoveryEntity entity = new CsmSiteRecoveryEntity()
            {
                RecoverConfig = false,
                SnapshotTime = this.SnapshotTime,
                SiteName = this.TargetSiteName,
                SlotName = this.TargetSlotName
            };
            WriteObject(WebsitesClient.RecoverSite(ResourceGroupName, Name, Slot, entity));
        }
    }
}
