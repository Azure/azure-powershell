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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.HydraAdapterNS;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    public class AzureSqlPsBackupProvider : IPsBackupProvider
    {
        private const int defaultOperationStatusRetryTimeInMilliSec = 5 * 1000; // 5 sec
        private const string separator = ";";
        private const string computeAzureVMVersion = "Microsoft.Compute";
        private const string classicComputeAzureVMVersion = "Microsoft.ClassicCompute";

        ProviderData ProviderData { get; set; }
        HydraAdapter HydraAdapter { get; set; }

        public void Initialize(ProviderData providerData, HydraAdapter hydraAdapter)
        {
            this.ProviderData = providerData;
            this.HydraAdapter = hydraAdapter;
        }

        public Management.RecoveryServices.Backup.Models.BaseRecoveryServicesJobResponse EnableProtection()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.BaseRecoveryServicesJobResponse DisableProtection()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.BaseRecoveryServicesJobResponse TriggerBackup()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.BaseRecoveryServicesJobResponse TriggerRestore()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.ProtectedItemResponse GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        public AzureRmRecoveryServicesBackupRecoveryPointBase GetRecoveryPointDetails()
        {
            AzureRmRecoveryServicesBackupAzureSqlItem item = ProviderData.ProviderParameters[GetRecoveryPointParams.Item]
                as AzureRmRecoveryServicesBackupAzureSqlItem;

            string recoveryPointId = ProviderData.ProviderParameters[GetRecoveryPointParams.RecoveryPointId].ToString();

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            var rpResponse = HydraAdapter.GetRecoveryPointDetails(containerUri, protectedItemName, recoveryPointId);
            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpResponse, item);
        }

        public List<AzureRmRecoveryServicesBackupRecoveryPointBase> ListRecoveryPoints()
        {
            DateTime startDate = (DateTime)(ProviderData.ProviderParameters[GetRecoveryPointParams.StartDate]);
            DateTime endDate = (DateTime)(ProviderData.ProviderParameters[GetRecoveryPointParams.EndDate]);
            AzureRmRecoveryServicesBackupIaasVmItem item = ProviderData.ProviderParameters[GetRecoveryPointParams.Item]
                as AzureRmRecoveryServicesBackupIaasVmItem;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            TimeSpan duration = endDate - startDate;
            if (duration.TotalDays > 30)
            {
                throw new Exception(Resources.RestoreDiskTimeRangeError); //tbd: Correct nsg and exception type
            }

            //we need to fetch the list of RPs
            RecoveryPointQueryParameters queryFilter = new RecoveryPointQueryParameters();
            queryFilter.StartDate = CommonHelpers.GetDateTimeStringForService(startDate);
            queryFilter.EndDate = CommonHelpers.GetDateTimeStringForService(endDate);
            RecoveryPointListResponse rpListResponse = null;

            rpListResponse = HydraAdapter.GetRecoveryPoints(containerUri, protectedItemName, queryFilter);
            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpListResponse, item);
        }

        public Management.RecoveryServices.Backup.Models.ProtectionPolicyResponse CreatePolicy()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.ProtectionPolicyResponse ModifyPolicy()
        {
            throw new NotImplementedException();
        }

        public List<Models.AzureRmRecoveryServicesBackupContainerBase> ListProtectionContainers()
        {
            throw new NotImplementedException();
        }

        public List<AzureRmRecoveryServicesBackupEngineBase> ListBackupManagementServers()
        {
            throw new NotImplementedException();
        }
       
        public AzureRmRecoveryServicesBackupSchedulePolicyBase GetDefaultSchedulePolicyObject()
        {
            throw new NotImplementedException();
        }

        public AzureRmRecoveryServicesBackupRetentionPolicyBase GetDefaultRetentionPolicyObject()
        {
            throw new NotImplementedException();
        }

        public List<AzureRmRecoveryServicesBackupItemBase> ListProtectedItems()
        {
            AzureRmRecoveryServicesBackupContainerBase container = (AzureRmRecoveryServicesBackupContainerBase)this.ProviderData.ProviderParameters[ItemParams.Container];
            string name = (string)this.ProviderData.ProviderParameters[ItemParams.AzureVMName];
            ItemProtectionStatus protectionStatus =
                (ItemProtectionStatus)this.ProviderData.ProviderParameters[ItemParams.ProtectionStatus];
            ItemProtectionState status = (ItemProtectionState)this.ProviderData.ProviderParameters[ItemParams.ProtectionState];
            Models.WorkloadType workloadType =
                (Models.WorkloadType)this.ProviderData.ProviderParameters[ItemParams.WorkloadType];

            ProtectedItemListQueryParam queryParams = new ProtectedItemListQueryParam();
            queryParams.DatasourceType = Microsoft.Azure.Management.RecoveryServices.Backup.Models.WorkloadType.AzureSqlDb.ToString();
            queryParams.BackupManagementType = Microsoft.Azure.Management.RecoveryServices.Backup.Models.BackupManagementType.AzureSql.ToString();

            List<ProtectedItemResource> protectedItems = new List<ProtectedItemResource>();
            string skipToken = null;
            PaginationRequest paginationRequest = null;
            do
            {
                var listResponse = HydraAdapter.ListProtectedItem(queryParams, paginationRequest);
                protectedItems.AddRange(listResponse.ItemList.Value);

                HydraHelpers.GetSkipTokenFromNextLink(listResponse.ItemList.NextLink, out skipToken);
                if (skipToken != null)
                {
                    paginationRequest = new PaginationRequest();
                    paginationRequest.SkipToken = skipToken;
                }
            } while (skipToken != null);

            // 1. Filter by container
            protectedItems = protectedItems.Where(protectedItem =>
            {
                Dictionary<UriEnums, string> dictionary = HelperUtils.ParseUri(protectedItem.Id);
                string containerUri = HelperUtils.GetContainerUri(dictionary, protectedItem.Id);
                return containerUri.Contains(container.Name);
            }).ToList();

            List<ProtectedItemResponse> protectedItemGetResponses = new List<ProtectedItemResponse>();

            // 2. Filter by item's friendly name
            if (!string.IsNullOrEmpty(name))
            {
                protectedItems = protectedItems.Where(protectedItem =>
                {
                    Dictionary<UriEnums, string> dictionary = HelperUtils.ParseUri(protectedItem.Id);
                    string protectedItemUri = HelperUtils.GetProtectedItemUri(dictionary, protectedItem.Id);
                    return protectedItemUri.ToLower().Contains(name.ToLower());
                }).ToList();

                GetProtectedItemQueryParam getItemQueryParams = new GetProtectedItemQueryParam();
                getItemQueryParams.Expand = "extendedinfo";

                for (int i = 0; i < protectedItems.Count; i++)
                {
                    Dictionary<UriEnums, string> dictionary = HelperUtils.ParseUri(protectedItems[i].Id);
                    string containerUri = HelperUtils.GetContainerUri(dictionary, protectedItems[i].Id);
                    string protectedItemUri = HelperUtils.GetProtectedItemUri(dictionary, protectedItems[i].Id);

                    var getResponse = HydraAdapter.GetProtectedItem(containerUri, protectedItemUri, getItemQueryParams);
                    protectedItemGetResponses.Add(getResponse);
                }
            }

            List<AzureRmRecoveryServicesBackupItemBase> itemModels = ConversionHelpers.GetItemModelList(protectedItems, container);

            if (!string.IsNullOrEmpty(name))
            {
                for (int i = 0; i < itemModels.Count; i++)
                {
                    AzureRmRecoveryServicesBackupAzureSqlItemExtendedInfo extendedInfo = new AzureRmRecoveryServicesBackupAzureSqlItemExtendedInfo();
                    var hydraExtendedInfo = ((AzureSqlProtectedItem)protectedItemGetResponses[i].Item.Properties).ExtendedInfo;
                    if (hydraExtendedInfo.OldestRecoveryPoint.HasValue)
                    {
                        extendedInfo.OldestRecoveryPoint = hydraExtendedInfo.OldestRecoveryPoint;
                    }
                    extendedInfo.PolicyState = hydraExtendedInfo.PolicyState;
                    extendedInfo.RecoveryPointCount = hydraExtendedInfo.RecoveryPointCount;
                    ((AzureRmRecoveryServicesBackupAzureSqlItem)itemModels[i]).ExtendedInfo = extendedInfo;
                }
            }

            // 3. Filter by item's Protection Status
            if (protectionStatus != 0)
            {
                throw new Exception(string.Format("Protection Status is not allowed for AzureSqlItem. protectionStatus : {0}", protectionStatus.ToString()));
            }

            // 4. Filter by item's Protection State
            if (status != 0)
            {
                if(status != ItemProtectionState.Protected)
                {
                    throw new Exception(string.Format("Givene Protection state is not valid for AzureSqlItem. Provided state : {0}", status.ToString()));
                }

                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureRmRecoveryServicesBackupAzureSqlItem)itemModel).ProtectionState == status.ToString();
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
    }
}
