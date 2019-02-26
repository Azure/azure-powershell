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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Enables backup of an item protected by the recovery services vault.
    /// Returns the corresponding job created in the service to track this backup operation.
    /// </summary>
    [Cmdlet("Backup", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupItem", SupportsShouldProcess = true), OutputType(typeof(JobBase))]
    public class BackupAzureRmRecoveryServicesBackupItem : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// The protected item on which backup has to be triggered.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsgs.Item.ProtectedItem,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

        /// <summary>
        /// The protected item on which backup has to be triggered.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Item.ExpiryDateTimeUTC,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public DateTime? ExpiryDateTimeUTC { get; set; }

        /// <summary>
        /// The protected item on which backup has to be triggered.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Item.BackupType,
            ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public BackupType BackupType { get; set; }

        /// <summary>
        /// The protected item on which backup has to be triggered.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Item.EnableCompression,
            ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter EnableCompression { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                PsBackupProviderManager providerManager =
                    new PsBackupProviderManager(new Dictionary<Enum, object>()
                    {
                        {VaultParams.VaultName, vaultName},
                        {VaultParams.ResourceGroupName, resourceGroupName},
                        {ItemParams.Item, Item},
                        {ItemParams.ExpiryDateTimeUTC, ExpiryDateTimeUTC},
                        {ItemParams.BackupType, BackupType},
                        {ItemParams.EnableCompression, EnableCompression.IsPresent},
                    }, ServiceClientAdapter);

                IPsBackupProvider psBackupProvider =
                    providerManager.GetProviderInstance(Item.WorkloadType, Item.BackupManagementType);
                var jobResponse = psBackupProvider.TriggerBackup();

                HandleCreatedJob(
                    jobResponse,
                    Resources.TriggerBackupOperation,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName);
            }, ShouldProcess(Item.Name, VerbsData.Backup));
        }
    }
}
