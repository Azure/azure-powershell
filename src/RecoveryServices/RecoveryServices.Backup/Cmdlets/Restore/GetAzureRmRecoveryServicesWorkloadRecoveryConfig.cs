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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Restores an item using the recovery point provided within the recovery services vault
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesWorkloadRecoveryConfig",
        DefaultParameterSetName = RpParameterSet, SupportsShouldProcess = true), OutputType(typeof(AzureWorkloadRecoveryConfig))]
    public class GetAzureRmRecoveryServicesWorkloadRecoveryConfig : RSBackupVaultCmdletBase
    {
        internal const string RpParameterSet = "AzureVMParameterSet";
        internal const string LogChainParameterSet = "AzureFileParameterSet";

        /// <summary>
        /// Recovery point of the item to be restored
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0,
             ParameterSetName = RpParameterSet, HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
        [ValidateNotNullOrEmpty]
        public RecoveryPointBase RecoveryPoint { get; set; }

        /// <summary>
        /// End time of Time range for which recovery points need to be fetched
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, Position = 0,
            ParameterSetName = LogChainParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.EndDate)]
        [ValidateNotNullOrEmpty]
        public DateTime PointInTime { get; set; }

        /// <summary>
        /// Protected Item object for which recovery points need to be fetched
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, Position = 1,
            HelpMessage = ParamHelpMsgs.RecoveryPointConfig.TargetItem)]
        [ValidateNotNullOrEmpty]
        public ItemBase TargetItem { get; set; }

        /// <summary>
        /// Protected Item object for which recovery points need to be fetched
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = false, Position = 2,
            HelpMessage = ParamHelpMsgs.RecoveryPointConfig.Item)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

        /// <summary>
        /// Use this switch if the disks from the recovery point are to be restored to their original storage accounts
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RecoveryPointConfig.OriginalWorkloadRestore)]
        public SwitchParameter OriginalWorkloadRestore { get; set; }

        /// <summary>
        /// Use this switch if the disks from the recovery point are to be restored to their original storage accounts
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RecoveryPointConfig.AlternateWorkloadRestore)]
        public SwitchParameter AlternateWorkloadRestore { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;
                Dictionary<Enum, object> providerParameters = new Dictionary<Enum, object>();

                providerParameters.Add(VaultParams.VaultName, vaultName);
                providerParameters.Add(VaultParams.ResourceGroupName, resourceGroupName);
                providerParameters.Add(WorkloadRecoveryConfigParams.RecoveryPoint, RecoveryPoint);
                providerParameters.Add(WorkloadRecoveryConfigParams.OriginalWorkloadRestore, OriginalWorkloadRestore.IsPresent);
                providerParameters.Add(WorkloadRecoveryConfigParams.AlternateWorkloadRestore, OriginalWorkloadRestore.IsPresent);
                providerParameters.Add(WorkloadRecoveryConfigParams.Item, Item);
                providerParameters.Add(WorkloadRecoveryConfigParams.TargetItem, TargetItem);
                providerParameters.Add(WorkloadRecoveryConfigParams.PointInTime, PointInTime);

                AzureWorkloadRecoveryConfig azureWorkloadRecoveryConfig = new AzureWorkloadRecoveryConfig();
                azureWorkloadRecoveryConfig.SourceResourceId = Item.SourceResourceId;
                if (ParameterSetName == RpParameterSet)
                {
                    azureWorkloadRecoveryConfig.RecoveryPoint = RecoveryPoint;
                }
                else
                {
                    azureWorkloadRecoveryConfig.PointInTime = PointInTime;
                }
                if (OriginalWorkloadRestore.IsPresent)
                {
                    azureWorkloadRecoveryConfig.RestoreRequestType = "Original WL Restore";
                    azureWorkloadRecoveryConfig.TargetServer = null;
                    azureWorkloadRecoveryConfig.TargetInstance = null;
                    azureWorkloadRecoveryConfig.RestoredDBName = Item.Name;
                    azureWorkloadRecoveryConfig.OverwriteWLIfpresent = "No";
                    azureWorkloadRecoveryConfig.NoRecoveryMode = "Disabled";
                }
                else if (AlternateWorkloadRestore.IsPresent)
                {
                    azureWorkloadRecoveryConfig.RestoreRequestType = "Alternate WL Restore";
                    azureWorkloadRecoveryConfig.TargetServer = null;
                    //to do
                    azureWorkloadRecoveryConfig.TargetInstance = null;

                    azureWorkloadRecoveryConfig.RestoredDBName = Item.Name + "_restored_" + DateTime.Now.ToUniversalTime().ToString();
                    azureWorkloadRecoveryConfig.OverwriteWLIfpresent = "No";
                    azureWorkloadRecoveryConfig.NoRecoveryMode = "Disabled";
                }
                else if (Item != null && TargetItem != null)
                {
                    azureWorkloadRecoveryConfig.RestoreRequestType = "Alternate WL Restore to diff item";
                    //todo
                    azureWorkloadRecoveryConfig.TargetServer = null;
                    azureWorkloadRecoveryConfig.TargetInstance = null;

                    azureWorkloadRecoveryConfig.RestoredDBName = Item.Name + "_restored_" + DateTime.Now.ToUniversalTime().ToString();
                    azureWorkloadRecoveryConfig.OverwriteWLIfpresent = "No";
                    azureWorkloadRecoveryConfig.NoRecoveryMode = "Disabled";
                }
                WriteObject(azureWorkloadRecoveryConfig);
            });
        }
    }
}