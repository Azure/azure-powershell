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
using AutoMapper;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.Rest.Azure.OData;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        ///     Retrieves Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <returns>Protection entity list response</returns>
        public List<ReplicationProtectedItem> GetAzureSiteRecoveryReplicationProtectedItem(
            string fabricName,
            string protectionContainerName)
        {
            var firstPage = GetSiteRecoveryClient()
                .ReplicationProtectedItems
                .ListByReplicationProtectionContainersWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(GetSiteRecoveryClient()
                    .ReplicationProtectedItems
                    .ListByReplicationProtectionContainersNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                GetRequestHeaders(true));
            pages.Insert(0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Retrieves Protected Items.
        /// </summary>
        /// <param name="protectionContainerName">Recovery Plan Name</param>
        /// <param name="sourceFabricName">Source Fabric Name</param>
        /// <returns>Protection entity list response</returns>
        public List<ReplicationProtectedItem> GetAzureSiteRecoveryReplicationProtectedItemInRP(
            string recoveryPlanName)
        {
            var protectedItemsQueryParameter =
                new ProtectedItemsQueryParameter {RecoveryPlanName = recoveryPlanName};
            var odataQuery =
                new ODataQuery<ProtectedItemsQueryParameter>(protectedItemsQueryParameter
                    .ToQueryString());
            var firstPage = GetSiteRecoveryClient()
                .ReplicationProtectedItems.ListWithHttpMessagesAsync(odataQuery,
                    null,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(GetSiteRecoveryClient()
                    .ReplicationProtectedItems.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                GetRequestHeaders(true));
            pages.Insert(0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Retrieves Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="replicatedProtectedItemName">Virtual Machine Name</param>
        /// <returns>Replicated Protected Item response</returns>
        public ReplicationProtectedItem GetAzureSiteRecoveryReplicationProtectedItem(
            string fabricName,
            string protectionContainerName,
            string replicatedProtectedItemName)
        {
            return GetSiteRecoveryClient()
                .ReplicationProtectedItems.GetWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    replicatedProtectedItemName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Creates Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="replicationProtectedItemName">Virtual Machine ID or Replication group Id</param>
        /// <param name="input">Enable protection input.</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation EnableProtection(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            EnableProtectionInput input)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationProtectedItems.BeginCreateWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    replicationProtectedItemName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Removes Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="replicationProtectedItemName">Virtual Machine ID or Replication group Id</param>
        /// <param name="input">Disable protection input.</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation DisableProtection(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            DisableProtectionInput input)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationProtectedItems.BeginDeleteWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    replicationProtectedItemName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Purges Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="replicationProtectedItemName">Virtual Machine ID or Replication group Id</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation PurgeProtection(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationProtectedItems.BeginPurgeWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    replicationProtectedItemName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Starts Planned Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Itenm</param>
        /// <param name="input">Input for Planned Failover</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryPlannedFailover(
            string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            PlannedFailoverInput input)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationProtectedItems.BeginPlannedFailoverWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    replicationProtectedItemName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Starts Unplanned Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <param name="input">Input for Unplanned failover</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryUnplannedFailover(
            string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            UnplannedFailoverInput input)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationProtectedItems.BeginUnplannedFailoverWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    replicationProtectedItemName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Starts Test Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <param name="input">Input for Test failover</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryTestFailover(
            string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            TestFailoverInput input)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationProtectedItems.BeginTestFailoverWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    replicationProtectedItemName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Start applying Recovery Point.
        /// </summary>
        /// <param name="fabricName">Fabric Name.</param>
        /// <param name="protectionContainerName">Protection Conatiner Name.</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item.</param>
        /// <param name="input">Input for applying recovery point.</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryApplyRecoveryPoint(
            string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            ApplyRecoveryPointInput input)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationProtectedItems.BeginApplyRecoveryPointWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    replicationProtectedItemName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Starts Commit Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryCommitFailover(
            string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationProtectedItems.BeginFailoverCommitWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    replicationProtectedItemName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Re-protects the Azure Site Recovery protection entity.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <param name="input">Input for Reprotect</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryReprotection(
            string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            ReverseReplicationInput input)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationProtectedItems.BeginReprotectWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    replicationProtectedItemName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Update Azure VM Properties
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <param name="input">Update Replication Protected Item Input</param>
        /// <returns></returns>
        public PSSiteRecoveryLongRunningOperation UpdateVmProperties(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            UpdateReplicationProtectedItemInput input)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationProtectedItems.BeginUpdateWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    replicationProtectedItemName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}