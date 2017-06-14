﻿// ----------------------------------------------------------------------------------
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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure.OData;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using RestAzureNS = Microsoft.Rest.Azure;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    /// <summary>
    /// This class implements methods for AzureSql backup provider
    /// </summary>
    public class AzureSqlPsBackupProvider : IPsBackupProvider
    {
        private const int defaultOperationStatusRetryTimeInMilliSec = 5 * 1000; // 5 sec
        private const string separator = ";";
        private const string computeAzureVMVersion = "Microsoft.Compute";
        private const string classicComputeAzureVMVersion = "Microsoft.ClassicCompute";
        private const string extendedInfo = "extendedinfo";
        private const int maxRestoreDiskTimeRange = 30;
        private const CmdletModel.RetentionDurationType defaultSqlRetentionType =
            CmdletModel.RetentionDurationType.Months;
        private const int defaultSqlRetentionCount = 10;

        Dictionary<Enum, object> ProviderData { get; set; }
        ServiceClientAdapter ServiceClientAdapter { get; set; }

        /// <summary>
        /// Initializes the provider with the data recieved from the cmdlet layer
        /// </summary>
        /// <param name="providerData">Data from the cmdlet layer intended for the provider</param>
        /// <param name="serviceClientAdapter">Service client adapter for communicating with the backend service</param>
        public void Initialize(
            Dictionary<Enum, object> providerData,
            ServiceClientAdapter serviceClientAdapter)
        {
            ProviderData = providerData;
            ServiceClientAdapter = serviceClientAdapter;
        }

        public RestAzureNS.AzureOperationResponse EnableProtection()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Triggers the disable protection operation for the given item
        /// </summary>
        /// <returns>The job response returned from the service</returns>
        public RestAzureNS.AzureOperationResponse DisableProtection()
        {
            bool deleteBackupData = (bool)ProviderData[ItemParams.DeleteBackupData];

            ItemBase itemBase = (ItemBase)ProviderData[ItemParams.Item];
            // do validations

            ValidateAzureSQLDisableProtectionRequest(itemBase);

            Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(itemBase.Id);
            string containerUri = HelperUtils.GetContainerUri(keyValueDict, itemBase.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, itemBase.Id);

            if (deleteBackupData)
            {
                return ServiceClientAdapter.DeleteProtectedItem(
                                containerUri,
                                protectedItemUri);
            }
            else
            {
                throw new Exception(Resources.AzureSqlRetainDataException);
            }
        }

        public RestAzureNS.AzureOperationResponse TriggerBackup()
        {
            throw new NotImplementedException();
        }

        public RestAzureNS.AzureOperationResponse TriggerRestore()
        {
            throw new NotImplementedException();
        }

        public ProtectedItemResource GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetches the detail info for the given recovery point
        /// </summary>
        /// <returns>Recovery point detail as returned by the service</returns>
        public RecoveryPointBase GetRecoveryPointDetails()
        {
            AzureSqlItem item = ProviderData[RecoveryPointParams.Item]
                as AzureSqlItem;

            string recoveryPointId = ProviderData[RecoveryPointParams.RecoveryPointId].ToString();

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            var rpResponse = ServiceClientAdapter.GetRecoveryPointDetails(
                containerUri, protectedItemName, recoveryPointId);
            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpResponse, item);
        }

        /// <summary>
        /// Lists recovery points generated for the given item
        /// </summary>
        /// <returns>List of recovery point PowerShell model objects</returns>
        public List<RecoveryPointBase> ListRecoveryPoints()
        {
            DateTime startDate = (DateTime)(ProviderData[RecoveryPointParams.StartDate]);
            DateTime endDate = (DateTime)(ProviderData[RecoveryPointParams.EndDate]);
            AzureSqlItem item = ProviderData[RecoveryPointParams.Item]
                as AzureSqlItem;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            TimeSpan duration = endDate - startDate;
            if (duration.TotalDays > maxRestoreDiskTimeRange)
            {
                throw new Exception(Resources.RestoreDiskTimeRangeError);
            }

            //we need to fetch the list of RPs
            var queryFilterString = QueryBuilder.Instance.GetQueryString(new BMSRPQueryObject()
            {
                StartDate = startDate,
                EndDate = endDate
            });

            ODataQuery<BMSRPQueryObject> queryFilter = new ODataQuery<BMSRPQueryObject>();
            queryFilter.Filter = queryFilterString;

            List<RecoveryPointResource> rpListResponse = ServiceClientAdapter.GetRecoveryPoints(
                containerUri, protectedItemName, queryFilter);
            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpListResponse, item);
        }

        /// <summary>
        /// Creates policy given the provider data
        /// </summary>
        /// <returns>Created policy object as returned by the service</returns>
        public ProtectionPolicyResource CreatePolicy()
        {
            string policyName = (string)ProviderData[PolicyParams.PolicyName];
            CmdletModel.WorkloadType workloadType =
                (CmdletModel.WorkloadType)ProviderData[PolicyParams.WorkloadType];
            RetentionPolicyBase retentionPolicy =
                ProviderData.ContainsKey(PolicyParams.RetentionPolicy) ?
                (RetentionPolicyBase)ProviderData[PolicyParams.RetentionPolicy] :
                null;

            ValidateAzureSqlWorkloadType(workloadType);

            // validate RetentionPolicy
            ValidateAzureSqlRetentionPolicy(retentionPolicy);
            Logger.Instance.WriteDebug("Validation of Retention policy is successful");

            // construct Hydra policy request            
            ProtectionPolicyResource hydraRequest = new ProtectionPolicyResource()
            {
                Properties = new AzureSqlProtectionPolicy()
                {
                    RetentionPolicy = PolicyHelpers.GetServiceClientSimpleRetentionPolicy(
                            (CmdletModel.SimpleRetentionPolicy)retentionPolicy)
                }
            };

            return ServiceClientAdapter.CreateOrUpdateProtectionPolicy(
                                 policyName,
                                 hydraRequest).Body;
        }

        /// <summary>
        /// Modifies policy using the provider data
        /// </summary>
        /// <returns>Modified policy object as returned by the service</returns>
        public RestAzureNS.AzureOperationResponse<ProtectionPolicyResource> ModifyPolicy()
        {
            RetentionPolicyBase retentionPolicy =
              ProviderData.ContainsKey(PolicyParams.RetentionPolicy) ?
              (RetentionPolicyBase)ProviderData[PolicyParams.RetentionPolicy] :
              null;

            PolicyBase policy =
                ProviderData.ContainsKey(PolicyParams.ProtectionPolicy) ?
                (PolicyBase)ProviderData[PolicyParams.ProtectionPolicy] :
                null;

            // RetentionPolicy 
            if (retentionPolicy == null)
            {
                throw new ArgumentException(Resources.RetentionPolicyEmptyInAzureSql);
            }
            else
            {
                ValidateAzureSqlRetentionPolicy(retentionPolicy);
                ((AzureSqlPolicy)policy).RetentionPolicy = retentionPolicy;
                Logger.Instance.WriteDebug("Validation of Retention policy is successful");
            }

            CmdletModel.SimpleRetentionPolicy sqlRetentionPolicy =
                (CmdletModel.SimpleRetentionPolicy)((AzureSqlPolicy)policy).RetentionPolicy;
            ProtectionPolicyResource hydraRequest = new ProtectionPolicyResource()
            {
                Properties = new AzureSqlProtectionPolicy()
                {
                    RetentionPolicy =
                            PolicyHelpers.GetServiceClientSimpleRetentionPolicy(sqlRetentionPolicy)
                }
            };

            return ServiceClientAdapter.CreateOrUpdateProtectionPolicy(policy.Name,
                                                               hydraRequest);
        }

        /// <summary>
        /// Lists protection containers according to the provider data
        /// </summary>
        /// <returns>List of protection containers</returns>
        public List<ContainerBase> ListProtectionContainers()
        {
            string name = (string)this.ProviderData[ContainerParams.Name];

            ODataQuery<BMSContainerQueryObject> queryParams =
                new ODataQuery<BMSContainerQueryObject>(
                    q => q.BackupManagementType
                            == ServiceClientModel.BackupManagementType.AzureSql);


            var listResponse = ServiceClientAdapter.ListContainers(queryParams);

            List<ContainerBase> containerModels =
                ConversionHelpers.GetContainerModelList(listResponse);

            if (!string.IsNullOrEmpty(name))
            {
                if (containerModels != null)
                {
                    containerModels = containerModels.Where(x => x.Name == name).ToList();
                }
            }

            return containerModels;
        }

        public List<CmdletModel.BackupEngineBase> ListBackupManagementServers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// SchedulePolicy Object is not required for WorkloadType AzureSql.
        /// </summary>
        public SchedulePolicyBase GetDefaultSchedulePolicyObject()
        {
            throw new ArgumentException(
                string.Format(Resources.SchedulePolicyObjectNotRequiredForAzureSql));
        }

        /// <summary>
        /// Constructs the retention policy object with default inits
        /// </summary>
        /// <returns>Default retention policy object</returns>
        public RetentionPolicyBase GetDefaultRetentionPolicyObject()
        {
            CmdletModel.SimpleRetentionPolicy defaultRetention =
                new CmdletModel.SimpleRetentionPolicy();
            defaultRetention.RetentionDurationType = defaultSqlRetentionType;
            defaultRetention.RetentionCount = defaultSqlRetentionCount;
            return defaultRetention;
        }

        /// <summary>
        /// Lists protected items protected by the recovery services vault according to the provider data
        /// </summary>
        /// <returns>List of protected items</returns>
        public List<ItemBase> ListProtectedItems()
        {
            ContainerBase container = (ContainerBase)ProviderData[ItemParams.Container];
            string name = (string)ProviderData[ItemParams.AzureVMName];
            ItemProtectionStatus protectionStatus =
                (ItemProtectionStatus)ProviderData[ItemParams.ProtectionStatus];
            ItemProtectionState status =
                (ItemProtectionState)ProviderData[ItemParams.ProtectionState];
            CmdletModel.WorkloadType workloadType =
                (CmdletModel.WorkloadType)ProviderData[ItemParams.WorkloadType];

            ODataQuery<ProtectedItemQueryObject> queryParams =
                new ODataQuery<ProtectedItemQueryObject>(
                    q => q.BackupManagementType
                            == ServiceClientModel.BackupManagementType.AzureSql &&
                         q.ItemType == DataSourceType.AzureSqlDb);

            List<ProtectedItemResource> protectedItems = new List<ProtectedItemResource>();
            string skipToken = null;
            var listResponse = ServiceClientAdapter.ListProtectedItem(queryParams, skipToken);
            protectedItems.AddRange(listResponse);


            // 1. Filter by container
            if (container != null)
            {
                protectedItems = protectedItems.Where(protectedItem =>
                {
                    Dictionary<UriEnums, string> dictionary =
                        HelperUtils.ParseUri(protectedItem.Id);
                    string containerUri =
                        HelperUtils.GetContainerUri(dictionary, protectedItem.Id);
                    return containerUri.Contains(container.Name);
                }).ToList();
            }

            List<ProtectedItemResource> protectedItemGetResponses =
                new List<ProtectedItemResource>();

            // 2. Filter by item's friendly name
            if (!string.IsNullOrEmpty(name))
            {
                protectedItems = protectedItems.Where(protectedItem =>
                {
                    Dictionary<UriEnums, string> dictionary =
                        HelperUtils.ParseUri(protectedItem.Id);
                    string protectedItemUri =
                        HelperUtils.GetProtectedItemUri(dictionary, protectedItem.Id);
                    return protectedItemUri.ToLower().Contains(name.ToLower());
                }).ToList();

                ODataQuery<GetProtectedItemQueryObject> getItemQueryParams =
                    new ODataQuery<GetProtectedItemQueryObject>(q => q.Expand == extendedInfo);

                for (int i = 0; i < protectedItems.Count; i++)
                {
                    Dictionary<UriEnums, string> dictionary =
                        HelperUtils.ParseUri(protectedItems[i].Id);
                    string containerUri =
                        HelperUtils.GetContainerUri(dictionary, protectedItems[i].Id);
                    string protectedItemUri =
                        HelperUtils.GetProtectedItemUri(dictionary, protectedItems[i].Id);

                    var getResponse = ServiceClientAdapter.GetProtectedItem(
                        containerUri, protectedItemUri, getItemQueryParams);
                    protectedItemGetResponses.Add(getResponse.Body);
                }
            }

            List<ItemBase> itemModels = ConversionHelpers.GetItemModelList(protectedItems);

            if (!string.IsNullOrEmpty(name))
            {
                for (int i = 0; i < itemModels.Count; i++)
                {
                    AzureSqlProtectedItem azureSqlProtectedItem =
                        (AzureSqlProtectedItem)protectedItemGetResponses[i].Properties;
                    AzureSqlItemExtendedInfo extendedInfo = new AzureSqlItemExtendedInfo();
                    var hydraExtendedInfo = azureSqlProtectedItem.ExtendedInfo;
                    if (hydraExtendedInfo.OldestRecoveryPoint.HasValue)
                    {
                        extendedInfo.OldestRecoveryPoint = hydraExtendedInfo.OldestRecoveryPoint;
                    }
                    extendedInfo.PolicyState = hydraExtendedInfo.PolicyState;
                    extendedInfo.RecoveryPointCount = hydraExtendedInfo.RecoveryPointCount;
                    ((AzureSqlItem)itemModels[i]).ExtendedInfo = extendedInfo;
                }
            }

            // 3. Filter by item's Protection Status
            if (protectionStatus != 0)
            {
                throw new Exception(
                    string.Format(
                        Resources.ProtectionStatusNotAllowedForAzureSqlItem,
                        protectionStatus.ToString()));
            }

            // 4. Filter by item's Protection State
            if (status != 0)
            {
                if (status != ItemProtectionState.Protected)
                {
                    throw new Exception(
                        string.Format(
                            Resources.ProtectionStateInvalidForAzureSqlItem,
                            status.ToString()));
                }

                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureSqlItem)itemModel).ProtectionState == status.ToString();
                }).ToList();
            }

            // 5. Filter by workload type
            if (workloadType != 0)
            {
                itemModels = itemModels.Where(itemModel =>
                {
                    return itemModel.WorkloadType == workloadType;
                }).ToList();
            }

            return itemModels;
        }

        #region private
        private void ValidateAzureSqlWorkloadType(CmdletModel.WorkloadType type)
        {
            if (type != CmdletModel.WorkloadType.AzureSQLDatabase)
            {
                throw new ArgumentException(
                    string.Format(
                        Resources.UnExpectedWorkLoadTypeException,
                        CmdletModel.WorkloadType.AzureSQLDatabase.ToString(),
                        type.ToString()));
            }
        }

        private void ValidateAzureSqlProtectionPolicy(PolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureSqlPolicy))
            {
                throw new ArgumentException(
                    string.Format(
                    Resources.InvalidProtectionPolicyException,
                    typeof(AzureSqlPolicy).ToString()));
            }

            ValidateAzureSqlWorkloadType(policy.WorkloadType);

            // call validation
            policy.Validate();
        }

        private void ValidateAzureSqlRetentionPolicy(RetentionPolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(CmdletModel.SimpleRetentionPolicy))
            {
                throw new ArgumentException(
                    string.Format(
                        Resources.InvalidRetentionPolicyException,
                        typeof(CmdletModel.SimpleRetentionPolicy).ToString()));
            }

            // call validation
            policy.Validate();
        }

        private void ValidateAzureSQLDisableProtectionRequest(ItemBase itemBase)
        {

            if (itemBase == null || itemBase.GetType() != typeof(AzureSqlItem))
            {
                throw new ArgumentException(
                    string.Format(
                        Resources.InvalidProtectionItemException,
                        typeof(AzureSqlItem).ToString()));
            }

            ValidateAzureSqlWorkloadType(itemBase.WorkloadType);
            ValidateAzureSqlContainerType(itemBase.ContainerType);
        }

        private void ValidateAzureSqlContainerType(ContainerType type)
        {
            if (type != ContainerType.AzureSQL)
            {
                throw new ArgumentException(
                    string.Format(
                        Resources.UnExpectedContainerTypeException,
                        ContainerType.AzureSQL.ToString(),
                        type.ToString()));
            }
        }
        #endregion
    }
}
