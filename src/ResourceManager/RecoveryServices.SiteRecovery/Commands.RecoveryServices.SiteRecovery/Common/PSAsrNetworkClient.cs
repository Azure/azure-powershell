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
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        ///     Gets all Azure Site Recovery Networks.
        /// </summary>
        /// <returns>Network list response</returns>
        public List<Network> GetAzureSiteRecoveryNetworks()
        {
            var firstPage = GetSiteRecoveryClient()
                .ReplicationNetworks.ListWithHttpMessagesAsync(GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(GetSiteRecoveryClient()
                    .ReplicationNetworks.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                GetRequestHeaders(true));
            pages.Insert(0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets all Azure Site Recovery Networks under a Server
        /// </summary>
        /// <param name="serverId">Server ID</param>
        /// <returns>Network list response</returns>
        public List<Network> GetAzureSiteRecoveryNetworks(string fabricName)
        {
            var firstPage = GetSiteRecoveryClient()
                .ReplicationNetworks.ListByReplicationFabricsWithHttpMessagesAsync(fabricName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(GetSiteRecoveryClient()
                    .ReplicationNetworks.ListByReplicationFabricsNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                GetRequestHeaders(true));
            pages.Insert(0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets a particular Azure Site Recovery Network under a Server
        /// </summary>
        /// <param name="fabricName">Fabric name</param>
        /// <param name="networkName">Network name</param>
        /// <returns>Network response</returns>
        public Network GetAzureSiteRecoveryNetwork(string fabricName,
            string networkName)
        {
            return GetSiteRecoveryClient()
                .ReplicationNetworks.GetWithHttpMessagesAsync(fabricName,
                    networkName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }
    }
}