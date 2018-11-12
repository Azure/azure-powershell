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
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using RestAzureNS = Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    /// <summary>
    /// This class implements methods for azure DB Workload backup provider
    /// </summary>
    public class AzureWorkloadPsBackupProvider : IPsBackupProvider
    {
        private const int defaultOperationStatusRetryTimeInMilliSec = 5 * 1000; // 5 sec
        private const string separator = ";";
        private const CmdletModel.RetentionDurationType defaultFileRetentionType =
            CmdletModel.RetentionDurationType.Days;
        private const int defaultFileRetentionCount = 30;
        Dictionary<Enum, object> ProviderData { get; set; }
        ServiceClientAdapter ServiceClientAdapter { get; set; }
        AzureWorkloadProviderHelper AzureWorkloadProviderHelper { get; set; }
        /// <summary>
        /// Initializes the provider with the data recieved from the cmdlet layer
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

        public RestAzureNS.AzureOperationResponse DisableProtection()
        {
            throw new NotImplementedException();
        }

        public RestAzureNS.AzureOperationResponse EnableProtection()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<CmdletModel.BackupEngineBase> ListBackupManagementServers()
        {
            throw new NotImplementedException();
        }

        public List<ItemBase> ListProtectedItems()
        {
            throw new NotImplementedException();
        }

        public List<ContainerBase> ListProtectionContainers()
        {
            throw new NotImplementedException();
        }

        public List<RecoveryPointBase> ListRecoveryPoints()
        {
            throw new NotImplementedException();
        }

        public RestAzureNS.AzureOperationResponse<ProtectionPolicyResource> ModifyPolicy()
        {
            return CreateorModifyPolicy();
        }

        private RestAzureNS.AzureOperationResponse<ProtectionPolicyResource> CreateorModifyPolicy()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            string policyName = ProviderData.ContainsKey(PolicyParams.PolicyName) ?
                (string)ProviderData[PolicyParams.PolicyName] : null;
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
            ProtectionPolicyResource serviceClientRequest = new ProtectionPolicyResource();

            if (policy != null)
            {
                // do validations
                ValidateAzureWorkloadProtectionPolicy(policy);
                Logger.Instance.WriteDebug("Validation of Protection Policy is successful");

                // RetentionPolicy and SchedulePolicy both should not be empty
                if (retentionPolicy == null && schedulePolicy == null)
                {
                    throw new ArgumentException(Resources.BothRetentionAndSchedulePoliciesEmpty);
                }

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
                Logger.Instance.WriteDebug("Copy of RetentionTime from with SchedulePolicy to RetentionPolicy is successful");

                // Now validate both RetentionPolicy and SchedulePolicy matches or not
                PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleRetentionPolicy(
                    (CmdletModel.LongTermRetentionPolicy)((AzureVmWorkloadPolicy)policy).FullBackupRetentionPolicy,
                    (CmdletModel.SimpleSchedulePolicy)((AzureVmWorkloadPolicy)policy).FullBackupSchedulePolicy);
                Logger.Instance.WriteDebug("Validation of Retention policy with Schedule policy is successful");

                // construct Service Client policy request
                AzureVmWorkloadProtectionPolicy azureVmWorkloadProtectionPolicy = new AzureVmWorkloadProtectionPolicy();
                azureVmWorkloadProtectionPolicy.Settings = new Settings("UTC",
                    ((AzureVmWorkloadPolicy)policy).IsCompression,
                    ((AzureVmWorkloadPolicy)policy).IsCompression);
                azureVmWorkloadProtectionPolicy.WorkLoadType = ConversionUtils.GetServiceClientWorkloadType(policy.WorkloadType.ToString());
                azureVmWorkloadProtectionPolicy.SubProtectionPolicy = new List<SubProtectionPolicy>();
                azureVmWorkloadProtectionPolicy.SubProtectionPolicy = PolicyHelpers.GetServiceClientSubProtectionPolicy((AzureVmWorkloadPolicy)policy);
                serviceClientRequest.Properties = azureVmWorkloadProtectionPolicy;
            }
            else
            {
                CmdletModel.WorkloadType workloadType =
                (CmdletModel.WorkloadType)ProviderData[PolicyParams.WorkloadType];

                // do validations
                ValidateAzureWorkloadWorkloadType(workloadType);
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
                PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleRetentionPolicy(
                                    (SQLRetentionPolicy)retentionPolicy,
                                    (SQLSchedulePolicy)schedulePolicy);
                Logger.Instance.WriteDebug("Validation of Retention policy with Schedule policy is successful");

                // construct Service Client policy request            
                AzureVmWorkloadProtectionPolicy azureVmWorkloadProtectionPolicy = new AzureVmWorkloadProtectionPolicy();
                azureVmWorkloadProtectionPolicy.Settings = new Settings("UTC",
                    ((SQLSchedulePolicy)schedulePolicy).IsCompression,
                    ((SQLSchedulePolicy)schedulePolicy).IsCompression);
                azureVmWorkloadProtectionPolicy.WorkLoadType = ConversionUtils.GetServiceClientWorkloadType(workloadType.ToString());
                azureVmWorkloadProtectionPolicy.SubProtectionPolicy = new List<SubProtectionPolicy>();
                azureVmWorkloadProtectionPolicy.SubProtectionPolicy = PolicyHelpers.GetServiceClientSubProtectionPolicy(
                                                    (SQLRetentionPolicy)retentionPolicy,
                                                    (SQLSchedulePolicy)schedulePolicy);
                serviceClientRequest.Properties = azureVmWorkloadProtectionPolicy;
            }

            return ServiceClientAdapter.CreateOrUpdateProtectionPolicy(
                policyName = policyName ?? policy.Name,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
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
            throw new NotImplementedException();
        }

        public RestAzureNS.AzureOperationResponse TriggerRestore()
        {
            throw new NotImplementedException();
        }

        private void ValidateAzureWorkloadProtectionPolicy(PolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureVmWorkloadPolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureVmWorkloadPolicy).ToString()));
            }

            ValidateAzureWorkloadWorkloadType(policy.WorkloadType);

            // call validation
            policy.Validate();
        }

        private void ValidateAzureWorkloadWorkloadType(CmdletModel.WorkloadType type)
        {
            if (type != CmdletModel.WorkloadType.MSSQL)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedWorkLoadTypeException,
                                            CmdletModel.WorkloadType.MSSQL.ToString(),
                                            type.ToString()));
            }
        }
    }
}