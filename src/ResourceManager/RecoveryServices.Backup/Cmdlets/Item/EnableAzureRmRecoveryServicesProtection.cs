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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using HydraModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;


namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Enable Azure Backup protection
    /// </summary>
    [Cmdlet(VerbsLifecycle.Enable, "AzureRmRecoveryServicesProtection", DefaultParameterSetName = ModifyProtectionParameterSet), OutputType(typeof(AzureRmRecoveryServicesJobBase))]
    public class EnableAzureRmRecoveryServicesProtection : RecoveryServicesBackupCmdletBase
    {
        internal const string AzureVMClassicComputeParameterSet = "AzureVMClassicComputeEnableProtection";
        internal const string AzureVMComputeParameterSet = "AzureVMComputeEnableProtection";
        internal const string ModifyProtectionParameterSet = "ModifyProtection";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AzureVMClassicComputeParameterSet, HelpMessage = ParamHelpMsg.Item.AzureVMName)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AzureVMComputeParameterSet, HelpMessage = ParamHelpMsg.Item.AzureVMName)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AzureVMClassicComputeParameterSet, HelpMessage = ParamHelpMsg.Item.AzureVMServiceName)]
        public string ServiceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AzureVMComputeParameterSet, HelpMessage = ParamHelpMsg.Item.AzureVMResourceGroupName)]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AzureVMClassicComputeParameterSet, HelpMessage = ParamHelpMsg.Common.WorkloadType)]
        [Parameter(Mandatory = true, ParameterSetName = AzureVMComputeParameterSet, HelpMessage = ParamHelpMsg.Common.WorkloadType)]
        public WorkloadType WorkLoadType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsg.Policy.ProtectionPolicy)]
        [ValidateNotNullOrEmpty]
        public AzureRmRecoveryServicesPolicyBase Policy { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ModifyProtectionParameterSet, HelpMessage = ParamHelpMsg.Item.ProtectedItem, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public AzureRmRecoveryServicesItemBase Item { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();
                
                PsBackupProviderManager providerManager = new PsBackupProviderManager(new Dictionary<System.Enum, object>()
                {  
                    {ItemParams.AzureVMName, Name},
                    {ItemParams.AzureVMCloudServiceName, ServiceName},
                    {ItemParams.AzureVMResourceGroupName, ResourceGroupName},
                    {ItemParams.WorkloadType, WorkLoadType},
                    {ItemParams.Policy, Policy},
                    {ItemParams.Item, Item},
                    {ItemParams.ParameterSetName, this.ParameterSetName},
                }, HydraAdapter);

                IPsBackupProvider psBackupProvider = (Item != null) ? providerManager.GetProviderInstance(WorkLoadType, Item.BackupManagementType)
                    : providerManager.GetProviderInstance(WorkLoadType);

                var jobResponse = psBackupProvider.EnableProtection();

                // Track Response and display job details
                // -- TBD to move it to common helper and remove hard-coded vaules

                var response = OperationStatusHelper.TrackOperationStatus(jobResponse, HydraAdapter);

                if (response.OperationStatus.Status == HydraModel.OperationStatusValues.Succeeded)
                {
                    var jobStatusResponse = (HydraModel.OperationStatusJobExtendedInfo)response.OperationStatus.Properties;
                    string jobId = jobStatusResponse.JobId;
                    var job = HydraAdapter.GetJob(jobId);
                    WriteObject(JobConversions.GetPSJob(job));
                }
                else if(response.OperationStatus.Status == HydraModel.OperationStatusValues.Failed)
                {
                    var jobStatusResponse = (HydraModel.OperationStatusJobExtendedInfo)response.OperationStatus.Properties;
                    if(jobStatusResponse != null || !string.IsNullOrEmpty(jobStatusResponse.JobId))
                    {
                        string jobId = jobStatusResponse.JobId;
                        var job = HydraAdapter.GetJob(jobId);
                        WriteObject(JobConversions.GetPSJob(job));
                    }

                    var errorMessage = string.Format(Resources.EnableProtectionOperationFailed,
                    response.OperationStatus.OperationStatusError.Code,
                    response.OperationStatus.OperationStatusError.Message);

                    throw new Exception(errorMessage);
                }
            });
        }
    }
}
