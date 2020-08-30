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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Used for Data Source Move operation. Currently we only support vault level data move from one region to another.
    /// </summary>
    [Cmdlet("Copy", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesVault", SupportsShouldProcess = true), OutputType(typeof(String))]
    public class CopyAzureRmRecoveryServicesVault : RecoveryServicesBackupCmdletBase
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
        /// Retries data move only with unmoved containers in the source vault
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.DSMove.RetryOnlyFailed)]
        public SwitchParameter RetryOnlyFailed;

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
                // Check if the Target vault is empty
                /// Check the containers count in target vault                
                var protectionContainersCount = BackupUtils.GetProtectionContainersCount(TargetVault.Name, TargetVault.ResourceGroupName, ServiceClientAdapter);

                Logger.Instance.WriteDebug("Protection Containers within vault: " + TargetVault.Name + " and resource Group: "
                    + TargetVault.ResourceGroupName+ " are "  + protectionContainersCount);

                if (protectionContainersCount > 0)
                {
                    throw new ArgumentException(string.Format(Resources.TargetVaultNotEmptyException)); 
                }

                /// check the count for VM backupItems 
                int vmItemsCount = BackupUtils.GetProtectedItems(TargetVault.Name, TargetVault.ResourceGroupName,
                    BackupManagementType.AzureIaasVM, WorkloadType.VM, ServiceClientAdapter).Count;

                Logger.Instance.WriteDebug("Protected VMs within vault: " + TargetVault.Name + " and resource Group: "
                    + TargetVault.ResourceGroupName + " are " + vmItemsCount);

                if (vmItemsCount > 0) {
                    throw new ArgumentException(string.Format(Resources.TargetVaultNotEmptyException));
                }

                // Confirm the target vault storage type
                BackupResourceConfigResource getStorageResponse = ServiceClientAdapter.GetVaultStorageType(
                                                                        TargetVault.ResourceGroupName, TargetVault.Name);
                
                Logger.Instance.WriteDebug("Storage Type: " + getStorageResponse.Properties.StorageType);

                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.TargetVaultStorageRedundancy,TargetVault.Name, getStorageResponse.Properties.StorageType),
                    Resources.TargetVaultStorageRedundancy,
                    getStorageResponse.Properties.StorageType, () =>
                    {
                        base.ExecuteCmdlet();

                        // Prepare Data Move
                        PrepareDataMoveRequest prepareMoveRequest = new PrepareDataMoveRequest();  
                        prepareMoveRequest.TargetResourceId = TargetVault.ID;
                        prepareMoveRequest.TargetRegion = TargetVault.Location; 

                        /// currently only allowing vault level data move
                        prepareMoveRequest.DataMoveLevel = "Vault";

                        if (RetryOnlyFailed.IsPresent)
                        {
                            prepareMoveRequest.IgnoreMoved = true;
                        }
                        else
                        {
                            prepareMoveRequest.IgnoreMoved = false;
                        }

                        Logger.Instance.WriteDebug("Retry only with failed items : " + prepareMoveRequest.IgnoreMoved);
                        Logger.Instance.WriteDebug("Location of Target vault: " + TargetVault.Location);

                        string correlationId = PrepareDataMove(SourceVault.Name, SourceVault.ResourceGroupName, prepareMoveRequest);

                        // Trigger Data Move
                        TriggerDataMoveRequest triggerMoveRequest = new TriggerDataMoveRequest();
                        triggerMoveRequest.SourceResourceId = SourceVault.ID;
                        triggerMoveRequest.SourceRegion = SourceVault.Location;

                        /// currently only allowing vault level data move
                        triggerMoveRequest.DataMoveLevel = "Vault";
                        triggerMoveRequest.CorrelationId = correlationId;
                        triggerMoveRequest.PauseGC = false;

                        Logger.Instance.WriteDebug("Location of Source vault: " + SourceVault.Location);
                        TriggerDataMove(TargetVault.Name, TargetVault.ResourceGroupName, triggerMoveRequest);

                        WriteObject(ParamHelpMsgs.DSMove.CmdletOutput);
                    }
                );
            }, ShouldProcess(TargetVault.Name, VerbsCommon.Set));
        }

        /// <summary>
        /// This method prepares the source vault for Data Move operation.
        /// </summary>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="prepareMoveRequest"></param>
        public string PrepareDataMove(string vaultName, string resourceGroupName, PrepareDataMoveRequest prepareMoveRequest)
        {
            // prepare move
            var prepareMoveOperationResponse = ServiceClientAdapter.BmsAdapter.Client.BeginBMSPrepareDataMoveWithHttpMessagesAsync(
                           vaultName, resourceGroupName, prepareMoveRequest).Result;

            // track prepare-move operation to success
            var operationStatus = TrackingHelpers.GetOperationStatusDataMove(
                prepareMoveOperationResponse,
                operationId => ServiceClientAdapter.GetDataMoveOperationStatus(operationId, vaultName, resourceGroupName));

            Logger.Instance.WriteDebug("Prepare move operation: " + operationStatus.Body.Status);

            // get the correlation Id and return it for trigger data move
            var operationResult = TrackingHelpers.GetCorrelationId(
                prepareMoveOperationResponse,
                operationId => ServiceClientAdapter.GetPrepareDataMoveOperationResult(operationId, vaultName, resourceGroupName));

            Logger.Instance.WriteDebug("Prepare move - correlationId:" + operationResult.CorrelationId);

            return operationResult.CorrelationId;
        }

        /// <summary>
        /// This method triggers the Data Move operation on Target vault.
        /// </summary>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="triggerMoveRequest"></param>
        public void TriggerDataMove(string vaultName, string resourceGroupName, TriggerDataMoveRequest triggerMoveRequest)
        {
            //trigger move 
            var triggerMoveOperationResponse = ServiceClientAdapter.BmsAdapter.Client.BeginBMSTriggerDataMoveWithHttpMessagesAsync(
                           vaultName, resourceGroupName, triggerMoveRequest).Result;

            // track trigger-move operation to success
            var operationStatus = TrackingHelpers.GetOperationStatusDataMove(
                triggerMoveOperationResponse,
                operationId => ServiceClientAdapter.GetDataMoveOperationStatus(operationId, vaultName, resourceGroupName));

            Logger.Instance.WriteDebug("Trigger move operation: " + operationStatus.Body.Status);

        }
    }
}
