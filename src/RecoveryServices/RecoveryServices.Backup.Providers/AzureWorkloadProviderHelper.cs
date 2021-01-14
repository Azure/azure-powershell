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
using System;
using System.Collections.Generic;
using System.Linq;
using BackupManagementType = Microsoft.Azure.Management.RecoveryServices.Backup.Models.BackupManagementType;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using ScheduleRunType = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ScheduleRunType;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using SystemNet = System.Net;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    /// <summary>
    /// This class implements implements methods for Azure Workload Provider Helper
    /// </summary>
    public class AzureWorkloadProviderHelper
    {
        ServiceClientAdapter ServiceClientAdapter { get; set; }

        public AzureWorkloadProviderHelper(ServiceClientAdapter serviceClientAdapter)
        {
            ServiceClientAdapter = serviceClientAdapter;
        }

        public void RefreshContainer(string vaultName = null, string vaultResourceGroupName = null,
            ODataQuery<BMSRefreshContainersQueryObject> queryParam = null)
        {
            var refreshContainerJobResponse = ServiceClientAdapter.RefreshContainers(
                vaultName: vaultName,
                resourceGroupName: vaultResourceGroupName,
                queryParam: queryParam);

            var operationStatus = TrackingHelpers.GetOperationResult(
                refreshContainerJobResponse,
                operationId =>
                    ServiceClientAdapter.GetContainerRefreshOrInquiryOperationResult(
                        operationId,
                        vaultName: vaultName,
                        resourceGroupName: vaultResourceGroupName));

            //Now wait for the operation to Complete
            if (refreshContainerJobResponse.Response.StatusCode
                    != SystemNet.HttpStatusCode.NoContent)
            {
                string errorMessage = string.Format(Resources.DiscoveryFailureErrorCode,
                    refreshContainerJobResponse.Response.StatusCode);
                Logger.Instance.WriteDebug(errorMessage);
            }
        }

        public void RegisterContainer(string containerName,
            ProtectionContainerResource protectionContainerResource,
            string vaultName, string vaultResourceGroupName)
        {
            var registerResponse = ServiceClientAdapter.RegisterContainer(
                            containerName,
                            protectionContainerResource,
                            vaultName,
                            vaultResourceGroupName);

            var operationStatus = TrackingHelpers.GetOperationResult(
                registerResponse,
                operationId =>
                    ServiceClientAdapter.GetRegisterContainerOperationResult(
                        operationId,
                        containerName,
                        vaultName: vaultName,
                        resourceGroupName: vaultResourceGroupName));

            //Now wait for the operation to Complete
            if (registerResponse.Response.StatusCode
                    != SystemNet.HttpStatusCode.NoContent)
            {
                string errorMessage = string.Format(Resources.RegisterFailureErrorCode,
                    registerResponse.Response.StatusCode);
                Logger.Instance.WriteDebug(errorMessage);
            }
        }

        public List<ProtectedItemResource> ListProtectedItemsByContainer(
            string vaultName,
            string resourceGroupName,
            CmdletModel.ContainerBase container,
            CmdletModel.PolicyBase policy,
            string backupManagementType,
            string dataSourceType, 
            bool UseSecondaryRegion = false)
        {
            ODataQuery<ProtectedItemQueryObject> queryParams = policy != null ?
                new ODataQuery<ProtectedItemQueryObject>(
                    q => q.BackupManagementType
                            == backupManagementType &&
                         q.ItemType == dataSourceType &&
                         q.PolicyName == policy.Name) :
                new ODataQuery<ProtectedItemQueryObject>(
                    q => q.BackupManagementType
                            == backupManagementType &&
                         q.ItemType == dataSourceType);            

            List<ProtectedItemResource> protectedItems = new List<ProtectedItemResource>();
            string skipToken = null;

            // fetching backup items from secondary region
            if (UseSecondaryRegion)
            {
                var listResponse = ServiceClientAdapter.ListCrrProtectedItem(
                queryParams,
                skipToken,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
                protectedItems.AddRange(listResponse);
            }
            else
            {
                var listResponse = ServiceClientAdapter.ListProtectedItem(
                queryParams,
                skipToken,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
                protectedItems.AddRange(listResponse);
            }            

            if (container != null)
            {
                protectedItems = protectedItems.Where(protectedItem =>
                {
                    Dictionary<CmdletModel.UriEnums, string> dictionary = HelperUtils.ParseUri(protectedItem.Id);
                    string containerUri = HelperUtils.GetContainerUri(dictionary, protectedItem.Id);

                    var delimIndex = containerUri.IndexOf(';');
                    string containerName = null;
                    if (string.Compare(protectedItem.Properties.BackupManagementType,
                        ServiceClientModel.BackupManagementType.AzureWorkload) == 0)
                    {
                        containerName = containerUri;
                    }
                    else
                    {
                        containerName = containerUri.Substring(delimIndex + 1);
                    }
                    return containerName.ToLower().Equals(container.Name.ToLower());
                }).ToList();
            }

            return protectedItems;
        }

        public List<CmdletModel.ItemBase> ListProtectedItemsByItemName(
            List<ProtectedItemResource> protectedItems,
            string itemName,
            string vaultName,
            string resourceGroupName,
            Action<CmdletModel.ItemBase, ProtectedItemResource> extendedInfoProcessor, string friendlyName = null)
        {
            List<ProtectedItemResource> protectedItemGetResponses =
                new List<ProtectedItemResource>();

            if (!string.IsNullOrEmpty(itemName) || !string.IsNullOrEmpty(friendlyName))
            {
                protectedItems = protectedItems.Where(protectedItem =>
                {
                    Dictionary<CmdletModel.UriEnums, string> dictionary = HelperUtils.ParseUri(protectedItem.Id);

                    string protectedItemUri = HelperUtils.GetProtectedItemUri(dictionary, protectedItem.Id);

                    bool filteredByUniqueName = itemName != null && (protectedItemUri.ToLower().Contains(itemName.ToLower()) );
                    bool filteredByFriendlyName = false;

                    if (protectedItem.Properties.BackupManagementType == "AzureStorage" && protectedItem.Properties.WorkloadType == "AzureFileShare")
                    {

                        string protectedItemFriendlyName = (protectedItem.Properties as AzureFileshareProtectedItem).FriendlyName;
                        filteredByUniqueName = filteredByUniqueName || ( itemName != null && protectedItemFriendlyName.ToLower() == itemName.ToLower() );
                        filteredByFriendlyName = friendlyName != null && protectedItemFriendlyName.ToLower() == friendlyName.ToLower();
                    }

                    return filteredByUniqueName || filteredByFriendlyName;
                }).ToList();

                ODataQuery<GetProtectedItemQueryObject> getItemQueryParams =
                    new ODataQuery<GetProtectedItemQueryObject>(q => q.Expand == "extendedinfo");

                for (int i = 0; i < protectedItems.Count; i++)
                {
                    Dictionary<CmdletModel.UriEnums, string> dictionary = HelperUtils.ParseUri(protectedItems[i].Id);
                    string containerUri = HelperUtils.GetContainerUri(dictionary, protectedItems[i].Id);
                    string protectedItemUri = HelperUtils.GetProtectedItemUri(dictionary, protectedItems[i].Id);

                    var getResponse = ServiceClientAdapter.GetProtectedItem(
                        containerUri,
                        protectedItemUri,
                        getItemQueryParams,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);
                    protectedItemGetResponses.Add(getResponse.Body);
                }
            }

            List<CmdletModel.ItemBase> itemModels = ConversionHelpers.GetItemModelList(protectedItems);

            if (!string.IsNullOrEmpty(itemName))
            {
                for (int i = 0; i < itemModels.Count; i++)
                {
                    extendedInfoProcessor(itemModels[i], protectedItemGetResponses[i]);
                }
            }

            return itemModels;
        }

        public List<CmdletModel.ContainerBase> ListProtectionContainers(
            Dictionary<Enum, object> providerData,
            string backupManagementType)
        {
            string vaultName = (string)providerData[CmdletModel.VaultParams.VaultName];
            string vaultResourceGroupName = (string)providerData[CmdletModel.VaultParams.ResourceGroupName];
            string friendlyName = (string)providerData[CmdletModel.ContainerParams.FriendlyName];
            CmdletModel.ContainerRegistrationStatus status =
                (CmdletModel.ContainerRegistrationStatus)providerData[CmdletModel.ContainerParams.Status];

            string nameQueryFilter = friendlyName;

            ODataQuery<ServiceClientModel.BMSContainerQueryObject> queryParams = null;
            if (status == 0)
            {
                queryParams = new ODataQuery<ServiceClientModel.BMSContainerQueryObject>(
                q => q.FriendlyName == nameQueryFilter &&
                q.BackupManagementType == backupManagementType);
            }
            else
            {
                var statusString = status.ToString();
                queryParams = new ODataQuery<ServiceClientModel.BMSContainerQueryObject>(
                q => q.FriendlyName == nameQueryFilter &&
                q.BackupManagementType == backupManagementType &&
                q.Status == statusString);
            }

            var listResponse = ServiceClientAdapter.ListContainers(
                queryParams,
                vaultName: vaultName,
                resourceGroupName: vaultResourceGroupName);

            return ConversionHelpers.GetContainerModelList(listResponse);
        }

        public void ValidateSimpleSchedulePolicy(CmdletModel.SchedulePolicyBase policy, string backupManagementType = "")
        {
            if (policy == null || policy.GetType() != typeof(CmdletModel.SimpleSchedulePolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidSchedulePolicyException,
                                            typeof(CmdletModel.SimpleSchedulePolicy).ToString()));
            }

            if(backupManagementType == BackupManagementType.AzureStorage &&
                ((CmdletModel.SimpleSchedulePolicy)policy).ScheduleRunFrequency == ScheduleRunType.Weekly)
            {
                throw new ArgumentException(Resources.AFSWeeklyScheduleNotAllowed);
            }

            // call validation
            policy.Validate();
        }

        public void ValidateSQLSchedulePolicy(CmdletModel.SchedulePolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(CmdletModel.SQLSchedulePolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidSchedulePolicyException,
                                            typeof(CmdletModel.SQLSchedulePolicy).ToString()));
            }

            // call validation
            policy.Validate();
        }

        public void ValidateLongTermRetentionPolicy(CmdletModel.RetentionPolicyBase policy, string backupManagementType = "")
        {
            if (policy == null || policy.GetType() != typeof(CmdletModel.LongTermRetentionPolicy))
            {
                throw new ArgumentException(
                    string.Format(
                        Resources.InvalidRetentionPolicyException,
                        typeof(CmdletModel.LongTermRetentionPolicy).ToString()));
            }

            // perform validation
            policy.Validate();
        }

        public void ValidateSQLRetentionPolicy(CmdletModel.RetentionPolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(CmdletModel.SQLRetentionPolicy))
            {
                throw new ArgumentException(
                    string.Format(
                        Resources.InvalidRetentionPolicyException,
                        typeof(CmdletModel.SQLRetentionPolicy).ToString()));
            }

            // perform validation
            policy.Validate();
        }

        public DateTime GenerateRandomScheduleTime()
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

        public void CopyScheduleTimeToRetentionTimes(CmdletModel.LongTermRetentionPolicy retPolicy,
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

        public List<RecoveryPointBase> ListRecoveryPoints(Dictionary<Enum, object> ProviderData)
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            DateTime startDate = (DateTime)(ProviderData[RecoveryPointParams.StartDate]);
            DateTime endDate = (DateTime)(ProviderData[RecoveryPointParams.EndDate]);
            string restorePointQueryType = ProviderData.ContainsKey(RecoveryPointParams.RestorePointQueryType) ?
                (string)ProviderData[RecoveryPointParams.RestorePointQueryType] : "All";
            bool secondaryRegion = (bool)ProviderData[CRRParams.UseSecondaryRegion];

            ItemBase item = ProviderData[RecoveryPointParams.Item] as ItemBase;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            TimeSpan duration = endDate - startDate;
            if (duration.TotalDays > 30)
            {
                throw new Exception(Resources.RestoreDiskTimeRangeError);
            }

            //we need to fetch the list of RPs
            var queryFilterString = "null";
            if (string.Compare(restorePointQueryType, "All") == 0)
            {
                queryFilterString = QueryBuilder.Instance.GetQueryString(new BMSRPQueryObject()
                {
                    StartDate = startDate,
                    EndDate = endDate,
                });
            }
            else
            {
                queryFilterString = QueryBuilder.Instance.GetQueryString(new BMSRPQueryObject()
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    RestorePointQueryType = restorePointQueryType,
                    ExtendedInfo = true
                });
            }

            ODataQuery<BMSRPQueryObject> queryFilter = new ODataQuery<BMSRPQueryObject>();
            queryFilter.Filter = queryFilterString;

            List<RecoveryPointResource> rpListResponse; 
            if (secondaryRegion)
            {
                //fetch recovery points from secondary region
                rpListResponse = ServiceClientAdapter.GetRecoveryPointsFromSecondaryRegion(
                containerUri,
                protectedItemName,
                queryFilter,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
            }
            else
            {
                rpListResponse = ServiceClientAdapter.GetRecoveryPoints(
                containerUri,
                protectedItemName,
                queryFilter,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
            }
            
            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpListResponse, item);
        }

        public List<PointInTimeBase> ListLogChains(Dictionary<Enum, object> ProviderData)
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            DateTime startDate = (DateTime)(ProviderData[RecoveryPointParams.StartDate]);
            DateTime endDate = (DateTime)(ProviderData[RecoveryPointParams.EndDate]);
            string restorePointQueryType = (string)ProviderData[RecoveryPointParams.RestorePointQueryType];

            ItemBase item = ProviderData[RecoveryPointParams.Item] as ItemBase;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            TimeSpan duration = endDate - startDate;
            if (duration.TotalDays > 30)
            {
                throw new Exception(Resources.RestoreDiskTimeRangeError);
            }

            //we need to fetch the list of RPs
            var queryFilterString = QueryBuilder.Instance.GetQueryString(new BMSRPQueryObject()
            {
                ExtendedInfo = true,
                StartDate = startDate,
                EndDate = endDate,
                RestorePointQueryType = restorePointQueryType
            });

            ODataQuery<BMSRPQueryObject> queryFilter = new ODataQuery<BMSRPQueryObject>();
            queryFilter.Filter = queryFilterString;

            List<RecoveryPointResource> rpListResponse = ServiceClientAdapter.GetRecoveryPoints(
                containerUri,
                protectedItemName,
                queryFilter,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            List<PointInTimeBase> timeRanges = new List<PointInTimeBase>();
            foreach (RecoveryPointResource rp in rpListResponse)
            {
                if (rp.Properties.GetType() == typeof(AzureWorkloadSQLPointInTimeRecoveryPoint))
                {
                    AzureWorkloadSQLPointInTimeRecoveryPoint recoveryPoint =
                       rp.Properties as AzureWorkloadSQLPointInTimeRecoveryPoint;
                    foreach (PointInTimeRange timeRange in recoveryPoint.TimeRanges)
                    {
                        timeRanges.Add(new PointInTimeBase()
                        {
                            
                            StartTime = timeRange.StartTime,
                            EndTime = timeRange.EndTime,
                            ItemName = item.Name
                        });
                    }
                }

            }
            return timeRanges;
        }

        public RecoveryPointBase GetRecoveryPointDetails(Dictionary<Enum, object> ProviderData)
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            ItemBase item = ProviderData[RecoveryPointParams.Item] as ItemBase;

            string recoveryPointId = ProviderData[RecoveryPointParams.RecoveryPointId].ToString();

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            var rpResponse = ServiceClientAdapter.GetRecoveryPointDetails(
                containerUri,
                protectedItemName,
                recoveryPointId,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpResponse, item);
        }

        public static CmdletModel.DailyRetentionFormat GetDailyRetentionFormat()
        {
            CmdletModel.DailyRetentionFormat dailyRetention =
                new CmdletModel.DailyRetentionFormat();
            dailyRetention.DaysOfTheMonth = new List<CmdletModel.Day>();
            CmdletModel.Day dayBasedRetention = new CmdletModel.Day();
            dayBasedRetention.IsLast = false;
            dayBasedRetention.Date = 1;
            dailyRetention.DaysOfTheMonth.Add(dayBasedRetention);
            return dailyRetention;
        }

        public static CmdletModel.WeeklyRetentionFormat GetWeeklyRetentionFormat()
        {
            CmdletModel.WeeklyRetentionFormat weeklyRetention =
                new CmdletModel.WeeklyRetentionFormat();
            weeklyRetention.DaysOfTheWeek = new List<System.DayOfWeek>();
            weeklyRetention.DaysOfTheWeek.Add(System.DayOfWeek.Sunday);

            weeklyRetention.WeeksOfTheMonth = new List<CmdletModel.WeekOfMonth>();
            weeklyRetention.WeeksOfTheMonth.Add(CmdletModel.WeekOfMonth.First);
            return weeklyRetention;
        }

        public void GetUpdatedSchedulePolicy(CmdletModel.PolicyBase policy, CmdletModel.SQLSchedulePolicy schPolicy)
        {
            ((CmdletModel.AzureVmWorkloadPolicy)policy).FullBackupSchedulePolicy = schPolicy.FullBackupSchedulePolicy;
            ((CmdletModel.AzureVmWorkloadPolicy)policy).DifferentialBackupSchedulePolicy = schPolicy.DifferentialBackupSchedulePolicy;
            ((CmdletModel.AzureVmWorkloadPolicy)policy).LogBackupSchedulePolicy = schPolicy.LogBackupSchedulePolicy;
            ((CmdletModel.AzureVmWorkloadPolicy)policy).IsLogBackupEnabled = schPolicy.IsLogBackupEnabled;
            ((CmdletModel.AzureVmWorkloadPolicy)policy).IsDifferentialBackupEnabled = schPolicy.IsDifferentialBackupEnabled;
            ((CmdletModel.AzureVmWorkloadPolicy)policy).IsCompression = schPolicy.IsCompression;
        }

        public void GetUpdatedRetentionPolicy(CmdletModel.PolicyBase policy, CmdletModel.SQLRetentionPolicy retPolicy)
        {
            ((CmdletModel.AzureVmWorkloadPolicy)policy).FullBackupRetentionPolicy = retPolicy.FullBackupRetentionPolicy;
            ((CmdletModel.AzureVmWorkloadPolicy)policy).DifferentialBackupRetentionPolicy = retPolicy.DifferentialBackupRetentionPolicy;
            ((CmdletModel.AzureVmWorkloadPolicy)policy).LogBackupRetentionPolicy = retPolicy.LogBackupRetentionPolicy;
        }

        public void TriggerInquiry(string vaultName, string vaultResourceGroupName,
               string containerName, string workloadType)
        {
            ODataQuery<BMSContainersInquiryQueryObject> queryParams = new ODataQuery<BMSContainersInquiryQueryObject>(
                q => q.WorkloadType
                     == workloadType);
            string errorMessage = string.Empty;
            var inquiryResponse = ServiceClientAdapter.InquireContainer(
               containerName,
               queryParams,
               vaultName,
               vaultResourceGroupName);

            var operationStatus = TrackingHelpers.GetOperationResult(
               inquiryResponse,
               operationId =>
                   ServiceClientAdapter.GetContainerRefreshOrInquiryOperationResult(
                       operationId,
                       vaultName: vaultName,
                       resourceGroupName: vaultResourceGroupName));

            //Now wait for the operation to Complete
            if (inquiryResponse.Response.StatusCode
                    != SystemNet.HttpStatusCode.NoContent)
            {
                errorMessage = string.Format(Resources.TriggerEnquiryFailureErrorCode,
                    inquiryResponse.Response.StatusCode);
                Logger.Instance.WriteDebug(errorMessage);
            }
        }

        public List<ItemBase> GetMABProtectedItems(string vaultName, string resourceGroupName)
        {
            ODataQuery<ProtectedItemQueryObject> queryParams =
                new ODataQuery<ProtectedItemQueryObject>(
                    q => q.BackupManagementType == BackupManagementType.MAB);
                            

            List<ProtectedItemResource> protectedItems = ServiceClientAdapter.ListProtectedItem(
                queryParams,
                null,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            return ConversionHelpers.GetItemModelList(protectedItems);
        }
    }
}