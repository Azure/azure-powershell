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

using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.Rest.Azure.OData;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        ///     Retrieves Replication Migration Item.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="migrationItemName">Migration item name</param>
        /// <returns>Replicated Migration Item response</returns>
        public MigrationItem GetAzureSiteRecoveryReplicationMigrationItem(
            string fabricName,
            string protectionContainerName,
            string migrationItemName)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationMigrationItems.GetWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    migrationItemName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Retrieves Replication Migration Items.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <returns>Migration entity list response</returns>
        public List<MigrationItem> GetAzureSiteRecoveryReplicationMigrationItem(
            string fabricName,
            string protectionContainerName)
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationMigrationItems
                .ListByReplicationProtectionContainersWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;

            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationMigrationItems
                    .ListByReplicationProtectionContainersNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));

            pages.Insert(0, firstPage);
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Retrieves Replication Migration Items in the vault.
        /// </summary>
        /// /// <param name="parameters">Migration Items Query parameters.</param>
        /// <returns>Migration entity list response</returns>
        public List<MigrationItem> ListAzureSiteRecoveryReplicationMigrationItems(
            MigrationItemsQueryParameter parameters)
        {
            var odataQuery = new ODataQuery<MigrationItemsQueryParameter>(parameters.ToQueryString());
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationMigrationItems.ListWithHttpMessagesAsync(
                    odataQuery,
                    null,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationMigrationItems
                    .ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));

            pages.Insert(0, firstPage);
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Creates Replication Migration Item.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="migrationItemName">Migration Item Name</param>
        /// <param name="input">Enable migration input.</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation EnableMigration(
            string fabricName,
            string protectionContainerName,
            string migrationItemName,
            EnableMigrationInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationMigrationItems.BeginCreateWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    migrationItemName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Updates Replication Migration Item.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="migrationItemName">Migration Item Name</param>
        /// <param name="input">Update migration input.</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation UpdateMigrationItem(
            string fabricName,
            string protectionContainerName,
            string migrationItemName,
            UpdateMigrationItemInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationMigrationItems.BeginUpdateWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    migrationItemName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Deletes the Replication Migration Item.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="migrationItemName">Migration Item Name</param>
        /// <param name="deleteOption">The delete option.</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation DisableMigration(
            string fabricName,
            string protectionContainerName,
            string migrationItemName,
            string deleteOption)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationMigrationItems.BeginDeleteWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    migrationItemName,
                    deleteOption,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Migration Item.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="migrationItemName">Migration Item Name</param>
        /// <param name="input">Migration input.</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryMigration(
            string fabricName,
            string protectionContainerName,
            string migrationItemName,
            MigrateInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationMigrationItems.BeginMigrateWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    migrationItemName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///  Starts Test Migration.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="migrationItemName">Migration Item Name</param>
        /// <param name="input">Test Migration input.</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryTestMigration(
            string fabricName,
            string protectionContainerName,
            string migrationItemName,
            TestMigrateInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationMigrationItems.BeginTestMigrateWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    migrationItemName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///  Starts Test Migration Cleanup.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="migrationItemName">Migration Item Name</param>
        /// <param name="input">Test Migration cleanup input.</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryTestMigrationCleanup(
            string fabricName,
            string protectionContainerName,
            string migrationItemName,
            TestMigrateCleanupInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationMigrationItems.BeginTestMigrateCleanupWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    migrationItemName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///   Resynchronizes replication.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="migrationItemName">Migration Item Name</param>
        /// <param name="input">Test Migration cleanup input.</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryResynchronizeReplication(
            string fabricName,
            string protectionContainerName,
            string migrationItemName,
            ResyncInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationMigrationItems.BeginResyncWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    migrationItemName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}
