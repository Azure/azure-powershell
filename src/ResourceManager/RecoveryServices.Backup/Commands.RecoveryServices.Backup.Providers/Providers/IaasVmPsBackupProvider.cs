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
using System.Management.Automation;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.HydraAdapterNS;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    public class IaasVmPsBackupProvider : IPsBackupProvider
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

        public BaseRecoveryServicesJobResponse EnableProtection()
        {
            string azureVMName = (string)ProviderData.ProviderParameters[ItemParams.AzureVMName];
            string azureVMCloudServiceName = (string)ProviderData.ProviderParameters[ItemParams.AzureVMCloudServiceName];
            string azureVMResourceGroupName = (string)ProviderData.ProviderParameters[ItemParams.AzureVMResourceGroupName];
            string parameterSetName = (string)ProviderData.ProviderParameters[ItemParams.ParameterSetName];

            AzureRmRecoveryServicesBackupPolicyBase policy = (AzureRmRecoveryServicesBackupPolicyBase)
                                                 ProviderData.ProviderParameters[ItemParams.Policy];

            AzureRmRecoveryServicesBackupItemBase itemBase = (AzureRmRecoveryServicesBackupItemBase)
                                                 ProviderData.ProviderParameters[ItemParams.Item];

            AzureRmRecoveryServicesBackupIaasVmItem item = (AzureRmRecoveryServicesBackupIaasVmItem)
                                                 ProviderData.ProviderParameters[ItemParams.Item];
            // do validations

            string containerUri = "";
            string protectedItemUri = "";
            bool isComputeAzureVM = false;

            if (itemBase == null)
            {
                isComputeAzureVM = string.IsNullOrEmpty(azureVMCloudServiceName) ? true : false;
                string azureVMRGName = (isComputeAzureVM) ? azureVMResourceGroupName : azureVMCloudServiceName;

                ValidateAzureVMWorkloadType(policy.WorkloadType);

                ValidateAzureVMEnableProtectionRequest(azureVMName, azureVMCloudServiceName, azureVMResourceGroupName, policy);

                ProtectableObjectResource protectableObjectResource = GetAzureVMProtectableObject(azureVMName, azureVMRGName, isComputeAzureVM);

                Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(protectableObjectResource.Id);
                containerUri = HelperUtils.GetContainerUri(keyValueDict, protectableObjectResource.Id);
                protectedItemUri = HelperUtils.GetProtectableItemUri(keyValueDict, protectableObjectResource.Id);
            }
            else
            {
                ValidateAzureVMWorkloadType(item.WorkloadType, policy.WorkloadType);
                ValidateAzureVMModifyProtectionRequest(itemBase, policy);

                isComputeAzureVM = IsComputeAzureVM(item.VirtualMachineId);
                Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
                containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
                protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);
            }

            // construct Hydra protectedItem request

            AzureIaaSVMProtectedItem properties;
            if (isComputeAzureVM == false)
            {
                properties = new AzureIaaSClassicComputeVMProtectedItem();
            }
            else
            {
                properties = new AzureIaaSComputeVMProtectedItem();
            }

            properties.PolicyId = policy.Id;

            ProtectedItemCreateOrUpdateRequest hydraRequest = new ProtectedItemCreateOrUpdateRequest()
            {
                Item = new ProtectedItemResource()
                {
                    Properties = properties,
                }
            };

            return HydraAdapter.CreateOrUpdateProtectedItem(
                                containerUri,
                                protectedItemUri,
                                hydraRequest);
        }

        public BaseRecoveryServicesJobResponse DisableProtection()
        {
            bool deleteBackupData = (bool)ProviderData.ProviderParameters[ItemParams.DeleteBackupData];

            AzureRmRecoveryServicesBackupItemBase itemBase = (AzureRmRecoveryServicesBackupItemBase)
                                                 ProviderData.ProviderParameters[ItemParams.Item];

            AzureRmRecoveryServicesBackupIaasVmItem item = (AzureRmRecoveryServicesBackupIaasVmItem)
                                                 ProviderData.ProviderParameters[ItemParams.Item];
            // do validations

            ValidateAzureVMDisableProtectionRequest(itemBase);

            Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);

            bool isComputeAzureVM = false;

            if (deleteBackupData)
            {
                return HydraAdapter.DeleteProtectedItem(
                                containerUri,
                                protectedItemUri);
            }
            else
            {
                isComputeAzureVM = IsComputeAzureVM(item.VirtualMachineId);

                // construct Hydra protectedItem request

                AzureIaaSVMProtectedItem properties;
                if (isComputeAzureVM == false)
                {
                    properties = new AzureIaaSClassicComputeVMProtectedItem();
                }
                else
                {
                    properties = new AzureIaaSComputeVMProtectedItem();
                }

                properties.PolicyId = string.Empty;
                properties.ProtectionState = ItemProtectionState.ProtectionStopped.ToString();

                ProtectedItemCreateOrUpdateRequest hydraRequest = new ProtectedItemCreateOrUpdateRequest()
                {
                    Item = new ProtectedItemResource()
                    {
                        Properties = properties,
                    }
                };

                return HydraAdapter.CreateOrUpdateProtectedItem(
                                    containerUri,
                                    protectedItemUri,
                                    hydraRequest);
            }
        }

        public BaseRecoveryServicesJobResponse TriggerBackup()
        {
            AzureRmRecoveryServicesBackupItemBase item = (AzureRmRecoveryServicesBackupItemBase)ProviderData.ProviderParameters[ItemParams.Item];
            AzureRmRecoveryServicesBackupIaasVmItem iaasVmItem = item as AzureRmRecoveryServicesBackupIaasVmItem;
            return HydraAdapter.TriggerBackup(IdUtils.GetValueByName(iaasVmItem.Id, IdUtils.IdNames.ProtectionContainerName),
                IdUtils.GetValueByName(iaasVmItem.Id, IdUtils.IdNames.ProtectedItemName));
        }

        public BaseRecoveryServicesJobResponse TriggerRestore()
        {
            AzureRmRecoveryServicesIaasVmRecoveryPoint rp = ProviderData.ProviderParameters[RestoreBackupItemParams.RecoveryPoint]
                as AzureRmRecoveryServicesIaasVmRecoveryPoint;
            string storageAccountId = ProviderData.ProviderParameters[RestoreBackupItemParams.StorageAccountId].ToString();
            string storageAccountLocation = ProviderData.ProviderParameters[RestoreBackupItemParams.StorageAccountLocation].ToString();
            string storageAccountType = ProviderData.ProviderParameters[RestoreBackupItemParams.StorageAccountType].ToString();

            var response = HydraAdapter.RestoreDisk(rp, storageAccountId, storageAccountLocation, storageAccountType);
            return response;
        }

        public ProtectedItemResponse GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        public AzureRmRecoveryServicesBackupRecoveryPointBase GetRecoveryPointDetails()
        {
            AzureRmRecoveryServicesBackupIaasVmItem item = ProviderData.ProviderParameters[GetRecoveryPointParams.Item]
                as AzureRmRecoveryServicesBackupIaasVmItem;

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

        public ProtectionPolicyResponse CreatePolicy()
        {
            string policyName = (string)ProviderData.ProviderParameters[PolicyParams.PolicyName];
            Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType workloadType =
                (Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType)ProviderData.ProviderParameters[PolicyParams.WorkloadType];
            AzureRmRecoveryServicesBackupRetentionPolicyBase retentionPolicy =
                ProviderData.ProviderParameters.ContainsKey(PolicyParams.RetentionPolicy) ?
                (AzureRmRecoveryServicesBackupRetentionPolicyBase)ProviderData.ProviderParameters[PolicyParams.RetentionPolicy] :
                null;
            AzureRmRecoveryServicesBackupSchedulePolicyBase schedulePolicy =
                ProviderData.ProviderParameters.ContainsKey(PolicyParams.SchedulePolicy) ?
                (AzureRmRecoveryServicesBackupSchedulePolicyBase)ProviderData.ProviderParameters[PolicyParams.SchedulePolicy] :
                null;

            // do validations
            ValidateAzureVMWorkloadType(workloadType);
            ValidateAzureVMSchedulePolicy(schedulePolicy);
            Logger.Instance.WriteDebug("Validation of Schedule policy is successful");

            // validate RetentionPolicy
            ValidateAzureVMRetentionPolicy(retentionPolicy);
            Logger.Instance.WriteDebug("Validation of Retention policy is successful");

            // update the retention times from backupSchedule to retentionPolicy after converting to UTC           
            CopyScheduleTimeToRetentionTimes((AzureRmRecoveryServicesBackupLongTermRetentionPolicy)retentionPolicy,
                                             (AzureRmRecoveryServicesBackupSimpleSchedulePolicy)schedulePolicy);
            Logger.Instance.WriteDebug("Copy of RetentionTime from with SchedulePolicy to RetentionPolicy is successful");

            // Now validate both RetentionPolicy and SchedulePolicy together
            PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleRetentionPolicy(
                                (AzureRmRecoveryServicesBackupLongTermRetentionPolicy)retentionPolicy,
                                (AzureRmRecoveryServicesBackupSimpleSchedulePolicy)schedulePolicy);
            Logger.Instance.WriteDebug("Validation of Retention policy with Schedule policy is successful");

            // construct Hydra policy request            
            ProtectionPolicyRequest hydraRequest = new ProtectionPolicyRequest()
            {
                Item = new ProtectionPolicyResource()
                {
                    Properties = new AzureIaaSVMProtectionPolicy()
                    {
                        RetentionPolicy = PolicyHelpers.GetHydraLongTermRetentionPolicy(
                                                (AzureRmRecoveryServicesBackupLongTermRetentionPolicy)retentionPolicy),
                        SchedulePolicy = PolicyHelpers.GetHydraSimpleSchedulePolicy(
                                                (AzureRmRecoveryServicesBackupSimpleSchedulePolicy)schedulePolicy)
                    }
                }
            };

            return HydraAdapter.CreateOrUpdateProtectionPolicy(
                                 policyName,
                                 hydraRequest);
        }

        public ProtectionPolicyResponse ModifyPolicy()
        {
            AzureRmRecoveryServicesBackupRetentionPolicyBase retentionPolicy =
               ProviderData.ProviderParameters.ContainsKey(PolicyParams.RetentionPolicy) ?
               (AzureRmRecoveryServicesBackupRetentionPolicyBase)ProviderData.ProviderParameters[PolicyParams.RetentionPolicy] :
               null;
            AzureRmRecoveryServicesBackupSchedulePolicyBase schedulePolicy =
                ProviderData.ProviderParameters.ContainsKey(PolicyParams.SchedulePolicy) ?
                (AzureRmRecoveryServicesBackupSchedulePolicyBase)ProviderData.ProviderParameters[PolicyParams.SchedulePolicy] :
                null;

            AzureRmRecoveryServicesBackupPolicyBase policy =
                ProviderData.ProviderParameters.ContainsKey(PolicyParams.ProtectionPolicy) ?
                (AzureRmRecoveryServicesBackupPolicyBase)ProviderData.ProviderParameters[PolicyParams.ProtectionPolicy] :
                null;

            // do validations
            ValidateAzureVMProtectionPolicy(policy);
            Logger.Instance.WriteDebug("Validation of Protection Policy is successful");

            // RetentionPolicy and SchedulePolicy both should not be empty
            if (retentionPolicy == null && schedulePolicy == null)
            {
                throw new ArgumentException(Resources.BothRetentionAndSchedulePoliciesEmpty);
            }

            // validate RetentionPolicy and SchedulePolicy
            if (schedulePolicy != null)
            {
                ValidateAzureVMSchedulePolicy(schedulePolicy);
                ((AzureRmRecoveryServicesIaasVmPolicy)policy).SchedulePolicy = schedulePolicy;
                Logger.Instance.WriteDebug("Validation of Schedule policy is successful");
            }
            if (retentionPolicy != null)
            {
                ValidateAzureVMRetentionPolicy(retentionPolicy);
                ((AzureRmRecoveryServicesIaasVmPolicy)policy).RetentionPolicy = retentionPolicy;
                Logger.Instance.WriteDebug("Validation of Retention policy is successful");
            }

            // copy the backupSchedule time to retentionPolicy after converting to UTC
            CopyScheduleTimeToRetentionTimes(
                (AzureRmRecoveryServicesBackupLongTermRetentionPolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).RetentionPolicy,
                (AzureRmRecoveryServicesBackupSimpleSchedulePolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).SchedulePolicy);
            Logger.Instance.WriteDebug("Copy of RetentionTime from with SchedulePolicy to RetentionPolicy is successful");

            // Now validate both RetentionPolicy and SchedulePolicy matches or not
            PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleRetentionPolicy(
                (AzureRmRecoveryServicesBackupLongTermRetentionPolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).RetentionPolicy,
                (AzureRmRecoveryServicesBackupSimpleSchedulePolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).SchedulePolicy);
            Logger.Instance.WriteDebug("Validation of Retention policy with Schedule policy is successful");

            // construct Hydra policy request            
            ProtectionPolicyRequest hydraRequest = new ProtectionPolicyRequest()
            {
                Item = new ProtectionPolicyResource()
                {
                    Properties = new AzureIaaSVMProtectionPolicy()
                    {
                        RetentionPolicy = PolicyHelpers.GetHydraLongTermRetentionPolicy(
                                  (AzureRmRecoveryServicesBackupLongTermRetentionPolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).RetentionPolicy),
                        SchedulePolicy = PolicyHelpers.GetHydraSimpleSchedulePolicy(
                                  (AzureRmRecoveryServicesBackupSimpleSchedulePolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).SchedulePolicy)
                    }
                }
            };

            return HydraAdapter.CreateOrUpdateProtectionPolicy(policy.Name,
                                                               hydraRequest);
        }

        public List<AzureRmRecoveryServicesBackupContainerBase> ListProtectionContainers()
        {
            Models.ContainerType containerType = (Models.ContainerType)this.ProviderData.ProviderParameters[ContainerParams.ContainerType];
            Models.BackupManagementType? backupManagementTypeNullable = (Models.BackupManagementType?)this.ProviderData.ProviderParameters[ContainerParams.BackupManagementType];
            string name = (string)this.ProviderData.ProviderParameters[ContainerParams.Name];
            string resourceGroupName = (string)this.ProviderData.ProviderParameters[ContainerParams.ResourceGroupName];
            ContainerRegistrationStatus status = (ContainerRegistrationStatus)this.ProviderData.ProviderParameters[ContainerParams.Status];

            if (backupManagementTypeNullable.HasValue)
            {
                ValidateAzureVMBackupManagementType(backupManagementTypeNullable.Value);
            }

            ProtectionContainerListQueryParams queryParams = new ProtectionContainerListQueryParams();

            // 1. Filter by Name
            queryParams.FriendlyName = name;

            // 2. Filter by ContainerType
            queryParams.BackupManagementType = Microsoft.Azure.Management.RecoveryServices.Backup.Models.BackupManagementType.AzureIaasVM.ToString();

            // 3. Filter by Status
            if (status != 0)
            {
                queryParams.RegistrationStatus = status.ToString();
            }
            
            var listResponse = HydraAdapter.ListContainers(queryParams);

            List<AzureRmRecoveryServicesBackupContainerBase> containerModels = ConversionHelpers.GetContainerModelList(listResponse);

            // 4. Filter by RG Name
            if (!string.IsNullOrEmpty(resourceGroupName))
            {
                containerModels = containerModels.Where(containerModel =>
                    (containerModel as AzureRmRecoveryServicesBackupIaasVmContainer).ResourceGroupName == resourceGroupName).ToList();
            }

            return containerModels;
        }

        public List<AzureRmRecoveryServicesBackupEngineBase> ListBackupManagementServers()
        {
            throw new NotImplementedException();
        }

        public List<AzureRmRecoveryServicesBackupItemBase> ListProtectedItems()
        {
            AzureRmRecoveryServicesBackupContainerBase container =
                (AzureRmRecoveryServicesBackupContainerBase)this.ProviderData.ProviderParameters[ItemParams.Container];
            string name = (string)this.ProviderData.ProviderParameters[ItemParams.AzureVMName];
            ItemProtectionStatus protectionStatus =
                (ItemProtectionStatus)this.ProviderData.ProviderParameters[ItemParams.ProtectionStatus];
            ItemProtectionState status = (ItemProtectionState)this.ProviderData.ProviderParameters[ItemParams.ProtectionState];
            Models.WorkloadType workloadType =
                (Models.WorkloadType)this.ProviderData.ProviderParameters[ItemParams.WorkloadType];

            ProtectedItemListQueryParam queryParams = new ProtectedItemListQueryParam();
            queryParams.DatasourceType = Microsoft.Azure.Management.RecoveryServices.Backup.Models.WorkloadType.VM;
            queryParams.BackupManagementType = Microsoft.Azure.Management.RecoveryServices.Backup.Models.BackupManagementType.AzureIaasVM.ToString();

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
                    AzureRmRecoveryServicesBackupIaasVmItemExtendedInfo extendedInfo = new AzureRmRecoveryServicesBackupIaasVmItemExtendedInfo();
                    var hydraExtendedInfo = ((AzureIaaSVMProtectedItem)protectedItemGetResponses[i].Item.Properties).ExtendedInfo;
                    if (hydraExtendedInfo.OldestRecoveryPoint.HasValue)
                    {
                        extendedInfo.OldestRecoveryPoint = hydraExtendedInfo.OldestRecoveryPoint;
                    }
                    extendedInfo.PolicyState = hydraExtendedInfo.PolicyInconsistent.ToString();
                    extendedInfo.RecoveryPointCount = hydraExtendedInfo.RecoveryPointCount;
                    ((AzureRmRecoveryServicesBackupIaasVmItem)itemModels[i]).ExtendedInfo = extendedInfo;
                }
            }

            // 3. Filter by item's Protection Status
            if (protectionStatus != 0)
            {
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureRmRecoveryServicesBackupIaasVmItem)itemModel).ProtectionStatus == protectionStatus;
                }).ToList();
            }

            // 4. Filter by item's Protection State
            if (status != 0)
            {
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureRmRecoveryServicesBackupIaasVmItem)itemModel).ProtectionState == status;
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

        public AzureRmRecoveryServicesBackupSchedulePolicyBase GetDefaultSchedulePolicyObject()
        {
            AzureRmRecoveryServicesBackupSimpleSchedulePolicy defaultSchedule = new AzureRmRecoveryServicesBackupSimpleSchedulePolicy();
            //Default is daily scedule at 10:30 AM local time
            defaultSchedule.ScheduleRunFrequency = ScheduleRunType.Daily;

            DateTime scheduleTime = GenerateRandomTime();
            defaultSchedule.ScheduleRunTimes = new List<DateTime>();
            defaultSchedule.ScheduleRunTimes.Add(scheduleTime);

            defaultSchedule.ScheduleRunDays = new List<DayOfWeek>();
            defaultSchedule.ScheduleRunDays.Add(DayOfWeek.Sunday);

            return defaultSchedule;
        }

        public AzureRmRecoveryServicesBackupRetentionPolicyBase GetDefaultRetentionPolicyObject()
        {
            AzureRmRecoveryServicesBackupLongTermRetentionPolicy defaultRetention = new AzureRmRecoveryServicesBackupLongTermRetentionPolicy();

            //Default time is 10:30 local time
            DateTime retentionTime = GenerateRandomTime();

            //Daily Retention policy
            defaultRetention.IsDailyScheduleEnabled = true;
            defaultRetention.DailySchedule = new Models.DailyRetentionSchedule();
            defaultRetention.DailySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.DailySchedule.RetentionTimes.Add(retentionTime);
            defaultRetention.DailySchedule.DurationCountInDays = 180; //TBD make it const

            //Weekly Retention policy
            defaultRetention.IsWeeklyScheduleEnabled = true;
            defaultRetention.WeeklySchedule = new Models.WeeklyRetentionSchedule();
            defaultRetention.WeeklySchedule.DaysOfTheWeek = new List<DayOfWeek>();
            defaultRetention.WeeklySchedule.DaysOfTheWeek.Add(DayOfWeek.Sunday);
            defaultRetention.WeeklySchedule.DurationCountInWeeks = 104; //TBD make it const
            defaultRetention.WeeklySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.WeeklySchedule.RetentionTimes.Add(retentionTime);

            //Monthly retention policy
            defaultRetention.IsMonthlyScheduleEnabled = true;
            defaultRetention.MonthlySchedule = new Models.MonthlyRetentionSchedule();
            defaultRetention.MonthlySchedule.DurationCountInMonths = 60; //tbd: make it const
            defaultRetention.MonthlySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.MonthlySchedule.RetentionTimes.Add(retentionTime);
            defaultRetention.MonthlySchedule.RetentionScheduleFormatType = Models.RetentionScheduleFormat.Weekly;

            //Initialize day based schedule
            defaultRetention.MonthlySchedule.RetentionScheduleDaily = GetDailyRetentionFormat();

            //Initialize Week based schedule
            defaultRetention.MonthlySchedule.RetentionScheduleWeekly = GetWeeklyRetentionFormat();

            //Yearly retention policy
            defaultRetention.IsYearlyScheduleEnabled = true;
            defaultRetention.YearlySchedule = new Models.YearlyRetentionSchedule();
            defaultRetention.YearlySchedule.DurationCountInYears = 10;
            defaultRetention.YearlySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.YearlySchedule.RetentionTimes.Add(retentionTime);
            defaultRetention.YearlySchedule.RetentionScheduleFormatType = Models.RetentionScheduleFormat.Weekly;
            defaultRetention.YearlySchedule.MonthsOfYear = new List<Models.Month>();
            defaultRetention.YearlySchedule.MonthsOfYear.Add(Models.Month.January);
            defaultRetention.YearlySchedule.RetentionScheduleDaily = GetDailyRetentionFormat();
            defaultRetention.YearlySchedule.RetentionScheduleWeekly = GetWeeklyRetentionFormat();
            return defaultRetention;

        }

        private static Models.DailyRetentionFormat GetDailyRetentionFormat()
        {
            Models.DailyRetentionFormat dailyRetention = new Models.DailyRetentionFormat();
            dailyRetention.DaysOfTheMonth = new List<Models.Day>();
            Models.Day dayBasedRetention = new Models.Day();
            dayBasedRetention.IsLast = false;
            dayBasedRetention.Date = 1;
            dailyRetention.DaysOfTheMonth.Add(dayBasedRetention);
            return dailyRetention;
        }

        private static Models.WeeklyRetentionFormat GetWeeklyRetentionFormat()
        {
            Models.WeeklyRetentionFormat weeklyRetention = new Models.WeeklyRetentionFormat();
            weeklyRetention.DaysOfTheWeek = new List<DayOfWeek>();
            weeklyRetention.DaysOfTheWeek.Add(DayOfWeek.Sunday);

            weeklyRetention.WeeksOfTheMonth = new List<WeekOfMonth>();
            weeklyRetention.WeeksOfTheMonth.Add(WeekOfMonth.First);
            return weeklyRetention;
        }

        private static DateTime GenerateRandomTime()
        {
            //Schedule time will be random to avoid the load in service (same is in portal as well)
            Random rand = new Random();
            int hour = rand.Next(0, 24);
            int minute = (rand.Next(0, 2) == 0) ? 0 : 30;
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 00, DateTimeKind.Utc);
        }


        #region private
        private void ValidateAzureVMWorkloadType(Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType type)
        {
            if (type != Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType.AzureVM)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedWorkLoadTypeException,
                                            Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType.AzureVM.ToString(),
                                            type.ToString()));
            }
        }

        private void ValidateAzureVMWorkloadType(Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType itemWorkloadType,
            Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType policyWorkloadType)
        {
            ValidateAzureVMWorkloadType(itemWorkloadType);
            ValidateAzureVMWorkloadType(policyWorkloadType);
            if (itemWorkloadType != policyWorkloadType)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedWorkLoadTypeException,
                                            Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType.AzureVM.ToString(),
                                            itemWorkloadType.ToString()));
            }
        }

        private void ValidateAzureVMContainerType(Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ContainerType type)
        {
            if (type != Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ContainerType.AzureVM)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedContainerTypeException,
                                            Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ContainerType.AzureVM.ToString(),
                                            type.ToString()));
            }
        }

        private void ValidateAzureVMBackupManagementType(Models.BackupManagementType backupManagementType)
        {
            if (backupManagementType != Models.BackupManagementType.AzureVM)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedBackupManagementTypeException,
                                            Models.BackupManagementType.AzureVM.ToString(),
                                            backupManagementType.ToString()));
            }
        }

        private void ValidateAzureVMProtectionPolicy(AzureRmRecoveryServicesBackupPolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureRmRecoveryServicesIaasVmPolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureRmRecoveryServicesIaasVmPolicy).ToString()));
            }

            ValidateAzureVMWorkloadType(policy.WorkloadType);

            // call validation
            policy.Validate();
        }

        private void ValidateAzureVMSchedulePolicy(AzureRmRecoveryServicesBackupSchedulePolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureRmRecoveryServicesBackupSimpleSchedulePolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidSchedulePolicyException,
                                            typeof(AzureRmRecoveryServicesBackupSimpleSchedulePolicy).ToString()));
            }

            // call validation
            policy.Validate();
        }

        private void ValidateAzureVMRetentionPolicy(AzureRmRecoveryServicesBackupRetentionPolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureRmRecoveryServicesBackupLongTermRetentionPolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidRetentionPolicyException,
                                            typeof(AzureRmRecoveryServicesBackupLongTermRetentionPolicy).ToString()));
            }

            // call validation
            policy.Validate();
        }

        private void ValidateAzureVMEnableProtectionRequest(string vmName, string serviceName, string rgName,
            AzureRmRecoveryServicesBackupPolicyBase policy)
        {
            if (string.IsNullOrEmpty(vmName))
            {
                throw new ArgumentException(string.Format(Resources.InvalidAzureVMName));
            }
            if (string.IsNullOrEmpty(rgName) && string.IsNullOrEmpty(serviceName))
            {
                throw new ArgumentException(string.Format(Resources.BothCloudServiceNameAndResourceGroupNameShouldNotEmpty));
            }
        }

        private void ValidateAzureVMModifyProtectionRequest(AzureRmRecoveryServicesBackupItemBase itemBase,
            AzureRmRecoveryServicesBackupPolicyBase policy)
        {
            if (itemBase == null || itemBase.GetType() != typeof(AzureRmRecoveryServicesBackupIaasVmItem))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureRmRecoveryServicesBackupIaasVmItem).ToString()));
            }

            if (string.IsNullOrEmpty(((AzureRmRecoveryServicesBackupIaasVmItem)itemBase).VirtualMachineId))
            {
                throw new ArgumentException(Resources.VirtualMachineIdIsEmptyOrNull);
            }
        }

        private void ValidateAzureVMDisableProtectionRequest(AzureRmRecoveryServicesBackupItemBase itemBase)
        {

            if (itemBase == null || itemBase.GetType() != typeof(AzureRmRecoveryServicesBackupIaasVmItem))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureRmRecoveryServicesBackupIaasVmItem).ToString()));
            }

            if (string.IsNullOrEmpty(((AzureRmRecoveryServicesBackupIaasVmItem)itemBase).VirtualMachineId))
            {
                throw new ArgumentException(Resources.VirtualMachineIdIsEmptyOrNull);
            }

            ValidateAzureVMWorkloadType(itemBase.WorkloadType);
            ValidateAzureVMContainerType(itemBase.ContainerType);
        }

        private bool IsComputeAzureVM(string virtualMachineId)
        {
            bool isComputeAzureVM = true;
            if (virtualMachineId.IndexOf(classicComputeAzureVMVersion, StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                isComputeAzureVM = false;
            }
            return isComputeAzureVM;
        }

        private ProtectableObjectResource GetAzureVMProtectableObject(string azureVMName, string azureVMRGName, bool isComputeAzureVM)
        {
            //TriggerDiscovery if needed

            bool isDiscoveryNeed = false;

            ProtectableObjectResource protectableObjectResource = null;
            isDiscoveryNeed = IsDiscoveryNeeded(azureVMName, azureVMRGName, isComputeAzureVM, out protectableObjectResource);
            if (isDiscoveryNeed)
            {
                Logger.Instance.WriteDebug(String.Format(Resources.VMNotDiscovered, azureVMName));
                RefreshContainer();
                isDiscoveryNeed = IsDiscoveryNeeded(azureVMName, azureVMRGName, isComputeAzureVM, out protectableObjectResource);
                if (isDiscoveryNeed == true)
                {
                    // Container is not discovered. Throw exception
                    string vmversion = (isComputeAzureVM) ? computeAzureVMVersion : classicComputeAzureVMVersion;
                    string errMsg = String.Format(Resources.DiscoveryFailure, azureVMName, azureVMRGName, vmversion);
                    Logger.Instance.WriteDebug(errMsg);
                    Logger.Instance.ThrowTerminatingError(new ErrorRecord(new Exception(Resources.AzureVMNotFound), string.Empty, ErrorCategory.InvalidArgument, null));
                }
            }
            if (protectableObjectResource == null)
            {
                // Container is not discovered. Throw exception
                string vmversion = (isComputeAzureVM) ? computeAzureVMVersion : classicComputeAzureVMVersion;
                string errMsg = String.Format(Resources.DiscoveryFailure, azureVMName, azureVMRGName, vmversion);
                Logger.Instance.WriteDebug(errMsg);
                Logger.Instance.ThrowTerminatingError(new ErrorRecord(new Exception(Resources.AzureVMNotFound), string.Empty, ErrorCategory.InvalidArgument, null));
            }

            return protectableObjectResource;

        }

        private bool IsDiscoveryNeeded(string vmName, string rgName, bool isComputeAzureVM,
            out ProtectableObjectResource protectableObjectResource)
        {
            bool isDiscoveryNeed = true;
            protectableObjectResource = null;
            string vmVersion = string.Empty;
            vmVersion = (isComputeAzureVM) == true ? computeAzureVMVersion : classicComputeAzureVMVersion;
            string virtualMachineId = GetAzureIaasVirtualMachineId(rgName, vmVersion, vmName);

            ProtectableObjectListQueryParameters queryParam = new ProtectableObjectListQueryParameters();
            // --- TBD To be added once bug is fixed in hydra and service
            //queryParam.ProviderType = ProviderType.AzureIaasVM.ToString();
            //queryParam.FriendlyName = vmName;

            // No need to use skip or top token here as no pagination support of IaaSVM PO.

            //First check if container is discovered or not
            var protectableItemList = HydraAdapter.ListProtectableItem(queryParam).ItemList;

            Logger.Instance.WriteDebug(String.Format(Resources.ContainerCountAfterFilter, protectableItemList.ProtectableObjects.Count()));
            if (protectableItemList.ProtectableObjects.Count() == 0)
            {
                //Container is not discovered
                Logger.Instance.WriteDebug(Resources.ContainerNotDiscovered);
                isDiscoveryNeed = true;
            }
            else
            {
                foreach (var protectableItem in protectableItemList.ProtectableObjects)
                {
                    AzureIaaSVMProtectableItem iaaSVMProtectableItem = (AzureIaaSVMProtectableItem)protectableItem.Properties;
                    if (iaaSVMProtectableItem != null &&
                        string.Compare(iaaSVMProtectableItem.FriendlyName, vmName, true) == 0
                        && iaaSVMProtectableItem.VirtualMachineId.IndexOf(virtualMachineId,
                        StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        protectableObjectResource = protectableItem;
                        isDiscoveryNeed = false;
                        break;
                    }
                }
            }

            return isDiscoveryNeed;
        }

        private void RefreshContainer()
        {
            string errorMessage = string.Empty;
            var refreshContainerJobResponse = HydraAdapter.RefreshContainers();

            //Now wait for the operation to Complete
            if (refreshContainerJobResponse.StatusCode != System.Net.HttpStatusCode.NoContent)
            {
                errorMessage = String.Format(Resources.DiscoveryFailureErrorCode, refreshContainerJobResponse.StatusCode);
                Logger.Instance.WriteDebug(errorMessage);
            }
        }

        private HttpStatusCode TrackRefreshContainerOperation(string operationResultLink, int checkFrequency = defaultOperationStatusRetryTimeInMilliSec)
        {
            HttpStatusCode status = HttpStatusCode.Accepted;
            while (status == HttpStatusCode.Accepted)
            {
                try
                {
                    var response = HydraAdapter.GetRefreshContainerOperationResultByURL(operationResultLink);
                    status = response.StatusCode;

                    TestMockSupport.Delay(checkFrequency);
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteDebug(ex.Message);
                    status = HttpStatusCode.InternalServerError;
                    break;
                }
            }

            if (status == HttpStatusCode.NoContent)
            {
                Logger.Instance.WriteDebug("Refresh Container Job completed with success");
            }
            else
            {
                string msg = String.Format("Unexpected http status in response header {0}", status);
                Logger.Instance.WriteDebug(msg);
                throw new Exception(msg);
            }

            return status;
        }

        private static string GetAzureIaasVirtualMachineId(string resourceGroup, string vmVersion, string name)
        {
            string IaasVMIdFormat = "/resourceGroups/{0}/providers/{1}/virtualMachines/{2}";
            return string.Format(IaasVMIdFormat, resourceGroup, vmVersion, name);
        }

        private void CopyScheduleTimeToRetentionTimes(AzureRmRecoveryServicesBackupLongTermRetentionPolicy retPolicy,
                                                      AzureRmRecoveryServicesBackupSimpleSchedulePolicy schPolicy)
        {
            // schedule runTimes is already validated if in UTC/not during validate()
            // now copy times from schedule to retention policy
            if (retPolicy.IsDailyScheduleEnabled && retPolicy.DailySchedule != null)
            {
                retPolicy.DailySchedule.RetentionTimes = schPolicy.ScheduleRunTimes;
            }

            if (retPolicy.IsWeeklyScheduleEnabled && retPolicy.WeeklySchedule != null)
            {
                retPolicy.WeeklySchedule.RetentionTimes = schPolicy.ScheduleRunTimes;
            }

            if (retPolicy.IsMonthlyScheduleEnabled && retPolicy.MonthlySchedule != null)
            {
                retPolicy.MonthlySchedule.RetentionTimes = schPolicy.ScheduleRunTimes;
            }

            if (retPolicy.IsYearlyScheduleEnabled && retPolicy.YearlySchedule != null)
            {
                retPolicy.YearlySchedule.RetentionTimes = schPolicy.ScheduleRunTimes;
            }
        }

        #endregion
    }
}
