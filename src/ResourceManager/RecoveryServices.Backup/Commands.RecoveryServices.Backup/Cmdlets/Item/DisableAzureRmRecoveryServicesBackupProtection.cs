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
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;


namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Enable Azure Backup protection
    /// </summary>
    [Cmdlet(VerbsLifecycle.Disable, "AzureRmRecoveryServicesBackupProtection"), 
    OutputType(typeof(JobBase))]
    public class DisableAzureRmRecoveryServicesBackupProtection : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsgs.Item.ProtectedItem, 
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

        [Parameter(Position = 2, Mandatory = false, 
            HelpMessage = ParamHelpMsgs.Item.RemoveProtectionOption)]
        public SwitchParameter RemoveRecoveryPoints
        {
            get { return DeleteBackupData; }
            set { DeleteBackupData = value; }
        }

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
