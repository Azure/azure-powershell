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
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.RecoveryServices.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Method to retrieve cloud services list for the current subscription
        /// </summary>
        /// <returns>list of cloud services.</returns>
        public IEnumerable<CloudService> GetCloudServices()
        {
            CloudServiceListResponse response = this.GetRecoveryServicesClient.CloudServices.List();

            return response.CloudServices;
        }

        /// <summary>
        /// Method to get Cloud Service object for a given vault
        /// </summary>
        /// <param name="vaultName">vault name</param>
        /// <param name="region">vault region</param>
        /// <returns>cloud service object.</returns>
        public CloudService GetCloudServiceForVault(string vaultName, string region)
        {
            IEnumerable<CloudService> cloudServiceList = this.GetCloudServices();
            CloudService cloudServiceToReturn = null;

            foreach (var cloudService in cloudServiceList)
            {
                Vault selectedVault = null;
                if (cloudService.GeoRegion == region)
                {
                    foreach (var vault in cloudService.Resources)
                    {
                        if (vault.Name == vaultName)
                        {
                            selectedVault = vault;
                            break;
                        }
                    }
                }

                if (selectedVault != null)
                {
                    cloudServiceToReturn = cloudService;
                    break;
                }
            }

            return cloudServiceToReturn;
        }
    }
}
