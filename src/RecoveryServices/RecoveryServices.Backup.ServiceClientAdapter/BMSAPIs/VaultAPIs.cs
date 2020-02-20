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
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        public List<string> ListVaults()
        {
            var response = RSAdapter.Client.Vaults.ListBySubscriptionIdWithHttpMessagesAsync(
                cancellationToken: RSAdapter.CmdletCancellationToken).Result;
            return response.Body.Select(vault => vault.Id).ToList();
        }
        public BackupResourceVaultConfigResource SetVaultProperty(string vaultName, string resourceGroupName,
            BackupResourceVaultConfigResource param)
        {
            return BmsAdapter.Client.BackupResourceVaultConfigs.UpdateWithHttpMessagesAsync(
                vaultName, resourceGroupName, param).Result.Body;
        }

        public BackupResourceVaultConfigResource GetVaultProperty(string vaultName, string resourceGroupName)
        {
            return BmsAdapter.Client.BackupResourceVaultConfigs.GetWithHttpMessagesAsync(
                vaultName, resourceGroupName).Result.Body;
        }
    }
}
