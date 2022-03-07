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
using System.Linq;
using System.Management.Automation;
using System.Globalization;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.BackupRestore
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppSnapshot"), OutputType(typeof(AzureWebAppSnapshot))]
    public class GetAzureWebAppSnapshot : WebAppOptionalSlotBaseCmdlet
    {

        [Parameter(Mandatory = false, HelpMessage = "Read the snapshots from a secondary scale unit.")]
        public SwitchParameter UseDisasterRecovery { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var list = WebsitesClient.GetSiteSnapshots(ResourceGroupName, Name, Slot, UseDisasterRecovery.IsPresent).Select(s => {
                return new AzureWebAppSnapshot()
                {
                    ResourceGroupName = this.ResourceGroupName,
                    Name = this.Name,
                    Slot = string.IsNullOrEmpty(this.Slot) ? "Production" : this.Slot,
                    SnapshotTime = DateTime.Parse(s.Time, CultureInfo.InvariantCulture)
                };
            }).OrderByDescending(s => s.SnapshotTime).ToArray();
            WriteObject(list, true);
        }
    }
}
