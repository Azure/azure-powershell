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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.HydraAdapter;

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

        public AzureRmRecoveryServicesRecoveryPointBase GetRecoveryPointDetails()
        {
            RecoveryPointResponse response = null;
            AzureRmRecoveryServicesItemBase item = ProviderData.ProviderParameters[GetRecoveryPointParams.Item]
                as AzureRmRecoveryServicesItemBase;

            string recoveryPointId = ProviderData.ProviderParameters[GetRecoveryPointParams.RecoveryPointId].ToString();

            if (item == null)
            {
                throw new InvalidCastException("Cant convert input to AzureRmRecoveryServicesItemBase");
            }

            string containerName = item.ContainerName;
            string protectedItemName = item.Name;

            var rpResponse = HydraAdapter.GetRecoveryPointDetails(containerName, protectedItemName, recoveryPointId);
            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpResponse, item);
        }

        public List<AzureRmRecoveryServicesRecoveryPointBase> ListRecoveryPoints()
        {
            RecoveryPointResponse response = null;
            DateTime startDate = (DateTime)(ProviderData.ProviderParameters[GetRecoveryPointParams.StartDate]);
            DateTime endDate = (DateTime)(ProviderData.ProviderParameters[GetRecoveryPointParams.EndDate]);
            AzureRmRecoveryServicesItemBase item = ProviderData.ProviderParameters[GetRecoveryPointParams.Item]
                as AzureRmRecoveryServicesItemBase;

            if (item == null)
            {
                throw new InvalidCastException("Cant convert input to AzureRmRecoveryServicesItemBase");
            }

            string containerName = item.ContainerName;
            string protectedItemName = item.Name;

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
