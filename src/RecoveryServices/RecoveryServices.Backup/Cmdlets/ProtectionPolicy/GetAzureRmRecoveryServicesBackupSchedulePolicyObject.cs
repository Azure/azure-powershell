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
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Returns a schedule policy PS object which can be modified in the PS shell 
    /// and fed to other cmdlets which accept it.
    /// </summary>
    [GenericBreakingChangeWithVersion("May 2025 onwards, this command will return a schedule policy object for Enhanced policy by default for AzureVM workload", "14.0.0", "8.0.0")]
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupSchedulePolicyObject"),OutputType(typeof(SchedulePolicyBase))]
    public class GetAzureRmRecoveryServicesBackupSchedulePolicyObject : RecoveryServicesBackupCmdletBase
    {
        /// <summary>
        /// List of supported BackupManagementTypes for this cmdlet. Used in help text creation.
        /// </summary>
        private const string validBackupManagementTypes = "AzureVM, AzureWorkload, AzureStorage";

        /// <summary>
        /// List of supported WorkloadTypes for this cmdlet. Used in help text creation.
        /// </summary>
        private const string validWorkloadTypes = "AzureVM, MSSQL, AzureFiles";

        /// <summary>
        /// Workload type of the policy to be created.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0,
            HelpMessage = ParamHelpMsgs.Common.WorkloadType + validWorkloadTypes)]
        [ValidateNotNullOrEmpty]
        public WorkloadType WorkloadType { get; set; }
                
        /// <summary>
        /// Backup management type of the policy to be created.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1,
            HelpMessage = ParamHelpMsgs.Common.BackupManagementType + validBackupManagementTypes)]
        [ValidateNotNullOrEmpty]
        public BackupManagementType? BackupManagementType { get; set; }

        /// <summary>
        /// Schedule run frequency for the policy. 
        /// </summary>
        [Parameter(Mandatory = false, Position = 2,
            HelpMessage = ParamHelpMsgs.Policy.ScheduleRunFrequency)]
        [ValidateSet("Daily", "Hourly", "Weekly")]
        public ScheduleRunType ScheduleRunFrequency = ScheduleRunType.Daily;

        private PSPolicyType? _policySubType;
        /// <summary>
        /// Schedule policy subtype. 
        /// </summary>
        [Parameter(Mandatory = false, Position = 3,
            HelpMessage = ParamHelpMsgs.Policy.SchedulePolicySubType)]
        public PSPolicyType PolicySubType
        {
            get
            {
                if(_policySubType == null)
                {
                    if(WorkloadType == WorkloadType.AzureVM)
                    {
                        return PSPolicyType.Enhanced;
                    }
                    else
                    {
                        return PSPolicyType.Standard;
                    }
                }
                return (PSPolicyType)_policySubType;
            }
            set
            {
                _policySubType = value;
            }
        }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                Dictionary<Enum, object> providerParameters = new Dictionary<Enum, object>();
                providerParameters.Add(PolicyParams.ScheduleRunFrequency, ScheduleRunFrequency);
                providerParameters.Add(PolicyParams.PolicySubType, PolicySubType);

                if (ScheduleRunFrequency != ScheduleRunType.Daily && WorkloadType != WorkloadType.AzureVM && WorkloadType != WorkloadType.AzureFiles)
                {
                    throw new ArgumentException(Resources.UnexpectedParamScheduleRunFrequency);
                }
                
                if(ScheduleRunFrequency == ScheduleRunType.Weekly && WorkloadType == WorkloadType.AzureFiles)
                {
                    throw new ArgumentException(Resources.WeeklyScheduleNotSupported);
                }

                if (PolicySubType == PSPolicyType.Enhanced && WorkloadType != WorkloadType.AzureVM)
                {
                    throw new ArgumentException(Resources.EnhancedPolicyNotSupported);
                }

                PsBackupProviderManager providerManager = new PsBackupProviderManager(
                    providerParameters, ServiceClientAdapter);

                IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(
                    WorkloadType, BackupManagementType);
                WriteObject(psBackupProvider.GetDefaultSchedulePolicyObject());
            });
        }
    }
}
