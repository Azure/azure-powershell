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
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using ScheduleRunType = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ScheduleRunType;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;
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
            string dataSourceType)
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

            var listResponse = ServiceClientAdapter.ListProtectedItem(
                queryParams,
                skipToken,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            protectedItems.AddRange(listResponse);

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

        public List<CrrModel.ProtectedItemResource> ListProtectedItemsByContainerCrr(
            string vaultName,
            string resourceGroupName,
            CmdletModel.ContainerBase container,
            CmdletModel.PolicyBase policy,
            string backupManagementType,
            string dataSourceType)
        {
            string skipToken = null;

            // fetching backup items from secondary region            
            ODataQuery<CrrModel.ProtectedItemQueryObject> queryParamsCrr = policy != null ?
                new ODataQuery<CrrModel.ProtectedItemQueryObject>(
                    q => q.BackupManagementType
                            == backupManagementType &&
                            q.ItemType == dataSourceType &&
                            q.PolicyName == policy.Name) :
                new ODataQuery<CrrModel.ProtectedItemQueryObject>(
                    q => q.BackupManagementType
                            == backupManagementType &&
                            q.ItemType == dataSourceType);

            List<CrrModel.ProtectedItemResource> protectedItemsCrr = new List<CrrModel.ProtectedItemResource>();

            var listResponse = ServiceClientAdapter.ListProtectedItemCrr(
            queryParamsCrr,
            skipToken,
            vaultName: vaultName,
            resourceGroupName: resourceGroupName);

            protectedItemsCrr.AddRange(listResponse);

            // return Crr Items when CRR 
            if (container != null)
            {
                protectedItemsCrr = protectedItemsCrr.Where(protectedItem =>
                {
                    Dictionary<CmdletModel.UriEnums, string> dictionary = HelperUtils.ParseUri(protectedItem.Id);
                    string containerUri = HelperUtils.GetContainerUri(dictionary, protectedItem.Id);

                    var delimIndex = containerUri.IndexOf(';');
                    string containerName = null;
                    if (string.Compare(protectedItem.Properties.BackupManagementType, ServiceClientModel.BackupManagementType.AzureWorkload) == 0)
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

            return protectedItemsCrr;
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

                    bool filteredByUniqueName = itemName != null && (protectedItemUri.ToLower().Contains(itemName.ToLower()));
                    bool filteredByFriendlyName = false;

                    if (protectedItem.Properties.BackupManagementType == "AzureStorage" && protectedItem.Properties.WorkloadType == "AzureFileShare")
                    {
                        string protectedItemFriendlyName = (protectedItem.Properties as AzureFileshareProtectedItem).FriendlyName;
                        filteredByUniqueName = filteredByUniqueName || (itemName != null && protectedItemFriendlyName.ToLower() == itemName.ToLower());
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

        // filter items from secondary region 
        public List<CmdletModel.ItemBase> ListProtectedItemsByItemNameCrr(
            List<CrrModel.ProtectedItemResource> protectedItems,
            string itemName,
            string vaultName,
            string resourceGroupName,
            Action<CmdletModel.ItemBase, ProtectedItemResource> extendedInfoProcessor, string friendlyName = null)
        {
            List<ProtectedItemResource> protectedItemGetResponses = new List<ProtectedItemResource>();
            if (!string.IsNullOrEmpty(itemName) || !string.IsNullOrEmpty(friendlyName))
            {
                protectedItems = protectedItems.Where(protectedItem =>
                {
                    Dictionary<CmdletModel.UriEnums, string> dictionary = HelperUtils.ParseUri(protectedItem.Id);

                    string protectedItemUri = HelperUtils.GetProtectedItemUri(dictionary, protectedItem.Id);

                    bool filteredByUniqueName = itemName != null && (protectedItemUri.ToLower().Contains(itemName.ToLower()));
                    bool filteredByFriendlyName = false;

                    if (protectedItem.Properties.BackupManagementType == "AzureStorage" && protectedItem.Properties.WorkloadType == "AzureFileShare")
                    {
                        // code should never reach here, as CRR is not supported for azure files yet
                        string protectedItemFriendlyName = (protectedItem.Properties as CrrModel.AzureFileshareProtectedItem).FriendlyName;
                        filteredByUniqueName = filteredByUniqueName || (itemName != null && protectedItemFriendlyName.ToLower() == itemName.ToLower());
                        filteredByFriendlyName = friendlyName != null && protectedItemFriendlyName.ToLower() == friendlyName.ToLower();
                    }

                    return filteredByUniqueName || filteredByFriendlyName;
                }).ToList();

                // bug: below API calls should be made to secondary region 
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

            List<CmdletModel.ItemBase> itemModels = ConversionHelpers.GetItemModelListCrr(protectedItems);
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
            if (policy == null || (policy.GetType() != typeof(CmdletModel.SimpleSchedulePolicy) && policy.GetType() != typeof(CmdletModel.SimpleSchedulePolicyV2)))
            {
                throw new ArgumentException(string.Format(Resources.InvalidSchedulePolicyException,
                                            typeof(CmdletModel.SimpleSchedulePolicy).ToString() + ", " + typeof(CmdletModel.SimpleSchedulePolicyV2).ToString()));
            }

            if (backupManagementType == ServiceClientModel.BackupManagementType.AzureStorage &&
                ((CmdletModel.SimpleSchedulePolicy)policy).ScheduleRunFrequency == ScheduleRunType.Weekly)
            {
                throw new ArgumentException(Resources.AFSWeeklyScheduleNotAllowed);
            }

            // call base schedule policy validation 
            policy.Validate();

            if (backupManagementType == ServiceClientModel.BackupManagementType.AzureIaasVM)
            {
                ValidateAzureIaasVMSchedulePolicy(policy);
            }
            else if (backupManagementType == ServiceClientModel.BackupManagementType.AzureStorage)
            {
                // AFS specific validation 
                ValidateAFSSchedulePolicy((CmdletModel.SimpleSchedulePolicy)policy);
            }
        }

        public void ValidateAFSSchedulePolicy(CmdletModel.SimpleSchedulePolicy policy)
        {
            if (policy.ScheduleRunFrequency == ScheduleRunType.Hourly)
            {
                List<int> AllowedScheduleIntervals = new List<int> { 4, 6, 8, 12 };
                if (!(AllowedScheduleIntervals.Contains((int)policy.ScheduleInterval)))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidScheduleInterval, string.Join(",", AllowedScheduleIntervals.ToArray())));
                }

                if ((policy.ScheduleWindowDuration < policy.ScheduleInterval) || (policy.ScheduleWindowDuration < PolicyConstants.AfsHourlyWindowDurationMin) ||
                    (policy.ScheduleWindowDuration > PolicyConstants.AfsHourlyWindowDurationMax))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidScheduleWindowDuration, PolicyConstants.AfsHourlyWindowDurationMin, PolicyConstants.AfsHourlyWindowDurationMax));
                }

                DateTime windowStartTime = (DateTime)policy.ScheduleWindowStartTime;
                DateTime minimumStartTime = new DateTime(windowStartTime.Year, windowStartTime.Month, windowStartTime.Day, 00, 00, 00, 00, DateTimeKind.Utc);
                DateTime maximumStartTime = new DateTime(windowStartTime.Year, windowStartTime.Month, windowStartTime.Day, 19, 30, 00, 00, DateTimeKind.Utc);

                //validate window start time 
                if (windowStartTime > maximumStartTime || windowStartTime < minimumStartTime)
                {
                    throw new ArgumentException(String.Format(Resources.ScheduleWindowStartTimeOutOfRange));
                }

                // final backup time can be 23:30:00                
                DateTime finalBackupTime = new DateTime(windowStartTime.Year, windowStartTime.Month, windowStartTime.Day, 23, 30, 00, 00, DateTimeKind.Utc);
                TimeSpan diff = finalBackupTime - windowStartTime;

                // If ScheduleWindowDuration is greator than (23:30 - ScheduleWindowStartTime) then throw exception  
                if (diff.TotalHours < policy.ScheduleWindowDuration)
                {
                    throw new ArgumentException(String.Format(Resources.InvalidLastBackupTime));
                }
            }
        }

        public void ValidateAzureIaasVMSchedulePolicy(CmdletModel.SchedulePolicyBase policy)
        {
            if (policy.GetType() == typeof(CmdletModel.SimpleSchedulePolicy))
            {
                CmdletModel.SimpleSchedulePolicy simpleSchedulePolicy = (CmdletModel.SimpleSchedulePolicy)policy;

                // Standard hourly is restricted for IaasVM
                if (simpleSchedulePolicy.ScheduleRunFrequency == ScheduleRunType.Hourly)
                {
                    throw new ArgumentException(Resources.StandardHourlyPolicyNotSupported);
                }
            }
            else if (policy.GetType() == typeof(CmdletModel.SimpleSchedulePolicyV2))
            {
                CmdletModel.SimpleSchedulePolicyV2 simpleSchedulePolicyV2 = (CmdletModel.SimpleSchedulePolicyV2)policy;
                if (simpleSchedulePolicyV2.ScheduleRunFrequency == ScheduleRunType.Hourly)
                {
                    // throw new ArgumentException("Enhanced Hourly policy is currently not supported for WorkloadType AzureIaasVM. This will be supported soon");                    
                    List<int> AllowedScheduleIntervals = new List<int> { 4, 6, 8, 12 };
                    if (!(AllowedScheduleIntervals.Contains((int)simpleSchedulePolicyV2.HourlySchedule.Interval)))
                    {
                        throw new ArgumentException(String.Format(Resources.InvalidScheduleInterval, string.Join(",", AllowedScheduleIntervals.ToArray())));
                    }

                    // duration should be multiple of Interval and less than or equal to 24
                    if (simpleSchedulePolicyV2.HourlySchedule.WindowDuration > 24 || simpleSchedulePolicyV2.HourlySchedule.WindowDuration % simpleSchedulePolicyV2.HourlySchedule.Interval != 0)
                    {
                        throw new ArgumentException("Hourly policy ScheduleWindowDuration should be multiple of ScheduleInterval and less than or equal to 24 Hrs. for WorkloadType AzureVM");
                    }
                }
            }
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

        public void ValidateLongTermRetentionPolicy(CmdletModel.RetentionPolicyBase policy, string backupManagementType = "", ScheduleRunType ScheduleRunFrequency = 0)
        {
            if (policy == null || policy.GetType() != typeof(CmdletModel.LongTermRetentionPolicy))
            {
                throw new ArgumentException(
                    string.Format(
                        Resources.InvalidRetentionPolicyException,
                        typeof(CmdletModel.LongTermRetentionPolicy).ToString()));
            }

            ((CmdletModel.LongTermRetentionPolicy)policy).Validate(ScheduleRunFrequency);
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

        public bool checkMUAForSchedulePolicy(ProtectionPolicyResource existingPolicy, ProtectionPolicyResource newPolicy)
        {
            return false;
        }

        public List<SubProtectionPolicy> GetSubProtectionPolicyOfType(IList<SubProtectionPolicy> newSubProtectionPolicies, string policyType)
        {
            return newSubProtectionPolicies.Where(
                newSubProtectionPolicy =>
                {
                    return (newSubProtectionPolicy.PolicyType == policyType);
                }).ToList();
        }

        public bool checkInstantRpRetentionRange(int? oldSnapshotRetention, int? newSnapshotRetention)
        {
            return (newSnapshotRetention < oldSnapshotRetention);
        }

        /// <summary>
        /// checks if daily retention is reduced first, then weekly, then monthly and then yearly; breaks and return true whenever it finds retention is reduced in any schedule.
        /// if retention is not reduced in any schedule, returns false at the end.
        /// </summary>
        /// <param name="oldRetentionPolicy"></param>
        /// <param name="newRetentionPolicy"></param>
        /// <returns></returns>
        public bool checkMUAForLongTermRetentionPolicy(ServiceClientModel.LongTermRetentionPolicy oldRetentionPolicy, ServiceClientModel.LongTermRetentionPolicy newRetentionPolicy)
        {
            if (oldRetentionPolicy.DailySchedule != null)
            {
                if (newRetentionPolicy.DailySchedule == null || (newRetentionPolicy.DailySchedule.RetentionDuration.Count < oldRetentionPolicy.DailySchedule.RetentionDuration.Count))
                {
                    return true;
                }
            }
            if (oldRetentionPolicy.WeeklySchedule != null)
            {
                if (newRetentionPolicy.WeeklySchedule == null || (newRetentionPolicy.WeeklySchedule.RetentionDuration.Count < oldRetentionPolicy.WeeklySchedule.RetentionDuration.Count))
                {
                    return true;
                }
            }
            if (oldRetentionPolicy.MonthlySchedule != null)
            {
                if (newRetentionPolicy.MonthlySchedule == null || (newRetentionPolicy.MonthlySchedule.RetentionDuration.Count < oldRetentionPolicy.MonthlySchedule.RetentionDuration.Count))
                {
                    return true;
                }
            }
            if (oldRetentionPolicy.YearlySchedule != null)
            {
                if (newRetentionPolicy.YearlySchedule == null || (newRetentionPolicy.YearlySchedule.RetentionDuration.Count < oldRetentionPolicy.YearlySchedule.RetentionDuration.Count))
                {
                    return true;
                }
            }

            return false;
        }

        public bool checkMUAForSimpleRetentionPolicy(ServiceClientModel.SimpleRetentionPolicy oldRetentionPolicy, ServiceClientModel.SimpleRetentionPolicy newRetentionPolicy)
        {
            if (newRetentionPolicy.RetentionDuration.Count < oldRetentionPolicy.RetentionDuration.Count)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// checks if daily retention is reduced first, then weekly, then monthly and then yearly; breaks and return true whenever it finds retention is reduced in any schedule.
        /// if retention is not reduced in any schedule, returns false at the end.
        /// </summary>
        /// <param name="oldRetentionPolicy"></param>
        /// <param name="newRetentionPolicy"></param>
        /// <returns></returns>
        public bool checkMUAForMSSQLPolicy(ServiceClientModel.AzureVmWorkloadProtectionPolicy oldRetentionPolicy, ServiceClientModel.AzureVmWorkloadProtectionPolicy newRetentionPolicy)
        {
            IList<SubProtectionPolicy> oldSubProtectionPolicies = oldRetentionPolicy.SubProtectionPolicy;
            IList<SubProtectionPolicy> newSubProtectionPolicies = newRetentionPolicy.SubProtectionPolicy;

            foreach (SubProtectionPolicy oldSubProtectionPolicy in oldSubProtectionPolicies)
            {
                string policyType = oldSubProtectionPolicy.PolicyType;
                List<SubProtectionPolicy> newSubProtectionPolicy = GetSubProtectionPolicyOfType(newSubProtectionPolicies, policyType);
                if(newSubProtectionPolicy == null || newSubProtectionPolicy.Count == 0) return true;
                else
                {
                    if (oldSubProtectionPolicy.RetentionPolicy.GetType() == typeof(ServiceClientModel.SimpleRetentionPolicy))
                    {
                        if(checkMUAForSimpleRetentionPolicy((ServiceClientModel.SimpleRetentionPolicy)oldSubProtectionPolicy.RetentionPolicy, (ServiceClientModel.SimpleRetentionPolicy)newSubProtectionPolicy[0].RetentionPolicy))
                        {
                            return true;
                        }
                    }
                    else if (oldSubProtectionPolicy.RetentionPolicy.GetType() == typeof(ServiceClientModel.LongTermRetentionPolicy))
                    {
                        if (checkMUAForLongTermRetentionPolicy((ServiceClientModel.LongTermRetentionPolicy)oldSubProtectionPolicy.RetentionPolicy, (ServiceClientModel.LongTermRetentionPolicy)newSubProtectionPolicy[0].RetentionPolicy))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool checkMUAForRetentionPolicy(ProtectionPolicyResource oldPolicy, ProtectionPolicyResource newPolicy)
        {
            if (newPolicy.Properties.GetType() == typeof(ServiceClientModel.AzureIaaSVMProtectionPolicy))
            {
                // check Instant RP reduced 
                int? oldSnapshotRetention = ((ServiceClientModel.AzureIaaSVMProtectionPolicy)oldPolicy.Properties).InstantRpRetentionRangeInDays;
                int? newSnapshotRetention = ((ServiceClientModel.AzureIaaSVMProtectionPolicy)newPolicy.Properties).InstantRpRetentionRangeInDays;                
                if (checkInstantRpRetentionRange(oldSnapshotRetention, newSnapshotRetention)) return true;

                ServiceClientModel.LongTermRetentionPolicy oldRetentionSchedule = (ServiceClientModel.LongTermRetentionPolicy)(((ServiceClientModel.AzureIaaSVMProtectionPolicy)oldPolicy.Properties).RetentionPolicy);
                ServiceClientModel.LongTermRetentionPolicy newRetentionSchedule = (ServiceClientModel.LongTermRetentionPolicy)(((ServiceClientModel.AzureIaaSVMProtectionPolicy)newPolicy.Properties).RetentionPolicy);

                return checkMUAForLongTermRetentionPolicy(oldRetentionSchedule, newRetentionSchedule);
            }

            else if (newPolicy.Properties.GetType() == typeof(ServiceClientModel.AzureFileShareProtectionPolicy))
            {
                ServiceClientModel.LongTermRetentionPolicy oldRetentionSchedule = (ServiceClientModel.LongTermRetentionPolicy)(((ServiceClientModel.AzureFileShareProtectionPolicy)oldPolicy.Properties).RetentionPolicy);
                ServiceClientModel.LongTermRetentionPolicy newRetentionSchedule = (ServiceClientModel.LongTermRetentionPolicy)(((ServiceClientModel.AzureFileShareProtectionPolicy)newPolicy.Properties).RetentionPolicy);

                return checkMUAForLongTermRetentionPolicy(oldRetentionSchedule, newRetentionSchedule);
            }

            else if (newPolicy.Properties.GetType() == typeof(ServiceClientModel.AzureVmWorkloadProtectionPolicy))
            {
                return checkMUAForMSSQLPolicy((ServiceClientModel.AzureVmWorkloadProtectionPolicy)oldPolicy.Properties, (ServiceClientModel.AzureVmWorkloadProtectionPolicy)newPolicy.Properties);                                
            }

            return false;
        }

        public bool checkMUAForModifyPolicy(ProtectionPolicyResource oldPolicy, ProtectionPolicyResource newPolicy, bool enableMUA = false)
        {
            if( enableMUA && (checkMUAForSchedulePolicy(oldPolicy, newPolicy) || checkMUAForRetentionPolicy(oldPolicy, newPolicy)))
            {
                return true;
            }

            return false;
        }

        public void CopyScheduleTimeToRetentionTimes(CmdletModel.LongTermRetentionPolicy retPolicy,
                                                      CmdletModel.SchedulePolicyBase schPolicyBase)
        {
            if ( schPolicyBase.GetType() == typeof(CmdletModel.SimpleSchedulePolicy))
            {
                CmdletModel.SimpleSchedulePolicy schPolicy = (CmdletModel.SimpleSchedulePolicy)schPolicyBase;

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
            else if (schPolicyBase.GetType() == typeof(CmdletModel.SimpleSchedulePolicyV2))
            {
                CmdletModel.SimpleSchedulePolicyV2 schPolicyV2 = (CmdletModel.SimpleSchedulePolicyV2)schPolicyBase;

                // schedule runTimes is already validated if in UTC/not during validate()
                // now copy times from schedule to retention policy

                List<DateTime> hourlyWindowStartTime = (schPolicyV2.HourlySchedule != null) ? new List<DateTime>{(DateTime)schPolicyV2.HourlySchedule.WindowStartTime} : null;

                if (retPolicy.IsDailyScheduleEnabled && retPolicy.DailySchedule != null)
                {
                    retPolicy.DailySchedule.RetentionTimes = (schPolicyV2.DailySchedule != null) ? schPolicyV2.DailySchedule.ScheduleRunTimes : hourlyWindowStartTime;
                }

                if (retPolicy.IsWeeklyScheduleEnabled && retPolicy.WeeklySchedule != null)
                {
                    retPolicy.WeeklySchedule.RetentionTimes = (schPolicyV2.DailySchedule != null) ? schPolicyV2.DailySchedule.ScheduleRunTimes : ((schPolicyV2.WeeklySchedule != null) ? schPolicyV2.WeeklySchedule.ScheduleRunTimes : hourlyWindowStartTime); 
                }

                if (retPolicy.IsMonthlyScheduleEnabled && retPolicy.MonthlySchedule != null)
                {
                    retPolicy.MonthlySchedule.RetentionTimes = (schPolicyV2.DailySchedule != null) ? schPolicyV2.DailySchedule.ScheduleRunTimes : ((schPolicyV2.WeeklySchedule != null) ? schPolicyV2.WeeklySchedule.ScheduleRunTimes : hourlyWindowStartTime);
                }

                if (retPolicy.IsYearlyScheduleEnabled && retPolicy.YearlySchedule != null)
                {
                    retPolicy.YearlySchedule.RetentionTimes = (schPolicyV2.DailySchedule != null) ? schPolicyV2.DailySchedule.ScheduleRunTimes : ((schPolicyV2.WeeklySchedule != null) ? schPolicyV2.WeeklySchedule.ScheduleRunTimes : hourlyWindowStartTime);
                }
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
            RecoveryPointTier targetTier = (RecoveryPointTier)ProviderData[RecoveryPointParams.TargetTier];
            bool isReadyForMove = (bool)ProviderData[RecoveryPointParams.IsReadyForMove];
            RecoveryPointTier tier = (RecoveryPointTier)ProviderData[RecoveryPointParams.Tier];

            ItemBase item = ProviderData[RecoveryPointParams.Item] as ItemBase;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

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
            
            List<RecoveryPointBase> recoveryPointList;
            if (secondaryRegion)
            {
                ODataQuery<CrrModel.BMSRPQueryObject> queryFilter = new ODataQuery<CrrModel.BMSRPQueryObject>();
                queryFilter.Filter = queryFilterString;

                //fetch recovery points from secondary region                
                List<CrrModel.RecoveryPointResource> rpListResponseCrr;
                rpListResponseCrr = ServiceClientAdapter.GetRecoveryPointsFromSecondaryRegion(
                containerUri,
                protectedItemName,
                queryFilter,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

                recoveryPointList = RecoveryPointConversions.GetPSAzureRecoveryPointsForSecondaryRegion(rpListResponseCrr, item);
            }
            else
            {
                ODataQuery<BMSRPQueryObject> queryFilter = new ODataQuery<BMSRPQueryObject>();
                queryFilter.Filter = queryFilterString;

                List<RecoveryPointResource> rpListResponse;
                rpListResponse = ServiceClientAdapter.GetRecoveryPoints(
                containerUri,
                protectedItemName,
                queryFilter,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

                recoveryPointList = RecoveryPointConversions.GetPSAzureRecoveryPoints(rpListResponse, item);
            }            

            //filter out archived recovery points for secondary region
            if (secondaryRegion)
            { 
                recoveryPointList = recoveryPointList.Where(
                    recoveryPoint =>
                    {
                        if (recoveryPoint.GetType() == typeof(AzureVmRecoveryPoint))
                        {
                            return ((AzureVmRecoveryPoint)recoveryPoint).RecoveryPointTier != RecoveryPointTier.VaultArchive;
                        }

                        if (recoveryPoint.GetType() == typeof(CmdletModel.AzureWorkloadRecoveryPoint))
                        {
                            return ((CmdletModel.AzureWorkloadRecoveryPoint)recoveryPoint).RecoveryPointTier != RecoveryPointTier.VaultArchive;
                        }

                        return false;
                    }).ToList();
            }

            // filter move readness based on target tier
            recoveryPointList = RecoveryPointConversions.CheckRPMoveReadiness(recoveryPointList, targetTier, isReadyForMove);

            //filter RPs based on tier
            return RecoveryPointConversions.FilterRPsBasedOnTier(recoveryPointList, tier);
        }

        public List<PointInTimeBase> ListLogChains(Dictionary<Enum, object> ProviderData)
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            DateTime startDate = (DateTime)(ProviderData[RecoveryPointParams.StartDate]);
            DateTime endDate = (DateTime)(ProviderData[RecoveryPointParams.EndDate]);
            string restorePointQueryType = (string)ProviderData[RecoveryPointParams.RestorePointQueryType];
            bool secondaryRegion = (bool)ProviderData[CRRParams.UseSecondaryRegion];

            ItemBase item = ProviderData[RecoveryPointParams.Item] as ItemBase;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            //we need to fetch the list of RPs
            var queryFilterString = QueryBuilder.Instance.GetQueryString(new BMSRPQueryObject()
            {
                ExtendedInfo = true,
                StartDate = startDate,
                EndDate = endDate,
                RestorePointQueryType = restorePointQueryType
            });

            List<PointInTimeBase> timeRanges = new List<PointInTimeBase>();
            if (secondaryRegion)
            {
                ODataQuery<CrrModel.BMSRPQueryObject> queryFilter = new ODataQuery<CrrModel.BMSRPQueryObject>();
                queryFilter.Filter = queryFilterString;

                //fetch recovery points Log Chain from secondary region
                List<CrrModel.RecoveryPointResource> rpListResponse = ServiceClientAdapter.GetRecoveryPointsFromSecondaryRegion(
                containerUri,
                protectedItemName,
                queryFilter,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

                foreach (CrrModel.RecoveryPointResource rp in rpListResponse)
                {
                    if (rp.Properties.GetType() == typeof(CrrModel.AzureWorkloadSQLPointInTimeRecoveryPoint))
                    {
                        CrrModel.AzureWorkloadSQLPointInTimeRecoveryPoint recoveryPoint =
                           rp.Properties as CrrModel.AzureWorkloadSQLPointInTimeRecoveryPoint;

                        foreach (CrrModel.PointInTimeRange timeRange in recoveryPoint.TimeRanges)
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
            }
            else
            {
                ODataQuery<BMSRPQueryObject> queryFilter = new ODataQuery<BMSRPQueryObject>();
                queryFilter.Filter = queryFilterString;

                List<RecoveryPointResource> rpListResponse = ServiceClientAdapter.GetRecoveryPoints(
                containerUri,
                protectedItemName,
                queryFilter,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

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

        public List<ItemBase> GetMABProtectedItems(string vaultName, string resourceGroupName, ContainerBase container = null)
        {
            ODataQuery<ProtectedItemQueryObject> queryParams =
                new ODataQuery<ProtectedItemQueryObject>(
                    q => q.BackupManagementType == ServiceClientModel.BackupManagementType.MAB);                            

            List<ProtectedItemResource> protectedItems = ServiceClientAdapter.ListProtectedItem(
                queryParams,
                null,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            // filter by Container Name if given
            if (container != null)
            {
                protectedItems = protectedItems.Where(protectedItem =>
                {
                    Dictionary<CmdletModel.UriEnums, string> dictionary = HelperUtils.ParseUri(protectedItem.Id);
                    string containerUri = HelperUtils.GetContainerUri(dictionary, protectedItem.Id);

                    var delimIndex = containerUri.IndexOf(';');
                    string containerName = containerUri.Substring(delimIndex + 1);                    
                    return containerName.ToLower().Equals(container.Name.ToLower());
                }).ToList();
            }

            return ConversionHelpers.GetItemModelList(protectedItems);
        }
    }
}