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


using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    ///     Gets the status of an Azure Web App backup
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmWebAppBackupList"), OutputType(typeof(AzureWebAppBackup[]))]
    public class GetAzureWebAppBackupList : WebAppOptionalSlotBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var list = WebsitesClient.ListSiteBackups(ResourceGroupName, Name, Slot).Value;
            AzureWebAppBackup[] backups = new AzureWebAppBackup[list.Count];
            for (int i = 0; i < backups.Length; i++)
            {
                backups[i] = BackupRestoreUtils.BackupItemToAppBackup(list[i], ResourceGroupName, Name, Slot);
            }
            WriteObject(backups, true);
        }
    }
}