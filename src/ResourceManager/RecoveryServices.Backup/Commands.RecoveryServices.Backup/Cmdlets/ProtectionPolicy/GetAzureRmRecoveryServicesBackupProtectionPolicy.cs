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
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Gets the list of protection policies associated with this recovery services vault
    /// according to the filters passed via the cmdlet parameters.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesBackupProtectionPolicy", DefaultParameterSetName = NoParamSet),
            OutputType(typeof(PolicyBase), typeof(IList<PolicyBase>))]
    public class GetAzureRmRecoveryServicesBackupProtectionPolicy : RecoveryServicesBackupCmdletBase
    {
        protected const string PolicyNameParamSet = "PolicyNameParamSet";
        protected const string WorkloadParamSet = "WorkloadParamSet";
        protected const string NoParamSet = "NoParamSet";
        protected const string WorkloadBackupMangementTypeParamSet = "WorkloadBackupManagementTypeParamSet";

        /// <summary>
        /// Name of the policy to be fetched.
        /// </summary>
        [Parameter(ParameterSetName = PolicyNameParamSet, Position = 1,
            Mandatory = true, HelpMessage = ParamHelpMsgs.Policy.Name)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Workload type of the policy to be fetched
        /// </summary>
        [Parameter(ParameterSetName = WorkloadParamSet, Position = 2,
            Mandatory = true, HelpMessage = ParamHelpMsgs.Common.WorkloadType)]
        [Parameter(ParameterSetName = WorkloadBackupMangementTypeParamSet, Position = 2,
            Mandatory = true, HelpMessage = ParamHelpMsgs.Common.WorkloadType)]
        [ValidateNotNullOrEmpty]
        public WorkloadType? WorkloadType { get; set; }

        /// <summary>
        /// Backup management type of the policy to be fetched
        /// </summary>
        [Parameter(ParameterSetName = WorkloadBackupMangementTypeParamSet, Position = 3,
            Mandatory = true, HelpMessage = ParamHelpMsgs.Common.BackupManagementType)]
        [ValidateNotNullOrEmpty]
        public BackupManagementType? BackupManagementType { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                WriteDebug(string.Format("Input params - Name:{0}, " +
                                      "WorkloadType: {1}, BackupManagementType:{2}, " +
                                      "ParameterSetName: {3}",
                                      Name == null ? "NULL" : Name,
                                      WorkloadType.HasValue ? WorkloadType.ToString() : "NULL",
                                      BackupManagementType.HasValue ?
                                      BackupManagementType.ToString() : "NULL",
                                      this.ParameterSetName));

                if (this.ParameterSetName == PolicyNameParamSet)
                {
                    // validate policyName
                    PolicyCmdletHelpers.ValidateProtectionPolicyName(Name);

                    // query service
                    ServiceClientModel.ProtectionPolicyResponse policy =
                        PolicyCmdletHelpers.GetProtectionPolicyByName(
                                                      Name,
                                                      ServiceClientAdapter);
                    if (policy == null)
                    {
                        throw new ArgumentException(string.Format(Resources.PolicyNotFoundException, Name));
                    }

                    WriteObject(ConversionHelpers.GetPolicyModel(policy.Item));
                }
                else
                {
                    List<PolicyBase> policyList = new List<PolicyBase>();
                    string serviceClientProviderType = null;

                    switch (this.ParameterSetName)
                    {
                        case WorkloadParamSet:
                            if (WorkloadType == Models.WorkloadType.AzureVM)
                            {
                                serviceClientProviderType =
                                    ServiceClientHelpers.GetServiceClientProviderType(Models.WorkloadType.AzureVM);
                            }
                            else if (WorkloadType == Models.WorkloadType.AzureSQLDatabase)
                            {
                                serviceClientProviderType = ServiceClientHelpers.GetServiceClientProviderType(Models.WorkloadType.AzureSQLDatabase);
                            }
                            break;

                        case WorkloadBackupMangementTypeParamSet:
                            if (WorkloadType == Models.WorkloadType.AzureVM)
                            {
                                if (BackupManagementType != Models.BackupManagementType.AzureVM)
                                {
                                    throw new ArgumentException(
                                        Resources.AzureVMUnsupportedBackupManagementTypeException);
                                }
                                serviceClientProviderType = ServiceClientHelpers.
                                    GetServiceClientProviderType(Models.WorkloadType.AzureVM);
                            }
                            else if (WorkloadType == Models.WorkloadType.AzureSQLDatabase)
                            {
                                if (BackupManagementType != Models.BackupManagementType.AzureSQL)
                                {
                                    throw new ArgumentException(
                                        Resources.AzureSqlUnsupportedBackupManagementTypeException);
                                }
                                serviceClientProviderType =
                                    ServiceClientHelpers.GetServiceClientProviderType(
                                        Models.WorkloadType.AzureSQLDatabase);
                            }
                            else
                            {
                                throw new ArgumentException(string.Format(
                                    Resources.UnsupportedWorkloadBackupManagementTypeException,
                                    WorkloadType.ToString(),
                                    BackupManagementType.ToString()));
                            }
                            break;

                        default:
                            break;
                    }

                    ServiceClientModel.ProtectionPolicyQueryParameters queryParams =
                        new ServiceClientModel.ProtectionPolicyQueryParameters()
                    {
                        BackupManagementType = serviceClientProviderType
                    };

                    WriteDebug("going to query service to get list of policies");
                    ServiceClientModel.ProtectionPolicyListResponse respList =
                        ServiceClientAdapter.ListProtectionPolicy(queryParams);
                    WriteDebug("Successfully got response from service");

                    policyList = ConversionHelpers.GetPolicyModelList(respList);
                    WriteObject(policyList, enumerateCollection: true);
                }
            });
        }
    }
}
