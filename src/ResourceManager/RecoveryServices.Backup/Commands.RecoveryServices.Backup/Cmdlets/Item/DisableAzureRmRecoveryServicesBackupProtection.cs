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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;


namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Disable protection of an item protected by the recovery services vault. 
    /// Returns the corresponding job created in the service to track this operation.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Disable, "AzureRmRecoveryServicesBackupProtection", SupportsShouldProcess = true), 
    OutputType(typeof(JobBase))]
    public class DisableAzureRmRecoveryServicesBackupProtection : RecoveryServicesBackupCmdletBase
    {
        /// <summary>
        /// The protected item whose protection needs to be disabled.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsgs.Item.ProtectedItem, 
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

        /// <summary>
        /// If this option is used, all the data backed up for this item will 
        /// also be deleted and restoring the data will not be possible.
        /// </summary>
        [Parameter(Position = 2, Mandatory = false, 
            HelpMessage = ParamHelpMsgs.Item.RemoveProtectionOption)]
        public SwitchParameter RemoveRecoveryPoints
        {
            get { return DeleteBackupData; }
            set { DeleteBackupData = value; }
        }

        /// <summary>
        /// Prevents the confirmation dialog when specified.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Item.ForceOption)]
        public SwitchParameter Force { get; set; }

        private bool DeleteBackupData;

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.DisableProtectionWarning, Item.Name),
                Resources.DisableProtectionMessage,
                Item.Name, () =>
                {
                    ExecutionBlock(() =>
                    {
                        base.ExecuteCmdlet();
                        PsBackupProviderManager providerManager = 
                            new PsBackupProviderManager(new Dictionary<System.Enum, object>()
                        {
                            {ItemParams.Item, Item},
                            {ItemParams.DeleteBackupData, this.DeleteBackupData},
                        }, ServiceClientAdapter);

                        IPsBackupProvider psBackupProvider = 
                            providerManager.GetProviderInstance(Item.WorkloadType, 
                            Item.BackupManagementType);

                        var itemResponse = psBackupProvider.DisableProtection();

                        // Track Response and display job details

                        HandleCreatedJob(itemResponse, Resources.DisableProtectionOperation);
                    });
                });

        }
    }
}
