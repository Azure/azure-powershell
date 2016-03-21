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
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    public class IaasVmPsBackupProvider : IPsBackupProvider
    {
        ProviderData ProviderData { get; set; }
        HydraAdapter.HydraAdapter HydraAdapter { get; set; }

        public void Initialize(ProviderData providerData, HydraAdapter.HydraAdapter hydraAdapter)
        {
            this.ProviderData = providerData;
            this.HydraAdapter = hydraAdapter;
        }

        public BaseRecoveryServicesJobResponse EnableProtection()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public ProtectedItemResponse GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        public RecoveryPointResponse GetRecoveryPoint()
        {
            throw new NotImplementedException();
        }

        public ProtectionPolicyResponse CreatePolicy()
        {
            string policyName = (string)ProviderData.ProviderParameters[PolicyParams.PolicyName];
            WorkloadType workloadType = (WorkloadType)ProviderData.ProviderParameters[PolicyParams.WorkloadType];
            BackupManagementType backupManagementType = (BackupManagementType)ProviderData.ProviderParameters[
                                                                              PolicyParams.BackupManagementType];
            AzureRmRecoveryServicesRetentionPolicyBase retentionPolicy = (AzureRmRecoveryServicesRetentionPolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.RetentionPolicy];
            AzureRmRecoveryServicesSchedulePolicyBase schedulePolicy = (AzureRmRecoveryServicesSchedulePolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.SchedulePolicy];
            string resourceName = (string)ProviderData.ProviderParameters[PolicyParams.ResourceName];
            string resourceGroupName = (string)ProviderData.ProviderParameters[PolicyParams.ResourceGroupName];


            // do validations
            ValidateAzureVMWorkloadType(workloadType);

            // validate both RetentionPolicy and SchedulePolicy
            ValidateAzureVMRetentionPolicy(retentionPolicy);
            ValidateAzureVMSchedulePolicy(schedulePolicy);

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
                                 resourceGroupName,
                                 resourceName,
                                 policyName,
                                 hydraRequest);
        }

        public List<AzureRmRecoveryServicesJobBase> ModifyPolicy()
        {
            AzureRmRecoveryServicesRetentionPolicyBase retentionPolicy = (AzureRmRecoveryServicesRetentionPolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.RetentionPolicy];
            AzureRmRecoveryServicesSchedulePolicyBase schedulePolicy = (AzureRmRecoveryServicesSchedulePolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.SchedulePolicy];
            AzureRmRecoveryServicesPolicyBase policy = (AzureRmRecoveryServicesPolicyBase)
                                                 ProviderData.ProviderParameters[PolicyParams.ProtectionPolicy];
            string resourceName = (string)ProviderData.ProviderParameters[PolicyParams.ResourceName];
            string resourceGroupName = (string)ProviderData.ProviderParameters[PolicyParams.ResourceGroupName];

            // do validations
            ValidateAzureVMProtectionPolicy(policy);

            // RetentionPolicy and SchedulePolicy both should not be empty
            if (retentionPolicy == null && schedulePolicy == null)
            {
                throw new ArgumentException("Both RetentionPolicy and SchedulePolicy are Empty .. nothing to update");
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

            ProtectionPolicyResponse response = HydraAdapter.CreateOrUpdateProtectionPolicy(
                                                               resourceGroupName,
                                                               resourceName,
                                                               policy.Name,
                                                               hydraRequest);

            List<AzureRmRecoveryServicesJobBase> jobsList = new List<AzureRmRecoveryServicesJobBase>();

            if (/*response.StatusCode == System.Net.HttpStatusCode.Accepted*/ true)
            {
                // poll for AsyncHeader and get the jobsList
                // TBD
        }
            else
            {
                // no datasources attached to policy
                // hence no jobs and no action.
            }

            return jobsList;
        }

        public List<AzureRmRecoveryServicesContainerBase> ListProtectionContainers()
        {
            string name = (string)this.ProviderData.ProviderParameters[ContainerParams.Name];
            ContainerRegistrationStatus status = (ContainerRegistrationStatus)this.ProviderData.ProviderParameters[ContainerParams.Status];
            ARSVault vault = (ARSVault)this.ProviderData.ProviderParameters[ContainerParams.Vault];
            string resourceGroupName = (string)this.ProviderData.ProviderParameters[ContainerParams.ResourceGroupName];

            ProtectionContainerListQueryParams queryParams = new ProtectionContainerListQueryParams();

            // 1. Filter by Name
            queryParams.FriendlyName = name;

            // 2. Filter by ContainerType
            queryParams.ProviderType = ProviderType.AzureIaasVM.ToString();

            // 3. Filter by Status
            queryParams.RegistrationStatus = status.ToString();

            var listResponse = HydraAdapter.ListContainers(vault.ResouceGroupName, vault.Name, queryParams);

            List<AzureRmRecoveryServicesContainerBase> containerModels = ConversionHelpers.GetContainerModelList(listResponse);

            // 4. Filter by RG Name
            if (!string.IsNullOrEmpty(resourceGroupName))
            {
                containerModels = containerModels.Where(containerModel =>
                    (containerModel as AzureRmRecoveryServicesIaasVmContainer).ResourceGroupName == resourceGroupName).ToList();
            }

            return containerModels;
        }

        public ProtectionPolicyResponse GetPolicy()
        {
            throw new NotImplementedException();
        }

        public void DeletePolicy()
        {
            throw new NotImplementedException();
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
            defaultRetention.MonthlySchedule.RetentionScheduleFormatType = Models.RetentionScheduleFormat.Weekly;

            //Initialize day based schedule
            defaultRetention.MonthlySchedule.RetentionScheduleDaily = GetDailyRetentionFormat();  

            //Initialize Week based schedule
            defaultRetention.MonthlySchedule.RetentionScheduleWeekly = GetWeeklyRetentionFormat();

            //Yearly retention policy
            defaultRetention.IsYearlyScheduleEnabled = true;
            defaultRetention.YearlySchedule = new Models.YearlyRetentionSchedule();
            defaultRetention.YearlySchedule.DurationCountInYears = 10;
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
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 00);
        }


        #region private
        private void ValidateAzureVMWorkloadType(WorkloadType type)
        {
            if (type != WorkloadType.AzureVM)
            {
                throw new ArgumentException("ExpectedWorkloadType = " + type.ToString());
            }
        }

        private void ValidateAzureVMProtectionPolicy(AzureRmRecoveryServicesPolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureRmRecoveryServicesIaasVmPolicy))
            {
                throw new ArgumentException("ProtectionPolicy is NULL or not of type AzureRmRecoveryServicesIaasVmPolicy");
            }

            ValidateAzureVMWorkloadType(policy.WorkloadType);

            // call validation
            policy.Validate();
        }

        private void ValidateAzureVMSchedulePolicy(AzureRmRecoveryServicesSchedulePolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureRmRecoveryServicesSimpleSchedulePolicy))
            {
                throw new ArgumentException("SchedulePolicy is NULL or not of type AzureRmRecoveryServicesSimpleSchedulePolicy");
            }

            // call validation
            policy.Validate();
        }

        private void ValidateAzureVMRetentionPolicy(AzureRmRecoveryServicesRetentionPolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureRmRecoveryServicesLongTermRetentionPolicy))
            {
                throw new ArgumentException("RetentionPolicy is NULL or not of type AzureRmRecoveryServicesLongTermRetentionPolicy");
            }

            // call validation
            policy.Validate();
        }
        #endregion
    }
}
