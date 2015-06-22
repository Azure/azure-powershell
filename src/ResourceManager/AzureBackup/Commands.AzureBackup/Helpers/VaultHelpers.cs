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
using System.Collections.Generic;
using System.Xml;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using System.Threading;
using Hyak.Common;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using System.Net;
using ClientModel = Microsoft.Azure.Management.BackupServices.Models;
using CmdletModel = Microsoft.Azure.Commands.AzureBackup.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.AzureBackup.Helpers
{   
    public static class VaultHelpers
    {
        /// <summary>
        /// Gets CmdletModel of backup vault from Client model
        /// </summary>
        /// <param name="vault"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public static CmdletModel.AzurePSBackupVault GetCmdletVault(ClientModel.AzureBackupVault vault, string storageType)
        {
            var response = new CmdletModel.AzurePSBackupVault
            {
                ResourceId = vault.Id,
                Name = vault.Name,
                Region = vault.Location,
                ResourceGroupName = GetResourceGroup(vault.Id),
                Sku = (vault.Properties != null) ? vault.Properties.Sku.Name : null,
                Storage = storageType,
            };

            return response;
        }

        /// <summary>
        /// Gets ResourceGroup from vault ID
        /// </summary>
        /// <param name="vaultId"></param>
        /// <returns></returns>
        public static string GetResourceGroup(string vaultId)
        {
            string[] tokens = vaultId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            return tokens[3];
        }
    }
}
