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
        ///     Retrieves list of recovery points for a Migration Item.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="migrationItemName">Migration item name</param>
        /// <returns>List of migration recovery points</returns>
        public List<MigrationRecoveryPoint> GetAzureSiteRecoveryMigrationRecoveryPoints(
            string fabricName,
            string protectionContainerName,
            string migrationItemName)
        {
            var firstPage = this.GetSiteRecoveryClient()
                .MigrationRecoveryPoints
                .ListByReplicationMigrationItemsWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    migrationItemName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;

            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .MigrationRecoveryPoints
                    .ListByReplicationMigrationItemsNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));

            pages.Insert(0, firstPage);
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Retrieves recovery point for a Migration Item and migration recovery point name.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="migrationItemName">Migration item name</param>
        /// <param name="migrationRecoveryPointName">The migration recovery point name.</param>
        /// <returns>Migration recovery point object</returns>
        public MigrationRecoveryPoint GetAzureSiteRecoveryMigrationRecoveryPoint(
            string fabricName,
            string protectionContainerName,
            string migrationItemName,
            string migrationRecoveryPointName)
        {
            return this.GetSiteRecoveryClient()
                .MigrationRecoveryPoints.GetWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    migrationItemName,
                    migrationRecoveryPointName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }
    }
}