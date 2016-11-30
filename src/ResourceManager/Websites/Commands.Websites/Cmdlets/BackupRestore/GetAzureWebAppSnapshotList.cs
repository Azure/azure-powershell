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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.BackupRestore
{
    /// <summary>
    /// Gets the status of an Azure Web App backup
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmWebAppSnapshotList"), OutputType(typeof(SnapshotCollection))]
    public class GetAzureWebAppSnapshotList : WebAppOptionalSlotBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            IList<Snapshot> snapshotCollection = WebsitesClient.GetSiteSnapshots(ResourceGroupName, Name, Slot).Value;
            AzureWebAppSnapshot[] snapshots = snapshotCollection.Select(snapshot => new AzureWebAppSnapshot()
            {
                Name = this.Name,
                Slot = this.Slot,
                ResourceGroupName = this.ResourceGroupName,
                SnapshotTime = snapshot.Time.Value
            }).ToArray();
            WriteObject(snapshots, true);
        }
    }
}
