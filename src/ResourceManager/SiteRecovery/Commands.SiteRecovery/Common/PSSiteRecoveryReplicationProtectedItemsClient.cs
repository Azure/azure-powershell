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

using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Retrieves Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <returns>Protection entity list response</returns>
        public ReplicationProtectedItemListResponse GetAzureSiteRecoveryReplicationProtectedItem(string fabricName,
            string protectionContainerName)
        {
            return
                this
                .GetSiteRecoveryClient()
                .ReplicationProtectedItem.List(fabricName, protectionContainerName, this.GetRequestHeaders());
        }

        /// <summary>
        /// Retrieves Protected Items.
        /// </summary>
        /// <param name="protectionContainerName">Recovery Plan Name</param>
        /// <param name="sourceFabricName">Source Fabric Name</param>
        /// <returns>Protection entity list response</returns>
        public ReplicationProtectedItemListResponse GetAzureSiteRecoveryReplicationProtectedItemInRP(string recoveryPlanName)
        {
            ReplicationProtectedItemListResponse output = new ReplicationProtectedItemListResponse();
            List<ReplicationProtectedItem> replicationProtectedItems = new List<ReplicationProtectedItem>();

            var protectedItemsQueryParameter = new ProtectedItemsQueryParameter()
            {
                RecoveryPlanName = recoveryPlanName
            };
            ReplicationProtectedItemListResponse response = this
                .GetSiteRecoveryClient()
                .ReplicationProtectedItem.ListAll(null, protectedItemsQueryParameter, this.GetRequestHeaders());
            replicationProtectedItems.AddRange(response.ReplicationProtectedItems);
            while (response.NextLink != null)
            {
                response = this
                    .GetSiteRecoveryClient()
                    .ReplicationProtectedItem.ListAllNext(response.NextLink, this.GetRequestHeaders());
                replicationProtectedItems.AddRange(response.ReplicationProtectedItems);
            }

            output.ReplicationProtectedItems = replicationProtectedItems;
            return output;
        }

        /// <summary>
        /// Retrieves Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="replicatedProtectedItemName">Virtual Machine Name</param>
        /// <returns>Replicated Protected Item response</returns>
        public ReplicationProtectedItemResponse GetAzureSiteRecoveryReplicationProtectedItem(string fabricName,
            string protectionContainerName,
            string replicatedProtectedItemName)
        {
            return
                this
                .GetSiteRecoveryClient()
                .ReplicationProtectedItem
                .Get(fabricName, protectionContainerName, replicatedProtectedItemName, this.GetRequestHeaders());
        }

        /// <summary>
        /// Creates Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="replicationProtectedItemName">Virtual Machine ID or Replication group Id</param>
        /// <param name="input">Enable protection input.</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse EnableProtection(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            EnableProtectionInput input)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginEnableProtection(
                fabricName,
                protectionContainerName,
                replicationProtectedItemName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Removes Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="replicationProtectedItemName">Virtual Machine ID or Replication group Id</param>
        /// <param name="input">Disable protection input.</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse DisableProtection(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            DisableProtectionInput input)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginDisableProtection(
                fabricName,
                protectionContainerName,
                replicationProtectedItemName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Purges Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="replicationProtectedItemName">Virtual Machine ID or Replication group Id</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse PurgeProtection(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginPurgeProtection(
                fabricName,
                protectionContainerName,
                replicationProtectedItemName,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Planned Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Itenm</param>
        /// <param name="input">Input for Planned Failover</param>
        /// <returns>Job Response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryPlannedFailover(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            PlannedFailoverInput input)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginPlannedFailover(fabricName,
                protectionContainerName,
                replicationProtectedItemName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Unplanned Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <param name="input">Input for Unplanned failover</param>
        /// <returns>Job Response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryUnplannedFailover(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            UnplannedFailoverInput input)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginUnplannedFailover(
                fabricName,
                protectionContainerName,
                replicationProtectedItemName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Test Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <param name="input">Input for Test failover</param>
        /// <returns>Job Response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryTestFailover(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            TestFailoverInput input)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginTestFailover(
                fabricName,
                protectionContainerName,
                replicationProtectedItemName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Commit Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <returns>Job Response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryCommitFailover(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginCommitFailover(
                 fabricName,
                 protectionContainerName,
                 replicationProtectedItemName,
                 this.GetRequestHeaders());
        }

        /// <summary>
        /// Re-protects the Azure Site Recovery protection entity.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <param name="input">Input for Reprotect</param>
        /// <returns>Job Response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryReprotection(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            ReverseReplicationInput input)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginReprotect(
                fabricName,
                protectionContainerName,
                replicationProtectedItemName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Write Protection Entities
        /// </summary>
        /// <param name="protectableItems">List of protectable items</param>
        internal List<T> FetchProtectionEntitiesData<T>(IList<ProtectableItem> protectableItems, string protectionContainerId, string protectionContainerName)
        {
            List<ASRProtectionEntity> asrProtectionEntityList = new List<ASRProtectionEntity>();
            Dictionary<string, Policy> policyCache = new Dictionary<string, Policy>();
            Dictionary<string, ReplicationProtectedItem> protectedItemCache = new Dictionary<string, ReplicationProtectedItem>();

            // Check even if an single item is protected then we will get all the protecteditems & policies.
            if (protectableItems.Select(p => 0 == string.Compare(p.Properties.ProtectionStatus, "protected", StringComparison.OrdinalIgnoreCase)) != null)
            {
                // Get all the protected items for the container.
                ReplicationProtectedItemListResponse ReplicationProtectedItemListResponse =
                    this.GetAzureSiteRecoveryReplicationProtectedItem(
                    Utilities.GetValueFromArmId(protectionContainerId, ARMResourceTypeConstants.ReplicationFabrics),
                    protectionContainerName);

                // Fill all protected items in dictionary for quick access.
                foreach (ReplicationProtectedItem protectedItem in ReplicationProtectedItemListResponse.ReplicationProtectedItems)
                {
                    protectedItemCache.Add(protectedItem.Name.ToLower(), protectedItem);
                }

                // Get all policies and fill up the dictionary once for quick access.
                PolicyListResponse policyListResponse = this.GetAzureSiteRecoveryPolicy();
                foreach (Policy policy in policyListResponse.Policies)
                {
                    policyCache.Add(policy.Name.ToLower(), policy);
                }
            }

            List<T> entities = new List<T>();
            // Fill up powershell entity with all the data.
            foreach (ProtectableItem protectableItem in protectableItems)
            {
                if (0 == string.Compare(protectableItem.Properties.ProtectionStatus, "protected", StringComparison.OrdinalIgnoreCase))
                {
                    string protectedItemName = Utilities.GetValueFromArmId(
                        protectableItem.Properties.ReplicationProtectedItemId, ARMResourceTypeConstants.ReplicationProtectedItems).ToLower();
                    ReplicationProtectedItem protectedItem = protectedItemCache[protectedItemName];

                    string policyName = Utilities.GetValueFromArmId(protectedItem.Properties.PolicyID, ARMResourceTypeConstants.ReplicationPolicies).ToLower();
                    Policy asrPolicy = policyCache[policyName];

                    if (typeof(T) == typeof(ASRVirtualMachine))
                    {
                        entities.Add((T)Convert.ChangeType(new ASRVirtualMachine(protectableItem, protectedItem, asrPolicy), typeof(T)));
                    }
                    else
                    {
                        entities.Add((T)Convert.ChangeType(new ASRProtectionEntity(protectableItem, protectedItem, asrPolicy), typeof(T)));
                    }
                }
                else
                {
                    if (typeof(T) == typeof(ASRVirtualMachine))
                    {
                        entities.Add((T)Convert.ChangeType(new ASRVirtualMachine(protectableItem), typeof(T)));
                    }
                    else
                    {
                        entities.Add((T)Convert.ChangeType(new ASRProtectionEntity(protectableItem), typeof(T)));
                    }

                }
            }

            asrProtectionEntityList.Sort((x, y) => x.FriendlyName.CompareTo(y.FriendlyName));
            return entities;
        }

        /// <summary>
        /// Write Protection Entity
        /// </summary>
        /// <param name="protectableItem"></param>
        internal T FetchProtectionEntityData<T>(ProtectableItem protectableItem, string protectionContainerId, string protectionContainerName)
        {
            ReplicationProtectedItemResponse replicationProtectedItemResponse = null;
            if (!String.IsNullOrEmpty(protectableItem.Properties.ReplicationProtectedItemId))
            {
                replicationProtectedItemResponse = this.GetAzureSiteRecoveryReplicationProtectedItem(
                    Utilities.GetValueFromArmId(protectionContainerId, ARMResourceTypeConstants.ReplicationFabrics),
                    protectionContainerName,
                    Utilities.GetValueFromArmId(protectableItem.Properties.ReplicationProtectedItemId, ARMResourceTypeConstants.ReplicationProtectedItems));
            }

            if (replicationProtectedItemResponse != null && replicationProtectedItemResponse.ReplicationProtectedItem != null)
            {
                PolicyResponse policyResponse = this.GetAzureSiteRecoveryPolicy(Utilities.GetValueFromArmId(
                    replicationProtectedItemResponse.ReplicationProtectedItem.Properties.PolicyID, ARMResourceTypeConstants.ReplicationPolicies));
                if (typeof(T) == typeof(ASRVirtualMachine))
                {
                    var pe = new ASRVirtualMachine(protectableItem, replicationProtectedItemResponse.ReplicationProtectedItem, policyResponse.Policy);
                    return (T)Convert.ChangeType(pe, typeof(T));
                }
                else
                {
                    var pe = new ASRProtectionEntity(protectableItem, replicationProtectedItemResponse.ReplicationProtectedItem, policyResponse.Policy);
                    return (T)Convert.ChangeType(pe, typeof(T));
                }

            }
            else
            {
                if (typeof(T) == typeof(ASRVirtualMachine))
                {
                    var pe = new ASRVirtualMachine(protectableItem);
                    return (T)Convert.ChangeType(pe, typeof(T));
                }
                else
                {
                    var pe = new ASRProtectionEntity(protectableItem);
                    return (T)Convert.ChangeType(pe, typeof(T));
                }
            }
        }

    }
}