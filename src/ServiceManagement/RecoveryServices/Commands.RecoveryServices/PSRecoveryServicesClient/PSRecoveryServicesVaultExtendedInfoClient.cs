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

using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Gets Vault Extended Information
        /// </summary>
        /// <returns>Vault Extended Information Response</returns>
        public async Task<ResourceExtendedInformation> GetExtendedInfo()
        {
            ResourceExtendedInformationResponse response = await this.GetSiteRecoveryClient().VaultExtendedInfo.GetExtendedInfoAsync(this.GetRequestHeaders(false));

            return response.ResourceExtendedInformation;
        }

        /// <summary>
        /// Creates the extended information for the vault
        /// </summary>
        /// <param name="extendedInfoArgs">extended info to be created</param>
        /// <returns>Vault Extended Information</returns>
        public OperationResponse CreateExtendedInfo(ResourceExtendedInformationArgs extendedInfoArgs)
        {
            return this.GetSiteRecoveryClient().VaultExtendedInfo.CreateExtendedInfo(extendedInfoArgs, this.GetRequestHeaders(false));
        }
    }
}
