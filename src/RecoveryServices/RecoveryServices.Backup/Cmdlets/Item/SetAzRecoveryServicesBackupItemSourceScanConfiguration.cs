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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Configures the Source Scan (Microsoft Defender for Cloud) state of a protected item, either
    /// enabling or disabling it, while preserving all other properties of the protected item.
    /// </summary>
    [Alias("Set-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBISourceScanConfiguration")]
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupItemSourceScanConfiguration", SupportsShouldProcess = true), OutputType(typeof(JobBase))]
    public class SetAzRecoveryServicesBackupItemSourceScanConfiguration : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// The protected item for which Source Scan is to be configured.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsgs.Item.SourceScanItem,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

        /// <summary>
        /// Source Scan state to be set for the item. Allowed values are Enabled, Disabled.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, HelpMessage = ParamHelpMsgs.Item.SourceScanState)]
        [ValidateSet("Enabled", "Disabled")]
        public string State { get; set; }

        /// <summary>
        /// Prevents the confirmation dialog when specified.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Item.SourceScanForceOption)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                // Source Scan (Microsoft Defender for Cloud) is currently only offered for Azure
                // Virtual Machine backup items; other workloads are rejected up front.
                if (Item.BackupManagementType != BackupManagementType.AzureVM ||
                    Item.WorkloadType != WorkloadType.AzureVM)
                {
                    throw new ArgumentException(Resources.SourceScanNotSupportedForItem);
                }

                Action configureSourceScan = () =>
                {
                    ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                    string vaultName = resourceIdentifier.ResourceName;
                    string resourceGroupName = resourceIdentifier.ResourceGroupName;

                    var uriDict = HelperUtils.ParseUri(Item.Id);
                    string containerUri = HelperUtils.GetContainerUri(uriDict, Item.Id);
                    string protectedItemUri = HelperUtils.GetProtectedItemUri(uriDict, Item.Id);

                    ServiceClientModel.ProtectedItemConfigureSourceScanRequest request =
                        new ServiceClientModel.ProtectedItemConfigureSourceScanRequest
                        {
                            SourceScanAction = State == "Enabled" ?
                                ServiceClientModel.SourceScanAction.Enable :
                                ServiceClientModel.SourceScanAction.Disable
                        };

                    var response = ServiceClientAdapter.ConfigureProtectedItemSourceScan(
                        containerUri,
                        protectedItemUri,
                        request,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);

                    var jobObj = HandleCreatedJob(
                        response,
                        Resources.ConfigureSourceScanOperation,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName,
                        returnJobObject: true);

                    WriteObject(jobObj);
                };

                if (State == "Disabled")
                {
                    ConfirmAction(
                        Force.IsPresent,
                        string.Format(Resources.ConfigureSourceScanWarning, Item.Name, State),
                        Resources.ConfigureSourceScanMessage,
                        Item.Name,
                        configureSourceScan);
                }
                else
                {
                    configureSourceScan();
                }
            }, ShouldProcess(Item.Name, "Configure Source Scan"));
        }
    }
}
