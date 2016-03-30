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
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.HydraAdapter;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    public class IaasVmPsBackupProvider : IPsBackupProvider
    {
        private const int defaultOperationStatusRetryTimeInMilliSec = 5 * 1000; // 10 sec
        private const string separator = ";";

        ProviderData ProviderData { get; set; }
        HydraAdapter.HydraAdapter HydraAdapter { get; set; }

        public void Initialize(ProviderData providerData, HydraAdapter.HydraAdapter hydraAdapter)
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

            Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType workloadType =
                (Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType)ProviderData.ProviderParameters[ItemParams.WorkloadType];

            AzureRmRecoveryServicesPolicyBase policy = (AzureRmRecoveryServicesPolicyBase)
                                                 ProviderData.ProviderParameters[ItemParams.Policy];
            if (policy == null)
            {
                // throw error -- TBD
            }

            AzureRmRecoveryServicesIaasVmItem item = (AzureRmRecoveryServicesIaasVmItem)
                                                 ProviderData.ProviderParameters[ItemParams.Item];
            // do validations
            //ValidateAzureVMWorkloadType(workloadType, policy); -- TBD

            string containerUri = "";
            string protectedItemUri = "";
            bool isComputeAzureVM = false;

            if (item == null)
            {
                isComputeAzureVM = string.IsNullOrEmpty(azureVMCloudServiceName) ? true : false;
                string azureVMRGName = (isComputeAzureVM) ? azureVMResourceGroupName : azureVMCloudServiceName;

                //ValidateEnableProtectionRequest(azureVMName, azureVMCloudServiceName, azureVMResourceGroupName); -- TBD

                AzureIaaSVMProtectableItem protectableObject = GetAzureVMProtectableObject(azureVMName, azureVMRGName, isComputeAzureVM);

                containerUri = protectableObject.ContainerUri;
                protectedItemUri = protectableObject.ProtectableObjectUri;
            }
            else
            {
                //ValidateMofifyProtectionRequest(item) -- TBD
                // isComputeAzureVM =  IsComputeAzureVM(item.item.VirtualMachineId); -- TBD
                string containerType = HydraHelpers.GetHydraContainerType(item.ContainerType);
                string vmType = HydraHelpers.GetHydraWorkloadType(item.WorkloadType);
                containerUri = string.Join(separator, new string[] { containerType, item.ContainerName });
                protectedItemUri = string.Join(separator, new string[] { vmType, item.Name });
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

            properties.PolicyName = policy.Name;

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
            throw new NotImplementedException();
        }

        public BaseRecoveryServicesJobResponse TriggerBackup()
        {
            throw new NotImplementedException();
        }

        public BaseRecoveryServicesJobResponse TriggerRestore()
        {
            AzureRmRecoveryServicesIaasVmRecoveryPoint rp = ProviderData.ProviderParameters[RestoreBackupItemParams.RecoveryPoint] 
                as AzureRmRecoveryServicesIaasVmRecoveryPoint;
            string storageId = ProviderData.ProviderParameters[RestoreBackupItemParams.StorageAccountId].ToString();

            if(rp == null)
            {
                throw new InvalidCastException("Cant convert input to AzureRmRecoveryServicesIaasVmRecoveryPoint");
            }
        }

        public ProtectedItemResponse GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        public AzureRmRecoveryServicesRecoveryPointBase GetRecoveryPointDetails()
        {
            AzureRmRecoveryServicesItemBase item = ProviderData.ProviderParameters[GetRecoveryPointParams.Item]
                as AzureRmRecoveryServicesItemBase;

            string recoveryPointId = ProviderData.ProviderParameters[GetRecoveryPointParams.RecoveryPointId].ToString();

            if (item == null)
            {
                throw new InvalidCastException("Cant convert input to AzureRmRecoveryServicesItemBase");
            }

            string containerName = item.ContainerName;
            string protectedItemName = (item as AzureRmRecoveryServicesIaasVmItem).Name;

            var rpResponse = HydraAdapter.GetRecoveryPointDetails(containerName, protectedItemName, recoveryPointId);
            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpResponse, item);
        }

        public List<AzureRmRecoveryServicesRecoveryPointBase> ListRecoveryPoints()
        {
            DateTime startDate = (DateTime)(ProviderData.ProviderParameters[GetRecoveryPointParams.StartDate]);
            DateTime endDate = (DateTime)(ProviderData.ProviderParameters[GetRecoveryPointParams.EndDate]);
            AzureRmRecoveryServicesItemBase item = ProviderData.ProviderParameters[GetRecoveryPointParams.Item]
                as AzureRmRecoveryServicesItemBase;

            if (item == null)
            {
                throw new InvalidCastException("Cant convert input to AzureRmRecoveryServicesItemBase");
            }

            string containerName = item.ContainerName;
            string protectedItemName = (item as AzureRmRecoveryServicesIaasVmItem).Name;

            TimeSpan duration = endDate - startDate;

            if (duration.TotalDays > 30)
            {
                throw new Exception("Time difference should not be more than 30 days"); //tbd: Correct nsg and exception type
            }

            //we need to fetch the list of RPs
            RecoveryPointQueryParameters queryFilter = new RecoveryPointQueryParameters();
            queryFilter.StartDate = CommonHelpers.GetDateTimeStringForService(startDate);
            queryFilter.EndDate = CommonHelpers.GetDateTimeStringForService(endDate);
            RecoveryPointListResponse rpListResponse = null;
            rpListResponse = HydraAdapter.GetRecoveryPoints(containerName, protectedItemName, queryFilter);
            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpListResponse, item);
        }

        public ProtectionPolicyResponse CreatePolicy()
        {
            string policyName = (string)ProviderData.ProviderParameters[PolicyParams.PolicyName];
            Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType workloadType =
                (Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType)ProviderData.ProviderParameters[PolicyParams.WorkloadType];
            BackupManagementType backupManagementType = (BackupManagementType)ProviderData.ProviderParameters[
                                                                              PolicyParams.BackupManagementType];
            AzureRmRecoveryServicesRetentionPolicyBase retentionPolicy = (AzureRmRecoveryServicesRetentionPolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.RetentionPolicy];
            AzureRmRecoveryServicesSchedulePolicyBase schedulePolicy = (AzureRmRecoveryServicesSchedulePolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.SchedulePolicy];

            // do validations
            ValidateAzureVMWorkloadType(workloadType);
            ValidateAzureVMSchedulePolicy(schedulePolicy);

            // update the retention times from backupSchedule to retentionPolicy after converting to UTC           
            CopyScheduleTimeToRetentionTimes((AzureRmRecoveryServicesLongTermRetentionPolicy)retentionPolicy,
                                             (AzureRmRecoveryServicesSimpleSchedulePolicy)schedulePolicy);

            // validate both RetentionPolicy and SchedulePolicy
            ValidateAzureVMRetentionPolicy(retentionPolicy);
            ValidateAzureVMSchedulePolicy(schedulePolicy);

            // Now validate both RetentionPolicy and SchedulePolicy matches or not
            PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleRetentionPolicy(
                                (AzureRmRecoveryServicesLongTermRetentionPolicy)retentionPolicy,
                                (AzureRmRecoveryServicesSimpleSchedulePolicy)schedulePolicy);

            // construct Hydra policy request            
            ProtectionPolicyRequest hydraRequest = new ProtectionPolicyRequest()
            {
                Item = new ProtectionPolicyResource()
                {
                    Properties = new AzureIaaSVMProtectionPolicy()
                    {
                        RetentionPolicy = PolicyHelpers.GetHydraLongTermRetentionPolicy(
                                                (AzureRmRecoveryServicesLongTermRetentionPolicy)retentionPolicy),
                        SchedulePolicy = PolicyHelpers.GetHydraSimpleSchedulePolicy(
                                                (AzureRmRecoveryServicesSimpleSchedulePolicy)schedulePolicy)
                    }
                }
            };

            return HydraAdapter.CreateOrUpdateProtectionPolicy(
                                 policyName,
                                 hydraRequest);
        }

        public ProtectionPolicyResponse ModifyPolicy()
        {
            AzureRmRecoveryServicesRetentionPolicyBase retentionPolicy = (AzureRmRecoveryServicesRetentionPolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.RetentionPolicy];
            AzureRmRecoveryServicesSchedulePolicyBase schedulePolicy = (AzureRmRecoveryServicesSchedulePolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.SchedulePolicy];
            AzureRmRecoveryServicesPolicyBase policy = (AzureRmRecoveryServicesPolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.ProtectionPolicy];

            // do validations
            ValidateAzureVMProtectionPolicy(policy);

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
            }
            if (retentionPolicy != null)
            {
                ValidateAzureVMRetentionPolicy(retentionPolicy);
                ((AzureRmRecoveryServicesIaasVmPolicy)policy).RetentionPolicy = retentionPolicy;
            }

            // copy the backupSchedule time to retentionPolicy after converting to UTC
            CopyScheduleTimeToRetentionTimes(
                (AzureRmRecoveryServicesLongTermRetentionPolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).RetentionPolicy,
                (AzureRmRecoveryServicesSimpleSchedulePolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).SchedulePolicy);

            // Now validate both RetentionPolicy and SchedulePolicy matches or not
            PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleRetentionPolicy(
                (AzureRmRecoveryServicesLongTermRetentionPolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).RetentionPolicy,
                (AzureRmRecoveryServicesSimpleSchedulePolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).SchedulePolicy);

            // construct Hydra policy request            
            ProtectionPolicyRequest hydraRequest = new ProtectionPolicyRequest()
            {
                Item = new ProtectionPolicyResource()
                {
                    Properties = new AzureIaaSVMProtectionPolicy()
                    {
                        RetentionPolicy = PolicyHelpers.GetHydraLongTermRetentionPolicy(
                                  (AzureRmRecoveryServicesLongTermRetentionPolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).RetentionPolicy),
                        SchedulePolicy = PolicyHelpers.GetHydraSimpleSchedulePolicy(
                                  (AzureRmRecoveryServicesSimpleSchedulePolicy)((AzureRmRecoveryServicesIaasVmPolicy)policy).SchedulePolicy)
                    }
                }
            };

            return HydraAdapter.CreateOrUpdateProtectionPolicy(policy.Name,
                                                               hydraRequest);            
        }

        public List<AzureRmRecoveryServicesContainerBase> ListProtectionContainers()
        {
            string name = (string)this.ProviderData.ProviderParameters[ContainerParams.Name];
            ContainerRegistrationStatus status = (ContainerRegistrationStatus)this.ProviderData.ProviderParameters[ContainerParams.Status];
            string resourceGroupName = (string)this.ProviderData.ProviderParameters[ContainerParams.ResourceGroupName];

            ProtectionContainerListQueryParams queryParams = new ProtectionContainerListQueryParams();

            // 1. Filter by Name
            queryParams.FriendlyName = name;

            // 2. Filter by ContainerType
            queryParams.ProviderType = ProviderType.AzureIaasVM.ToString();

            // 3. Filter by Status
            queryParams.RegistrationStatus = status.ToString();

            var listResponse = HydraAdapter.ListContainers(queryParams);

            List<AzureRmRecoveryServicesContainerBase> containerModels = ConversionHelpers.GetContainerModelList(listResponse);

            // 4. Filter by RG Name
            if (!string.IsNullOrEmpty(resourceGroupName))
            {
                containerModels = containerModels.Where(containerModel =>
                    (containerModel as AzureRmRecoveryServicesIaasVmContainer).ResourceGroupName == resourceGroupName).ToList();
            }

            return containerModels;
        }

        public List<AzureRmRecoveryServicesItemBase> ListProtectedItems()
        {
            AzureRmRecoveryServicesContainerBase container =
                (AzureRmRecoveryServicesContainerBase)this.ProviderData.ProviderParameters[ItemParams.Container];
            string name = (string)this.ProviderData.ProviderParameters[ItemParams.AzureVMName];
            ItemProtectionStatus protectionStatus =
                (ItemProtectionStatus)this.ProviderData.ProviderParameters[ItemParams.ProtectionStatus];
            ItemStatus status = (ItemStatus)this.ProviderData.ProviderParameters[ItemParams.Status];
            Models.WorkloadType workloadType =
                (Models.WorkloadType)this.ProviderData.ProviderParameters[ItemParams.WorkloadType];

            ProtectedItemListQueryParam queryParams = new ProtectedItemListQueryParam();
            queryParams.DatasourceType = Microsoft.Azure.Management.RecoveryServices.Backup.Models.WorkloadType.VM;
            queryParams.ProviderType = ProviderType.AzureIaasVM.ToString();

            var listResponse = HydraAdapter.ListProtectedItem(queryParams);
            
            List<AzureRmRecoveryServicesItemBase> itemModels = ConversionHelpers.GetItemModelList(listResponse.ItemList.Value, container);

            // 1. Filter by container
            itemModels = itemModels.Where(itemModel =>
            {
                return itemModel.ContainerName == container.Name;
            }).ToList();

            // 2. Filter by item's friendly name
            if (!string.IsNullOrEmpty(name))
            {
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureRmRecoveryServicesIaasVmItem)itemModel).Name == name;
                }).ToList();
            }

            // 3. Filter by item's Protection Status
            if (protectionStatus != 0)
            {
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureRmRecoveryServicesIaasVmItem)itemModel).ProtectionStatus == protectionStatus;
                }).ToList();
            }

            // 4. Filter by item's Protection State
            if (status != 0)
            {
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureRmRecoveryServicesIaasVmItem)itemModel).ProtectionState == status;
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

        public AzureRmRecoveryServicesSchedulePolicyBase GetDefaultSchedulePolicyObject()
        {
            AzureRmRecoveryServicesSimpleSchedulePolicy defaultSchedule = new AzureRmRecoveryServicesSimpleSchedulePolicy();
            //Default is daily scedule at 10:30 AM local time
            defaultSchedule.ScheduleRunFrequency = ScheduleRunType.Daily;

            DateTime scheduleTime = GenerateRandomTime();
            defaultSchedule.ScheduleRunTimes = new List<DateTime>();
            defaultSchedule.ScheduleRunTimes.Add(scheduleTime);

            defaultSchedule.ScheduleRunDays = new List<DayOfWeek>();
            defaultSchedule.ScheduleRunDays.Add(DayOfWeek.Sunday);

            return defaultSchedule;
        }

        public AzureRmRecoveryServicesRetentionPolicyBase GetDefaultRetentionPolicyObject()
        {
            AzureRmRecoveryServicesLongTermRetentionPolicy defaultRetention = new AzureRmRecoveryServicesLongTermRetentionPolicy();

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

        private void ValidateAzureVMProtectionPolicy(AzureRmRecoveryServicesPolicyBase policy)
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

        private void ValidateAzureVMSchedulePolicy(AzureRmRecoveryServicesSchedulePolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureRmRecoveryServicesSimpleSchedulePolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidSchedulePolicyException,
                                            typeof(AzureRmRecoveryServicesSimpleSchedulePolicy).ToString()));
            }

            // call validation
            policy.Validate();
        }

        private void ValidateAzureVMRetentionPolicy(AzureRmRecoveryServicesRetentionPolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureRmRecoveryServicesLongTermRetentionPolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidRetentionPolicyException,
                                            typeof(AzureRmRecoveryServicesLongTermRetentionPolicy).ToString()));
            }

            // call validation
            policy.Validate();
        }

        private AzureIaaSVMProtectableItem GetAzureVMProtectableObject(string azureVMName, string azureVMRGName, bool isComputeAzureVM)
        {
            //TriggerDiscovery if needed

            bool isDiscoveryNeed = false;

            AzureIaaSVMProtectableItem protectableObject = null;
            isDiscoveryNeed = IsDiscoveryNeeded(azureVMName, azureVMRGName, isComputeAzureVM, out protectableObject);
            if (isDiscoveryNeed)
            {
                // WriteDebug(String.Format(Resources.VMNotDiscovered, vmName));
                RefreshContainer();
                isDiscoveryNeed = IsDiscoveryNeeded(azureVMName, azureVMRGName, isComputeAzureVM, out protectableObject);
                if (isDiscoveryNeed == true)
                {
                    // TBD Container is not discovered. Throw exception
                    //string errMsg = String.Format(Resources.DiscoveryFailure, vmName, ServiceOrRG, rgName);
                    //WriteDebug(errMsg);
                    //ThrowTerminatingError(new ErrorRecord(new Exception(Resources.AzureVMNotFound), string.Empty, ErrorCategory.InvalidArgument, null));
                }
            }
            if (protectableObject == null)
            {
                // TBD throw exception.
            }

            return protectableObject;

        }

        private bool IsDiscoveryNeeded(string vmName, string rgName, bool isComputeAzureVM,
            out AzureIaaSVMProtectableItem protectableObject)
        {
            bool isDiscoveryNeed = true;
            protectableObject = null;
            string vmVersion = string.Empty;
            vmVersion = (isComputeAzureVM) == true ? "Compute" : "ClassicCompute"; // -- TBD Move hard coded values to a constant.

            ProtectableObjectListQueryParameters queryParam = new ProtectableObjectListQueryParameters();
            queryParam.ProviderType = ProviderType.AzureIaasVM.ToString();
            // Add FriendlyName query param here -- TBD
            // No need to use skip or top token here as no pagination support of IaaSVM PO.

            //First check if container is discovered or not            
            var protectableItemList = HydraAdapter.ListProtectableItem(queryParam).ItemList;

            //WriteDebug(String.Format(Resources.ContainerCountFromService, containers.Count())); -- TBD
            if (protectableItemList.ProtectableObjects.Count() == 0)
            {
                //Container is not discovered
                //WriteDebug(Resources.ContainerNotDiscovered); -- TBD
                isDiscoveryNeed = true;
            }
            else
            {
                foreach (var protectableItem in protectableItemList.ProtectableObjects)
                {
                    AzureIaaSVMProtectableItem iaaSVMProtectableItem = (AzureIaaSVMProtectableItem)protectableItem.Properties;
                    if (iaaSVMProtectableItem != null &&
                        iaaSVMProtectableItem.FriendlyName == vmName && iaaSVMProtectableItem.ResourceGroup == rgName
                        && iaaSVMProtectableItem.VirtualMachineVersion == vmVersion)
                    {
                        protectableObject = iaaSVMProtectableItem;
                        isDiscoveryNeed = false;
                        break;
                    }
                }
            }

            return isDiscoveryNeed;
        }

        private void RefreshContainer()
        {
            bool isRetryNeeded = true;
            int retryCount = 1;
            bool isDiscoverySuccessful = false;
            string errorMessage = string.Empty;
            while (isRetryNeeded && retryCount <= 3)
            {
                var refreshContainerJobResponse = HydraAdapter.RefreshContainers();

                //Now wait for the operation to Complete               
                isRetryNeeded = WaitForDiscoveryToComplete(refreshContainerJobResponse.Location, out isDiscoverySuccessful, out errorMessage);
                retryCount++;
            }

            if (!isDiscoverySuccessful)
            {
                // TBD ThrowTerminatingError(new ErrorRecord(new Exception(errorMessage), string.Empty, ErrorCategory.InvalidArgument, null));
            }
        }

        private bool WaitForDiscoveryToComplete(string locationUri, out bool isDiscoverySuccessful, out string errorMessage)
        {
            bool isRetryNeeded = false;
            var status = TrackRefreshContainerOperation(locationUri);
            errorMessage = String.Empty;

            isDiscoverySuccessful = true;
            //If operation fails check if retry is needed or not
            if (status != HttpStatusCode.OK)
            {
                isDiscoverySuccessful = false;
                errorMessage = "";
                // TBDs
                //Check if retry needed.
                //WriteDebug(String.Format(Resources.DiscoveryFailureErrorCode, status.Error.Code));
                //if ((status.Error.Code == AzureBackupOperationErrorCode.DiscoveryInProgress.ToString() ||
                //    (status.Error.Code == AzureBackupOperationErrorCode.BMSUserErrorObjectLocked.ToString())))
                //{
                //    //Need to retry for this errors
                //    isRetryNeeded = true;
                //    WriteDebug(String.Format(Resources.RertyDiscovery));
                //}
            }
            return isRetryNeeded;
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

                    Thread.Sleep(checkFrequency);
                }
                catch (Exception ex)
                {
                    // TBD throw exception
                    throw ex;
                }
            }

            if (status == HttpStatusCode.NoContent)
            {
                // TBD WriteDebug("Refresh Container Job completed with success");
            }
            else
            {
                string msg = String.Format("Unexpected http status in response header{ {0}", status);
                // -- TBD WriteDebug(msg);
                throw new Exception(msg);
            }

            return status;
        }

        private void CopyScheduleTimeToRetentionTimes(AzureRmRecoveryServicesLongTermRetentionPolicy retPolicy,
                                                      AzureRmRecoveryServicesSimpleSchedulePolicy schPolicy)
        {
            // first convert schedule run times to UTC
            schPolicy.ScheduleRunTimes = PolicyHelpers.ParseScheduleRunTimesToUTC(schPolicy.ScheduleRunTimes);

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
