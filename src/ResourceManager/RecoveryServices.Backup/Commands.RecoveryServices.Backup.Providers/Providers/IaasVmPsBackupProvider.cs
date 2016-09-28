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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    /// <summary>
    /// This class implements implements methods for IaasVm backup provider
    /// </summary>
    public class IaasVmPsBackupProvider : IPsBackupProvider
    {
        private const int defaultOperationStatusRetryTimeInMilliSec = 5 * 1000; // 5 sec
        private const string separator = ";";
        private const string computeAzureVMVersion = "Microsoft.Compute";
        private const string classicComputeAzureVMVersion = "Microsoft.ClassicCompute";

        Dictionary<System.Enum, object> ProviderData { get; set; }
        ServiceClientAdapter ServiceClientAdapter { get; set; }

        /// <summary>
        /// Initializes the provider with the data recieved from the cmdlet layer
        /// </summary>
        /// <param name="providerData">Data from the cmdlet layer intended for the provider</param>
        /// <param name="serviceClientAdapter">Service client adapter for communicating with the backend service</param>
        public void Initialize(Dictionary<System.Enum, object> providerData, ServiceClientAdapter serviceClientAdapter)
        {
            this.ProviderData = providerData;
            this.ServiceClientAdapter = serviceClientAdapter;
        }

        /// <summary>
        /// Triggers the enable protection operation for the given item
        /// </summary>
        /// <returns>The job response returned from the service</returns>
        public BaseRecoveryServicesJobResponse EnableProtection()
        {
            string azureVMName = (string)ProviderData[ItemParams.AzureVMName];
            string azureVMCloudServiceName = (string)ProviderData[ItemParams.AzureVMCloudServiceName];
            string azureVMResourceGroupName = (string)ProviderData[ItemParams.AzureVMResourceGroupName];
            string parameterSetName = (string)ProviderData[ItemParams.ParameterSetName];

            PolicyBase policy = (PolicyBase)
                                                 ProviderData[ItemParams.Policy];

            ItemBase itemBase = (ItemBase)
                                                 ProviderData[ItemParams.Item];

            AzureVmItem item = (AzureVmItem)
                                                 ProviderData[ItemParams.Item];
            // do validations

            string containerUri = "";
            string protectedItemUri = "";
            bool isComputeAzureVM = false;
            string sourceResourceId = null;

            if (itemBase == null)
            {
                isComputeAzureVM = string.IsNullOrEmpty(azureVMCloudServiceName) ? true : false;
                string azureVMRGName = (isComputeAzureVM) ? 
                    azureVMResourceGroupName : azureVMCloudServiceName;

                ValidateAzureVMWorkloadType(policy.WorkloadType);

                ValidateAzureVMEnableProtectionRequest(
                    azureVMName, 
                    azureVMCloudServiceName, 
                    azureVMResourceGroupName, 
                    policy);

                ProtectableObjectResource protectableObjectResource = 
                    GetAzureVMProtectableObject(azureVMName, azureVMRGName, isComputeAzureVM);

                Dictionary<UriEnums, string> keyValueDict = 
                    HelperUtils.ParseUri(protectableObjectResource.Id);
                containerUri = HelperUtils.GetContainerUri(
                    keyValueDict, protectableObjectResource.Id);
                protectedItemUri = HelperUtils.GetProtectableItemUri(
                    keyValueDict, protectableObjectResource.Id);

                AzureIaaSVMProtectableItem iaasVmProtectableItem =
                    (AzureIaaSVMProtectableItem)protectableObjectResource.Properties;
                if (iaasVmProtectableItem != null)
                {
                    sourceResourceId = iaasVmProtectableItem.VirtualMachineId;
            }
            }
            else
            {
                ValidateAzureVMWorkloadType(item.WorkloadType, policy.WorkloadType);
                ValidateAzureVMModifyProtectionRequest(itemBase, policy);

                isComputeAzureVM = IsComputeAzureVM(item.VirtualMachineId);
                Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
                containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
                protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);
                sourceResourceId = item.SourceResourceId;
            }

            // construct Service Client protectedItem request

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
            properties.SourceResourceId = sourceResourceId;

            ProtectedItemCreateOrUpdateRequest serviceClientRequest = new ProtectedItemCreateOrUpdateRequest()
            {
                Item = new ProtectedItemResource()
                {
                    Properties = properties,
                }
            };

            return ServiceClientAdapter.CreateOrUpdateProtectedItem(
                                containerUri,
                                protectedItemUri,
                                serviceClientRequest);
        }

        /// <summary>
        /// Triggers the disable protection operation for the given item
        /// </summary>
        /// <returns>The job response returned from the service</returns>
        public BaseRecoveryServicesJobResponse DisableProtection()
        {
            bool deleteBackupData = (bool)ProviderData[ItemParams.DeleteBackupData];

            ItemBase itemBase = (ItemBase)
                                                 ProviderData[ItemParams.Item];

            AzureVmItem item = (AzureVmItem)
                                                 ProviderData[ItemParams.Item];
            // do validations

            ValidateAzureVMDisableProtectionRequest(itemBase);

            Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);

            bool isComputeAzureVM = false;

            if (deleteBackupData)
            {
                return ServiceClientAdapter.DeleteProtectedItem(
                                containerUri,
                                protectedItemUri);
            }
            else
            {
                isComputeAzureVM = IsComputeAzureVM(item.VirtualMachineId);

                // construct Service Client protectedItem request

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
                properties.SourceResourceId = item.SourceResourceId;

                ProtectedItemCreateOrUpdateRequest serviceClientRequest = new ProtectedItemCreateOrUpdateRequest()
                {
                    Item = new ProtectedItemResource()
                    {
                        Properties = properties,
                    }
                };

                return ServiceClientAdapter.CreateOrUpdateProtectedItem(
                                    containerUri,
                                    protectedItemUri,
                                    serviceClientRequest);
            }
        }

        /// <summary>
        /// Triggers the backup operation for the given item
        /// </summary>
        /// <returns>The job response returned from the service</returns>
        public BaseRecoveryServicesJobResponse TriggerBackup()
        {
            ItemBase item = (ItemBase)ProviderData[ItemParams.Item];
            DateTime? expiryDateTime = (DateTime?)ProviderData[ItemParams.ExpiryDateTimeUTC];
            AzureVmItem iaasVmItem = item as AzureVmItem;

            return ServiceClientAdapter.TriggerBackup(
                IdUtils.GetValueByName(iaasVmItem.Id, IdUtils.IdNames.ProtectionContainerName),
                IdUtils.GetValueByName(iaasVmItem.Id, IdUtils.IdNames.ProtectedItemName),
                expiryDateTime);
        }

        /// <summary>
        /// Triggers the recovery operation for the given recovery point
        /// </summary>
        /// <returns>The job response returned from the service</returns>
        public BaseRecoveryServicesJobResponse TriggerRestore()
        {
            AzureVmRecoveryPoint rp = ProviderData[RestoreBackupItemParams.RecoveryPoint]
                as AzureVmRecoveryPoint;
            string storageAccountId = ProviderData[RestoreBackupItemParams.StorageAccountId].ToString();
            string storageAccountLocation = 
                ProviderData[RestoreBackupItemParams.StorageAccountLocation].ToString();
            string storageAccountType = 
                ProviderData[RestoreBackupItemParams.StorageAccountType].ToString();

            var response = ServiceClientAdapter.RestoreDisk(rp, storageAccountId, storageAccountLocation, storageAccountType);
            return response;
        }

        public ProtectedItemResponse GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetches the detail info for the given recovery point
        /// </summary>
        /// <returns>Recovery point detail as returned by the service</returns>
        public CmdletModel.RecoveryPointBase GetRecoveryPointDetails()
        {
            AzureVmItem item = ProviderData[RecoveryPointParams.Item]
                as AzureVmItem;

            string recoveryPointId = ProviderData[RecoveryPointParams.RecoveryPointId].ToString();

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            var rpResponse = ServiceClientAdapter.GetRecoveryPointDetails(
                containerUri, protectedItemName, recoveryPointId);

            var rp = RecoveryPointConversions.GetPSAzureRecoveryPoints(rpResponse, item) as AzureVmRecoveryPoint;

            if (rp.EncryptionEnabled)
            {
                string keyFileDownloadLocation =
                    (string)ProviderData[RecoveryPointParams.KeyFileDownloadLocation];
                string keyFileContent = rp.KeyAndSecretDetails.KeyBackupData;
                if (!string.IsNullOrEmpty(keyFileDownloadLocation))
                {
                    string absoluteFilePath = Path.Combine(keyFileDownloadLocation, "key.blob");
                    File.WriteAllBytes(absoluteFilePath, Convert.FromBase64String(keyFileContent));
                }
            }
            return rp;
        }

        /// <summary>
        /// Lists recovery points generated for the given item
        /// </summary>
        /// <returns>List of recovery point PowerShell model objects</returns>
        public List<CmdletModel.RecoveryPointBase> ListRecoveryPoints()
        {
            DateTime startDate = (DateTime)(ProviderData[RecoveryPointParams.StartDate]);
            DateTime endDate = (DateTime)(ProviderData[RecoveryPointParams.EndDate]);
            AzureVmItem item = ProviderData[RecoveryPointParams.Item]
                as AzureVmItem;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            TimeSpan duration = endDate - startDate;
            if (duration.TotalDays > 30)
            {
                throw new Exception(Resources.RestoreDiskTimeRangeError); 
            }

            //we need to fetch the list of RPs
            RecoveryPointQueryParameters queryFilter = new RecoveryPointQueryParameters();
            queryFilter.StartDate = CommonHelpers.GetDateTimeStringForService(startDate);
            queryFilter.EndDate = CommonHelpers.GetDateTimeStringForService(endDate);
            RecoveryPointListResponse rpListResponse = null;

            rpListResponse = ServiceClientAdapter.GetRecoveryPoints(containerUri, protectedItemName, queryFilter);
            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpListResponse, item);
        }

        /// <summary>
        /// Creates policy given the provider data
        /// </summary>
        /// <returns>Created policy object as returned by the service</returns>
        public ProtectionPolicyResponse CreatePolicy()
        {
            string policyName = (string)ProviderData[PolicyParams.PolicyName];
            Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType workloadType =
                (Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType)ProviderData[PolicyParams.WorkloadType];
            RetentionPolicyBase retentionPolicy =
                ProviderData.ContainsKey(PolicyParams.RetentionPolicy) ?
                (RetentionPolicyBase)ProviderData[PolicyParams.RetentionPolicy] :
                null;
            SchedulePolicyBase schedulePolicy =
                ProviderData.ContainsKey(PolicyParams.SchedulePolicy) ?
                (SchedulePolicyBase)ProviderData[PolicyParams.SchedulePolicy] :
                null;

            // do validations
            ValidateAzureVMWorkloadType(workloadType);
            ValidateAzureVMSchedulePolicy(schedulePolicy);
            Logger.Instance.WriteDebug("Validation of Schedule policy is successful");

            // validate RetentionPolicy
            ValidateAzureVMRetentionPolicy(retentionPolicy);
            Logger.Instance.WriteDebug("Validation of Retention policy is successful");

            // update the retention times from backupSchedule to retentionPolicy after converting to UTC           
            CopyScheduleTimeToRetentionTimes((CmdletModel.LongTermRetentionPolicy)retentionPolicy,
                                             (CmdletModel.SimpleSchedulePolicy)schedulePolicy);
            Logger.Instance.WriteDebug("Copy of RetentionTime from with SchedulePolicy to RetentionPolicy is successful");

            // Now validate both RetentionPolicy and SchedulePolicy together
            PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleRetentionPolicy(
                                (CmdletModel.LongTermRetentionPolicy)retentionPolicy,
                                (CmdletModel.SimpleSchedulePolicy)schedulePolicy);
            Logger.Instance.WriteDebug("Validation of Retention policy with Schedule policy is successful");

            // construct Service Client policy request            
            ProtectionPolicyRequest serviceClientRequest = new ProtectionPolicyRequest()
            {
                Item = new ProtectionPolicyResource()
                {
                    Properties = new AzureIaaSVMProtectionPolicy()
                    {
                        RetentionPolicy = PolicyHelpers.GetServiceClientLongTermRetentionPolicy(
                                                (CmdletModel.LongTermRetentionPolicy)retentionPolicy),
                        SchedulePolicy = PolicyHelpers.GetServiceClientSimpleSchedulePolicy(
                                                (CmdletModel.SimpleSchedulePolicy)schedulePolicy)
                    }
                }
            };

            return ServiceClientAdapter.CreateOrUpdateProtectionPolicy(
                                 policyName,
                                 serviceClientRequest);
        }

        /// <summary>
        /// Modifies policy using the provider data
        /// </summary>
        /// <returns>Modified policy object as returned by the service</returns>
        public ProtectionPolicyResponse ModifyPolicy()
        {
            RetentionPolicyBase retentionPolicy =
               ProviderData.ContainsKey(PolicyParams.RetentionPolicy) ?
               (RetentionPolicyBase)ProviderData[PolicyParams.RetentionPolicy] :
               null;
            SchedulePolicyBase schedulePolicy =
                ProviderData.ContainsKey(PolicyParams.SchedulePolicy) ?
                (SchedulePolicyBase)ProviderData[PolicyParams.SchedulePolicy] :
                null;

            PolicyBase policy =
                ProviderData.ContainsKey(PolicyParams.ProtectionPolicy) ?
                (PolicyBase)ProviderData[PolicyParams.ProtectionPolicy] :
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
                ((AzureVmPolicy)policy).SchedulePolicy = schedulePolicy;
                Logger.Instance.WriteDebug("Validation of Schedule policy is successful");
            }
            if (retentionPolicy != null)
            {
                ValidateAzureVMRetentionPolicy(retentionPolicy);
                ((AzureVmPolicy)policy).RetentionPolicy = retentionPolicy;
                Logger.Instance.WriteDebug("Validation of Retention policy is successful");
            }

            // copy the backupSchedule time to retentionPolicy after converting to UTC
            CopyScheduleTimeToRetentionTimes(
                (CmdletModel.LongTermRetentionPolicy)((AzureVmPolicy)policy).RetentionPolicy,
                (CmdletModel.SimpleSchedulePolicy)((AzureVmPolicy)policy).SchedulePolicy);
            Logger.Instance.WriteDebug("Copy of RetentionTime from with SchedulePolicy to RetentionPolicy is successful");

            // Now validate both RetentionPolicy and SchedulePolicy matches or not
            PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleRetentionPolicy(
                (CmdletModel.LongTermRetentionPolicy)((AzureVmPolicy)policy).RetentionPolicy,
                (CmdletModel.SimpleSchedulePolicy)((AzureVmPolicy)policy).SchedulePolicy);
            Logger.Instance.WriteDebug("Validation of Retention policy with Schedule policy is successful");

            // construct Service Client policy request            
            ProtectionPolicyRequest serviceClientRequest = new ProtectionPolicyRequest()
            {
                Item = new ProtectionPolicyResource()
                {
                    Properties = new AzureIaaSVMProtectionPolicy()
                    {
                        RetentionPolicy = PolicyHelpers.GetServiceClientLongTermRetentionPolicy(
                                  (CmdletModel.LongTermRetentionPolicy)((AzureVmPolicy)policy).RetentionPolicy),
                        SchedulePolicy = PolicyHelpers.GetServiceClientSimpleSchedulePolicy(
                                  (CmdletModel.SimpleSchedulePolicy)((AzureVmPolicy)policy).SchedulePolicy)
                    }
                }
            };

            return ServiceClientAdapter.CreateOrUpdateProtectionPolicy(policy.Name,
                                                               serviceClientRequest);
        }

        /// <summary>
        /// Lists protection containers according to the provider data
        /// </summary>
        /// <returns>List of protection containers</returns>
        public List<ContainerBase> ListProtectionContainers()
        {
            Models.ContainerType containerType = 
                (Models.ContainerType)this.ProviderData[ContainerParams.ContainerType];
            Models.BackupManagementType? backupManagementTypeNullable = 
                (Models.BackupManagementType?)this.ProviderData[ContainerParams.BackupManagementType];
            string name = (string)this.ProviderData[ContainerParams.Name];
            string friendlyName = (string)this.ProviderData[ContainerParams.FriendlyName];
            string resourceGroupName = (string)this.ProviderData[ContainerParams.ResourceGroupName];
            ContainerRegistrationStatus status = 
                (ContainerRegistrationStatus)this.ProviderData[ContainerParams.Status];

            if (backupManagementTypeNullable.HasValue)
            {
                ValidateAzureVMBackupManagementType(backupManagementTypeNullable.Value);
            }

            string nameQueryFilter = friendlyName;

            if (!string.IsNullOrEmpty(name))
            {
                Logger.Instance.WriteWarning(Resources.GetContainerNameParamDeprecated);

                if (string.IsNullOrEmpty(friendlyName))
                {
                    nameQueryFilter = name;
                }
            }

            ProtectionContainerListQueryParams queryParams = new ProtectionContainerListQueryParams();

            // 1. Filter by Name
            queryParams.FriendlyName = nameQueryFilter;

            // 2. Filter by ContainerType
            queryParams.BackupManagementType =
                ServiceClientModel.BackupManagementType.AzureIaasVM.ToString();

            // 3. Filter by Status
            if (status != 0)
            {
                queryParams.RegistrationStatus = status.ToString();
            }

            var listResponse = ServiceClientAdapter.ListContainers(queryParams);

            List<ContainerBase> containerModels = ConversionHelpers.GetContainerModelList(listResponse);

            // 4. Filter by RG Name
            if (!string.IsNullOrEmpty(resourceGroupName))
            {
                containerModels = containerModels.Where(
                    containerModel =>
                    {
                        return string.Compare(
                            (containerModel as AzureVmContainer).ResourceGroupName, 
                            resourceGroupName, 
                            true) == 0;
                    }).ToList();
            }

            return containerModels;
        }

        public List<CmdletModel.BackupEngineBase> ListBackupManagementServers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists protected items protected by the recovery services vault according to the provider data
        /// </summary>
        /// <returns>List of protected items</returns>
        public List<ItemBase> ListProtectedItems()
        {
            ContainerBase container =
                (ContainerBase)this.ProviderData[ItemParams.Container];
            string name = (string)this.ProviderData[ItemParams.AzureVMName];
            ItemProtectionStatus protectionStatus =
                (ItemProtectionStatus)this.ProviderData[ItemParams.ProtectionStatus];
            ItemProtectionState status = 
                (ItemProtectionState)this.ProviderData[ItemParams.ProtectionState];
            Models.WorkloadType workloadType =
                (Models.WorkloadType)this.ProviderData[ItemParams.WorkloadType];

            ProtectedItemListQueryParam queryParams = new ProtectedItemListQueryParam();
            queryParams.DatasourceType = ServiceClientModel.WorkloadType.VM;
            queryParams.BackupManagementType = ServiceClientModel.BackupManagementType.AzureIaasVM.ToString();

            List<ProtectedItemResource> protectedItems = new List<ProtectedItemResource>();
            string skipToken = null;
            PaginationRequest paginationRequest = null;
            do
            {
                var listResponse = ServiceClientAdapter.ListProtectedItem(queryParams, paginationRequest);
                protectedItems.AddRange(listResponse.ItemList.Value);

                ServiceClientHelpers.GetSkipTokenFromNextLink(listResponse.ItemList.NextLink, out skipToken);
                if (skipToken != null)
                {
                    paginationRequest = new PaginationRequest();
                    paginationRequest.SkipToken = skipToken;
                }
            } while (skipToken != null);

            // 1. Filter by container
            if (container != null)
            {
                protectedItems = protectedItems.Where(protectedItem =>
                {
                    Dictionary<UriEnums, string> dictionary = HelperUtils.ParseUri(protectedItem.Id);
                    string containerUri = HelperUtils.GetContainerUri(dictionary, protectedItem.Id);
                    return containerUri.Contains(container.Name);
                }).ToList();
            }

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

                    var getResponse = ServiceClientAdapter.GetProtectedItem(containerUri, protectedItemUri, getItemQueryParams);
                    protectedItemGetResponses.Add(getResponse);
                }
            }

            List<ItemBase> itemModels = ConversionHelpers.GetItemModelList(protectedItems);

            if (!string.IsNullOrEmpty(name))
            {
                for (int i = 0; i < itemModels.Count; i++)
                {
                    AzureVmItemExtendedInfo extendedInfo = new AzureVmItemExtendedInfo();
                    var serviceClientExtendedInfo = ((AzureIaaSVMProtectedItem)protectedItemGetResponses[i].Item.Properties).ExtendedInfo;
                    if (serviceClientExtendedInfo.OldestRecoveryPoint.HasValue)
                    {
                        extendedInfo.OldestRecoveryPoint = serviceClientExtendedInfo.OldestRecoveryPoint;
                    }
                    extendedInfo.PolicyState = serviceClientExtendedInfo.PolicyInconsistent.ToString();
                    extendedInfo.RecoveryPointCount = serviceClientExtendedInfo.RecoveryPointCount;
                    ((AzureVmItem)itemModels[i]).ExtendedInfo = extendedInfo;
                }
            }

            // 3. Filter by item's Protection Status
            if (protectionStatus != 0)
            {
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureVmItem)itemModel).ProtectionStatus == protectionStatus;
                }).ToList();
            }

            // 4. Filter by item's Protection State
            if (status != 0)
            {
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureVmItem)itemModel).ProtectionState == status;
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

        /// <summary>
        /// Constructs the schedule policy object with default inits
        /// </summary>
        /// <returns>Default schedule policy object</returns>
        public SchedulePolicyBase GetDefaultSchedulePolicyObject()
        {
            CmdletModel.SimpleSchedulePolicy defaultSchedule = new CmdletModel.SimpleSchedulePolicy();
            //Default is daily scedule at 10:30 AM local time
            defaultSchedule.ScheduleRunFrequency = ScheduleRunType.Daily;

            DateTime scheduleTime = GenerateRandomTime();
            defaultSchedule.ScheduleRunTimes = new List<DateTime>();
            defaultSchedule.ScheduleRunTimes.Add(scheduleTime);

            defaultSchedule.ScheduleRunDays = new List<DayOfWeek>();
            defaultSchedule.ScheduleRunDays.Add(DayOfWeek.Sunday);

            return defaultSchedule;
        }

        /// <summary>
        /// Constructs the retention policy object with default inits
        /// </summary>
        /// <returns>Default retention policy object</returns>
        public RetentionPolicyBase GetDefaultRetentionPolicyObject()
        {
            CmdletModel.LongTermRetentionPolicy defaultRetention = new CmdletModel.LongTermRetentionPolicy();

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
            defaultRetention.MonthlySchedule.RetentionScheduleFormatType = 
                Models.RetentionScheduleFormat.Weekly;

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
            defaultRetention.YearlySchedule.RetentionScheduleFormatType = 
                Models.RetentionScheduleFormat.Weekly;
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
            return new DateTime(DateTime.Now.Year, 
                DateTime.Now.Month, 
                DateTime.Now.Day, 
                hour, 
                minute, 
                00, 
                DateTimeKind.Utc);
        }


        #region private
        private void ValidateAzureVMWorkloadType(CmdletModel.WorkloadType type)
        {
            if (type != CmdletModel.WorkloadType.AzureVM)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedWorkLoadTypeException,
                                            CmdletModel.WorkloadType.AzureVM.ToString(),
                                            type.ToString()));
            }
        }

        private void ValidateAzureVMWorkloadType(CmdletModel.WorkloadType itemWorkloadType,
            CmdletModel.WorkloadType policyWorkloadType)
        {
            ValidateAzureVMWorkloadType(itemWorkloadType);
            ValidateAzureVMWorkloadType(policyWorkloadType);
            if (itemWorkloadType != policyWorkloadType)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedWorkLoadTypeException,
                                            CmdletModel.WorkloadType.AzureVM.ToString(),
                                            itemWorkloadType.ToString()));
            }
        }

        private void ValidateAzureVMContainerType(CmdletModel.ContainerType type)
        {
            if (type != CmdletModel.ContainerType.AzureVM)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedContainerTypeException,
                                            CmdletModel.ContainerType.AzureVM.ToString(),
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

        private void ValidateAzureVMProtectionPolicy(PolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureVmPolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureVmPolicy).ToString()));
            }

            ValidateAzureVMWorkloadType(policy.WorkloadType);

            // call validation
            policy.Validate();
        }

        private void ValidateAzureVMSchedulePolicy(SchedulePolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(CmdletModel.SimpleSchedulePolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidSchedulePolicyException,
                                            typeof(CmdletModel.SimpleSchedulePolicy).ToString()));
            }

            // call validation
            policy.Validate();
        }

        private void ValidateAzureVMRetentionPolicy(RetentionPolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(CmdletModel.LongTermRetentionPolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidRetentionPolicyException,
                                            typeof(CmdletModel.LongTermRetentionPolicy).ToString()));
            }

            // call validation
            policy.Validate();
        }

        private void ValidateAzureVMEnableProtectionRequest(string vmName, string serviceName, string rgName,
            PolicyBase policy)
        {
            if (string.IsNullOrEmpty(vmName))
            {
                throw new ArgumentException(string.Format(Resources.InvalidAzureVMName));
            }
            if (string.IsNullOrEmpty(rgName) && string.IsNullOrEmpty(serviceName))
            {
                throw new ArgumentException(
                    string.Format(Resources.BothCloudServiceNameAndResourceGroupNameShouldNotEmpty)
                    );
            }
        }

        private void ValidateAzureVMModifyProtectionRequest(ItemBase itemBase,
            PolicyBase policy)
        {
            if (itemBase == null || itemBase.GetType() != typeof(AzureVmItem))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureVmItem).ToString()));
            }

            if (string.IsNullOrEmpty(((AzureVmItem)itemBase).VirtualMachineId))
            {
                throw new ArgumentException(Resources.VirtualMachineIdIsEmptyOrNull);
            }
        }

        private void ValidateAzureVMDisableProtectionRequest(ItemBase itemBase)
        {

            if (itemBase == null || itemBase.GetType() != typeof(AzureVmItem))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureVmItem).ToString()));
            }

            if (string.IsNullOrEmpty(((AzureVmItem)itemBase).VirtualMachineId))
            {
                throw new ArgumentException(Resources.VirtualMachineIdIsEmptyOrNull);
            }

            ValidateAzureVMWorkloadType(itemBase.WorkloadType);
            ValidateAzureVMContainerType(itemBase.ContainerType);
        }

        private bool IsComputeAzureVM(string virtualMachineId)
        {
            bool isComputeAzureVM = true;
            if (virtualMachineId.IndexOf(classicComputeAzureVMVersion, 
                StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                isComputeAzureVM = false;
            }
            return isComputeAzureVM;
        }

        private ProtectableObjectResource GetAzureVMProtectableObject
            (
            string azureVMName, 
            string azureVMRGName, 
            bool isComputeAzureVM
            )
        {
            //TriggerDiscovery if needed

            bool isDiscoveryNeed = false;

            ProtectableObjectResource protectableObjectResource = null;
            isDiscoveryNeed = IsDiscoveryNeeded(
                azureVMName, 
                azureVMRGName, 
                isComputeAzureVM, 
                out protectableObjectResource);
            if (isDiscoveryNeed)
            {
                Logger.Instance.WriteDebug(String.Format(Resources.VMNotDiscovered, azureVMName));
                RefreshContainer();
                isDiscoveryNeed = IsDiscoveryNeeded(
                    azureVMName, 
                    azureVMRGName, 
                    isComputeAzureVM, 
                    out protectableObjectResource);
                if (isDiscoveryNeed == true)
                {
                    // Container is not discovered. Throw exception
                    string vmversion = (isComputeAzureVM) ? 
                        computeAzureVMVersion : 
                        classicComputeAzureVMVersion;
                    string errMsg = String.Format(Resources.DiscoveryFailure, 
                        azureVMName, 
                        azureVMRGName, 
                        vmversion);
                    Logger.Instance.WriteDebug(errMsg);
                    Logger.Instance.ThrowTerminatingError(
                        new ErrorRecord(new Exception(Resources.AzureVMNotFound), 
                            string.Empty, 
                            ErrorCategory.InvalidArgument, 
                            null));
                }
            }
            if (protectableObjectResource == null)
            {
                // Container is not discovered. Throw exception
                string vmversion = (isComputeAzureVM) ? 
                    computeAzureVMVersion : classicComputeAzureVMVersion;
                string errMsg = String.Format(
                    Resources.DiscoveryFailure, 
                    azureVMName, 
                    azureVMRGName, 
                    vmversion);
                Logger.Instance.WriteDebug(errMsg);
                Logger.Instance.ThrowTerminatingError(
                    new ErrorRecord(new Exception(Resources.AzureVMNotFound), 
                        string.Empty, ErrorCategory.InvalidArgument, null));
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
            // --- TBD To be added once bug is fixed in Service Client and service
            //queryParam.ProviderType = ProviderType.AzureIaasVM.ToString();
            //queryParam.FriendlyName = vmName;

            // No need to use skip or top token here as no pagination support of IaaSVM PO.

            //First check if container is discovered or not
            var protectableItemList = ServiceClientAdapter.ListProtectableItem(queryParam).ItemList;

            Logger.Instance.WriteDebug(String.Format(Resources.ContainerCountAfterFilter, 
                protectableItemList.ProtectableObjects.Count()));
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
                    AzureIaaSVMProtectableItem iaaSVMProtectableItem = 
                        (AzureIaaSVMProtectableItem)protectableItem.Properties;
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
            var refreshContainerJobResponse = ServiceClientAdapter.RefreshContainers();

            //Now wait for the operation to Complete
            if (refreshContainerJobResponse.StatusCode != System.Net.HttpStatusCode.NoContent)
            {
                errorMessage = String.Format(Resources.DiscoveryFailureErrorCode, 
                    refreshContainerJobResponse.StatusCode);
                Logger.Instance.WriteDebug(errorMessage);
            }
        }

        private HttpStatusCode TrackRefreshContainerOperation(string operationResultLink, 
            int checkFrequency = defaultOperationStatusRetryTimeInMilliSec)
        {
            HttpStatusCode status = HttpStatusCode.Accepted;
            while (status == HttpStatusCode.Accepted)
            {
                try
                {
                    var response = ServiceClientAdapter.GetRefreshContainerOperationResultByURL(operationResultLink);
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

        private static string GetAzureIaasVirtualMachineId(
            string resourceGroup, 
            string vmVersion, 
            string name)
        {
            string IaasVMIdFormat = "/resourceGroups/{0}/providers/{1}/virtualMachines/{2}";
            return string.Format(IaasVMIdFormat, resourceGroup, vmVersion, name);
        }

        private void CopyScheduleTimeToRetentionTimes(CmdletModel.LongTermRetentionPolicy retPolicy,
                                                      CmdletModel.SimpleSchedulePolicy schPolicy)
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
