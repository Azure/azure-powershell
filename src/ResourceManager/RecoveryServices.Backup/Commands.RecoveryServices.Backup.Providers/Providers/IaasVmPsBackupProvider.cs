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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    public class IaasVmPsBackupProvider : IPsBackupProvider
    {
        ProviderData providerData;
        HydraAdapter.HydraAdapter hydraAdapter;

        public void Initialize(ProviderData providerData, HydraAdapter.HydraAdapter hydraAdapter)
        {
            this.providerData = providerData;
            this.hydraAdapter = hydraAdapter;
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
            string policyName = (string)providerData.ProviderParameters[PolicyParams.PolicyName];
            WorkloadType workloadType = (WorkloadType)providerData.ProviderParameters[PolicyParams.WorkloadType];
            BackupManagementType backupManagementType = (BackupManagementType)providerData.ProviderParameters[
                                                                              PolicyParams.BackupManagementType];
            AzureRmRecoveryServicesRetentionPolicyBase retentionPolicy = (AzureRmRecoveryServicesRetentionPolicyBase)
                                                 providerData.ProviderParameters[PolicyParams.RetentionPolicy];
            AzureRmRecoveryServicesSchedulePolicyBase schedulePolicy = (AzureRmRecoveryServicesSchedulePolicyBase)
                                                 providerData.ProviderParameters[PolicyParams.SchedulePolicy];
            string resourceName = (string)providerData.ProviderParameters[PolicyParams.ResourceName];
            string resourceGroupName = (string)providerData.ProviderParameters[PolicyParams.ResourceGroupName];


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

            return hydraAdapter.CreateOrUpdateProtectionPolicy(
                                 resourceGroupName,
                                 resourceName,
                                 policyName,
                                 hydraRequest);
        }

        public List<AzureRmRecoveryServicesJobBase> ModifyPolicy()
        {            
            AzureRmRecoveryServicesRetentionPolicyBase retentionPolicy = (AzureRmRecoveryServicesRetentionPolicyBase)
                                                 providerData.ProviderParameters[PolicyParams.RetentionPolicy];
            AzureRmRecoveryServicesSchedulePolicyBase schedulePolicy = (AzureRmRecoveryServicesSchedulePolicyBase)
                                                 providerData.ProviderParameters[PolicyParams.SchedulePolicy];
            AzureRmRecoveryServicesPolicyBase policy = (AzureRmRecoveryServicesPolicyBase)
                                                 providerData.ProviderParameters[PolicyParams.ProtectionPolicy];
            string resourceName = (string)providerData.ProviderParameters[PolicyParams.ResourceName];
            string resourceGroupName = (string)providerData.ProviderParameters[PolicyParams.ResourceGroupName];
          
            // do validations
            ValidateAzureVMProtectionPolicy(policy);
            
            // RetentionPolicy and SchedulePolicy both should not be empty
            if(retentionPolicy == null && schedulePolicy == null)
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
                        
            ProtectionPolicyResponse response =  hydraAdapter.CreateOrUpdateProtectionPolicy(
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

        #region private
        private void ValidateAzureVMWorkloadType(WorkloadType type)
        {
            if(type != WorkloadType.AzureVM)
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
