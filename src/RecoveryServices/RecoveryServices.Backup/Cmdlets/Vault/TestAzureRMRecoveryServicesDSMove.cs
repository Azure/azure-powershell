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
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using System.Collections.Generic;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Used for  validtaing Data Source Move operation. The command runs successfully if the DS move is feasible.
    /// </summary>
    [Cmdlet("Test", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesDSMove", SupportsShouldProcess = true), OutputType(typeof(Boolean))]
    public class TestAzureRMRecoveryServicesDSMove : RecoveryServicesBackupCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Source Vault for Data Move Operation
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsgs.DSMove.SourceVault,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault SourceVault;

        /// <summary>
        /// Target Vault for Data Move Operation
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, HelpMessage = ParamHelpMsgs.DSMove.TargetVault,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault TargetVault;

        /// <summary>
        /// Prevents the confirmation dialog when specified.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.DSMove.ForceOption)]
        public SwitchParameter Force { get; set; }

        #endregion Parameters

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                // fetch source vault and target vault subscription
                Dictionary<CmdletModel.UriEnums, string> TargetVaultDict = HelperUtils.ParseUri(TargetVault.ID);
                string targetSub = TargetVaultDict[CmdletModel.UriEnums.Subscriptions];

                // set target subscription 
                string subscriptionContext = ServiceClientAdapter.BmsAdapter.Client.SubscriptionId;
                ServiceClientAdapter.BmsAdapter.Client.SubscriptionId = targetSub;


                // Check if the Target vault is empty
                // Check the containers count in target vault
                var protectionContainersCount = BackupUtils.GetProtectionContainersCount(TargetVault.Name, TargetVault.ResourceGroupName, ServiceClientAdapter);

                Logger.Instance.WriteDebug("Protection Containers within vault: " + TargetVault.Name + " and resource Group: "
                    + TargetVault.ResourceGroupName + " are " + protectionContainersCount);

                if (protectionContainersCount > 0)
                {
                    throw new ArgumentException(string.Format(Resources.TargetVaultNotEmptyException));
                }

                // check the count for VM backupItems

                int vmItemsCount = BackupUtils.GetProtectedItems(TargetVault.Name, TargetVault.ResourceGroupName,
                    BackupManagementType.AzureIaasVM, WorkloadType.VM, ServiceClientAdapter).Count;

                Logger.Instance.WriteDebug("Protected VMs within vault: " + TargetVault.Name + " and resource Group: "
                    + TargetVault.ResourceGroupName + " are " + vmItemsCount);

                if (vmItemsCount > 0)
                {
                    throw new ArgumentException(string.Format(Resources.TargetVaultNotEmptyException));
                }

                // Confirm the target vault storage type
                BackupResourceConfigResource getStorageResponse = ServiceClientAdapter.GetVaultStorageType(
                                                                        TargetVault.ResourceGroupName, TargetVault.Name);

                Logger.Instance.WriteDebug("Target vault storage type: " + getStorageResponse.Properties.StorageType);

                // set subscription to original
                ServiceClientAdapter.BmsAdapter.Client.SubscriptionId = subscriptionContext;

                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.TargetVaultStorageRedundancy, TargetVault.Name, getStorageResponse.Properties.StorageType), 
                    Resources.TargetVaultStorageRedundancy,
                    getStorageResponse.Properties.StorageType, () => 
                    {
                        base.ExecuteCmdlet();
                        
                        WriteObject(true);
                    }
                );
            }, ShouldProcess(TargetVault.Name, VerbsCommon.Set));
        }
    }
}
