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

using Microsoft.WindowsAzure.Management.RecoveryServices;
using Microsoft.WindowsAzure.Management.RecoveryServices.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Method to create Azure Site Recovery Vault
        /// </summary>
        /// <param name="cloudServiceName">name of the cloud service</param>
        /// <param name="vaultName">name of the vault</param>
        /// <param name="vaultCreateInput">vault creation input object</param>
        /// <returns>creation response object.</returns>
        public RecoveryServicesOperationStatusResponse CreateVault(string cloudServiceName, string vaultName, VaultCreateArgs vaultCreateInput)
        {
            return this.GetRecoveryServicesClient.Vaults.Create(cloudServiceName, vaultName, vaultCreateInput);
        }
    }
}
