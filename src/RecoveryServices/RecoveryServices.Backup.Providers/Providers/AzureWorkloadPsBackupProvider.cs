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
using Microsoft.Rest.Azure.OData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using RestAzureNS = Microsoft.Rest.Azure;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    /// <summary>
    /// This class implements methods for azure DB Workload backup provider
    /// </summary>
    public class AzureWorkloadPsBackupProvider : IPsBackupProvider
    {
        private const int defaultOperationStatusRetryTimeInMilliSec = 5 * 1000; // 5 sec
        private const string separator = ";";
        Dictionary<Enum, object> ProviderData { get; set; }
        ServiceClientAdapter ServiceClientAdapter { get; set; }
        AzureWorkloadProviderHelper AzureWorkloadProviderHelper { get; set; }

        /// <summary>
        /// Initializes the provider with the data received from the cmdlet layer
        /// </summary>
        /// <param name="providerData">Data from the cmdlet layer intended for the provider</param>
        /// <param name="serviceClientAdapter">Service client adapter for communicating with the backend service</param>
        public void Initialize(Dictionary<Enum, object> providerData, ServiceClientAdapter serviceClientAdapter)
        {
            ProviderData = providerData;
            ServiceClientAdapter = serviceClientAdapter;
            AzureWorkloadProviderHelper = new AzureWorkloadProviderHelper(ServiceClientAdapter);
        }

        public ResourceBackupStatus CheckBackupStatus()
        {
            throw new NotImplementedException();
        }

        public ProtectionPolicyResource CreatePolicy()
        {
            return CreateorModifyPolicy().Body;
        }

        public RestAzureNS.AzureOperationResponse<ProtectedItemResource> DisableProtection()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string vaultResourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            bool deleteBackupData = ProviderData.ContainsKey(ItemParams.DeleteBackupData) ?
                (bool)ProviderData[ItemParams.DeleteBackupData] : false;

            ItemBase itemBase = (ItemBase)ProviderData[ItemParams.Item];

            AzureItem item;
            if (itemBase.WorkloadType == CmdletModel.WorkloadType.SAPHanaDatabase)
            {
                item = (AzureWorkloadSAPHanaDatabaseProtectedItem)ProviderData[ItemParams.Item];                
            }
            else
            {
                item = (AzureWorkloadSQLDatabaseProtectedItem)ProviderData[ItemParams.Item];                
            }
            
            AzureVmWorkloadSQLDatabaseProtectedItem properties = new AzureVmWorkloadSQLDatabaseProtectedItem();

            return EnableOrModifyProtection(disableWithRetentionData: true);

        }

        public RestAzureNS.AzureOperationResponse DisableProtectionWithDeleteData()
        {   
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string vaultResourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            bool deleteBackupData = ProviderData.ContainsKey(ItemParams.DeleteBackupData) ?
                (bool)ProviderData[ItemParams.DeleteBackupData] : false;
            string auxiliaryAccessToken = ProviderData.ContainsKey(ResourceGuardParams.Token) ? (string)ProviderData[ResourceGuardParams.Token] : null;
            ItemBase itemBase = (ItemBase)ProviderData[ItemParams.Item];
            string containerUri = "";
            string protectedItemUri = "";

            AzureItem item;
            if (itemBase.WorkloadType == CmdletModel.WorkloadType.SAPHanaDatabase)
            {
                item = (AzureWorkloadSAPHanaDatabaseProtectedItem)ProviderData[ItemParams.Item];
                ValidateAzureWorkloadSAPHanaDatabaseDisableProtectionRequest(itemBase);
            }
            else
            {
                item = (AzureWorkloadSQLDatabaseProtectedItem)ProviderData[ItemParams.Item];
                ValidateAzureWorkloadSQLDatabaseDisableProtectionRequest(itemBase);
            }

            Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
            containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
            protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);

            return ServiceClientAdapter.DeleteProtectedItem(
                                containerUri,
                                protectedItemUri,
                                vaultName: vaultName,
                                resourceGroupName: vaultResourceGroupName,
                                auxiliaryAccessToken,
                                item.Id);
        }

        public RestAzureNS.AzureOperationResponse<ProtectedItemResource> SuspendBackup()
        {   
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];

            ItemBase itemBase = (ItemBase)ProviderData[ItemParams.Item];

            // do validations
            ValidateAzureWorkloadDisableProtectionRequest(itemBase);

            Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(itemBase.Id);
            string containerUri = HelperUtils.GetContainerUri(keyValueDict, itemBase.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, itemBase.Id);

            AzureVmWorkloadProtectedItem properties = new AzureVmWorkloadProtectedItem();

            properties.ProtectionState = ProtectionState.BackupsSuspended;
            properties.SourceResourceId = itemBase.SourceResourceId;

            ProtectedItemResource serviceClientRequest = new ProtectedItemResource()
            {
                Properties = properties,
            };

            return ServiceClientAdapter.CreateOrUpdateProtectedItem(
                containerUri,
                protectedItemUri,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
        }

        public RestAzureNS.AzureOperationResponse<ProtectedItemResource> UndeleteProtection()
        {   
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            AzureWorkloadSQLDatabaseProtectedItem item = (AzureWorkloadSQLDatabaseProtectedItem)ProviderData[ItemParams.Item];

            Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);

            AzureVmWorkloadSQLDatabaseProtectedItem properties = new AzureVmWorkloadSQLDatabaseProtectedItem();

            properties.PolicyId = null;
            properties.ProtectionState = ProtectionState.ProtectionStopped;
            properties.SourceResourceId = item.SourceResourceId;
            properties.IsRehydrate = true;

            ProtectedItemResource serviceClientRequest = new ProtectedItemResource()
            {
                Properties = properties,
            };

            return ServiceClientAdapter.CreateOrUpdateProtectedItem(
                containerUri,
                protectedItemUri,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
        }

        public RestAzureNS.AzureOperationResponse<ProtectedItemResource> EnableProtection()
        {
            return EnableOrModifyProtection();
        }

        public RetentionPolicyBase GetDefaultRetentionPolicyObject()
        {
            SQLRetentionPolicy defaultRetention = new SQLRetentionPolicy();
            DateTime retentionTime = AzureWorkloadProviderHelper.GenerateRandomScheduleTime();

            defaultRetention.FullBackupRetentionPolicy = new CmdletModel.LongTermRetentionPolicy();
            defaultRetention.DifferentialBackupRetentionPolicy = new CmdletModel.SimpleRetentionPolicy();
            defaultRetention.LogBackupRetentionPolicy = new CmdletModel.SimpleRetentionPolicy();

            //Setup FullBackupRetentionPolicy
            //Daily Retention policy
            defaultRetention.FullBackupRetentionPolicy.IsDailyScheduleEnabled = true;
            defaultRetention.FullBackupRetentionPolicy.DailySchedule = new CmdletModel.DailyRetentionSchedule();
            defaultRetention.FullBackupRetentionPolicy.DailySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.FullBackupRetentionPolicy.DailySchedule.RetentionTimes.Add(retentionTime);
            defaultRetention.FullBackupRetentionPolicy.DailySchedule.DurationCountInDays = 180; //TBD make it const

            //Weekly Retention policy
            defaultRetention.FullBackupRetentionPolicy.IsWeeklyScheduleEnabled = true;
            defaultRetention.FullBackupRetentionPolicy.WeeklySchedule = new CmdletModel.WeeklyRetentionSchedule();
            defaultRetention.FullBackupRetentionPolicy.WeeklySchedule.DaysOfTheWeek = new List<System.DayOfWeek>();
            defaultRetention.FullBackupRetentionPolicy.WeeklySchedule.DaysOfTheWeek.Add(System.DayOfWeek.Sunday);
            defaultRetention.FullBackupRetentionPolicy.WeeklySchedule.DurationCountInWeeks = 104; //TBD make it const
            defaultRetention.FullBackupRetentionPolicy.WeeklySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.FullBackupRetentionPolicy.WeeklySchedule.RetentionTimes.Add(retentionTime);

            //Monthly retention policy
            defaultRetention.FullBackupRetentionPolicy.IsMonthlyScheduleEnabled = true;
            defaultRetention.FullBackupRetentionPolicy.MonthlySchedule = new CmdletModel.MonthlyRetentionSchedule();
            defaultRetention.FullBackupRetentionPolicy.MonthlySchedule.DurationCountInMonths = 60; //tbd: make it const
            defaultRetention.FullBackupRetentionPolicy.MonthlySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.FullBackupRetentionPolicy.MonthlySchedule.RetentionTimes.Add(retentionTime);
            defaultRetention.FullBackupRetentionPolicy.MonthlySchedule.RetentionScheduleFormatType =
            CmdletModel.RetentionScheduleFormat.Weekly;

            //Initialize day based schedule
            defaultRetention.FullBackupRetentionPolicy.MonthlySchedule.RetentionScheduleDaily = AzureWorkloadProviderHelper.GetDailyRetentionFormat();

            //Initialize Week based schedule
            defaultRetention.FullBackupRetentionPolicy.MonthlySchedule.RetentionScheduleWeekly = AzureWorkloadProviderHelper.GetWeeklyRetentionFormat();

            //Yearly retention policy
            defaultRetention.FullBackupRetentionPolicy.IsYearlyScheduleEnabled = true;
            defaultRetention.FullBackupRetentionPolicy.YearlySchedule = new CmdletModel.YearlyRetentionSchedule();
            defaultRetention.FullBackupRetentionPolicy.YearlySchedule.DurationCountInYears = 10;
            defaultRetention.FullBackupRetentionPolicy.YearlySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.FullBackupRetentionPolicy.YearlySchedule.RetentionTimes.Add(retentionTime);
            defaultRetention.FullBackupRetentionPolicy.YearlySchedule.RetentionScheduleFormatType =
            CmdletModel.RetentionScheduleFormat.Weekly;
            defaultRetention.FullBackupRetentionPolicy.YearlySchedule.MonthsOfYear = new List<Month>();
            defaultRetention.FullBackupRetentionPolicy.YearlySchedule.MonthsOfYear.Add(Month.January);
            defaultRetention.FullBackupRetentionPolicy.YearlySchedule.RetentionScheduleDaily = AzureWorkloadProviderHelper.GetDailyRetentionFormat();
            defaultRetention.FullBackupRetentionPolicy.YearlySchedule.RetentionScheduleWeekly = AzureWorkloadProviderHelper.GetWeeklyRetentionFormat();

            //Setup DifferentialBackupRetentionPolicy
            defaultRetention.DifferentialBackupRetentionPolicy.RetentionDurationType = CmdletModel.RetentionDurationType.Days;
            defaultRetention.DifferentialBackupRetentionPolicy.RetentionCount = 30;

            //Setup LogBackupRetentionPolicy
            defaultRetention.LogBackupRetentionPolicy.RetentionDurationType = CmdletModel.RetentionDurationType.Days;
            defaultRetention.LogBackupRetentionPolicy.RetentionCount = 15;

            return defaultRetention;
        }

        public SchedulePolicyBase GetDefaultSchedulePolicyObject()
        {
            SQLSchedulePolicy defaultSchedule = new SQLSchedulePolicy();

            defaultSchedule.FullBackupSchedulePolicy = new CmdletModel.SimpleSchedulePolicy();
            defaultSchedule.DifferentialBackupSchedulePolicy = new CmdletModel.SimpleSchedulePolicy();
            defaultSchedule.LogBackupSchedulePolicy = new CmdletModel.LogSchedulePolicy();
            defaultSchedule.IsDifferentialBackupEnabled = false;
            defaultSchedule.IsLogBackupEnabled = true;
            defaultSchedule.IsCompression = false;

            //Setup FullBackupSchedulePolicy
            defaultSchedule.FullBackupSchedulePolicy.ScheduleRunFrequency = CmdletModel.ScheduleRunType.Daily;
            DateTime scheduleTime = AzureWorkloadProviderHelper.GenerateRandomScheduleTime();
            defaultSchedule.FullBackupSchedulePolicy.ScheduleRunTimes = new List<DateTime>();
            defaultSchedule.FullBackupSchedulePolicy.ScheduleRunTimes.Add(scheduleTime);

            defaultSchedule.FullBackupSchedulePolicy.ScheduleRunDays = new List<System.DayOfWeek>();
            defaultSchedule.FullBackupSchedulePolicy.ScheduleRunDays.Add(System.DayOfWeek.Sunday);

            //Setup DifferentialBackupSchedulePolicy
            defaultSchedule.DifferentialBackupSchedulePolicy.ScheduleRunFrequency = CmdletModel.ScheduleRunType.Weekly;
            defaultSchedule.DifferentialBackupSchedulePolicy.ScheduleRunTimes = new List<DateTime>();
            defaultSchedule.DifferentialBackupSchedulePolicy.ScheduleRunTimes.Add(scheduleTime);

            defaultSchedule.DifferentialBackupSchedulePolicy.ScheduleRunDays = new List<System.DayOfWeek>();
            defaultSchedule.DifferentialBackupSchedulePolicy.ScheduleRunDays.Add(System.DayOfWeek.Monday);

            //Setup LogBackupSchedulePolicy
            defaultSchedule.LogBackupSchedulePolicy.ScheduleFrequencyInMins = 120;

            return defaultSchedule;
        }

        public ProtectedItemResource GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        public RecoveryPointBase GetRecoveryPointDetails()
        {
            return AzureWorkloadProviderHelper.GetRecoveryPointDetails(ProviderData);
        }

        public List<CmdletModel.BackupEngineBase> ListBackupManagementServers()
        {
            throw new NotImplementedException();
        }

        public List<ItemBase> ListProtectedItems()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            ContainerBase container =
                (ContainerBase)ProviderData[ItemParams.Container];
            string itemName = (string)ProviderData[ItemParams.ItemName];
            ItemProtectionStatus protectionStatus =
                (ItemProtectionStatus)ProviderData[ItemParams.ProtectionStatus];
            ItemProtectionState status =
                (ItemProtectionState)ProviderData[ItemParams.ProtectionState];
            CmdletModel.WorkloadType workloadType =
                (CmdletModel.WorkloadType)ProviderData[ItemParams.WorkloadType];
            bool UseSecondaryRegion = (bool)ProviderData[CRRParams.UseSecondaryRegion];
            PolicyBase policy = (PolicyBase)ProviderData[PolicyParams.ProtectionPolicy];

            string dataSourceType = (workloadType == CmdletModel.WorkloadType.SAPHanaDatabase) ? DataSourceType.SAPHanaDatabase : DataSourceType.SQLDataBase;
            
            List<CrrModel.ProtectedItemResource> protectedItemsCrr = null;
            List<ProtectedItemResource> protectedItems = null;
            List<ItemBase> itemModels = null;
            if (UseSecondaryRegion)
            {                
                // 1. Filter by container
                protectedItemsCrr = AzureWorkloadProviderHelper.ListProtectedItemsByContainerCrr(
                vaultName,
                resourceGroupName,
                container,
                policy,
                ServiceClientModel.BackupManagementType.AzureWorkload,
                dataSourceType);
                
                itemModels = AzureWorkloadProviderHelper.ListProtectedItemsByItemNameCrr(
                protectedItemsCrr,
                itemName,
                vaultName,
                resourceGroupName,
                (itemModel, protectedItemGetResponse) =>
                {
                    AzureWorkloadSQLDatabaseProtectedItemExtendedInfo extendedInfo = new AzureWorkloadSQLDatabaseProtectedItemExtendedInfo();
                    var serviceClientExtendedInfo = ((AzureVmWorkloadSQLDatabaseProtectedItem)protectedItemGetResponse.Properties).ExtendedInfo;
                    if (serviceClientExtendedInfo.OldestRecoveryPoint.HasValue)
                    {
                        extendedInfo.OldestRecoveryPoint = serviceClientExtendedInfo.OldestRecoveryPoint;
                    }
                    extendedInfo.PolicyState = serviceClientExtendedInfo.PolicyState.ToString();
                    extendedInfo.RecoveryPointCount =
                        (int)(serviceClientExtendedInfo.RecoveryPointCount.HasValue ?
                            serviceClientExtendedInfo.RecoveryPointCount : 0);
                    ((AzureWorkloadSQLDatabaseProtectedItem)itemModel).LatestRecoveryPoint = ((AzureVmWorkloadSQLDatabaseProtectedItem)protectedItemGetResponse.Properties).LastRecoveryPoint;
                    ((AzureWorkloadSQLDatabaseProtectedItem)itemModel).ExtendedInfo = extendedInfo;
                });                
            }
            else
            {
                // 1. Filter by container
                protectedItems = AzureWorkloadProviderHelper.ListProtectedItemsByContainer(
                vaultName,
                resourceGroupName,
                container,
                policy,
                ServiceClientModel.BackupManagementType.AzureWorkload,
                dataSourceType);

                // 2. Filter by item name
                itemModels = AzureWorkloadProviderHelper.ListProtectedItemsByItemName(
                    protectedItems,
                    itemName,
                    vaultName,
                    resourceGroupName,
                    (itemModel, protectedItemGetResponse) =>
                    {
                        AzureWorkloadSQLDatabaseProtectedItemExtendedInfo extendedInfo = new AzureWorkloadSQLDatabaseProtectedItemExtendedInfo();
                        var serviceClientExtendedInfo = ((AzureVmWorkloadSQLDatabaseProtectedItem)protectedItemGetResponse.Properties).ExtendedInfo;
                        if (serviceClientExtendedInfo.OldestRecoveryPoint.HasValue)
                        {
                            extendedInfo.OldestRecoveryPoint = serviceClientExtendedInfo.OldestRecoveryPoint;
                        }
                        extendedInfo.PolicyState = serviceClientExtendedInfo.PolicyState.ToString();
                        extendedInfo.RecoveryPointCount =
                            (int)(serviceClientExtendedInfo.RecoveryPointCount.HasValue ?
                                serviceClientExtendedInfo.RecoveryPointCount : 0);
                        ((AzureWorkloadSQLDatabaseProtectedItem)itemModel).LatestRecoveryPoint = ((AzureVmWorkloadSQLDatabaseProtectedItem)protectedItemGetResponse.Properties).LastRecoveryPoint;
                        ((AzureWorkloadSQLDatabaseProtectedItem)itemModel).ExtendedInfo = extendedInfo;
                    });
            }
            
            // 3. Filter by item's Protection Status
            if (protectionStatus != 0)
            {
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureWorkloadSQLDatabaseProtectedItem)itemModel).ProtectionStatus == protectionStatus;
                }).ToList();
            }

            // 4. Filter by item's Protection State
            if (status != 0)
            {
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureWorkloadSQLDatabaseProtectedItem)itemModel).ProtectionState == status;
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

        public List<ContainerBase> ListProtectionContainers()
        {
            CmdletModel.BackupManagementType? backupManagementTypeNullable =
                (CmdletModel.BackupManagementType?)
                    ProviderData[ContainerParams.BackupManagementType];

            if (backupManagementTypeNullable.HasValue)
            {
                ValidateAzureWorkloadBackupManagementType(backupManagementTypeNullable.Value);
            }

            return AzureWorkloadProviderHelper.ListProtectionContainers(
               ProviderData,
               ServiceClientModel.BackupManagementType.AzureWorkload);
        }

        public List<RecoveryPointBase> ListRecoveryPoints()
        {
            return AzureWorkloadProviderHelper.ListRecoveryPoints(ProviderData);
        }

        public RestAzureNS.AzureOperationResponse<ProtectionPolicyResource> ModifyPolicy()
        {
            return CreateorModifyPolicy();
        }

        public RPMountScriptDetails ProvisionItemLevelRecoveryAccess()
        {
            throw new NotImplementedException();
        }

        public void RevokeItemLevelRecoveryAccess()
        {
            throw new NotImplementedException();
        }

        public RestAzureNS.AzureOperationResponse TriggerBackup()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string vaultResourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            ItemBase item = (ItemBase)ProviderData[ItemParams.Item];
            DateTime? expiryDateTime = (DateTime?)ProviderData[ItemParams.ExpiryDateTimeUTC];
            string backupType = ProviderData[ItemParams.BackupType].ToString();
            bool enableCompression = (bool)ProviderData[ItemParams.EnableCompression];
            AzureWorkloadSQLDatabaseProtectedItem azureWorkloadProtectedItem = item as AzureWorkloadSQLDatabaseProtectedItem;
            BackupRequestResource triggerBackupRequest = new BackupRequestResource();
            AzureWorkloadBackupRequest azureWorkloadBackupRequest = new AzureWorkloadBackupRequest();
            azureWorkloadBackupRequest.RecoveryPointExpiryTimeInUtc = expiryDateTime;
            azureWorkloadBackupRequest.BackupType = backupType;
            azureWorkloadBackupRequest.EnableCompression = enableCompression;
            triggerBackupRequest.Properties = azureWorkloadBackupRequest;

            return ServiceClientAdapter.TriggerBackup(
               IdUtils.GetValueByName(azureWorkloadProtectedItem.Id, IdUtils.IdNames.ProtectionContainerName),
               IdUtils.GetValueByName(azureWorkloadProtectedItem.Id, IdUtils.IdNames.ProtectedItemName),
               triggerBackupRequest,
               vaultName: vaultName,
               resourceGroupName: vaultResourceGroupName);
        }

        public RestAzureNS.AzureOperationResponse TriggerRestore()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            string vaultLocation = (string)ProviderData[VaultParams.VaultLocation];
            RecoveryConfigBase wLRecoveryConfigBase =
                (RecoveryConfigBase)ProviderData[RestoreWLBackupItemParams.WLRecoveryConfig];
            AzureWorkloadRecoveryConfig wLRecoveryConfig =
                (AzureWorkloadRecoveryConfig)ProviderData[RestoreWLBackupItemParams.WLRecoveryConfig];
            RestoreRequestResource triggerRestoreRequest = new RestoreRequestResource();
            bool useSecondaryRegion = (bool)ProviderData[CRRParams.UseSecondaryRegion];
            String secondaryRegion = useSecondaryRegion ? (string)ProviderData[CRRParams.SecondaryRegion] : null;
            string rehydrateDuration = ProviderData.ContainsKey(RecoveryPointParams.RehydrateDuration) ?
                ProviderData[RecoveryPointParams.RehydrateDuration].ToString() : "15";
            string rehydratePriority = ProviderData.ContainsKey(RecoveryPointParams.RehydratePriority) ?
                ProviderData[RecoveryPointParams.RehydratePriority].ToString() : null;
            string auxiliaryAccessToken = ProviderData.ContainsKey(ResourceGuardParams.Token) ? (string)ProviderData[ResourceGuardParams.Token] : null;
            bool isMUAOperation = ProviderData.ContainsKey(ResourceGuardParams.IsMUAOperation) ? (bool)ProviderData[ResourceGuardParams.IsMUAOperation] : false;

            if (wLRecoveryConfig.RecoveryPoint.ContainerName != null && wLRecoveryConfig.FullRP == null)
            {
                AzureWorkloadSQLRestoreRequest azureWorkloadSQLRestoreRequest =
                    new AzureWorkloadSQLRestoreRequest();

                azureWorkloadSQLRestoreRequest.SourceResourceId = wLRecoveryConfig.SourceResourceId;
                azureWorkloadSQLRestoreRequest.ShouldUseAlternateTargetLocation =
                    string.Compare(wLRecoveryConfig.RestoreRequestType, "Original WL Restore") != 0 ? true : false;
                azureWorkloadSQLRestoreRequest.IsNonRecoverable =
                    string.Compare(wLRecoveryConfig.NoRecoveryMode, "Enabled") == 0 ? true : false;
                azureWorkloadSQLRestoreRequest.RecoveryType =
                    string.Compare(wLRecoveryConfig.RestoreRequestType, "Original WL Restore") == 0 ?
                    RecoveryType.OriginalLocation : RecoveryType.AlternateLocation;
                if (azureWorkloadSQLRestoreRequest.RecoveryType == RecoveryType.AlternateLocation)
                {
                    azureWorkloadSQLRestoreRequest.TargetInfo = new TargetRestoreInfo()
                    {
                        OverwriteOption = string.Compare(wLRecoveryConfig.OverwriteWLIfpresent, "No") == 0 ?
                        OverwriteOptions.FailOnConflict : OverwriteOptions.Overwrite,
                        DatabaseName = wLRecoveryConfig.TargetInstance + "/" + wLRecoveryConfig.RestoredDBName,
                        ContainerId = wLRecoveryConfig.ContainerId
                    };
                    azureWorkloadSQLRestoreRequest.AlternateDirectoryPaths = wLRecoveryConfig.targetPhysicalPath;

                    if (wLRecoveryConfig.TargetVirtualMachineId != null && wLRecoveryConfig.TargetVirtualMachineId != "")
                    {
                        azureWorkloadSQLRestoreRequest.TargetVirtualMachineId = wLRecoveryConfig.TargetVirtualMachineId;
                    }
                    else
                    {
                        throw new ArgumentException(Resources.TargetVirtualMachineIdRequiredException);
                    }                    
                }
                if (wLRecoveryConfig.RecoveryMode == "FileRecovery")
                {
                    azureWorkloadSQLRestoreRequest.RecoveryMode = "FileRecovery";
                    azureWorkloadSQLRestoreRequest.TargetInfo = new TargetRestoreInfo()
                    {
                        OverwriteOption = string.Compare(wLRecoveryConfig.OverwriteWLIfpresent, "No") == 0 ?
                        OverwriteOptions.FailOnConflict : OverwriteOptions.Overwrite,
                        ContainerId = wLRecoveryConfig.ContainerId,
                        TargetDirectoryForFileRestore = wLRecoveryConfig.FilePath
                    };
                }
                triggerRestoreRequest.Properties = azureWorkloadSQLRestoreRequest;
            }
            else
            {
                AzureWorkloadSQLPointInTimeRestoreRequest azureWorkloadSQLPointInTimeRestoreRequest =
                    new AzureWorkloadSQLPointInTimeRestoreRequest();

                azureWorkloadSQLPointInTimeRestoreRequest.SourceResourceId = wLRecoveryConfig.SourceResourceId;
                azureWorkloadSQLPointInTimeRestoreRequest.ShouldUseAlternateTargetLocation =
                    string.Compare(wLRecoveryConfig.RestoreRequestType, "Original WL Restore") != 0 ? true : false;
                azureWorkloadSQLPointInTimeRestoreRequest.IsNonRecoverable =
                    string.Compare(wLRecoveryConfig.NoRecoveryMode, "Enabled") == 0 ? true : false;
                azureWorkloadSQLPointInTimeRestoreRequest.RecoveryType =
                    string.Compare(wLRecoveryConfig.RestoreRequestType, "Original WL Restore") == 0 ?
                    RecoveryType.OriginalLocation : RecoveryType.AlternateLocation;
                if (azureWorkloadSQLPointInTimeRestoreRequest.RecoveryType == RecoveryType.AlternateLocation)
                {
                    azureWorkloadSQLPointInTimeRestoreRequest.TargetInfo = new TargetRestoreInfo()
                    {
                        OverwriteOption = string.Compare(wLRecoveryConfig.OverwriteWLIfpresent, "No") == 0 ?
                        OverwriteOptions.FailOnConflict : OverwriteOptions.Overwrite,
                        DatabaseName = wLRecoveryConfig.TargetInstance + "/" + wLRecoveryConfig.RestoredDBName,
                        ContainerId = wLRecoveryConfig.ContainerId
                    };
                    azureWorkloadSQLPointInTimeRestoreRequest.AlternateDirectoryPaths = wLRecoveryConfig.targetPhysicalPath;

                    if (wLRecoveryConfig.TargetVirtualMachineId != null && wLRecoveryConfig.TargetVirtualMachineId != "")
                    {
                        azureWorkloadSQLPointInTimeRestoreRequest.TargetVirtualMachineId = wLRecoveryConfig.TargetVirtualMachineId;
                    }
                    else
                    {
                        throw new ArgumentException(Resources.TargetVirtualMachineIdRequiredException);
                    }
                }

                if (wLRecoveryConfig.RecoveryMode == "FileRecovery")
                {
                    azureWorkloadSQLPointInTimeRestoreRequest.RecoveryMode = "FileRecovery";
                    azureWorkloadSQLPointInTimeRestoreRequest.TargetInfo = new TargetRestoreInfo()
                    {
                        OverwriteOption = string.Compare(wLRecoveryConfig.OverwriteWLIfpresent, "No") == 0 ?
                        OverwriteOptions.FailOnConflict : OverwriteOptions.Overwrite,
                        ContainerId = wLRecoveryConfig.ContainerId,
                        TargetDirectoryForFileRestore = wLRecoveryConfig.FilePath
                    };
                }

                azureWorkloadSQLPointInTimeRestoreRequest.PointInTime = wLRecoveryConfig.PointInTime;
                triggerRestoreRequest.Properties = azureWorkloadSQLPointInTimeRestoreRequest;
            }

            if (useSecondaryRegion)
            {
                AzureRecoveryPoint rp = (AzureRecoveryPoint)wLRecoveryConfig.RecoveryPoint;

                // get access token
                CrrModel.CrrAccessToken accessToken = ServiceClientAdapter.GetCRRAccessToken(rp, secondaryRegion, vaultName: vaultName, resourceGroupName: resourceGroupName, ServiceClientModel.BackupManagementType.AzureWorkload);

                // AzureWorkload CRR Request
                Logger.Instance.WriteDebug("Triggering Restore to secondary region: " + secondaryRegion);

                CrrModel.CrossRegionRestoreRequest crrRestoreRequest = new CrrModel.CrossRegionRestoreRequest();
                crrRestoreRequest.CrossRegionRestoreAccessDetails = accessToken;
                                
                // convert restore request to CRR restore request
                if (triggerRestoreRequest.Properties.GetType().Name.Equals("AzureWorkloadSQLPointInTimeRestoreRequest"))
                {
                    var restoreRequestSerialized = JsonConvert.SerializeObject(triggerRestoreRequest.Properties);
                    CrrModel.AzureWorkloadSQLPointInTimeRestoreRequest restoreRequestForSecondaryRegion = JsonConvert.DeserializeObject<CrrModel.AzureWorkloadSQLPointInTimeRestoreRequest>(restoreRequestSerialized);
                    crrRestoreRequest.RestoreRequest = restoreRequestForSecondaryRegion;
                }
                else if(triggerRestoreRequest.Properties.GetType().Name.Equals("AzureWorkloadSQLRestoreRequest"))
                {
                    var restoreRequestSerialized = JsonConvert.SerializeObject(triggerRestoreRequest.Properties);
                    CrrModel.AzureWorkloadSQLRestoreRequest restoreRequestForSecondaryRegion = JsonConvert.DeserializeObject<CrrModel.AzureWorkloadSQLRestoreRequest>(restoreRequestSerialized);
                    crrRestoreRequest.RestoreRequest = restoreRequestForSecondaryRegion;
                }

                // storage account location isn't required in case of workload restore
                var response = ServiceClientAdapter.RestoreDiskSecondryRegion(
                    rp,
                    triggerCRRRestoreRequest: crrRestoreRequest,
                    secondaryRegion: secondaryRegion);
                return response;
            }
            else
            {
                #region Rehydrate Restore 
                CmdletModel.AzureWorkloadRecoveryPoint rp =  (CmdletModel.AzureWorkloadRecoveryPoint)wLRecoveryConfig.RecoveryPoint;

                if(rp.RecoveryPointTier == RecoveryPointTier.VaultArchive && rehydratePriority == null)
                {
                    throw new ArgumentException(Resources.InvalidRehydration); 
                }

                if (rp.RecoveryPointTier == RecoveryPointTier.VaultArchive && rehydratePriority != null)
                {
                    var azureWorkloadRestoreRequestSerialized = JsonConvert.SerializeObject(triggerRestoreRequest.Properties);
                    
                    if (triggerRestoreRequest.Properties.GetType().Equals("AzureWorkloadSQLPointInTimeRestoreRequest"))
                    {
                        Logger.Instance.WriteWarning("Rehyrate restore isn't supported for AzureWorkloadSQLPointInTimeRestore ");                        
                    }
                    else
                    {
                        AzureWorkloadSQLRestoreWithRehydrateRequest azureWorkloadRestoreRequestDeSerialized = JsonConvert.DeserializeObject<AzureWorkloadSQLRestoreWithRehydrateRequest>(azureWorkloadRestoreRequestSerialized);
                        azureWorkloadRestoreRequestDeSerialized.RecoveryPointRehydrationInfo = new RecoveryPointRehydrationInfo();
                        azureWorkloadRestoreRequestDeSerialized.RecoveryPointRehydrationInfo.RehydrationRetentionDuration = "P" + rehydrateDuration + "D"; // P <val> D
                        azureWorkloadRestoreRequestDeSerialized.RecoveryPointRehydrationInfo.RehydrationPriority = rehydratePriority;
                        triggerRestoreRequest.Properties = azureWorkloadRestoreRequestDeSerialized;
                    }
                }
                #endregion

                // check for MUA
                bool isMUAProtected = isMUAOperation;

                var response = ServiceClientAdapter.RestoreDisk(
                (AzureRecoveryPoint)wLRecoveryConfig.RecoveryPoint,
                "LocationNotRequired",
                triggerRestoreRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName,
                vaultLocation: vaultLocation,
                auxiliaryAccessToken,
                isMUAProtected);

                return response;
            }
        }

        private RestAzureNS.AzureOperationResponse<ProtectionPolicyResource> CreateorModifyPolicy()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            string policyName = ProviderData.ContainsKey(PolicyParams.PolicyName) ?
                (string)ProviderData[PolicyParams.PolicyName] : null;
            
            RetentionPolicyBase retentionPolicy = ProviderData.ContainsKey(PolicyParams.RetentionPolicy) ? (RetentionPolicyBase)ProviderData[PolicyParams.RetentionPolicy] : null;
            SchedulePolicyBase schedulePolicy = ProviderData.ContainsKey(PolicyParams.SchedulePolicy) ? (SchedulePolicyBase)ProviderData[PolicyParams.SchedulePolicy] : null;
            PolicyBase policy = ProviderData.ContainsKey(PolicyParams.ProtectionPolicy) ? (PolicyBase)ProviderData[PolicyParams.ProtectionPolicy] : null;           

            bool fixForInconsistentItems = ProviderData.ContainsKey(PolicyParams.FixForInconsistentItems) ? (bool)ProviderData[PolicyParams.FixForInconsistentItems] : false;

            ProtectionPolicyResource serviceClientRequest = new ProtectionPolicyResource();

            string auxiliaryAccessToken = ProviderData.ContainsKey(ResourceGuardParams.Token) ? (string)ProviderData[ResourceGuardParams.Token] : null;
            bool isMUAOperation = ProviderData.ContainsKey(ResourceGuardParams.IsMUAOperation) ? (bool)ProviderData[ResourceGuardParams.IsMUAOperation] : false;
            ProtectionPolicyResource existingPolicy = ProviderData.ContainsKey(PolicyParams.ExistingPolicy) ? (ProtectionPolicyResource)ProviderData[PolicyParams.ExistingPolicy] : null;

            CmdletModel.TieringPolicy tieringDetails = ProviderData.ContainsKey(PolicyParams.TieringPolicy) ? (CmdletModel.TieringPolicy)ProviderData[PolicyParams.TieringPolicy] : null;
            bool isSmartTieringEnabled = ProviderData.ContainsKey(PolicyParams.IsSmartTieringEnabled) ? (bool)ProviderData[PolicyParams.IsSmartTieringEnabled] : false;

            if (policy != null)
            {
                // do validations
                ValidateAzureWorkloadProtectionPolicy(policy);
                Logger.Instance.WriteDebug("Validation of Protection Policy is successful");

                // RetentionPolicy and SchedulePolicy both should not be empty
                if (retentionPolicy == null && schedulePolicy == null && tieringDetails == null)
                {
                    if (fixForInconsistentItems == false)
                    {
                        throw new ArgumentException(Resources.BothRetentionAndSchedulePoliciesEmpty);
                    }
                    AzureVmWorkloadProtectionPolicy azureVmWorkloadModifyPolicy = new AzureVmWorkloadProtectionPolicy();
                    azureVmWorkloadModifyPolicy.Settings = new Settings(((CmdletModel.SimpleSchedulePolicy)((AzureVmWorkloadPolicy)policy).FullBackupSchedulePolicy).ScheduleRunTimeZone,
                        ((AzureVmWorkloadPolicy)policy).IsCompression,
                        ((AzureVmWorkloadPolicy)policy).IsCompression);
                    azureVmWorkloadModifyPolicy.WorkLoadType = ConversionUtils.GetServiceClientWorkloadType(policy.WorkloadType.ToString());
                    azureVmWorkloadModifyPolicy.SubProtectionPolicy = new List<SubProtectionPolicy>();
                    azureVmWorkloadModifyPolicy.SubProtectionPolicy = PolicyHelpers.GetServiceClientSubProtectionPolicy((AzureVmWorkloadPolicy)policy, isSmartTieringEnabled);
                    azureVmWorkloadModifyPolicy.MakePolicyConsistent = true;
                    serviceClientRequest.Properties = azureVmWorkloadModifyPolicy;
                }
                else
                {
                    // validate RetentionPolicy and SchedulePolicy
                    if (schedulePolicy != null)
                    {
                        AzureWorkloadProviderHelper.ValidateSQLSchedulePolicy(schedulePolicy);
                        AzureWorkloadProviderHelper.GetUpdatedSchedulePolicy(policy, (SQLSchedulePolicy)schedulePolicy);
                        Logger.Instance.WriteDebug("Validation of Schedule policy is successful");
                    }
                    if (retentionPolicy != null)
                    {
                        AzureWorkloadProviderHelper.ValidateSQLRetentionPolicy(retentionPolicy);
                        AzureWorkloadProviderHelper.GetUpdatedRetentionPolicy(policy, (SQLRetentionPolicy)retentionPolicy);
                        Logger.Instance.WriteDebug("Validation of Retention policy is successful");
                    }

                    // copy the backupSchedule time to retentionPolicy after converting to UTC
                    AzureWorkloadProviderHelper.CopyScheduleTimeToRetentionTimes(
                        (CmdletModel.LongTermRetentionPolicy)((AzureVmWorkloadPolicy)policy).FullBackupRetentionPolicy,
                        (CmdletModel.SimpleSchedulePolicy)((AzureVmWorkloadPolicy)policy).FullBackupSchedulePolicy);
                    Logger.Instance.WriteDebug("Copy of RetentionTime from SchedulePolicy to RetentionPolicy is successful");

                    // Now validate both RetentionPolicy and SchedulePolicy matches or not
                    PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleSchedulePolicy(
                        (CmdletModel.LongTermRetentionPolicy)((AzureVmWorkloadPolicy)policy).FullBackupRetentionPolicy,
                        (CmdletModel.SimpleSchedulePolicy)((AzureVmWorkloadPolicy)policy).FullBackupSchedulePolicy);
                    Logger.Instance.WriteDebug("Validation of Retention policy with Schedule policy is successful");
                                        
                    if (tieringDetails != null)
                    {
                        PolicyHelpers.ValidateFullBackupRetentionPolicyWithTieringPolicy((CmdletModel.LongTermRetentionPolicy)((AzureVmWorkloadPolicy)policy).FullBackupRetentionPolicy, tieringDetails);
                        AzureWorkloadProviderHelper.GetUpdatedTieringPolicy(policy, tieringDetails);
                        Logger.Instance.WriteDebug("Validation of Tiering policy is successful");
                    }
                    else if (((AzureVmWorkloadPolicy)policy).FullBackupTieringPolicy != null)
                    {
                        PolicyHelpers.ValidateFullBackupRetentionPolicyWithTieringPolicy((CmdletModel.LongTermRetentionPolicy)((AzureVmWorkloadPolicy)policy).FullBackupRetentionPolicy, ((AzureVmWorkloadPolicy)policy).FullBackupTieringPolicy, true);
                    }

                    string timeZone = (((CmdletModel.SimpleSchedulePolicy)((AzureVmWorkloadPolicy)policy).FullBackupSchedulePolicy).ScheduleRunTimeZone != null) ? ((CmdletModel.SimpleSchedulePolicy)((AzureVmWorkloadPolicy)policy).FullBackupSchedulePolicy).ScheduleRunTimeZone  : "UTC";

                    // construct Service Client policy request
                    AzureVmWorkloadProtectionPolicy azureVmWorkloadProtectionPolicy = new AzureVmWorkloadProtectionPolicy();
                    azureVmWorkloadProtectionPolicy.Settings = new Settings(timeZone,
                        ((AzureVmWorkloadPolicy)policy).IsCompression,
                        ((AzureVmWorkloadPolicy)policy).IsCompression);
                    azureVmWorkloadProtectionPolicy.WorkLoadType = ConversionUtils.GetServiceClientWorkloadType(policy.WorkloadType.ToString());
                    azureVmWorkloadProtectionPolicy.SubProtectionPolicy = new List<SubProtectionPolicy>();
                    azureVmWorkloadProtectionPolicy.SubProtectionPolicy = PolicyHelpers.GetServiceClientSubProtectionPolicy((AzureVmWorkloadPolicy)policy, isSmartTieringEnabled);
                    serviceClientRequest.Properties = azureVmWorkloadProtectionPolicy;
                }
            }
            else
            {
                CmdletModel.WorkloadType workloadType =
                (CmdletModel.WorkloadType)ProviderData[PolicyParams.WorkloadType];

                // do validations
                ValidateAzureVmWorkloadType(workloadType);
                AzureWorkloadProviderHelper.ValidateSQLSchedulePolicy(schedulePolicy);
                Logger.Instance.WriteDebug("Validation of Schedule policy is successful");

                // validate RetentionPolicy
                AzureWorkloadProviderHelper.ValidateSQLRetentionPolicy(retentionPolicy);
                Logger.Instance.WriteDebug("Validation of Retention policy is successful");

                // update the retention times from backupSchedule to retentionPolicy after converting to UTC           
                AzureWorkloadProviderHelper.CopyScheduleTimeToRetentionTimes(((SQLRetentionPolicy)retentionPolicy).FullBackupRetentionPolicy,
                                                 ((SQLSchedulePolicy)schedulePolicy).FullBackupSchedulePolicy);
                Logger.Instance.WriteDebug("Copy of RetentionTime from with SchedulePolicy to RetentionPolicy is successful");

                // Now validate both RetentionPolicy and SchedulePolicy together
                PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleSchedulePolicy(
                                    (SQLRetentionPolicy)retentionPolicy,
                                    (SQLSchedulePolicy)schedulePolicy);
                Logger.Instance.WriteDebug("Validation of Retention policy with Schedule policy is successful");

                // validate tiering policy
                PolicyHelpers.ValidateFullBackupRetentionPolicyWithTieringPolicy(((SQLRetentionPolicy)retentionPolicy).FullBackupRetentionPolicy, tieringDetails);
                Logger.Instance.WriteDebug("Validation of Retention policy with Tiering policy is successful");

                string timeZone = (((SQLSchedulePolicy)schedulePolicy).FullBackupSchedulePolicy.ScheduleRunTimeZone != null) ? ((SQLSchedulePolicy)schedulePolicy).FullBackupSchedulePolicy.ScheduleRunTimeZone : "UTC";

                // construct Service Client policy request            
                AzureVmWorkloadProtectionPolicy azureVmWorkloadProtectionPolicy = new AzureVmWorkloadProtectionPolicy();
                azureVmWorkloadProtectionPolicy.Settings = new Settings(timeZone, 
                    ((SQLSchedulePolicy)schedulePolicy).IsCompression,
                    ((SQLSchedulePolicy)schedulePolicy).IsCompression);
                azureVmWorkloadProtectionPolicy.WorkLoadType = ConversionUtils.GetServiceClientWorkloadType(workloadType.ToString());
                azureVmWorkloadProtectionPolicy.SubProtectionPolicy = new List<SubProtectionPolicy>();
                azureVmWorkloadProtectionPolicy.SubProtectionPolicy = PolicyHelpers.GetServiceClientSubProtectionPolicy(
                                                    (SQLRetentionPolicy)retentionPolicy,
                                                    (SQLSchedulePolicy)schedulePolicy, tieringDetails, isSmartTieringEnabled);
                serviceClientRequest.Properties = azureVmWorkloadProtectionPolicy;
            }

            // check for MUA
            bool isMUAProtected = false;
            if (existingPolicy != null)
            {
                isMUAProtected = AzureWorkloadProviderHelper.checkMUAForModifyPolicy(existingPolicy, serviceClientRequest, isMUAOperation);
            }

            return ServiceClientAdapter.CreateOrUpdateProtectionPolicy(
                policyName = policyName ?? policy.Name,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName,
                auxiliaryAccessToken,
                isMUAProtected);
        }

        private RestAzureNS.AzureOperationResponse<ProtectedItemResource> EnableOrModifyProtection(bool disableWithRetentionData = false)
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string vaultResourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];

            PolicyBase policy = ProviderData.ContainsKey(ItemParams.Policy) ?
                (PolicyBase)ProviderData[ItemParams.Policy] : null;

            ProtectableItemBase protectableItemBase = ProviderData.ContainsKey(ItemParams.ProtectableItem) ?
                (ProtectableItemBase)ProviderData[ItemParams.ProtectableItem] : null;
            AzureWorkloadProtectableItem protectableItem = ProviderData.ContainsKey(ItemParams.ProtectableItem) ?
                (AzureWorkloadProtectableItem)ProviderData[ItemParams.ProtectableItem] : null;

            ItemBase itemBase = ProviderData.ContainsKey(ItemParams.Item) ?
                (ItemBase)ProviderData[ItemParams.Item] : null;

            AzureItem item;
            AzureVmWorkloadProtectedItem properties;
            if (itemBase != null && itemBase.WorkloadType == CmdletModel.WorkloadType.SAPHanaDatabase)
            {
                item = ProviderData.ContainsKey(ItemParams.Item) ?
                (AzureWorkloadSAPHanaDatabaseProtectedItem)ProviderData[ItemParams.Item] : null;

                properties = new AzureVmWorkloadSAPHanaDatabaseProtectedItem();
            }
            else
            {
                item = ProviderData.ContainsKey(ItemParams.Item) ?
                (AzureWorkloadSQLDatabaseProtectedItem)ProviderData[ItemParams.Item] : null;

                properties = new AzureVmWorkloadSQLDatabaseProtectedItem();
            }

            string auxiliaryAccessToken = ProviderData.ContainsKey(ResourceGuardParams.Token) ? (string)ProviderData[ResourceGuardParams.Token] : null;
            bool isMUAOperation = ProviderData.ContainsKey(ResourceGuardParams.IsMUAOperation) ? (bool)ProviderData[ResourceGuardParams.IsMUAOperation] : false;

            ProtectionPolicyResource oldPolicy = null;
            ProtectionPolicyResource newPolicy = null;
            if (isMUAOperation && item != null && item.PolicyId != null && policy != null && policy.Id != null)
            {
                Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.PolicyId);
                string oldPolicyName = HelperUtils.GetPolicyNameFromPolicyId(keyValueDict, item.PolicyId);

                keyValueDict = HelperUtils.ParseUri(policy.Id);
                string newPolicyName = HelperUtils.GetPolicyNameFromPolicyId(keyValueDict, policy.Id);

                // fetch old and new Policy 
                oldPolicy = ServiceClientAdapter.GetProtectionPolicy(
                    oldPolicyName,
                    vaultName: vaultName,
                    resourceGroupName: vaultResourceGroupName);

                newPolicy = ServiceClientAdapter.GetProtectionPolicy(
                    newPolicyName,
                    vaultName: vaultName,
                    resourceGroupName: vaultResourceGroupName);
            }

            string containerUri = "";
            string protectedItemUri = "";

            if (disableWithRetentionData)
            {
                //Disable protection while retaining backup data
                ValidateAzureWorkloadDisableProtectionRequest(itemBase);

                Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
                containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
                protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);
                properties.PolicyId = string.Empty;
                properties.ProtectionState = ProtectionState.ProtectionStopped;
                properties.SourceResourceId = item.SourceResourceId;
            }
            else
            {
                if (protectableItem != null)
                {
                    Dictionary<UriEnums, string> keyValueDict =
                        HelperUtils.ParseUri(protectableItem.Id);
                    containerUri = HelperUtils.GetContainerUri(
                        keyValueDict, protectableItem.Id);
                    protectedItemUri = HelperUtils.GetProtectableItemUri(
                        keyValueDict, protectableItem.Id);

                    properties.PolicyId = policy.Id;
                }
                else if (item != null)
                {
                    Dictionary<UriEnums, string> keyValueDict =
                        HelperUtils.ParseUri(item.Id);
                    containerUri = HelperUtils.GetContainerUri(
                        keyValueDict, item.Id);
                    protectedItemUri = HelperUtils.GetProtectedItemUri(
                        keyValueDict, item.Id);

                    properties.PolicyId = policy.Id;
                }
            }

            ProtectedItemResource serviceClientRequest = new ProtectedItemResource()
            {
                Properties = properties
            };

            // check for MUA
            bool isMUAProtected = false;
            if (isMUAOperation && oldPolicy != null && newPolicy != null)
            {
                isMUAProtected = AzureWorkloadProviderHelper.checkMUAForModifyPolicy(oldPolicy, newPolicy, isMUAOperation);
            }
            if (disableWithRetentionData)
            {
                isMUAProtected = true;
            }

            return ServiceClientAdapter.CreateOrUpdateProtectedItem(
                containerUri,
                protectedItemUri,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: vaultResourceGroupName,
                auxiliaryAccessToken,
                isMUAProtected,
                disableWithRetentionData);
        }

        public void RegisterContainer()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string vaultResourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            string containerName = (string)ProviderData[ContainerParams.Name];
            string backupManagementType = (string)ProviderData[ContainerParams.BackupManagementType];
            string workloadType = (string)ProviderData[ContainerParams.ContainerType];
            ContainerBase containerBase =
                (ContainerBase)ProviderData[ContainerParams.Container];
            AzureVmWorkloadContainer container = (AzureVmWorkloadContainer)ProviderData[ContainerParams.Container];

            ProtectionContainerResource protectionContainerResource = null;

            //Trigger Discovery
            ODataQuery<BMSRefreshContainersQueryObject> queryParam = new ODataQuery<BMSRefreshContainersQueryObject>(
                q => q.BackupManagementType
                    == ServiceClientModel.BackupManagementType.AzureWorkload);
            AzureWorkloadProviderHelper.RefreshContainer(vaultName, vaultResourceGroupName, queryParam);

            List<ProtectableContainerResource> unregisteredVmContainers =
                    GetUnRegisteredVmContainers(vaultName, vaultResourceGroupName);
            ProtectableContainerResource unregisteredVmContainer = unregisteredVmContainers.Find(
                vmContainer => string.Compare(vmContainer.Name.Split(';').Last(),
                containerName, true) == 0);

            if (unregisteredVmContainer != null || container != null)
            {
                protectionContainerResource =
                        new ProtectionContainerResource(container != null ? container.Id : unregisteredVmContainer.Id,
                        container != null ? container.Name : unregisteredVmContainer.Name);
                AzureVMAppContainerProtectionContainer azureVMContainer = new AzureVMAppContainerProtectionContainer(
                    friendlyName: containerName,
                    backupManagementType: backupManagementType,
                    sourceResourceId: container != null ? container.SourceResourceId : unregisteredVmContainer.Properties.ContainerId,
                    workloadType: workloadType.ToString(),
                    operationType: container != null ? OperationType.Reregister : OperationType.Register);
                protectionContainerResource.Properties = azureVMContainer;
                AzureWorkloadProviderHelper.RegisterContainer(container != null ? container.Name : unregisteredVmContainer.Name,
                protectionContainerResource,
                vaultName,
                vaultResourceGroupName);
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.AzureWorkloadAlreadyRegisteredException));
            }
        }

        public List<PointInTimeBase> GetLogChains()
        {
            return AzureWorkloadProviderHelper.ListLogChains(ProviderData);
        }

        private void ValidateAzureWorkloadSQLDatabaseDisableProtectionRequest(ItemBase itemBase)
        {

            if (itemBase == null || itemBase.GetType() != typeof(AzureWorkloadSQLDatabaseProtectedItem))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureWorkloadSQLDatabaseProtectedItem).ToString()));
            }

            ValidateAzureVmWorkloadType(itemBase.WorkloadType);
            ValidateAzureWorkloadContainerType(itemBase.ContainerType);
        }

        private void ValidateAzureWorkloadSAPHanaDatabaseDisableProtectionRequest(ItemBase itemBase)
        {

            if (itemBase == null || itemBase.GetType() != typeof(AzureWorkloadSAPHanaDatabaseProtectedItem))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureWorkloadSAPHanaDatabaseProtectedItem).ToString()));
            }

            ValidateAzureVmWorkloadType(itemBase.WorkloadType);
            ValidateAzureWorkloadContainerType(itemBase.ContainerType);
        }

        private void ValidateAzureVmWorkloadType(CmdletModel.WorkloadType type)
        {
            if (type != CmdletModel.WorkloadType.MSSQL && type != CmdletModel.WorkloadType.SAPHanaDatabase)
            {
                string expectedWorkloadType = CmdletModel.WorkloadType.MSSQL.ToString() + " or " + CmdletModel.WorkloadType.SAPHanaDatabase.ToString();
                throw new ArgumentException(string.Format(Resources.UnExpectedWorkLoadTypeException,
                                            expectedWorkloadType,
                                            type.ToString()));
            }
        }

        private void ValidateAzureWorkloadContainerType(CmdletModel.ContainerType type)
        {
            if (type != CmdletModel.ContainerType.AzureVMAppContainer)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedContainerTypeException,
                                            CmdletModel.ContainerType.AzureVMAppContainer.ToString(),
                                            type.ToString()));
            }
        }

        private void ValidateAzureWorkloadBackupManagementType(
            CmdletModel.BackupManagementType backupManagementType)
        {
            if (backupManagementType != CmdletModel.BackupManagementType.AzureWorkload)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedBackupManagementTypeException,
                                            CmdletModel.BackupManagementType.AzureWorkload.ToString(),
                                            backupManagementType.ToString()));
            }
        }

        private List<ProtectableContainerResource> GetUnRegisteredVmContainers(string vaultName = null,
           string vaultResourceGroupName = null)
        {
            ODataQuery<BMSContainerQueryObject> queryParams = null;
            queryParams = new ODataQuery<BMSContainerQueryObject>(
                q => q.BackupManagementType == ServiceClientModel.BackupManagementType.AzureWorkload);

            var listResponse = ServiceClientAdapter.ListUnregisteredContainers(
                queryParams,
                vaultName: vaultName,
                resourceGroupName: vaultResourceGroupName);
            List<ProtectableContainerResource> containerModels = listResponse.ToList();

            return containerModels;
        }

        private void ValidateAzureWorkloadProtectionPolicy(PolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureVmWorkloadPolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureVmWorkloadPolicy).ToString()));
            }

            ValidateAzureVmWorkloadType(policy.WorkloadType);

            // call validation
            policy.Validate();
        }

        private void ValidateAzureWorkloadDisableProtectionRequest(ItemBase itemBase)
        {

            if (itemBase == null || (itemBase.GetType() != typeof(AzureWorkloadSQLDatabaseProtectedItem) && itemBase.GetType() != typeof(AzureWorkloadSAPHanaDatabaseProtectedItem)))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureWorkloadSQLDatabaseProtectedItem).ToString()));
            }

            ValidateAzureVmWorkloadType(itemBase.WorkloadType);
            ValidateAzureWorkloadContainerType(itemBase.ContainerType);
        }
    }
}