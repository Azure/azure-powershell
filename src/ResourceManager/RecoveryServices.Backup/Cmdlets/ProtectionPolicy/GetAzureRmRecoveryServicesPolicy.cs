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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using HydraModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Get list of protection policies
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesProtectionPolicy", DefaultParameterSetName = NoParamSet), OutputType(typeof(List<AzureRmRecoveryServicesPolicyBase>))]
    public class GetAzureRmRecoveryServicesProtectionPolicy : RecoveryServicesBackupCmdletBase
    {
        protected const string PolicyNameParamSet = "PolicyNameParamSet";
        protected const string WorkloadParamSet = "WorkloadParamSet";
        protected const string NoParamSet = "NoParamSet";
        protected const string WorkloadBackupMangementTypeParamSet = "WorkloadBackupManagementTypeParamSet";

        [Parameter(ParameterSetName = PolicyNameParamSet, Mandatory = true, HelpMessage = ParamHelpMsg.Policy.Name)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = WorkloadParamSet, Mandatory = true, HelpMessage = ParamHelpMsg.Common.WorkloadType)]
        [Parameter(ParameterSetName = WorkloadBackupMangementTypeParamSet, Mandatory = true, HelpMessage = ParamHelpMsg.Common.WorkloadType)]
        [ValidateNotNullOrEmpty]
        public WorkloadType WorkloadType { get; set; }

        [Parameter(ParameterSetName = WorkloadBackupMangementTypeParamSet, Mandatory = false, HelpMessage = ParamHelpMsg.Common.BackupManagementType)]
        [ValidateNotNullOrEmpty]
        public BackupManagementType BackupManagementType { get; set; }

        public override void ExecuteCmdlet()
        {
           ExecutionBlock(() =>
           {
               base.ExecuteCmdlet();

               List<AzureRmRecoveryServicesPolicyBase> policyList = new List<AzureRmRecoveryServicesPolicyBase>();

               if (this.ParameterSetName == PolicyNameParamSet)
               {
                   // validate policyName
                   PolicyCmdletHelpers.ValidateProtectionPolicyName(Name);

                   // query service
                   HydraModel.ProtectionPolicyResponse policy = PolicyCmdletHelpers.GetProtectionPolicyByName(
                                                     Name,
                                                     HydraAdapter);
                   if (policy == null)
                   {
                       throw new ArgumentException(string.Format(Resources.PolicyNotFoundException, Name));
                   }
                   policyList.Add(ConversionHelpers.GetPolicyModel(policy.Item));
               }
               else
               {
                   string hydraProviderType = null;
                   string hydraDataSourceType = null;

                   switch (this.ParameterSetName)
                   {
                       case WorkloadParamSet:
                           if (WorkloadType == Models.WorkloadType.AzureVM)
                           {
                               hydraProviderType = HydraHelpers.GetHydraProviderType(WorkloadType);
                           }
                           break;

                       case WorkloadBackupMangementTypeParamSet:
                           if (WorkloadType == Models.WorkloadType.AzureVM)
                           {
                               if (BackupManagementType != Models.BackupManagementType.AzureVM)
                               {
                                   throw new ArgumentException(Resources.AzureVMUnsupportedBackupManagementTypeException);
                               }
                               hydraProviderType = HydraHelpers.GetHydraProviderType(WorkloadType);
                           }
                           else
                           {
                               throw new ArgumentException(string.Format(
                                           Resources.UnsupportedWorkloadBackupManagementTypeException,       
                                           WorkloadType.ToString(),
                                           BackupManagementType.ToString()));
                           }
                           break;

                       case NoParamSet:
                           // query params should be null by default
                           break;

                       default:
                           break;
                   }

                   HydraModel.ProtectionPolicyQueryParameters queryParams = new HydraModel.ProtectionPolicyQueryParameters()
                   {
                       BackupManagementType = hydraProviderType
                   };
                   HydraModel.ProtectionPolicyListResponse respList = HydraAdapter.ListProtectionPolicy(queryParams);
                   if (respList != null && respList.ItemList != null &&
                       respList.ItemList.Value != null && respList.ItemList.Value.Count != 0)
                   {
                       foreach (HydraModel.ProtectionPolicyResource policy in respList.ItemList.Value)
                       {
                           AzureRmRecoveryServicesPolicyBase psModel = ConversionHelpers.GetPolicyModel(policy);
                           if (psModel != null)
                           {
                               policyList.Add(ConversionHelpers.GetPolicyModel(policy));
                           }
                       }
                   }
               }

               WriteObject(policyList);
           });
        }
    }
}
