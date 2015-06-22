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

using Microsoft.Azure.Commands.AzureBackup.Helpers;
using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Management.BackupServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CmdletModel = Microsoft.Azure.Commands.AzureBackup.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// API to download the azure backup vault's credentials.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureBackupVault"), OutputType(typeof(CmdletModel.AzurePSBackupVault))]
    public class SetAzureBackupVault : AzureBackupVaultCmdletBase
    {
        [Parameter(Position = 1, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.StorageType)]
        public AzureBackupVaultStorageType? Storage { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.Sku)]
        [ValidateSet("standard")]
        public string Sku { get; set; }

        // TODO: Add support for tags
        //[Alias("Tags")]
        //[Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ResourceTags)]
        //public Hashtable[] Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                if (Sku != null)
                {
                    WriteDebug(String.Format("Updating Sku, Sku: {0}", Sku));
                    AzureBackupClient.CreateOrUpdateAzureBackupVault(vault.ResourceGroupName, vault.Name, vault.Region, Sku);
                }

                if (Storage.HasValue)
                {
                    WriteDebug(String.Format("Setting storage type for the resource, Type: {0}", Storage));

                    AzureBackupClient.UpdateStorageType(Storage.ToString());
                }

                var backupVault = AzureBackupClient.GetVault(vault.ResourceGroupName, vault.Name);
                WriteObject(VaultHelpers.GetCmdletVault(backupVault, AzureBackupClient.GetStorageTypeDetails(vault.ResourceGroupName, vault.Name)));
            });
        }
    }
}
