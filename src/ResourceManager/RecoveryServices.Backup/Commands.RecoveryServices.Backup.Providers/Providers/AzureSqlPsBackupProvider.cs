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
    public class AzureSqlPsBackupProvider : IPsBackupProvider
    {
        ProviderData ProviderData { get; set; }
        HydraAdapter HydraAdapter { get; set; }

        public void Initialize(ProviderData providerData, HydraAdapter hydraAdapter)
        {
            this.ProviderData = providerData;
            this.HydraAdapter = hydraAdapter;
        }

        public Management.RecoveryServices.Backup.Models.BaseRecoveryServicesJobResponse EnableProtection()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.BaseRecoveryServicesJobResponse DisableProtection()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.BaseRecoveryServicesJobResponse TriggerBackup()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.BaseRecoveryServicesJobResponse TriggerRestore()
        {
            throw new NotImplementedException();
        }

        public Management.RecoveryServices.Backup.Models.ProtectedItemResponse GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        public AzureRmRecoveryServicesBackupRecoveryPointBase GetRecoveryPointDetails()
        {
            throw new NotImplementedException();
        }

        public List<AzureRmRecoveryServicesBackupRecoveryPointBase> ListRecoveryPoints()
        {
            throw new NotImplementedException();
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

            ValidateAzureSqlWorkloadType(workloadType);
            
            // validate RetentionPolicy
            ValidateAzureSqlRetentionPolicy(retentionPolicy);
            Logger.Instance.WriteDebug("Validation of Retention policy is successful");

            // construct Hydra policy request            
            ProtectionPolicyRequest hydraRequest = new ProtectionPolicyRequest()
            {
                Item = new ProtectionPolicyResource()
                {
                    Properties = new AzureSqlProtectionPolicy()
                    {
                         RetentionPolicy = PolicyHelpers.GetHydraSimpleRetentionPolicy(
                                                (AzureRmRecoveryServicesBackupSimpleRetentionPolicy)retentionPolicy)
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

            AzureRmRecoveryServicesBackupPolicyBase policy =
                ProviderData.ProviderParameters.ContainsKey(PolicyParams.ProtectionPolicy) ?
                (AzureRmRecoveryServicesBackupPolicyBase)ProviderData.ProviderParameters[PolicyParams.ProtectionPolicy] :
                null;

            // RetentionPolicy 
            if (retentionPolicy == null)
            {
                throw new ArgumentException(Resources.RetentionPolicyEmptyInAzureSql);
            }
            else
            {
                ValidateAzureSqlRetentionPolicy(retentionPolicy);
                ((AzureRmRecoveryServicesAzureSqlPolicy)policy).RetentionPolicy = retentionPolicy;
                Logger.Instance.WriteDebug("Validation of Retention policy is successful");
            }

            ProtectionPolicyRequest hydraRequest = new ProtectionPolicyRequest()
            {
                Item = new ProtectionPolicyResource()
                {
                    Properties = new AzureSqlProtectionPolicy()
                    {
                        RetentionPolicy = PolicyHelpers.GetHydraSimpleRetentionPolicy(
                                  (AzureRmRecoveryServicesBackupSimpleRetentionPolicy)((AzureRmRecoveryServicesAzureSqlPolicy)policy).RetentionPolicy)
                    }
                }
            };

            return HydraAdapter.CreateOrUpdateProtectionPolicy(policy.Name,
                                                               hydraRequest);
        }

        public List<Models.AzureRmRecoveryServicesBackupContainerBase> ListProtectionContainers()
        {
            throw new NotImplementedException();
        }

        public List<AzureRmRecoveryServicesBackupEngineBase> ListBackupManagementServers()
        {
            throw new NotImplementedException();
        }

        public AzureRmRecoveryServicesBackupSchedulePolicyBase GetDefaultSchedulePolicyObject()
        {
            throw new ArgumentException(string.Format(Resources.SchedulePolicyObjectNotRequiredForAzureSql));
        }
       
        public AzureRmRecoveryServicesBackupRetentionPolicyBase GetDefaultRetentionPolicyObject()
        {
            AzureRmRecoveryServicesBackupSimpleRetentionPolicy defaultRetention = new AzureRmRecoveryServicesBackupSimpleRetentionPolicy();
            defaultRetention.RetentionDuration = new Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.RetentionDuration();
            defaultRetention.RetentionDuration.RetentionDurationType = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.RetentionDurationType.Days;
            defaultRetention.RetentionDuration.RetentionCount = 180;
            return defaultRetention;
        }

        public List<Models.AzureRmRecoveryServicesBackupItemBase> ListProtectedItems()
        {
            throw new NotImplementedException();
        }

        #region private
        private void ValidateAzureSqlWorkloadType(Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType type)
        {
            if (type != Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType.AzureSql)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedWorkLoadTypeException,
                                            Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType.AzureSql.ToString(),
                                            type.ToString()));
            }
        }

        private void ValidateAzureSqlProtectionPolicy(AzureRmRecoveryServicesBackupPolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureRmRecoveryServicesAzureSqlPolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureRmRecoveryServicesAzureSqlPolicy).ToString()));
            }

            ValidateAzureSqlWorkloadType(policy.WorkloadType);

            // call validation
            policy.Validate();
        }

        private void ValidateAzureSqlRetentionPolicy(AzureRmRecoveryServicesBackupRetentionPolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureRmRecoveryServicesBackupSimpleRetentionPolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidRetentionPolicyException,
                                            typeof(AzureRmRecoveryServicesBackupSimpleRetentionPolicy).ToString()));
            }

            // call validation
            policy.Validate();
        }
        #endregion
    }
}
