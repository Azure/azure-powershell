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
            base.ExecuteCmdlet();

            string rgName = "";  // TBD
            string resourceName = "";  // TBD
            List<AzureRmRecoveryServicesPolicyBase> respList = new List<AzureRmRecoveryServicesPolicyBase>();

            switch(this.ParameterSetName)
            {
                case PolicyNameParamSet:
                    // validate policyName
                    PolicyCmdletHelpers.ValidateProtectionPolicyName(Name);

                    // query service
                    HydraModel.ProtectionPolicyResponse policy = PolicyCmdletHelpers.GetProtectionPolicyByName(
                                                      Name,
                                                      HydraAdapter,
                                                      rgName,
                                                      resourceName);
                    respList.Add(ConversionHelpers.GetPolicyModel(policy.Item));
                    break;

                // below cases TBD
                case WorkloadParamSet:
                    break;

                case WorkloadBackupMangementTypeParamSet:
                    break;

                case NoParamSet:
                    break;

                default:
                    break;
            }

            WriteObject(respList);
        }
    }
}
