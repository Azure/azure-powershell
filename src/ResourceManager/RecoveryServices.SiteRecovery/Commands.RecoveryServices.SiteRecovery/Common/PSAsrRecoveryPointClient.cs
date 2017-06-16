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
        ///     Gets the list of recovery points for a replicationProtectedItem.
        /// </summary>
        /// <param name="fabricName">Fabric name.</param>
        /// <param name="protectionContainerName">Protection container name.</param>
        /// <param name="replicationProtectedItemName">Replication protected item name.</param>
        /// <returns>List of recovery points.</returns>
        public List<RecoveryPoint> GetAzureSiteRecoveryRecoveryPoint(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName)
        {
            var firstPage = GetSiteRecoveryClient()
                .RecoveryPoints.ListByReplicationProtectedItemsWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    replicationProtectedItemName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(GetSiteRecoveryClient()
                    .RecoveryPoints.ListByReplicationProtectedItemsNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                GetRequestHeaders(true));
            pages.Insert(0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets recovery point for a replicationProtectedItem and recovery point name.
        /// </summary>
        /// <param name="fabricName">Fabric name.</param>
        /// <param name="protectionContainerName">Protection container name.</param>
        /// <param name="replicationProtectedItemName">Replication protected item name.</param>
        /// <param name="recoveryPointName">Recovery point name.</param>
        /// <returns>Recovery point.</returns>
        public RecoveryPoint GetAzureSiteRecoveryRecoveryPoint(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            string recoveryPointName)
        {
            return GetSiteRecoveryClient()
                .RecoveryPoints.GetWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    replicationProtectedItemName,
                    recoveryPointName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }
    }
}