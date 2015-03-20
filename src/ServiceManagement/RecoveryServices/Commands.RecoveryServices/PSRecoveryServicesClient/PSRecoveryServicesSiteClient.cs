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

using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Method to get the Azure site recovery sites
        /// </summary>
        /// <param name="vault">vault object</param>
        /// <returns>Site list response</returns>
        public SiteListResponse GetAzureSiteRecoverySites(ASRVault vault = null)
        {
            if (vault != null)
            {
                Utilities.UpdateVaultSettings(new ASRVaultCreds()
                {
                    CloudServiceName = vault.CloudServiceName,
                    ResourceName = vault.Name
                });
            }

            return this.GetSiteRecoveryClient().Sites.List(this.GetRequestHeaders(false));
        }

        /// <summary>
        /// Method to create a Site
        /// </summary>
        /// <param name="siteName">name of the site</param>
        /// <param name="siteType">type of the site</param>
        /// <param name="vault">vault object</param>
        /// <returns>job object for the creation.</returns>
        public JobResponse CreateAzureSiteRecoverySite(string siteName, string siteType = null, ASRVault vault = null)
        {
            if (vault != null)
            {
                Utilities.UpdateVaultSettings(new ASRVaultCreds()
                {
                    CloudServiceName = vault.CloudServiceName,
                    ResourceName = vault.Name
                });
            }

            if (string.IsNullOrEmpty(siteType))
            {
                siteType = FabricProviders.HyperVSite;
            }

            SiteCreationInput input = new SiteCreationInput()
            {
                Name = siteName,
                FabricType = siteType
            };

            return this.GetSiteRecoveryClient().Sites.Create(input, this.GetRequestHeaders(false));
        }
    }
}
