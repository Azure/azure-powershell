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
        ///     Gets a particular Azure Site Recovery Network under a Server
        /// </summary>
        /// <param name="fabricName">Fabric name</param>
        /// <param name="networkName">Network name</param>
        /// <returns>Network response</returns>
        public Network GetAzureSiteRecoveryNetwork(
            string fabricName,
            string networkName)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationNetworks.GetWithHttpMessagesAsync(
                    fabricName,
                    networkName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Gets all Azure Site Recovery Networks.
        /// </summary>
        /// <returns>Network list response</returns>
        public List<Network> GetAzureSiteRecoveryNetworks()
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationNetworks.ListWithHttpMessagesAsync(this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationNetworks.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));
            pages.Insert(
                0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets all Azure Site Recovery Networks under a Server
        /// </summary>
        /// <param name="fabricName">Fabric name</param>
        /// <returns>Network list response</returns>
        public List<Network> GetAzureSiteRecoveryNetworks(
            string fabricName)
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationNetworks.ListByReplicationFabricsWithHttpMessagesAsync(
                    fabricName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationNetworks.ListByReplicationFabricsNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));
            pages.Insert(
                0,
                firstPage);

            return Utilities.IpageToList(pages);
        }
    }
}