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
using Microsoft.Rest.Azure.OData;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Configures the Source Scan (Microsoft Defender for Cloud) state of a protected item, either
    /// enabling or disabling it, while preserving all other properties of the protected item.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupSourceScan", SupportsShouldProcess = true), OutputType(typeof(JobBase))]
    public class SetAzRecoveryServicesBackupSourceScan : RSBackupVaultCmdletBase
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

                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.ConfigureSourceScanWarning, Item.Name, State),
                    Resources.ConfigureSourceScanMessage,
                    Item.Name, () =>
                    {
                        ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                        string vaultName = resourceIdentifier.ResourceName;
                        string resourceGroupName = resourceIdentifier.ResourceGroupName;

                        var uriDict = HelperUtils.ParseUri(Item.Id);
                        string containerUri = HelperUtils.GetContainerUri(uriDict, Item.Id);
                        string protectedItemUri = HelperUtils.GetProtectedItemUri(uriDict, Item.Id);

                        // Fetch the full existing protected item so that PUT preserves every
                        // existing property, per Source Scan protected-item PUT semantics.
                        ODataQuery<ServiceClientModel.GetProtectedItemQueryObject> queryFilter =
                            new ODataQuery<ServiceClientModel.GetProtectedItemQueryObject>(q => q.Expand == "extendedinfo");

                        var getResponse = ServiceClientAdapter.GetProtectedItem(
                            containerUri,
                            protectedItemUri,
                            queryFilter,
                            vaultName: vaultName,
                            resourceGroupName: resourceGroupName);

                        ServiceClientModel.ProtectedItemResource protectedItemResource = getResponse.Body;

                        if (protectedItemResource.Properties.SourceSideScanInfo == null)
                        {
                            protectedItemResource.Properties.SourceSideScanInfo = new ServiceClientModel.SourceSideScanInfo();
                        }

                        protectedItemResource.Properties.SourceSideScanInfo.SourceSideScanStatus =
                            State == "Enabled" ?
                                ServiceClientModel.SourceSideScanStatus.Configured :
                                ServiceClientModel.SourceSideScanStatus.NotConfigured;

                        var response = ServiceClientAdapter.UpdateProtectedItemSourceScan(
                            containerUri,
                            protectedItemUri,
                            protectedItemResource,
                            vaultName: vaultName,
                            resourceGroupName: resourceGroupName);

                        var jobObj = HandleCreatedJob(
                            response,
                            Resources.ConfigureSourceScanOperation,
                            vaultName: vaultName,
                            resourceGroupName: resourceGroupName,
                            returnJobObject: true);

                        WriteObject(jobObj);
                    });
            }, ShouldProcess(Item.Name, "Configure Source Scan"));
        }
    }
}
